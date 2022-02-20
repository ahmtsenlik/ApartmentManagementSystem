using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommandRequest>
    {
        public AddUserCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("{UserId} is required.");

            RuleFor(c => c.ApartmentId).NotEmpty().WithMessage("{ApartmentId} is required.");

            RuleFor(c => c.IsOwner).NotEmpty().WithMessage("{IsOwner} is required.");
        }
        
    }
}
