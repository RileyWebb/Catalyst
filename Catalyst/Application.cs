using System.Linq;
using Catalyst.Events;
using Catalyst.Rendering.Vulkan.Khr;
using Catalyst.Windowing.SDL2;
using VK = Catalyst.Rendering.Vulkan;
using Renderer = Catalyst.Rendering.Renderer;
using Window = Catalyst.Windowing.Window;

namespace Catalyst
{
    public abstract class Application
    {
        public Window Window;
        public Renderer Renderer;

        public ApplicationState State;
        public EventQueue EventQueue;

        public string Name;

        public Application(string name)
        {
            Loader.Kernel32.LoadLibrary("SDL2.dll");
            
            Name = name;
            
            EventQueue = new EventQueue();
            Window = new Window(this);

            //VKInstance = CreateVulkanInstance();
            
            //Renderer = new Renderer(this, Window);
        }

        public virtual void Load()
        {
            
        }
        
        public virtual void Start()
        {
            Window.Show();
            
            State = ApplicationState.Running;
            while (State != ApplicationState.Closing)
            {
                Update();
            }
        }

        public virtual void Update()
        {
            //EventQueue

            Window.Update();
            //Renderer.Draw();
        }
    }

    public enum ApplicationState
    {
        Running,
        Paused,
        Closing,
    }
}