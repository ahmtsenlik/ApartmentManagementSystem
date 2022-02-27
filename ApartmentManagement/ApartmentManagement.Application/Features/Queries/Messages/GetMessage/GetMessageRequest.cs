
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageRequest : IRequest<GetMessageResponse>
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
}
