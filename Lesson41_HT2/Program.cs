// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Thread Safe EmailSenderService yarating
//- bunda bitta email ketib bo'lmagunicha boshqa thread SendEmailAsync methodiga kira olmasin
//- SMTP instance ni esa constructor ichida yarating

using Lesson41_HT2.Services;

for (var index = 0; index < 100; index++)
{
    var emailSenderService = new EmailSenderService();
    var tasks = new List<Task>()
     {
         new(() => emailSenderService.SendEmailAsync("abdurahmonsadriddinov0412@gmail.com","fullname")
         .AsTask().Wait()),
         new(() => emailSenderService.SendEmailAsync("toshmurodovj13@gmail.com","Firdavs").AsTask().Wait())
     };

    Parallel.ForEach(tasks, task => task.Start());
}