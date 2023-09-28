namespace Lesson45HT1_LinqQuerySyntax.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }  
        public Guid UserId { get; set; }
        public Order(double  amount, Guid userId)
        {
            Amount = amount;
            UserId = userId;
            Id = Guid.NewGuid();
        }
    }
}
