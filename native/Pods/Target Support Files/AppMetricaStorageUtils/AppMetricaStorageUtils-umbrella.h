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

#import "AppMetricaStorageUtils/AMADiskFileStorage.h"
#import "AppMetricaStorageUtils/AMAFileStorage.h"
#import "AppMetricaStorageUtils/AMAIncrementableValueStorage.h"
#import "AppMetricaStorageUtils/AMAIncrementableValueStorageFactory.h"
#import "AppMetricaStorageUtils/AMAKeyValueStorageDataProviding.h"
#import "AppMetricaStorageUtils/AMAKeyValueStorageProviding.h"
#import "AppMetricaStorageUtils/AMAKeyValueStoring.h"
#import "AppMetricaStorageUtils/AMARollbackHolder.h"
#import "AppMetricaStorageUtils/AMAUserDefaultsKVSDataProvider.h"
#import "AppMetricaStorageUtils/AMAUserDefaultsStorage.h"
#import "AppMetricaStorageUtils/AppMetricaStorageUtils.h"

FOUNDATION_EXPORT double AppMetricaStorageUtilsVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaStorageUtilsVersionString[];

