namespace Nefarius.Utilities.DotNetInstaller;

/// <summary>
///     .NET 7 Constants.
/// </summary>
public static class DotNet7Constants
{
    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x64).
    /// </summary>
    public const string DotNet7X64Url =
        "https://download.visualstudio.microsoft.com/download/pr/3ebf014d-fcb9-4200-b3fe-76ba2000b027/840f2f95833ce400a9949e35f1581d28/windowsdesktop-runtime-7.0.3-win-x64.exe";

    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x86).
    /// </summary>
    public const string DotNet7X86Url =
        "https://download.visualstudio.microsoft.com/download/pr/fb8bf100-9e1c-472c-8bc8-aa16fff44f53/8d36f5a56edff8620f9c63c1e73ba88c/windowsdesktop-runtime-7.0.3-win-x86.exe";

    /// <summary>
    ///     ASP.NET Core Hosting Bundle direct download link.
    /// </summary>
    public const string AspNetCoreHostingBundleUrl =
        "https://download.visualstudio.microsoft.com/download/pr/ff197e9e-44ac-40af-8ba7-267d92e9e4fa/d24439192bc549b42f9fcb71ecb005c0/dotnet-hosting-7.0.3-win.exe";

    /// <summary>
    ///     Desktop Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string DesktopRuntimeExpectedName = "Microsoft.WindowsDesktop.App 7.";

    /// <summary>
    ///     ASP.NET Core Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string AspNetCoreRuntimeExpectedName = "Microsoft.AspNetCore.App 7.";

    /// <summary>
    ///     Temporary file name to download the setup as.
    /// </summary>
    public const string LocalSetupFileName = "dotnet-setup.exe";
}