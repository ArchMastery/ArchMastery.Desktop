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
            SaveProject = new(ProjectService.ExecuteSaveProject, ProjectService.HasProject);
            CloseProject = new(ProjectService.ExecuteCloseProject, ProjectService.HasProject);
            AddAssembly = new(ProjectService.ExecuteAddAssembly, ProjectService.HasProject);
            Exit = new(ProjectService.ExecuteExit);
        }
        public AsyncRelayCommand<MainViewModel> NewProject { get; }
        public AsyncRelayCommand<MainViewModel> OpenProject { get; }
        public AsyncRelayCommand<ProjectViewModel> SaveProject { get; }
        public AsyncRelayCommand<ProjectViewModel> CloseProject { get; }
        public AsyncRelayCommand<ProjectViewModel> AddAssembly { get; }
        public AsyncRelayCommand<ProjectViewModel> Exit { get; }
        public ProjectService ProjectService { get; }
    }
}