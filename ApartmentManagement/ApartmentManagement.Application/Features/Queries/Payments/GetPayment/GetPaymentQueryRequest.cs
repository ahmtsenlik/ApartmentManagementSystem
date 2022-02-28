using MediatR;


namespace ApartmentManagement.Application.Features.Queries.Payments.GetPayment
{
    public class GetPaymentQueryRequest:IRequest<GetPaymentQueryResponse>
    {
        public string Guid { get; set; }
    }
}
