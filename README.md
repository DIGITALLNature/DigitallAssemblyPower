# Digitall.Plugins

NuGet package for Microsoft Dataverse plugin development that stays close to the standard `IPlugin` model while adding focused convenience features (extensions, logging adapters, and optional base classes).

<p align="center">
    <a href="LICENSE" target="_blank">
        <img src="https://img.shields.io/github/license/DIGITALLNature/DigitallAssemblyPower.svg" alt="GitHub license">
    </a>
    <a href="https://github.com/DIGITALLNature/DigitallAssemblyPower/releases" target="_blank">
        <img src="https://img.shields.io/github/tag/DIGITALLNature/DigitallAssemblyPower.svg" alt="GitHub tag (latest SemVer)">
    </a>
    <a href="https://www.nuget.org/packages/Digitall.Plugins" target="_blank">
        <img src="https://img.shields.io/nuget/v/Digitall.Plugins" alt="NuGet">
    </a>
    <a href="https://github.com/DIGITALLNature/DigitallAssemblyPower/graphs/contributors" target="_blank">
        <img src="https://img.shields.io/github/contributors-anon/DIGITALLNature/DigitallAssemblyPower.svg" alt="GitHub contributors">
    </a>
</p>

---

## Table of Contents

- [Installation](#installation)
- [Ecosystem Synergy](#ecosystem-synergy)
- [Design Goals](#design-goals)
- [Quick Start](#quick-start)
- [Usage](#usage)
  - [PluginSkeleton](#pluginskeleton)
  - [Executor](#executor)
  - [Service Provider Extensions](#service-provider-extensions)
  - [Time Provider (Testability)](#time-provider-testability)
  - [Logging](#logging)
- [API Reference](#api-reference)
  - [Base Classes](#base-classes)
  - [Extension Methods](#extension-methods)
  - [Enums](#enums)
- [Examples](#examples)
- [Requirements](#requirements)
- [License](#license)

---

## Installation

```bash
dotnet add package Digitall.Plugins
```

For a project in a subdirectory:

```bash
dotnet add src/MyProject package Digitall.Plugins
```

---

## Ecosystem Synergy

`Digitall.Plugins` is designed to work well on its own, but the best end-to-end developer experience comes from combining it with the related DIGITALL packages/tools:

| Purpose | Package / Tool | Link |
|---|---|---|
| Plugin implementation helpers (base classes + extensions) | `Digitall.Plugins` | https://www.nuget.org/packages/Digitall.Plugins |
| Fast, in-memory Dataverse testing | `Digitall.Dataverse.Testing` | https://www.nuget.org/packages/Digitall.Dataverse.Testing |
| Attribute-based plugin/workflow registration metadata | `Digitall.Plugins.Registration` | https://www.nuget.org/packages/Digitall.Plugins.Registration |
| ALM automation, registration and model generation workflows | `dgt.power` (`dgtp`) | https://www.nuget.org/packages/dgt.power |

Typical flow:
1. Implement plugin logic with `PluginSkeleton` (or plain `IPlugin`) plus extension methods from this package.
2. Add registration attributes via `Digitall.Plugins.Registration`.
3. Use `dgt.power` (`dgtp`) to handle registration and early-bound model generation workflows.
4. Test plugin behavior quickly with `Digitall.Dataverse.Testing`, including deterministic time-based tests via `TimeProvider`.

---

## Design Goals

- Stay close to Microsoft's standard Dataverse plugin model (`IPlugin` + `IServiceProvider`) to keep behavior predictable.
- Keep framework logic transparent: extension methods provide convenience without adding hidden pipeline behavior.
- Let teams adopt incrementally: use pure `IPlugin`, `PluginSkeleton`, or `Executor` depending on project needs.

---

## Quick Start

Choose the base class that best fits your plugin design. For new plugins, start with **PluginSkeleton**. If you prefer plain `IPlugin`, the extension methods work there as well.

### Using PluginSkeleton (Recommended)

```csharp
using Digitall.Plugins;
using Microsoft.Xrm.Sdk;

public class MyPlugin : PluginSkeleton
{
    protected override void ExecuteInternal(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetExecutionContext();
        var entity = context.GetTarget<Entity>();
        
        // Your plugin logic here
    }
}
```

### Using Executor

```csharp
using Digitall.Plugins;

public class MyExecutor : Executor
{
    protected override ExecutionResult Execute()
    {
        var entity = Entity; // Pre-unwrapped from context
        var id = entity.Id;
        
        return ExecutionResult.Ok;
    }
}
```

---

## Usage

### PluginSkeleton

`PluginSkeleton` is the recommended base class for new plugins. It follows Microsoft's stateless plugin guidance while keeping the standard `IServiceProvider` programming model you already know from raw `IPlugin`.

**Benefits:**
- Same `IServiceProvider` flow as regular `IPlugin`, so existing code patterns are easy to migrate.
- Designed for stateless execution (important because Dataverse may reuse plugin instances across invocations).
- Automatic execution start/end logging with elapsed time.
- Structured exception logging and rethrow behavior.
- Access to `Microsoft.Extensions.Logging.ILogger`-compatible logging via selectable sinks.

> [!IMPORTANT]
> Keep plugin implementations stateless. Avoid mutable instance properties for request-specific data because the Dataverse runtime may reuse plugin instances across executions.

**Override abstract method:**

```csharp
protected abstract void ExecuteInternal(IServiceProvider serviceProvider);
```

**Example:**

```csharp
using Digitall.Plugins;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;

public class AccountPlugin : PluginSkeleton
{
    protected override void ExecuteInternal(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetExecutionContext();
        var account = context.GetTarget<Entity>();
        
        // Access services via extensions
        var logger = serviceProvider.GetLogger(
            ServiceProviderExtensions.LogSink.PluginTelemetry,
            ServiceProviderExtensions.LogSink.TracingService
        );
        var service = serviceProvider.GetOrganizationService();
        
        logger.LogInformation("Processing account: {0}", account.Id);
    }
}
```

---

### Executor

`Executor` is a legacy-compatible base class kept for backward compatibility. It is **not deprecated**, but new plugins should generally start with `PluginSkeleton` (or plain `IPlugin` if preferred).

**Benefits:**
- Simplified property access (Entity, EntityReference, PreEntityImage, etc.)
- Pre-configured OrganizationService properties (Secured/Elevated)
- Support for secure and unsecure configuration
- ExecutionResult tracking
- Support for CreateMultiple/UpdateMultiple operations

**Constructor parameters (optional):**

| Parameter | Type | Description |
|---|---|---|
| `unsecure` | `string` | Unsecure configuration string |
| `secure` | `string` | Secure configuration string |

**Common Properties:**

| Property | Type | Description |
|---|---|---|
| `Entity` | `Entity` | The target entity for single-record operations |
| `GetEntities()` | `EntityCollection` | Target entities for CreateMultiple/UpdateMultiple |
| `EntityReference` | `EntityReference` | The target entity reference |
| `PreEntityImage` | `Entity` | Pre-operation entity image |
| `GetPreEntityImages()` | `EntityCollection` | Pre-operation entity images (for bulk operations) |
| `PostEntityImage` | `Entity` | Post-operation entity image |
| `GetPostEntityImages()` | `EntityCollection` | Post-operation entity images (for bulk operations) |
| `SecuredOrganizationService` | `IOrganizationService` | Organization service with caller's privileges |
| `ElevatedOrganizationService` | `IOrganizationService` | Organization service with system privileges |
| `Core` | `IPluginExecutionContext` | The raw execution context |

**Example:**

```csharp
using Digitall.Plugins;

public class AccountExecutor : Executor
{
    protected override ExecutionResult Execute()
    {
        var entity = Entity;
        var accountName = entity.GetAttributeValue<string>("name");
        
        // Use pre-configured services
        var service = SecuredOrganizationService;
        
        return ExecutionResult.Ok;
    }
}
```

---

### Service Provider Extensions

Extension methods are the core value of this library. They work with any plugin style (`IPlugin`, `PluginSkeleton`, `Executor`, or custom base classes) and add convenience APIs without introducing black-box framework behavior.

```csharp
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;

var context = serviceProvider.GetExecutionContext();
var service = serviceProvider.GetOrganizationService();
var elevated = serviceProvider.GetElevatedOrganizationService();
var logger = serviceProvider.GetLogger();
var tracing = serviceProvider.GetTracingService();
var timeProvider = serviceProvider.GetTimeProvider();
var miService = serviceProvider.GetManagedIdentityService();
```

**Available Methods:**

| Method | Returns | Description |
|---|---|---|
| `GetExecutionContext()` | `IPluginExecutionContext7` | The plugin execution context |
| `GetOrganizationService()` | `IOrganizationService` | Service for current user (from context) |
| `GetOrganizationService(Guid userId)` | `IOrganizationService` | Service for specified user |
| `GetElevatedOrganizationService()` | `IOrganizationService` | Service with system (elevated) privileges |
| `GetTracingService()` | `ITracingService` | Tracing service for legacy logging |
| `GetLogger()` | `Microsoft.Xrm.Sdk.PluginTelemetry.ILogger` | Native Dataverse Plugin Telemetry logger |
| `GetLogger(params LogSink[] sinks)` | `Microsoft.Extensions.Logging.ILogger` | Standard .NET logger abstraction with selectable sinks |
| `GetTimeProvider()` | `TimeProvider` | Current time provider (testable) |
| `GetManagedIdentityService()` | `IManagedIdentityService` | Managed identity service for token acquisition |

---

### Time Provider (Testability)

Use `TimeProvider` for date/time-dependent plugin logic instead of directly calling `DateTime.UtcNow`.

At runtime, `GetTimeProvider()` falls back to `TimeProvider.System` when no custom provider is registered by the host. In tests, inject a fake provider (for example `FakeTimeProvider` from [`Microsoft.Extensions.TimeProvider.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing)), optionally together with [`Digitall.Dataverse.Testing`](https://www.nuget.org/packages/Digitall.Dataverse.Testing) for full in-memory Dataverse test scenarios.

```csharp
var timeProvider = serviceProvider.GetTimeProvider();
var utcNow = timeProvider.GetUtcNow();
```

---

### Logging

The library supports two logger interfaces and keeps the naming explicit:

- `GetLogger()` returns `Microsoft.Xrm.Sdk.PluginTelemetry.ILogger` (Dataverse plugin telemetry logger).
- `GetLogger(params LogSink[] sinks)` returns `Microsoft.Extensions.Logging.ILogger` (standard .NET logging abstraction).
- Older versions exposed `LoggingFacade`; current guidance is to use the standard .NET `ILogger` abstraction from `GetLogger(params LogSink[] sinks)`.

This lets you code against the standard .NET abstraction and change log sinks without rewriting logging calls (for example from `TracingService` only to `TracingService + PluginTelemetry`).

```csharp
var logger = serviceProvider.GetLogger(
    ServiceProviderExtensions.LogSink.PluginTelemetry,
    ServiceProviderExtensions.LogSink.TracingService
);

logger.LogInformation("Processing entity {0}", entityId);
logger.LogWarning("Warning: {0}", message);
logger.LogError("Error occurred: {0}", exception);
```

**Log Sinks:**

`PluginTelemetry` is intentionally named as a separate sink because Dataverse's telemetry logger is **not** `Microsoft.Extensions.Logging.ILogger`.

If your environment enables Dataverse Plugin Telemetry / Application Insights integration, you can keep the same `ILogger` calls and only adjust selected sinks.

When calling `GetLogger(params LogSink[] sinks)`:
- no sinks defaults to `TracingService`
- one sink logs to that sink
- multiple sinks write to all specified sinks

```csharp
// Logs to TracingService only
var logger1 = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.TracingService);

// Logs to PluginTelemetry only
var logger2 = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.PluginTelemetry);

// Logs to both
var logger3 = serviceProvider.GetLogger(
    ServiceProviderExtensions.LogSink.PluginTelemetry, 
    ServiceProviderExtensions.LogSink.TracingService
);
```

---

### Plugin Execution Context Extensions

Simplified access to execution context data with type-safe casting:

```csharp
using Digitall.Plugins.Extensions;

var context = serviceProvider.GetExecutionContext();

// Type-safe entity retrieval
var account = context.GetTarget<Account>();
var accounts = context.GetTargets<Account>(); // For bulk operations

// Image retrieval with casting
var preImage = context.GetPreImage<Account>();
var preImages = context.GetPreImages<Account>(); // For bulk operations
var postImage = context.GetPostImage<Account>();
var postImages = context.GetPostImages<Account>(); // For bulk operations

// Query information
var columnSet = context.GetColumnSet();
var isQuery = context.GetQuery(out QueryExpression query, out ColumnSet columns);

// Formatted context information
var stageName = context.GetFormattedExecutionStage(); // e.g., "PreOperation"
var modeName = context.GetFormattedExecutionMode(); // e.g., "Synchronous"

// Entity relationship operations
var relationship = context.GetRelationship();
var relatedEntities = context.GetRelatedEntities();
```

---

## API Reference

### Base Classes

#### PluginSkeleton

Abstract base class implementing `IPlugin` with built-in logging and exception handling.

| Member | Type | Description |
|---|---|---|
| `ExecuteInternal(serviceProvider)` | `abstract void` | Implement your plugin logic here |

---

#### Executor

Abstract base class implementing `IPlugin` with simplified property access and stateless execution.

| Member | Type | Description |
|---|---|---|
| `Result` | `ExecutionResult` | Get/set execution result |
| `Core` | `IPluginExecutionContext` | Raw execution context |
| `Entity` | `Entity` | Target entity (single operations) |
| `GetEntities()` | `EntityCollection` | Target entities (bulk operations) |
| `PreEntityImage` | `Entity` | Pre-image entity |
| `GetPreEntityImages()` | `EntityCollection` | Pre-image entities (bulk) |
| `PostEntityImage` | `Entity` | Post-image entity |
| `GetPostEntityImages()` | `EntityCollection` | Post-image entities (bulk) |
| `SecuredOrganizationService` | `IOrganizationService` | Cached service for current user |
| `ElevatedOrganizationService` | `IOrganizationService` | Cached service with system privileges |
| `Execute()` | `abstract ExecutionResult` | Implement your plugin logic here |

---

### Extension Methods

#### ServiceProviderExtensions

Available on `IServiceProvider`:

```csharp
GetExecutionContext()                                          // IPluginExecutionContext7
GetOrganizationService()                                       // IOrganizationService (current user)
GetOrganizationService(Guid userId)                           // IOrganizationService (specific user)
GetElevatedOrganizationService()                              // IOrganizationService (system)
GetTracingService()                                           // ITracingService
GetLogger()                                                   // Microsoft.Xrm.Sdk.PluginTelemetry.ILogger
GetLogger(params LogSink[] sinks)                             // Microsoft.Extensions.Logging.ILogger
GetTimeProvider()                                             // TimeProvider
GetManagedIdentityService()                                   // IManagedIdentityService
```

#### PluginExecutionContextExtensions

Available on `IPluginExecutionContext`:

```csharp
GetTarget<T>()                                                // T (typed entity)
GetTargets<T>()                                               // IEnumerable<T> (bulk operations)
GetPreImage<T>()                                              // T (typed pre-image)
GetPreImages<T>()                                             // IEnumerable<T> (bulk pre-images)
GetPostImage<T>()                                             // T (typed post-image)
GetPostImages<T>()                                            // IEnumerable<T> (bulk post-images)
GetColumnSet()                                                // ColumnSet
GetQuery(out QueryExpression, out ColumnSet)                 // bool
GetQuery(out QueryByAttribute, out ColumnSet)                // bool
GetQuery(out FetchExpression, out ColumnSet)                 // bool
GetRelationship()                                             // Relationship
GetRelatedEntities()                                          // EntityReferenceCollection
GetFormattedExecutionStage()                                  // string ("PreOperation", etc.)
GetFormattedExecutionMode()                                   // string ("Synchronous", etc.)
GetInputParameter<T>(string key, out T value)                // bool
GetOutputParameter<T>(string key, out T value)               // bool
SetOutputParameter<T>(string key, T value)                   // void
GetRetrieveEntity()                                           // Entity
GetRetrieveMultipleEntities()                                 // EntityCollection
```

#### EntityAttributeExtension

Available on `Entity`:

```csharp
HasAttribute(string attributeName)                            // bool
GetAttributeValue<T>(string attributeName, T defaultValue)   // T
GetAttribute<T>(string attributeName)                         // T
```

---

### Enums

#### ExecutionResult

Return value from `Executor.Execute()`:

| Value | Description |
|---|---|
| `Ok` | Execution completed successfully |
| `Failure` | Execution failed |
| `Skipped` | Execution was skipped |

---

## Examples

See the `examples/SamplePlugin` directory for complete working examples:

- **VanillaSample.cs**: Traditional IPlugin implementation
- **SkeletonSample.cs**: Using PluginSkeleton base class
- **ExecutorSample.cs**: Using Executor base class

---

## Requirements

- .NET Framework 4.6.2 or higher
- Microsoft.Xrm.Sdk 9.0 or higher
- Microsoft.Extensions.Logging 6.0 or higher

---

## License

Released under the [Microsoft Public License (MS-PL)](LICENSE).
