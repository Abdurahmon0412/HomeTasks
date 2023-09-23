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