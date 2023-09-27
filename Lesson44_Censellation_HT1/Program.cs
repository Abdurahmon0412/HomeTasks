using Lesson44_Censellation_HT1.Services;

Console.WriteLine("Hello, World!");
var cancellationTokenSourse = new CancellationTokenSource(5000);

try
{
    await Nimadir.Execute(cancellationTokenSourse.Token);

}
catch (Exception ex)
{
    Console.WriteLine("Exception bo'ldi: " + ex.Message);
}