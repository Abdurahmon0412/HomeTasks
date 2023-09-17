namespace Lesson38_Bogus.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return $"{OrderNumber} {CustomerName} {OrderDate}";
        }
    }
}
