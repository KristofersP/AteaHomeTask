using BillingApi.Core.Services;
using BillingApi.Database;
using BillingApi.Models;
using BillingApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingApi.Services
{
    public class BillingService: EntityService<Order>,IBillingService
    {
        private readonly IEnumerable<IPaymentGateway> _gatewayHandlers;
        public BillingService(IBillingApiDbContext context,IEnumerable<IPaymentGateway> gatewayHandlers) : base(context)
        {
            _gatewayHandlers = gatewayHandlers;
        }

        public Receipt MapPayementGateway(Order order)
        {
            var receipt = new Receipt();
            receipt.OrderNumber = order.OrderNumber;
            receipt.PaidAmount = order.PayableAmount;
            receipt.Description = order.Description;
            receipt.Date = DateTime.Now.ToString();

            var handler = _gatewayHandlers.SingleOrDefault(h => h.GatewayName.ToLower() == order.PaymentGateway);
            receipt.PaymentGateway = handler.GetGateway(order);
            _context.Receipts.Add(receipt);
            _context.SaveChanges();

            return receipt;
        }
        
    }
}
