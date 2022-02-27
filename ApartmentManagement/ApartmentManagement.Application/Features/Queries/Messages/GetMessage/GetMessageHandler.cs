using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using ApartmentManagement.Application.Exceptions;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageHandler : IRequestHandler<GetMessageRequest, GetMessageResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetMessageResponse> Handle(GetMessageRequest request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetSingleAsync(x=>x.Id==request.MessageId,x=>x.Receiver,x=>x.Sender);
            if (message is null)
            {
                throw new NotFoundException(nameof(Message), request.MessageId);
            }
            if (message.Receiver.Id == request.UserId || message.Sender.Id == request.UserId)
            {
                return _mapper.Map<GetMessageResponse>(message);
            }

            throw new NotFoundException(nameof(Message), request.MessageId);
        }
    }
}