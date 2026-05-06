using Com.Yandex.Mobile.Ads.Common;

namespace MAUI.Yandex.Ads;

public sealed class ActionInitializationListener : Java.Lang.Object, IInitializationListener
{
    private readonly Action _onCompleted;

    public ActionInitializationListener(Action onCompleted) => _onCompleted = onCompleted;

    public void OnInitializationCompleted() => _onCompleted();
}
