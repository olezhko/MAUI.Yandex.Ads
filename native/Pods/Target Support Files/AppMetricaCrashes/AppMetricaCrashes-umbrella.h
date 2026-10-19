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

#import "AppMetricaCrashes/AMAAppMetricaCrashes.h"
#import "AppMetricaCrashes/AMAAppMetricaCrashesConfiguration.h"
#import "AppMetricaCrashes/AMAAppMetricaCrashReporting.h"
#import "AppMetricaCrashes/AMAAppMetricaPluginReporting.h"
#import "AppMetricaCrashes/AMAAppMetricaPlugins.h"
#import "AppMetricaCrashes/AMACrashBacktrace.h"
#import "AppMetricaCrashes/AMACrashBacktraceFrame.h"
#import "AppMetricaCrashes/AMACrashEvent.h"
#import "AppMetricaCrashes/AMACrashEventError.h"
#import "AppMetricaCrashes/AMACrashFilteringProxy.h"
#import "AppMetricaCrashes/AMACrashInfo.h"
#import "AppMetricaCrashes/AMACrashMach.h"
#import "AppMetricaCrashes/AMACrashObserverConfiguration.h"
#import "AppMetricaCrashes/AMACrashObserving.h"
#import "AppMetricaCrashes/AMACrashProviderDelegate.h"
#import "AppMetricaCrashes/AMACrashProviding.h"
#import "AppMetricaCrashes/AMACrashSignal.h"
#import "AppMetricaCrashes/AMACrashThreadInfo.h"
#import "AppMetricaCrashes/AMACrashType.h"
#import "AppMetricaCrashes/AMAError.h"
#import "AppMetricaCrashes/AMAErrorRepresentable.h"
#import "AppMetricaCrashes/AMAPluginErrorDetails.h"
#import "AppMetricaCrashes/AMAStackTraceElement.h"
#import "AppMetricaCrashes/AppMetricaCrashes.h"

FOUNDATION_EXPORT double AppMetricaCrashesVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaCrashesVersionString[];

