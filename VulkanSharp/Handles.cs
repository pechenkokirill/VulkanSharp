using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	public partial class Instance
	{
		protected IntPtr m;
		public IntPtr Handle => m;

		public void Destroy (AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyInstance (this.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public PhysicalDevice[] EnumeratePhysicalDevices ()
		{
			Result result;
			unsafe {
				UInt32 pPhysicalDeviceCount;
				result = Interop.NativeMethods.vkEnumeratePhysicalDevices (this.m, &pPhysicalDeviceCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPhysicalDeviceCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (IntPtr));
				var ptrpPhysicalDevices = Marshal.AllocHGlobal ((int)(size * pPhysicalDeviceCount));
				result = Interop.NativeMethods.vkEnumeratePhysicalDevices (this.m, &pPhysicalDeviceCount, (IntPtr*)ptrpPhysicalDevices);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPhysicalDeviceCount <= 0)
					return null;
				var arr = new PhysicalDevice [pPhysicalDeviceCount];
				for (int i = 0; i < pPhysicalDeviceCount; i++) {
					arr [i] = new PhysicalDevice (((IntPtr*)ptrpPhysicalDevices)[i]);
				}

				return arr;
			}
		}

		public IntPtr GetProcAddr (string pName)
		{
			unsafe {
				return Interop.NativeMethods.vkGetInstanceProcAddr (this.m, pName);
			}
		}

		public SurfaceKhr CreateDisplayPlaneSurfaceKHR (DisplaySurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			SurfaceKhr pSurface;
			unsafe {
				pSurface = new SurfaceKhr ();

				fixed (UInt64* ptrpSurface = &pSurface.m) {
					result = Interop.NativeMethods.vkCreateDisplayPlaneSurfaceKHR (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSurface);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSurface;
			}
		}

		public void DestroySurfaceKHR (SurfaceKhr surface, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroySurfaceKHR (this.m, surface.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public DebugReportCallbackExt CreateDebugReportCallbackEXT (DebugReportCallbackCreateInfoExt pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			DebugReportCallbackExt pCallback;
			unsafe {
				pCallback = new DebugReportCallbackExt ();

				fixed (UInt64* ptrpCallback = &pCallback.m) {
					result = Interop.NativeMethods.vkCreateDebugReportCallbackEXT (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpCallback);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pCallback;
			}
		}

		public void DestroyDebugReportCallbackEXT (DebugReportCallbackExt callback, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyDebugReportCallbackEXT (this.m, callback.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DebugReportMessageEXT (DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, UInt64 @object, UIntPtr location, Int32 messageCode, string pLayerPrefix, string pMessage)
		{
			unsafe {
				Interop.NativeMethods.vkDebugReportMessageEXT (this.m, flags, objectType, @object, location, messageCode, pLayerPrefix, pMessage);
			}
		}
	}

	public partial class PhysicalDevice
	{
		protected IntPtr m;

		public PhysicalDevice(IntPtr handle) {
			m = handle;
		}

		public IntPtr Handle => m;

		public PhysicalDeviceProperties GetProperties ()
		{
			PhysicalDeviceProperties pProperties;
			unsafe {
				pProperties = new PhysicalDeviceProperties ();
				Interop.NativeMethods.vkGetPhysicalDeviceProperties (this.m, pProperties.m);

				return pProperties;
			}
		}

		public QueueFamilyProperties[] GetQueueFamilyProperties ()
		{
			unsafe {
				UInt32 pQueueFamilyPropertyCount;
				Interop.NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties (this.m, &pQueueFamilyPropertyCount, null);
				if (pQueueFamilyPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (QueueFamilyProperties));
				var ptrpQueueFamilyProperties = Marshal.AllocHGlobal ((int)(size * pQueueFamilyPropertyCount));
				Interop.NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties (this.m, &pQueueFamilyPropertyCount, (QueueFamilyProperties*)ptrpQueueFamilyProperties);

				if (pQueueFamilyPropertyCount <= 0)
					return null;
				var arr = new QueueFamilyProperties [pQueueFamilyPropertyCount];
				for (int i = 0; i < pQueueFamilyPropertyCount; i++) {
					arr [i] = (((QueueFamilyProperties*)ptrpQueueFamilyProperties) [i]);
				}

				return arr;
			}
		}

		public PhysicalDeviceMemoryProperties GetMemoryProperties ()
		{
			PhysicalDeviceMemoryProperties pMemoryProperties;
			unsafe {
				pMemoryProperties = new PhysicalDeviceMemoryProperties ();
				Interop.NativeMethods.vkGetPhysicalDeviceMemoryProperties (this.m, pMemoryProperties.m);

				return pMemoryProperties;
			}
		}

		public PhysicalDeviceFeatures GetFeatures ()
		{
			PhysicalDeviceFeatures pFeatures;
			unsafe {
				pFeatures = new PhysicalDeviceFeatures ();
				Interop.NativeMethods.vkGetPhysicalDeviceFeatures (this.m, &pFeatures);

				return pFeatures;
			}
		}

		public FormatProperties GetFormatProperties (Format format)
		{
			FormatProperties pFormatProperties;
			unsafe {
				pFormatProperties = new FormatProperties ();
				Interop.NativeMethods.vkGetPhysicalDeviceFormatProperties (this.m, format, &pFormatProperties);

				return pFormatProperties;
			}
		}

		public ImageFormatProperties GetImageFormatProperties (Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags)
		{
			Result result;
			ImageFormatProperties pImageFormatProperties;
			unsafe {
				pImageFormatProperties = new ImageFormatProperties ();
				result = Interop.NativeMethods.vkGetPhysicalDeviceImageFormatProperties (this.m, format, type, tiling, usage, flags, &pImageFormatProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				return pImageFormatProperties;
			}
		}

		public Device CreateDevice (DeviceCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Device pDevice;
			unsafe {
				pDevice = new Device ();

				fixed (IntPtr* ptrpDevice = &pDevice.m) {
					result = Interop.NativeMethods.vkCreateDevice (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpDevice);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pDevice;
			}
		}

		public LayerProperties[] EnumerateDeviceLayerProperties ()
		{
			Result result;
			unsafe {
				UInt32 pPropertyCount;
				result = Interop.NativeMethods.vkEnumerateDeviceLayerProperties (this.m, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (Interop.LayerProperties));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkEnumerateDeviceLayerProperties (this.m, &pPropertyCount, (Interop.LayerProperties*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new LayerProperties [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = new LayerProperties (&((Interop.LayerProperties*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public ExtensionProperties[] EnumerateDeviceExtensionProperties (string pLayerName)
		{
			Result result;
			unsafe {
				UInt32 pPropertyCount;
				result = Interop.NativeMethods.vkEnumerateDeviceExtensionProperties (this.m, pLayerName, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (Interop.ExtensionProperties));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkEnumerateDeviceExtensionProperties (this.m, pLayerName, &pPropertyCount, (Interop.ExtensionProperties*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new ExtensionProperties [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = new ExtensionProperties (&((Interop.ExtensionProperties*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public SparseImageFormatProperties[] GetSparseImageFormatProperties (Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
		{
			unsafe {
				UInt32 pPropertyCount;
				Interop.NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties (this.m, format, type, samples, usage, tiling, &pPropertyCount, null);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (SparseImageFormatProperties));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				Interop.NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties (this.m, format, type, samples, usage, tiling, &pPropertyCount, (SparseImageFormatProperties*)ptrpProperties);

				if (pPropertyCount <= 0)
					return null;
				var arr = new SparseImageFormatProperties [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = (((SparseImageFormatProperties*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public DisplayPropertiesKhr[] GetDisplayPropertiesKHR ()
		{
			Result result;
			unsafe {
				UInt32 pPropertyCount;
				result = Interop.NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR (this.m, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (Interop.DisplayPropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR (this.m, &pPropertyCount, (Interop.DisplayPropertiesKhr*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new DisplayPropertiesKhr [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = new DisplayPropertiesKhr (&((Interop.DisplayPropertiesKhr*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public DisplayPlanePropertiesKhr[] GetDisplayPlanePropertiesKHR ()
		{
			Result result;
			unsafe {
				UInt32 pPropertyCount;
				result = Interop.NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR (this.m, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (Interop.DisplayPlanePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR (this.m, &pPropertyCount, (Interop.DisplayPlanePropertiesKhr*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new DisplayPlanePropertiesKhr [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = new DisplayPlanePropertiesKhr (&((Interop.DisplayPlanePropertiesKhr*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public DisplayKhr[] GetDisplayPlaneSupportedDisplaysKHR (UInt32 planeIndex)
		{
			Result result;
			unsafe {
				UInt32 pDisplayCount;
				result = Interop.NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR (this.m, planeIndex, &pDisplayCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pDisplayCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpDisplays = Marshal.AllocHGlobal ((int)(size * pDisplayCount));
				result = Interop.NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR (this.m, planeIndex, &pDisplayCount, (UInt64*)ptrpDisplays);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pDisplayCount <= 0)
					return null;
				var arr = new DisplayKhr [pDisplayCount];
				for (int i = 0; i < pDisplayCount; i++) {
					arr [i] = new DisplayKhr ();
					arr [i].m = ((UInt64*)ptrpDisplays) [i];
				}

				return arr;
			}
		}

		public DisplayModePropertiesKhr[] GetDisplayModePropertiesKHR (DisplayKhr display)
		{
			Result result;
			unsafe {
				UInt32 pPropertyCount;
				result = Interop.NativeMethods.vkGetDisplayModePropertiesKHR (this.m, display.m, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (Interop.DisplayModePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkGetDisplayModePropertiesKHR (this.m, display.m, &pPropertyCount, (Interop.DisplayModePropertiesKhr*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new DisplayModePropertiesKhr [pPropertyCount];
				for (int i = 0; i < pPropertyCount; i++) {
					arr [i] = new DisplayModePropertiesKhr (&((Interop.DisplayModePropertiesKhr*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public DisplayModeKhr CreateDisplayModeKHR (DisplayKhr display, DisplayModeCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			DisplayModeKhr pMode;
			unsafe {
				pMode = new DisplayModeKhr ();

				fixed (UInt64* ptrpMode = &pMode.m) {
					result = Interop.NativeMethods.vkCreateDisplayModeKHR (this.m, display.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpMode);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pMode;
			}
		}

		public DisplayPlaneCapabilitiesKhr GetDisplayPlaneCapabilitiesKHR (DisplayModeKhr mode, UInt32 planeIndex)
		{
			Result result;
			DisplayPlaneCapabilitiesKhr pCapabilities;
			unsafe {
				pCapabilities = new DisplayPlaneCapabilitiesKhr ();
				result = Interop.NativeMethods.vkGetDisplayPlaneCapabilitiesKHR (this.m, mode.m, planeIndex, &pCapabilities);
				if (result != Result.Success)
					throw new ResultException (result);

				return pCapabilities;
			}
		}

		public Bool32 GetSurfaceSupportKHR (UInt32 queueFamilyIndex, SurfaceKhr surface)
		{
			Result result;
			Bool32 pSupported;
			unsafe {
				pSupported = new Bool32 ();
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfaceSupportKHR (this.m, queueFamilyIndex, surface.m, &pSupported);
				if (result != Result.Success)
					throw new ResultException (result);

				return pSupported;
			}
		}

		public SurfaceCapabilitiesKhr GetSurfaceCapabilitiesKHR (SurfaceKhr surface)
		{
			Result result;
			SurfaceCapabilitiesKhr pSurfaceCapabilities;
			unsafe {
				pSurfaceCapabilities = new SurfaceCapabilitiesKhr ();
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfaceCapabilitiesKHR (this.m, surface.m, &pSurfaceCapabilities);
				if (result != Result.Success)
					throw new ResultException (result);

				return pSurfaceCapabilities;
			}
		}

		public SurfaceFormatKhr[] GetSurfaceFormatsKHR (SurfaceKhr surface)
		{
			Result result;
			unsafe {
				UInt32 pSurfaceFormatCount;
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR (this.m, surface.m, &pSurfaceFormatCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pSurfaceFormatCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (SurfaceFormatKhr));
				var ptrpSurfaceFormats = Marshal.AllocHGlobal ((int)(size * pSurfaceFormatCount));
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR (this.m, surface.m, &pSurfaceFormatCount, (SurfaceFormatKhr*)ptrpSurfaceFormats);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pSurfaceFormatCount <= 0)
					return null;
				var arr = new SurfaceFormatKhr [pSurfaceFormatCount];
				for (int i = 0; i < pSurfaceFormatCount; i++) {
					arr [i] = (((SurfaceFormatKhr*)ptrpSurfaceFormats) [i]);
				}

				return arr;
			}
		}

		public PresentModeKhr[] GetSurfacePresentModesKHR (SurfaceKhr surface)
		{
			Result result;
			unsafe {
				UInt32 pPresentModeCount;
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR (this.m, surface.m, &pPresentModeCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPresentModeCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (PresentModeKhr));
				var ptrpPresentModes = Marshal.AllocHGlobal ((int)(size * pPresentModeCount));
				result = Interop.NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR (this.m, surface.m, &pPresentModeCount, (PresentModeKhr*)ptrpPresentModes);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPresentModeCount <= 0)
					return null;
				var arr = new PresentModeKhr [pPresentModeCount];
				for (int i = 0; i < pPresentModeCount; i++) {
					arr [i] = new PresentModeKhr ();
					arr [i] = ((PresentModeKhr*)ptrpPresentModes) [i];
				}

				return arr;
			}
		}
	}

	public partial class Device
	{
		internal IntPtr m;

		public IntPtr GetProcAddr (string pName)
		{
			unsafe {
				return Interop.NativeMethods.vkGetDeviceProcAddr (this.m, pName);
			}
		}

		public void Destroy (AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyDevice (this.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Queue GetQueue (UInt32 queueFamilyIndex, UInt32 queueIndex)
		{
			Queue pQueue;
			unsafe {
				pQueue = new Queue ();

				fixed (IntPtr* ptrpQueue = &pQueue.m) {
					Interop.NativeMethods.vkGetDeviceQueue (this.m, queueFamilyIndex, queueIndex, ptrpQueue);
				}

				return pQueue;
			}
		}

		public void WaitIdle ()
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkDeviceWaitIdle (this.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public DeviceMemory AllocateMemory (MemoryAllocateInfo pAllocateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			DeviceMemory pMemory;
			unsafe {
				pMemory = new DeviceMemory ();

				fixed (UInt64* ptrpMemory = &pMemory.m) {
					result = Interop.NativeMethods.vkAllocateMemory (this.m, pAllocateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpMemory);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pMemory;
			}
		}

		public void FreeMemory (DeviceMemory memory, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkFreeMemory (this.m, memory.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public IntPtr MapMemory (DeviceMemory memory, DeviceSize offset, DeviceSize size, UInt32 flags)
		{
			Result result;
			IntPtr ppData;
			unsafe {
				ppData = new IntPtr ();
				result = Interop.NativeMethods.vkMapMemory (this.m, memory.m, offset, size, flags, &ppData);
				if (result != Result.Success)
					throw new ResultException (result);

				return ppData;
			}
		}

		public void UnmapMemory (DeviceMemory memory)
		{
			unsafe {
				Interop.NativeMethods.vkUnmapMemory (this.m, memory.m);
			}
		}

		public void FlushMappedMemoryRanges (UInt32 memoryRangeCount, MappedMemoryRange pMemoryRanges)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkFlushMappedMemoryRanges (this.m, memoryRangeCount, pMemoryRanges.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void InvalidateMappedMemoryRanges (UInt32 memoryRangeCount, MappedMemoryRange pMemoryRanges)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkInvalidateMappedMemoryRanges (this.m, memoryRangeCount, pMemoryRanges.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public DeviceSize GetMemoryCommitment (DeviceMemory memory)
		{
			DeviceSize pCommittedMemoryInBytes;
			unsafe {
				pCommittedMemoryInBytes = new DeviceSize ();
				Interop.NativeMethods.vkGetDeviceMemoryCommitment (this.m, memory.m, &pCommittedMemoryInBytes);

				return pCommittedMemoryInBytes;
			}
		}

		public MemoryRequirements GetBufferMemoryRequirements (Buffer buffer)
		{
			MemoryRequirements pMemoryRequirements;
			unsafe {
				pMemoryRequirements = new MemoryRequirements ();
				Interop.NativeMethods.vkGetBufferMemoryRequirements (this.m, buffer.m, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public void BindBufferMemory (Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkBindBufferMemory (this.m, buffer.m, memory.m, memoryOffset);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public MemoryRequirements GetImageMemoryRequirements (Image image)
		{
			MemoryRequirements pMemoryRequirements;
			unsafe {
				pMemoryRequirements = new MemoryRequirements ();
				Interop.NativeMethods.vkGetImageMemoryRequirements (this.m, image.m, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public void BindImageMemory (Image image, DeviceMemory memory, DeviceSize memoryOffset)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkBindImageMemory (this.m, image.m, memory.m, memoryOffset);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public SparseImageMemoryRequirements[] GetImageSparseMemoryRequirements (Image image)
		{
			unsafe {
				UInt32 pSparseMemoryRequirementCount;
				Interop.NativeMethods.vkGetImageSparseMemoryRequirements (this.m, image.m, &pSparseMemoryRequirementCount, null);
				if (pSparseMemoryRequirementCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (SparseImageMemoryRequirements));
				var ptrpSparseMemoryRequirements = Marshal.AllocHGlobal ((int)(size * pSparseMemoryRequirementCount));
				Interop.NativeMethods.vkGetImageSparseMemoryRequirements (this.m, image.m, &pSparseMemoryRequirementCount, (SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements);

				if (pSparseMemoryRequirementCount <= 0)
					return null;
				var arr = new SparseImageMemoryRequirements [pSparseMemoryRequirementCount];
				for (int i = 0; i < pSparseMemoryRequirementCount; i++) {
					arr [i] = (((SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements) [i]);
				}

				return arr;
			}
		}

		public Fence CreateFence (FenceCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Fence pFence;
			unsafe {
				pFence = new Fence ();

				fixed (UInt64* ptrpFence = &pFence.m) {
					result = Interop.NativeMethods.vkCreateFence (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpFence);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pFence;
			}
		}

		public void DestroyFence (Fence fence, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyFence (this.m, fence.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void ResetFences (UInt32 fenceCount, Fence pFences)
		{
			Result result;
			unsafe {
				fixed (UInt64* ptrpFences = &pFences.m) {
					result = Interop.NativeMethods.vkResetFences (this.m, fenceCount, ptrpFences);
				}
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void GetFenceStatus (Fence fence)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkGetFenceStatus (this.m, fence.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void WaitForFences (UInt32 fenceCount, Fence pFences, Bool32 waitAll, UInt64 timeout)
		{
			Result result;
			unsafe {
				fixed (UInt64* ptrpFences = &pFences.m) {
					result = Interop.NativeMethods.vkWaitForFences (this.m, fenceCount, ptrpFences, waitAll, timeout);
				}
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public Semaphore CreateSemaphore (SemaphoreCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Semaphore pSemaphore;
			unsafe {
				pSemaphore = new Semaphore ();

				fixed (UInt64* ptrpSemaphore = &pSemaphore.m) {
					result = Interop.NativeMethods.vkCreateSemaphore (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSemaphore);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSemaphore;
			}
		}

		public void DestroySemaphore (Semaphore semaphore, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroySemaphore (this.m, semaphore.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Event CreateEvent (EventCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Event pEvent;
			unsafe {
				pEvent = new Event ();

				fixed (UInt64* ptrpEvent = &pEvent.m) {
					result = Interop.NativeMethods.vkCreateEvent (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpEvent);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pEvent;
			}
		}

		public void DestroyEvent (Event @event, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyEvent (this.m, @event.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void GetEventStatus (Event @event)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkGetEventStatus (this.m, @event.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void SetEvent (Event @event)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkSetEvent (this.m, @event.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void ResetEvent (Event @event)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkResetEvent (this.m, @event.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public QueryPool CreateQueryPool (QueryPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			QueryPool pQueryPool;
			unsafe {
				pQueryPool = new QueryPool ();

				fixed (UInt64* ptrpQueryPool = &pQueryPool.m) {
					result = Interop.NativeMethods.vkCreateQueryPool (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpQueryPool);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pQueryPool;
			}
		}

		public void DestroyQueryPool (QueryPool queryPool, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyQueryPool (this.m, queryPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public IntPtr GetQueryPoolResults (QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, DeviceSize stride, QueryResultFlags flags)
		{
			Result result;
			IntPtr pData;
			unsafe {
				pData = new IntPtr ();
				result = Interop.NativeMethods.vkGetQueryPoolResults (this.m, queryPool.m, firstQuery, queryCount, dataSize, pData, stride, flags);
				if (result != Result.Success)
					throw new ResultException (result);

				return pData;
			}
		}

		public Buffer CreateBuffer (BufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Buffer pBuffer;
			unsafe {
				pBuffer = new Buffer ();

				fixed (UInt64* ptrpBuffer = &pBuffer.m) {
					result = Interop.NativeMethods.vkCreateBuffer (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpBuffer);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pBuffer;
			}
		}

		public void DestroyBuffer (Buffer buffer, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyBuffer (this.m, buffer.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public BufferView CreateBufferView (BufferViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			BufferView pView;
			unsafe {
				pView = new BufferView ();

				fixed (UInt64* ptrpView = &pView.m) {
					result = Interop.NativeMethods.vkCreateBufferView (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pView;
			}
		}

		public void DestroyBufferView (BufferView bufferView, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyBufferView (this.m, bufferView.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Image CreateImage (ImageCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Image pImage;
			unsafe {
				pImage = new Image ();

				fixed (UInt64* ptrpImage = &pImage.m) {
					result = Interop.NativeMethods.vkCreateImage (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpImage);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pImage;
			}
		}

		public void DestroyImage (Image image, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyImage (this.m, image.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public SubresourceLayout GetImageSubresourceLayout (Image image, ImageSubresource pSubresource)
		{
			SubresourceLayout pLayout;
			unsafe {
				pLayout = new SubresourceLayout ();
				Interop.NativeMethods.vkGetImageSubresourceLayout (this.m, image.m, &pSubresource, &pLayout);

				return pLayout;
			}
		}

		public ImageView CreateImageView (ImageViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			ImageView pView;
			unsafe {
				pView = new ImageView ();

				fixed (UInt64* ptrpView = &pView.m) {
					result = Interop.NativeMethods.vkCreateImageView (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pView;
			}
		}

		public void DestroyImageView (ImageView imageView, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyImageView (this.m, imageView.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public ShaderModule CreateShaderModule (ShaderModuleCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			ShaderModule pShaderModule;
			unsafe {
				pShaderModule = new ShaderModule ();

				fixed (UInt64* ptrpShaderModule = &pShaderModule.m) {
					result = Interop.NativeMethods.vkCreateShaderModule (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpShaderModule);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pShaderModule;
			}
		}

		public void DestroyShaderModule (ShaderModule shaderModule, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyShaderModule (this.m, shaderModule.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public PipelineCache CreatePipelineCache (PipelineCacheCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			PipelineCache pPipelineCache;
			unsafe {
				pPipelineCache = new PipelineCache ();

				fixed (UInt64* ptrpPipelineCache = &pPipelineCache.m) {
					result = Interop.NativeMethods.vkCreatePipelineCache (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineCache);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pPipelineCache;
			}
		}

		public void DestroyPipelineCache (PipelineCache pipelineCache, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyPipelineCache (this.m, pipelineCache.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void GetPipelineCacheData (PipelineCache pipelineCache, out UIntPtr pDataSize, IntPtr pData)
		{
			Result result;
			unsafe {
				fixed (UIntPtr* ptrpDataSize = &pDataSize) {
					result = Interop.NativeMethods.vkGetPipelineCacheData (this.m, pipelineCache.m, ptrpDataSize, pData);
				}
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void MergePipelineCaches (PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache pSrcCaches)
		{
			Result result;
			unsafe {
				fixed (UInt64* ptrpSrcCaches = &pSrcCaches.m) {
					result = Interop.NativeMethods.vkMergePipelineCaches (this.m, dstCache.m, srcCacheCount, ptrpSrcCaches);
				}
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public Pipeline[] CreateGraphicsPipelines (PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator)
		{
			Result result;
			unsafe {
				if (createInfoCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpPipelines = Marshal.AllocHGlobal ((int)(size * createInfoCount));
				result = Interop.NativeMethods.vkCreateGraphicsPipelines (this.m, pipelineCache.m, createInfoCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (UInt64*)ptrpPipelines);
				if (result != Result.Success)
					throw new ResultException (result);

				if (createInfoCount <= 0)
					return null;
				var arr = new Pipeline [createInfoCount];
				for (int i = 0; i < createInfoCount; i++) {
					arr [i] = new Pipeline ();
					arr [i].m = ((UInt64*)ptrpPipelines) [i];
				}

				return arr;
			}
		}

		public Pipeline[] CreateComputePipelines (PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator)
		{
			Result result;
			unsafe {
				if (createInfoCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpPipelines = Marshal.AllocHGlobal ((int)(size * createInfoCount));
				result = Interop.NativeMethods.vkCreateComputePipelines (this.m, pipelineCache.m, createInfoCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (UInt64*)ptrpPipelines);
				if (result != Result.Success)
					throw new ResultException (result);

				if (createInfoCount <= 0)
					return null;
				var arr = new Pipeline [createInfoCount];
				for (int i = 0; i < createInfoCount; i++) {
					arr [i] = new Pipeline ();
					arr [i].m = ((UInt64*)ptrpPipelines) [i];
				}

				return arr;
			}
		}

		public void DestroyPipeline (Pipeline pipeline, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyPipeline (this.m, pipeline.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public PipelineLayout CreatePipelineLayout (PipelineLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			PipelineLayout pPipelineLayout;
			unsafe {
				pPipelineLayout = new PipelineLayout ();

				fixed (UInt64* ptrpPipelineLayout = &pPipelineLayout.m) {
					result = Interop.NativeMethods.vkCreatePipelineLayout (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineLayout);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pPipelineLayout;
			}
		}

		public void DestroyPipelineLayout (PipelineLayout pipelineLayout, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyPipelineLayout (this.m, pipelineLayout.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Sampler CreateSampler (SamplerCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Sampler pSampler;
			unsafe {
				pSampler = new Sampler ();

				fixed (UInt64* ptrpSampler = &pSampler.m) {
					result = Interop.NativeMethods.vkCreateSampler (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSampler);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSampler;
			}
		}

		public void DestroySampler (Sampler sampler, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroySampler (this.m, sampler.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public DescriptorSetLayout CreateDescriptorSetLayout (DescriptorSetLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			DescriptorSetLayout pSetLayout;
			unsafe {
				pSetLayout = new DescriptorSetLayout ();

				fixed (UInt64* ptrpSetLayout = &pSetLayout.m) {
					result = Interop.NativeMethods.vkCreateDescriptorSetLayout (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSetLayout);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSetLayout;
			}
		}

		public void DestroyDescriptorSetLayout (DescriptorSetLayout descriptorSetLayout, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyDescriptorSetLayout (this.m, descriptorSetLayout.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public DescriptorPool CreateDescriptorPool (DescriptorPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			DescriptorPool pDescriptorPool;
			unsafe {
				pDescriptorPool = new DescriptorPool ();

				fixed (UInt64* ptrpDescriptorPool = &pDescriptorPool.m) {
					result = Interop.NativeMethods.vkCreateDescriptorPool (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpDescriptorPool);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pDescriptorPool;
			}
		}

		public void DestroyDescriptorPool (DescriptorPool descriptorPool, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyDescriptorPool (this.m, descriptorPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void ResetDescriptorPool (DescriptorPool descriptorPool, UInt32 flags)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkResetDescriptorPool (this.m, descriptorPool.m, flags);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public DescriptorSet[] AllocateDescriptorSets (DescriptorSetAllocateInfo pAllocateInfo)
		{
			Result result;
			unsafe {
				if (pAllocateInfo.DescriptorSetCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpDescriptorSets = Marshal.AllocHGlobal ((int)(size * pAllocateInfo.DescriptorSetCount));
				result = Interop.NativeMethods.vkAllocateDescriptorSets (this.m, pAllocateInfo.m, (UInt64*)ptrpDescriptorSets);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pAllocateInfo.DescriptorSetCount <= 0)
					return null;
				var arr = new DescriptorSet [pAllocateInfo.DescriptorSetCount];
				for (int i = 0; i < pAllocateInfo.DescriptorSetCount; i++) {
					arr [i] = new DescriptorSet ();
					arr [i].m = ((UInt64*)ptrpDescriptorSets) [i];
				}

				return arr;
			}
		}

		public void FreeDescriptorSets (DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet pDescriptorSets)
		{
			Result result;
			unsafe {
				fixed (UInt64* ptrpDescriptorSets = &pDescriptorSets.m) {
					result = Interop.NativeMethods.vkFreeDescriptorSets (this.m, descriptorPool.m, descriptorSetCount, ptrpDescriptorSets);
				}
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void UpdateDescriptorSets (UInt32 descriptorWriteCount, WriteDescriptorSet pDescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet pDescriptorCopies)
		{
			unsafe {
				Interop.NativeMethods.vkUpdateDescriptorSets (this.m, descriptorWriteCount, pDescriptorWrites.m, descriptorCopyCount, pDescriptorCopies.m);
			}
		}

		public Framebuffer CreateFramebuffer (FramebufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			Framebuffer pFramebuffer;
			unsafe {
				pFramebuffer = new Framebuffer ();

				fixed (UInt64* ptrpFramebuffer = &pFramebuffer.m) {
					result = Interop.NativeMethods.vkCreateFramebuffer (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpFramebuffer);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pFramebuffer;
			}
		}

		public void DestroyFramebuffer (Framebuffer framebuffer, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyFramebuffer (this.m, framebuffer.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public RenderPass CreateRenderPass (RenderPassCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			RenderPass pRenderPass;
			unsafe {
				pRenderPass = new RenderPass ();

				fixed (UInt64* ptrpRenderPass = &pRenderPass.m) {
					result = Interop.NativeMethods.vkCreateRenderPass (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpRenderPass);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pRenderPass;
			}
		}

		public void DestroyRenderPass (RenderPass renderPass, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyRenderPass (this.m, renderPass.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Extent2D GetRenderAreaGranularity (RenderPass renderPass)
		{
			Extent2D pGranularity;
			unsafe {
				pGranularity = new Extent2D ();
				Interop.NativeMethods.vkGetRenderAreaGranularity (this.m, renderPass.m, &pGranularity);

				return pGranularity;
			}
		}

		public CommandPool CreateCommandPool (CommandPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			CommandPool pCommandPool;
			unsafe {
				pCommandPool = new CommandPool ();

				fixed (UInt64* ptrpCommandPool = &pCommandPool.m) {
					result = Interop.NativeMethods.vkCreateCommandPool (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpCommandPool);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pCommandPool;
			}
		}

		public void DestroyCommandPool (CommandPool commandPool, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroyCommandPool (this.m, commandPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void ResetCommandPool (CommandPool commandPool, CommandPoolResetFlags flags)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkResetCommandPool (this.m, commandPool.m, flags);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public CommandBuffer[] AllocateCommandBuffers (CommandBufferAllocateInfo pAllocateInfo)
		{
			Result result;
			unsafe {
				if (pAllocateInfo.CommandBufferCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (IntPtr));
				var ptrpCommandBuffers = Marshal.AllocHGlobal ((int)(size * pAllocateInfo.CommandBufferCount));
				result = Interop.NativeMethods.vkAllocateCommandBuffers (this.m, pAllocateInfo.m, (IntPtr*)ptrpCommandBuffers);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pAllocateInfo.CommandBufferCount <= 0)
					return null;
				var arr = new CommandBuffer [pAllocateInfo.CommandBufferCount];
				for (int i = 0; i < pAllocateInfo.CommandBufferCount; i++) {
					arr [i] = new CommandBuffer ();
					arr [i].m = ((IntPtr*)ptrpCommandBuffers) [i];
				}

				return arr;
			}
		}

		public void FreeCommandBuffers (CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer pCommandBuffers)
		{
			unsafe {
				fixed (IntPtr* ptrpCommandBuffers = &pCommandBuffers.m) {
					Interop.NativeMethods.vkFreeCommandBuffers (this.m, commandPool.m, commandBufferCount, ptrpCommandBuffers);
				}
			}
		}

		public SwapchainKhr[] CreateSharedSwapchainsKHR (UInt32 swapchainCount, SwapchainCreateInfoKhr pCreateInfos, AllocationCallbacks pAllocator)
		{
			Result result;
			unsafe {
				if (swapchainCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpSwapchains = Marshal.AllocHGlobal ((int)(size * swapchainCount));
				result = Interop.NativeMethods.vkCreateSharedSwapchainsKHR (this.m, swapchainCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (UInt64*)ptrpSwapchains);
				if (result != Result.Success)
					throw new ResultException (result);

				if (swapchainCount <= 0)
					return null;
				var arr = new SwapchainKhr [swapchainCount];
				for (int i = 0; i < swapchainCount; i++) {
					arr [i] = new SwapchainKhr ();
					arr [i].m = ((UInt64*)ptrpSwapchains) [i];
				}

				return arr;
			}
		}

		public SwapchainKhr CreateSwapchainKHR (SwapchainCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator)
		{
			Result result;
			SwapchainKhr pSwapchain;
			unsafe {
				pSwapchain = new SwapchainKhr ();

				fixed (UInt64* ptrpSwapchain = &pSwapchain.m) {
					result = Interop.NativeMethods.vkCreateSwapchainKHR (this.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSwapchain);
				}
				if (result != Result.Success)
					throw new ResultException (result);

				return pSwapchain;
			}
		}

		public void DestroySwapchainKHR (SwapchainKhr swapchain, AllocationCallbacks pAllocator)
		{
			unsafe {
				Interop.NativeMethods.vkDestroySwapchainKHR (this.m, swapchain.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public Image[] GetSwapchainImagesKHR (SwapchainKhr swapchain)
		{
			Result result;
			unsafe {
				UInt32 pSwapchainImageCount;
				result = Interop.NativeMethods.vkGetSwapchainImagesKHR (this.m, swapchain.m, &pSwapchainImageCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pSwapchainImageCount <= 0)
					return null;

				int size = Marshal.SizeOf (typeof (UInt64));
				var ptrpSwapchainImages = Marshal.AllocHGlobal ((int)(size * pSwapchainImageCount));
				result = Interop.NativeMethods.vkGetSwapchainImagesKHR (this.m, swapchain.m, &pSwapchainImageCount, (UInt64*)ptrpSwapchainImages);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pSwapchainImageCount <= 0)
					return null;
				var arr = new Image [pSwapchainImageCount];
				for (int i = 0; i < pSwapchainImageCount; i++) {
					arr [i] = new Image ();
					arr [i].m = ((UInt64*)ptrpSwapchainImages) [i];
				}

				return arr;
			}
		}

		public UInt32 AcquireNextImageKHR (SwapchainKhr swapchain, UInt64 timeout, Semaphore semaphore, Fence fence)
		{
			Result result;
			UInt32 pImageIndex;
			unsafe {
				pImageIndex = new UInt32 ();
				result = Interop.NativeMethods.vkAcquireNextImageKHR (this.m, swapchain.m, timeout, semaphore.m, fence.m, &pImageIndex);
				if (result != Result.Success)
					throw new ResultException (result);

				return pImageIndex;
			}
		}

		public DebugMarkerObjectNameInfoExt DebugMarkerSetObjectNameEXT ()
		{
			Result result;
			DebugMarkerObjectNameInfoExt pNameInfo;
			unsafe {
				pNameInfo = new DebugMarkerObjectNameInfoExt ();
				result = Interop.NativeMethods.vkDebugMarkerSetObjectNameEXT (this.m, pNameInfo.m);
				if (result != Result.Success)
					throw new ResultException (result);

				return pNameInfo;
			}
		}

		public DebugMarkerObjectTagInfoExt DebugMarkerSetObjectTagEXT ()
		{
			Result result;
			DebugMarkerObjectTagInfoExt pTagInfo;
			unsafe {
				pTagInfo = new DebugMarkerObjectTagInfoExt ();
				result = Interop.NativeMethods.vkDebugMarkerSetObjectTagEXT (this.m, pTagInfo.m);
				if (result != Result.Success)
					throw new ResultException (result);

				return pTagInfo;
			}
		}
	}

	public partial class Queue
	{
		internal IntPtr m;

		public void Submit (UInt32 submitCount, SubmitInfo pSubmits, Fence fence)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkQueueSubmit (this.m, submitCount, pSubmits.m, fence.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void WaitIdle ()
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkQueueWaitIdle (this.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void BindSparse (UInt32 bindInfoCount, BindSparseInfo pBindInfo, Fence fence)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkQueueBindSparse (this.m, bindInfoCount, pBindInfo.m, fence.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void PresentKHR (PresentInfoKhr pPresentInfo)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkQueuePresentKHR (this.m, pPresentInfo.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}
	}

	public partial class CommandBuffer
	{
		internal IntPtr m;

		public void Begin (CommandBufferBeginInfo pBeginInfo)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkBeginCommandBuffer (this.m, pBeginInfo.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void End ()
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkEndCommandBuffer (this.m);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void Reset (CommandBufferResetFlags flags)
		{
			Result result;
			unsafe {
				result = Interop.NativeMethods.vkResetCommandBuffer (this.m, flags);
				if (result != Result.Success)
					throw new ResultException (result);
			}
		}

		public void CmdBindPipeline (PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
		{
			unsafe {
				Interop.NativeMethods.vkCmdBindPipeline (this.m, pipelineBindPoint, pipeline.m);
			}
		}

		public void CmdSetViewport (UInt32 firstViewport, UInt32 viewportCount, Viewport pViewports)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetViewport (this.m, firstViewport, viewportCount, &pViewports);
			}
		}

		public void CmdSetScissor (UInt32 firstScissor, UInt32 scissorCount, Rect2D pScissors)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetScissor (this.m, firstScissor, scissorCount, &pScissors);
			}
		}

		public void CmdSetLineWidth (float lineWidth)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetLineWidth (this.m, lineWidth);
			}
		}

		public void CmdSetDepthBias (float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetDepthBias (this.m, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
			}
		}

		public void CmdSetBlendConstants (float blendConstants)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetBlendConstants (this.m, blendConstants);
			}
		}

		public void CmdSetDepthBounds (float minDepthBounds, float maxDepthBounds)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetDepthBounds (this.m, minDepthBounds, maxDepthBounds);
			}
		}

		public void CmdSetStencilCompareMask (StencilFaceFlags faceMask, UInt32 compareMask)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetStencilCompareMask (this.m, faceMask, compareMask);
			}
		}

		public void CmdSetStencilWriteMask (StencilFaceFlags faceMask, UInt32 writeMask)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetStencilWriteMask (this.m, faceMask, writeMask);
			}
		}

		public void CmdSetStencilReference (StencilFaceFlags faceMask, UInt32 reference)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetStencilReference (this.m, faceMask, reference);
			}
		}

		public void CmdBindDescriptorSets (PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet pDescriptorSets, UInt32 dynamicOffsetCount, UInt32 pDynamicOffsets)
		{
			unsafe {
				fixed (UInt64* ptrpDescriptorSets = &pDescriptorSets.m) {
					Interop.NativeMethods.vkCmdBindDescriptorSets (this.m, pipelineBindPoint, layout.m, firstSet, descriptorSetCount, ptrpDescriptorSets, dynamicOffsetCount, &pDynamicOffsets);
				}
			}
		}

		public void CmdBindIndexBuffer (Buffer buffer, DeviceSize offset, IndexType indexType)
		{
			unsafe {
				Interop.NativeMethods.vkCmdBindIndexBuffer (this.m, buffer.m, offset, indexType);
			}
		}

		public void CmdBindVertexBuffers (UInt32 firstBinding, UInt32 bindingCount, Buffer pBuffers, DeviceSize pOffsets)
		{
			unsafe {
				fixed (UInt64* ptrpBuffers = &pBuffers.m) {
					Interop.NativeMethods.vkCmdBindVertexBuffers (this.m, firstBinding, bindingCount, ptrpBuffers, &pOffsets);
				}
			}
		}

		public void CmdDraw (UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDraw (this.m, vertexCount, instanceCount, firstVertex, firstInstance);
			}
		}

		public void CmdDrawIndexed (UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDrawIndexed (this.m, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
			}
		}

		public void CmdDrawIndirect (Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDrawIndirect (this.m, buffer.m, offset, drawCount, stride);
			}
		}

		public void CmdDrawIndexedIndirect (Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDrawIndexedIndirect (this.m, buffer.m, offset, drawCount, stride);
			}
		}

		public void CmdDispatch (UInt32 x, UInt32 y, UInt32 z)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDispatch (this.m, x, y, z);
			}
		}

		public void CmdDispatchIndirect (Buffer buffer, DeviceSize offset)
		{
			unsafe {
				Interop.NativeMethods.vkCmdDispatchIndirect (this.m, buffer.m, offset);
			}
		}

		public void CmdCopyBuffer (Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy pRegions)
		{
			unsafe {
				Interop.NativeMethods.vkCmdCopyBuffer (this.m, srcBuffer.m, dstBuffer.m, regionCount, &pRegions);
			}
		}

		public void CmdCopyImage (Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy pRegions)
		{
			unsafe {
				Interop.NativeMethods.vkCmdCopyImage (this.m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdBlitImage (Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit pRegions, Filter filter)
		{
			unsafe {
				Interop.NativeMethods.vkCmdBlitImage (this.m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, pRegions.m, filter);
			}
		}

		public void CmdCopyBufferToImage (Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy pRegions)
		{
			unsafe {
				Interop.NativeMethods.vkCmdCopyBufferToImage (this.m, srcBuffer.m, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdCopyImageToBuffer (Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy pRegions)
		{
			unsafe {
				Interop.NativeMethods.vkCmdCopyImageToBuffer (this.m, srcImage.m, srcImageLayout, dstBuffer.m, regionCount, &pRegions);
			}
		}

		public void CmdUpdateBuffer (Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32 pData)
		{
			unsafe {
				Interop.NativeMethods.vkCmdUpdateBuffer (this.m, dstBuffer.m, dstOffset, dataSize, &pData);
			}
		}

		public void CmdFillBuffer (Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
		{
			unsafe {
				Interop.NativeMethods.vkCmdFillBuffer (this.m, dstBuffer.m, dstOffset, size, data);
			}
		}

		public void CmdClearColorImage (Image image, ImageLayout imageLayout, ClearColorValue pColor, UInt32 rangeCount, ImageSubresourceRange pRanges)
		{
			unsafe {
				Interop.NativeMethods.vkCmdClearColorImage (this.m, image.m, imageLayout, pColor.m, rangeCount, &pRanges);
			}
		}

		public void CmdClearDepthStencilImage (Image image, ImageLayout imageLayout, ClearDepthStencilValue pDepthStencil, UInt32 rangeCount, ImageSubresourceRange pRanges)
		{
			unsafe {
				Interop.NativeMethods.vkCmdClearDepthStencilImage (this.m, image.m, imageLayout, &pDepthStencil, rangeCount, &pRanges);
			}
		}

		public void CmdClearAttachments (UInt32 attachmentCount, ClearAttachment pAttachments, UInt32 rectCount, ClearRect pRects)
		{
			unsafe {
				Interop.NativeMethods.vkCmdClearAttachments (this.m, attachmentCount, &pAttachments, rectCount, &pRects);
			}
		}

		public void CmdResolveImage (Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve pRegions)
		{
			unsafe {
				Interop.NativeMethods.vkCmdResolveImage (this.m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdSetEvent (Event @event, PipelineStageFlags stageMask)
		{
			unsafe {
				Interop.NativeMethods.vkCmdSetEvent (this.m, @event.m, stageMask);
			}
		}

		public void CmdResetEvent (Event @event, PipelineStageFlags stageMask)
		{
			unsafe {
				Interop.NativeMethods.vkCmdResetEvent (this.m, @event.m, stageMask);
			}
		}

		public void CmdWaitEvents (UInt32 eventCount, Event pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers)
		{
			unsafe {
				fixed (UInt64* ptrpEvents = &pEvents.m) {
					Interop.NativeMethods.vkCmdWaitEvents (this.m, eventCount, ptrpEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers.m, bufferMemoryBarrierCount, pBufferMemoryBarriers.m, imageMemoryBarrierCount, pImageMemoryBarriers.m);
				}
			}
		}

		public void CmdPipelineBarrier (PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers)
		{
			unsafe {
				Interop.NativeMethods.vkCmdPipelineBarrier (this.m, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers.m, bufferMemoryBarrierCount, pBufferMemoryBarriers.m, imageMemoryBarrierCount, pImageMemoryBarriers.m);
			}
		}

		public void CmdBeginQuery (QueryPool queryPool, UInt32 query, QueryControlFlags flags)
		{
			unsafe {
				Interop.NativeMethods.vkCmdBeginQuery (this.m, queryPool.m, query, flags);
			}
		}

		public void CmdEndQuery (QueryPool queryPool, UInt32 query)
		{
			unsafe {
				Interop.NativeMethods.vkCmdEndQuery (this.m, queryPool.m, query);
			}
		}

		public void CmdResetQueryPool (QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
		{
			unsafe {
				Interop.NativeMethods.vkCmdResetQueryPool (this.m, queryPool.m, firstQuery, queryCount);
			}
		}

		public void CmdWriteTimestamp (PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
		{
			unsafe {
				Interop.NativeMethods.vkCmdWriteTimestamp (this.m, pipelineStage, queryPool.m, query);
			}
		}

		public void CmdCopyQueryPoolResults (QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
		{
			unsafe {
				Interop.NativeMethods.vkCmdCopyQueryPoolResults (this.m, queryPool.m, firstQuery, queryCount, dstBuffer.m, dstOffset, stride, flags);
			}
		}

		public void CmdPushConstants (PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr pValues)
		{
			unsafe {
				Interop.NativeMethods.vkCmdPushConstants (this.m, layout.m, stageFlags, offset, size, pValues);
			}
		}

		public void CmdBeginRenderPass (RenderPassBeginInfo pRenderPassBegin, SubpassContents contents)
		{
			unsafe {
				Interop.NativeMethods.vkCmdBeginRenderPass (this.m, pRenderPassBegin.m, contents);
			}
		}

		public void CmdNextSubpass (SubpassContents contents)
		{
			unsafe {
				Interop.NativeMethods.vkCmdNextSubpass (this.m, contents);
			}
		}

		public void CmdEndRenderPass ()
		{
			unsafe {
				Interop.NativeMethods.vkCmdEndRenderPass (this.m);
			}
		}

		public void CmdExecuteCommands (UInt32 commandBufferCount, CommandBuffer pCommandBuffers)
		{
			unsafe {
				fixed (IntPtr* ptrpCommandBuffers = &pCommandBuffers.m) {
					Interop.NativeMethods.vkCmdExecuteCommands (this.m, commandBufferCount, ptrpCommandBuffers);
				}
			}
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerBeginEXT ()
		{
			DebugMarkerMarkerInfoExt pMarkerInfo;
			unsafe {
				pMarkerInfo = new DebugMarkerMarkerInfoExt ();
				Interop.NativeMethods.vkCmdDebugMarkerBeginEXT (this.m, pMarkerInfo.m);

				return pMarkerInfo;
			}
		}

		public void CmdDebugMarkerEndEXT ()
		{
			unsafe {
				Interop.NativeMethods.vkCmdDebugMarkerEndEXT (this.m);
			}
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerInsertEXT ()
		{
			DebugMarkerMarkerInfoExt pMarkerInfo;
			unsafe {
				pMarkerInfo = new DebugMarkerMarkerInfoExt ();
				Interop.NativeMethods.vkCmdDebugMarkerInsertEXT (this.m, pMarkerInfo.m);

				return pMarkerInfo;
			}
		}
	}

	public partial class DeviceMemory
	{
		internal UInt64 m;
	}

	public partial class CommandPool
	{
		internal UInt64 m;
	}

	public partial class Buffer
	{
		internal UInt64 m;
	}

	public partial class BufferView
	{
		internal UInt64 m;
	}

	public partial class Image
	{
		internal UInt64 m;
	}

	public partial class ImageView
	{
		internal UInt64 m;
	}

	public partial class ShaderModule
	{
		internal UInt64 m;
	}

	public partial class Pipeline
	{
		internal UInt64 m;
	}

	public partial class PipelineLayout
	{
		internal UInt64 m;
	}

	public partial class Sampler
	{
		internal UInt64 m;
	}

	public partial class DescriptorSet
	{
		internal UInt64 m;
	}

	public partial class DescriptorSetLayout
	{
		internal UInt64 m;
	}

	public partial class DescriptorPool
	{
		internal UInt64 m;
	}

	public partial class Fence
	{
		internal UInt64 m;
	}

	public partial class Semaphore
	{
		internal UInt64 m;
	}

	public partial class Event
	{
		internal UInt64 m;
	}

	public partial class QueryPool
	{
		internal UInt64 m;
	}

	public partial class Framebuffer
	{
		internal UInt64 m;
	}

	public partial class RenderPass
	{
		internal UInt64 m;
	}

	public partial class PipelineCache
	{
		internal UInt64 m;
	}

	public partial class DisplayKhr
	{
		internal UInt64 m;
	}

	public partial class DisplayModeKhr
	{
		internal UInt64 m;
	}

	public partial class SurfaceKhr
	{
		public UInt64 m;
	}

	public partial class SwapchainKhr
	{
		internal UInt64 m;
	}

	public partial class DebugReportCallbackExt
	{
		internal UInt64 m;
	}
}
