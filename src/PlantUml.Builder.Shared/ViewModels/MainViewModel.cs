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
        private string _name = string.Empty;

        public MainViewModel(MainViewModelCommands commands)
        {
            Commands = commands;
        }

        public MainViewModelCommands Commands { get; }

        public ProjectViewModel? Project
        {
            get => _project;
            set
            {
                if(SetProperty(ref _project, value))
                {
                    Name = value.Name;
                }
            }
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}