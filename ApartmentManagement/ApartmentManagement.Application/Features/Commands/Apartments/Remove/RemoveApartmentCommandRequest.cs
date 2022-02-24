using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Remove
{
    public class RemoveApartmentCommandRequest:IRequest<RemoveApartmentCommandResponse>
    {
        public int ApartmentId { get; set; }
    }
}

