# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

`MAUI.Yandex.Ads` is a .NET MAUI library that wraps the Yandex Mobile Ads SDK and exposes a banner ad control (`AdBannerView`) to MAUI apps. It targets `net10.0-android` and `net10.0-ios` only (min Android API 23, iOS 15.0).

The solution (`MAUI.Yandex.Ads.slnx`) has three .NET projects plus a native Xcode project:

- **`MAUI.Yandex.Ads/`**: the library (cross-platform control plus per-platform handlers).
- **`native/`**: Xcode framework project `YandexAdsBridge`, a Swift wrapper around Yandex Mobile Ads SDK 8 (CocoaPods). Its output `native/build/YandexAdsBridge.xcframework` is committed.
- **`MAUI.Yandex.Ads.iOS.Binding/`**: .NET iOS binding over `YandexAdsBridge.xcframework` (namespace `YandexAdsBridge`). The library references it only for `-ios` targets. Its `README.md` has the full iOS setup details.
- **`MAUI.Yandex.Ads.Sample/`**: a MAUI sample app (based on the standard MAUI template) that references the library. It uses `<yandexAds:AdBannerView>` in `Pages/MainPage.xaml` and is where changes get tested by hand.

## Build Commands

```bash
# Library, both platforms
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj

# Single platform
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-android
dotnet build MAUI.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-ios   # macOS + Xcode required

# Run the sample app
dotnet build MAUI.Yandex.Ads.Sample/MAUI.Yandex.Ads.Sample.csproj -f net10.0-android -t:Run
dotnet build MAUI.Yandex.Ads.Sample/MAUI.Yandex.Ads.Sample.csproj -f net10.0-ios -t:Run       # simulator

# Rebuild the native iOS wrapper (needs Xcode, CocoaPods, XcodeGen: brew install xcodegen cocoapods)
native/build.sh   # xcodegen generate + pod install + archive device/simulator -> native/build/YandexAdsBridge.xcframework
```

There are no test projects.

An incremental iOS build does not always refresh the app bundle's `Info.plist`. After you edit `Platforms/iOS/Info.plist`, delete `bin/Debug/net10.0-ios` and `obj/Debug/net10.0-ios` and reinstall the app. To confirm the change made it in, run `plutil -p` on the plist inside the built `.app`.

## Architecture

### Cross-platform control

- `AdBannerView.cs` is the cross-platform `View`. It has the bindable properties `AdUnitId` and `AdWidth` and the events `AdLoaded` and `AdFailedToLoad(string error)`. Handlers fire the events through the `internal` methods `RaiseAdLoaded` and `RaiseAdFailedToLoad`.
- `YandexAdsMauiExtensions.UseYandexAds()` registers `AdBannerViewHandler` under `#if ANDROID` / `#elif IOS`. A new platform has to be added here as well.
- The two handlers are not shared partials. Android: `Platforms/Android/AdBannerViewHandler.cs`, namespace `MAUI.Yandex.Ads`. iOS: `Platforms/iOS/YandexBannerViewHandler.cs`, class `AdBannerViewHandler` in namespace `MAUI.Yandex.Ads.Platforms.iOS`. Only `AdUnitId` is in the property mappers, and a change to it reloads the banner.
- `AdWidth` is used only on Android (`BannerAdSize.StickySize`). The iOS handler ignores it and uses the key window's safe-area width (`YABBannerAd.Sticky(width)`). On iOS the handler sets `HeightRequest` from the banner's `ContentSize` after it loads.

### Android native SDK

- The SDK is fetched from Maven with `<AndroidMavenLibrary Include="com.yandex.android:mobileads" ...>`. Its many transitive Maven dependencies (`com.yandex.div`, `io.appmetrica.analytics`, `yatagan`, `varioqub`, …) are listed explicitly with `Bind="false"`. The ones that have NuGet equivalents (AndroidX, Kotlin, OkHttp, Play Services) come in as `PackageReference`s instead. When you bump the SDK version, update this dependency list together with it. Java dependency verification errors usually mean an entry is missing.
- `Transforms/Metadata.xml` fixes up the generated bindings. `BannerAdView` and `BannerAdSize` extend obfuscated internal classes that get no C# type, so they are re-parented to `RelativeLayout` and `Object`. A `CallToActionView.getText` override that breaks compilation is removed. A new SDK version may change the obfuscated names and need new transforms.
- The library does not call `MobileAds.Initialize`. The consuming app does that itself, as `MAUI.Yandex.Ads.Sample/Platforms/Android/MainActivity.cs` shows using `ActionInitializationListener` (a helper exposed by the library).

### iOS native SDK (Swift wrapper + slim binding)

- SDK 8 is Swift 6, and its ObjC surface is incomplete. `native/YandexAdsBridge/YandexAdsBridge.swift` exposes ObjC-friendly `YAB*` classes instead: `YABAds` (init and settings), `YABBannerAd`, `YABInterstitialAd` and `YABRewardedAd`. They are all `@MainActor`, so call them on the main thread.
- `YandexAdsBridge` is a **dynamic** framework, and the pods (YandexMobileAds, AppMetrica*, DivKit) are statically linked into it. As a result the .NET side has one `NativeReference` and needs no linker flags. The pod version is pinned in `native/Podfile`. The Xcode project is generated from `native/project.yml`.
- `MAUI.Yandex.Ads.iOS.Binding/ApiDefinition.cs` is hand-written to match the `@objc(...)` selectors. To add an API: add Swift with `@objc(selector:)`, run `native/build.sh`, then add the matching `[Export("selector:")]`. The binding csproj runs `native/build.sh` automatically only when the xcframework is missing.
- `Platforms/iOS/YandexFullscreenAds.cs` offers Task-based helpers for interstitial and rewarded ads. It is not wired into `UseYandexAds()`.
- `MAUI.Yandex.Ads/Frameworks/YandexMobileAds.xcframework` is left over from an earlier direct binding. No project references it.

### Requirements on the consuming iOS app

These have to live in the app, not the library, because a library cannot add keys to the app's `Info.plist`:

- **SDK init:** the app calls `YABAds.Start(...)` (and `YABAds.EnableLogging()` in DEBUG) in `AppDelegate.FinishedLaunching`. See the sample's `Platforms/iOS/AppDelegate.cs`.
- **UIScene life cycle (required by the iOS 26+ SDK):** `Info.plist` needs a `UIApplicationSceneManifest` that maps `__MAUI_DEFAULT_SCENE_CONFIGURATION__` to `UISceneDelegateClassName` `SceneDelegate`. A `[Register("SceneDelegate")] class SceneDelegate : MauiUISceneDelegate` must exist exactly once across all loaded assemblies. Two copies crash at startup with "Cannot register two managed types". It currently lives in the sample (`Platforms/iOS/SceneDelegate.cs`).
- **SKAdNetwork:** `Info.plist` needs Yandex's `SKAdNetworkItems`, otherwise banners fail with "App doesn't support SKAdNetwork". `update_skad_ids.sh <Info.plist>` merges in the current IDs from `https://yastatic.net/pcode-static/skadnetwork/skadids.json`. The library's `UpdateYandexSkadIds` MSBuild target runs it against `MAUI.Yandex.Ads/Platforms/iOS/Info.plist`, which does not exist. The sample's copy of the script is run by hand.
- **Debugging the SDK:** in Console.app, filter on `Subsystem = com.mobile.ads.ads.sdk` (category `Integration`).
