﻿using ApartmentManagement.Application.Models;
using ApartmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Application.Features.Queries.Bills.GetUnPaidBills
{
    public class GetUnPaidBillsQueryResponse
    {
        public int Id { get; set; }
        public BillType Type { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsPaid { get; set; }
        public ApartmentBillModel Apartment { get; set; }
    }
}
