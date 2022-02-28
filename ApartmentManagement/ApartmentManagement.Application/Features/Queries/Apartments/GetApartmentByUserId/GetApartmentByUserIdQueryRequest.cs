using MediatR;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartmentByUserId
{
    public class GetApartmentByUserIdQueryRequest:IRequest<GetApartmentByUserIdQueryResponse>
    {
        public int UserId { get; set; }
    }
}
