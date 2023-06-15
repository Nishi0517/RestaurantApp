namespace RestaurantAPI.Models
{
    public class OrderWithCustomer
    {
        public long OrderMasterId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string pMethod { get; set; }
        public decimal gTotal { get; set; }
        public Customers Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
