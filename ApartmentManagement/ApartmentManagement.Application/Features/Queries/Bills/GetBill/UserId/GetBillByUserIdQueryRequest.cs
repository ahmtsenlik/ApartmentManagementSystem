using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill.UserId
{
    public class GetBillByUserIdQueryRequest:IRequest<IList<GetBillByUserIdQueryResponse>>
    {
        public int UserId { get; set; }
    }
}
