// Objective-C–visible facade over Yandex Mobile Ads SDK 8 for .NET binding.
// Only types .NET already understands cross this boundary:
// NSObject, UIView, UIViewController, NSString, NSError, CGFloat/CGSize, blocks.
//
// All SDK calls must happen on the main thread (SDK 8 is MainActor-isolated),
// so every class here is @MainActor. Call them from the UI thread in C#.

import UIKit
import YandexMobileAds

// MARK: - SDK-level settings

@objc(YABAds)
@MainActor
public final class YABAds: NSObject {

    /// Manual SDK initialization (recommended: call from FinishedLaunching).
    @objc(startWithCompletion:)
    public static func start(completion: (() -> Void)?) {
        Task { @MainActor in
            await YandexAds.initializeSDK()
            completion?()
        }
    }

    @objc(enableLogging)
    public static func enableLogging() {
        YandexAds.enableLogging()
    }

    @objc(setUserConsent:)
    public static func setUserConsent(_ consent: Bool) {
        YandexAds.setUserConsent(consent)
    }

    @objc(setAgeRestricted:)
    public static func setAgeRestricted(_ restricted: Bool) {
        YandexAds.setAgeRestricted(restricted)
    }

    @objc(setLocationTracking:)
    public static func setLocationTracking(_ enabled: Bool) {
        YandexAds.setLocationTracking(enabled)
    }

    @objc(sdkVersion)
    public static var sdkVersion: String {
        YandexAds.sdkVersion.stringValue
    }
}

// MARK: - Banner (adaptive sticky / adaptive inline)

@objc(YABBannerAd)
@MainActor
public final class YABBannerAd: NSObject, BannerAdViewDelegate {

    private let banner: BannerAdView
    private let width: CGFloat

    /// The native banner view. Add it to your container (Auto Layout).
    @objc public var view: UIView { banner }

    @objc public var onLoaded: (() -> Void)?
    @objc public var onFailedToLoad: ((NSError) -> Void)?
    @objc public var onClicked: (() -> Void)?
    @objc public var onImpression: (() -> Void)?

    private init(size: BannerAdSize, width: CGFloat) {
        self.banner = BannerAdView(adSize: size)
        self.width = width
        super.init()
        banner.delegate = self
        banner.translatesAutoresizingMaskIntoConstraints = false
    }

    /// Adaptive sticky banner (height ≤ 15% of screen, ≥ 50pt).
    @objc(stickyWithContainerWidth:)
    public static func sticky(containerWidth: CGFloat) -> YABBannerAd {
        YABBannerAd(size: .sticky(containerWidth: containerWidth), width: containerWidth)
    }

    /// Adaptive inline banner for feeds / scrollable content.
    @objc(inlineWithWidth:maxHeight:)
    public static func inline(width: CGFloat, maxHeight: CGFloat) -> YABBannerAd {
        YABBannerAd(size: .inline(width: width, maxHeight: maxHeight), width: width)
    }

    @objc(loadWithAdUnitId:)
    public func load(adUnitId: String) {
        banner.loadAd(with: AdRequest(adUnitID: adUnitId))
    }

    /// Size the banner wants after it has loaded (use it to size the host view).
    @objc public var contentSize: CGSize {
        banner.systemLayoutSizeFitting(
            CGSize(width: width, height: UIView.layoutFittingCompressedSize.height),
            withHorizontalFittingPriority: .required,
            verticalFittingPriority: .fittingSizeLevel)
    }

    @objc(destroy)
    public func destroy() {
        banner.delegate = nil
        banner.removeFromSuperview()
    }

    // BannerAdViewDelegate
    public func bannerAdViewDidLoad(_ bannerAdView: BannerAdView) { onLoaded?() }
    public func bannerAdViewDidFailLoading(_ bannerAdView: BannerAdView, error: Error) {
        onFailedToLoad?(error as NSError)
    }
    public func bannerAdViewDidClick(_ bannerAdView: BannerAdView) { onClicked?() }
    public func bannerAdView(_ bannerAdView: BannerAdView, didTrackImpression impressionData: ImpressionData?) {
        onImpression?()
    }
}

// MARK: - Interstitial

@objc(YABInterstitialAd)
@MainActor
public final class YABInterstitialAd: NSObject, InterstitialAdDelegate {

    private let loader = InterstitialAdLoader()
    private var ad: InterstitialAd?

    @objc public var onShown: (() -> Void)?
    @objc public var onDismissed: (() -> Void)?
    @objc public var onClicked: (() -> Void)?
    @objc public var onImpression: (() -> Void)?
    @objc public var onFailedToShow: ((NSError) -> Void)?

    @objc public override init() { super.init() }

    @objc public var isLoaded: Bool { ad != nil }

    /// completion(nil) on success, completion(error) on failure.
    @objc(loadWithAdUnitId:completion:)
    public func load(adUnitId: String, completion: @escaping (NSError?) -> Void) {
        loader.loadAd(with: AdRequest(adUnitID: adUnitId)) { [weak self] result in
            switch result {
            case .success(let ad):
                self?.ad = ad
                ad.delegate = self
                completion(nil)
            case .failure(let error):
                completion(error as NSError)
            }
        }
    }

    @objc(showFromViewController:)
    public func show(from viewController: UIViewController) {
        ad?.show(from: viewController)
    }

    // InterstitialAdDelegate (all methods are required in SDK 8)
    public func interstitialAdDidShow(_ interstitialAd: InterstitialAd) { onShown?() }
    public func interstitialAdDidDismiss(_ interstitialAd: InterstitialAd) {
        ad = nil
        onDismissed?()
    }
    public func interstitialAdDidClick(_ interstitialAd: InterstitialAd) { onClicked?() }
    public func interstitialAd(_ interstitialAd: InterstitialAd, didTrackImpression impressionData: ImpressionData?) {
        onImpression?()
    }
    public func interstitialAd(_ interstitialAd: InterstitialAd, didFailToShow error: Error) {
        ad = nil
        onFailedToShow?(error as NSError)
    }
}

// MARK: - Rewarded

@objc(YABRewardedAd)
@MainActor
public final class YABRewardedAd: NSObject, RewardedAdDelegate {

    private let loader = RewardedAdLoader()
    private var ad: RewardedAd?

    @objc public var onShown: (() -> Void)?
    @objc public var onDismissed: (() -> Void)?
    @objc public var onClicked: (() -> Void)?
    @objc public var onImpression: (() -> Void)?
    @objc public var onFailedToShow: ((NSError) -> Void)?
    /// (amount, type)
    @objc public var onRewarded: ((Int, String) -> Void)?

    @objc public override init() { super.init() }

    @objc public var isLoaded: Bool { ad != nil }

    @objc(loadWithAdUnitId:completion:)
    public func load(adUnitId: String, completion: @escaping (NSError?) -> Void) {
        loader.loadAd(with: AdRequest(adUnitID: adUnitId)) { [weak self] result in
            switch result {
            case .success(let ad):
                self?.ad = ad
                ad.delegate = self
                completion(nil)
            case .failure(let error):
                completion(error as NSError)
            }
        }
    }

    @objc(showFromViewController:)
    public func show(from viewController: UIViewController) {
        ad?.show(from: viewController)
    }

    // RewardedAdDelegate (all methods are required in SDK 8)
    public func rewardedAd(_ rewardedAd: RewardedAd, didReward reward: Reward) {
        onRewarded?(Int(reward.amount), reward.type)
    }
    public func rewardedAd(_ rewardedAd: RewardedAd, didFailToShow error: Error) {
        ad = nil
        onFailedToShow?(error as NSError)
    }
    public func rewardedAdDidShow(_ rewardedAd: RewardedAd) { onShown?() }
    public func rewardedAdDidDismiss(_ rewardedAd: RewardedAd) {
        ad = nil
        onDismissed?()
    }
    public func rewardedAdDidClick(_ rewardedAd: RewardedAd) { onClicked?() }
    public func rewardedAd(_ rewardedAd: RewardedAd, didTrackImpression impressionData: ImpressionData?) {
        onImpression?()
    }
}
