using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Payments;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Payments
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQueryRequest, GetPaymentQueryResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        public GetPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper, IBillRepository billRepository)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _billRepository = billRepository;
        }

        public async Task<GetPaymentQueryResponse> Handle(GetPaymentQueryRequest request, CancellationToken cancellationToken)
        {
     
            var payment = await _paymentRepository.GetSingleAsync(x => x.Guid == request.Guid);
            var result= _mapper.Map<GetPaymentQueryResponse>(payment);
            if (result.IsPaid)
            {
                var bill = await _billRepository.GetByIdAsync(payment.BillId);
                bill.IsPaid = true;
                bill.PaymentTime = DateTime.Now;
                await _billRepository.UpdateAsync(bill);
            }

            return result;
        }
    }
}
