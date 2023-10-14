
namespace N53_DependancyInjection.Models;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public Guid UserId { get; set; }

    public Order(Guid id, Guid userId, double amount)
    {
        Id = id;
        UserId = userId;
        Amount = amount;
    }
}