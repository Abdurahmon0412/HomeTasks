namespace Lesson38_Bogus.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} {Email} {Department}";
        }
    }
}
