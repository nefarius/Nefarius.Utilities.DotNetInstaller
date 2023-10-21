namespace Nefarius.Utilities.DotNetInstaller;

/// <summary>
///     .NET 7 Constants.
/// </summary>
public static class DotNet7Constants
{
    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x64).
    /// </summary>
    public const string DotNet7DesktopX64Url =
        "https://download.visualstudio.microsoft.com/download/pr/f9ea536d-8e1f-4247-88b8-e79e33fa0873/c06e39f73a3bb1ec8833bb1cde98fce3/windowsdesktop-runtime-7.0.12-win-x64.exe";

    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x86).
    /// </summary>
    public const string DotNet7DesktopX86Url =
        "https://download.visualstudio.microsoft.com/download/pr/7e606599-560e-47c9-9ff1-60af4beaffb5/377fdff249559470cf483880f16acaf0/windowsdesktop-runtime-7.0.12-win-x86.exe";

    /// <summary>
    ///     ASP.NET Core Hosting Bundle direct download link.
    /// </summary>
    public const string AspNetCoreHostingBundleUrl =
        "https://download.visualstudio.microsoft.com/download/pr/723dac98-2f86-4efa-a67d-90b7f88d1a78/325c7069d70a1b23dd1a1545930ac251/dotnet-hosting-7.0.12-win.exe";

    /// <summary>
    ///     Desktop Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string DesktopRuntimeExpectedNamePrefix = "Microsoft.WindowsDesktop.App 7.";

    /// <summary>
    ///     ASP.NET Core Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string AspNetCoreRuntimeExpectedNamePrefix = "Microsoft.AspNetCore.App 7.";

    /// <summary>
    ///     Temporary file name to download the setup as.
    /// </summary>
    public const string LocalSetupFileName = "dotnet-setup.exe";
}