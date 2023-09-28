namespace Lesson45HT1_LinqQuerySyntax.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public double Count { get; set; }
        public OrderProduct(Guid productId , Guid orderId,double count)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            OrderId = orderId;
            Count = count;
        }
    }
}
