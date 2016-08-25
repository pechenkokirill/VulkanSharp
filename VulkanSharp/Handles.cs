using System;
using System.Linq;
using System.Runtime.InteropServices;
using VulkanSharp.Interop;

namespace VulkanSharp
{
	// ReSharper disable InconsistentNaming
	public partial class Instance
	{
		protected IntPtr _handle;
		public IntPtr Handle => _handle;

		public DebugReportCallbackExt CreateDebugReportCallbackEXT(DebugReportCallbackCreateInfoExt pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pCallback = new DebugReportCallbackExt();

				Result result;
				fixed (ulong* ptrpCallback = &pCallback._handle) result = NativeMethods.vkCreateDebugReportCallbackEXT(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpCallback);
				if (result != Result.Success) throw new ResultException(result);

				return pCallback;
			}
		}

		public SurfaceKhr CreateDisplayPlaneSurfaceKHR(DisplaySurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pSurface = new SurfaceKhr();

				Result result;
				fixed (ulong* ptrpSurface = &pSurface._handle) result = NativeMethods.vkCreateDisplayPlaneSurfaceKHR(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSurface);
				if (result != Result.Success) throw new ResultException(result);

				return pSurface;
			}
		}

		public void DebugReportMessageEXT(DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, ulong @object, UIntPtr location, int messageCode, string pLayerPrefix, string pMessage) {
			NativeMethods.vkDebugReportMessageEXT(_handle, flags, objectType, @object, location, messageCode, pLayerPrefix, pMessage);
		}

		public void Destroy(AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyInstance(_handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDebugReportCallbackEXT(DebugReportCallbackExt callback, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyDebugReportCallbackEXT(_handle, callback._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySurfaceKHR(SurfaceKhr surface, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroySurfaceKHR(_handle, surface._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public PhysicalDevice[] EnumeratePhysicalDevices() {
			unsafe {
				uint pPhysicalDeviceCount;
				var result = NativeMethods.vkEnumeratePhysicalDevices(_handle, &pPhysicalDeviceCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPhysicalDeviceCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(IntPtr));
				var ptrpPhysicalDevices = Marshal.AllocHGlobal((int)(size * pPhysicalDeviceCount));
				result = NativeMethods.vkEnumeratePhysicalDevices(_handle, &pPhysicalDeviceCount, (IntPtr*)ptrpPhysicalDevices);
				if (result != Result.Success) throw new ResultException(result);

				if (pPhysicalDeviceCount <= 0) return null;
				var arr = new PhysicalDevice[pPhysicalDeviceCount];
				for (var i = 0; i < pPhysicalDeviceCount; i++) {
					arr[i] = new PhysicalDevice(((IntPtr*)ptrpPhysicalDevices)[i]);
				}

				return arr;
			}
		}

		public IntPtr GetProcAddr(string pName) {
			return NativeMethods.vkGetInstanceProcAddr(_handle, pName);
		}
	}

	public class PhysicalDevice
	{
		protected IntPtr _handle;

		public IntPtr Handle => _handle;

		public PhysicalDevice(IntPtr handle) {
			_handle = handle;
		}

		public Device CreateDevice(DeviceCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pDevice = new Device();

				Result result;
				fixed (IntPtr* ptrpDevice = &pDevice._handle) result = NativeMethods.vkCreateDevice(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpDevice);
				if (result != Result.Success) throw new ResultException(result);

				return pDevice;
			}
		}

		public DisplayModeKhr CreateDisplayModeKHR(DisplayKhr display, DisplayModeCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pMode = new DisplayModeKhr();

				Result result;
				fixed (ulong* ptrpMode = &pMode._handle) result = NativeMethods.vkCreateDisplayModeKHR(_handle, display._handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpMode);
				if (result != Result.Success) throw new ResultException(result);

				return pMode;
			}
		}

		public ExtensionProperties[] EnumerateDeviceExtensionProperties(string pLayerName) {
			unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkEnumerateDeviceExtensionProperties(_handle, pLayerName, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkEnumerateDeviceExtensionProperties(_handle, pLayerName, &pPropertyCount, (Interop.ExtensionProperties*)ptrpProperties);
				if (result != Result.Success) throw new ResultException(result);

				if (pPropertyCount <= 0) return null;
				var arr = new ExtensionProperties[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = new ExtensionProperties(&((Interop.ExtensionProperties*)ptrpProperties)[i]);
				}

				return arr;
			}
		}

		public LayerProperties[] EnumerateDeviceLayerProperties() {
			unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkEnumerateDeviceLayerProperties(_handle, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.LayerProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkEnumerateDeviceLayerProperties(_handle, &pPropertyCount, (Interop.LayerProperties*)ptrpProperties);
				if (result != Result.Success) throw new ResultException(result);

				if (pPropertyCount <= 0) return null;
				var arr = new LayerProperties[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = new LayerProperties(&((Interop.LayerProperties*)ptrpProperties)[i]);
				}

				return arr;
			}
		}

		public DisplayModePropertiesKhr[] GetDisplayModePropertiesKHR(DisplayKhr display) {
			unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkGetDisplayModePropertiesKHR(_handle, display._handle, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayModePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetDisplayModePropertiesKHR(_handle, display._handle, &pPropertyCount, (Interop.DisplayModePropertiesKhr*)ptrpProperties);
				if (result != Result.Success) throw new ResultException(result);

				if (pPropertyCount <= 0) return null;
				var arr = new DisplayModePropertiesKhr[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = new DisplayModePropertiesKhr(&((Interop.DisplayModePropertiesKhr*)ptrpProperties)[i]);
				}

				return arr;
			}
		}

		public DisplayPlaneCapabilitiesKhr GetDisplayPlaneCapabilitiesKHR(DisplayModeKhr mode, uint planeIndex) {
		    unsafe {
				var pCapabilities = new DisplayPlaneCapabilitiesKhr();
				var result = NativeMethods.vkGetDisplayPlaneCapabilitiesKHR(_handle, mode._handle, planeIndex, &pCapabilities);
				if (result != Result.Success) throw new ResultException(result);

				return pCapabilities;
			}
		}

		public DisplayPlanePropertiesKhr[] GetDisplayPlanePropertiesKHR() {
		    unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR(_handle, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayPlanePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR(_handle, &pPropertyCount, (Interop.DisplayPlanePropertiesKhr*)ptrpProperties);
				if (result != Result.Success) throw new ResultException(result);

				if (pPropertyCount <= 0) return null;
				var arr = new DisplayPlanePropertiesKhr[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = new DisplayPlanePropertiesKhr(&((Interop.DisplayPlanePropertiesKhr*)ptrpProperties)[i]);
				}

				return arr;
			}
		}

		public DisplayKhr[] GetDisplayPlaneSupportedDisplaysKHR(uint planeIndex) {
		    unsafe {
				uint pDisplayCount;
				var result = NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR(_handle, planeIndex, &pDisplayCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pDisplayCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpDisplays = Marshal.AllocHGlobal((int)(size * pDisplayCount));
				result = NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR(_handle, planeIndex, &pDisplayCount, (ulong*)ptrpDisplays);
				if (result != Result.Success) throw new ResultException(result);

				if (pDisplayCount <= 0) return null;
				var arr = new DisplayKhr[pDisplayCount];
				for (var i = 0; i < pDisplayCount; i++) {
					arr[i] = new DisplayKhr();
					arr[i]._handle = ((ulong*)ptrpDisplays)[i];
				}

				return arr;
			}
		}

		public DisplayPropertiesKhr[] GetDisplayPropertiesKHR() {
		    unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR(_handle, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayPropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR(_handle, &pPropertyCount, (Interop.DisplayPropertiesKhr*)ptrpProperties);
				if (result != Result.Success) throw new ResultException(result);

				if (pPropertyCount <= 0) return null;
				var arr = new DisplayPropertiesKhr[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = new DisplayPropertiesKhr(&((Interop.DisplayPropertiesKhr*)ptrpProperties)[i]);
				}

				return arr;
			}
		}

		public PhysicalDeviceFeatures GetFeatures() {
		    unsafe {
				var pFeatures = new PhysicalDeviceFeatures();
				NativeMethods.vkGetPhysicalDeviceFeatures(_handle, &pFeatures);
				return pFeatures;
			}
		}

		public FormatProperties GetFormatProperties(Format format) {
		    unsafe {
				var pFormatProperties = new FormatProperties();
				NativeMethods.vkGetPhysicalDeviceFormatProperties(_handle, format, &pFormatProperties);
				return pFormatProperties;
			}
		}

		public ImageFormatProperties GetImageFormatProperties(Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags) {
		    unsafe {
				var pImageFormatProperties = new ImageFormatProperties();
				var result = NativeMethods.vkGetPhysicalDeviceImageFormatProperties(_handle, format, type, tiling, usage, flags, &pImageFormatProperties);
				if (result != Result.Success) throw new ResultException(result);
				return pImageFormatProperties;
			}
		}

		public PhysicalDeviceMemoryProperties GetMemoryProperties() {
		    unsafe {
				var pMemoryProperties = new PhysicalDeviceMemoryProperties();
				NativeMethods.vkGetPhysicalDeviceMemoryProperties(_handle, pMemoryProperties._handle);

				return pMemoryProperties;
			}
		}

		public PhysicalDeviceProperties GetProperties() {
		    unsafe {
				var pProperties = new PhysicalDeviceProperties();
				NativeMethods.vkGetPhysicalDeviceProperties(_handle, pProperties._handle);

				return pProperties;
			}
		}

		public QueueFamilyProperties[] GetQueueFamilyProperties() {
			unsafe {
				uint pQueueFamilyPropertyCount;
				NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties(_handle, &pQueueFamilyPropertyCount, null);
				if (pQueueFamilyPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(QueueFamilyProperties));
				var ptrpQueueFamilyProperties = Marshal.AllocHGlobal((int)(size * pQueueFamilyPropertyCount));
				NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties(_handle, &pQueueFamilyPropertyCount, (QueueFamilyProperties*)ptrpQueueFamilyProperties);

				if (pQueueFamilyPropertyCount <= 0) return null;
				var arr = new QueueFamilyProperties[pQueueFamilyPropertyCount];
				for (var i = 0; i < pQueueFamilyPropertyCount; i++) {
					arr[i] = ((QueueFamilyProperties*)ptrpQueueFamilyProperties)[i];
				}

				return arr;
			}
		}

		public SparseImageFormatProperties[] GetSparseImageFormatProperties(Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling) {
			unsafe {
				uint pPropertyCount;
				NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties(_handle, format, type, samples, usage, tiling, &pPropertyCount, null);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SparseImageFormatProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties(_handle, format, type, samples, usage, tiling, &pPropertyCount, (SparseImageFormatProperties*)ptrpProperties);

				if (pPropertyCount <= 0) return null;
				var arr = new SparseImageFormatProperties[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = ((SparseImageFormatProperties*)ptrpProperties)[i];
				}

				return arr;
			}
		}

		public SurfaceCapabilitiesKhr GetSurfaceCapabilitiesKHR(SurfaceKhr surface) {
		    unsafe {
				var pSurfaceCapabilities = new SurfaceCapabilitiesKhr();
				var result = NativeMethods.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_handle, surface._handle, &pSurfaceCapabilities);
				if (result != Result.Success) throw new ResultException(result);

				return pSurfaceCapabilities;
			}
		}

		public SurfaceFormatKhr[] GetSurfaceFormatsKHR(SurfaceKhr surface) {
		    unsafe {
				uint pSurfaceFormatCount;
				var result = NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR(_handle, surface._handle, &pSurfaceFormatCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pSurfaceFormatCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SurfaceFormatKhr));
				var ptrpSurfaceFormats = Marshal.AllocHGlobal((int)(size * pSurfaceFormatCount));
				result = NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR(_handle, surface._handle, &pSurfaceFormatCount, (SurfaceFormatKhr*)ptrpSurfaceFormats);
				if (result != Result.Success) throw new ResultException(result);

				if (pSurfaceFormatCount <= 0) return null;
				var arr = new SurfaceFormatKhr[pSurfaceFormatCount];
				for (var i = 0; i < pSurfaceFormatCount; i++) {
					arr[i] = ((SurfaceFormatKhr*)ptrpSurfaceFormats)[i];
				}

				return arr;
			}
		}

		public PresentModeKhr[] GetSurfacePresentModesKHR(SurfaceKhr surface) {
		    unsafe {
				uint pPresentModeCount;
				var result = NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR(_handle, surface._handle, &pPresentModeCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPresentModeCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(int));
				//var size = Marshal.SizeOf(typeof(PresentModeKhr));
				var ptrpPresentModes = Marshal.AllocHGlobal((int)(size * pPresentModeCount));
				result = NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR(_handle, surface._handle, &pPresentModeCount, (PresentModeKhr*)ptrpPresentModes);
				if (result != Result.Success) throw new ResultException(result);

				if (pPresentModeCount <= 0) return null;
				var arr = new PresentModeKhr[pPresentModeCount];
				for (var i = 0; i < pPresentModeCount; i++) {
					arr[i] = new PresentModeKhr();
					arr[i] = ((PresentModeKhr*)ptrpPresentModes)[i];
				}

				return arr;
			}
		}

		public Bool32 GetSurfaceSupportKHR(uint queueFamilyIndex, SurfaceKhr surface) {
		    unsafe {
				var pSupported = new Bool32();
				var result = NativeMethods.vkGetPhysicalDeviceSurfaceSupportKHR(_handle, queueFamilyIndex, surface._handle, &pSupported);
				if (result != Result.Success) throw new ResultException(result);

				return pSupported;
			}
		}
	}

	public partial class Device
	{
		public IntPtr _handle;

		public uint AcquireNextImageKHR(SwapchainKhr swapchain, TimeSpan timeout, Semaphore semaphore = null, Fence fence = null) {
			return AcquireNextImageKHR(swapchain, (ulong)timeout.Ticks * 100, semaphore, fence);
		}
		
		/// <summary>
		/// </summary>
		/// <param name="swapchain"></param>
		/// <param name="timeout">In nanoseconds</param>
		/// <param name="semaphore"></param>
		/// <param name="fence"></param>
		/// <returns></returns>
		public uint AcquireNextImageKHR(SwapchainKhr swapchain, ulong timeout, Semaphore semaphore = null, Fence fence = null) {
			unsafe {
				var pImageIndex = new uint();
				var result = NativeMethods.vkAcquireNextImageKHR(_handle, swapchain._handle, timeout, semaphore?._handle ?? 0, fence?._handle ?? 0, &pImageIndex);
				if (result != Result.Success) throw new ResultException(result);

				return pImageIndex;
			}
		}

		public CommandBuffer[] AllocateCommandBuffers(CommandBufferAllocateInfo pAllocateInfo) {
		    unsafe {
				if (pAllocateInfo.CommandBufferCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(IntPtr));
				var ptrpCommandBuffers = Marshal.AllocHGlobal((int)(size * pAllocateInfo.CommandBufferCount));
				var result = NativeMethods.vkAllocateCommandBuffers(_handle, pAllocateInfo._handle, (IntPtr*)ptrpCommandBuffers);
				if (result != Result.Success) throw new ResultException(result);

				if (pAllocateInfo.CommandBufferCount <= 0) return null;
				var arr = new CommandBuffer[pAllocateInfo.CommandBufferCount];
				for (var i = 0; i < pAllocateInfo.CommandBufferCount; i++) {
					arr[i] = new CommandBuffer();
					arr[i]._handle = ((IntPtr*)ptrpCommandBuffers)[i];
				}

				return arr;
			}
		}

		public DescriptorSet[] AllocateDescriptorSets(DescriptorSetAllocateInfo pAllocateInfo) {
		    unsafe {
				if (pAllocateInfo.DescriptorSetCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpDescriptorSets = Marshal.AllocHGlobal((int)(size * pAllocateInfo.DescriptorSetCount));
				var result = NativeMethods.vkAllocateDescriptorSets(_handle, pAllocateInfo._handle, (ulong*)ptrpDescriptorSets);
				if (result != Result.Success) throw new ResultException(result);

				if (pAllocateInfo.DescriptorSetCount <= 0) return null;
				var arr = new DescriptorSet[pAllocateInfo.DescriptorSetCount];
				for (var i = 0; i < pAllocateInfo.DescriptorSetCount; i++) {
				    arr[i] = new DescriptorSet {
				        _handle = ((ulong*)ptrpDescriptorSets)[i]
				    };
				}

				return arr;
			}
		}

		public DeviceMemory AllocateMemory(MemoryAllocateInfo pAllocateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pMemory = new DeviceMemory();

				Result result;
				fixed (ulong* ptrpMemory = &pMemory._handle) result = NativeMethods.vkAllocateMemory(_handle, pAllocateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpMemory);
				if (result != Result.Success) throw new ResultException(result);

				return pMemory;
			}
		}

		public void BindBufferMemory(Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset) {
			var result = NativeMethods.vkBindBufferMemory(_handle, buffer._handle, memory._handle, memoryOffset);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void BindImageMemory(Image image, DeviceMemory memory, DeviceSize memoryOffset) {
			var result = NativeMethods.vkBindImageMemory(_handle, image._handle, memory._handle, memoryOffset);
			if (result != Result.Success) throw new ResultException(result);
		}

		public Buffer CreateBuffer(BufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
			unsafe {
				var pBuffer = new Buffer();

				Result result;
				fixed (ulong* ptrpBuffer = &pBuffer._handle) result = NativeMethods.vkCreateBuffer(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpBuffer);
				if (result != Result.Success) throw new ResultException(result);

				return pBuffer;
			}
		}

		public BufferView CreateBufferView(BufferViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pView = new BufferView();

		        Result result;
		        fixed (ulong* ptrpView = &pView._handle) result = NativeMethods.vkCreateBufferView(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				if (result != Result.Success) throw new ResultException(result);

				return pView;
			}
		}

		public CommandPool CreateCommandPool(CommandPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pCommandPool = new CommandPool();

		        Result result;
		        fixed (ulong* ptrpCommandPool = &pCommandPool._handle) result = NativeMethods.vkCreateCommandPool(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpCommandPool);
				if (result != Result.Success) throw new ResultException(result);

				return pCommandPool;
			}
		}

		public Pipeline[] CreateComputePipelines(PipelineCache pipelineCache, uint createInfoCount, ComputePipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator = null) {
		    unsafe {
				if (createInfoCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpPipelines = Marshal.AllocHGlobal((int)(size * createInfoCount));
				var result = NativeMethods.vkCreateComputePipelines(_handle, pipelineCache._handle, createInfoCount, pCreateInfos._handle, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpPipelines);
				if (result != Result.Success) throw new ResultException(result);

				if (createInfoCount <= 0) return null;
				var arr = new Pipeline[createInfoCount];
				for (var i = 0; i < createInfoCount; i++) {
					arr[i] = new Pipeline();
					arr[i]._handle = ((ulong*)ptrpPipelines)[i];
				}

				return arr;
			}
		}

		public DescriptorPool CreateDescriptorPool(DescriptorPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pDescriptorPool = new DescriptorPool();

		        Result result;
		        fixed (ulong* ptrpDescriptorPool = &pDescriptorPool._handle) result = NativeMethods.vkCreateDescriptorPool(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpDescriptorPool);
				if (result != Result.Success) throw new ResultException(result);

				return pDescriptorPool;
			}
		}

		public DescriptorSetLayout CreateDescriptorSetLayout(DescriptorSetLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pSetLayout = new DescriptorSetLayout();

		        Result result;
		        fixed (ulong* ptrpSetLayout = &pSetLayout._handle) result = NativeMethods.vkCreateDescriptorSetLayout(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSetLayout);
				if (result != Result.Success) throw new ResultException(result);

				return pSetLayout;
			}
		}

		public Event CreateEvent(EventCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pEvent = new Event();

		        Result result;
		        fixed (ulong* ptrpEvent = &pEvent._handle) result = NativeMethods.vkCreateEvent(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpEvent);
				if (result != Result.Success) throw new ResultException(result);

				return pEvent;
			}
		}

		public Fence CreateFence(FenceCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pFence = new Fence();

		        Result result;
		        fixed (ulong* ptrpFence = &pFence._handle) result = NativeMethods.vkCreateFence(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpFence);
				if (result != Result.Success) throw new ResultException(result);

				return pFence;
			}
		}

		public Framebuffer CreateFramebuffer(FramebufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pFramebuffer = new Framebuffer();

		        Result result;
		        fixed (ulong* ptrpFramebuffer = &pFramebuffer._handle) result = NativeMethods.vkCreateFramebuffer(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpFramebuffer);
				if (result != Result.Success) throw new ResultException(result);

				return pFramebuffer;
			}
		}

		public Pipeline[] CreateGraphicsPipelines(PipelineCache pipelineCache, uint createInfoCount, GraphicsPipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator = null) {
		    unsafe {
				if (createInfoCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpPipelines = Marshal.AllocHGlobal((int)(size * createInfoCount));
				var result = NativeMethods.vkCreateGraphicsPipelines(_handle, pipelineCache._handle, createInfoCount, pCreateInfos._handle, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpPipelines);
				if (result != Result.Success) throw new ResultException(result);

				if (createInfoCount <= 0) return null;
				var arr = new Pipeline[createInfoCount];
				for (var i = 0; i < createInfoCount; i++) {
				    arr[i] = new Pipeline {
				        _handle = ((ulong*)ptrpPipelines)[i]
				    };
				}

				return arr;
			}
		}

		public Image CreateImage(ImageCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pImage = new Image();

		        Result result;
		        fixed (ulong* ptrpImage = &pImage._handle) result = NativeMethods.vkCreateImage(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpImage);
				if (result != Result.Success) throw new ResultException(result);

				return pImage;
			}
		}

		public ImageView CreateImageView(ImageViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pView = new ImageView();

		        Result result;
		        fixed (ulong* ptrpView = &pView._handle) result = NativeMethods.vkCreateImageView(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				if (result != Result.Success) throw new ResultException(result);

				return pView;
			}
		}

		public PipelineCache CreatePipelineCache(PipelineCacheCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pPipelineCache = new PipelineCache();

		        Result result;
		        fixed (ulong* ptrpPipelineCache = &pPipelineCache._handle) result = NativeMethods.vkCreatePipelineCache(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineCache);
				if (result != Result.Success) throw new ResultException(result);

				return pPipelineCache;
			}
		}

		public PipelineLayout CreatePipelineLayout(PipelineLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pPipelineLayout = new PipelineLayout();

		        Result result;
		        fixed (ulong* ptrpPipelineLayout = &pPipelineLayout._handle) result = NativeMethods.vkCreatePipelineLayout(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineLayout);
				if (result != Result.Success) throw new ResultException(result);

				return pPipelineLayout;
			}
		}

		public QueryPool CreateQueryPool(QueryPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pQueryPool = new QueryPool();

		        Result result;
		        fixed (ulong* ptrpQueryPool = &pQueryPool._handle) result = NativeMethods.vkCreateQueryPool(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpQueryPool);
				if (result != Result.Success) throw new ResultException(result);

				return pQueryPool;
			}
		}

		public RenderPass CreateRenderPass(RenderPassCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pRenderPass = new RenderPass();

		        Result result;
		        fixed (ulong* ptrpRenderPass = &pRenderPass._handle) result = NativeMethods.vkCreateRenderPass(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpRenderPass);
				if (result != Result.Success) throw new ResultException(result);

				return pRenderPass;
			}
		}

		public Sampler CreateSampler(SamplerCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pSampler = new Sampler();

		        Result result;
		        fixed (ulong* ptrpSampler = &pSampler._handle) result = NativeMethods.vkCreateSampler(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSampler);
				if (result != Result.Success) throw new ResultException(result);

				return pSampler;
			}
		}

		public Semaphore CreateSemaphore(SemaphoreCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pSemaphore = new Semaphore();

		        Result result;
		        fixed (ulong* ptrpSemaphore = &pSemaphore._handle) result = NativeMethods.vkCreateSemaphore(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSemaphore);
				if (result != Result.Success) throw new ResultException(result);

				return pSemaphore;
			}
		}

		public ShaderModule CreateShaderModule(ShaderModuleCreateInfo pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pShaderModule = new ShaderModule();

		        Result result;
		        fixed (ulong* ptrpShaderModule = &pShaderModule._handle) result = NativeMethods.vkCreateShaderModule(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpShaderModule);
				if (result != Result.Success) throw new ResultException(result);

				return pShaderModule;
			}
		}

		public SwapchainKhr[] CreateSharedSwapchainsKHR(uint swapchainCount, SwapchainCreateInfoKhr pCreateInfos, AllocationCallbacks pAllocator = null) {
		    unsafe {
				if (swapchainCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpSwapchains = Marshal.AllocHGlobal((int)(size * swapchainCount));
				var result = NativeMethods.vkCreateSharedSwapchainsKHR(_handle, swapchainCount, pCreateInfos._handle, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpSwapchains);
				if (result != Result.Success) throw new ResultException(result);

				if (swapchainCount <= 0) return null;
				var arr = new SwapchainKhr[swapchainCount];
				for (var i = 0; i < swapchainCount; i++) {
					arr[i] = new SwapchainKhr();
					arr[i]._handle = ((ulong*)ptrpSwapchains)[i];
				}

				return arr;
			}
		}

		public SwapchainKhr CreateSwapchainKHR(SwapchainCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator = null) {
		    unsafe {
				var pSwapchain = new SwapchainKhr();
		        Result result;
		        fixed (ulong* ptrpSwapchain = &pSwapchain._handle) result = NativeMethods.vkCreateSwapchainKHR(_handle, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpSwapchain);
				if (result != Result.Success) throw new ResultException(result);
				return pSwapchain;
			}
		}

		public DebugMarkerObjectNameInfoExt DebugMarkerSetObjectNameEXT() {
		    unsafe {
				var pNameInfo = new DebugMarkerObjectNameInfoExt();
				var result = NativeMethods.vkDebugMarkerSetObjectNameEXT(_handle, pNameInfo._handle);
				if (result != Result.Success) throw new ResultException(result);
				return pNameInfo;
			}
		}

		public DebugMarkerObjectTagInfoExt DebugMarkerSetObjectTagEXT() {
		    unsafe {
				var pTagInfo = new DebugMarkerObjectTagInfoExt();
				var result = NativeMethods.vkDebugMarkerSetObjectTagEXT(_handle, pTagInfo._handle);
				if (result != Result.Success) throw new ResultException(result);

				return pTagInfo;
			}
		}

		public void Destroy(AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyDevice(_handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyBuffer(Buffer buffer, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyBuffer(_handle, buffer._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyBufferView(BufferView bufferView, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyBufferView(_handle, bufferView._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyCommandPool(CommandPool commandPool, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyCommandPool(_handle, commandPool._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDescriptorPool(DescriptorPool descriptorPool, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyDescriptorPool(_handle, descriptorPool._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDescriptorSetLayout(DescriptorSetLayout descriptorSetLayout, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyDescriptorSetLayout(_handle, descriptorSetLayout._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyEvent(Event @event, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyEvent(_handle, @event._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyFence(Fence fence, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyFence(_handle, fence._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyFramebuffer(Framebuffer framebuffer, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyFramebuffer(_handle, framebuffer._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyImage(Image image, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyImage(_handle, image._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyImageView(ImageView imageView, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyImageView(_handle, imageView._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipeline(Pipeline pipeline, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyPipeline(_handle, pipeline._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipelineCache(PipelineCache pipelineCache, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyPipelineCache(_handle, pipelineCache._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipelineLayout(PipelineLayout pipelineLayout, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyPipelineLayout(_handle, pipelineLayout._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyQueryPool(QueryPool queryPool, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyQueryPool(_handle, queryPool._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyRenderPass(RenderPass renderPass, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyRenderPass(_handle, renderPass._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySampler(Sampler sampler, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroySampler(_handle, sampler._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySemaphore(Semaphore semaphore, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroySemaphore(_handle, semaphore._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyShaderModule(ShaderModule shaderModule, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroyShaderModule(_handle, shaderModule._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySwapchainKHR(SwapchainKhr swapchain, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkDestroySwapchainKHR(_handle, swapchain._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void FlushMappedMemoryRanges(uint memoryRangeCount, MappedMemoryRange pMemoryRanges) {
		    unsafe {
			    var result = NativeMethods.vkFlushMappedMemoryRanges(_handle, memoryRangeCount, pMemoryRanges._handle);
			    if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void FreeCommandBuffers(CommandPool commandPool, uint commandBufferCount, CommandBuffer pCommandBuffers) {
			unsafe {
				fixed (IntPtr* ptrpCommandBuffers = &pCommandBuffers._handle) NativeMethods.vkFreeCommandBuffers(_handle, commandPool._handle, commandBufferCount, ptrpCommandBuffers);
			}
		}

		public void FreeDescriptorSets(DescriptorPool descriptorPool, uint descriptorSetCount, DescriptorSet pDescriptorSets) {
		    unsafe {
			    Result result;
			    fixed (ulong* ptrpDescriptorSets = &pDescriptorSets._handle) result = NativeMethods.vkFreeDescriptorSets(_handle, descriptorPool._handle, descriptorSetCount, ptrpDescriptorSets);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void FreeMemory(DeviceMemory memory, AllocationCallbacks pAllocator = null) {
			unsafe {
				NativeMethods.vkFreeMemory(_handle, memory._handle, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public MemoryRequirements GetBufferMemoryRequirements(Buffer buffer) {
		    unsafe {
				var pMemoryRequirements = new MemoryRequirements();
				NativeMethods.vkGetBufferMemoryRequirements(_handle, buffer._handle, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public void GetEventStatus(Event @event) {
		    var result = NativeMethods.vkGetEventStatus(_handle, @event._handle);
		    if (result != Result.Success) throw new ResultException(result);
		}

	    public void GetFenceStatus(Fence fence) {
		    var result = NativeMethods.vkGetFenceStatus(_handle, fence._handle);
		    if (result != Result.Success) throw new ResultException(result);
		}

	    public MemoryRequirements GetImageMemoryRequirements(Image image) {
		    unsafe {
				var pMemoryRequirements = new MemoryRequirements();
				NativeMethods.vkGetImageMemoryRequirements(_handle, image._handle, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public SparseImageMemoryRequirements[] GetImageSparseMemoryRequirements(Image image) {
			unsafe {
				uint pSparseMemoryRequirementCount;
				NativeMethods.vkGetImageSparseMemoryRequirements(_handle, image._handle, &pSparseMemoryRequirementCount, null);
				if (pSparseMemoryRequirementCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SparseImageMemoryRequirements));
				var ptrpSparseMemoryRequirements = Marshal.AllocHGlobal((int)(size * pSparseMemoryRequirementCount));
				NativeMethods.vkGetImageSparseMemoryRequirements(_handle, image._handle, &pSparseMemoryRequirementCount, (SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements);

				if (pSparseMemoryRequirementCount <= 0) return null;
				var arr = new SparseImageMemoryRequirements[pSparseMemoryRequirementCount];
				for (var i = 0; i < pSparseMemoryRequirementCount; i++) {
					arr[i] = ((SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements)[i];
				}

				return arr;
			}
		}

		public SubresourceLayout GetImageSubresourceLayout(Image image, ImageSubresource pSubresource) {
		    unsafe {
				var pLayout = new SubresourceLayout();
				NativeMethods.vkGetImageSubresourceLayout(_handle, image._handle, &pSubresource, &pLayout);

				return pLayout;
			}
		}

		public DeviceSize GetMemoryCommitment(DeviceMemory memory) {
		    unsafe {
				var pCommittedMemoryInBytes = new DeviceSize();
				NativeMethods.vkGetDeviceMemoryCommitment(_handle, memory._handle, &pCommittedMemoryInBytes);

				return pCommittedMemoryInBytes;
			}
		}

		public void GetPipelineCacheData(PipelineCache pipelineCache, out UIntPtr pDataSize, IntPtr pData) {
		    unsafe {
			    Result result;
			    fixed (UIntPtr* ptrpDataSize = &pDataSize) result = NativeMethods.vkGetPipelineCacheData(_handle, pipelineCache._handle, ptrpDataSize, pData);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public IntPtr GetProcAddr(string pName) {
			return NativeMethods.vkGetDeviceProcAddr(_handle, pName);
		}

		public IntPtr GetQueryPoolResults(QueryPool queryPool, uint firstQuery, uint queryCount, UIntPtr dataSize, DeviceSize stride, QueryResultFlags flags) {
		    var pData = new IntPtr();
			var result = NativeMethods.vkGetQueryPoolResults(_handle, queryPool._handle, firstQuery, queryCount, dataSize, pData, stride, flags);
			if (result != Result.Success) throw new ResultException(result);

			return pData;
		}

		public Queue GetQueue(uint queueFamilyIndex, uint queueIndex) {
		    unsafe {
				var pQueue = new Queue();

				fixed (IntPtr* ptrpQueue = &pQueue._handle) NativeMethods.vkGetDeviceQueue(_handle, queueFamilyIndex, queueIndex, ptrpQueue);

				return pQueue;
			}
		}

		public Extent2D GetRenderAreaGranularity(RenderPass renderPass) {
		    unsafe {
				var pGranularity = new Extent2D();
				NativeMethods.vkGetRenderAreaGranularity(_handle, renderPass._handle, &pGranularity);

				return pGranularity;
			}
		}

		public Image[] GetSwapchainImagesKHR(SwapchainKhr swapchain) {
		    unsafe {
				uint pSwapchainImageCount;
				var result = NativeMethods.vkGetSwapchainImagesKHR(_handle, swapchain._handle, &pSwapchainImageCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pSwapchainImageCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpSwapchainImages = Marshal.AllocHGlobal((int)(size * pSwapchainImageCount));
				result = NativeMethods.vkGetSwapchainImagesKHR(_handle, swapchain._handle, &pSwapchainImageCount, (ulong*)ptrpSwapchainImages);
				if (result != Result.Success) throw new ResultException(result);

				if (pSwapchainImageCount <= 0) return null;
				var arr = new Image[pSwapchainImageCount];
				for (var i = 0; i < pSwapchainImageCount; i++) {
				    arr[i] = new Image {
				        _handle = ((ulong*)ptrpSwapchainImages)[i]
				    };
				}

				return arr;
			}
		}

		public void InvalidateMappedMemoryRanges(uint memoryRangeCount, MappedMemoryRange pMemoryRanges) {
		    unsafe {
			    var result = NativeMethods.vkInvalidateMappedMemoryRanges(_handle, memoryRangeCount, pMemoryRanges._handle);
			    if (result != Result.Success) throw new ResultException(result);
			}
		}

		public IntPtr MapMemory(DeviceMemory memory, DeviceSize offset, DeviceSize size, uint flags) {
		    unsafe {
				var ppData = new IntPtr();
				var result = NativeMethods.vkMapMemory(_handle, memory._handle, offset, size, flags, &ppData);
				if (result != Result.Success) throw new ResultException(result);

				return ppData;
			}
		}

		public void MergePipelineCaches(PipelineCache dstCache, uint srcCacheCount, PipelineCache pSrcCaches) {
		    unsafe {
			    Result result;
			    fixed (ulong* ptrpSrcCaches = &pSrcCaches._handle) result = NativeMethods.vkMergePipelineCaches(_handle, dstCache._handle, srcCacheCount, ptrpSrcCaches);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void ResetCommandPool(CommandPool commandPool, CommandPoolResetFlags flags) {
		    var result = NativeMethods.vkResetCommandPool(_handle, commandPool._handle, flags);
		    if (result != Result.Success) throw new ResultException(result);
		}

	    public void ResetDescriptorPool(DescriptorPool descriptorPool, uint flags) {
	        var result = NativeMethods.vkResetDescriptorPool(_handle, descriptorPool._handle, flags);
	        if (result != Result.Success) throw new ResultException(result);
	    }

	    public void ResetEvent(Event @event) {
	        var result = NativeMethods.vkResetEvent(_handle, @event._handle);
	        if (result != Result.Success) throw new ResultException(result);
	    }

	    public void ResetFences(uint fenceCount, Fence pFences) {
		    unsafe {
			    Result result;
			    fixed (ulong* ptrpFences = &pFences._handle) result = NativeMethods.vkResetFences(_handle, fenceCount, ptrpFences);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void SetEvent(Event @event) {
		    var result = NativeMethods.vkSetEvent(_handle, @event._handle);
		    if (result != Result.Success) throw new ResultException(result);
		}

	    public void UnmapMemory(DeviceMemory memory) {
			NativeMethods.vkUnmapMemory(_handle, memory._handle);
		}

		public void UpdateDescriptorSets(WriteDescriptorSet[] descriptorWrites, CopyDescriptorSet[] descriptorCopies) {
			unsafe {
			    var writeCount = (uint)(descriptorWrites?.Length ?? 0);
                var copyCount = (uint)(descriptorCopies?.Length ?? 0);

                // Can't get pointer of zero-length or null array.
                var writeHandles = writeCount != 0 ? descriptorWrites.Select(d => *d._handle).ToArray() : new Interop.WriteDescriptorSet[1];
                var copyHandles = copyCount != 0 ? descriptorCopies.Select(d => *d._handle).ToArray() : new Interop.CopyDescriptorSet[1];

                fixed (Interop.WriteDescriptorSet* writeSet = &writeHandles[0] )
                fixed (Interop.CopyDescriptorSet* copySet = &copyHandles[0])
                {
                    NativeMethods.vkUpdateDescriptorSets(_handle, writeCount, writeSet, copyCount, copySet);
                }
			}
		}

		public void WaitForFences(uint fenceCount, Fence pFences, Bool32 waitAll, ulong timeout) {
		    unsafe {
			    Result result;
			    fixed (ulong* ptrpFences = &pFences._handle) result = NativeMethods.vkWaitForFences(_handle, fenceCount, ptrpFences, waitAll, timeout);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void WaitIdle() {
		    var result = NativeMethods.vkDeviceWaitIdle(_handle);
		    if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class Queue
	{
		public IntPtr _handle;

		public void BindSparse(uint bindInfoCount, BindSparseInfo pBindInfo, Fence fence) {
			unsafe {
				var result = NativeMethods.vkQueueBindSparse(_handle, bindInfoCount, pBindInfo._handle, fence._handle);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void PresentKHR(PresentInfoKhr pPresentInfo) {
			unsafe {
				var result = NativeMethods.vkQueuePresentKHR(_handle, pPresentInfo._handle);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

	    public void Submit(params SubmitInfo[] submitInfos) {
	        Submit(submitInfos, null);
	    }

		public void Submit(SubmitInfo[] pSubmits, Fence fence) {
			unsafe {
				var fenceHandle = fence?._handle ?? 0;
				var submitCount = (uint)(pSubmits?.Length ?? 0);
                var array = submitCount != 0 ? pSubmits.Select(s => *s._handle).ToArray() : new Interop.SubmitInfo[1];
				fixed (Interop.SubmitInfo* first = &array[0]) {
					var result = NativeMethods.vkQueueSubmit(_handle, submitCount, first, fenceHandle);
					if (result != Result.Success) throw new ResultException(result);
				}
			}
		}

		public void WaitIdle() {
			var result = NativeMethods.vkQueueWaitIdle(_handle);
			if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class CommandBuffer
	{
		public IntPtr _handle;

		public void Begin(CommandBufferBeginInfo pBeginInfo) {
		    unsafe {
			    var result = NativeMethods.vkBeginCommandBuffer(_handle, pBeginInfo._handle);
			    if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void CmdBeginQuery(QueryPool queryPool, uint query, QueryControlFlags flags) {
			NativeMethods.vkCmdBeginQuery(_handle, queryPool._handle, query, flags);
		}

		public void CmdBeginRenderPass(RenderPassBeginInfo pRenderPassBegin, SubpassContents contents) {
			unsafe {
				NativeMethods.vkCmdBeginRenderPass(_handle, pRenderPassBegin._handle, contents);
			}
		}

		public void CmdBindDescriptorSets(PipelineBindPoint pipelineBindPoint, PipelineLayout layout, uint firstSet, uint descriptorSetCount, DescriptorSet[] pDescriptorSets, uint dynamicOffsetCount, uint pDynamicOffsets) {
			unsafe {
			    var handles = pDescriptorSets.Select(s => s._handle).ToArray();
			    fixed (ulong* ptrpDescriptorSets = &handles[0]) {
			        NativeMethods.vkCmdBindDescriptorSets(_handle, pipelineBindPoint, layout._handle, firstSet, descriptorSetCount, ptrpDescriptorSets, dynamicOffsetCount, &pDynamicOffsets);
			    }
			}
		}

		public void CmdBindIndexBuffer(Buffer buffer, DeviceSize offset, IndexType indexType) {
			NativeMethods.vkCmdBindIndexBuffer(_handle, buffer._handle, offset, indexType);
		}

		public void CmdBindPipeline(PipelineBindPoint pipelineBindPoint, Pipeline pipeline) {
			NativeMethods.vkCmdBindPipeline(_handle, pipelineBindPoint, pipeline._handle);
		}

		public void CmdBindVertexBuffers(uint firstBinding, uint bindingCount, Buffer pBuffers, DeviceSize pOffsets) {
			unsafe {
				fixed (ulong* ptrpBuffers = &pBuffers._handle) NativeMethods.vkCmdBindVertexBuffers(_handle, firstBinding, bindingCount, ptrpBuffers, &pOffsets);
			}
		}

		public void CmdBlitImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageBlit pRegions, Filter filter) {
			unsafe {
				NativeMethods.vkCmdBlitImage(_handle, srcImage._handle, srcImageLayout, dstImage._handle, dstImageLayout, regionCount, pRegions._handle, filter);
			}
		}

		public void CmdClearAttachments(uint attachmentCount, ClearAttachment pAttachments, uint rectCount, ClearRect pRects) {
			unsafe {
				NativeMethods.vkCmdClearAttachments(_handle, attachmentCount, &pAttachments, rectCount, &pRects);
			}
		}

		public void CmdClearColorImage(Image image, ImageLayout imageLayout, ClearColorValue pColor, uint rangeCount, ImageSubresourceRange pRanges) {
			unsafe {
				NativeMethods.vkCmdClearColorImage(_handle, image._handle, imageLayout, pColor._handle, rangeCount, &pRanges);
			}
		}

		public void CmdClearDepthStencilImage(Image image, ImageLayout imageLayout, ClearDepthStencilValue pDepthStencil, uint rangeCount, ImageSubresourceRange pRanges) {
			unsafe {
				NativeMethods.vkCmdClearDepthStencilImage(_handle, image._handle, imageLayout, &pDepthStencil, rangeCount, &pRanges);
			}
		}

		public void CmdCopyBuffer(Buffer srcBuffer, Buffer dstBuffer, uint regionCount, BufferCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyBuffer(_handle, srcBuffer._handle, dstBuffer._handle, regionCount, &pRegions);
			}
		}

		public void CmdCopyBufferToImage(Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, uint regionCount, BufferImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyBufferToImage(_handle, srcBuffer._handle, dstImage._handle, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdCopyImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyImage(_handle, srcImage._handle, srcImageLayout, dstImage._handle, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdCopyImageToBuffer(Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, uint regionCount, BufferImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyImageToBuffer(_handle, srcImage._handle, srcImageLayout, dstBuffer._handle, regionCount, &pRegions);
			}
		}

		public void CmdCopyQueryPoolResults(QueryPool queryPool, uint firstQuery, uint queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags) {
			NativeMethods.vkCmdCopyQueryPoolResults(_handle, queryPool._handle, firstQuery, queryCount, dstBuffer._handle, dstOffset, stride, flags);
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerBeginEXT() {
		    unsafe {
				var pMarkerInfo = new DebugMarkerMarkerInfoExt();
				NativeMethods.vkCmdDebugMarkerBeginEXT(_handle, pMarkerInfo._handle);

				return pMarkerInfo;
			}
		}

		public void CmdDebugMarkerEndEXT() {
			NativeMethods.vkCmdDebugMarkerEndEXT(_handle);
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerInsertEXT() {
		    unsafe {
				var pMarkerInfo = new DebugMarkerMarkerInfoExt();
				NativeMethods.vkCmdDebugMarkerInsertEXT(_handle, pMarkerInfo._handle);

				return pMarkerInfo;
			}
		}

		public void CmdDispatch(uint x, uint y, uint z) {
			NativeMethods.vkCmdDispatch(_handle, x, y, z);
		}

		public void CmdDispatchIndirect(Buffer buffer, DeviceSize offset) {
			NativeMethods.vkCmdDispatchIndirect(_handle, buffer._handle, offset);
		}

		public void CmdDraw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) {
			NativeMethods.vkCmdDraw(_handle, vertexCount, instanceCount, firstVertex, firstInstance);
		}

		public void CmdDrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int vertexOffset, uint firstInstance) {
			NativeMethods.vkCmdDrawIndexed(_handle, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
		}

		public void CmdDrawIndexedIndirect(Buffer buffer, DeviceSize offset, uint drawCount, uint stride) {
			NativeMethods.vkCmdDrawIndexedIndirect(_handle, buffer._handle, offset, drawCount, stride);
		}

		public void CmdDrawIndirect(Buffer buffer, DeviceSize offset, uint drawCount, uint stride) {
			NativeMethods.vkCmdDrawIndirect(_handle, buffer._handle, offset, drawCount, stride);
		}

		public void CmdEndQuery(QueryPool queryPool, uint query) {
			NativeMethods.vkCmdEndQuery(_handle, queryPool._handle, query);
		}

		public void CmdEndRenderPass() {
			NativeMethods.vkCmdEndRenderPass(_handle);
		}

		public void CmdExecuteCommands(params CommandBuffer[] commandBuffers) {
			if (commandBuffers == null || commandBuffers.Length == 0) {
				unsafe {
					NativeMethods.vkCmdExecuteCommands(_handle, 0, null);
				}
			}
			else {
				var array = commandBuffers.Select(c => c._handle).ToArray();
				unsafe {
					fixed (IntPtr* ptrCommandBuffers = &array[0])
					{
						NativeMethods.vkCmdExecuteCommands(_handle, (uint)commandBuffers.Length, ptrCommandBuffers);
					}
				}
			}
		}

		public void CmdFillBuffer(Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, uint data) {
			NativeMethods.vkCmdFillBuffer(_handle, dstBuffer._handle, dstOffset, size, data);
		}

		public void CmdNextSubpass(SubpassContents contents) {
			NativeMethods.vkCmdNextSubpass(_handle, contents);
		}

		public void CmdPipelineBarrier(PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, uint memoryBarrierCount, MemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers) {
			unsafe {
				NativeMethods.vkCmdPipelineBarrier(_handle, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers._handle, bufferMemoryBarrierCount, pBufferMemoryBarriers._handle, imageMemoryBarrierCount, pImageMemoryBarriers._handle);
			}
		}

		public void CmdPushConstants(PipelineLayout layout, ShaderStageFlags stageFlags, uint offset, uint size, IntPtr pValues) {
			NativeMethods.vkCmdPushConstants(_handle, layout._handle, stageFlags, offset, size, pValues);
		}

		public void CmdResetEvent(Event @event, PipelineStageFlags stageMask) {
			NativeMethods.vkCmdResetEvent(_handle, @event._handle, stageMask);
		}

		public void CmdResetQueryPool(QueryPool queryPool, uint firstQuery, uint queryCount) {
			NativeMethods.vkCmdResetQueryPool(_handle, queryPool._handle, firstQuery, queryCount);
		}

		public void CmdResolveImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageResolve pRegions) {
			unsafe {
				NativeMethods.vkCmdResolveImage(_handle, srcImage._handle, srcImageLayout, dstImage._handle, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdSetBlendConstants(float blendConstants) {
			NativeMethods.vkCmdSetBlendConstants(_handle, blendConstants);
		}

		public void CmdSetDepthBias(float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor) {
			NativeMethods.vkCmdSetDepthBias(_handle, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
		}

		public void CmdSetDepthBounds(float minDepthBounds, float maxDepthBounds) {
			NativeMethods.vkCmdSetDepthBounds(_handle, minDepthBounds, maxDepthBounds);
		}

		public void CmdSetEvent(Event @event, PipelineStageFlags stageMask) {
			NativeMethods.vkCmdSetEvent(_handle, @event._handle, stageMask);
		}

		public void CmdSetLineWidth(float lineWidth) {
			NativeMethods.vkCmdSetLineWidth(_handle, lineWidth);
		}

		public void CmdSetScissor(uint firstScissor, uint scissorCount, Rect2D pScissors) {
			unsafe {
				NativeMethods.vkCmdSetScissor(_handle, firstScissor, scissorCount, &pScissors);
			}
		}

		public void CmdSetStencilCompareMask(StencilFaceFlags faceMask, uint compareMask) {
			NativeMethods.vkCmdSetStencilCompareMask(_handle, faceMask, compareMask);
		}

		public void CmdSetStencilReference(StencilFaceFlags faceMask, uint reference) {
			NativeMethods.vkCmdSetStencilReference(_handle, faceMask, reference);
		}

		public void CmdSetStencilWriteMask(StencilFaceFlags faceMask, uint writeMask) {
			NativeMethods.vkCmdSetStencilWriteMask(_handle, faceMask, writeMask);
		}

		public void CmdSetViewport(uint firstViewport, uint viewportCount, Viewport pViewports) {
			unsafe {
				NativeMethods.vkCmdSetViewport(_handle, firstViewport, viewportCount, &pViewports);
			}
		}

		public void CmdUpdateBuffer(Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, uint pData) {
			unsafe {
				NativeMethods.vkCmdUpdateBuffer(_handle, dstBuffer._handle, dstOffset, dataSize, &pData);
			}
		}

		public void CmdWaitEvents(uint eventCount, Event pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, uint memoryBarrierCount, MemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers) {
			unsafe {
				fixed (ulong* ptrpEvents = &pEvents._handle) NativeMethods.vkCmdWaitEvents(_handle, eventCount, ptrpEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers._handle, bufferMemoryBarrierCount, pBufferMemoryBarriers._handle, imageMemoryBarrierCount, pImageMemoryBarriers._handle);
			}
		}

		public void CmdWriteTimestamp(PipelineStageFlags pipelineStage, QueryPool queryPool, uint query) {
			NativeMethods.vkCmdWriteTimestamp(_handle, pipelineStage, queryPool._handle, query);
		}

		public void End() {
		    var result = NativeMethods.vkEndCommandBuffer(_handle);
		    if (result != Result.Success) throw new ResultException(result);
		}

	    public void Reset(CommandBufferResetFlags flags) {
		    var result = NativeMethods.vkResetCommandBuffer(_handle, flags);
		    if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class DeviceMemory
	{
		public ulong _handle;
	}

	public class CommandPool
	{
		public ulong _handle;
	}

	public class Buffer
	{
		public ulong _handle;
	}

	public class BufferView
	{
		public ulong _handle;
	}

	public class Image
	{
		public ulong _handle;
	}

	public class ImageView
	{
		public ulong _handle;
	}

	public class ShaderModule
	{
		public ulong _handle;
	}

	public class Pipeline
	{
		public ulong _handle;
	}

	public class PipelineLayout
	{
		public ulong _handle;
	}

	public class Sampler
	{
		public ulong _handle;
	}

	public class DescriptorSet
	{
		public ulong _handle;
	}

	public class DescriptorSetLayout
	{
		public ulong _handle;
	}

	public class DescriptorPool
	{
		public ulong _handle;
	}

	public class Fence
	{
		public ulong _handle;
	}

	public class Semaphore
	{
		public ulong _handle;
	}

	public class Event
	{
		public ulong _handle;
	}

	public class QueryPool
	{
		public ulong _handle;
	}

	public class Framebuffer
	{
		public ulong _handle;
	}

	public class RenderPass
	{
		public ulong _handle;
	}

	public class PipelineCache
	{
		public ulong _handle;
	}

	public class DisplayKhr
	{
		public ulong _handle;
	}

	public class DisplayModeKhr
	{
		public ulong _handle;
	}

	public class SurfaceKhr
	{
		public ulong _handle;
	}

	public class SwapchainKhr
	{
		public ulong _handle;
	}

	public class DebugReportCallbackExt
	{
		public ulong _handle;
	}
}