// Hand-written binding for YandexAdsBridge-Swift.h.
// Selectors match the @objc(...) names in native/YandexAdsBridge/YandexAdsBridge.swift.
// To regenerate/compare with Objective Sharpie:
//   cd native/build/ios.xcarchive/Products/Library/Frameworks/YandexAdsBridge.framework
//   sharpie bind --output=sharpie-out --namespace=YandexAdsBridge \
//     --sdk=iphoneos --scope=Headers Headers/YandexAdsBridge-Swift.h

using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using NFloat = System.Runtime.InteropServices.NFloat;

namespace YandexAdsBridge
{
    // @interface YABAds : NSObject
    [BaseType(typeof(NSObject), Name = "YABAds")]
    [DisableDefaultCtor]
    interface YABAds
    {
        // +(void)startWithCompletion:(void (^ _Nullable)(void))completion;
        [Static]
        [Export("startWithCompletion:")]
        [Async]
        void Start([NullAllowed] Action completion);

        [Static]
        [Export("enableLogging")]
        void EnableLogging();

        [Static]
        [Export("setUserConsent:")]
        void SetUserConsent(bool consent);

        [Static]
        [Export("setAgeRestricted:")]
        void SetAgeRestricted(bool restricted);

        [Static]
        [Export("setLocationTracking:")]
        void SetLocationTracking(bool enabled);

        [Static]
        [Export("sdkVersion")]
        string SdkVersion { get; }
    }

    // @interface YABBannerAd : NSObject <YMABannerAdViewDelegate>
    [BaseType(typeof(NSObject), Name = "YABBannerAd")]
    [DisableDefaultCtor]
    interface YABBannerAd
    {
        [Static]
        [Export("stickyWithContainerWidth:")]
        YABBannerAd Sticky(NFloat containerWidth);

        [Static]
        [Export("inlineWithWidth:maxHeight:")]
        YABBannerAd Inline(NFloat width, NFloat maxHeight);

        [Export("view")]
        UIView View { get; }

        [Export("contentSize")]
        CGSize ContentSize { get; }

        [Export("loadWithAdUnitId:")]
        void Load(string adUnitId);

        [Export("destroy")]
        void Destroy();

        [NullAllowed, Export("onLoaded", ArgumentSemantic.Copy)]
        Action OnLoaded { get; set; }

        [NullAllowed, Export("onFailedToLoad", ArgumentSemantic.Copy)]
        Action<NSError> OnFailedToLoad { get; set; }

        [NullAllowed, Export("onClicked", ArgumentSemantic.Copy)]
        Action OnClicked { get; set; }

        [NullAllowed, Export("onImpression", ArgumentSemantic.Copy)]
        Action OnImpression { get; set; }
    }

    // @interface YABInterstitialAd : NSObject
    [BaseType(typeof(NSObject), Name = "YABInterstitialAd")]
    interface YABInterstitialAd
    {
        [Export("isLoaded")]
        bool IsLoaded { get; }

        // -(void)loadWithAdUnitId:(NSString*)id completion:(void (^)(NSError * _Nullable))completion;
        [Export("loadWithAdUnitId:completion:")]
        void Load(string adUnitId, Action<NSError?> completion);

        [Export("showFromViewController:")]
        void Show(UIViewController viewController);

        [NullAllowed, Export("onShown", ArgumentSemantic.Copy)]
        Action OnShown { get; set; }

        [NullAllowed, Export("onDismissed", ArgumentSemantic.Copy)]
        Action OnDismissed { get; set; }

        [NullAllowed, Export("onClicked", ArgumentSemantic.Copy)]
        Action OnClicked { get; set; }

        [NullAllowed, Export("onImpression", ArgumentSemantic.Copy)]
        Action OnImpression { get; set; }

        [NullAllowed, Export("onFailedToShow", ArgumentSemantic.Copy)]
        Action<NSError> OnFailedToShow { get; set; }
    }

    // @interface YABRewardedAd : NSObject
    [BaseType(typeof(NSObject), Name = "YABRewardedAd")]
    interface YABRewardedAd
    {
        [Export("isLoaded")]
        bool IsLoaded { get; }

        [Export("loadWithAdUnitId:completion:")]
        void Load(string adUnitId, Action<NSError?> completion);

        [Export("showFromViewController:")]
        void Show(UIViewController viewController);

        [NullAllowed, Export("onShown", ArgumentSemantic.Copy)]
        Action OnShown { get; set; }

        [NullAllowed, Export("onDismissed", ArgumentSemantic.Copy)]
        Action OnDismissed { get; set; }

        [NullAllowed, Export("onClicked", ArgumentSemantic.Copy)]
        Action OnClicked { get; set; }

        [NullAllowed, Export("onImpression", ArgumentSemantic.Copy)]
        Action OnImpression { get; set; }

        [NullAllowed, Export("onFailedToShow", ArgumentSemantic.Copy)]
        Action<NSError> OnFailedToShow { get; set; }

        // void (^)(NSInteger amount, NSString *type)
        [NullAllowed, Export("onRewarded", ArgumentSemantic.Copy)]
        Action<nint, string> OnRewarded { get; set; }
    }
}
