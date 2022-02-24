using ApartmentManagement.MessageContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AparmentManagement.PaymentWebAPI.consumer
{
    public class TodoConsumer : IConsumer<Todo>
    {
        public async Task Consume(ConsumeContext<Todo> context)
        {
            var data = context.Message;
            Console.WriteLine(data.mesaj);
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
