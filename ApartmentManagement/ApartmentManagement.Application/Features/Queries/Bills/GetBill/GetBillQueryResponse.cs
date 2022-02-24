﻿using ApartmentManagement.Application.Models;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQueryResponse
    {
        public BillType Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsPaid { get; set; }
        public ApartmentBillModel Apartment { get; set; }

    }
}
