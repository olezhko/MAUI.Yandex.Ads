using CommunityToolkit.Mvvm.Input;
using MAUI.Yandex.Ads.Sample.Models;

namespace MAUI.Yandex.Ads.Sample.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}