using System.Runtime.InteropServices;

namespace Catalyst.Windowing.SDL2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TouchID
    {
        private readonly long id;

        public TouchID(long id)
        {
            this.id = id;
        }

        public static implicit operator long(TouchID touchID)
        {
            return touchID.id;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FingerID
    {
        private readonly long id;

        public FingerID(long id)
        {
            this.id = id;
        }

        public static implicit operator long(FingerID fingerID)
        {
            return fingerID.id;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Finger
    {
        public FingerID Id;
        public float X;
        public float Y;
        public float Pressure;
    }

    internal static unsafe partial class SDL
    {
        public const uint TOUCH_MOUSEID = unchecked((uint) -1);

        [DllImport(LibraryName, EntryPoint = "SDL_GetNumTouchDevices", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumTouchDevices();

        [DllImport(LibraryName, EntryPoint = "SDL_GetTouchDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern TouchID GetTouchDevice(int index);

        [DllImport(LibraryName, EntryPoint = "SDL_GetNumTouchFingers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumTouchFingers(TouchID touchID);

        [DllImport(LibraryName, EntryPoint = "SDL_GetTouchFinger", CallingConvention = CallingConvention.Cdecl)]
        public static extern Finger GetTouchFinger(TouchID touchID, int index);
    }
}