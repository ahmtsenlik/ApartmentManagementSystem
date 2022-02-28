using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartmentByUserId
{
    public class GetApartmentByUserIdQueryHandler : IRequestHandler<GetApartmentByUserIdQueryRequest, GetApartmentByUserIdQueryResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentByUserIdQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<GetApartmentByUserIdQueryResponse> Handle(GetApartmentByUserIdQueryRequest request, CancellationToken cancellationToken)
        {

            var apartment = await _apartmentRepository.GetSingleAsync(x => x.UserId == request.UserId, x => x.User);
            if (apartment is null)
            {
                throw new NotFoundException(nameof(apartment), request.UserId);
            }

            return _mapper.Map<GetApartmentByUserIdQueryResponse>(apartment);
        }
    }
}
