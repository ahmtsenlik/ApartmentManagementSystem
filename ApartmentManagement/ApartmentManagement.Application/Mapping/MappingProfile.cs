using ApartmentManagement.Application.Features.Commands.Apartments.AddUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Create;
using ApartmentManagement.Application.Features.Commands.Apartments.Update;
using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Commands.Bills.AddBulk;
using ApartmentManagement.Application.Features.Commands.Messages.SendMessage;
using ApartmentManagement.Application.Features.Commands.Users.Signup;
using ApartmentManagement.Application.Features.Commands.Users.Update;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartment;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartments;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill;
using ApartmentManagement.Application.Features.Queries.Bills.GetBills;
using ApartmentManagement.Application.Features.Queries.Messages.GetMessages;
using ApartmentManagement.Application.Features.Queries.Users.GetUser;
using ApartmentManagement.Application.Features.Queries.Users.GetUsers;
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
            CreateMap<User, LoginUserModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, MessageUserModel>().ReverseMap();
            CreateMap<User, GetUsersQueryResponse>().ReverseMap();
            CreateMap<User, GetUserQueryResponse>().ReverseMap();
            CreateMap<User, UpdateUserCommandRequest>().ReverseMap();
            
            
            CreateMap<Apartment, CreateApartmentCommandRequest>().ReverseMap();
            CreateMap<Apartment, UpdateApartmentCommandRequest>().ReverseMap();
            CreateMap<Apartment, AddUserCommandRequest>().ReverseMap();
            CreateMap<Apartment, GetApartmentQueryResponse>().ReverseMap();
            CreateMap<Apartment, GetApartmentsQueryResponse>().ReverseMap();
            CreateMap<Apartment, ApartmentBillModel>().ReverseMap();

            CreateMap<Message, SendMessageCommandRequest>().ReverseMap(); 
            CreateMap<Message, GetMessagesResponse>().ReverseMap();
            CreateMap<Bill, AddBillCommandRequest>().ReverseMap();
            CreateMap<Bill, GetBillsQueryResponse>().ReverseMap();
            CreateMap<Bill, GetBillQueryResponse>().ReverseMap();
            CreateMap<Bill, AddBulkBillCommandRequest>().ReverseMap();
            

        }
    }
}
