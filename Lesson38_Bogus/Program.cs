// See https://aka.ms/new-console-template for more information
using Lesson38_Bogus.Services;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

var fakeDataGenerator = new FakeDataGenerator();

var weathers = fakeDataGenerator.FakerWeatherReportGenerate();
weathers.ForEach(weather => Console.WriteLine(weather));

Console.WriteLine("Hello, World!");

var orders = fakeDataGenerator.FakerOrderGenerate();
orders.ForEach(order => Console.WriteLine(order));

Console.WriteLine("Hello, World!");

var blogPosts = fakeDataGenerator.FakerBlogPostGenerate();
blogPosts.ForEach(blogPost => Console.WriteLine(blogPost));

Console.WriteLine("Hello, World!");

var userAddresses = fakeDataGenerator.FakerUserAddressGenerate();
userAddresses.ForEach(userAddress => Console.WriteLine(userAddress));

Console.WriteLine("Hello, World!");

var employees = fakeDataGenerator.FakerEmployeeGenerate();
employees.ForEach(employee => Console.WriteLine(employee));
