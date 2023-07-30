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
        "https://download.visualstudio.microsoft.com/download/pr/7727acb3-25ca-473b-a392-75afeb33cab7/f11f0477fd2fcfbb3111881377d0c9bb/windowsdesktop-runtime-7.0.9-win-x64.exe";

    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x86).
    /// </summary>
    public const string DotNet7DesktopX86Url =
        "https://download.visualstudio.microsoft.com/download/pr/139b19d0-2d39-48ce-b59a-aec437509c20/ea6a2711eec53660c3b14d78b9fb2963/windowsdesktop-runtime-7.0.9-win-x86.exe";

    /// <summary>
    ///     ASP.NET Core Hosting Bundle direct download link.
    /// </summary>
    public const string AspNetCoreHostingBundleUrl =
        "https://download.visualstudio.microsoft.com/download/pr/a1918362-b09b-4593-a4b1-e5f0d9bd68b0/2470e7376871b57867655c057e878800/dotnet-hosting-7.0.9-win.exe";

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