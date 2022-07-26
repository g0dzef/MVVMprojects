using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Services.Interfaces
{
    public interface IAsyncDataService
    {
        string GetResult(DateTime value);
    }
}
