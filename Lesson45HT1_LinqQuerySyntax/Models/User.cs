namespace Lesson45HT1_LinqQuerySyntax.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
