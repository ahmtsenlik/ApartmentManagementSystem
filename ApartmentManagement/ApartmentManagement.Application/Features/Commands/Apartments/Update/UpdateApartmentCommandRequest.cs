using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Apartments.Update
{
    public class UpdateApartmentCommandRequest:IRequest<UpdateApartmentCommandResponse>
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
    }
}
