using System;
using System.Collections.Generic;
using System.Text;
using MAUI.Yandex.Ads.Platforms.iOS;

namespace MAUI.Yandex.Ads;

public static class YandexAdsMauiExtensions
{
    public static MauiAppBuilder UseYandexAds(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
            handlers.AddHandler<AdBannerView, AdBannerViewHandler>();
#elif IOS
            handlers.AddHandler<AdBannerView, AdBannerViewHandler>();
#endif
        });

        return builder;
    }
}