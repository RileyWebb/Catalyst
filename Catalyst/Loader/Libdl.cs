using System;
using System.Runtime.InteropServices;

namespace Catalyst.Loader
{
    internal static class Libdl
    {
        public const int RtldNow = 0x002;

        [DllImport("libdl")]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport("libdl")]
        public static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport("libdl")]
        public static extern int dlclose(IntPtr handle);

        [DllImport("libdl")]
        public static extern string dlerror();
    }
}