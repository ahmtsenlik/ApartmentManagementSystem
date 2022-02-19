using ApartmentManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Commands.Bills.Add
{
    public class AddBillCommandRequest:IRequest<AddBillCommandResponse>
    {
        public BillType Type { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ApartmentId { get; set; }
    }
}
