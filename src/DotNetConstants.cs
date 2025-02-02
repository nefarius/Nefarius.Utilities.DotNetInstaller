namespace Nefarius.Utilities.DotNetInstaller;

/// <summary>
///     .NET 7 Constants.
/// </summary>
public static class DotNetConstants
{
    /// <summary>
    ///     Temporary file name to download the setup as.
    /// </summary>
    public const string LocalSetupFileName = "dotnet-setup.exe";

    #region .NET 7

    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x64).
    /// </summary>
    public const string DotNetDesktopX64Url7 =
        "https://download.visualstudio.microsoft.com/download/pr/f9ea536d-8e1f-4247-88b8-e79e33fa0873/c06e39f73a3bb1ec8833bb1cde98fce3/windowsdesktop-runtime-7.0.12-win-x64.exe";

    /// <summary>
    ///     .NET 7 Desktop Runtime direct download link (x86).
    /// </summary>
    public const string DotNetDesktopX86Url7 =
        "https://download.visualstudio.microsoft.com/download/pr/7e606599-560e-47c9-9ff1-60af4beaffb5/377fdff249559470cf483880f16acaf0/windowsdesktop-runtime-7.0.12-win-x86.exe";

    /// <summary>
    ///     ASP.NET Core Hosting Bundle direct download link.
    /// </summary>
    public const string AspNetCoreHostingBundleUrl7 =
        "https://download.visualstudio.microsoft.com/download/pr/723dac98-2f86-4efa-a67d-90b7f88d1a78/325c7069d70a1b23dd1a1545930ac251/dotnet-hosting-7.0.12-win.exe";

    /// <summary>
    ///     Desktop Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string DesktopRuntimeExpectedNamePrefix7 = "Microsoft.WindowsDesktop.App 7.";

    /// <summary>
    ///     ASP.NET Core Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string AspNetCoreRuntimeExpectedNamePrefix7 = "Microsoft.AspNetCore.App 7.";

    #endregion

    #region .NET 8
    
    /// <summary>
    ///     .NET 8 Desktop Runtime direct download link (x64).
    /// </summary>
    public const string DotNetDesktopX64Url8 =
        "https://download.visualstudio.microsoft.com/download/pr/f1e7ffc8-c278-4339-b460-517420724524/f36bb75b2e86a52338c4d3a90f8dac9b/windowsdesktop-runtime-8.0.12-win-x64.exe";

    /// <summary>
    ///     .NET 8 Desktop Runtime direct download link (x86).
    /// </summary>
    public const string DotNetDesktopX86Url8 =
        "https://download.visualstudio.microsoft.com/download/pr/acf6e5d3-1e2f-4072-833c-fa84a10841c5/acd48342207247f404a5aaa58d1a1ea1/windowsdesktop-runtime-8.0.12-win-x86.exe";

    /// <summary>
    ///     ASP.NET Core Hosting Bundle direct download link.
    /// </summary>
    public const string AspNetCoreHostingBundleUrl8 =
        "https://download.visualstudio.microsoft.com/download/pr/976226c0-41dc-49ba-ad3c-14ed3f55294d/adfedbe9509adcca236e9035d0ba7d0a/dotnet-hosting-8.0.12-win.exe";

    /// <summary>
    ///     Desktop Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string DesktopRuntimeExpectedNamePrefix8 = "Microsoft.WindowsDesktop.App 8.";

    /// <summary>
    ///     ASP.NET Core Runtime name to check against when enumerating runtimes.
    /// </summary>
    public const string AspNetCoreRuntimeExpectedNamePrefix8 = "Microsoft.AspNetCore.App 8.";

    #endregion
}