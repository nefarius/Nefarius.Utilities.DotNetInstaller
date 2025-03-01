# ArchitectureInfo

Namespace: Nefarius.Utilities.DotNetInstaller.Util

Processor architecture helpers.

```csharp
public static class ArchitectureInfo
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ArchitectureInfo](./nefarius.utilities.dotnetinstaller.util.architectureinfo.md)

## Properties

### <a id="properties-isarm64"/>**IsArm64**

Gets whether the current process is ARM64-native.

```csharp
public static bool IsArm64 { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### <a id="properties-platformshortname"/>**PlatformShortName**

Gets the short name of the platform. See [RuntimeInformation.OSArchitecture](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation.osarchitecture).

```csharp
public static string PlatformShortName { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
