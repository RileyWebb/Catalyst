using System.Linq;
using Catalyst.Rendering.Vulkan;
using Catalyst.Rendering.Vulkan.Khr;

namespace Catalyst.Rendering
{
    public class RenderContext
    {
        public Instance Instance;
        public SurfaceKhr Surface;
        
        public PhysicalDevice PhysicalGraphicsDevice;
        public Device GraphicsDevice;
        
        public SwapchainKhr Swapchain;

        private int _graphicsQueueFamilyIndex = -1;
        private int _computeQueueFamilyIndex = -1;
        private int _presentQueueFamilyIndex = -1;
        
        public RenderContext(Instance instance, SurfaceKhr surface)
        {
            Instance = instance;
            Surface = surface;

            PhysicalGraphicsDevice = GetPhysicalDevice();    
            
            Debug.Log($"Using Device: {PhysicalGraphicsDevice.GetProperties().DeviceName}");
            
            string[]? deviceExtensions = {"VK_KHR_swapchain"};
            PhysicalDeviceFeatures deviceFeatures = new PhysicalDeviceFeatures();
            GraphicsDevice = CreateDevice(PhysicalGraphicsDevice, deviceExtensions, deviceFeatures);
        }
        
        private PhysicalDevice GetPhysicalDevice()
        {
            PhysicalDevice[] physicalDevices = Instance.EnumeratePhysicalDevices();

            if (physicalDevices.Length == 0)
                throw new System.Exception("No devices with Vulkan support found");

            foreach (PhysicalDevice device in physicalDevices)
            {
                QueueFamilyProperties[] queueFamilyProperties = device.GetQueueFamilyProperties();

                for (int i = 0; i < queueFamilyProperties.Length; i++)
                {
                    if (queueFamilyProperties[i].QueueFlags.HasFlag(Queues.Graphics))
                    {
                        if (_graphicsQueueFamilyIndex == -1) _graphicsQueueFamilyIndex = i;
                        if (_computeQueueFamilyIndex == -1) _computeQueueFamilyIndex = i;

                        if (device.GetSurfaceSupportKhr(i, Surface))
                            _presentQueueFamilyIndex = i;

                        if (_graphicsQueueFamilyIndex != -1 &&
                            _computeQueueFamilyIndex != -1 &&
                            _presentQueueFamilyIndex != -1)
                        {
                            return device; //TEST DEVICE SUITABILITY
                        }
                    }
                }
            }

            throw new System.Exception("No suitable devices found");
        }

        private Device CreateDevice(PhysicalDevice physicalDevice, string[] extensions, PhysicalDeviceFeatures? features)
        {
            foreach (string extension in extensions)
                if (physicalDevice.EnumerateExtensionProperties().All(i => i.ExtensionName != extension))
                    throw new System.Exception($"Required Device Extension: {extension} not found");
            
            //REWORK https://vulkan-tutorial.com/Drawing_a_triangle/Setup/Physical_devices_and_queue_families
            bool sameGraphicsAndPresent = _graphicsQueueFamilyIndex == _presentQueueFamilyIndex;
            DeviceQueueCreateInfo[] queueCreateInfos = new DeviceQueueCreateInfo[sameGraphicsAndPresent ? 1 : 2];
            queueCreateInfos[0] = new DeviceQueueCreateInfo(_graphicsQueueFamilyIndex, 1, 1.0f);
            if (!sameGraphicsAndPresent)
                queueCreateInfos[1] = new DeviceQueueCreateInfo(_presentQueueFamilyIndex, 1, 1.0f);

            DeviceCreateInfo deviceCreateInfo = new DeviceCreateInfo(queueCreateInfos, extensions, features);

            return physicalDevice.CreateDevice(deviceCreateInfo);
        }
    }
}