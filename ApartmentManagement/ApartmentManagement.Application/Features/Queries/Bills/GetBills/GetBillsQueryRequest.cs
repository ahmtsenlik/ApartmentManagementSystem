using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBills
{
    public class GetBillsQueryRequest:IRequest<IList<GetBillsQueryResponse>>
    {
        public bool? IsPaid { get; set; }
    }
}
