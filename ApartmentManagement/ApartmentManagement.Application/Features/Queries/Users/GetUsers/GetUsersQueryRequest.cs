using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Users.GetUsers
{
    public class GetUsersQueryRequest:IRequest<IList<GetUsersQueryResponse>>
    {
    }
}
