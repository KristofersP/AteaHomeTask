using BillingApi.Core.Services;
using BillingApi.Models;

namespace BillingApi.Service.Services.GatewayHandlers
{
    public class StripeGatewayHandler : IPaymentGateway
    {
        public string GatewayName => "stripe";
        public string GetGateway(Order order)
        {
            if (order.PaymentGateway.ToLower() == GatewayName.ToLower())
            {
                return GatewayName;
            }

            return "";
        }
    }
}
