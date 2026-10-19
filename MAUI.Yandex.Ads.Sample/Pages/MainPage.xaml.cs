using System.Diagnostics;
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

        private void OnAdLoaded(object? sender, EventArgs e)
        {
            Debug.WriteLine($"Yandex banner ad loaded successfully ({((AdBannerView)sender!).AdUnitId})");
        }

        private void OnAdFailedToLoad(object? sender, string error)
        {
            Debug.WriteLine($"Yandex banner ad failed to load ({((AdBannerView)sender!).AdUnitId}): {error}");
        }
    }
}
