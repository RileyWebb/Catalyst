using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Catalyst.Rendering.Vulkan.Ext;
using Catalyst.Rendering.Vulkan.Khr;
using Catalyst.Windowing.SDL2;
using VK = Catalyst.Rendering.Vulkan;

namespace Catalyst.Rendering
{
    public class Renderer
    {
        public static VK.Instance Instance;
        
        private static VK.ApplicationInfo _appInfo;

        private static VK.Instance CreateVulkanInstance(Application app)
        {
            _appInfo = new VK.ApplicationInfo(app.Name,
                default(Rendering.Vulkan.Version),
                Engine.Name,
                new Rendering.Vulkan.Version(Engine.Version.Major, Engine.Version.Minor, Engine.Version.Patch));

            string[]? layerNames = new string[] { };
            string[]? extensionNames = app.Window.GetInstanceExtensions();

            if (Debug.IsDebug)
            {
                layerNames = new[] {"VK_LAYER_KHRONOS_validation"};
                extensionNames = extensionNames.Concat(new[] {"VK_EXT_debug_utils", "VK_EXT_debug_report"}).ToArray();
            }

            Instance = new VK.Instance(new VK.InstanceCreateInfo(_appInfo, layerNames == new string[]{} ? null : layerNames, extensionNames));
            Debug.CreateVulkanDebugCallback(Instance);
            
            return Instance;
        }

        ~Renderer()
        {
            //Swapchain.Dispose();
            //Device.Dispose();
            //Surface.Dispose();
        }
    }
}