using Lesson43_Mutex_HT1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43_Mutex_HT1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserService _userService;
        private Mutex _mutex = new(false, "MutexName");

        public EmployeeService(IUserService userService)
        {
            _userService = userService;
        }

        public Task CreatePerformanceRecordAsync(Guid id)
        {
            return Task.Run(() =>
            {
                _mutex.WaitOne();
                var foundedUser = _userService.Get(id);
                if (foundedUser != null)
                {
                    var fullName = $"{foundedUser.FirstName}{foundedUser.LastName}.json";
                    File.Create(fullName).Close();
                }
                _mutex.ReleaseMutex();

            });
        }
    }
}
