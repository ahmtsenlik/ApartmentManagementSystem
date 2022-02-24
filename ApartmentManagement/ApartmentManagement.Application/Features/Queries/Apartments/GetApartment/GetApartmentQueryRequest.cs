using MediatR;


namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryRequest:IRequest<GetApartmentQueryResponse>
    {
        public int Id { get; set; }
    }
}
