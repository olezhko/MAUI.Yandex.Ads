# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

`MAUI.Yandex.Ads` is a .NET MAUI library that wraps the Yandex Mobile Ads SDK and exposes a banner ad control (`AdBannerView`) to MAUI apps. It targets `net10.0-android` and `net10.0-ios` only (min Android API 23, iOS 15.0).

The solution (`MAUI.Yandex.Ads.slnx`) has three projects:

- **`MAUI.Yandex.Ads/`**: the library itself (cross-platform control plus per-platform handlers).
- **`MAUI.Yandex.Ads.iOS.Binding/`**: an Objective-C binding project for `YandexMobileAds.xcframework`, which is committed in that directory. The library references it only for `-ios` targets.
- **`MAUI.Yandex.Ads.Sample/`**: a MAUI sample app (based on the standard MAUI template) that references the library. It uses `<yandexAds:AdBannerView>` in `Pages/MainPage.xaml` and is the place to manually test changes.

## Build Commands

```bash
# Library, both platforms
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj

# Single platform
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-android
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-ios   # macOS + Xcode required

# Run the sample app
dotnet build MAUI.Yandex.Ads.Sample/MAUI.Yandex.Ads.Sample.csproj -f net10.0-android -t:Run
```

There are no test projects.

## Architecture

### Handler pattern

- `AdBannerView.cs` is the cross-platform `View`. It has the bindable properties `AdUnitId` and `AdWidth` and the events `AdLoaded` and `AdFailedToLoad`. Handlers fire the events through the `internal` methods `RaiseAdLoaded` and `RaiseAdFailedToLoad`.
- `Platforms/Android/AdBannerViewHandler.cs` and `Platforms/iOS/AdBannerViewHandler.cs` are `partial class AdBannerViewHandler` implementations in the `MAUI.Yandex.Ads` namespace. There is no shared or stub handler. A target without a platform folder has no handler.
- `YandexAdsMauiExtensions.UseYandexAds()` registers the handler under `#if ANDROID` / `#elif IOS`. A new platform has to be added here as well.
- Only `AdUnitId` is in the property mappers. `AdWidth` is read only when the ad is created or loaded (Android: `BannerAdSize.StickySize`; iOS: `YMABannerAdSize.StickySizeWithContainerWidth` in `CreatePlatformView`), so changing it later has no effect.

### Android native SDK

- The SDK is fetched from Maven with `<AndroidMavenLibrary Include="com.yandex.android:mobileads" ...>`. Its many transitive Maven dependencies (`com.yandex.div`, `io.appmetrica.analytics`, `yatagan`, `varioqub`, …) are listed explicitly with `Bind="false"`. The ones that have NuGet equivalents (AndroidX, Kotlin, OkHttp, Play Services) come in as `PackageReference`s instead. When you bump the SDK version, update this dependency list together with it. Java dependency verification errors usually mean an entry is missing.
- `Transforms/Metadata.xml` fixes up the generated bindings. `BannerAdView` and `BannerAdSize` extend obfuscated internal classes that get no C# type, so they are re-parented to `RelativeLayout` and `Object`. A `CallToActionView.getText` override that breaks compilation is removed. A new SDK version may change the obfuscated names and need new transforms.
- The library does not call `MobileAds.Initialize`. The consuming app does that itself, as `MAUI.Yandex.Ads.Sample/Platforms/Android/MainActivity.cs` shows using `ActionInitializationListener` (a helper exposed by the library).

### iOS native SDK

- `ApiDefinition.cs` and `StructsAndEnums.cs` in the binding project are hand-maintained bindings, originally generated from the xcframework headers. The handler uses `YMAAdView`, `YMAAdViewDelegate` and `YMABannerAdSize` from the `MAUI.Yandex.Ads.iOS.Binding` namespace. When the xcframework is updated, update these definitions to match its headers.
