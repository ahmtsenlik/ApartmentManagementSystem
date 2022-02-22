using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetUnPaidBills
{
    public class GetUnPaidBillsQueryHandler : IRequestHandler<GetUnPaidBillsQueryRequest, IList<GetUnPaidBillsQueryResponse>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetUnPaidBillsQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetUnPaidBillsQueryResponse>> Handle(GetUnPaidBillsQueryRequest request, CancellationToken cancellationToken)
        {
            var unPaidBillList = await _billRepository.GetAsync(x=>x.IsPaid==false, x => x.Apartment);
            return _mapper.Map<IList<GetUnPaidBillsQueryResponse>>(unPaidBillList);
        }
    }
}
