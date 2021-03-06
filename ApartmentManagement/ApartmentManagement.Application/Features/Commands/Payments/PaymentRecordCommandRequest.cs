using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Payments
{
    public class PaymentRecordCommandRequest:IRequest
    { 
        public int BillId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public bool IsPaid { get; set; }
        public string Guid { get; set; }

    }
}
