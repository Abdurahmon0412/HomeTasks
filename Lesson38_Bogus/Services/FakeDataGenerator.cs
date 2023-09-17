using Bogus;
using Lesson38_Bogus.Interfaces;
using Lesson38_Bogus.Models;

namespace Lesson38_Bogus.Services
{
    public class FakeDataGenerator : IFakeDataGenerator
    {
        private Faker faker;
        public FakeDataGenerator()
        {
            faker = new Faker();
        }
        public List<BlogPost> FakerBlogPostGenerate(int count = 1)
        {
            var blogPostFaker = new Faker<BlogPost>()
                .RuleFor(post => post.Id, faker.Random.Guid)
                .RuleFor(post => post.Title, faker.Lorem.Sentence(5,1))
                .RuleFor(post => post.Content, faker.Lorem.Paragraph(3))
                .RuleFor(post => post.PublishDate, faker.Date.Recent());

            return blogPostFaker.Generate(count); 
        }

        public List<Employee> FakerEmployeeGenerate(int count = 1)
        {
            var employeeFaker = new Faker<Employee>()
                .RuleFor(employee => employee.Id, faker.Random.Guid())
                .RuleFor(employee => employee.Name, faker.Name.FullName())
                .RuleFor(employee => employee.Email, faker.Internet.Email())
                .RuleFor(employee => employee.Department, faker.Commerce.Department());
            
            return employeeFaker.Generate(count);
        }

        public List<Order> FakerOrderGenerate(int count = 1)
        {
            var orderFaker = new Faker<Order>()
                .RuleFor(order => order.Id, faker.Random.Guid())
                .RuleFor(order => order.OrderNumber, faker.Random.Int(1000, 9999))
                .RuleFor(order => order.OrderDate, faker.Date.Past())
                .RuleFor(order => order.CustomerName, faker.Name.FullName());
            return orderFaker.Generate(count);  
        }

        public List<UserAddress> FakerUserAddressGenerate(int count = 1)
        {
            var userAddressFaker = new Faker<UserAddress>()
                .RuleFor(adress => adress.Id, faker.Random.Guid())
                .RuleFor(adress => adress.Street, faker.Address.StreetAddress())
                .RuleFor(address => address.City, faker.Address.City())
                .RuleFor(address => address.ZipCode, faker.Address.ZipCode());
            return userAddressFaker.Generate(count);
        }

        public List<WeatherReport> FakerWeatherReportGenerate(int count = 1)
        {
             var weatherReportFaker = new Faker<WeatherReport>()
                 .RuleFor(wr => wr.Id, faker.Random.Guid())
                 .RuleFor(wr => wr.Location, faker.Address.City())
                 .RuleFor(wr => wr.Temperature, faker.Random.Float(-20, 40))
                 .RuleFor(wr => wr.Description, faker.Lorem.Word())
                 .RuleFor(wr => wr.Timestamp, faker.Date
                 .Between(DateTime.Now.AddMonths(-6), DateTime.Now));

            return weatherReportFaker.Generate(count);
        }
    }
}
