using BillingApi.Core.Services;
using BillingApi.Models;

namespace BillingApi.Service.Services.GatewayHandlers
{
    public class AmazonPaymentGatewayHandler : IPaymentGateway
    {
        public string GatewayName => "amazonpay";
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
