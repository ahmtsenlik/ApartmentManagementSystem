using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartments
{
    public class GetApartmentsQueryHandler : IRequestHandler<GetApartmentsQueryRequest, IList<GetApartmentsQueryResponse>>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public GetApartmentsQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper, ICacheService cacheService)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IList<GetApartmentsQueryResponse>> Handle(GetApartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "ApartmentList";
            
            if (_cacheService.TryGet(cacheKey, out List<GetApartmentsQueryResponse> cacheList))
            {
                return cacheList;
            }
            var getList = await _apartmentRepository.GetAsync(null, x => x.User);
            var apartmentList=_mapper.Map<IList<GetApartmentsQueryResponse>>(getList);
            _cacheService.Set(cacheKey, apartmentList);
            return apartmentList;
            
        
        }
    }
}
