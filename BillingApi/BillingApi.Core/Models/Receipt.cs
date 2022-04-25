namespace BillingApi.Models
{
    public class Receipt : Entity
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public float PaidAmount { get; set; }
        public string PaymentGateway { get; set; }
    }
}
