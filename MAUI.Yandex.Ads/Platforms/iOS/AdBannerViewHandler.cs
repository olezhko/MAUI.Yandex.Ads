using Microsoft.Maui.Handlers;
using MAUI.Yandex.Ads.iOS.Binding;

namespace MAUI.Yandex.Ads;

public partial class AdBannerViewHandler
    : ViewHandler<AdBannerView, YMANativeBannerView>
{
    public static IPropertyMapper<AdBannerView, AdBannerViewHandler> Mapper =
        new PropertyMapper<AdBannerView, AdBannerViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(AdBannerView.AdUnitId)] = MapAdUnitId,
        };

    public AdBannerViewHandler() : base(Mapper) { }

    // ── Create native view ────────────────────────────────────────────────
    protected override YMABannerAdView CreatePlatformView()
    {
        var banner = new YMABannerAdView();
        banner.Delegate = new BannerDelegate(VirtualView);
        return banner;
    }

    protected override void ConnectHandler(YMABannerAdView platformView)
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

    private void LoadAd(YMABannerAdView banner)
    {
        if (string.IsNullOrEmpty(VirtualView.AdUnitId)) return;

        banner.AdUnitID = VirtualView.AdUnitId;
        banner.AdSize = YMABannerAdSize.StickySize((uint)VirtualView.AdWidth);
        banner.LoadAd(new YMAMutableAdRequest());
    }

    // ── Delegate ──────────────────────────────────────────────────────────
    private sealed class BannerDelegate : YMABannerAdViewDelegate
    {
        private readonly AdBannerView _view;
        public BannerDelegate(AdBannerView view) => _view = view;

        public override void BannerAdViewDidLoad(YMABannerAdView banner)
            => _view.RaiseAdLoaded();

        public override void BannerAdView(YMABannerAdView banner,
            YMAAdRequestError error)
            => _view.RaiseAdFailedToLoad(error.Error.LocalizedDescription);
    }
}