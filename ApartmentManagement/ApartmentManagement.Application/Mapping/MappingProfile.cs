using ApartmentManagement.Application.Features.Commands.Apartments.AddUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Create;
using ApartmentManagement.Application.Features.Commands.Apartments.Update;
using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Commands.Bills.AddBulk;
using ApartmentManagement.Application.Features.Commands.Messages.SendMessage;
using ApartmentManagement.Application.Features.Commands.Payments;
using ApartmentManagement.Application.Features.Commands.Users.Signup;
using ApartmentManagement.Application.Features.Commands.Users.Update;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartment;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartments;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.UserId;
using ApartmentManagement.Application.Features.Queries.Bills.GetBills;
using ApartmentManagement.Application.Features.Queries.Messages.GetMessages;
using ApartmentManagement.Application.Features.Queries.Payments;
using ApartmentManagement.Application.Features.Queries.Users.GetUser;
using ApartmentManagement.Application.Features.Queries.Users.GetUsers;
using ApartmentManagement.Application.Models;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.MessageContracts;
using AutoMapper;
using static ApartmentManagement.Domain.Enum.BaseEnum;

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
            CreateMap<Bill, GetBillByUserIdQueryResponse>().ReverseMap();
            CreateMap<Bill, GetBillByIdQueryResponse>().ReverseMap();
            CreateMap<Bill, AddBulkBillCommandRequest>().ReverseMap();

            CreateMap<PaymentResponse, PaymentRecordCommandRequest>().ReverseMap();
            CreateMap<Payment, PaymentRecordCommandRequest>().ReverseMap();
            CreateMap<Payment, GetPaymentQueryResponse>().ReverseMap();
            
        }
    }
}
