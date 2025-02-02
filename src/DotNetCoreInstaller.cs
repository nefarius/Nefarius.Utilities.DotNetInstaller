using System.Diagnostics.CodeAnalysis;

using CliWrap;
using CliWrap.Buffered;

using Microsoft.Win32;

using Nefarius.Utilities.DotNetInstaller.Util;

namespace Nefarius.Utilities.DotNetInstaller;

/// <summary>
///     Utility class for detecting and installing .NET 7.x from any .NET Standard 2.0 program.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class DotNetCoreInstaller
{
    private static readonly Dictionary<DotNetCoreMajorVersion, string> DesktopNamePrefixMap =
        new()
        {
            { DotNetCoreMajorVersion.DotNet7, DotNetConstants.DesktopRuntimeExpectedNamePrefix7 },
            { DotNetCoreMajorVersion.DotNet8, DotNetConstants.DesktopRuntimeExpectedNamePrefix8 }
        };

    private static readonly Dictionary<DotNetCoreMajorVersion, string> AspNetNamePrefixMap =
        new()
        {
            { DotNetCoreMajorVersion.DotNet7, DotNetConstants.AspNetCoreRuntimeExpectedNamePrefix7 },
            { DotNetCoreMajorVersion.DotNet8, DotNetConstants.AspNetCoreRuntimeExpectedNamePrefix8 }
        };

    private static readonly Dictionary<DotNetCoreMajorVersion, string> VersionDesktopDownloadUrlMapX86 =
        new()
        {
            { DotNetCoreMajorVersion.DotNet7, DotNetConstants.DotNetDesktopX86Url7 },
            { DotNetCoreMajorVersion.DotNet8, DotNetConstants.DotNetDesktopX86Url8 }
        };

    private static readonly Dictionary<DotNetCoreMajorVersion, string> VersionDesktopDownloadUrlMapX64 =
        new()
        {
            { DotNetCoreMajorVersion.DotNet7, DotNetConstants.DotNetDesktopX64Url7 },
            { DotNetCoreMajorVersion.DotNet8, DotNetConstants.DotNetDesktopX64Url8 }
        };

    private static readonly Dictionary<DotNetCoreMajorVersion, string> VersionAspnetBundleDownloadUrlMap =
        new()
        {
            { DotNetCoreMajorVersion.DotNet7, DotNetConstants.AspNetCoreHostingBundleUrl7 },
            { DotNetCoreMajorVersion.DotNet8, DotNetConstants.AspNetCoreHostingBundleUrl8 }
        };

    private static string? GetDotnetPathFromRegistry()
    {
        using RegistryKey? key =
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedhost");
        string? installPath = key?.GetValue("Path") as string;

        return !string.IsNullOrEmpty(installPath) ? Path.Combine(installPath, "dotnet.exe") : null;
    }

    /// <summary>
    ///     Checks whether the required Desktop Runtime is installed.
    /// </summary>
    public static async Task<bool> IsDesktopRuntimeInstalled(
        DotNetCoreMajorVersion version = DotNetCoreMajorVersion.DotNet7)
    {
        try
        {
            BufferedCommandResult dotnet = await Cli.Wrap(GetDotnetPathFromRegistry()!)
                .WithValidation(CommandResultValidation.None)
                .WithArguments(builder => builder
                    .Add("--list-runtimes"))
                .ExecuteBufferedAsync();

            return dotnet.ExitCode == 0 &&
                   dotnet.StandardOutput
                       .Split('\n')
                       .Any(runtime => runtime.Contains(DesktopNamePrefixMap[version]));
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Checks whether the required Desktop Runtime is installed.
    /// </summary>
    public static async Task<bool> IsAspNetCoreRuntimeInstalled(
        DotNetCoreMajorVersion version = DotNetCoreMajorVersion.DotNet7)
    {
        try
        {
            BufferedCommandResult dotnet = await Cli.Wrap(GetDotnetPathFromRegistry()!)
                .WithValidation(CommandResultValidation.None)
                .WithArguments(builder => builder
                    .Add("--list-runtimes"))
                .ExecuteBufferedAsync();

            return dotnet.ExitCode == 0 &&
                   dotnet.StandardOutput
                       .Split('\n')
                       .Any(runtime => runtime.Contains(AspNetNamePrefixMap[version]));
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Downloads and installs .NET Desktop Runtime.
    /// </summary>
    /// <param name="version">The desired <see cref="DotNetCoreMajorVersion"/> or <see cref="DotNetCoreMajorVersion.DotNet7"/> by default.</param>
    /// <param name="progressMessage">Optional callback for informational display messages.</param>
    /// <param name="progressPercent">Optional callback for progress percentage.</param>
    /// <param name="logInformation">Optional callback for informational log messages.</param>
    /// <param name="logError">Optional callback for errors.</param>
    public static async Task DesktopDownloadAndInstall(
        DotNetCoreMajorVersion version = DotNetCoreMajorVersion.DotNet7,
        Action<string>? progressMessage = null,
        Action<double>? progressPercent = null,
        Action<string>? logInformation = null,
        Action<string>? logError = null
    )
    {
        string tempDir = FilesHelper.GetTemporaryDirectory();

        try
        {
            using HttpClient client = new();
            string targetFile = Path.Combine(tempDir, DotNetConstants.LocalSetupFileName);

            progressMessage?.Invoke("Downloading .NET Desktop Runtime" +
                                    "\n\nThis might take a few seconds depending on your Internet speed");

            FileStream file = File.Create(targetFile);
            await client.DownloadAsync(
                Environment.Is64BitOperatingSystem
                    ? VersionDesktopDownloadUrlMapX64[version]
                    : VersionDesktopDownloadUrlMapX86[version],
                file,
                new Progress<float>(
                    progress =>
                    {
                        progressPercent?.Invoke(progress);
                    }));
            file.Dispose();

            progressMessage?.Invoke("Installing .NET Desktop Runtime");

            CommandResult dotnet = await Cli.Wrap(targetFile)
                .WithArguments(builder => builder
                    .Add("/install")
                    .Add("/quiet")
                    .Add("/norestart")
                )
                .ExecuteAsync();

            logInformation?.Invoke($"dotnet install returned {dotnet.ExitCode}");

            progressMessage?.Invoke(".NET Desktop Runtime installed");
        }
        catch (Exception ex)
        {
            logError?.Invoke(ex.Message);
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    /// <summary>
    ///     Downloads and installs ASP.NET Core Runtime
    /// </summary>
    /// <param name="version">The desired <see cref="DotNetCoreMajorVersion"/> or <see cref="DotNetCoreMajorVersion.DotNet7"/> by default.</param>
    /// <param name="progressMessage">Optional callback for informational display messages.</param>
    /// <param name="progressPercent">Optional callback for progress percentage.</param>
    /// <param name="logInformation">Optional callback for informational log messages.</param>
    /// <param name="logError">Optional callback for errors.</param>
    public static async Task AspNetCoreDownloadAndInstall(
        DotNetCoreMajorVersion version = DotNetCoreMajorVersion.DotNet7,
        Action<string>? progressMessage = null,
        Action<double>? progressPercent = null,
        Action<string>? logInformation = null,
        Action<string>? logError = null
    )
    {
        string tempDir = FilesHelper.GetTemporaryDirectory();

        try
        {
            using HttpClient client = new();
            string targetFile = Path.Combine(tempDir, DotNetConstants.LocalSetupFileName);

            progressMessage?.Invoke("Downloading ASP.NET Core Runtime" +
                                    "\n\nThis might take a few seconds depending on your Internet speed");

            FileStream file = File.Create(targetFile);
            await client.DownloadAsync(VersionAspnetBundleDownloadUrlMap[version], file,
                new Progress<float>(
                    progress =>
                    {
                        progressPercent?.Invoke(progress);
                    }));
            file.Dispose();

            progressMessage?.Invoke("Installing ASP.NET Core Runtime");

            CommandResult dotnet = await Cli.Wrap(targetFile)
                .WithArguments(builder => builder
                    .Add("/install")
                    .Add("/quiet")
                    .Add("/norestart")
                )
                .ExecuteAsync();

            logInformation?.Invoke($"dotnet install returned {dotnet.ExitCode}");

            progressMessage?.Invoke("ASP.NET Core Runtime installed");
        }
        catch (Exception ex)
        {
            logError?.Invoke(ex.Message);
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }
}