using ApartmentManagement.MessageContracts;
using MassTransit;
using Payment.WebAPI.Data.Repository.Abstractions;
using Payment.WebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AparmentManagement.PaymentWebAPI.consumer
{
    public class PaymentConsumer : IConsumer<PaymentRequest>
    {
        private readonly IBus _bus;
        private readonly ICardRepository _cardRepository;
        private readonly IPaymentRecordRepository _paymentRecordRepository;
       

        public PaymentConsumer(IBus bus, ICardRepository cardRepository, IPaymentRecordRepository paymentRecordRepository)
        {
            _bus = bus;
            _cardRepository = cardRepository;
            _paymentRecordRepository = paymentRecordRepository;

        }

        public async Task Consume(ConsumeContext<PaymentRequest> context)
        {
            //data
            var pay = context.Message;

            Uri uri = new Uri(RabbitMqConsts.RabbitMqUri + RabbitMqConsts.ResponseQueue);
            var endPoint = await _bus.GetSendEndpoint(uri);        
        
            var isPaid = false;

            var getCard = await _cardRepository.GetOneAsync(x => x.CardNumber == pay.CardNumber);
            if (getCard is null)
            {
                await endPoint.Send(new PaymentResponse
                {
                    BillId = pay.BillId,
                    FirstName = pay.FirstName,
                    LastName = pay.LastName,
                    IsPaid = false,
                    Message = "Card information is incorrect.",
                    Guid = pay.Guid
                });
                return;
            }

            if (getCard.FirstName == pay.FirstName &&
                getCard.LastName == pay.LastName &&
                getCard.ExpMonth == pay.ExpMonth &&
                getCard.ExpYear == pay.ExpYear &&
                getCard.SecurityCode == pay.SecurityCode)
            {
                if (getCard.Balance > pay.Amount)
                {
                    getCard.Balance -= pay.Amount;
                    isPaid = true;
                    await _cardRepository.Update(getCard);
                }
            }
            else
            {
                await endPoint.Send(new PaymentResponse
                {
                    BillId = pay.BillId,
                    FirstName = pay.FirstName,
                    LastName = pay.LastName,
                    IsPaid = false,
                    Message = "Card information is incorrect.",
                    Guid = pay.Guid
                });
                return;      
            }

            //payment record 
            var payment = new PaymentRecord
            {
                CreateDate = DateTime.Now,
                CardNumber = pay.CardNumber,
                FirstName = pay.FirstName,
                LastName = pay.LastName,
                Description = pay.Description,
                Amount = pay.Amount,
                IsSuccess = isPaid
            };
            await _paymentRecordRepository.AddAsync(payment);
            if (isPaid)
            {
                await endPoint.Send(new PaymentResponse
                {
                    BillId = pay.BillId,
                    FirstName = pay.FirstName,
                    LastName = pay.LastName,
                    IsPaid = true,
                    Message = "Payment is Successful.",
                    Guid = pay.Guid
                });
                return;
                
            }
            await endPoint.Send(new PaymentResponse
            {
                BillId = pay.BillId,
                FirstName = pay.FirstName,
                LastName = pay.LastName,
                IsPaid = false,
                Message = "Insufficient balance.",
                Guid = pay.Guid
            });
            
        }
    }
}
