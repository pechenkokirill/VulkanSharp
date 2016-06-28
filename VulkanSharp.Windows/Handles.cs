using System;

namespace VulkanSharp.Windows
{
	public static class InstanceExtension
	{
		public static SurfaceKhr CreateWin32SurfaceKHR (this Instance instance, Win32SurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			SurfaceKhr pSurface;
			unsafe {
				pSurface = new SurfaceKhr ();

				fixed (UInt64* ptrpSurface = &pSurface.m) {
					result = Windows.Interop.NativeMethods.vkCreateWin32SurfaceKHR (instance.Handle, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSurface);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSurface;
			}
		}
	}

	public static class PhysicalDeviceExtension
	{
		public static Bool32 GetWin32PresentationSupportKHR (this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
		{
			unsafe {
				return Windows.Interop.NativeMethods.vkGetPhysicalDeviceWin32PresentationSupportKHR (physicalDevice.Handle, queueFamilyIndex);
			}
		}
	}

}
