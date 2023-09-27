using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson44_Censellation_HT1.Services
{
    public class Nimadir
    {
        public static async ValueTask Execute(CancellationToken cancellationToken)
        {
            for (var index = 0; index < 100; index++)
            {
                // I - usul
                // if (cancellationToken.IsCancellationRequested)
                //     throw new TimeoutException("Time out ");

                // II - usul
                // cancellationToken.ThrowIfCancellationRequested();

                await Task.Delay(200, cancellationToken); // III - usul (async methodlarning ko'pchiligi token qabul qiladi)
            }
        }
    }
}
