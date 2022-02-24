using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQueryRequest:IRequest<IList<GetBillQueryResponse>>
    {
        public int UserId { get; set; }
    }
}
