using Bogus;
using Lesson38_Bogus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson38_Bogus.Interfaces
{
    public interface IFakeDataGenerator
    {
        List<Employee> FakerEmployeeGenerate(int count = 1);
        List<Order> FakerOrderGenerate(int count = 1);
        List<UserAddress> FakerUserAddressGenerate(int count = 1);
        List<BlogPost> FakerBlogPostGenerate(int count = 1);
        List<WeatherReport> FakerWeatherReportGenerate(int count = 1);

    }
}
