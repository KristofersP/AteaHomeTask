using BillingApi.Core.Services;
using BillingApi.Database;
using BillingApi.Models;
using BillingApi.Service.Services;
using System;

namespace BillingApi.Services
{
    public class BillingService: EntityService<Order>,IBillingService
    {
        protected readonly IBillingApiDbContext _context;
        public BillingService(IBillingApiDbContext context) : base(context)
        {
            _context = context;
        }

        public Receipt MapPayementGateway(Order order)
        {
            var receipt = new Receipt();
            receipt.OrderNumber = order.OrderNumber;
            receipt.PaidAmount = order.PayableAmount;
            receipt.Description = order.Description;
            receipt.Date = DateTime.Now.ToString();

            if (order.PaymentGateway.ToLower() == "paypal")
            {
                receipt.PaymentGateway = "PayPal";
                _context.Receipts.Add(receipt);
                _context.SaveChanges();
                return receipt;
            }
            else if (order.PaymentGateway.ToLower() == "stripe")
            {
                receipt.PaymentGateway = "Stripe";
                _context.Receipts.Add(receipt);
                _context.SaveChanges();
                return receipt;
            }
            else
            {
                receipt.PaymentGateway = "AmazonPay";
                _context.Receipts.Add(receipt);
                _context.SaveChanges();
                return receipt;
            }
        }
        
    }
}
