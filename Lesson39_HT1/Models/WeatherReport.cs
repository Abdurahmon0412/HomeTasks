namespace Lesson39_HT1.Models
{
    public class WeatherReport
    {
        public string State { get; set; }
        public double Degree { get; set; }

        public WeatherReport(string state, double degree)
        {
            State = state;
            Degree = degree;
        }

        public override string ToString()
        {
            return $"State: {State}\tDegree: {Degree}";
        }
    }
}
