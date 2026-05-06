using MAUI.Yandex.Ads.Sample.Models;

namespace MAUI.Yandex.Ads.Sample.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
