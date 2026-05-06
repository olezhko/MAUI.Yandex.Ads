using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Yandex.Mobile.Ads.Common;

namespace MAUI.Yandex.Ads.Sample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MobileAds.Initialize(this, new ActionInitializationListener(() => { }));
        }
    }
}
