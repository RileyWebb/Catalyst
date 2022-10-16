using System.Linq;
using Catalyst.Events;
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

        public VK.Instance VKInstance;
        private VK.AllocationCallbacks? VKAllocator;
        
        public ApplicationState State;
        public EventQueue EventQueue;

        public string Name;

        private VK.ApplicationInfo _appInfo;

        public Application(string name)
        {
            Loader.Kernel32.LoadLibrary("SDL2.dll");
            
            Name = name;
            
            EventQueue = new EventQueue();
            Window = new Window(this);

            VKInstance = CreateVulkanInstance();
            VKAllocator = VKInstance.Allocator;
            
            
            SDL.Vulkan_CreateSurface(Window.window, VKInstance, out var a);
            Renderer = new Renderer(this, new VK.Khr.SurfaceKhr(VKInstance, ref VKAllocator, (long)a));
        }

        public virtual void Load()
        {
            
        }
        
        public virtual void Start()
        {
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
        }

        private VK.Instance CreateVulkanInstance()
        {
            _appInfo = new VK.ApplicationInfo(Name,
                default(Rendering.Vulkan.Version),
                Engine.Name,
                new Rendering.Vulkan.Version(Engine.Version.Major, Engine.Version.Minor, Engine.Version.Patch));

            string[]? layerNames = new string[] { };
            string[]? extensionNames = Window.GetInstanceExtensions();

            if (Debug.IsDebug)
            {
                layerNames = new[] {"VK_LAYER_KHRONOS_validation"};
                extensionNames = extensionNames.Concat(new[] {"VK_EXT_debug_utils", "VK_EXT_debug_report"}).ToArray();
            }

            VKInstance = new VK.Instance(new VK.InstanceCreateInfo(_appInfo, layerNames == new string[]{} ? null : layerNames, extensionNames));
            Debug.CreateVulkanDebugCallback(VKInstance);
            
            return VKInstance;
        }
        //Window
        //Vulkan
        //Input
    }

    public enum ApplicationState
    {
        Running,
        Paused,
        Closing,
    }
}