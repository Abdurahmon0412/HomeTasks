using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43_Mutex_HT1.Interfaces
{
    public interface IPerformanceService
    {
        Task<bool> ReportPerformanceAsync(Guid id);
    }
}
