using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ArchMastery.Builder.ViewModels;
using System.Diagnostics;
using ArchMastery.Builder.Services;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArchMastery.Builder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private MainViewModel _viewModel;

        public MainViewModel ViewModel {
            get => _viewModel;
            set
            {
                if (value is null || value.Equals(_viewModel)) return;

                _viewModel = value;
            }
        }

        public ProjectService ProjectService { get; }

        public MainPage()
        {
            ProjectService = App.Host.Services.GetService<ProjectService>();

            ProjectService.RequestExitApp += () =>
            {
                Process.GetCurrentProcess().CloseMainWindow();
            };

            ViewModel = App.Host.Services.GetRequiredService<MainViewModel>();
            this.InitializeComponent();
        }
    }
}
