using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using PlantUml.Builder.Services;
using PlantUml.Builder.ViewModels;

using static PlantUml.Builder.ViewModels.MainViewModel;

namespace PlantUml.Builder
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
