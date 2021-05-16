using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using Newtonsoft.Json;

using PlantUml.Builder.ViewModels;

using Uno.Disposables;
using Uno.Extensions;

using Windows.Storage;
using Windows.Storage.Streams;

using Buffer = System.Buffer;
#nullable enable
namespace PlantUml.Builder.Services
{
    public class ProjectService
    {
        public DialogService DialogService { get; }
        public event Action? RequestExitApp;

        public ProjectService(DialogService dialogService)
        {
            DialogService = dialogService;
        }

        public void ExecuteExit(ProjectViewModel? project)
        {
            if (project is not null)
            {
                ExecuteCloseProject(project);
            }

            RequestExitApp?.Invoke();
        }

        public void ExecuteSaveProject(ProjectViewModel? project)
        { }

        public void ExecuteAddAssembly(ProjectViewModel? project)
        { }

        public void ExecuteCloseProject(ProjectViewModel? project)
        {
            if (project is null) return;

            Task.Run(async () =>
            {
                if (project.IsDirty)
                {
                    await project.SaveAsync();
                }

                project.TryDispose();
            }).ConfigureAwait(true)
                .GetAwaiter()
                .GetResult();
        }

        public void ExecuteNewProject(MainViewModel? viewModel)
        {
            if (viewModel?.Project is not null && viewModel.Project.IsDirty)
            {
                ExecuteCloseProject(viewModel.Project);
            }

            viewModel.Project = App.Host.Services.GetRequiredService<ProjectViewModel>();
        }

        public void ExecuteOpenProject(MainViewModel? viewModel)
        {
            if (viewModel?.Project is not null && viewModel.Project.IsDirty)
            {
                ExecuteCloseProject(viewModel.Project);
            }

            Task.Run(async () =>
            {
                var result = await OpenAsync();

                viewModel.Project = result.project;
            }).ConfigureAwait(true)
                .GetAwaiter()
                .GetResult();
        }


        public async Task<(bool yes, ProjectViewModel project)> OpenAsync()
        {
            var result = await DialogService.OpenProjectAsync();

            if (result.yes)
            {
                using var readStream = await result.file.OpenReadAsync();
                var buffer = new Windows.Storage.Streams.Buffer((uint)readStream.Size);
                var bytes = await readStream.ReadAsync(buffer, (uint)readStream.Size, InputStreamOptions.None);
                var json = Encoding.UTF8.GetString(buffer.ToArray());

                var project = JsonConvert.DeserializeObject<ProjectViewModel>(json);

                return (true, project);
            }

            return (false, null);
        }
    }
}