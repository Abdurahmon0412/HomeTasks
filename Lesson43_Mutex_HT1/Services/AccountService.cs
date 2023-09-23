using Lesson43_Mutex_HT1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43_Mutex_HT1.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPerformanceService _performanceService;

        public AccountService(IEmployeeService employeeService, IPerformanceService performanceService)
        {
            _employeeService = employeeService;
            _performanceService = performanceService;
        }

        public Task CreateReportAsync(Guid id)
        {
            var result = _employeeService.CreatePerformanceRecordAsync(id)
            .ContinueWith(_ => _performanceService.ReportPerformanceAsync(id));

            return result;
        }
    }
}
