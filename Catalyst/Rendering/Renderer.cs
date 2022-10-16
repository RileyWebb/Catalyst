﻿using System;
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
        public Application Application;

        public VK.Instance Instance;
        
        public static VK.ExtensionProperties[] Extensions;
        public static VK.LayerProperties[] Layers;
        
        private static VK.AllocationCallbacks? allocationCallbacks;

        public VK.PhysicalDevice PhysicalDevice;
        public VK.Device Device;
        public SurfaceKhr Surface;
        
        public VK.Queue GraphicsQueue;
        public VK.Queue ComputeQueue;
        public VK.Queue PresentQueue;
        public VK.CommandPool GraphicsCommandPool;
        public VK.CommandPool ComputeCommandPool;

        public VK.Khr.SwapchainKhr Swapchain;
        public VK.Extent2D Extent;
        public VK.Image[] Framebuffer;
        public VK.ImageView[] SwapchainImageViews;

        public VK.Framebuffer[] SwapchainFramebuffers;
        
        private VK.Khr.SurfaceCapabilitiesKhr SurfaceCapabilities;

        private int _graphicsQueueFamilyIndex = -1;
        private int _computeQueueFamilyIndex = -1;
        private int _presentQueueFamilyIndex = -1;

        public Renderer(Application app, VK.Khr.SurfaceKhr surface)
        {
            Application = app;
            Instance = Application.VKInstance;
            allocationCallbacks = Instance.Allocator;

            Surface = surface;
    
            // Get Device
            PhysicalDevice = GetPhysicalDevice(Surface);

            string[] deviceExtensions = {"VK_KHR_swapchain"};
            VK.PhysicalDeviceFeatures deviceFeatures = new VK.PhysicalDeviceFeatures();
            Device = CreateDevice(PhysicalDevice, deviceExtensions, deviceFeatures);

            // Get queues
            GraphicsQueue = Device.GetQueue(_graphicsQueueFamilyIndex);
            ComputeQueue = _computeQueueFamilyIndex == _graphicsQueueFamilyIndex
                ? GraphicsQueue
                : Device.GetQueue(_computeQueueFamilyIndex);
            PresentQueue = _presentQueueFamilyIndex == _graphicsQueueFamilyIndex
                ? GraphicsQueue
                : Device.GetQueue(_presentQueueFamilyIndex);

            // Create command pools
            GraphicsCommandPool = Device.CreateCommandPool(new VK.CommandPoolCreateInfo(_graphicsQueueFamilyIndex));
            ComputeCommandPool = Device.CreateCommandPool(new VK.CommandPoolCreateInfo(_computeQueueFamilyIndex));
        
            // Create Swapchain
            SurfaceCapabilities = PhysicalDevice.GetSurfaceCapabilitiesKhr(Surface);
            Extent = SurfaceCapabilities.CurrentExtent;
        
            Swapchain = CreateSwapchain(SurfaceCapabilities);
            Framebuffer = Swapchain.GetImages();
            SwapchainImageViews = new VK.ImageView[Framebuffer.Length];

            for (int i = 0; i < SwapchainImageViews.Length; i++)
            {
                SwapchainImageViews[i] = Framebuffer[i].CreateView(new VK.ImageViewCreateInfo(VK.Format.B8G8R8A8UNorm, new VK.ImageSubresourceRange(VK.ImageAspects.Color,0,1,0,1)), Instance.Allocator);
            }

            VK.ShaderModule frag = CreateShaderModule(File.ReadAllBytes("Resources/Shaders/frag.spv"));
            VK.ShaderModule vert = CreateShaderModule(File.ReadAllBytes("Resources/Shaders/vert.spv"));

            VK.PipelineShaderStageCreateInfo vertShaderStageCreateInfo =
                new VK.PipelineShaderStageCreateInfo(VK.ShaderStages.Vertex, vert, "main");
            VK.PipelineShaderStageCreateInfo fragShaderStageCreateInfo =
                new VK.PipelineShaderStageCreateInfo(VK.ShaderStages.Fragment, frag, "main");

            VK.PipelineShaderStageCreateInfo[] shaderStages = {vertShaderStageCreateInfo, fragShaderStageCreateInfo};
            //COMEBACK TO THIS
            VK.PipelineVertexInputStateCreateInfo vertexInputInfo = new VK.PipelineVertexInputStateCreateInfo();
            //Surface.
            VK.PipelineInputAssemblyStateCreateInfo inputAssembly =
                new VK.PipelineInputAssemblyStateCreateInfo(VK.PrimitiveTopology.TriangleList);

            VK.Viewport viewport = new VK.Viewport(0, 0, Extent.Width, Extent.Width);
            VK.Rect2D scissor = new VK.Rect2D(0, 0, Extent.Width, Extent.Height);
        
            Console.WriteLine($"{Extent.Width} : {Extent.Height}");

            VK.PipelineViewportStateCreateInfo viewportStateCreateInfo =
                new VK.PipelineViewportStateCreateInfo(viewport, scissor);

            VK.PipelineRasterizationStateCreateInfo rasterizationStateCreateInfo =
                new VK.PipelineRasterizationStateCreateInfo();

            VK.PipelineMultisampleStateCreateInfo multisampleStateCreateInfo =
                new VK.PipelineMultisampleStateCreateInfo(VK.SampleCounts.Count1);

            VK.PipelineColorBlendAttachmentState colorBlendAttachmentState = new VK.PipelineColorBlendAttachmentState();

            VK.PipelineColorBlendStateCreateInfo colorBlendStateCreateInfo = new VK.PipelineColorBlendStateCreateInfo( new []{colorBlendAttachmentState});
        
            VK.DynamicState[] dynamicStates = {
                VK.DynamicState.Viewport,
                VK.DynamicState.LineWidth,
            };
        
            VK.PipelineDynamicStateCreateInfo dynamicState = new VK.PipelineDynamicStateCreateInfo(dynamicStates);

            VK.PipelineLayoutCreateInfo pipelineLayoutInfo = new VK.PipelineLayoutCreateInfo();
        
            VK.PipelineLayout pipelineLayout =
                new VK.PipelineLayout(Device, ref pipelineLayoutInfo, ref allocationCallbacks);

            VK.AttachmentDescription colorAttachment = new VK.AttachmentDescription(VK.AttachmentDescriptions.MayAlias,
                Swapchain.Format, VK.SampleCounts.Count1, VK.AttachmentLoadOp.Clear, VK.AttachmentStoreOp.Store,
                VK.AttachmentLoadOp.DontCare, VK.AttachmentStoreOp.DontCare, VK.ImageLayout.Undefined,
                VK.ImageLayout.PresentSrcKhr);

            VK.AttachmentReference reference = new VK.AttachmentReference(0, VK.ImageLayout.ColorAttachmentOptimal);

            VK.SubpassDescription subpass = new VK.SubpassDescription(new []{reference});

            VK.RenderPassCreateInfo renderPassCreateInfo = new VK.RenderPassCreateInfo(new[] {subpass}, new []{colorAttachment});
            VK.RenderPass renderPass = Device.CreateRenderPass(renderPassCreateInfo);

            VK.GraphicsPipelineCreateInfo graphicsPipelineCreateInfo = new VK.GraphicsPipelineCreateInfo(pipelineLayout,
                renderPass, 0, shaderStages, inputAssembly, vertexInputInfo, rasterizationStateCreateInfo,
                viewportState: viewportStateCreateInfo, multisampleState: multisampleStateCreateInfo, dynamicState: dynamicState, colorBlendState: colorBlendStateCreateInfo);

            VK.PipelineCacheCreateInfo cacheCreateInfo = new VK.PipelineCacheCreateInfo();
        
            VK.Pipeline graphicsPipeline =
                new VK.Pipeline(Device, null, ref graphicsPipelineCreateInfo, ref allocationCallbacks);

            SwapchainFramebuffers = new VK.Framebuffer[SwapchainImageViews.Length];

            for (int i = 0; i < SwapchainFramebuffers.Length; i++)
            {
                VK.ImageView[] attachments =
                {
                    SwapchainImageViews[i]
                };
            
                VK.FramebufferCreateInfo framebufferInfo = new VK.FramebufferCreateInfo(attachments, Extent.Width, Extent.Height);

                SwapchainFramebuffers[i] = new VK.Framebuffer(Device, renderPass, ref framebufferInfo, ref allocationCallbacks);
            }

            VK.CommandPoolCreateInfo commandPoolCreateInfo = new VK.CommandPoolCreateInfo(_graphicsQueueFamilyIndex);
            VK.CommandPool commandPool = Device.CreateCommandPool(commandPoolCreateInfo, allocationCallbacks);

            VK.Semaphore renderFinishedSemaphore = Device.CreateSemaphore();
            VK.Semaphore imageAvailableSemaphore = Device.CreateSemaphore();

            int imageIndex = Swapchain.AcquireNextImage(semaphore: imageAvailableSemaphore);
            VK.SubmitInfo submitInfo = new VK.SubmitInfo(new[] {imageAvailableSemaphore}, signalSemaphores: new []{renderFinishedSemaphore}, waitDstStageMask: new[]{VK.PipelineStages.DrawIndirect});
        
            GraphicsQueue.Submit(submitInfo);
        }
        
        private VK.PhysicalDevice GetPhysicalDevice(SurfaceKhr surface)
        {
            VK.PhysicalDevice[] physicalDevices = Instance.EnumeratePhysicalDevices();

            if (physicalDevices.Length == 0)
                throw new System.Exception("No devices with Vulkan support found");

            foreach (VK.PhysicalDevice device in physicalDevices)
            {
                VK.QueueFamilyProperties[] queueFamilyProperties = device.GetQueueFamilyProperties();

                for (int i = 0; i < queueFamilyProperties.Length; i++)
                {
                    if (queueFamilyProperties[i].QueueFlags.HasFlag(VK.Queues.Graphics))
                    {
                        if (_graphicsQueueFamilyIndex == -1) _graphicsQueueFamilyIndex = i;
                        if (_computeQueueFamilyIndex == -1) _computeQueueFamilyIndex = i;

                        if (device.GetSurfaceSupportKhr(i, surface))
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

        private VK.Device CreateDevice(VK.PhysicalDevice physicalDevice, string[] extensions, VK.PhysicalDeviceFeatures? features)
        {
            foreach (string extension in extensions)
                if (physicalDevice.EnumerateExtensionProperties().All(i => i.ExtensionName != extension))
                    throw new System.Exception($"Required Device Extension: {extension} not found");

            //physicalDevice.GetSurfaceSupportKhr()
            //REWORK https://vulkan-tutorial.com/Drawing_a_triangle/Setup/Physical_devices_and_queue_families
            bool sameGraphicsAndPresent = _graphicsQueueFamilyIndex == _presentQueueFamilyIndex;
            VK.DeviceQueueCreateInfo[] queueCreateInfos = new VK.DeviceQueueCreateInfo[sameGraphicsAndPresent ? 1 : 2];
            queueCreateInfos[0] = new VK.DeviceQueueCreateInfo(_graphicsQueueFamilyIndex, 1, 1.0f);
            if (!sameGraphicsAndPresent)
                queueCreateInfos[1] = new VK.DeviceQueueCreateInfo(_presentQueueFamilyIndex, 1, 1.0f);

            VK.DeviceCreateInfo deviceCreateInfo = new VK.DeviceCreateInfo(
                queueCreateInfos,
                extensions, 
                features);

            return physicalDevice.CreateDevice(deviceCreateInfo, Instance.Allocator);
        }

        private SwapchainKhr CreateSwapchain(SurfaceCapabilitiesKhr capabilities)
        {
            SurfaceFormatKhr[] formats = PhysicalDevice.GetSurfaceFormatsKhr(Surface);
            PresentModeKhr[] presentModes = PhysicalDevice.GetSurfacePresentModesKhr(Surface);

            VK.Format format = formats.Length == 1 && formats[0].Format == VK.Format.Undefined
                ? VK.Format.B8G8R8A8UNorm
                : formats[0].Format;

            PresentModeKhr presentMode =
                presentModes.Contains(PresentModeKhr.Mailbox) ? PresentModeKhr.Mailbox : //PREFERED
                presentModes.Contains(PresentModeKhr.FifoRelaxed) ? PresentModeKhr.FifoRelaxed :
                presentModes.Contains(PresentModeKhr.Fifo) ? PresentModeKhr.Fifo :
                PresentModeKhr.Immediate; //VSYNC OFF

            return Device.CreateSwapchainKhr(new SwapchainCreateInfoKhr(
                surface: Surface,
                imageFormat: format,
                imageExtent: capabilities.CurrentExtent,
                preTransform: capabilities.CurrentTransform,
                presentMode: presentMode), Instance.Allocator);
        }
        

        public VK.ShaderModule CreateShaderModule(byte[] data)
        {
            VK.ShaderModuleCreateInfo createInfo = new VK.ShaderModuleCreateInfo(data);
            return Device.CreateShaderModule(createInfo);
        }

        public static IntPtr AllocFunc(IntPtr userData, VK.Size size, VK.Size alignment, VK.SystemAllocationScope allocationScope)
        {
            IntPtr ptr = Marshal.AllocHGlobal(size);
            var sourceArray = new byte[size];
            Marshal.Copy(sourceArray, 0, ptr, (int)size);
            
            Debug.Log($"Allocating: size: {size}, alignment: {alignment}, allocationScope: {allocationScope}, return ptr* : 0x{ptr}");
            return ptr;  
        }

        public static IntPtr ReallocFunc(IntPtr userData, IntPtr original, VK.Size size, VK.Size alignment, VK.SystemAllocationScope allocationScope)
        {
            IntPtr ptr = Marshal.ReAllocHGlobal(original, size);
            Marshal.FreeHGlobal(original);
            
            Debug.Log($"Reallocating: original: {original}, size: {size}, alignment: {alignment}, allocationScope: {allocationScope}, return ptr* : 0x{ptr}");
            return ptr;  
        }
        
        public static void FreeFunc(IntPtr userData, IntPtr memory)
        {
            Debug.Log($"Freeing ptr: 0x{memory}");
            Marshal.FreeHGlobal(memory);
        }

        public static bool DebugCallback(DebugReportCallbackInfo info)
        {
            Debug.Log($"[{info.Flags}][{info.LayerPrefix}] {info.Message}");
            return info.Flags.HasFlag(DebugReportFlagsExt.Error);
        }
        
        ~Renderer()
        {
            Swapchain.Dispose();
            Device.Dispose();
            Surface.Dispose();
        }
    }
}