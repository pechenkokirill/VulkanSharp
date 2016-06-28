using System;
using System.Runtime.InteropServices;

namespace VulkanSharp.Windows.Interop
{
	internal static class NativeMethods
	{
		const string VulkanLibrary = "vulkan-1";

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateWin32SurfaceKHR (IntPtr instance, Win32SurfaceCreateInfoKhr* pCreateInfo, VulkanSharp.Interop.AllocationCallbacks* pAllocator, UInt64* pSurface);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Bool32 vkGetPhysicalDeviceWin32PresentationSupportKHR (IntPtr physicalDevice, UInt32 queueFamilyIndex);

	}
}
