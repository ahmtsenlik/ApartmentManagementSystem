using ApartmentManagement.MessageContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI
{
    public class CheckConsume : IConsumer<PaymentResponse>
    {
        public async Task Consume(ConsumeContext<PaymentResponse> context)
        {
            var data = context.Message;
            Console.WriteLine(data.IsPaid+" basardim");
        }
    }
}
