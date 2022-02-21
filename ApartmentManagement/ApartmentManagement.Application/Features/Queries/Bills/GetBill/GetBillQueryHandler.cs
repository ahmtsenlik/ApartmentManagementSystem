using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQueryHandler : IRequestHandler<GetBillQueryRequest, GetBillQueryResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetBillQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        public async Task<GetBillQueryResponse> Handle(GetBillQueryRequest request, CancellationToken cancellationToken)
        {
          
            var bill = await _billRepository.GetSingleAsync(x => x.Apartment.User.Id == request.UserId,x=>x.Apartment);
            if (bill is null)
            {
                throw new NotFoundException(nameof(bill), request.UserId);
            }

            return _mapper.Map<GetBillQueryResponse>(bill);
            
        }
    }
}
