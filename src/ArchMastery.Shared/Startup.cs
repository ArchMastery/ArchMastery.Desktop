using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using ArchMastery.Services;
using ArchMastery.ViewModels;

using static ArchMastery.ViewModels.MainViewModel;

namespace ArchMastery
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProjectService>();
            services.AddSingleton<DialogService>();
            services.AddSingleton<MainViewModelCommands>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<ProjectViewModel>();
        }
    }
}
