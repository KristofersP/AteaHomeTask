using BillingApi.Models;

namespace BillingApi.Services.Validators
{
    public class PaymentGatewayValidator : IValidator
    {
        public bool IsValid(Order order)
        {
            return !string.IsNullOrEmpty(order.PaymentGateway);
        }
    }
}
