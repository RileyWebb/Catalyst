using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Catalyst.Windowing.SDL2;
using SDL = Catalyst.Windowing.SDL2.SDL;

namespace Catalyst.Windowing
{
    public unsafe class Window
    {
        public Application Application;
        
        internal SDL2.Window window;

        public Window(Application app)
        {
            Application = app;
            window = SDL.CreateWindow(app.Name, SDL.WINDOWPOS_UNDEFINED, SDL.WINDOWPOS_UNDEFINED, 720, 720,
                WindowFlags.Vulkan);
        }

        public void Update()
        {
            while (SDL.PollEvent(out Event @event) != 0) 
            {
                switch (@event.Type)
                {
                    case SDL2.EventType.Quit:
                        Application.State = ApplicationState.Closing;
                        break;
                    case SDL2.EventType.WindowEvent:
                        if (@event.Window.Evt == WindowEventID.Close)
                            Application.State = ApplicationState.Closing;
                        break;
                }
            }
        }

        internal string[] GetInstanceExtensions()
        {
            SDL.Vulkan_GetInstanceExtensions(window, out uint count, null!);
            IntPtr[] namePtrs = new IntPtr[count];
            SDL.Vulkan_GetInstanceExtensions(window, out count, namePtrs);

            string[] names = new string[count];
            for (int i = 0; i < count; i++)
                names[i] = SDL.UTF8_ToManaged(namePtrs[i]);

            return names;
        }
    }
}