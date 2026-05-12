using Foundation;
using MAUI.Yandex.Ads.iOS.Binding;
using Microsoft.Maui.Handlers;

namespace MAUI.Yandex.Ads;

public partial class AdBannerViewHandler
    : ViewHandler<AdBannerView, YMAAdView>
{
    public static IPropertyMapper<AdBannerView, AdBannerViewHandler> Mapper =
        new PropertyMapper<AdBannerView, AdBannerViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(AdBannerView.AdUnitId)] = MapAdUnitId,
        };

    public AdBannerViewHandler() : base(Mapper) { }

    // ── Create native view ────────────────────────────────────────────────
    protected override YMAAdView CreatePlatformView()
    {
        var banner = new YMAAdView(VirtualView.AdUnitId, YMABannerAdSize.StickySizeWithContainerWidth((uint)VirtualView.AdWidth));
        banner.Delegate = new BannerDelegate(VirtualView);
        return banner;
    }

    protected override void ConnectHandler(YMAAdView platformView)
    {
        base.ConnectHandler(platformView);
        LoadAd(platformView);
    }

    // ── Property mappers ──────────────────────────────────────────────────
    private static void MapAdUnitId(
        AdBannerViewHandler handler, AdBannerView view)
    {
        handler.LoadAd(handler.PlatformView);
    }

    private void LoadAd(YMAAdView banner)
    {
        if (string.IsNullOrEmpty(VirtualView.AdUnitId)) return;

        banner.LoadAd();
    }

    // ── Delegate ──────────────────────────────────────────────────────────
    private sealed class BannerDelegate : YMAAdViewDelegate
    {
        private readonly AdBannerView _view;
        public BannerDelegate(AdBannerView view) => _view = view;

        public override void AdViewDidLoad(YMAAdView adView)
            => _view.RaiseAdLoaded();

        public override void AdViewDidFailLoading(YMAAdView adView, NSError error)
            => _view.RaiseAdFailedToLoad(error.LocalizedDescription);
    }
}