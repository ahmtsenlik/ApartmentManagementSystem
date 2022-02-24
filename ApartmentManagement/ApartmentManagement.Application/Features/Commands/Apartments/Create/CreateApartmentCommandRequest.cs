using MediatR;
namespace ApartmentManagement.Application.Features.Commands.Apartments.Create
{
    public class CreateApartmentCommandRequest:IRequest<CreateApartmentCommandResponse>
    {
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
        
    }
}
