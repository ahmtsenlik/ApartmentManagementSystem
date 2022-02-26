using ApartmentManagement.Application.Contracts.Persistence.Repositories.Payments;
using ApartmentManagement.Application.Features.Commands.Payments;
using ApartmentManagement.MessageContracts;
using AutoMapper;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI
{
    public class CheckPaymentConsume : IConsumer<PaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CheckPaymentConsume(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PaymentResponse> context)
        {
         
            var record = _mapper.Map<PaymentRecordCommandRequest>(context.Message);
            await _mediator.Send(record);
        }
      

    }
}
