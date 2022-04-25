using BillingApi.Models;

namespace BillingApi.Core.Services
{
    public interface IBillingService: IEntityService<Order>
    {
        Receipt MapPayementGateway(Order order);
    }
}
