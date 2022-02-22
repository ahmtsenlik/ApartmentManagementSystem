using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Exceptions;
using ApartmentManagement.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Remove
{
    public class RemoveApartmentCommandHandler : IRequestHandler<RemoveApartmentCommandRequest,RemoveApartmentCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly RemoveApartmentCommandValidator _validator;
        public RemoveApartmentCommandHandler(IApartmentRepository apartmentRepository, RemoveApartmentCommandValidator validator)
        {
            _apartmentRepository = apartmentRepository;
            _validator=validator;
        }

        public async Task<RemoveApartmentCommandResponse> Handle(RemoveApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "This apartment has already been registered"
                };
            }

            var removeApartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);

            if (removeApartment is null)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment with this id could not be found."       
                };
            }

            if (removeApartment is not null && !removeApartment.IsEmpty)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "Apartment is full, remove user first."
                };
            }

            await _apartmentRepository.RemoveAsync(removeApartment);

            return new RemoveApartmentCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
