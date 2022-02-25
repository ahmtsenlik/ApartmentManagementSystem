using MediatR;
using System.Text.Json.Serialization;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Commands.Bills.Add
{
    public class AddBillCommandRequest:IRequest<AddBillCommandResponse>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BillType Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ApartmentId { get; set; }
    }
}
