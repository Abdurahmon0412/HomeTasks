namespace Lesson45HT1_LinqQuerySyntax.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name,decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}
