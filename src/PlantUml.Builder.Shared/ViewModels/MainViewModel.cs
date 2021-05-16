using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PlantUml.Builder.Services;

using Windows.Storage.Pickers;
using Windows.System;
using Newtonsoft.Json;
using Microsoft.UI.Xaml;

#nullable enable

namespace PlantUml.Builder.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ProjectViewModel? _project;

        public MainViewModel(MainViewModelCommands commands)
        {
            Commands = commands;
        }

        public MainViewModelCommands Commands { get; }

        public ProjectViewModel? Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }
    }
}