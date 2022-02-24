using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Users.GetUser
{
    public class GetUserQueryRequest:IRequest<GetUserQueryResponse>
    {
        public int Id { get; set; }
    }
}
