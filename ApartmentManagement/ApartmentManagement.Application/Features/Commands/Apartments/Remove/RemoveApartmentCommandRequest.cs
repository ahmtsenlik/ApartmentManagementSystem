using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Remove
{
    public class RemoveApartmentCommandRequest:IRequest<RemoveApartmentCommandResponse>
    {
        public int ApartmentId { get; set; }
    }
}

