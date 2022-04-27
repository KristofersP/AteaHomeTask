using BillingApi.Core.Services;
using BillingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApi.Service.Services.GatewayHandlers
{
    public class PayPalGatewayHandler : IPaymentGateway
    {
        public string GatewayName => "paypal";
        public string GetGateway(Order order)
        {
            if(order.PaymentGateway.ToLower() == GatewayName.ToLower())
            {
                return GatewayName;
            }

            return "";
        }
    }
}
