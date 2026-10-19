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

#import "AppMetricaLog/AMALogChannel.h"
#import "AppMetricaLog/AMALogConfigurator.h"
#import "AppMetricaLog/AMALogFacade.h"
#import "AppMetricaLog/AMALogFlags.h"
#import "AppMetricaLog/AMALogMacros.h"
#import "AppMetricaLog/AppMetricaLog.h"

FOUNDATION_EXPORT double AppMetricaLogVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaLogVersionString[];

