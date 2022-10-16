using System;
using System.Runtime.InteropServices;
using Catalyst.Exceptions;

namespace Catalyst.Loader
{
    internal static class Loader
    {
        internal static DevicePlatform Platform => GetPlatform();
        internal static Architecture Architecture => RuntimeInformation.OSArchitecture;

        static Loader()
        {
            if (Platform == DevicePlatform.Unknown)
                throw new PlatformNotSupportedException("This Platform is Unknown and or Unsupported");
            
            
        }

        internal static IntPtr LoadLibrary(string name)
        {
            switch (Platform)
            {
                case DevicePlatform.Windows:
                    return Kernel32.LoadLibrary(name);
                    break;
                case DevicePlatform.Linux:
                case DevicePlatform.Android:
                    return Libdl.dlopen(name, Libdl.RtldNow);
                    break;
            }

            throw new LibraryLoadingException(name);
        }

        private static DevicePlatform GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return DevicePlatform.Windows;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS"))
                    ? DevicePlatform.IOS
                    : DevicePlatform.MacOS;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID"))
                    ? DevicePlatform.Android
                    : DevicePlatform.Linux;

            return DevicePlatform.Unknown;
        }
    }

    public enum DevicePlatform
    {
        Windows,
        Linux,
        MacOS,
        Android,
        IOS,
        Unknown,
    }
}