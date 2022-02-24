using MediatR;
using System.Collections.Generic;


namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessagesRequest:IRequest<IList<GetMessagesResponse>>
    {
        public int UserId { get; set; }
    }
}
