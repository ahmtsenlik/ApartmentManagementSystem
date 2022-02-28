using ApartmentManagement.MessageContracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payment.WebAPI.Data.Repository.Abstractions;
using Payment.WebAPI.Models;
using Payment.WebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Payment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPaymentRecordRepository _paymentRecordRepository;
        public PayController(ICardRepository cardRepository, IPaymentRecordRepository paymentRecordRepository)
        {
            _cardRepository = cardRepository;
            _paymentRecordRepository = paymentRecordRepository;
        }
        [HttpPost("AddCard")]
        public async Task<ActionResult> AddCard(Card card)
        {
            await _cardRepository.AddAsync(card);
            return Ok();
        }

        //[HttpPost]
        //public async Task<ActionResult> Pay(PaymentRequest pay)
        //{
        //    var isPaid = false;
        //    var getCard = await _cardRepository.GetOneAsync(x => x.CardNumber == pay.CardNumber);
        //    if (getCard is null)
        //    {
        //        return BadRequest("Card information is incorrect.");
        //    }

        //    if (getCard.FirstName==pay.FirstName&&
        //        getCard.LastName==pay.LastName&&
        //        getCard.ExpMonth==pay.ExpMonth&&
        //        getCard.ExpYear==pay.ExpYear&&
        //        getCard.SecurityCode==pay.SecurityCode)
        //    {
        //        if (getCard.Balance>pay.Amount)
        //        {
        //            getCard.Balance -= pay.Amount;
        //            isPaid = true;
        //            await _cardRepository.Update(getCard);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Card information is incorrect.");
        //    }

        //    //payment record 
        //    var payment = new PaymentRecord
        //    {
        //        CreateDate = DateTime.Now,
        //        CardNumber = pay.CardNumber,
        //        FirstName = pay.FirstName,
        //        LastName = pay.LastName,
        //        Description = pay.Description,
        //        Amount = pay.Amount,
        //        IsSuccess = isPaid
        //    };
        //    await _paymentRecordRepository.AddAsync(payment);
        //    if (isPaid)
        //    {
        //        return Ok("Payment is Successful.");
        //    }
        //    return BadRequest("Insufficient balance.");
        //}

    }
}
