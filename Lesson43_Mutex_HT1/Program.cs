using Lesson43_Mutex_HT1.Models;
using Lesson43_Mutex_HT1.Services;

Console.WriteLine("Hello, World!");
var uzim = new User("Abdurahmon", "Sadriddin", true);

var userService = new UserService();
userService.Create(uzim);
var employeeService = new EmployeeService(userService);
var performanceService = new PerformanceService(userService);
var accountService = new AccountService(employeeService, performanceService);

await accountService.CreateReportAsync(uzim.Id);