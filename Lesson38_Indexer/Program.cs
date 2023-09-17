using Lesson38_Indexer;

var userContainer = new UserContainer();

//var user1 = new User("Ali", "Zairov", "emilAddress@gmail.com");
//var user2 = new User("Azizbek", "Abdurahmonov", "nimadir@gmail.com");
//var user3 = new User("Ilhom", "Karimjonov", "salom@gmail.com");

var user1Id = userContainer.AddUser("Ali", "Zairov", "emilAddress@gmail.com");
var user2Id = userContainer.AddUser("Azizbek", "Abdurahmonov", "nimadir@gmail.com");
var user3Id = userContainer.AddUser("Ilhom", "Karimjonov", "salom@gmail.com");


Console.WriteLine(userContainer[user1Id]);
Console.WriteLine(userContainer["h"]);
Console.WriteLine(userContainer[2]);

