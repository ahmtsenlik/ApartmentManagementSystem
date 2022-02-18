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
    public class RemoveApartmentCommandHandler : IRequestHandler<RemoveApartmentCommandRequest>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly RemoveApartmentCommandValidator _validator;
        public RemoveApartmentCommandHandler(IApartmentRepository apartmentRepository, RemoveApartmentCommandValidator validator)
        {
            _apartmentRepository = apartmentRepository;
            _validator=validator;
        }

        public async Task<Unit> Handle(RemoveApartmentCommandRequest request, CancellationToken cancellationToken)
        {
             _validator.ValidateAndThrow(request);
            
            var removeApartment = await _apartmentRepository.GetByIdAsync(request.Id);
            if (removeApartment is null)
            {
                throw new NotFoundException(nameof(Apartment), request.Id);
            }
            if (removeApartment is not null && removeApartment.IsEmpty)
            {
                await _apartmentRepository.RemoveAsync(removeApartment);
                
            }
            return Unit.Value;
            
        }
    }
}
