using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Catalyst.Windowing.SDL2
{
    [Flags]
    public enum SDLInitFlags : uint
    {
        None = 0,
        Timer = 0x00000001u,
        Audio = 0x00000010u,
        Video = 0x00000020u,
        Joystick = 0x00000200u,
        Haptic = 0x00001000u,
        GameController = 0x00002000u,
        Events = 0x00004000u,
        NoParachute = 0x00100000u,

        Everything = Timer | Audio | Video | Events
                     | Joystick | Haptic | GameController
    }

    internal static unsafe partial class SDL
    {
        [DllImport(LibraryName, EntryPoint = "SDL_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init(SDLInitFlags flags);

        [DllImport(LibraryName, EntryPoint = "SDL_InitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitSubSystem(SDLInitFlags flags);

        [DllImport(LibraryName, EntryPoint = "SDL_QuitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QuitSubSystem(SDLInitFlags flags);

        [DllImport(LibraryName, EntryPoint = "SDL_WasInit", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDLInitFlags WasInit(SDLInitFlags flags);

        [DllImport(LibraryName, EntryPoint = "SDL_Quit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Quit();

        private static string GetString(byte* ptr)
        {
            int count = 0;
            while (*(ptr + count) != 0)
            {
                count += 1;
            }

            return Encoding.UTF8.GetString(ptr, count);
        }

        private static unsafe byte* Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return (byte*) 0;
            }

            int bufferSize = Utf8Size(str);
            byte* buffer = (byte*) Marshal.AllocHGlobal(bufferSize);
            fixed (char* strPtr = str)
            {
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
            }

            return buffer;
        }
    }
}