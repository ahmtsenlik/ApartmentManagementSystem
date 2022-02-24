using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Services;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBills
{
    public class GetBillsQueryHandler : IRequestHandler<GetBillsQueryRequest, IList<GetBillsQueryResponse>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetBillsQueryHandler(IBillRepository billRepository, IMapper mapper, ICacheService cacheService)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IList<GetBillsQueryResponse>> Handle(GetBillsQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.IsPaid!=null)
            {
                var getList = await _billRepository.GetAsync(x => x.IsPaid == request.IsPaid, x => x.Apartment);
                return _mapper.Map<IList<GetBillsQueryResponse>>(getList);
            }

            var getAllList = await _billRepository.GetAsync(null, x => x.Apartment);
            return _mapper.Map<IList<GetBillsQueryResponse>>(getAllList);
            

        }
    }
}
