using VulkanSharp.Windows.Interop;

namespace VulkanSharp.Windows
{
	// ReSharper disable InconsistentNaming
	public static class InstanceExtension
	{
		public static SurfaceKhr CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pSurface = new SurfaceKhr();

				Result result;
				fixed (ulong* ptrpSurface = &pSurface._handle) result = NativeMethods.vkCreateWin32SurfaceKHR(instance.Handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSurface);
				if (result != Result.Success) throw new ResultException(result);

				return pSurface;
			}
		}
	}

	public static class PhysicalDeviceExtension
	{
		public static Bool32 GetWin32PresentationSupportKHR(this PhysicalDevice physicalDevice, uint queueFamilyIndex) {
			return NativeMethods.vkGetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice.Handle, queueFamilyIndex);
		}
	}
}