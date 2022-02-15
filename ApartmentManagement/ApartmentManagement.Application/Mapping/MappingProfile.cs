using ApartmentManagement.Application.Features.Commands.Users.Signup;
using ApartmentManagement.Application.Models;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, SignupUserCommandRequest>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<User, SignupUserCommandRequest>().ReverseMap();
        }
    }
}
