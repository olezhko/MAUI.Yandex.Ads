using Foundation;
using UIKit;
using YandexAdsBridge;

namespace MAUI.Yandex.Ads.Sample
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
        {
    #if DEBUG
            YABAds.EnableLogging(); // Console.app: Subsystem = com.mobile.ads.ads.sdk
    #endif
            // Manual init speeds up the first ad (docs: Quick start → Initializing the library).
            YABAds.Start(() => Console.WriteLine($"Yandex Mobile Ads {YABAds.SdkVersion} initialized"));

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}
