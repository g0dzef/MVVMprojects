using Microsoft.Extensions.DependencyInjection;
using MVVMproject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAsyncDataService, AsyncDataService>();

            services.AddSingleton<ContactsRepository>();

            return services;
        }
    }
}
