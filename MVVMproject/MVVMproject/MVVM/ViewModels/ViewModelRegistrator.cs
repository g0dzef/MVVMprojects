using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.MVVM.ViewModels
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection RegisterViewModel(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<ContactsViewModel>();

            return services;
        }
    }
}
