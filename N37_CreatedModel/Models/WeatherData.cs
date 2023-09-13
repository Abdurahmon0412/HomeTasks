using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //WeatherData: A tuple with elements for the temperature, humidity, and wind speed of a weather reading.
    public class WeatherData
    {
        public static (double temperature, double humdity, double WindSpeed)
            WeatherReading = (25, 12.55, 175.45);
    }
}
