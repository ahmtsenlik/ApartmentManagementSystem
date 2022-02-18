using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommandRequest>
    {
        public SendMessageCommandValidator()
        {
            RuleFor(c => c.SenderId).NotEmpty().WithMessage("{Sender Id} is required.");

            RuleFor(c => c.ReceiverId).NotEmpty().WithMessage("{Receiver Id} is required.");

            RuleFor(c => c.Title).NotEmpty().WithMessage("{Title} is required.")
                .MaximumLength(256).WithMessage("{Title} can be a maximum of 256 characters.");

            RuleFor(c => c.Content).NotEmpty().WithMessage("{First Name} is required.");
    }
    }
}
