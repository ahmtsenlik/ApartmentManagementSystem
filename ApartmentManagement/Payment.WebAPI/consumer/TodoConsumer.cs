using ApartmentManagement.MessageContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AparmentManagement.PaymentWebAPI.consumer
{
    public class TodoConsumer : IConsumer<PaymentRequest>
    {
        private readonly IBus _bus;

        public TodoConsumer(IBus bus)
        {
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<PaymentRequest> context)
        {            
            var data = context.Message;

            Thread.Sleep(2000);

            Uri uri = new Uri(RabbitMqConsts.RabbitMqUri+RabbitMqConsts.ResponseQueue);
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new PaymentResponse { IsPaid=false});
            Console.WriteLine(data.CardNumber);
            
        }
    }
}
