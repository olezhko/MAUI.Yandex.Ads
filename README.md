# MAUI.Yandex.Ads

A .NET MAUI library that wraps the [Yandex Mobile Ads SDK](https://yandex.ru/dev/mobile-ads/) and exposes banner ad functionality as a native MAUI control.

## Supported platforms

| Platform | Minimum OS |
|----------|-----------|
| Android  | API 23    |
| iOS      | 15.0      |

## Installation

```
dotnet add package LATec.MAUI.Yandex.Ads
```

## Setup

Register the handler in `MauiProgram.cs`:

```csharp
using MAUI.Yandex.Ads;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseYandexAds();   // <-- add this

        return builder.Build();
    }
}
```

## Usage

### XAML

```xml
<ContentPage
    xmlns:yandex="clr-namespace:MAUI.Yandex.Ads;assembly=MAUI.Yandex.Ads">

    <yandex:AdBannerView
        AdUnitId="your-ad-unit-id"
        AdWidth="320"
        HeightRequest="50"
        HorizontalOptions="Center" />

</ContentPage>
```

### C#

```csharp
using MAUI.Yandex.Ads;

var banner = new AdBannerView
{
    AdUnitId = "your-ad-unit-id",
    AdWidth = 320,
    HeightRequest = 50,
    HorizontalOptions = LayoutOptions.Center
};

banner.AdLoaded += (s, e) => Console.WriteLine("Ad loaded");
banner.AdFailedToLoad += (s, error) => Console.WriteLine($"Ad failed: {error}");
```

## API

### AdBannerView properties

| Property   | Type     | Default | Description                          |
|------------|----------|---------|--------------------------------------|
| `AdUnitId` | `string` | `""`    | Yandex ad unit ID                    |
| `AdWidth`  | `int`    | `320`   | Requested banner width in dp (Android only; iOS uses the full safe-area width) |

### AdBannerView events

| Event            | Args            | Description                    |
|------------------|-----------------|--------------------------------|
| `AdLoaded`       | `EventArgs`     | Fired when the ad is displayed |
| `AdFailedToLoad` | `string` (error)| Fired when the ad request fails|

## Android setup

Initialize the SDK once at startup, for example in `Platforms/Android/MainActivity.cs`:

```csharp
using Com.Yandex.Mobile.Ads.Common;
using MAUI.Yandex.Ads;

public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        MobileAds.Initialize(this, new ActionInitializationListener(() => { }));
    }
}
```

## iOS setup

The library talks to Yandex Mobile Ads SDK 8 through a small Swift wrapper, `YandexAdsBridge.xcframework`, which is embedded in the app automatically. The SDK can't add anything to your app's `Info.plist`, so the steps below are done in the app.

### 1. Initialize the SDK

In `Platforms/iOS/AppDelegate.cs`:

```csharp
using YandexAdsBridge;

public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
{
#if DEBUG
    YABAds.EnableLogging(); // Console.app: Subsystem = com.mobile.ads.ads.sdk
#endif
    YABAds.Start(() => Console.WriteLine($"Yandex Mobile Ads {YABAds.SdkVersion} initialized"));
    return base.FinishedLaunching(application, launchOptions);
}
```

### 2. Adopt the UIScene life cycle

Apps built with the iOS 26+ SDK fail to launch with *"UIScene life cycle is required for apps built with this SDK"* unless they use scenes. Add a scene delegate (only one class may be registered as `SceneDelegate`):

```csharp
// Platforms/iOS/SceneDelegate.cs
using Foundation;

[Register("SceneDelegate")]
public class SceneDelegate : MauiUISceneDelegate
{
}
```

and declare it in `Platforms/iOS/Info.plist`:

```xml
<key>UIApplicationSceneManifest</key>
<dict>
    <key>UIApplicationSupportsMultipleScenes</key>
    <false/>
    <key>UISceneConfigurations</key>
    <dict>
        <key>UIWindowSceneSessionRoleApplication</key>
        <array>
            <dict>
                <key>UISceneConfigurationName</key>
                <string>__MAUI_DEFAULT_SCENE_CONFIGURATION__</string>
                <key>UISceneDelegateClassName</key>
                <string>SceneDelegate</string>
            </dict>
        </array>
    </dict>
</dict>
```

### 3. Add SKAdNetwork IDs

Without Yandex's SKAdNetwork IDs, banners fail with *"App doesn't support SKAdNetwork"*. Add every ID from [skadids.json](https://yastatic.net/pcode-static/skadnetwork/skadids.json) to `SKAdNetworkItems` in `Platforms/iOS/Info.plist`:

```xml
<key>SKAdNetworkItems</key>
<array>
    <dict>
        <key>SKAdNetworkIdentifier</key>
        <string>zq492l623r.skadnetwork</string>
    </dict>
    <!-- ... -->
</array>
```

This repository's `update_skad_ids.sh` merges the current list into a plist for you (macOS):

```
bash update_skad_ids.sh Platforms/iOS/Info.plist
```

### Troubleshooting

- After you change `Info.plist`, do a clean build (delete `bin/` and `obj/` for `net10.0-ios`) and reinstall the app. Incremental builds can keep the old plist in the app bundle.
- To see SDK diagnostics, open Console.app and filter on `Subsystem = com.mobile.ads.ads.sdk`, `Category = Integration`.
- To rebuild the native wrapper (contributors only), run `native/build.sh`. It needs Xcode, CocoaPods and XcodeGen. See `MAUI.Yandex.Ads.iOS.Binding/README.md`.

## License

MIT
