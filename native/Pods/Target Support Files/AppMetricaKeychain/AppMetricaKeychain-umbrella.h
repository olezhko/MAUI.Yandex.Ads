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

#import "AppMetricaKeychain/AMAFallbackKeychain.h"
#import "AppMetricaKeychain/AMAKeychain.h"
#import "AppMetricaKeychain/AMAKeychainBridge.h"
#import "AppMetricaKeychain/AMAKeychainStoring.h"
#import "AppMetricaKeychain/AppMetricaKeychain.h"

FOUNDATION_EXPORT double AppMetricaKeychainVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaKeychainVersionString[];

