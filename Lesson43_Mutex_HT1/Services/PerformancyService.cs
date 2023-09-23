using Lesson43_Mutex_HT1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43_Mutex_HT1.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IUserService _userService;
        private Mutex _mutex = new(false, "MutexName");

        public PerformanceService(IUserService userService)
        {
            _userService = userService;
        }

        public Task<bool> ReportPerformanceAsync(Guid id)
        {
            return Task.Run(() =>
            {
                _mutex.WaitOne();
                var foundedUser = _userService.Get(id);

                if (foundedUser != null)
                {
                    var fullName = $"{foundedUser.FirstName}{foundedUser.LastName}.json";
                    File.WriteAllText(fullName, "All good ");
                    return true;
                }

                return false;
            });
        }
    }
}
