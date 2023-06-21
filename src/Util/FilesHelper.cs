namespace Nefarius.Utilities.DotNetInstaller.Util;

internal static class FilesHelper
{
    /// <summary>
    ///     Creates and return a new temporary directory path.
    /// </summary>
    /// <returns>The newly created unique temporary path.</returns>
    public static string GetTemporaryDirectory()
    {
        string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);
        return tempDirectory;
    }
}