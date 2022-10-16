using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Catalyst.Rendering.Vulkan.Ext;
using VK = Catalyst.Rendering.Vulkan;

namespace Catalyst
{
    public static class Debug
    {
#if DEBUG
        public static bool IsDebug = true;

        public static Level LogLevel = Level.Log;
        public static Level PrintLevel = Level.Log;
        public static VK.Ext.DebugReportFlagsExt VulkanLogLevel = DebugReportFlagsExt.All;
#else
        public static bool IsDebug = false;
        
        public static Level LogLevel = Level.Warning;
        public static Level PrintLevel = Level.Warning;
        public static VK.Ext.DebugReportFlagsExt VulkanLogLevel = DebugReportFlagsExt.Warning;
#endif

        static Debug()
        {
        }

        public static void Assert(bool condition)
        {
            if (condition == true)
            {
                string message = $"Assertion Info:\n{System.Environment.StackTrace}";
                //SDL.Mes(SDL.MessageBoxFlags.SDL_MESSAGEBOX_ERROR, "Assertion Failed", message, IntPtr.Zero);
            }
        }

        public static void Log(string text) => Write(text, Level.Log);
        
        public static void Warn(string text) => Write(text, Level.Warning);
        
        public static void Error(string text) => Write(text, Level.Error);
        
        public static void Critical(string text)
        {
            Write(text, Level.Critical);
            //SDL2.ShowSimpleMessageBox(SDL2.MessageBoxFlags.SDL_MESSAGEBOX_ERROR, "Critical Error", text, IntPtr.Zero);
            Environment.Exit(-1);
        }

        private static void Write(string text, Level level)
        {
            if (level >= PrintLevel)
                Console.WriteLine(text);
            
            //if (level >= LogLevel)
                //Console.WriteLine(text);
        }

        internal static void CreateVulkanDebugCallback(VK.Instance instance)
        {
            if (IsDebug)
            {
                VK.Ext.DebugReportCallbackCreateInfoExt createInfo = new VK.Ext.DebugReportCallbackCreateInfoExt(VulkanLogLevel,
                    info =>
                    {
                        switch (info.Flags)
                        {
                            case DebugReportFlagsExt.Debug:
                            case DebugReportFlagsExt.Information:
                                Log(info.Message); break;
                            case DebugReportFlagsExt.Warning: 
                            case DebugReportFlagsExt.PerformanceWarning:
                                Warn(info.Message); break;
                            case DebugReportFlagsExt.Error: Error(info.Message); break;
                        }

                        return true;
                    });
                VK.AllocationCallbacks? vkInstanceAllocator = instance.Allocator;
                VK.Ext.DebugReportCallbackExt a = new VK.Ext.DebugReportCallbackExt(instance, ref createInfo, ref vkInstanceAllocator);
                
            }
        }
    }
    
    public enum Level
    {
        Log,
        Warning,
        Error,
        Critical,
    }
}