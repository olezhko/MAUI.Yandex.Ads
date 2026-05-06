# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET MAUI library (`MAUI.Yandex.Ads`) that wraps the Yandex Mobile Ads SDK to expose banner ad functionality to .NET MAUI apps. It targets `net10.0-android`, `net10.0-ios`, and `net10.0-maccatalyst` (iOS/Mac only on non-Linux build hosts).

## Build Commands

```bash
# Build all supported platforms
dotnet build MAUI10.Yandex.Ads/MAUI.Yandex.Ads.csproj

# Build Android only (works on any OS)
dotnet build MAUI10.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-android

# Build iOS (requires macOS + Xcode)
dotnet build MAUI10.Yandex.Ads/MAUI.Yandex.Ads.csproj -f net10.0-ios
```

There are no test projects in this repository.

## Architecture

### MAUI Handler Pattern

The library uses the standard MAUI handler architecture:

- **`AdBannerView.cs`** — the cross-platform `View` subclass with bindable properties (`AdUnitId`, `AdWidth`) and events (`AdLoaded`, `AdFailedToLoad`). This is what consumers reference in XAML/C#.
- **`Platforms/Android/AdBannerViewHandler.cs`** — platform implementation using `BannerAdView` from the Yandex Android SDK. Compiled only for `-android` target.
- **`Platforms/iOS/AdBannerViewHandler.cs`** — platform implementation using `YMABannerAdView` from the Yandex iOS xcframework. Compiled only for `-ios` and `-maccatalyst` targets.
- **`AdBannerViewHandler.cs`** (root) — a non-functional stub compiled for unsupported platforms (e.g., Windows, Mac Catalyst without iOS support). It is intentionally left empty so the project builds without errors on those targets.
- **`YandexAdsMauiExtensions.cs`** — provides the `UseYandexAds(this MauiAppBuilder)` extension method that registers the handler. Consumers call this in `MauiProgram.cs`.

### Native SDK Integration

- **Android**: Pulled automatically at build time via `<AndroidMavenLibrary Include="com.yandex.android:mobileads" Version="7.7.0" />` — no manual download needed.
- **iOS**: Requires manually placing `YandexMobileAds.xcframework` at `MAUI10.Yandex.Ads/Frameworks/YandexMobileAds.xcframework`. The `.csproj` references it via `<NativeReference>`. This directory does not exist in source control and must be populated before iOS builds will succeed.

### Adding a New Platform Handler

1. Create `Platforms/{Platform}/AdBannerViewHandler.cs` as a `public partial class AdBannerViewHandler : ViewHandler<AdBannerView, TNativeView>`.
2. Implement `CreatePlatformView()`, `ConnectHandler()`, and property mappers.
3. The root-level stub will be excluded automatically by the MAUI build system for that platform.

### Consumer Integration

```csharp
// MauiProgram.cs
builder.UseYandexAds();

// XAML
<yandex:AdBannerView AdUnitId="your-unit-id" AdWidth="320" />
```
