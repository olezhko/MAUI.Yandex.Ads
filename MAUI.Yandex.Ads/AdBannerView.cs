namespace MAUI.Yandex.Ads;

public class AdBannerView : View
{
    public static readonly BindableProperty AdUnitIdProperty =
        BindableProperty.Create(
            nameof(AdUnitId),
            typeof(string),
            typeof(AdBannerView),
            defaultValue: string.Empty);

    public static readonly BindableProperty AdWidthProperty =
        BindableProperty.Create(
            nameof(AdWidth),
            typeof(int),
            typeof(AdBannerView),
            defaultValue: 320);

    public string AdUnitId
    {
        get => (string)GetValue(AdUnitIdProperty);
        set => SetValue(AdUnitIdProperty, value);
    }

    public int AdWidth
    {
        get => (int)GetValue(AdWidthProperty);
        set => SetValue(AdWidthProperty, value);
    }

    // Events
    public event EventHandler? AdLoaded;
    public event EventHandler<string>? AdFailedToLoad;

    internal void RaiseAdLoaded() => AdLoaded?.Invoke(this, EventArgs.Empty);
    internal void RaiseAdFailedToLoad(string error) => AdFailedToLoad?.Invoke(this, error);
}