using System;
using System.Runtime.InteropServices;

namespace VulkanSharp.Windows.Interop
{
	// ReSharper disable InconsistentNaming
	internal static class NativeMethods
	{
		private const string VulkanLibrary = "vulkan-1";

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static extern unsafe Result vkCreateWin32SurfaceKHR (IntPtr instance, Win32SurfaceCreateInfoKhr* pCreateInfo, VulkanSharp.Interop.AllocationCallbacks* pAllocator, ulong* pSurface);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static extern Bool32 vkGetPhysicalDeviceWin32PresentationSupportKHR (IntPtr physicalDevice, uint queueFamilyIndex);
	}
}
