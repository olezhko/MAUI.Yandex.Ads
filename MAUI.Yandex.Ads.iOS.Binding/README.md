# Yandex Mobile Ads SDK 8 → .NET MAUI (iOS)

Native Library Interop ("slim binding") setup, in three layers:

```
native/   Xcode framework project (Swift wrapper) + Podfile  →  YandexAdsBridge.xcframework
binding/  .NET iOS binding project (ApiDefinition.cs)          →  YandexAdsBridge.Binding.dll
app/      .NET MAUI app using banner / interstitial / rewarded
```

## Why a wrapper framework instead of binding YandexMobileAds directly

- SDK 8 is built with Swift 6; its ObjC surface (`YMA*`) is partial (no async loaders,
  MainActor-isolated types) and it drags in AppMetrica*, DivKit facade and resource bundles.
- The wrapper (`YAB*` classes) exposes only ObjC-friendly types (NSObject, UIView,
  UIViewController, NSString, NSError, blocks), so `ApiDefinition.cs` stays tiny and stable.
- The wrapper is a **dynamic** framework and the pods are **static** libs linked into it, so
  .NET references exactly one framework; all transitive pods, system frameworks and linker
  flags are resolved by Xcode/CocoaPods, not by you in MSBuild.

## Requirements (from Yandex docs + .NET)

- macOS, Xcode 16.4+ (SDK 8 requirement), CocoaPods, XcodeGen (`brew install xcodegen cocoapods`)
- .NET 10 SDK + `dotnet workload install maui`
- Deployment target iOS 15.0 (SDK needs 13+; 15 avoids Swift-concurrency back-deploy issues)

## 1. Native: Xcode library project + pod install

```bash
cd native
xcodegen generate          # creates YandexAdsBridge.xcodeproj from project.yml
pod install                # creates YandexAdsBridge.xcworkspace (YandexMobileAds 8.6.0)
open YandexAdsBridge.xcworkspace   # optional: build once in Xcode to check
./build.sh                 # does all of the above + archives device & simulator → build/YandexAdsBridge.xcframework
```

Prefer creating the project by hand? Xcode → New Project → iOS → **Framework**, name
`YandexAdsBridge`, then set: iOS 15.0, *Build Libraries for Distribution* = NO,
*Skip Install* = NO, *User Script Sandboxing* = NO, *Other Linker Flags* += `-ObjC`,
add `YandexAdsBridge/YandexAdsBridge.swift`, put the `Podfile` next to the `.xcodeproj`,
run `pod install`, and use `./build.sh` (it skips XcodeGen if the project already exists).

`build.sh` prints the generated `Headers/YandexAdsBridge-Swift.h` and the exported `YAB*`
classes so you can confirm the binding surface.

## 2. Binding project

```bash
cd binding/YandexAdsBridge.Binding
dotnet build
```

- References `native/build/YandexAdsBridge.xcframework` via `<NativeReference>`
  (runs `native/build.sh` automatically if the xcframework is missing).
- `ApiDefinition.cs` is hand-written to match the `@objc(...)` selectors. When you add
  wrapper APIs: add Swift with `@objc(selector:)`, rebuild native, add the matching
  `[Export("selector:")]` here (or diff against `sharpie bind` output — command in the file).

Bound API:

| C# | What it does |
|---|---|
| `YABAds.Start(cb)` / `StartAsync()` | `YandexAds.initializeSDK()` |
| `YABAds.EnableLogging()`, `SetUserConsent`, `SetAgeRestricted`, `SetLocationTracking`, `SdkVersion` | SDK settings |
| `YABBannerAd.Sticky(width)` / `Inline(width, maxHeight)` → `.View`, `.Load(id)`, `.ContentSize`, callbacks | `BannerAdView` + `BannerAdSize.sticky/inline` |
| `YABInterstitialAd.Load(id, cb)` / `.Show(vc)` + callbacks | `InterstitialAdLoader` / `InterstitialAd` |
| `YABRewardedAd.Load(id, cb)` / `.Show(vc)` + `OnRewarded(amount, type)` | `RewardedAdLoader` / `RewardedAd` |

## 3. MAUI app

```bash
cd app/YandexAdsSample
dotnet build -t:Run -f net10.0-ios            # simulator
```

- `Platforms/iOS/AppDelegate.cs` – logging (DEBUG) + manual SDK init in `FinishedLaunching`.
- `Controls/YandexBannerView.cs` + `Platforms/iOS/YandexBannerViewHandler.cs` – sticky banner as a MAUI view.
- `Platforms/iOS/YandexFullscreenAds.cs` – Task-based interstitial / rewarded.
- `update_skad_ids.sh` runs before each iOS build and merges Yandex's current SKAdNetwork
  IDs into `Platforms/iOS/Info.plist` (additive; skipped if offline).

Demo ad unit IDs used: `demo-banner-yandex`, `demo-interstitial-yandex`, `demo-rewarded-yandex`.
Replace them with your `R-M-XXXXX-YY` IDs before release.

## Verifying the integration

Console.app → filter `Subsystem = com.mobile.ads.ads.sdk`, `Category = Integration`.
You should see the SDK resource bundle being enabled, SDK init, and SKAdNetwork found.

If the log says the SDK **resource bundle is missing**: CocoaPods copies it into
`YandexAdsBridge.framework`; if the SDK looks in the main bundle instead, copy the `*.bundle`
found by `build.sh` into the app and add to `YandexAdsSample.csproj`:

```xml
<BundleResource Include="..\..\native\Pods\YandexMobileAds\static\YandexMobileAds.xcframework\MobileAdsBundle.bundle\**"
                Link="MobileAdsBundle.bundle\%(RecursiveDir)%(Filename)%(Extension)" />
```

(the path/bundle name is from the pod's podspec; check `native/Pods/YandexMobileAds` for the actual one).

## Gotchas

- Call every SDK API on the main thread (SDK 8 types are `@MainActor`).
- Don't retry loading immediately after a load failure; cap retries.
- Keep strong references to interstitial/rewarded objects while in use (`YandexFullscreenAds` does).
- Android: separate binding of `com.yandex.android:mobileads`; not covered here.
