# Digitall.Plugins

NuGet package providing base classes and extensions to simplify Microsoft Dataverse plugin development with improved logging and error handling.

<p align="center">
    <a href="LICENSE.md" target="_blank">
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
- [Quick Start](#quick-start)
- [Usage](#usage)
  - [PluginSkeleton](#pluginskeleton)
  - [Executor](#executor)
  - [Service Provider Extensions](#service-provider-extensions)
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

## Quick Start

Choose the base class that best fits your plugin design:

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

`PluginSkeleton` is a modern, structured base class with built-in logging and exception handling. It automatically logs execution start/end times, parameters, and errors.

**Benefits:**
- Automatic performance logging (elapsed milliseconds)
- Structured error logging with full context
- Support for Microsoft.Extensions.Logging.ILogger
- Support for Dataverse PluginTelemetry logging
- Automatic exception propagation with logging

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
        var logger = serviceProvider.GetLogger();
        var service = serviceProvider.GetOrganizationService();
        
        logger.LogInformation("Processing account: {0}", account.Id);
    }
}
```

---

### Executor

`Executor` is a legacy-compatible base class that provides convenient property accessors for common plugin execution patterns. It implements the "stateless" Microsoft recommendation by cloning itself on each invocation.

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

Access Dataverse services and utilities through extension methods on `IServiceProvider`.

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
| `GetLogger()` | `ILogger` | Default Dataverse logger (combined Telemetry + Tracing) |
| `GetLogger(params LogSink[] sinks)` | `ILogger` | Logger targeting specific sinks |
| `GetTimeProvider()` | `TimeProvider` | Current time provider (testable) |
| `GetManagedIdentityService()` | `IManagedIdentityService` | Managed identity service for token acquisition |

---

### Logging

The library provides integrated logging through `ILogger` (Microsoft.Extensions.Logging compatible):

```csharp
var logger = serviceProvider.GetLogger();

logger.LogInformation("Processing entity {0}", entityId);
logger.LogWarning("Warning: {0}", message);
logger.LogError("Error occurred: {0}", exception);
```

**Log Sinks:**

By default, logs go to both PluginTelemetry and TracingService:

```csharp
// Logs to TracingService only
var logger1 = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.TracingService);

// Logs to PluginTelemetry only
var logger2 = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.PluginTelemetry);

// Logs to both (default)
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
| `TimeProvider` | `TimeProvider` | Encapsulates DateTime access for testability |
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
GetLogger()                                                   // ILogger (default sinks)
GetLogger(params LogSink[] sinks)                             // ILogger (specific sinks)
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

Released under the [Microsoft Public License (MS-PL)](LICENSE.md).