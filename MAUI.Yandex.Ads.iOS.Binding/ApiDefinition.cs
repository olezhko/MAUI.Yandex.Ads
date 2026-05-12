using Foundation;
using ObjCRuntime;
using System;
using UIKit;
using CoreLocation;
using CoreGraphics;

namespace MAUI.Yandex.Ads.iOS.Binding
{
    // The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
    // to the project.
    // Open your binding csproj and add a section like this
    // <ItemGroup>
    //   <NativeReference Include="MyLibrary.xcframework">
    //     <Kind>Framework</Kind>
    //     <Frameworks></Frameworks>
    //   </NativeReference>
    // </ItemGroup>
    //
    // Once you've added it, you will need to customize it for your specific library:
    //  - Change the Include to the correct path/name of your library
    //  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
    //    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
    //  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
    // Example:
    // <NativeReference Include="libs\MyTestFramework.xcframework">
    //   <Kind>Framework</Kind>
    //   <Frameworks>CoreLocation ModelIO</Frameworks>
    // </NativeReference>
    // 
    // Once you've done that, you're ready to move on to binding the API...
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, nint index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     NativeHandle Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //


    [Static]
    partial interface Constants
    {
        // extern NSString *const kYMAAdsErrorDomain __attribute__((deprecated("This constant is deprecated. Use `NSError.isYandexMobileAdsError` instead.")));
        [Field("kYMAAdsErrorDomain", "__Internal")]
        NSString kYMAAdsErrorDomain { get; }

        // extern NSString *const kYMANativeAdErrorDomain __attribute__((deprecated("This constant is deprecated. Use `NSError.isYandexMobileNativeAdsError` instead.")));
        [Field("kYMANativeAdErrorDomain", "__Internal")]
        NSString kYMANativeAdErrorDomain { get; }

        // extern NSString *const _Nonnull kYMAGenderFemale;
        [Field("kYMAGenderFemale", "__Internal")]
        NSString kYMAGenderFemale { get; }

        // extern NSString *const _Nonnull kYMAGenderMale;
        [Field("kYMAGenderMale", "__Internal")]
        NSString kYMAGenderMale { get; }
    }

    // @interface YMANativeAdView : UIView
    [BaseType(typeof(UIView))]
    interface YMANativeAdView
    {
        // @property (nonatomic, strong) UILabel * _Nullable ageLabel __attribute__((iboutlet));
        [NullAllowed, Export("ageLabel", ArgumentSemantic.Strong)]
        UILabel AgeLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable bodyLabel __attribute__((iboutlet));
        [NullAllowed, Export("bodyLabel", ArgumentSemantic.Strong)]
        UILabel BodyLabel { get; set; }

        // @property (nonatomic, strong) UIButton * _Nullable callToActionButton __attribute__((iboutlet));
        [NullAllowed, Export("callToActionButton", ArgumentSemantic.Strong)]
        UIButton CallToActionButton { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable domainLabel __attribute__((iboutlet));
        [NullAllowed, Export("domainLabel", ArgumentSemantic.Strong)]
        UILabel DomainLabel { get; set; }

        // @property (nonatomic, strong) UIImageView * _Nullable faviconImageView __attribute__((iboutlet));
        [NullAllowed, Export("faviconImageView", ArgumentSemantic.Strong)]
        UIImageView FaviconImageView { get; set; }

        // @property (nonatomic, strong) UIButton * _Nullable feedbackButton __attribute__((iboutlet));
        [NullAllowed, Export("feedbackButton", ArgumentSemantic.Strong)]
        UIButton FeedbackButton { get; set; }

        // @property (nonatomic, strong) UIImageView * _Nullable iconImageView __attribute__((iboutlet));
        [NullAllowed, Export("iconImageView", ArgumentSemantic.Strong)]
        UIImageView IconImageView { get; set; }

        // @property (nonatomic, strong) YMANativeMediaView * _Nullable mediaView __attribute__((iboutlet));
        [NullAllowed, Export("mediaView", ArgumentSemantic.Strong)]
        YMANativeMediaView MediaView { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable priceLabel __attribute__((iboutlet));
        [NullAllowed, Export("priceLabel", ArgumentSemantic.Strong)]
        UILabel PriceLabel { get; set; }

        // @property (nonatomic, strong) UIView<YMARating> * _Nullable ratingView __attribute__((iboutlet));
        [NullAllowed, Export("ratingView", ArgumentSemantic.Strong)]
        YMARating RatingView { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable reviewCountLabel __attribute__((iboutlet));
        [NullAllowed, Export("reviewCountLabel", ArgumentSemantic.Strong)]
        UILabel ReviewCountLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable sponsoredLabel __attribute__((iboutlet));
        [NullAllowed, Export("sponsoredLabel", ArgumentSemantic.Strong)]
        UILabel SponsoredLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable titleLabel __attribute__((iboutlet));
        [NullAllowed, Export("titleLabel", ArgumentSemantic.Strong)]
        UILabel TitleLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable warningLabel __attribute__((iboutlet));
        [NullAllowed, Export("warningLabel", ArgumentSemantic.Strong)]
        UILabel WarningLabel { get; set; }

        // @property (readonly, nonatomic, strong) id<YMANativeAd> _Nullable ad;
        [NullAllowed, Export("ad", ArgumentSemantic.Strong)]
        YMANativeAd Ad { get; }
    }

    // @interface YMANativeMediaView : UIView
    [BaseType(typeof(UIView))]
    interface YMANativeMediaView
    {
    }

    // @interface YMAAdAttributes : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdAttributes
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable campaignID;
        [NullAllowed, Export("campaignID")]
        string CampaignID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable bannerID;
        [NullAllowed, Export("bannerID")]
        string BannerID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable placeID;
        [NullAllowed, Export("placeID")]
        string PlaceID { get; }
    }

    // @interface YMAAdInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdInfo
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull adUnitId;
        [Export("adUnitId")]
        string AdUnitId { get; }

        // @property (readonly, copy, nonatomic) SWIFT_DEPRECATED_MSG("`info` property is deprecated. Use `adAttributes` property of ad class instead.") NSString * data __attribute__((deprecated("`info` property is deprecated. Use `adAttributes` property of ad class instead.")));
        [Export("data")]
        string Data { get; }

        // @property (readonly, nonatomic, strong) YMAAdSize * _Nullable adSize;
        [NullAllowed, Export("adSize", ArgumentSemantic.Strong)]
        YMAAdSize AdSize { get; }

        // @property (readonly, copy, nonatomic) NSArray<YMACreative *> * _Nonnull creatives;
        [Export("creatives", ArgumentSemantic.Copy)]
        YMACreative[] Creatives { get; }

        // -(instancetype _Nonnull)initWithAdUnitId:(NSString * _Nonnull)adUnitId adSize:(YMAAdSize * _Nullable)adSize;
        [Export("initWithAdUnitId:adSize:")]
        NativeHandle Constructor(string adUnitId, [NullAllowed] YMAAdSize adSize);
    }

    // @interface YMAAdRequest : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMAAdRequest : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; }

        // @property (readonly, nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme")]
        YMAAdTheme AdTheme { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable headerBiddingData;
        [NullAllowed, Export("headerBiddingData")]
        string HeaderBiddingData { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable readyResponse;
        [NullAllowed, Export("readyResponse")]
        string ReadyResponse { get; }

        // @property (readonly, nonatomic, strong) YMAMutableAdRequest * _Nonnull mutableRequest;
        [Export("mutableRequest", ArgumentSemantic.Strong)]
        YMAMutableAdRequest MutableRequest { get; }

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableRequest` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAAdRequestConfiguration : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdRequestConfiguration : INSCopying, INSMutableCopying
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitID { get; }

        // @property (readonly, nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; }

        // @property (readonly, nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme")]
        YMAAdTheme AdTheme { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; }

        // @property (readonly, nonatomic, strong) YMAMutableAdRequestConfiguration * _Nonnull mutableConfiguration;
        [Export("mutableConfiguration", ArgumentSemantic.Strong)]
        YMAMutableAdRequestConfiguration MutableConfiguration { get; }

        // -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID;
        [Export("initWithAdUnitID:")]
        NativeHandle Constructor(string adUnitID);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableConfiguration` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAAdRequestError : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdRequestError
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable adUnitId;
        [NullAllowed, Export("adUnitId")]
        string AdUnitId { get; }

        // @property (readonly, nonatomic) NSError * _Nonnull error;
        [Export("error")]
        NSError Error { get; }

        // -(instancetype _Nonnull)initWithAdUnitId:(NSString * _Nullable)adUnitId error:(NSError * _Nonnull)error;
        [Export("initWithAdUnitId:error:")]
        NativeHandle Constructor([NullAllowed] string adUnitId, NSError error);
    }

    // @interface YMAAdRequestTokenConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdRequestTokenConfiguration
    {
        // @property (readonly, nonatomic, strong) YMAAdTargetInfo * _Nonnull targetInfo;
        [Export("targetInfo", ArgumentSemantic.Strong)]
        YMAAdTargetInfo TargetInfo { get; }

        // @property (readonly, nonatomic, strong) YMABannerAdSize * _Nullable bannerAdSize;
        [NullAllowed, Export("bannerAdSize", ArgumentSemantic.Strong)]
        YMABannerAdSize BannerAdSize { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; }
    }

    // @interface YMAAdRequestTokenLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMAAdRequestTokenLoader
    {
        // -(void)loadRequestTokenWithRequestConfiguration:(YMAAdRequestTokenConfiguration * _Nonnull)requestConfiguration completionHandler:(void (^ _Nonnull)(NSString * _Nullable))completionHandler;
        [Export("loadRequestTokenWithRequestConfiguration:completionHandler:")]
        void LoadRequestTokenWithRequestConfiguration(YMAAdRequestTokenConfiguration requestConfiguration, Action<NSString> completionHandler);
    }

    // @interface YMAAdSize : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdSize
    {
        // @property (readonly, nonatomic) CGFloat width;
        [Export("width")]
        nfloat Width { get; }

        // @property (readonly, nonatomic) CGFloat height;
        [Export("height")]
        nfloat Height { get; }

        // -(instancetype _Nonnull)initWithSize:(CGSize)size;
        [Export("initWithSize:")]
        NativeHandle Constructor(CGSize size);
    }

    // @interface YMAAdTargetInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAdTargetInfo
    {
        // @property (nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; set; }

        // @property (nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; set; }
    }

    // @interface YMAAdView : UIView
    [BaseType(typeof(UIView))]
    interface YMAAdView
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitID { get; }

        // @property (readonly, copy, nonatomic) SWIFT_DEPRECATED_MSG("`info` property is deprecated. Use `adAttributes` property instead.") NSString * info __attribute__((deprecated("`info` property is deprecated. Use `adAttributes` property instead.")));
        [Export("info")]
        string Info { get; }

        // @property (readonly, copy, nonatomic) NSArray<YMAAdAttributes *> * _Nonnull adAttributes;
        [Export("adAttributes", ArgumentSemantic.Copy)]
        YMAAdAttributes[] AdAttributes { get; }

        // @property (readonly, nonatomic, strong) YMAAdInfo * _Nullable adInfo;
        [NullAllowed, Export("adInfo", ArgumentSemantic.Strong)]
        YMAAdInfo AdInfo { get; }

        // @property (readonly, nonatomic, strong) SWIFT_DEPRECATED_MSG("`videoController` property will be removed in future versions.") YMAVideoController * videoController __attribute__((deprecated("`videoController` property will be removed in future versions.")));
        [Export("videoController", ArgumentSemantic.Strong)]
        YMAVideoController VideoController { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAAdViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAAdViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID adSize:(YMABannerAdSize * _Nonnull)adSize;
        [Export("initWithAdUnitID:adSize:")]
        NativeHandle Constructor(string adUnitID, YMABannerAdSize adSize);

        // -(void)displayAtTopInView:(UIView * _Nonnull)view;
        [Export("displayAtTopInView:")]
        void DisplayAtTopInView(UIView view);

        // -(void)displayAtBottomInView:(UIView * _Nonnull)view;
        [Export("displayAtBottomInView:")]
        void DisplayAtBottomInView(UIView view);

        // -(void)loadAd;
        [Export("loadAd")]
        void LoadAd();

        // -(void)loadAdWithRequest:(YMAAdRequest * _Nullable)request;
        [Export("loadAdWithRequest:")]
        void LoadAdWithRequest([NullAllowed] YMAAdRequest request);

        // -(CGSize)adContentSize __attribute__((warn_unused_result("")));
        [Export("adContentSize")]
        //[Verify(MethodToProperty)]
        CGSize AdContentSize { get; }

        // @property (readonly, nonatomic) CGSize intrinsicContentSize;
        [Export("intrinsicContentSize")]
        CGSize IntrinsicContentSize { get; }

        // -(void)didMoveToSuperview;
        [Export("didMoveToSuperview")]
        void DidMoveToSuperview();

        // -(BOOL)pointInside:(CGPoint)point withEvent:(UIEvent * _Nullable)event __attribute__((warn_unused_result("")));
        [Export("pointInside:withEvent:")]
        bool PointInside(CGPoint point, [NullAllowed] UIEvent @event);
    }

    // @protocol YMAAdViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAAdViewDelegate
    {
        // @optional -(UIViewController * _Nullable)viewControllerForPresentingModalView __attribute__((warn_unused_result("")));
        [NullAllowed, Export("viewControllerForPresentingModalView")]
        //[Verify(MethodToProperty)]
        UIViewController ViewControllerForPresentingModalView { get; }

        // @optional -(void)adViewDidLoad:(YMAAdView * _Nonnull)adView;
        [Export("adViewDidLoad:")]
        void AdViewDidLoad(YMAAdView adView);

        // @optional -(void)adViewDidFailLoading:(YMAAdView * _Nonnull)adView error:(NSError * _Nonnull)error;
        [Export("adViewDidFailLoading:error:")]
        void AdViewDidFailLoading(YMAAdView adView, NSError error);

        // @optional -(void)adViewDidClick:(YMAAdView * _Nonnull)adView;
        [Export("adViewDidClick:")]
        void AdViewDidClick(YMAAdView adView);

        // @optional -(void)adViewWillLeaveApplication:(YMAAdView * _Nonnull)adView;
        [Export("adViewWillLeaveApplication:")]
        void AdViewWillLeaveApplication(YMAAdView adView);

        // @optional -(void)adView:(YMAAdView * _Nonnull)adView willPresentScreen:(UIViewController * _Nullable)viewController;
        [Export("adView:willPresentScreen:")]
        void AdView_WillPresentScreen(YMAAdView adView, [NullAllowed] UIViewController viewController);

        // @optional -(void)adView:(YMAAdView * _Nonnull)adView didDismissScreen:(UIViewController * _Nullable)viewController;
        [Export("adView:didDismissScreen:")]
        void AdView_DidDismissScreen(YMAAdView adView, [NullAllowed] UIViewController viewController);

        // @optional -(void)adView:(YMAAdView * _Nonnull)adView didTrackImpressionWithData:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("adView:didTrackImpressionWithData:")]
        void AdView(YMAAdView adView, [NullAllowed] YMAImpressionData impressionData);

        // @optional -(void)closeAdView:(YMAAdView * _Nonnull)adView;
        [Export("closeAdView:")]
        void CloseAdView(YMAAdView adView);
    }

    // @interface YMAAppOpenAd : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAppOpenAd
    {
        // @property (readonly, nonatomic, strong) YMAAdInfo * _Nullable adInfo;
        [NullAllowed, Export("adInfo", ArgumentSemantic.Strong)]
        YMAAdInfo AdInfo { get; }

        // @property (readonly, copy, nonatomic) NSArray<YMAAdAttributes *> * _Nonnull adAttributes;
        [Export("adAttributes", ArgumentSemantic.Copy)]
        YMAAdAttributes[] AdAttributes { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAAppOpenAdDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAAppOpenAdDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)showFromViewController:(UIViewController * _Nullable)viewController;
        [Export("showFromViewController:")]
        void ShowFromViewController([NullAllowed] UIViewController viewController);
    }

    // @protocol YMAAppOpenAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAAppOpenAdDelegate
    {
        // @optional -(void)appOpenAd:(YMAAppOpenAd * _Nonnull)appOpenAd didFailToShowWithError:(NSError * _Nonnull)error;
        [Export("appOpenAd:didFailToShowWithError:")]
        void AppOpenAd(YMAAppOpenAd appOpenAd, NSError error);

        // @optional -(void)appOpenAdDidShow:(YMAAppOpenAd * _Nonnull)appOpenAd;
        [Export("appOpenAdDidShow:")]
        void AppOpenAdDidShow(YMAAppOpenAd appOpenAd);

        // @optional -(void)appOpenAdDidDismiss:(YMAAppOpenAd * _Nonnull)appOpenAd;
        [Export("appOpenAdDidDismiss:")]
        void AppOpenAdDidDismiss(YMAAppOpenAd appOpenAd);

        // @optional -(void)appOpenAdDidClick:(YMAAppOpenAd * _Nonnull)appOpenAd;
        [Export("appOpenAdDidClick:")]
        void AppOpenAdDidClick(YMAAppOpenAd appOpenAd);

        // @optional -(void)appOpenAd:(YMAAppOpenAd * _Nonnull)appOpenAd didTrackImpressionWithData:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("appOpenAd:didTrackImpressionWithData:")]
        void AppOpenAd(YMAAppOpenAd appOpenAd, [NullAllowed] YMAImpressionData impressionData);
    }

    // @interface YMAAppOpenAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMAAppOpenAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAAppOpenAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAAppOpenAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdWithRequestConfiguration:(YMAAdRequestConfiguration * _Nonnull)request;
        [Export("loadAdWithRequestConfiguration:")]
        void LoadAdWithRequestConfiguration(YMAAdRequestConfiguration request);

        // -(void)cancelLoading;
        [Export("cancelLoading")]
        void CancelLoading();
    }

    // @protocol YMAAppOpenAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAAppOpenAdLoaderDelegate
    {
        // @required -(void)appOpenAdLoader:(YMAAppOpenAdLoader * _Nonnull)adLoader didLoad:(YMAAppOpenAd * _Nonnull)appOpenAd;
        [Abstract]
        [Export("appOpenAdLoader:didLoad:")]
        void DidLoad(YMAAppOpenAdLoader adLoader, YMAAppOpenAd appOpenAd);

        // @required -(void)appOpenAdLoader:(YMAAppOpenAdLoader * _Nonnull)adLoader didFailToLoadWithError:(YMAAdRequestError * _Nonnull)error;
        [Abstract]
        [Export("appOpenAdLoader:didFailToLoadWithError:")]
        void DidFailToLoadWithError(YMAAppOpenAdLoader adLoader, YMAAdRequestError error);
    }

    // @interface YMAAudioSessionManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAAudioSessionManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAAudioSessionManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAAudioSessionManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL isAutomaticallyManaged;
        [Export("isAutomaticallyManaged")]
        bool IsAutomaticallyManaged { get; set; }
    }

    // @protocol YMAAudioSessionManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAAudioSessionManagerDelegate
    {
        // @required -(void)audioSessionManagerWillPlayAudio:(YMAAudioSessionManager * _Nonnull)audioSessionManager;
        [Abstract]
        [Export("audioSessionManagerWillPlayAudio:")]
        void AudioSessionManagerWillPlayAudio(YMAAudioSessionManager audioSessionManager);

        // @required -(void)audioSessionManagerDidStopPlayingAudio:(YMAAudioSessionManager * _Nonnull)audioSessionManager;
        [Abstract]
        [Export("audioSessionManagerDidStopPlayingAudio:")]
        void AudioSessionManagerDidStopPlayingAudio(YMAAudioSessionManager audioSessionManager);
    }

    // @interface YMABannerAdSize : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMABannerAdSize
    {
        // @property (readonly, nonatomic) CGSize size;
        [Export("size")]
        CGSize Size { get; }

        // +(YMABannerAdSize * _Nonnull)fixedSizeWithWidth:(CGFloat)width height:(CGFloat)height __attribute__((warn_unused_result("")));
        [Static]
        [Export("fixedSizeWithWidth:height:")]
        YMABannerAdSize FixedSizeWithWidth(nfloat width, nfloat height);

        // +(YMABannerAdSize * _Nonnull)inlineSizeWithWidth:(CGFloat)width maxHeight:(CGFloat)height __attribute__((warn_unused_result("")));
        [Static]
        [Export("inlineSizeWithWidth:maxHeight:")]
        YMABannerAdSize InlineSizeWithWidth(nfloat width, nfloat height);

        // +(YMABannerAdSize * _Nonnull)stickySizeWithContainerWidth:(CGFloat)width __attribute__((warn_unused_result("")));
        [Static]
        [Export("stickySizeWithContainerWidth:")]
        YMABannerAdSize StickySizeWithContainerWidth(nfloat width);
    }

    // @interface YMABidderTokenLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMABidderTokenLoader
    {
        // -(instancetype _Nonnull)initWithMediationNetworkName:(NSString * _Nonnull)mediationNetworkName;
        [Export("initWithMediationNetworkName:")]
        NativeHandle Constructor(string mediationNetworkName);

        // -(void)loadBidderTokenWithRequestConfiguration:(YMABidderTokenRequestConfiguration * _Nonnull)requestConfiguration completionHandler:(void (^ _Nonnull)(NSString * _Nullable))completionHandler;
        [Export("loadBidderTokenWithRequestConfiguration:completionHandler:")]
        void LoadBidderTokenWithRequestConfiguration(YMABidderTokenRequestConfiguration requestConfiguration, Action<NSString> completionHandler);
    }

    // @interface YMABidderTokenRequestConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMABidderTokenRequestConfiguration
    {
        // @property (readonly, nonatomic) enum YMAAdType adType;
        [Export("adType")]
        YMAAdType AdType { get; }

        // @property (readonly, nonatomic, strong) YMAAdTargetInfo * _Nonnull targetInfo;
        [Export("targetInfo", ArgumentSemantic.Strong)]
        YMAAdTargetInfo TargetInfo { get; }

        // @property (nonatomic, strong) SWIFT_DEPRECATED_MSG("Use the factory method banner(size:) instead.") YMABannerAdSize * bannerAdSize __attribute__((deprecated("Use the factory method banner(size:) instead.")));
        [Export("bannerAdSize", ArgumentSemantic.Strong)]
        YMABannerAdSize BannerAdSize { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; set; }

        // +(YMABidderTokenRequestConfiguration * _Nonnull)bannerWithSize:(YMABannerAdSize * _Nonnull)size __attribute__((warn_unused_result("")));
        [Static]
        [Export("bannerWithSize:")]
        YMABidderTokenRequestConfiguration BannerWithSize(YMABannerAdSize size);

        // +(YMABidderTokenRequestConfiguration * _Nonnull)interstitial __attribute__((warn_unused_result("")));
        [Static]
        [Export("interstitial")]
        //[Verify(MethodToProperty)]
        YMABidderTokenRequestConfiguration Interstitial { get; }

        // +(YMABidderTokenRequestConfiguration * _Nonnull)rewarded __attribute__((warn_unused_result("")));
        [Static]
        [Export("rewarded")]
        //[Verify(MethodToProperty)]
        YMABidderTokenRequestConfiguration Rewarded { get; }

        // +(YMABidderTokenRequestConfiguration * _Nonnull)native __attribute__((warn_unused_result("")));
        [Static]
        [Export("native")]
        //[Verify(MethodToProperty)]
        YMABidderTokenRequestConfiguration Native { get; }

        // +(YMABidderTokenRequestConfiguration * _Nonnull)appOpenAd __attribute__((warn_unused_result("")));
        [Static]
        [Export("appOpenAd")]
        //[Verify(MethodToProperty)]
        YMABidderTokenRequestConfiguration AppOpenAd { get; }

        // -(instancetype _Nonnull)initWithAdType:(enum YMAAdType)adType __attribute__((deprecated("Use factory methods instead: banner(size:), interstitial(), rewarded(), native() or appOpenAd().")));
        [Export("initWithAdType:")]
        NativeHandle Constructor(YMAAdType adType);
    }

    // @interface YMAButtonAppearance : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMAButtonAppearance : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nonnull textAppearance;
        [Export("textAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance TextAppearance { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull highlightedTextColor;
        [Export("highlightedTextColor", ArgumentSemantic.Strong)]
        UIColor HighlightedTextColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull normalColor;
        [Export("normalColor", ArgumentSemantic.Strong)]
        UIColor NormalColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull highlightedColor;
        [Export("highlightedColor", ArgumentSemantic.Strong)]
        UIColor HighlightedColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; }

        // @property (readonly, nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat BorderWidth { get; }

        // @property (readonly, nonatomic, strong) YMAMutableButtonAppearance * _Nonnull mutableAppearance;
        [Export("mutableAppearance", ArgumentSemantic.Strong)]
        YMAMutableButtonAppearance MutableAppearance { get; }

        // -(instancetype _Nonnull)initWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth;
        [Export("initWithTextAppearance:normalColor:highlightedColor:borderColor:borderWidth:")]
        NativeHandle Constructor(YMALabelAppearance textAppearance, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        // -(instancetype _Nonnull)initWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance highlightedTextColor:(UIColor * _Nonnull)highlightedTextColor normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth;
        [Export("initWithTextAppearance:highlightedTextColor:normalColor:highlightedColor:borderColor:borderWidth:")]
        NativeHandle Constructor(YMALabelAppearance textAppearance, UIColor highlightedTextColor, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        // +(instancetype _Nonnull)appearanceWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth __attribute__((warn_unused_result("")));
        [Static]
        [Export("appearanceWithTextAppearance:normalColor:highlightedColor:borderColor:borderWidth:")]
        YMAButtonAppearance AppearanceWithTextAppearance(YMALabelAppearance textAppearance, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        // +(instancetype _Nonnull)appearanceWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance highlightedTextColor:(UIColor * _Nonnull)highlightedTextColor normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth __attribute__((warn_unused_result("")));
        [Static]
        [Export("appearanceWithTextAppearance:highlightedTextColor:normalColor:highlightedColor:borderColor:borderWidth:")]
        YMAButtonAppearance AppearanceWithTextAppearance(YMALabelAppearance textAppearance, UIColor highlightedTextColor, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableAppearance` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMACreative : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMACreative
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable creativeID;
        [NullAllowed, Export("creativeID")]
        string CreativeID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable campaignID;
        [NullAllowed, Export("campaignID")]
        string CampaignID { get; }
    }

    // @interface CustomMediaView : UIView
    [BaseType(typeof(UIView), Name = "_TtC15YandexMobileAds15CustomMediaView")]
    interface CustomMediaView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //NativeHandle Constructor(NSCoder coder);
    }

    // @interface YMADeviceType : NSObject
    [BaseType(typeof(NSObject))]
    interface YMADeviceType
    {
        // @property (readonly, nonatomic) NSUInteger rawValue;
        [Export("rawValue")]
        nuint RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSUInteger)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(nuint rawValue);

        // @property (readonly, nonatomic, strong, class) YMADeviceType * _Nonnull none;
        [Static]
        [Export("none", ArgumentSemantic.Strong)]
        YMADeviceType None { get; }

        // @property (readonly, nonatomic, strong, class) YMADeviceType * _Nonnull hardware;
        [Static]
        [Export("hardware", ArgumentSemantic.Strong)]
        YMADeviceType Hardware { get; }

        // @property (readonly, nonatomic, strong, class) YMADeviceType * _Nonnull simulator;
        [Static]
        [Export("simulator", ArgumentSemantic.Strong)]
        YMADeviceType Simulator { get; }
    }

    // @interface YMAImageAppearance : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMAImageAppearance : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic, strong) YMASizeConstraint * _Nonnull widthConstraint;
        [Export("widthConstraint", ArgumentSemantic.Strong)]
        YMASizeConstraint WidthConstraint { get; }

        // @property (readonly, nonatomic, strong) YMAMutableImageAppearance * _Nonnull mutableAppearance;
        [Export("mutableAppearance", ArgumentSemantic.Strong)]
        YMAMutableImageAppearance MutableAppearance { get; }

        // -(instancetype _Nonnull)initWithWidthConstraint:(YMASizeConstraint * _Nonnull)widthConstraint;
        [Export("initWithWidthConstraint:")]
        NativeHandle Constructor(YMASizeConstraint widthConstraint);

        // +(instancetype _Nonnull)appearanceWithWidthConstraint:(YMASizeConstraint * _Nonnull)widthConstraint __attribute__((warn_unused_result("")));
        [Static]
        [Export("appearanceWithWidthConstraint:")]
        YMAImageAppearance AppearanceWithWidthConstraint(YMASizeConstraint widthConstraint);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableAppearance` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @protocol YMAImpressionData <NSCoding, NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMAImpressionData : INSCoding
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull rawData;
        [Abstract]
        [Export("rawData")]
        string RawData { get; }
    }

    // @interface YMAInterstitialAd : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAInterstitialAd
    {
        // @property (readonly, nonatomic, strong) YMAAdInfo * _Nullable adInfo;
        [NullAllowed, Export("adInfo", ArgumentSemantic.Strong)]
        YMAAdInfo AdInfo { get; }

        // @property (readonly, copy, nonatomic) NSArray<YMAAdAttributes *> * _Nonnull adAttributes;
        [Export("adAttributes", ArgumentSemantic.Copy)]
        YMAAdAttributes[] AdAttributes { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAInterstitialAdDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAInterstitialAdDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)showFromViewController:(UIViewController * _Nullable)viewController;
        [Export("showFromViewController:")]
        void ShowFromViewController([NullAllowed] UIViewController viewController);
    }

    // @protocol YMAInterstitialAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAInterstitialAdDelegate
    {
        // @optional -(void)interstitialAd:(YMAInterstitialAd * _Nonnull)interstitialAd didFailToShowWithError:(NSError * _Nonnull)error;
        [Export("interstitialAd:didFailToShowWithError:")]
        void InterstitialAd(YMAInterstitialAd interstitialAd, NSError error);

        // @optional -(void)interstitialAdDidShow:(YMAInterstitialAd * _Nonnull)interstitialAd;
        [Export("interstitialAdDidShow:")]
        void InterstitialAdDidShow(YMAInterstitialAd interstitialAd);

        // @optional -(void)interstitialAdDidDismiss:(YMAInterstitialAd * _Nonnull)interstitialAd;
        [Export("interstitialAdDidDismiss:")]
        void InterstitialAdDidDismiss(YMAInterstitialAd interstitialAd);

        // @optional -(void)interstitialAdDidClick:(YMAInterstitialAd * _Nonnull)interstitialAd;
        [Export("interstitialAdDidClick:")]
        void InterstitialAdDidClick(YMAInterstitialAd interstitialAd);

        // @optional -(void)interstitialAd:(YMAInterstitialAd * _Nonnull)interstitialAd didTrackImpressionWithData:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("interstitialAd:didTrackImpressionWithData:")]
        void InterstitialAd(YMAInterstitialAd interstitialAd, [NullAllowed] YMAImpressionData impressionData);
    }

    // @interface YMAInterstitialAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMAInterstitialAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAInterstitialAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAInterstitialAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdWithRequestConfiguration:(YMAAdRequestConfiguration * _Nonnull)request;
        [Export("loadAdWithRequestConfiguration:")]
        void LoadAdWithRequestConfiguration(YMAAdRequestConfiguration request);

        // -(void)cancelLoading;
        [Export("cancelLoading")]
        void CancelLoading();
    }

    // @protocol YMAInterstitialAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAInterstitialAdLoaderDelegate
    {
        // @required -(void)interstitialAdLoader:(YMAInterstitialAdLoader * _Nonnull)adLoader didLoad:(YMAInterstitialAd * _Nonnull)interstitialAd;
        [Abstract]
        [Export("interstitialAdLoader:didLoad:")]
        void DidLoad(YMAInterstitialAdLoader adLoader, YMAInterstitialAd interstitialAd);

        // @required -(void)interstitialAdLoader:(YMAInterstitialAdLoader * _Nonnull)adLoader didFailToLoadWithError:(YMAAdRequestError * _Nonnull)error;
        [Abstract]
        [Export("interstitialAdLoader:didFailToLoadWithError:")]
        void DidFailToLoadWithError(YMAInterstitialAdLoader adLoader, YMAAdRequestError error);
    }

    // @interface YMALabelAppearance : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMALabelAppearance : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic, strong) UIFont * _Nonnull font;
        [Export("font", ArgumentSemantic.Strong)]
        UIFont Font { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; }

        // @property (readonly, nonatomic, strong) YMAMutableLabelAppearance * _Nonnull mutableAppearance;
        [Export("mutableAppearance", ArgumentSemantic.Strong)]
        YMAMutableLabelAppearance MutableAppearance { get; }

        // -(instancetype _Nonnull)initWithFont:(UIFont * _Nonnull)font textColor:(UIColor * _Nonnull)textColor;
        [Export("initWithFont:textColor:")]
        NativeHandle Constructor(UIFont font, UIColor textColor);

        // +(instancetype _Nonnull)appearanceWithFont:(UIFont * _Nonnull)font textColor:(UIColor * _Nonnull)textColor __attribute__((warn_unused_result("")));
        [Static]
        [Export("appearanceWithFont:textColor:")]
        YMALabelAppearance AppearanceWithFont(UIFont font, UIColor textColor);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableAppearance` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMobileAds : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAMobileAds
    {
        // +(void)enableLogging;
        [Static]
        [Export("enableLogging")]
        void EnableLogging();

        // +(NSString * _Nonnull)sdkVersion __attribute__((warn_unused_result("")));
        [Static]
        [Export("sdkVersion")]
        //[Verify(MethodToProperty)]
        string SdkVersion { get; }

        // +(YMAAudioSessionManager * _Nonnull)audioSessionManager __attribute__((warn_unused_result("")));
        [Static]
        [Export("audioSessionManager")]
        //[Verify(MethodToProperty)]
        YMAAudioSessionManager AudioSessionManager { get; }

        // +(void)setLocationTrackingEnabled:(BOOL)enabled;
        [Static]
        [Export("setLocationTrackingEnabled:")]
        void SetLocationTrackingEnabled(bool enabled);

        // +(void)setAgeRestrictedUser:(BOOL)restricted;
        [Static]
        [Export("setAgeRestrictedUser:")]
        void SetAgeRestrictedUser(bool restricted);

        // +(void)enableVisibilityErrorIndicatorForDeviceType:(YMADeviceType * _Nonnull)deviceType;
        [Static]
        [Export("enableVisibilityErrorIndicatorForDeviceType:")]
        void EnableVisibilityErrorIndicatorForDeviceType(YMADeviceType deviceType);

        // +(void)setUserConsent:(BOOL)consent;
        [Static]
        [Export("setUserConsent:")]
        void SetUserConsent(bool consent);

        // +(void)initializeSDKWithCompletionHandler:(void (^ _Nullable)(void))completionHandler;
        [Static]
        [Export("initializeSDKWithCompletionHandler:")]
        void InitializeSDKWithCompletionHandler([NullAllowed] Action completionHandler);

        // +(void)showDebugPanel;
        [Static]
        [Export("showDebugPanel")]
        void ShowDebugPanel();

        // +(void)setAppAdAnalyticsReportingEnabled:(BOOL)enabled;
        [Static]
        [Export("setAppAdAnalyticsReportingEnabled:")]
        void SetAppAdAnalyticsReportingEnabled(bool enabled);

        // +(void)setAppMetricaEasyIntegrationEnabled:(BOOL)enabled;
        [Static]
        [Export("setAppMetricaEasyIntegrationEnabled:")]
        void SetAppMetricaEasyIntegrationEnabled(bool enabled);

        // @property (readonly, copy, nonatomic, class) NSArray<NSString *> * _Nonnull hooksHeaders;
        [Static]
        [Export("hooksHeaders", ArgumentSemantic.Copy)]
        string[] HooksHeaders { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull hostHeader;
        [Static]
        [Export("hostHeader")]
        string HostHeader { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull schemeHeader;
        [Static]
        [Export("schemeHeader")]
        string SchemeHeader { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull portHeader;
        [Static]
        [Export("portHeader")]
        string PortHeader { get; }

        // @property (readonly, nonatomic, class) NSInteger serverRequestForwardErrorCode;
        [Static]
        [Export("serverRequestForwardErrorCode")]
        nint ServerRequestForwardErrorCode { get; }

        // +(void)setForceMediationTestMode:(BOOL)value;
        [Static]
        [Export("setForceMediationTestMode:")]
        void SetForceMediationTestMode(bool value);

        // +(void)setWebViewShouldDelayLoadCallback:(BOOL)value;
        [Static]
        [Export("setWebViewShouldDelayLoadCallback:")]
        void SetWebViewShouldDelayLoadCallback(bool value);

        [Static]
        [Export("setShowFakeStoreController:")]
        void SetShowFakeStoreController(bool value);

        // +(void)useVerificatorForUITests;
        [Static]
        [Export("useVerificatorForUITests")]
        void UseVerificatorForUITests();

        // +(void)blockAdWithReasonWithBlockReason:(NSString * _Nonnull)blockReason reportReason:(NSString * _Nonnull)reportReason;
        [Static]
        [Export("blockAdWithReasonWithBlockReason:reportReason:")]
        void BlockAdWithReasonWithBlockReason(string blockReason, string reportReason);
    }

    // @interface YMAMutableAdRequest : YMAAdRequest
    [BaseType(typeof(YMAAdRequest))]
    interface YMAMutableAdRequest
    {
        // @property (nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; set; }

        // @property (nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @property (nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme", ArgumentSemantic.Assign)]
        YMAAdTheme AdTheme { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable headerBiddingData;
        [NullAllowed, Export("headerBiddingData")]
        string HeaderBiddingData { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable readyResponse;
        [NullAllowed, Export("readyResponse")]
        string ReadyResponse { get; set; }

        // @property (readonly, nonatomic, strong) YMAAdRequest * _Nonnull request;
        [Export("request", ArgumentSemantic.Strong)]
        YMAAdRequest Request { get; }

        // -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `request` property instead.")));
        [Export("copyWithZone:")]
        unsafe NSObject CopyWithZone([NullAllowed] NSZone? zone);
    }

    // @interface YMAMutableAdRequestConfiguration : YMAAdRequestConfiguration
    [BaseType(typeof(YMAAdRequestConfiguration))]
    interface YMAMutableAdRequestConfiguration
    {
        // @property (nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; set; }

        // @property (nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @property (nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme", ArgumentSemantic.Assign)]
        YMAAdTheme AdTheme { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; set; }

        // @property (readonly, nonatomic, strong) YMAAdRequestConfiguration * _Nonnull request;
        [Export("request", ArgumentSemantic.Strong)]
        YMAAdRequestConfiguration Request { get; }

        // -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID;
        [Export("initWithAdUnitID:")]
        NativeHandle Constructor(string adUnitID);

        // -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `request` property instead.")));
        [Export("copyWithZone:")]
        unsafe NSObject CopyWithZone([NullAllowed] NSZone? zone);
    }

    // @interface YMAMutableButtonAppearance : YMAButtonAppearance
    [BaseType(typeof(YMAButtonAppearance))]
    interface YMAMutableButtonAppearance
    {
        // @property (nonatomic, strong) YMALabelAppearance * _Nonnull textAppearance;
        [Export("textAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance TextAppearance { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull highlightedTextColor;
        [Export("highlightedTextColor", ArgumentSemantic.Strong)]
        UIColor HighlightedTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull normalColor;
        [Export("normalColor", ArgumentSemantic.Strong)]
        UIColor NormalColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull highlightedColor;
        [Export("highlightedColor", ArgumentSemantic.Strong)]
        UIColor HighlightedColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // @property (nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat BorderWidth { get; set; }

        // @property (readonly, nonatomic, strong) YMAButtonAppearance * _Nonnull buttonAppearance;
        [Export("buttonAppearance", ArgumentSemantic.Strong)]
        YMAButtonAppearance ButtonAppearance { get; }

        // -(instancetype _Nonnull)initWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth;
        [Export("initWithTextAppearance:normalColor:highlightedColor:borderColor:borderWidth:")]
        NativeHandle Constructor(YMALabelAppearance textAppearance, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        // -(instancetype _Nonnull)initWithTextAppearance:(YMALabelAppearance * _Nonnull)textAppearance highlightedTextColor:(UIColor * _Nonnull)highlightedTextColor normalColor:(UIColor * _Nonnull)normalColor highlightedColor:(UIColor * _Nonnull)highlightedColor borderColor:(UIColor * _Nonnull)borderColor borderWidth:(CGFloat)borderWidth;
        [Export("initWithTextAppearance:highlightedTextColor:normalColor:highlightedColor:borderColor:borderWidth:")]
        NativeHandle Constructor(YMALabelAppearance textAppearance, UIColor highlightedTextColor, UIColor normalColor, UIColor highlightedColor, UIColor borderColor, nfloat borderWidth);

        // -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `buttonAppearance` property instead.")));
        [Export("copyWithZone:")]
        unsafe NSObject CopyWithZone([NullAllowed] NSZone? zone);
    }

    // @interface YMAMutableImageAppearance : YMAImageAppearance
    [BaseType(typeof(YMAImageAppearance))]
    interface YMAMutableImageAppearance
    {
        // @property (nonatomic, strong) YMASizeConstraint * _Nonnull widthConstraint;
        [Export("widthConstraint", ArgumentSemantic.Strong)]
        YMASizeConstraint WidthConstraint { get; set; }

        // @property (readonly, nonatomic, strong) YMAImageAppearance * _Nonnull imageAppearance;
        [Export("imageAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance ImageAppearance { get; }

        // -(instancetype _Nonnull)initWithWidthConstraint:(YMASizeConstraint * _Nonnull)widthConstraint;
        [Export("initWithWidthConstraint:")]
        NativeHandle Constructor(YMASizeConstraint widthConstraint);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `imageAppearance` property instead.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMutableLabelAppearance : YMALabelAppearance
    [BaseType(typeof(YMALabelAppearance))]
    interface YMAMutableLabelAppearance
    {
        // @property (nonatomic, strong) UIFont * _Nonnull font;
        [Export("font", ArgumentSemantic.Strong)]
        UIFont Font { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nonnull labelAppearance;
        [Export("labelAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance LabelAppearance { get; }

        // -(instancetype _Nonnull)initWithFont:(UIFont * _Nonnull)font textColor:(UIColor * _Nonnull)textColor;
        [Export("initWithFont:textColor:")]
        NativeHandle Constructor(UIFont font, UIColor textColor);

        // -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `labelAppearance` property instead.")));
        [Export("copyWithZone:")]
        unsafe NSObject CopyWithZone([NullAllowed] NSZone? zone);
    }

    // @interface YMANativeAdRequestConfiguration : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMANativeAdRequestConfiguration : INSCopying, INSMutableCopying
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull adUnitID;
        [Export("adUnitID")]
        string AdUnitID { get; }

        // @property (readonly, nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; }

        // @property (readonly, nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme")]
        YMAAdTheme AdTheme { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable readyResponse;
        [NullAllowed, Export("readyResponse")]
        string ReadyResponse { get; }

        // @property (readonly, nonatomic) BOOL shouldLoadImagesAutomatically;
        [Export("shouldLoadImagesAutomatically")]
        bool ShouldLoadImagesAutomatically { get; }

        // @property (readonly, nonatomic, strong) YMAMutableNativeAdRequestConfiguration * _Nonnull mutableConfiguration;
        [Export("mutableConfiguration", ArgumentSemantic.Strong)]
        YMAMutableNativeAdRequestConfiguration MutableConfiguration { get; }

        // -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID;
        [Export("initWithAdUnitID:")]
        NativeHandle Constructor(string adUnitID);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableConfiguration` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMutableNativeAdRequestConfiguration : YMANativeAdRequestConfiguration
    [BaseType(typeof(YMANativeAdRequestConfiguration))]
    interface YMAMutableNativeAdRequestConfiguration
    {
        // @property (nonatomic, strong) NSNumber * _Nullable age;
        [NullAllowed, Export("age", ArgumentSemantic.Strong)]
        NSNumber Age { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable contextQuery;
        [NullAllowed, Export("contextQuery")]
        string ContextQuery { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable contextTags;
        [NullAllowed, Export("contextTags", ArgumentSemantic.Copy)]
        string[] ContextTags { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable gender;
        [NullAllowed, Export("gender")]
        string Gender { get; set; }

        // @property (nonatomic, strong) CLLocation * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @property (nonatomic) enum YMAAdTheme adTheme;
        [Export("adTheme", ArgumentSemantic.Assign)]
        YMAAdTheme AdTheme { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable biddingData;
        [NullAllowed, Export("biddingData")]
        string BiddingData { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Parameters { get; set; }

        // @property (nonatomic) BOOL shouldLoadImagesAutomatically;
        [Export("shouldLoadImagesAutomatically")]
        bool ShouldLoadImagesAutomatically { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable readyResponse;
        [NullAllowed, Export("readyResponse")]
        string ReadyResponse { get; set; }

        // @property (readonly, nonatomic, strong) YMANativeAdRequestConfiguration * _Nonnull request;
        [Export("request", ArgumentSemantic.Strong)]
        YMANativeAdRequestConfiguration Request { get; }

        // -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID;
        [Export("initWithAdUnitID:")]
        NativeHandle Constructor(string adUnitID);

        // -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `request` property instead.")));
        [Export("copyWithZone:")]
        unsafe NSObject CopyWithZone([NullAllowed] NSZone? zone);
    }

    // @interface YMANativeTemplateAppearance : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMANativeTemplateAppearance : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat BorderWidth { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; }

        // @property (readonly, nonatomic) YMAHorizontalOffset contentPadding;
        [Export("contentPadding")]
        YMAHorizontalOffset ContentPadding { get; }

        // @property (readonly, nonatomic) YMAHorizontalOffset imageMargins;
        [Export("imageMargins")]
        YMAHorizontalOffset ImageMargins { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable ageAppearance;
        [NullAllowed, Export("ageAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance AgeAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable bodyAppearance;
        [NullAllowed, Export("bodyAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance BodyAppearance { get; }

        // @property (readonly, nonatomic, strong) YMAButtonAppearance * _Nullable callToActionAppearance;
        [NullAllowed, Export("callToActionAppearance", ArgumentSemantic.Strong)]
        YMAButtonAppearance CallToActionAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable domainAppearance;
        [NullAllowed, Export("domainAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance DomainAppearance { get; }

        // @property (readonly, nonatomic, strong) YMAImageAppearance * _Nullable faviconAppearance;
        [NullAllowed, Export("faviconAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance FaviconAppearance { get; }

        // @property (readonly, nonatomic, strong) YMAImageAppearance * _Nullable feedbackAppearance;
        [NullAllowed, Export("feedbackAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance FeedbackAppearance { get; }

        // @property (readonly, nonatomic, strong) YMAImageAppearance * _Nullable imageAppearance;
        [NullAllowed, Export("imageAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance ImageAppearance { get; }

        // @property (readonly, nonatomic, strong) YMARatingAppearance * _Nullable ratingAppearance;
        [NullAllowed, Export("ratingAppearance", ArgumentSemantic.Strong)]
        YMARatingAppearance RatingAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable sponsoredAppearance;
        [NullAllowed, Export("sponsoredAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance SponsoredAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable titleAppearance;
        [NullAllowed, Export("titleAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance TitleAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable reviewCountAppearance;
        [NullAllowed, Export("reviewCountAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance ReviewCountAppearance { get; }

        // @property (readonly, nonatomic, strong) YMALabelAppearance * _Nullable warningAppearance;
        [NullAllowed, Export("warningAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance WarningAppearance { get; }

        // @property (readonly, nonatomic, strong) YMAMutableNativeTemplateAppearance * _Nonnull mutableAppearance;
        [Export("mutableAppearance", ArgumentSemantic.Strong)]
        YMAMutableNativeTemplateAppearance MutableAppearance { get; }

        // @property (readonly, nonatomic, strong, class) YMANativeTemplateAppearance * _Nonnull defaultAppearance;
        [Static]
        [Export("defaultAppearance", ArgumentSemantic.Strong)]
        YMANativeTemplateAppearance DefaultAppearance { get; }

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableAppearance` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMutableNativeTemplateAppearance : YMANativeTemplateAppearance
    [BaseType(typeof(YMANativeTemplateAppearance))]
    interface YMAMutableNativeTemplateAppearance
    {
        // @property (nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat BorderWidth { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic) YMAHorizontalOffset contentPadding;
        [Export("contentPadding", ArgumentSemantic.Assign)]
        YMAHorizontalOffset ContentPadding { get; set; }

        // @property (nonatomic) YMAHorizontalOffset imageMargins;
        [Export("imageMargins", ArgumentSemantic.Assign)]
        YMAHorizontalOffset ImageMargins { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable ageAppearance;
        [NullAllowed, Export("ageAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance AgeAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable bodyAppearance;
        [NullAllowed, Export("bodyAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance BodyAppearance { get; set; }

        // @property (nonatomic, strong) YMAButtonAppearance * _Nullable callToActionAppearance;
        [NullAllowed, Export("callToActionAppearance", ArgumentSemantic.Strong)]
        YMAButtonAppearance CallToActionAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable domainAppearance;
        [NullAllowed, Export("domainAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance DomainAppearance { get; set; }

        // @property (nonatomic, strong) YMAImageAppearance * _Nullable faviconAppearance;
        [NullAllowed, Export("faviconAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance FaviconAppearance { get; set; }

        // @property (nonatomic, strong) YMAImageAppearance * _Nullable feedbackAppearance;
        [NullAllowed, Export("feedbackAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance FeedbackAppearance { get; set; }

        // @property (nonatomic, strong) YMAImageAppearance * _Nullable imageAppearance;
        [NullAllowed, Export("imageAppearance", ArgumentSemantic.Strong)]
        YMAImageAppearance ImageAppearance { get; set; }

        // @property (nonatomic, strong) YMARatingAppearance * _Nullable ratingAppearance;
        [NullAllowed, Export("ratingAppearance", ArgumentSemantic.Strong)]
        YMARatingAppearance RatingAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable sponsoredAppearance;
        [NullAllowed, Export("sponsoredAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance SponsoredAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable titleAppearance;
        [NullAllowed, Export("titleAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance TitleAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable reviewCountAppearance;
        [NullAllowed, Export("reviewCountAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance ReviewCountAppearance { get; set; }

        // @property (nonatomic, strong) YMALabelAppearance * _Nullable warningAppearance;
        [NullAllowed, Export("warningAppearance", ArgumentSemantic.Strong)]
        YMALabelAppearance WarningAppearance { get; set; }

        //// @property (readonly, nonatomic, strong) YMANativeTemplateAppearance * _Nonnull appearance;
        //[Export("appearance", ArgumentSemantic.Strong)]
        //YMANativeTemplateAppearance Appearance { get; }

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `appearance` property instead.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMARatingAppearance : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMARatingAppearance : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic, strong) UIColor * _Nonnull emptyStarColor;
        [Export("emptyStarColor", ArgumentSemantic.Strong)]
        UIColor EmptyStarColor { get; }

        // @property (readonly, nonatomic, strong) UIColor * _Nonnull filledStarColor;
        [Export("filledStarColor", ArgumentSemantic.Strong)]
        UIColor FilledStarColor { get; }

        // @property (readonly, nonatomic) CGFloat preferredStarSize;
        [Export("preferredStarSize")]
        nfloat PreferredStarSize { get; }

        // @property (readonly, nonatomic, strong) YMAMutableRatingAppearance * _Nonnull mutableAppearance;
        [Export("mutableAppearance", ArgumentSemantic.Strong)]
        YMAMutableRatingAppearance MutableAppearance { get; }

        // -(instancetype _Nonnull)initWithEmptyStarColor:(UIColor * _Nonnull)emptyStarColor filledStarColor:(UIColor * _Nonnull)filledStarColor starSize:(CGFloat)starSize;
        [Export("initWithEmptyStarColor:filledStarColor:starSize:")]
        NativeHandle Constructor(UIColor emptyStarColor, UIColor filledStarColor, nfloat starSize);

        // +(instancetype _Nonnull)appearanceWithEmptyStarColor:(UIColor * _Nonnull)emptyStarColor filledStarColor:(UIColor * _Nonnull)filledStarColor starSize:(CGFloat)starSize __attribute__((warn_unused_result("")));
        [Static]
        [Export("appearanceWithEmptyStarColor:filledStarColor:starSize:")]
        YMARatingAppearance AppearanceWithEmptyStarColor(UIColor emptyStarColor, UIColor filledStarColor, nfloat starSize);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableAppearance` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMutableRatingAppearance : YMARatingAppearance
    [BaseType(typeof(YMARatingAppearance))]
    interface YMAMutableRatingAppearance
    {
        // @property (nonatomic, strong) UIColor * _Nonnull emptyStarColor;
        [Export("emptyStarColor", ArgumentSemantic.Strong)]
        UIColor EmptyStarColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull filledStarColor;
        [Export("filledStarColor", ArgumentSemantic.Strong)]
        UIColor FilledStarColor { get; set; }

        // @property (nonatomic) CGFloat preferredStarSize;
        [Export("preferredStarSize")]
        nfloat PreferredStarSize { get; set; }

        // @property (readonly, nonatomic, strong) YMARatingAppearance * _Nonnull ratingAppearance;
        [Export("ratingAppearance", ArgumentSemantic.Strong)]
        YMARatingAppearance RatingAppearance { get; }

        //// -(instancetype _Nonnull)initWithEmptyStarColor:(UIColor * _Nonnull)emptyStarColor filledStarColor:(UIColor * _Nonnull)filledStarColor starSize:(CGFloat)starSize;
        //[Export("initWithEmptyStarColor:filledStarColor:starSize:")]
        //NativeHandle Constructor(UIColor emptyStarColor, UIColor filledStarColor, nfloat starSize);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `ratingAppearance` property instead.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMASizeConstraint : NSObject <NSCopying, NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface YMASizeConstraint : INSCopying, INSMutableCopying
    {
        // @property (readonly, nonatomic) enum YMASizeConstraintType type;
        [Export("type")]
        YMASizeConstraintType Type { get; }

        // @property (readonly, nonatomic) CGFloat value;
        [Export("value")]
        nfloat Value { get; }

        // @property (readonly, nonatomic, strong) YMAMutableSizeConstraint * _Nonnull mutableConstraint;
        [Export("mutableConstraint", ArgumentSemantic.Strong)]
        YMAMutableSizeConstraint MutableConstraint { get; }

        // -(instancetype _Nonnull)initWithType:(enum YMASizeConstraintType)type value:(CGFloat)value;
        [Export("initWithType:value:")]
        NativeHandle Constructor(YMASizeConstraintType type, nfloat value);

        // +(instancetype _Nonnull)constraintWithType:(enum YMASizeConstraintType)type value:(CGFloat)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("constraintWithType:value:")]
        YMASizeConstraint ConstraintWithType(YMASizeConstraintType type, nfloat value);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Will be removed in future versions.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);

        //// -(id _Nonnull)mutableCopyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("mutableCopy(with:) is deprecated. Use `mutableConstraint` property instead.")));
        //[Export("mutableCopyWithZone:")]
        //unsafe NSObject MutableCopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YMAMutableSizeConstraint : YMASizeConstraint
    [BaseType(typeof(YMASizeConstraint))]
    interface YMAMutableSizeConstraint
    {
        // @property (nonatomic) enum YMASizeConstraintType type;
        [Export("type", ArgumentSemantic.Assign)]
        YMASizeConstraintType Type { get; set; }

        // @property (nonatomic) CGFloat value;
        [Export("value")]
        nfloat Value { get; set; }

        // @property (readonly, nonatomic, strong) YMASizeConstraint * _Nonnull constraint;
        [Export("constraint", ArgumentSemantic.Strong)]
        YMASizeConstraint Constraint { get; }

        // -(instancetype _Nonnull)initWithType:(enum YMASizeConstraintType)type value:(CGFloat)value;
        [Export("initWithType:value:")]
        NativeHandle Constructor(YMASizeConstraintType type, nfloat value);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result(""))) __attribute__((deprecated("copy(with:) is deprecated. Use `constraint` property instead.")));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NativeHandle* zone);
    }

    // @interface YandexMobileAds_Swift_1742 (NSError)
    //[Category]
    //[BaseType(typeof(NSError))]
    //interface NSError_YandexMobileAds_Swift_1742
    //{
    //    // @property (readonly, nonatomic) BOOL isYandexMobileAdsError;
    //    [Export("isYandexMobileAdsError")]
    //    bool IsYandexMobileAdsError { get; }

    //    // @property (readonly, nonatomic) BOOL isYandexMobileNativeAdsError;
    //    [Export("isYandexMobileNativeAdsError")]
    //    bool IsYandexMobileNativeAdsError { get; }
    //}

    // @protocol YMANativeAd <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMANativeAd
    {
        // @required @property (readonly, nonatomic) enum YMANativeAdType adType;
        [Abstract]
        [Export("adType")]
        YMANativeAdType AdType { get; }

        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        YMANativeAdDelegate Delegate { get; set; }

        // @required @property (nonatomic, strong) id<YMANativeAdDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Strong)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable info;
        [Abstract]
        [NullAllowed, Export("info")]
        string Info { get; }

        // @required @property (readonly, nonatomic, strong) YMAAdAttributes * _Nullable adAttributes;
        [Abstract]
        [NullAllowed, Export("adAttributes", ArgumentSemantic.Strong)]
        YMAAdAttributes AdAttributes { get; }

        // @required @property (readonly, copy, nonatomic) NSArray<id<YMANativeAd>> * _Nonnull ads;
        [Abstract]
        [Export("ads", ArgumentSemantic.Copy)]
        YMANativeAd[] Ads { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable creativeID;
        [Abstract]
        [NullAllowed, Export("creativeID")]
        string CreativeID { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable campaignID;
        [Abstract]
        [NullAllowed, Export("campaignID")]
        string CampaignID { get; }

        // @required -(YMANativeAdAssets * _Nonnull)adAssets __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("adAssets")]
        //[Verify(MethodToProperty)]
        YMANativeAdAssets AdAssets { get; }

        // @required -(void)loadImages;
        [Abstract]
        [Export("loadImages")]
        void LoadImages();

        // @required -(void)addImageLoadingObserver:(id<YMANativeAdImageLoadingObserver> _Nonnull)observer;
        [Abstract]
        [Export("addImageLoadingObserver:")]
        void AddImageLoadingObserver(YMANativeAdImageLoadingObserver observer);

        // @required -(void)removeImageLoadingObserver:(id<YMANativeAdImageLoadingObserver> _Nonnull)observer;
        [Abstract]
        [Export("removeImageLoadingObserver:")]
        void RemoveImageLoadingObserver(YMANativeAdImageLoadingObserver observer);

        // @required -(BOOL)bindWithAdView:(YMANativeAdView * _Nonnull)adView error:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export("bindWithAdView:error:")]
        bool BindWithAdView(YMANativeAdView adView, [NullAllowed] out NSError error);

        // @required -(BOOL)bindAdToView:(UIView * _Nonnull)view viewData:(YMANativeAdViewData * _Nonnull)viewData error:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export("bindAdToView:viewData:error:")]
        bool BindAdToView(UIView view, YMANativeAdViewData viewData, [NullAllowed] out NSError error);

        // @required -(BOOL)bindAdToSliderView:(YMANativeAdView * _Nonnull)sliderView error:(NSError * _Nullable * _Nullable)error __attribute__((deprecated("`bindAd(toSliderView:)` will be removed in future versions. Use `SliderAd.bind(with:)` instead.")));
        [Abstract]
        [Export("bindAdToSliderView:error:")]
        bool BindAdToSliderView(YMANativeAdView sliderView, [NullAllowed] out NSError error);
    }

    // @interface YMANativeAdAssets : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeAdAssets
    {
        // @property (copy, nonatomic) NSString * _Nullable age;
        [NullAllowed, Export("age")]
        string Age { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable body;
        [NullAllowed, Export("body")]
        string Body { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable callToAction;
        [NullAllowed, Export("callToAction")]
        string CallToAction { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable domain;
        [NullAllowed, Export("domain")]
        string Domain { get; set; }

        // @property (nonatomic, strong) YMANativeAdImage * _Nullable favicon;
        [NullAllowed, Export("favicon", ArgumentSemantic.Strong)]
        YMANativeAdImage Favicon { get; set; }

        // @property (nonatomic) BOOL feedbackAvailable;
        [Export("feedbackAvailable")]
        bool FeedbackAvailable { get; set; }

        // @property (nonatomic, strong) YMANativeAdImage * _Nullable icon;
        [NullAllowed, Export("icon", ArgumentSemantic.Strong)]
        YMANativeAdImage Icon { get; set; }

        // @property (nonatomic, strong) YMANativeAdImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        YMANativeAdImage Image { get; set; }

        // @property (nonatomic, strong) YMANativeAdMedia * _Nullable media;
        [NullAllowed, Export("media", ArgumentSemantic.Strong)]
        YMANativeAdMedia Media { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable price;
        [NullAllowed, Export("price")]
        string Price { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable rating;
        [NullAllowed, Export("rating", ArgumentSemantic.Strong)]
        NSNumber Rating { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable reviewCount;
        [NullAllowed, Export("reviewCount")]
        string ReviewCount { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sponsored;
        [NullAllowed, Export("sponsored")]
        string Sponsored { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable title;
        [NullAllowed, Export("title")]
        string Title { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable warning;
        [NullAllowed, Export("warning")]
        string Warning { get; set; }
    }

    // @protocol YMANativeAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMANativeAdDelegate
    {
        // @optional -(UIViewController * _Nullable)viewControllerForPresentingModalView __attribute__((warn_unused_result(""))) __attribute__((deprecated("`viewControllerForPresentingModalView` will be removed in future versions.")));
        [NullAllowed, Export("viewControllerForPresentingModalView")]
        //[Verify(MethodToProperty)]
        UIViewController ViewControllerForPresentingModalView { get; }

        // @optional -(void)nativeAdDidClick:(id<YMANativeAd> _Nonnull)ad;
        [Export("nativeAdDidClick:")]
        void NativeAdDidClick(YMANativeAd ad);

        // @optional -(void)nativeAdWillLeaveApplication:(id<YMANativeAd> _Nonnull)ad;
        [Export("nativeAdWillLeaveApplication:")]
        void NativeAdWillLeaveApplication(YMANativeAd ad);

        // @optional -(void)nativeAd:(id<YMANativeAd> _Nonnull)ad willPresentScreen:(UIViewController * _Nullable)viewController;
        [Export("nativeAd:willPresentScreen:")]
        void NativeAd_willPresentScreen(YMANativeAd ad, [NullAllowed] UIViewController viewController);

        // @optional -(void)nativeAd:(id<YMANativeAd> _Nonnull)ad didDismissScreen:(UIViewController * _Nullable)viewController;
        [Export("nativeAd:didDismissScreen:")]
        void NativeAd_didDismissScreen(YMANativeAd ad, [NullAllowed] UIViewController viewController);

        // @optional -(void)nativeAd:(id<YMANativeAd> _Nonnull)ad didTrackImpressionWithData:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("nativeAd:didTrackImpressionWithData:")]
        void NativeAd(YMANativeAd ad, [NullAllowed] YMAImpressionData impressionData);

        // @optional -(void)closeNativeAd:(id<YMANativeAd> _Nonnull)ad;
        [Export("closeNativeAd:")]
        void CloseNativeAd(YMANativeAd ad);
    }

    // @interface YMANativeAdImage : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeAdImage
    {
        // @property (readonly, nonatomic) CGSize size;
        [Export("size")]
        CGSize Size { get; }

        // @property (readonly, nonatomic, strong) UIImage * _Nullable imageValue;
        [NullAllowed, Export("imageValue", ArgumentSemantic.Strong)]
        UIImage ImageValue { get; }
    }

    // @protocol YMANativeAdImageLoadingObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMANativeAdImageLoadingObserver
    {
        // @required -(void)nativeAdDidFinishLoadingImages:(id<YMANativeAd> _Nonnull)ad;
        [Abstract]
        [Export("nativeAdDidFinishLoadingImages:")]
        void NativeAdDidFinishLoadingImages(YMANativeAd ad);
    }

    // @interface YMANativeAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMANativeAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMANativeAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdWithRequestConfiguration:(YMANativeAdRequestConfiguration * _Nonnull)requestConfiguration;
        [Export("loadAdWithRequestConfiguration:")]
        void LoadAdWithRequestConfiguration(YMANativeAdRequestConfiguration requestConfiguration);
    }

    // @protocol YMANativeAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMANativeAdLoaderDelegate
    {
        // @required -(void)nativeAdLoader:(YMANativeAdLoader * _Nonnull)loader didLoadAd:(id<YMANativeAd> _Nonnull)ad;
        [Abstract]
        [Export("nativeAdLoader:didLoadAd:")]
        void DidLoadAd(YMANativeAdLoader loader, YMANativeAd ad);

        // @required -(void)nativeAdLoader:(YMANativeAdLoader * _Nonnull)loader didFailLoadingWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("nativeAdLoader:didFailLoadingWithError:")]
        void DidFailLoadingWithError(YMANativeAdLoader loader, NSError error);
    }

    // @interface YMANativeAdMedia : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMANativeAdMedia
    {
        // @property (readonly, nonatomic) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; }
    }

    // @interface YMANativeAdVideoController : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeAdVideoController
    {
        // -(void)pause;
        [Export("pause")]
        void Pause();

        // -(void)resume;
        [Export("resume")]
        void Resume();
    }

    // @protocol YMANativeAdVideoControllerProvider <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMANativeAdVideoControllerProvider
    {
        // @required @property (readonly, nonatomic, strong) YMANativeAdVideoController * _Nullable videoController;
        [Abstract]
        [NullAllowed, Export("videoController", ArgumentSemantic.Strong)]
        YMANativeAdVideoController VideoController { get; }
    }

    // @interface YMANativeAdViewData : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeAdViewData
    {
        // @property (nonatomic, strong) UILabel * _Nullable ageLabel;
        [NullAllowed, Export("ageLabel", ArgumentSemantic.Strong)]
        UILabel AgeLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable bodyLabel;
        [NullAllowed, Export("bodyLabel", ArgumentSemantic.Strong)]
        UILabel BodyLabel { get; set; }

        // @property (nonatomic, strong) UIButton * _Nullable callToActionButton;
        [NullAllowed, Export("callToActionButton", ArgumentSemantic.Strong)]
        UIButton CallToActionButton { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable domainLabel;
        [NullAllowed, Export("domainLabel", ArgumentSemantic.Strong)]
        UILabel DomainLabel { get; set; }

        // @property (nonatomic, strong) UIImageView * _Nullable faviconImageView;
        [NullAllowed, Export("faviconImageView", ArgumentSemantic.Strong)]
        UIImageView FaviconImageView { get; set; }

        // @property (nonatomic, strong) UIButton * _Nullable feedbackButton;
        [NullAllowed, Export("feedbackButton", ArgumentSemantic.Strong)]
        UIButton FeedbackButton { get; set; }

        // @property (nonatomic, strong) UIImageView * _Nullable iconImageView;
        [NullAllowed, Export("iconImageView", ArgumentSemantic.Strong)]
        UIImageView IconImageView { get; set; }

        // @property (nonatomic, strong) YMANativeMediaView * _Nullable mediaView;
        [NullAllowed, Export("mediaView", ArgumentSemantic.Strong)]
        YMANativeMediaView MediaView { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable priceLabel;
        [NullAllowed, Export("priceLabel", ArgumentSemantic.Strong)]
        UILabel PriceLabel { get; set; }

        // @property (nonatomic, strong) UIView<YMARating> * _Nullable ratingView;
        [NullAllowed, Export("ratingView", ArgumentSemantic.Strong)]
        YMARating RatingView { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable reviewCountLabel;
        [NullAllowed, Export("reviewCountLabel", ArgumentSemantic.Strong)]
        UILabel ReviewCountLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable sponsoredLabel;
        [NullAllowed, Export("sponsoredLabel", ArgumentSemantic.Strong)]
        UILabel SponsoredLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable titleLabel;
        [NullAllowed, Export("titleLabel", ArgumentSemantic.Strong)]
        UILabel TitleLabel { get; set; }

        // @property (nonatomic, strong) UILabel * _Nullable warningLabel;
        [NullAllowed, Export("warningLabel", ArgumentSemantic.Strong)]
        UILabel WarningLabel { get; set; }
    }

    // @interface YMANativeBannerView : UIView
    [BaseType(typeof(UIView))]
    interface YMANativeBannerView
    {
        // @property (nonatomic, strong) id<YMANativeAd> _Nullable ad;
        [NullAllowed, Export("ad", ArgumentSemantic.Strong)]
        YMANativeAd Ad { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //NativeHandle Constructor(NSCoder coder);

        // -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder coder);

        // -(void)applyAppearance:(YMANativeTemplateAppearance * _Nonnull)appearance;
        [Export("applyAppearance:")]
        void ApplyAppearance(YMANativeTemplateAppearance appearance);

        // +(CGFloat)heightWithAd:(id<YMANativeAd> _Nonnull)ad width:(CGFloat)width appearance:(YMANativeTemplateAppearance * _Nullable)appearance __attribute__((warn_unused_result("")));
        [Static]
        [Export("heightWithAd:width:appearance:")]
        nfloat HeightWithAd(YMANativeAd ad, nfloat width, [NullAllowed] YMANativeTemplateAppearance appearance);
    }

    // @interface YMANativeBulkAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMANativeBulkAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMANativeBulkAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMANativeBulkAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdsWithRequestConfiguration:(YMANativeAdRequestConfiguration * _Nonnull)requestConfiguration adsCount:(NSInteger)adsCount;
        [Export("loadAdsWithRequestConfiguration:adsCount:")]
        void LoadAdsWithRequestConfiguration(YMANativeAdRequestConfiguration requestConfiguration, nint adsCount);
    }

    // @protocol YMANativeBulkAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMANativeBulkAdLoaderDelegate
    {
        // @required -(void)nativeBulkAdLoader:(YMANativeBulkAdLoader * _Nonnull)nativeBulkAdLoader didLoadAds:(NSArray<id<YMANativeAd>> * _Nonnull)ads;
        [Abstract]
        [Export("nativeBulkAdLoader:didLoadAds:")]
        void DidLoadAds(YMANativeBulkAdLoader nativeBulkAdLoader, YMANativeAd[] ads);

        // @required -(void)nativeBulkAdLoader:(YMANativeBulkAdLoader * _Nonnull)nativeBulkAdLoader didFailLoadingWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("nativeBulkAdLoader:didFailLoadingWithError:")]
        void DidFailLoadingWithError(YMANativeBulkAdLoader nativeBulkAdLoader, NSError error);
    }

    // @interface NativePromoBannerView : UIView
    [BaseType(typeof(UIView), Name = "_TtC15YandexMobileAds21NativePromoBannerView")]
    interface NativePromoBannerView
    {
    }

    // @interface YMANativeVideoPlaybackControls : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMANativeVideoPlaybackControls
    {
        // -(instancetype _Nonnull)initWithProgressControl:(UIView<YMANativeVideoPlaybackProgressControl> * _Nullable)progressControl muteControl:(UIView<YMANativeVideoPlaybackMuteControl> * _Nullable)muteControl;
        [Export("initWithProgressControl:muteControl:")]
        NativeHandle Constructor([NullAllowed] YMANativeVideoPlaybackProgressControl progressControl, [NullAllowed] YMANativeVideoPlaybackMuteControl muteControl);

        // -(void)setupVideoPlaybackControlsTo:(YMANativeMediaView * _Nonnull)view;
        [Export("setupVideoPlaybackControlsTo:")]
        void SetupVideoPlaybackControlsTo(YMANativeMediaView view);
    }

    // @protocol YMANativeVideoPlaybackMuteControl <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMANativeVideoPlaybackMuteControl
    {
        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        YMANativeVideoPlaybackMuteControlDelegate Delegate { get; set; }

        // @required @property (nonatomic, strong) id<YMANativeVideoPlaybackMuteControlDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Strong)]
        NSObject WeakDelegate { get; set; }

        // @required -(void)configureWithIsMuted:(BOOL)isMuted;
        [Abstract]
        [Export("configureWithIsMuted:")]
        void ConfigureWithIsMuted(bool isMuted);

        // @required -(void)configureWithIsHidden:(BOOL)isHidden;
        [Abstract]
        [Export("configureWithIsHidden:")]
        void ConfigureWithIsHidden(bool isHidden);
    }

    // @protocol YMANativeVideoPlaybackMuteControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMANativeVideoPlaybackMuteControlDelegate
    {
        // @required -(void)muteControl:(id<YMANativeVideoPlaybackMuteControl> _Nonnull)muteControl didChangeIsMuted:(BOOL)isMuted;
        [Abstract]
        [Export("muteControl:didChangeIsMuted:")]
        void DidChangeIsMuted(YMANativeVideoPlaybackMuteControl muteControl, bool isMuted);
    }

    // @protocol YMANativeVideoPlaybackProgressControl <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMANativeVideoPlaybackProgressControl
    {
        // @required -(void)configureWithPosition:(NSTimeInterval)position duration:(NSTimeInterval)duration;
        [Abstract]
        [Export("configureWithPosition:duration:")]
        void ConfigureWithPosition(double position, double duration);

        // @required -(void)reset;
        [Abstract]
        [Export("reset")]
        void Reset();
    }

    // @protocol YMARating <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMARating
    {
        // @required -(NSNumber * _Nullable)rating __attribute__((warn_unused_result("")));
        // @required -(void)setRating:(NSNumber * _Nullable)rating;
        [Abstract]
        [NullAllowed, Export("rating")]
        //[Verify(MethodToProperty)]
        NSNumber Rating { get; set; }
    }

    // @interface RetailMediaAdView : UIView
    [BaseType(typeof(UIView), Name = "_TtC15YandexMobileAds17RetailMediaAdView")]
    interface RetailMediaAdView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //NativeHandle Constructor(NSCoder coder);

        //// -(void)observeValueForKeyPath:(NSString * _Nullable)keyPath ofObject:(id _Nullable)object change:(NSDictionary<NSKeyValueChangeKey,id> * _Nullable)change context:(void * _Nullable)context;
        //[Export("observeValueForKeyPath:ofObject:change:context:")]
        //unsafe void ObserveValueForKeyPath([NullAllowed] string keyPath, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> change, [NullAllowed] NativeHandle* context);
    }

    // @protocol YMAReward <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface YMAReward
    {
        // @required @property (readonly, nonatomic) NSInteger amount;
        [Abstract]
        [Export("amount")]
        nint Amount { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Abstract]
        [Export("type")]
        string Type { get; }
    }

    // @interface YMARewardedAd : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMARewardedAd
    {
        // @property (readonly, nonatomic, strong) YMAAdInfo * _Nullable adInfo;
        [NullAllowed, Export("adInfo", ArgumentSemantic.Strong)]
        YMAAdInfo AdInfo { get; }

        // @property (readonly, copy, nonatomic) NSArray<YMAAdAttributes *> * _Nonnull adAttributes;
        [Export("adAttributes", ArgumentSemantic.Copy)]
        YMAAdAttributes[] AdAttributes { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMARewardedAdDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMARewardedAdDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)showFromViewController:(UIViewController * _Nullable)viewController;
        [Export("showFromViewController:")]
        void ShowFromViewController([NullAllowed] UIViewController viewController);
    }

    // @protocol YMARewardedAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMARewardedAdDelegate
    {
        // @required -(void)rewardedAd:(YMARewardedAd * _Nonnull)rewardedAd didReward:(id<YMAReward> _Nonnull)reward;
        [Abstract]
        [Export("rewardedAd:didReward:")]
        void RewardedAd(YMARewardedAd rewardedAd, YMAReward reward);

        // @optional -(void)rewardedAd:(YMARewardedAd * _Nonnull)rewardedAd didFailToShowWithError:(NSError * _Nonnull)error;
        [Export("rewardedAd:didFailToShowWithError:")]
        void RewardedAd(YMARewardedAd rewardedAd, NSError error);

        // @optional -(void)rewardedAdDidShow:(YMARewardedAd * _Nonnull)rewardedAd;
        [Export("rewardedAdDidShow:")]
        void RewardedAdDidShow(YMARewardedAd rewardedAd);

        // @optional -(void)rewardedAdDidDismiss:(YMARewardedAd * _Nonnull)rewardedAd;
        [Export("rewardedAdDidDismiss:")]
        void RewardedAdDidDismiss(YMARewardedAd rewardedAd);

        // @optional -(void)rewardedAdDidClick:(YMARewardedAd * _Nonnull)rewardedAd;
        [Export("rewardedAdDidClick:")]
        void RewardedAdDidClick(YMARewardedAd rewardedAd);

        // @optional -(void)rewardedAd:(YMARewardedAd * _Nonnull)rewardedAd didTrackImpressionWith:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("rewardedAd:didTrackImpressionWith:")]
        void RewardedAd(YMARewardedAd rewardedAd, [NullAllowed] YMAImpressionData impressionData);
    }

    // @interface YMARewardedAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMARewardedAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMARewardedAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMARewardedAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdWithRequestConfiguration:(YMAAdRequestConfiguration * _Nonnull)request;
        [Export("loadAdWithRequestConfiguration:")]
        void LoadAdWithRequestConfiguration(YMAAdRequestConfiguration request);

        // -(void)cancelLoading;
        [Export("cancelLoading")]
        void CancelLoading();
    }

    // @protocol YMARewardedAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMARewardedAdLoaderDelegate
    {
        // @required -(void)rewardedAdLoader:(YMARewardedAdLoader * _Nonnull)adLoader didLoad:(YMARewardedAd * _Nonnull)rewardedAd;
        [Abstract]
        [Export("rewardedAdLoader:didLoad:")]
        void DidLoad(YMARewardedAdLoader adLoader, YMARewardedAd rewardedAd);

        // @required -(void)rewardedAdLoader:(YMARewardedAdLoader * _Nonnull)adLoader didFailToLoadWithError:(YMAAdRequestError * _Nonnull)error;
        [Abstract]
        [Export("rewardedAdLoader:didFailToLoadWithError:")]
        void DidFailToLoadWithError(YMARewardedAdLoader adLoader, YMAAdRequestError error);
    }

    // @protocol YMASliderAd
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMASliderAd
    {
        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        YMASliderAdDelegate Delegate { get; set; }

        // @required @property (nonatomic, strong) id<YMASliderAdDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Strong)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable info;
        [Abstract]
        [NullAllowed, Export("info")]
        string Info { get; }

        // @required @property (readonly, nonatomic, strong) YMAAdAttributes * _Nullable adAttributes;
        [Abstract]
        [NullAllowed, Export("adAttributes", ArgumentSemantic.Strong)]
        YMAAdAttributes AdAttributes { get; }

        // @required @property (readonly, copy, nonatomic) NSArray<id<YMANativeAd>> * _Nonnull ads;
        [Abstract]
        [Export("ads", ArgumentSemantic.Copy)]
        YMANativeAd[] Ads { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable creativeID;
        [Abstract]
        [NullAllowed, Export("creativeID")]
        string CreativeID { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable campaignID;
        [Abstract]
        [NullAllowed, Export("campaignID")]
        string CampaignID { get; }

        // @required -(void)loadImages;
        [Abstract]
        [Export("loadImages")]
        void LoadImages();

        // @required -(BOOL)bindWithAdView:(YMANativeAdView * _Nonnull)adView error:(NSError * _Nullable * _Nullable)error;
        [Abstract]
        [Export("bindWithAdView:error:")]
        bool BindWithAdView(YMANativeAdView adView, [NullAllowed] out NSError error);
    }

    // @protocol YMASliderAdDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMASliderAdDelegate
    {
        // @optional -(void)sliderAdDidClick:(id<YMASliderAd> _Nonnull)ad;
        [Export("sliderAdDidClick:")]
        void SliderAdDidClick(YMASliderAd ad);

        // @optional -(void)sliderAdWillLeaveApplication:(id<YMASliderAd> _Nonnull)ad;
        [Export("sliderAdWillLeaveApplication:")]
        void SliderAdWillLeaveApplication(YMASliderAd ad);

        // @optional -(void)sliderAd:(id<YMASliderAd> _Nonnull)ad willPresentScreen:(UIViewController * _Nullable)viewController;
        [Export("sliderAd:willPresentScreen:")]
        void SliderAd_willPresentScreen(YMASliderAd ad, [NullAllowed] UIViewController viewController);

        // @optional -(void)sliderAd:(id<YMASliderAd> _Nonnull)ad didDismissScreen:(UIViewController * _Nullable)viewController;
        [Export("sliderAd:didDismissScreen:")]
        void SliderAd_didDismissScreen(YMASliderAd ad, [NullAllowed] UIViewController viewController);

        // @optional -(void)sliderAd:(id<YMASliderAd> _Nonnull)ad didTrackImpressionWithData:(id<YMAImpressionData> _Nullable)impressionData;
        [Export("sliderAd:didTrackImpressionWithData:")]
        void SliderAd(YMASliderAd ad, [NullAllowed] YMAImpressionData impressionData);

        // @optional -(void)sliderAdDidClose:(id<YMASliderAd> _Nonnull)ad;
        [Export("sliderAdDidClose:")]
        void SliderAdDidClose(YMASliderAd ad);
    }

    // @interface YMASliderAdLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface YMASliderAdLoader
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMASliderAdLoaderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMASliderAdLoaderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)loadAdWithRequestConfiguration:(YMANativeAdRequestConfiguration * _Nonnull)requestConfiguration;
        [Export("loadAdWithRequestConfiguration:")]
        void LoadAdWithRequestConfiguration(YMANativeAdRequestConfiguration requestConfiguration);
    }

    // @protocol YMASliderAdLoaderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMASliderAdLoaderDelegate
    {
        // @required -(void)sliderAdLoader:(YMASliderAdLoader * _Nonnull)loader didLoadAd:(id<YMASliderAd> _Nonnull)ad;
        [Abstract]
        [Export("sliderAdLoader:didLoadAd:")]
        void DidLoadAd(YMASliderAdLoader loader, YMASliderAd ad);

        // @required -(void)sliderAdLoader:(YMASliderAdLoader * _Nonnull)loader didFailLoadingWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("sliderAdLoader:didFailLoadingWithError:")]
        void DidFailLoadingWithError(YMASliderAdLoader loader, NSError error);
    }

    // @interface YMAVersion : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface YMAVersion
    {
        // @property (readonly, nonatomic, strong, class) YMAVersion * _Nonnull currentVersion;
        [Static]
        [Export("currentVersion", ArgumentSemantic.Strong)]
        YMAVersion CurrentVersion { get; }

        // @property (readonly, nonatomic) NSInteger major;
        [Export("major")]
        nint Major { get; }

        // @property (readonly, nonatomic) NSInteger minor;
        [Export("minor")]
        nint Minor { get; }

        // @property (readonly, nonatomic) NSInteger patch;
        [Export("patch")]
        nint Patch { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull prereleaseIdentifiers;
        [Export("prereleaseIdentifiers", ArgumentSemantic.Copy)]
        string[] PrereleaseIdentifiers { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull buildMetadataIdentifiers;
        [Export("buildMetadataIdentifiers", ArgumentSemantic.Copy)]
        string[] BuildMetadataIdentifiers { get; }
    }

    // @interface YMAVideoController : NSObject
    [BaseType(typeof(NSObject))]
    interface YMAVideoController
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        YMAVideoDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMAVideoDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol YMAVideoDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMAVideoDelegate
    {
        // @optional -(void)videoControllerDidFinishPlayingVideo:(YMAVideoController * _Nonnull)videoController;
        [Export("videoControllerDidFinishPlayingVideo:")]
        void VideoControllerDidFinishPlayingVideo(YMAVideoController videoController);
    }
}
