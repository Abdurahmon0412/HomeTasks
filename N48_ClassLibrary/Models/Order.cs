namespace N48_ClassLibrary.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid UserId { get; set; }
        public Order(double amount, Guid userId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            UserId = userId;
        }
    }
}
