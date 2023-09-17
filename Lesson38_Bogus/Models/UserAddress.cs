namespace Lesson38_Bogus.Models
{
    public class UserAddress
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street} {City} {ZipCode}";
        }
    }

}
