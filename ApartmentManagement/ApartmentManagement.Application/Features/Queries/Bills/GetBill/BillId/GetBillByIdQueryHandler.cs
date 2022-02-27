using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId
{
    public class GetBillByIdQueryHandler : IRequestHandler<GetBillByIdQueryRequest, GetBillByIdQueryResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetBillByIdQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<GetBillByIdQueryResponse> Handle(GetBillByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var bills = await _billRepository.GetSingleAsync(x => x.Id == request.Id,x=>x.Apartment,x=>x.Apartment.User);

            if (bills is null)
            {
                throw new NotFoundException(nameof(bills), request.Id);
            }

            return _mapper.Map<GetBillByIdQueryResponse>(bills);
        }
    }
}