using System.Runtime.InteropServices;

namespace Catalyst.Windowing.SDL2
{
    internal static unsafe partial class SDL
    {
        [DllImport(LibraryName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetError();

        public static string GetErrorString()
        {
            return GetString(GetError());
        }

        [DllImport(LibraryName, EntryPoint = "SDL_ClearError", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearError();
    }
}