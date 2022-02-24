using MediatR;
using System.Collections.Generic;


namespace ApartmentManagement.Application.Features.Queries.Users.GetUsers
{
    public class GetUsersQueryRequest:IRequest<IList<GetUsersQueryResponse>>
    {
    }
}
