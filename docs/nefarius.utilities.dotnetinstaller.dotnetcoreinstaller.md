# DotNetCoreInstaller

Namespace: Nefarius.Utilities.DotNetInstaller

Utility class for detecting and installing .NET 7.x from any .NET Standard 2.0 program.

```csharp
public static class DotNetCoreInstaller
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DotNetCoreInstaller](./nefarius.utilities.dotnetinstaller.dotnetcoreinstaller.md)

## Methods

### <a id="methods-aspnetcoredownloadandinstall"/>**AspNetCoreDownloadAndInstall(DotNetCoreMajorVersion, Action&lt;String&gt;, Action&lt;Double&gt;, Action&lt;String&gt;, Action&lt;String&gt;, CancellationToken)**

Downloads and installs ASP.NET Core Runtime

```csharp
public static Task AspNetCoreDownloadAndInstall(DotNetCoreMajorVersion version, Action<String> progressMessage, Action<Double> progressPercent, Action<String> logInformation, Action<String> logError, CancellationToken stoppingToken)
```

#### Parameters

`version` [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md)<br>
The desired [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md) or
 [DotNetCoreMajorVersion.DotNet7](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md#dotnet7) by default.

`progressMessage` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for informational display messages.

`progressPercent` [Action&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for progress percentage.

`logInformation` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for informational log messages.

`logError` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for errors.

`stoppingToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
An optional [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken).

#### Returns

A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### <a id="methods-desktopdownloadandinstall"/>**DesktopDownloadAndInstall(DotNetCoreMajorVersion, Action&lt;String&gt;, Action&lt;Double&gt;, Action&lt;String&gt;, Action&lt;String&gt;, CancellationToken)**

Downloads and installs .NET Desktop Runtime.

```csharp
public static Task DesktopDownloadAndInstall(DotNetCoreMajorVersion version, Action<String> progressMessage, Action<Double> progressPercent, Action<String> logInformation, Action<String> logError, CancellationToken stoppingToken)
```

#### Parameters

`version` [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md)<br>
The desired [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md) or
 [DotNetCoreMajorVersion.DotNet7](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md#dotnet7) by default.

`progressMessage` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for informational display messages.

`progressPercent` [Action&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for progress percentage.

`logInformation` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for informational log messages.

`logError` [Action&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
Optional callback for errors.

`stoppingToken` [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)<br>
An optional [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken).

#### Returns

A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task).

### <a id="methods-isaspnetcoreruntimeinstalled"/>**IsAspNetCoreRuntimeInstalled(DotNetCoreMajorVersion)**

Checks whether the required Desktop Runtime is installed.

```csharp
public static Task<Boolean> IsAspNetCoreRuntimeInstalled(DotNetCoreMajorVersion version)
```

#### Parameters

`version` [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md)<br>
The desired [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md) or
 [DotNetCoreMajorVersion.DotNet7](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md#dotnet7) by default.

#### Returns

A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) with [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) success result.

### <a id="methods-isdesktopruntimeinstalled"/>**IsDesktopRuntimeInstalled(DotNetCoreMajorVersion)**

Checks whether the required Desktop Runtime is installed.

```csharp
public static Task<Boolean> IsDesktopRuntimeInstalled(DotNetCoreMajorVersion version)
```

#### Parameters

`version` [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md)<br>
The desired [DotNetCoreMajorVersion](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md) or
 [DotNetCoreMajorVersion.DotNet7](./nefarius.utilities.dotnetinstaller.dotnetcoremajorversion.md#dotnet7) by default.

#### Returns

A [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) with [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) success result.
