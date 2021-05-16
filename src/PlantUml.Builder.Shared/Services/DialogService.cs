using System;
using System.Threading.Tasks;
using Windows.Storage;
using PlantUml.Builder.ViewModels;

using Windows.Storage.Pickers;

#nullable enable

namespace PlantUml.Builder.Services
{
    public class DialogService
    {
        public async Task<(bool yes, StorageFile? target)> SaveProjectAsync(ProjectViewModel projectViewModel)
        {
            var picker = new FileSavePicker
            {
                SuggestedFileName = projectViewModel.Name + ".pumlproj"
            };

            picker.FileTypeChoices.Add("PlantUML Project", new[] { ".pumlproj" });

            var target = await picker.PickSaveFileAsync();

            return (target?.Path != null, target);
        }

        public async Task<(bool yes, StorageFile? file)> OpenProjectAsync()
        {
            var picker = new FileOpenPicker();

            picker.FileTypeFilter.Add(".pumlproj");

            var target = await picker.PickSingleFileAsync();

            return (target?.Path != null, target);
        }
    }
}