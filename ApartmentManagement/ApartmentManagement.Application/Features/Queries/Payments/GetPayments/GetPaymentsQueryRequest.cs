using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Payments.GetPayments
{
    public class GetPaymentsQueryRequest:IRequest<List<GetPaymentsQueryResponse>>
    {
        public bool? IsPaid { get; set; }
    }
}
