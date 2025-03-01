using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Nefarius.Utilities.DotNetInstaller.Util;

/// <summary>
///     Processor architecture helpers.
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class ArchitectureInfo
{
    /// <summary>
    ///     Gets whether the current process is ARM64-native.
    /// </summary>
    public static bool IsArm64
    {
        get
        {
            IntPtr handle = Process.GetCurrentProcess().Handle;
            IsWow64Process2(handle, out _, out ushort nativeMachine);

            return nativeMachine == 0xaa64;
        }
    }

    /// <summary>
    ///     Gets the short name of the platform. See <see cref="RuntimeInformation.OSArchitecture" />.
    /// </summary>
    public static string PlatformShortName =>
        IsArm64
            ? "arm64"
            : RuntimeInformation.OSArchitecture.ToString();

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool IsWow64Process2(
        IntPtr process,
        out ushort processMachine,
        out ushort nativeMachine
    );
}