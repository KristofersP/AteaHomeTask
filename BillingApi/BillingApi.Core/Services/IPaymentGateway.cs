using BillingApi.Models;

namespace BillingApi.Core.Services
{
    public interface IPaymentGateway
    {
        string GatewayName { get; }
        string GetGateway(Order order);
    }
}
