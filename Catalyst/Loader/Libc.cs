using System;
using System.Runtime.InteropServices;

namespace Catalyst.Loader
{
    internal static class Libc
    {
        public const int RtldNow = 0x002;

        [DllImport("libc")]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport("libc")]
        public static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport("libc")]
        public static extern int dlclose(IntPtr handle);

        [DllImport("libc")]
        public static extern string dlerror();
    }
}