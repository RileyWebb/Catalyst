using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Catalyst.Rendering.Vulkan;
using Catalyst.Rendering.Vulkan.Khr;
using Catalyst.Windowing.SDL2;
using Event = Catalyst.Windowing.SDL2.Event;
using SDL = Catalyst.Windowing.SDL2.SDL;

namespace Catalyst.Windowing
{
    public unsafe class Window
    {
        public Application Application;
        
        internal IntPtr Handle;

        public Window(Application app)
        {
            Application = app;
            Handle = SDL.CreateWindow(app.Name, SDL.WINDOWPOS_UNDEFINED, SDL.WINDOWPOS_UNDEFINED, 720, 720,
                WindowFlags.Vulkan | WindowFlags.Hidden);
        }

        public void Update()
        {
            while (SDL.PollEvent(out Event @event) != 0) 
            {
                switch (@event.Type)
                {
                    case EventType.Quit:
                        Application.State = ApplicationState.Closing;
                        break;
                    case EventType.WindowEvent:
                        if (@event.Window.Evt == WindowEventID.Close)
                            Application.State = ApplicationState.Closing;
                        break;
                }
            }
        }

        public void Show() => SDL.ShowWindow(Handle);
        
        internal string[]? GetInstanceExtensions()
        {
            SDL.Vulkan_GetInstanceExtensions(Handle, out uint count, null!);
            IntPtr[] namePtrs = new IntPtr[count];
            SDL.Vulkan_GetInstanceExtensions(Handle, out count, namePtrs);

            string[]? names = new string[count];
            for (int i = 0; i < count; i++)
                names[i] = SDL.UTF8_ToManaged(namePtrs[i]);

            return names;
        }
        
        internal SurfaceKhr CreateSurface(Instance vkInstance)
        {
            SDL.Vulkan_CreateSurface(Handle, vkInstance, out ulong handle);
            AllocationCallbacks? allocator = vkInstance.Allocator;
            return new SurfaceKhr(vkInstance, ref allocator, (long)handle);
        }
    }
}