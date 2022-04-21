using BillingApi.Models;

namespace BillingApi.Services.Valdiators
{
    public class PaymentGatewayValidator : IValidator
    {
        public bool IsValid(Order order)
        {
            return order.PaymentGateway != null;
        }
    }
}
