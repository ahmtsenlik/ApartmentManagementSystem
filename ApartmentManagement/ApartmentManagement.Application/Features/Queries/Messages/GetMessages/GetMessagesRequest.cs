using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessagesRequest:IRequest<IList<GetMessagesResponse>>
    {
        public int UserId { get; set; }
    }
}
