using BillingApi.Models;

namespace BillingApi.Services
{
    public interface IValidator
    {
        bool IsValid(Order order);
    }
}
