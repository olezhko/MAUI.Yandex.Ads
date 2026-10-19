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

#import "AppMetricaCore/AMAAdRevenueInfo.h"
#import "AppMetricaCore/AMAAppMetrica.h"
#import "AppMetricaCore/AMAAppMetricaConfiguration.h"
#import "AppMetricaCore/AMAAppMetricaEvent.h"
#import "AppMetricaCore/AMAAppMetricaPreloadInfo.h"
#import "AppMetricaCore/AMAAppMetricaReporting.h"
#import "AppMetricaCore/AMAECommerce.h"
#import "AppMetricaCore/AMAJSControlling.h"
#import "AppMetricaCore/AMAProfileAttribute.h"
#import "AppMetricaCore/AMAReporterConfiguration.h"
#import "AppMetricaCore/AMARevenueInfo.h"
#import "AppMetricaCore/AMAUserProfile.h"
#import "AppMetricaCore/AppMetricaCore.h"

FOUNDATION_EXPORT double AppMetricaCoreVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaCoreVersionString[];

