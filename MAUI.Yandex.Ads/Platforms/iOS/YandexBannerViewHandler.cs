using Microsoft.Maui.Handlers;
using UIKit;
using YandexAdsBridge;

namespace MAUI.Yandex.Ads.Platforms.iOS;

public class AdBannerViewHandler : ViewHandler<AdBannerView, UIView>
{
    public static readonly IPropertyMapper<AdBannerView, AdBannerViewHandler> Mapper =
        new PropertyMapper<AdBannerView, AdBannerViewHandler>(ViewMapper)
        {
            [nameof(AdBannerView.AdUnitId)] = (h, _) => h.LoadBanner(),
        };

    YABBannerAd? _banner;

    public AdBannerViewHandler() : base(Mapper) { }

    protected override UIView CreatePlatformView() => new UIView { ClipsToBounds = true };

    void LoadBanner()
    {
        if (string.IsNullOrEmpty(VirtualView?.AdUnitId))
            return;

        _banner?.Destroy();

        // Docs: pass the full available width, minus safe-area insets.
        var window = UIApplication.SharedApplication.ConnectedScenes
            .OfType<UIWindowScene>().SelectMany(s => s.Windows).FirstOrDefault(w => w.IsKeyWindow);
        var width = window?.SafeAreaLayoutGuide.LayoutFrame.Width ?? UIScreen.MainScreen.Bounds.Width;

        var banner = YABBannerAd.Sticky(width);
        _banner = banner;

        var adView = banner.View;
        PlatformView.AddSubview(adView);
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            adView.TopAnchor.ConstraintEqualTo(PlatformView.TopAnchor),
            adView.CenterXAnchor.ConstraintEqualTo(PlatformView.CenterXAnchor),
        });

        banner.OnLoaded = () =>
        {
            if (VirtualView is null) return;
            VirtualView.HeightRequest = banner.ContentSize.Height;
            VirtualView.RaiseAdLoaded();
        };
        banner.OnFailedToLoad = error => VirtualView?.RaiseAdFailedToLoad(error.LocalizedDescription);

        banner.Load(VirtualView.AdUnitId);
    }

    protected override void DisconnectHandler(UIView platformView)
    {
        _banner?.Destroy();
        _banner = null;
        base.DisconnectHandler(platformView);
    }
}
