using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly RemoveUserCommandValidator _validator;

        public RemoveUserCommandHandler(IApartmentRepository apartmentRepository, RemoveUserCommandValidator validator, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _validator = validator;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new RemoveUserCommandResponse
                {
                    Message = validationResult.ToString(),
                    IsSuccess = false
                };
            }

            var updateApartment = await _apartmentRepository.GetSingleAsync(x=>x.Id==request.ApartmentId,x=>x.User);

            if (updateApartment is null)
            {
                return new RemoveUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment was not found."
                };
            }
           
            if (updateApartment.IsEmpty)
            {
                return new RemoveUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "This apartment is already empty"
                };
            }
  
            updateApartment.User = null;
            updateApartment.UserId = null;
            updateApartment.IsEmpty = true;
            await _apartmentRepository.UpdateAsync(updateApartment);
            return new RemoveUserCommandResponse
            {
                IsSuccess = true
            };

        }
    }
}
