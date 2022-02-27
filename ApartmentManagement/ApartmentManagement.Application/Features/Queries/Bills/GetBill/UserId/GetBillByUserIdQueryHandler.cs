using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill.UserId
{
    public class GetBillByUserIdQueryHandler : IRequestHandler<GetBillByUserIdQueryRequest, IList<GetBillByUserIdQueryResponse>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetBillByUserIdQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        public async Task<IList<GetBillByUserIdQueryResponse>> Handle(GetBillByUserIdQueryRequest request, CancellationToken cancellationToken)
        {       
            var bills = await _billRepository.GetAsync(x => x.Apartment.User.Id == request.UserId,x=>x.Apartment);
            
            if (bills is null)
            {
                throw new NotFoundException(nameof(bills), request.UserId);
            }

            return _mapper.Map<IList<GetBillByUserIdQueryResponse>>(bills);
            
        }
    }
}
