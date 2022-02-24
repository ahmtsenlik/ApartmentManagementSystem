using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Bills.AddBulk
{
    public class AddBulkBillCommandHandler : IRequestHandler<AddBulkBillCommandRequest, AddBulkBillCommandResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly AddBulkBillCommandValidator _validator;

        public AddBulkBillCommandHandler(IBillRepository billRepository, IApartmentRepository apartmentRepository, IMapper mapper, AddBulkBillCommandValidator validator)
        {
            _billRepository = billRepository;
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<AddBulkBillCommandResponse> Handle(AddBulkBillCommandRequest request, CancellationToken cancellationToken)
        {
            
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new AddBulkBillCommandResponse
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
            var billAmount = request.Amount / request.Apartments.Count;
            foreach (var ApartmentId in request.Apartments)
            {
                var apartment = await _apartmentRepository.GetByIdAsync(ApartmentId);
                if (apartment is null)
                    continue;
                var checkBill = await _billRepository.GetAsync(b => b.Type == request.Type && b.Month == request.Month && b.Year == request.Year && b.Apartment.Id == ApartmentId);
                if (checkBill.Count != 0)
                    continue;


                var bill = _mapper.Map<Bill>(request);
                bill.Amount = billAmount;
                bill.IsPaid = false;
                bill.Apartment = apartment;

                await _billRepository.AddAsync(bill);

            }
           
            return new AddBulkBillCommandResponse
            {
                IsSuccess = true,
                Message = "Bill added."
            };
        }
    }
}
