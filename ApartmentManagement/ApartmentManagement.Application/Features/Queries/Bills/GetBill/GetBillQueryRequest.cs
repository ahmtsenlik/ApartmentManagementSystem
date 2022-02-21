using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQueryRequest:IRequest<GetBillQueryResponse>
    {
        public int UserId { get; set; }
    }
}
