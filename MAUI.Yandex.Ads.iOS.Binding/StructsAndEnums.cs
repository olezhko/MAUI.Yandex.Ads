using ObjCRuntime;
using System.Runtime.InteropServices;

namespace MAUI.Yandex.Ads.iOS.Binding
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YMAHorizontalOffset
    {
        public nfloat left;

        public nfloat right;
    }

    [Native]
    public enum YMAAdErrorCode : long
    {
        EmptyAdUnitID = 0,
        InvalidUUID = 1,
        NoSuchAdUnitID = 2,
        NoFill = 3,
        BadServerResponse = 4,
        AdSizeMismatch = 5,
        AdTypeMismatch = 6,
        ServiceTemporarilyNotAvailable = 7,
        AdHasAlreadyBeenPresented = 8,
        NilPresentingViewController = 9,
        IncorrectFullscreenView = 10,
        InvalidSDKConfiguration = 11,
        MissingSKAdNetworkIdentifier = 12
    }

    [Native]
    public enum YMAAdTheme : long
    {
        Unspecified = 0,
        Light = 1,
        Dark = 2
    }

    [Native]
    public enum YMAAdType : long
    {
        Banner = 0,
        Interstitial = 1,
        Rewarded = 2,
        Native = 3,
        AppOpenAd = 4,
        RetailMedia = 5
    }

    [Native]
    public enum YMANativeAdType : long
    {
        Content = 0,
        AppInstall = 1,
        Media = 2
    }

    [Native]
    public enum YMANativeErrorCode : long
    {
        NoViewForAsset = 0,
        InvalidViewForBinding = 1
    }

    [Native]
    public enum YMASizeConstraintType : long
    {
        Fixed = 0,
        FixedBannerRatio = 1,
        PreferredBannerRatio = 2
    }
}
