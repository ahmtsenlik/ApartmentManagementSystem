using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
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

namespace ApartmentManagement.Application.Features.Commands.Bills.Add
{
    public class AddBillCommandHandler : IRequestHandler<AddBillCommandRequest, AddBillCommandResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly AddBillCommandValidator _validator;

        public AddBillCommandHandler(IBillRepository billRepository, IMapper mapper, AddBillCommandValidator validator, IApartmentRepository apartmentRepository)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _validator = validator;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<AddBillCommandResponse> Handle(AddBillCommandRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);
            if (apartment is null)
            {
                return new AddBillCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment was not found."
                };
            }
            var checkBill =await _billRepository.GetAsync(b => b.Type == request.Type && b.Month == request.Month && b.Year == request.Year && b.Apartment.Id == request.ApartmentId);
            if (checkBill.Count!=0)
            {
                return new AddBillCommandResponse
                {
                    IsSuccess = false,
                    Message = "This bill has already been added."
                };
            }

            var bill = _mapper.Map<Bill>(request);
            bill.IsActive = true;
            bill.IsPaid = false;
            bill.Apartment = apartment;

            await _billRepository.AddAsync(bill);
            return new AddBillCommandResponse
            {
                IsSuccess = true,
                Message = "Bill added."
            };

        }
    }
}
