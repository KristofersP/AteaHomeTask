﻿using BillingApi.Models;

namespace BillingApi.Services
{
    public class OrderValidator : IValidator
    {
        public bool IsValid(Order order)
        {
            return order != null;
        }
    }
}
