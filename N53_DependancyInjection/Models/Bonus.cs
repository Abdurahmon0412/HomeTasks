namespace N53_DependancyInjection.Models;

public class Bonus :IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double BonusAmount { get; set; }
}
