using Lesson39_HT2.Services.Services;

var validation = new ValidationService();
var sendEmailService = new SendEmailService();

var accountService = new AccountService(validation, sendEmailService);

try
{
    var result =  accountService.Registr("Firdavs", "Asadov", "toshmurodovj13@gmail.com", "dfasdf342");
    if (result)
        Console.WriteLine("Success");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}