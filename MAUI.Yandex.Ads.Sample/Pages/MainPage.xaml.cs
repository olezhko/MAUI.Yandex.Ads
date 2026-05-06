using MAUI.Yandex.Ads.Sample.Models;
using MAUI.Yandex.Ads.Sample.PageModels;

namespace MAUI.Yandex.Ads.Sample.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}