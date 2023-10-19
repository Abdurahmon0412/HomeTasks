using FileStorogeN56.Extentions;
using FileStorogeN56.Models;
using FileStorogeN56.Services;

Console.WriteLine("Hello world!");

for(int i = 0; i < 10; i++)
{
    Console.WriteLine(Guid.NewGuid());
}

var user1 = new User(Guid.Parse("23cf5d0b-c78d-4c0c-a81e-6ac247c00348"), "Doniyorbek");

var user2 = new User(Guid.Parse("6ea044df-12bb-45f5-a74f-cb0981000298"), "Otebek");

var user3 = new User(Guid.Parse("cc1bce2b-0465-4afd-9176-bdb25ac0a462"), "Toshtemir");

var user4 = new User(Guid.Parse("15729c37-dbe0-4532-9398-a872f23a10c3"), "Toshtemir");

var user5 = new User(Guid.Parse("62960577-3639-44e8-a9d2-04ae3bb34175"), "Toshtemir");

var user6 = new User(Guid.Parse("120e424f-59a2-48f3-9b7f-c16e267fb7e1"), "Toshtemir");


user2.InitializeUserFolders();
user1.InitializeUserFolders();
user3.InitializeUserFolders();
user4.InitializeUserFolders();
user5.InitializeUserFolders();
user6.InitializeUserFolders();

var directoryService = new DirectoryService();
var fileService = new FileService();
var cleanerService = new CleanUpService(directoryService, fileService);


var invalidDocuments = await cleanerService.CleanUpAsync(user1);
invalidDocuments.ForEach(Console.WriteLine);