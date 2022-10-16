using System;
using System.Runtime.InteropServices;

namespace Catalyst.Windowing.SDL2
{
    public enum SysWMType
    {
        Unknown,
        Windows,
        X11,
        DirectFB,
        Cocoa,
        UIKit,
        Wayland,
        Mir,
        WinRT,
        Android,
        Vivante,
        OS2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SysWMInfo
    {
        public Version Version;
        public SysWMType Subsystem;
        public SysWMInfoUnion Info;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SysWMInfoUnion
    {
        [FieldOffset(0)] public SysWMInfoWin Win;
        [FieldOffset(0)] public SysWMInfoX11 X11;
        [FieldOffset(0)] public SysWMInfoCocoa Cocoa;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SysWMInfoWin
    {
        public IntPtr Window;
        public IntPtr HDc;
        public IntPtr HInstance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SysWMInfoCocoa
    {
        public IntPtr Window;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SysWMInfoX11
    {
        public IntPtr Display;
        public IntPtr Window;
    }

    internal static unsafe partial class SDL
    {
        [DllImport(LibraryName, EntryPoint = "SDL_GetWindowWMInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetWindowWMInfo(Window window, SysWMInfo* info);

        [DllImport(LibraryName, EntryPoint = "SDL_GetWindowWMInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetWindowWMInfo(Window window, ref SysWMInfo info);
    }
}