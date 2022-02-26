using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill.UserId
{
    public class GetBillByUserIdRequest:IRequest<IList<GetBillByUserIdResponse>>
    {
        public int UserId { get; set; }
    }
}
