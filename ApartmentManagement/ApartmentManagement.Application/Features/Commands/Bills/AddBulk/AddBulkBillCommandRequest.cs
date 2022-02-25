using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Commands.Bills.AddBulk
{
    public class AddBulkBillCommandRequest : IRequest<AddBulkBillCommandResponse>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BillType Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IList<int> Apartments { get; set; }
    }
}
