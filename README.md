# MAUI.Yandex.Ads

A .NET MAUI library that wraps the [Yandex Mobile Ads SDK](https://yandex.ru/dev/mobile-ads/) and exposes banner ad functionality as a native MAUI control.

## Supported platforms

| Platform | Minimum OS |
|----------|-----------|
| Android  | API 23    |
| iOS      | 15.0      |

## Installation

```
dotnet add package MAUI.Yandex.Ads
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
| `AdWidth`  | `int`    | `320`   | Requested banner width in dp / points |

### AdBannerView events

| Event            | Args            | Description                    |
|------------------|-----------------|--------------------------------|
| `AdLoaded`       | `EventArgs`     | Fired when the ad is displayed |
| `AdFailedToLoad` | `string` (error)| Fired when the ad request fails|

## iOS setup

The Yandex Mobile Ads xcframework is not distributed via NuGet. Before building for iOS you must place the framework at:

```
MAUI.Yandex.Ads/Frameworks/YandexMobileAds.xcframework
```

Download it from the [Yandex Mobile Ads iOS releases page](https://yandex.ru/dev/mobile-ads/doc/ios/quick-start/) and copy the `.xcframework` bundle into that directory. The `.csproj` picks it up automatically via `<NativeReference>`.

## License

MIT
