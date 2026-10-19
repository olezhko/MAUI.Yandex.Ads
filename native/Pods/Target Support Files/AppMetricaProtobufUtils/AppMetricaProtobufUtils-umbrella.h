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

#import "AppMetricaProtobufUtils/AMAAllocationsTrackerProvider.h"
#import "AppMetricaProtobufUtils/AMAAllocationsTracking.h"
#import "AppMetricaProtobufUtils/AMAProtobufAllocator.h"
#import "AppMetricaProtobufUtils/AMAProtobufUtilities.h"
#import "AppMetricaProtobufUtils/AppMetricaProtobufUtils.h"

FOUNDATION_EXPORT double AppMetricaProtobufUtilsVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaProtobufUtilsVersionString[];

