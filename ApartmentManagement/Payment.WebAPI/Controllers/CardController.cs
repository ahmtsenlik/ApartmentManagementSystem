using Microsoft.AspNetCore.Mvc;
using Payment.WebAPI.Data.Repository.Abstractions;
using Payment.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Payment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository cardRepository;
  
        public CardController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }
     
        [HttpPost]
        public async Task<ActionResult> Post(PaymentModel paymentModel)
        {
            
            return Ok();
        }
    }
}
