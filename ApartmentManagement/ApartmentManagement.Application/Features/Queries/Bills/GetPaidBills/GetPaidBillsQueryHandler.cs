using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetPaidBills
{
    public class GetPaidBillsQueryHandler : IRequestHandler<GetPaidBillsQueryRequest, IList<GetPaidBillsQueryResponse>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetPaidBillsQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetPaidBillsQueryResponse>> Handle(GetPaidBillsQueryRequest request, CancellationToken cancellationToken)
        {
            var unPaidBillList = await _billRepository.GetAsync(x=>x.IsPaid==true, x => x.Apartment);
            return _mapper.Map<IList<GetPaidBillsQueryResponse>>(unPaidBillList);
        }
    }
}
