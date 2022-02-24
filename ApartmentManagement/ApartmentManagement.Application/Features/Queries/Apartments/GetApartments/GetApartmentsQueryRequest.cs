using MediatR;
using System.Collections.Generic;


namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartments
{
    public class GetApartmentsQueryRequest:IRequest<IList<GetApartmentsQueryResponse>>
    {
    }
}
