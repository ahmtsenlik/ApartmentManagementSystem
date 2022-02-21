using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommandRequest, SendMessageCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly SendMessageCommandValidator _validator;
        private readonly UserManager<User> _userManager;

        public SendMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper, SendMessageCommandValidator validator, UserManager<User> userManager)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _validator = validator;
            _userManager = userManager;
        }

        public async Task<SendMessageCommandResponse> Handle(SendMessageCommandRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
     
            var sender = await _userManager.FindByIdAsync(request.SenderId);
            if (sender is null)
            {
                return new SendMessageCommandResponse
                {
                    IsSuccess = false,
                    Message = "No sender with this id was found."
                };
            }
            var receiver = await _userManager.FindByIdAsync(request.ReceiverId);
            if (sender is null)
            {
                return new SendMessageCommandResponse
                {
                    IsSuccess = false,
                    Message = "No receiver with this id was found."
                };
            }
            var message =_mapper.Map<Message>(request);

            //var user = _mapper.Map<User>(request);

            message.CreatedDate = DateTime.Now;
            message.IsRead = false;
            message.Sender = sender;
            message.Receiver = receiver;
    
            await _messageRepository.AddAsync(message);

            return new SendMessageCommandResponse
            {
                IsSuccess = true,
                Message = "Message has been sent."
            };
        }
    }
}
