

//// See https://aka.ms/new-console-template for more information
using N36_Task3.Models;
using N36_Task3.Services;

Console.WriteLine("Hello, World!");
//ExamScore modelidan foydalaning ( id, userId, score )
//-User modelidan foydalaning(id, firstname, lastname )
//-2 alasi uchun o'zining crud entity servisini yarating

//- ExamAnalytics servisidan foydalaning, bu service tepadagi 2 ala service uchun composition service bo'ladi
//////- unda GetScores methodi bo'lsin, bu method ( fullName, score ) tipidagi IEnumerable ma'lumot qaytarsin, 
///bunda har bitta user va uning examdagi balli qaytsin
///
var userCrudEntityService = new UserCrudEntityService();
var examScoreCrudEntityService = new ExamScoreCrudEntityService();

var user1Id = userCrudEntityService.AddUser(1, "eshmat", "Murodov");
var user2Id = userCrudEntityService.AddUser(2, "Gishmat", "Xoshimov");
var user3Id = userCrudEntityService.AddUser(3, "Abdullon", "Nodirov");

var score1 = new ExamScore(1,user1Id, 39);
var score2 = new ExamScore(2,user2Id, 40);
var score3 = new ExamScore(3,user3Id, 48);


examScoreCrudEntityService.AddExamscore(score1);
examScoreCrudEntityService.AddExamscore(score2);
examScoreCrudEntityService.AddExamscore(score3);


var examAnalytics = new ExamAnalyticsService(userCrudEntityService, examScoreCrudEntityService);
examAnalytics.GetScore().ToList().ForEach(result => 
Console.WriteLine($"{result.FullName} {result.Score}"));