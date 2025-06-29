namespace ContosoPizza.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public bool? IsDelivered { get; set; } = false;
       public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}