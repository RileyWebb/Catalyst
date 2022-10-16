using Catalyst.Windowing.SDL2;
using SDL = Catalyst.Windowing.SDL2.SDL;

namespace Catalyst
{
    public static class Engine
    {
        public const string Name = "Catalyst";
        public static readonly Version Version = new Version(1, 0, 0);

        public static void Init()
        {
            Debug.Log($"{Name} Engine {Version.ToString()}");
            SDL.Init(SDLInitFlags.Everything);
            Debug.Log($"SDL {SDL.VersionString()} Initialised");
        }
    }
}