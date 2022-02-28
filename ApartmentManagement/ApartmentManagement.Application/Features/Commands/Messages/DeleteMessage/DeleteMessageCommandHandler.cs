using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using ApartmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Messages.DeleteMessage
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommandRequest, DeleteMessageCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public DeleteMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<DeleteMessageCommandResponse> Handle(DeleteMessageCommandRequest request, CancellationToken cancellationToken)
        {
            var checkMessage =await _messageRepository.GetSingleAsync(x=>x.Id==request.MessageId,x=>x.Sender,x=>x.Receiver);
            if (checkMessage is null)
            {
                throw new NotFoundException(nameof(checkMessage), request.MessageId);
            }
            if (checkMessage.Receiver.Id==request.UserId || checkMessage.Sender.Id == request.UserId)
            {
                await _messageRepository.RemoveAsync(checkMessage);
                return new DeleteMessageCommandResponse
                {
                    IsSuccess = true,
                    Message = "The message has been successfully deleted."
                };
            }
            throw new NotFoundException(nameof(checkMessage), request.MessageId);





        }
    }
}
