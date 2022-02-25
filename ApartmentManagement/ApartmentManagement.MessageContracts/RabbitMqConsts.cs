using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.MessageContracts
{
    public class RabbitMqConsts
    {
        public const string RabbitMqRootUri = "rabbitmq://localhost";
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "admin";
        public const string Password = "admin123";
        public const string RequestQueue = "RequestQueue";
        public const string ResponseQueue = "ResponseQueue";


    }
}
