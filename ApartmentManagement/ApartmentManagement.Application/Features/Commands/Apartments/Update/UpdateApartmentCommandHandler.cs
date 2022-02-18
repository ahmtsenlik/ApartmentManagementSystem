﻿using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Exceptions;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Update

{
    public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommandRequest, UpdateApartmentCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly UpdateApartmentCommandValidator _validator;

        public UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, UpdateApartmentCommandValidator validator)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateApartmentCommandResponse> Handle(UpdateApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
           
            var updateApartment = await _apartmentRepository.GetByIdAsync(request.Id);
            if (updateApartment is null)
            {
                throw new NotFoundException(nameof(Apartment), request.Id);
            }

            _mapper.Map(request, updateApartment, typeof(UpdateApartmentCommandRequest), typeof(Apartment));
            updateApartment.IsActive = true;
            updateApartment.IsEmpty = true;
            await _apartmentRepository.UpdateAsync(updateApartment);

            return new UpdateApartmentCommandResponse
            {
                IsSuccess = true
            };

        }
    }
}