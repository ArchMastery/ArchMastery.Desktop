using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using ArchMastery.Builder.Services;
using ArchMastery.Builder.ViewModels;

using static ArchMastery.Builder.ViewModels.MainViewModel;

namespace ArchMastery.Builder
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
