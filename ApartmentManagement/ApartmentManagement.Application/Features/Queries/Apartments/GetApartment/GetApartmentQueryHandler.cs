using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
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

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryHandler : IRequestHandler<GetApartmentQueryRequest, GetApartmentQueryResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly GetApartmentQueryValidator _validator;

        public GetApartmentQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper, GetApartmentQueryValidator validator)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetApartmentQueryResponse> Handle(GetApartmentQueryRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var apartment = await _apartmentRepository.GetSingleAsync(x => x.Id == request.ApartmentId, x=>x.User,x=>x.Bills);
            if (apartment is null)
            {
                throw new NotFoundException(nameof(apartment), request.ApartmentId);
            }
 
            return _mapper.Map<GetApartmentQueryResponse>(apartment);
        }


    }
}
