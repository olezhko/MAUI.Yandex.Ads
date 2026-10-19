using Foundation;
using YandexAdsBridge;

namespace YandexAdsSample.Platforms.iOS;

/// <summary>Task-based helpers over the bound interstitial / rewarded wrappers.</summary>
public sealed class YandexFullscreenAds
{
    // Docs: keep strong references to the ad objects while they're in use.
    readonly YABInterstitialAd _interstitial = new();
    readonly YABRewardedAd _rewarded = new();

    public event Action<string>? Log;

    public YandexFullscreenAds()
    {
        _interstitial.OnShown = () => Log?.Invoke("Interstitial shown");
        _interstitial.OnDismissed = () => Log?.Invoke("Interstitial dismissed");
        _interstitial.OnFailedToShow = e => Log?.Invoke($"Interstitial failed to show: {e.LocalizedDescription}");

        _rewarded.OnShown = () => Log?.Invoke("Rewarded shown");
        _rewarded.OnDismissed = () => Log?.Invoke("Rewarded dismissed");
        _rewarded.OnFailedToShow = e => Log?.Invoke($"Rewarded failed to show: {e.LocalizedDescription}");
        _rewarded.OnRewarded = (amount, type) => Log?.Invoke($"Reward: {amount} {type}");
    }

    public Task LoadInterstitialAsync(string adUnitId = "demo-interstitial-yandex") =>
        Load(cb => _interstitial.Load(adUnitId, cb));

    public Task LoadRewardedAsync(string adUnitId = "demo-rewarded-yandex") =>
        Load(cb => _rewarded.Load(adUnitId, cb));

    public bool ShowInterstitial()
    {
        var vc = Platform.GetCurrentUIViewController();
        if (vc is null || !_interstitial.IsLoaded) return false;
        _interstitial.Show(vc);
        return true;
    }

    public bool ShowRewarded()
    {
        var vc = Platform.GetCurrentUIViewController();
        if (vc is null || !_rewarded.IsLoaded) return false;
        _rewarded.Show(vc);
        return true;
    }

    static Task Load(Action<Action<NSError?>> start)
    {
        var tcs = new TaskCompletionSource();
        // All SDK calls must run on the main thread.
        MainThread.BeginInvokeOnMainThread(() => start(error =>
        {
            if (error is null) tcs.TrySetResult();
            else tcs.TrySetException(new NSErrorException(error));
        }));
        return tcs.Task;
    }
}
