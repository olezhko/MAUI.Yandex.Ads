#ifdef __OBJC__
#import <UIKit/UIKit.h>
#else
#ifndef FOUNDATION_EXPORT
#if defined(__cplusplus)
#define FOUNDATION_EXPORT extern "C"
#else
#define FOUNDATION_EXPORT extern
#endif
#endif
#endif

#import "AppMetricaPlatform/AMAApplicationState.h"
#import "AppMetricaPlatform/AMAApplicationStateKeys.h"
#import "AppMetricaPlatform/AMABundleInfoProvider.h"
#import "AppMetricaPlatform/AMAPlatformDescription.h"
#import "AppMetricaPlatform/AMAPlatformLocaleState.h"
#import "AppMetricaPlatform/AMAVersion.h"
#import "AppMetricaPlatform/AppMetricaPlatform.h"
#import "AppMetricaPlatform/NSBundle+ApplicationBundle.h"

FOUNDATION_EXPORT double AppMetricaPlatformVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaPlatformVersionString[];

