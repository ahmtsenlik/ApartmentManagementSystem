
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Payments;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Payments.GetPayments
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQueryRequest, IList<GetPaymentsQueryResponse>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetPaymentsQueryResponse>> Handle(GetPaymentsQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.IsPaid != null)
            {
                var getList = await _paymentRepository.GetAsync(x => x.IsPaid == request.IsPaid);
                return _mapper.Map<IList<GetPaymentsQueryResponse>>(getList);
            
            }

            var getAllList = await _paymentRepository.GetAsync();
            return _mapper.Map<IList<GetPaymentsQueryResponse>>(getAllList);
           
            throw new System.NotImplementedException();

        }
    }
}
