using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, IList<GetMessagesResponse>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessagesHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetMessagesResponse>> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAsync(x => x.Sender.Id == request.UserId || x.Receiver.Id == request.UserId, x => x.Sender, x => x.Receiver);

            return _mapper.Map<IList<GetMessagesResponse>>(messages);
        }
    }
}
