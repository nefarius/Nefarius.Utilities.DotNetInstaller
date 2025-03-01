// See https://aka.ms/new-console-template for more information

using Nefarius.Utilities.DotNetInstaller;

Console.WriteLine(await DotNetCoreInstaller.IsDesktopRuntimeInstalled(DotNetCoreMajorVersion.DotNet8));
await DotNetCoreInstaller.DesktopDownloadAndInstall(DotNetCoreMajorVersion.DotNet8);