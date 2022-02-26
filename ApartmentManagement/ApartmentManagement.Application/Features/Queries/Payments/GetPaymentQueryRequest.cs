using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Payments
{
    public class GetPaymentQueryRequest:IRequest<GetPaymentQueryResponse>
    {
        public string Guid { get; set; }
    }
}
