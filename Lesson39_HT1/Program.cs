using Lesson39_HT1.Models;

var usersAndWeathersList = new List<object>
{
    new User(firstName: "Sardor", lastName: "Tuxtaniyozov"),
    new WeatherReport("Toshkent" , 28.8),
    new User("Nodir" , "Xoliqulov"),
    new WeatherReport("Samarqand" , 30.9),
    new User("Azizbek", "Abdurahmonov"),
    new WeatherReport("USA", 45),
    new User("John", "Doniyorov")
};
foreach(var obj in usersAndWeathersList)
{
    if(obj is User user && user is { FirstName : "John"})
        Console.WriteLine(user);

    if(obj is WeatherReport weatherReport && weatherReport is { Degree: > 30 })
        Console.WriteLine(obj);
}