using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Commands.Bills.AddBulk
{
    public class AddBulkBillCommandRequest : IRequest<AddBulkBillCommandResponse>
    {
        public BillType Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IList<int> Apartments { get; set; }
    }
}
