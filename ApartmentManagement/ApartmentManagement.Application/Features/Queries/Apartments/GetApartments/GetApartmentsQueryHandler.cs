using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartments
{
    public class GetApartmentsQueryHandler : IRequestHandler<GetApartmentsQueryRequest, IList<GetApartmentsQueryResponse>>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentsQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetApartmentsQueryResponse>> Handle(GetApartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var apartmentList = await _apartmentRepository.GetAsync(null,x=>x.User);
            return _mapper.Map<IList<GetApartmentsQueryResponse>>(apartmentList);
        }
    }
}
