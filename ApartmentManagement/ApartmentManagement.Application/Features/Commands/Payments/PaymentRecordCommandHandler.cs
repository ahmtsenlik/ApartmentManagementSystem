using ApartmentManagement.Application.Contracts.Persistence.Repositories.Payments;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Payments
{
    public class PaymentRecordCommandHandler : IRequestHandler<PaymentRecordCommandRequest>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentRecordCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PaymentRecordCommandRequest request, CancellationToken cancellationToken)
        {
            var pay = _mapper.Map<Payment>(request);
            pay.CreateDate = DateTime.Now;
            await _paymentRepository.AddAsync(pay);
            
            return Unit.Value;
        }
    }
}
