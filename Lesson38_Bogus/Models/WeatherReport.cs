namespace Lesson38_Bogus.Models
{
    public class WeatherReport
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public float Temperature { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{Location} {Temperature} {Description} {Timestamp}";
        }
    }
}
