using MVVMproject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVMproject.Services
{
    public class AsyncDataService : IAsyncDataService
    {
        private const int _sleepTime = 7000;

        public string GetResult(DateTime value)
        {
            Thread.Sleep(_sleepTime);

            return $"Return value {value}";
        }
    }
}
