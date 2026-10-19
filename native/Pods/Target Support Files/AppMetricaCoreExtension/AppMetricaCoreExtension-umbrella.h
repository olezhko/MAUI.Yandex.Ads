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

#import "AppMetricaCoreExtension/AMAAdProviding.h"
#import "AppMetricaCoreExtension/AMAApplicationStateManager.h"
#import "AppMetricaCoreExtension/AMAAppMetricaEventData.h"
#import "AppMetricaCoreExtension/AMAAppMetricaExtended.h"
#import "AppMetricaCoreExtension/AMAAppMetricaExtendedReporting.h"
#import "AppMetricaCoreExtension/AMAAppMetricaInternalEvent.h"
#import "AppMetricaCoreExtension/AMAAppMetricaLibraryAdapterConfiguration.h"
#import "AppMetricaCoreExtension/AMAEnvironmentContainer.h"
#import "AppMetricaCoreExtension/AMAEventFlushableDelegate.h"
#import "AppMetricaCoreExtension/AMAEventPollingDelegate.h"
#import "AppMetricaCoreExtension/AMAExtendedStartupObserving.h"
#import "AppMetricaCoreExtension/AMAModuleActivationConfiguration.h"
#import "AppMetricaCoreExtension/AMAModuleActivationDelegate.h"
#import "AppMetricaCoreExtension/AMAModuleEntryPoint.h"
#import "AppMetricaCoreExtension/AMAModulePreActivationHandler.h"
#import "AppMetricaCoreExtension/AMAModuleRegistrar.h"
#import "AppMetricaCoreExtension/AMAReporterStorageControlling.h"
#import "AppMetricaCoreExtension/AMAServiceConfiguration.h"
#import "AppMetricaCoreExtension/AMAStaticEventData.h"
#import "AppMetricaCoreExtension/AppMetricaCoreExtension.h"

FOUNDATION_EXPORT double AppMetricaCoreExtensionVersionNumber;
FOUNDATION_EXPORT const unsigned char AppMetricaCoreExtensionVersionString[];

