using Android.Content;
using Microsoft.Maui.Handlers;
using Com.Yandex.Mobile.Ads.Banner;
using Com.Yandex.Mobile.Ads.Common;

namespace MAUI.Yandex.Ads;

public partial class AdBannerViewHandler
    : ViewHandler<AdBannerView, BannerAdView>
{
    public static IPropertyMapper<AdBannerView, AdBannerViewHandler> Mapper =
        new PropertyMapper<AdBannerView, AdBannerViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(AdBannerView.AdUnitId)] = MapAdUnitId,
        };

    public AdBannerViewHandler() : base(Mapper) { }

    // ── Create native view ────────────────────────────────────────────────
    protected override BannerAdView CreatePlatformView()
    {
        var banner = new BannerAdView(Context);
        banner.SetBannerAdEventListener(new BannerListener(VirtualView));
        return banner;
    }

    protected override void ConnectHandler(BannerAdView platformView)
    {
        base.ConnectHandler(platformView);
        LoadAd(platformView);
    }

    // ── Property mappers ──────────────────────────────────────────────────
    private static void MapAdUnitId(
        AdBannerViewHandler handler, AdBannerView view)
    {
        handler.PlatformView.SetAdUnitId(view.AdUnitId);
        handler.LoadAd(handler.PlatformView);
    }

    private void LoadAd(BannerAdView banner)
    {
        if (string.IsNullOrEmpty(VirtualView.AdUnitId)) return;

        banner.SetAdUnitId(VirtualView.AdUnitId);
        banner.AdSize = BannerAdSize.StickySize(Context, VirtualView.AdWidth);
        banner.LoadAd(new AdRequest.Builder().Build());
    }

    // ── Event listener ────────────────────────────────────────────────────
    private sealed class BannerListener : Java.Lang.Object, IBannerAdEventListener
    {
        private readonly AdBannerView _view;
        public BannerListener(AdBannerView view) => _view = view;

        public void OnAdLoaded() => _view.RaiseAdLoaded();
        public void OnAdFailedToLoad(AdRequestError error)
            => _view.RaiseAdFailedToLoad(error.Description);
        public void OnAdClicked() { }
        public void OnLeftApplication() { }
        public void OnReturnedToApplication() { }
        public void OnImpression(IImpressionData? data) { }
    }
}