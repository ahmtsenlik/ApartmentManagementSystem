using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryRequest:IRequest<GetApartmentQueryResponse>
    {
        public int Id { get; set; }
    }
}
