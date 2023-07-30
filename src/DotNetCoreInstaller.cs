using System.Diagnostics.CodeAnalysis;

using CliWrap;
using CliWrap.Buffered;

using Nefarius.Utilities.DotNetInstaller.Util;

namespace Nefarius.Utilities.DotNetInstaller;

/// <summary>
///     Utility class for detecting and installing .NET 7.x from any .NET Standard 2.0 program.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class DotNetCoreInstaller
{
    /// <summary>
    ///     Checks whether the required Desktop Runtime is installed.
    /// </summary>
    public static async Task<bool> IsDesktopRuntimeInstalled()
    {
        try
        {
            BufferedCommandResult dotnet = await Cli.Wrap("dotnet")
                .WithValidation(CommandResultValidation.None)
                .WithArguments(builder => builder
                    .Add("--list-runtimes"))
                .ExecuteBufferedAsync();

            return dotnet.ExitCode == 0 &&
                   dotnet.StandardOutput
                       .Split('\n')
                       .Any(runtime => runtime.Contains(DotNet7Constants.DesktopRuntimeExpectedNamePrefix));
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Checks whether the required Desktop Runtime is installed.
    /// </summary>
    public static async Task<bool> IsAspNetCoreRuntimeInstalled()
    {
        try
        {
            BufferedCommandResult dotnet = await Cli.Wrap("dotnet")
                .WithValidation(CommandResultValidation.None)
                .WithArguments(builder => builder
                    .Add("--list-runtimes"))
                .ExecuteBufferedAsync();

            return dotnet.ExitCode == 0 &&
                   dotnet.StandardOutput
                       .Split('\n')
                       .Any(runtime => runtime.Contains(DotNet7Constants.AspNetCoreRuntimeExpectedNamePrefix));
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Downloads and installs .NET Desktop Runtime 7.0
    /// </summary>
    public static async Task DesktopDownloadAndInstall(
        Action<string> progressMessage = default,
        Action<double> progressPercent = default,
        Action<string> logInformation = default,
        Action<string> logError = default
    )
    {
        string tempDir = FilesHelper.GetTemporaryDirectory();

        try
        {
            using HttpClient client = new();
            string targetFile = Path.Combine(tempDir, DotNet7Constants.LocalSetupFileName);

            progressMessage?.Invoke("Downloading .NET Desktop Runtime 7" +
                                    "\n\nThis might take a few seconds depending on your Internet speed");

            FileStream file = File.Create(targetFile);
            await client.DownloadAsync(
                Environment.Is64BitOperatingSystem ? DotNet7Constants.DotNet7DesktopX64Url : DotNet7Constants.DotNet7DesktopX86Url,
                file,
                new Progress<float>(
                    progress =>
                    {
                        progressPercent?.Invoke(progress);
                    }));
            file.Dispose();

            progressMessage?.Invoke("Installing .NET Desktop Runtime 7");

            CommandResult dotnet = await Cli.Wrap(targetFile)
                .WithArguments(builder => builder
                    .Add("/install")
                    .Add("/quiet")
                    .Add("/norestart")
                )
                .ExecuteAsync();

            logInformation?.Invoke($"dotnet install returned {dotnet.ExitCode}");

            progressMessage?.Invoke(".NET Desktop Runtime 7 installed");
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }

    /// <summary>
    ///     Downloads and installs ASP.NET Core 7.0 Runtime
    /// </summary>
    public static async Task AspNetCoreDownloadAndInstall(
        Action<string> progressMessage = default,
        Action<double> progressPercent = default,
        Action<string> logInformation = default,
        Action<string> logError = default
    )
    {
        string tempDir = FilesHelper.GetTemporaryDirectory();

        try
        {
            using HttpClient client = new();
            string targetFile = Path.Combine(tempDir, DotNet7Constants.LocalSetupFileName);

            progressMessage?.Invoke("Downloading ASP.NET Core 7.0 Runtime" +
                                    "\n\nThis might take a few seconds depending on your Internet speed");

            FileStream file = File.Create(targetFile);
            await client.DownloadAsync(DotNet7Constants.AspNetCoreHostingBundleUrl, file,
                new Progress<float>(
                    progress =>
                    {
                        progressPercent?.Invoke(progress);
                    }));
            file.Dispose();

            progressMessage?.Invoke("Installing ASP.NET Core 7.0 Runtime");

            CommandResult dotnet = await Cli.Wrap(targetFile)
                .WithArguments(builder => builder
                    .Add("/install")
                    .Add("/quiet")
                    .Add("/norestart")
                )
                .ExecuteAsync();

            logInformation?.Invoke($"dotnet install returned {dotnet.ExitCode}");

            progressMessage?.Invoke("ASP.NET Core 7.0 Runtime installed");
        }
        finally
        {
            Directory.Delete(tempDir, true);
        }
    }
}