namespace BillingApi.Models
{
    public class Order : Entity
    {
        public int OrderNumber { get; set; }
        public int UserId { get; set; }
        public float PayableAmount { get; set; }
        public string PaymentGateway { get; set; }
        public string Description { get; set; }
    }
}
