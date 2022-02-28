﻿
namespace ApartmentManagement.Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string TCIdentityNumber { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LicensePlate { get; set; }
        public bool IsOwner { get; set; }

    }
}
