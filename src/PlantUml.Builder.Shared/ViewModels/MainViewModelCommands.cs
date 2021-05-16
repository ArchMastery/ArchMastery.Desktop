using Microsoft.Toolkit.Mvvm.Input;

using PlantUml.Builder.Services;

#nullable enable

namespace PlantUml.Builder.ViewModels
{
    public class MainViewModelCommands
    {
        public MainViewModelCommands(ProjectService projectService)
        {
            ProjectService = projectService;
            NewProject = new(ProjectService.ExecuteNewProject);
            OpenProject = new(ProjectService.ExecuteOpenProject);
            SaveProject = new(ProjectService.ExecuteSaveProject);
            AddAssembly = new(ProjectService.ExecuteAddAssembly);
            Exit = new(ProjectService.ExecuteExit);
        }
        public RelayCommand<MainViewModel> NewProject { get; }
        public RelayCommand<MainViewModel> OpenProject { get; }
        public RelayCommand<ProjectViewModel> SaveProject { get; }
        public RelayCommand<ProjectViewModel> AddAssembly { get; }
        public RelayCommand<ProjectViewModel> Exit { get; }
        public ProjectService ProjectService { get; }
    }
}