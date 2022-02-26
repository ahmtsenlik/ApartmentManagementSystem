using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId
{
    public class GetBillByIdQueryRequest : IRequest<GetBillByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
