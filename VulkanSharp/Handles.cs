using System;
using System.Runtime.InteropServices;
using VulkanSharp.Interop;

namespace VulkanSharp
{
	// ReSharper disable InconsistentNaming
	public partial class Instance
	{
		protected IntPtr m;
		public IntPtr Handle => m;

		public DebugReportCallbackExt CreateDebugReportCallbackEXT(DebugReportCallbackCreateInfoExt pCreateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pCallback = new DebugReportCallbackExt();

				Result result;
				fixed (ulong* ptrpCallback = &pCallback.m) result = NativeMethods.vkCreateDebugReportCallbackEXT(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpCallback);
				if (result != Result.Success) throw new ResultException(result);

				return pCallback;
			}
		}

		public SurfaceKhr CreateDisplayPlaneSurfaceKHR(DisplaySurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pSurface = new SurfaceKhr();

				Result result;
				fixed (ulong* ptrpSurface = &pSurface.m) result = NativeMethods.vkCreateDisplayPlaneSurfaceKHR(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSurface);
				if (result != Result.Success) throw new ResultException(result);

				return pSurface;
			}
		}

		public void DebugReportMessageEXT(DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, ulong @object, UIntPtr location, int messageCode, string pLayerPrefix, string pMessage) {
			NativeMethods.vkDebugReportMessageEXT(m, flags, objectType, @object, location, messageCode, pLayerPrefix, pMessage);
		}

		public void Destroy(AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyInstance(m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDebugReportCallbackEXT(DebugReportCallbackExt callback, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyDebugReportCallbackEXT(m, callback.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySurfaceKHR(SurfaceKhr surface, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroySurfaceKHR(m, surface.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public PhysicalDevice[] EnumeratePhysicalDevices() {
			unsafe {
				uint pPhysicalDeviceCount;
				var result = NativeMethods.vkEnumeratePhysicalDevices(m, &pPhysicalDeviceCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPhysicalDeviceCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(IntPtr));
				var ptrpPhysicalDevices = Marshal.AllocHGlobal((int)(size * pPhysicalDeviceCount));
				result = NativeMethods.vkEnumeratePhysicalDevices(m, &pPhysicalDeviceCount, (IntPtr*)ptrpPhysicalDevices);
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
			return NativeMethods.vkGetInstanceProcAddr(m, pName);
		}
	}

	public class PhysicalDevice
	{
		protected IntPtr m;

		public IntPtr Handle => m;

		public PhysicalDevice(IntPtr handle) {
			m = handle;
		}

		public Device CreateDevice(DeviceCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pDevice = new Device();

				Result result;
				fixed (IntPtr* ptrpDevice = &pDevice.m) result = NativeMethods.vkCreateDevice(m, pCreateInfo._handle, pAllocator != null ? pAllocator.Handle : null, ptrpDevice);
				if (result != Result.Success) throw new ResultException(result);

				return pDevice;
			}
		}

		public DisplayModeKhr CreateDisplayModeKHR(DisplayKhr display, DisplayModeCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pMode = new DisplayModeKhr();

				Result result;
				fixed (ulong* ptrpMode = &pMode.m) result = NativeMethods.vkCreateDisplayModeKHR(m, display.m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpMode);
				if (result != Result.Success) throw new ResultException(result);

				return pMode;
			}
		}

		public ExtensionProperties[] EnumerateDeviceExtensionProperties(string pLayerName) {
			unsafe {
				uint pPropertyCount;
				var result = NativeMethods.vkEnumerateDeviceExtensionProperties(m, pLayerName, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkEnumerateDeviceExtensionProperties(m, pLayerName, &pPropertyCount, (Interop.ExtensionProperties*)ptrpProperties);
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
				var result = NativeMethods.vkEnumerateDeviceLayerProperties(m, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.LayerProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkEnumerateDeviceLayerProperties(m, &pPropertyCount, (Interop.LayerProperties*)ptrpProperties);
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
				var result = NativeMethods.vkGetDisplayModePropertiesKHR(m, display.m, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayModePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetDisplayModePropertiesKHR(m, display.m, &pPropertyCount, (Interop.DisplayModePropertiesKhr*)ptrpProperties);
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
			Result result;
			DisplayPlaneCapabilitiesKhr pCapabilities;
			unsafe {
				pCapabilities = new DisplayPlaneCapabilitiesKhr();
				result = NativeMethods.vkGetDisplayPlaneCapabilitiesKHR(m, mode.m, planeIndex, &pCapabilities);
				if (result != Result.Success) throw new ResultException(result);

				return pCapabilities;
			}
		}

		public DisplayPlanePropertiesKhr[] GetDisplayPlanePropertiesKHR() {
			Result result;
			unsafe {
				uint pPropertyCount;
				result = NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR(m, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayPlanePropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetPhysicalDeviceDisplayPlanePropertiesKHR(m, &pPropertyCount, (Interop.DisplayPlanePropertiesKhr*)ptrpProperties);
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
			Result result;
			unsafe {
				uint pDisplayCount;
				result = NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR(m, planeIndex, &pDisplayCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pDisplayCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpDisplays = Marshal.AllocHGlobal((int)(size * pDisplayCount));
				result = NativeMethods.vkGetDisplayPlaneSupportedDisplaysKHR(m, planeIndex, &pDisplayCount, (ulong*)ptrpDisplays);
				if (result != Result.Success) throw new ResultException(result);

				if (pDisplayCount <= 0) return null;
				var arr = new DisplayKhr[pDisplayCount];
				for (var i = 0; i < pDisplayCount; i++) {
					arr[i] = new DisplayKhr();
					arr[i].m = ((ulong*)ptrpDisplays)[i];
				}

				return arr;
			}
		}

		public DisplayPropertiesKhr[] GetDisplayPropertiesKHR() {
			Result result;
			unsafe {
				uint pPropertyCount;
				result = NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR(m, &pPropertyCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(Interop.DisplayPropertiesKhr));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				result = NativeMethods.vkGetPhysicalDeviceDisplayPropertiesKHR(m, &pPropertyCount, (Interop.DisplayPropertiesKhr*)ptrpProperties);
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
			PhysicalDeviceFeatures pFeatures;
			unsafe {
				pFeatures = new PhysicalDeviceFeatures();
				NativeMethods.vkGetPhysicalDeviceFeatures(m, &pFeatures);

				return pFeatures;
			}
		}

		public FormatProperties GetFormatProperties(Format format) {
			FormatProperties pFormatProperties;
			unsafe {
				pFormatProperties = new FormatProperties();
				NativeMethods.vkGetPhysicalDeviceFormatProperties(m, format, &pFormatProperties);

				return pFormatProperties;
			}
		}

		public ImageFormatProperties GetImageFormatProperties(Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags) {
			Result result;
			ImageFormatProperties pImageFormatProperties;
			unsafe {
				pImageFormatProperties = new ImageFormatProperties();
				result = NativeMethods.vkGetPhysicalDeviceImageFormatProperties(m, format, type, tiling, usage, flags, &pImageFormatProperties);
				if (result != Result.Success) throw new ResultException(result);

				return pImageFormatProperties;
			}
		}

		public PhysicalDeviceMemoryProperties GetMemoryProperties() {
			PhysicalDeviceMemoryProperties pMemoryProperties;
			unsafe {
				pMemoryProperties = new PhysicalDeviceMemoryProperties();
				NativeMethods.vkGetPhysicalDeviceMemoryProperties(m, pMemoryProperties.m);

				return pMemoryProperties;
			}
		}

		public PhysicalDeviceProperties GetProperties() {
			PhysicalDeviceProperties pProperties;
			unsafe {
				pProperties = new PhysicalDeviceProperties();
				NativeMethods.vkGetPhysicalDeviceProperties(m, pProperties._handle);

				return pProperties;
			}
		}

		public QueueFamilyProperties[] GetQueueFamilyProperties() {
			unsafe {
				uint pQueueFamilyPropertyCount;
				NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties(m, &pQueueFamilyPropertyCount, null);
				if (pQueueFamilyPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(QueueFamilyProperties));
				var ptrpQueueFamilyProperties = Marshal.AllocHGlobal((int)(size * pQueueFamilyPropertyCount));
				NativeMethods.vkGetPhysicalDeviceQueueFamilyProperties(m, &pQueueFamilyPropertyCount, (QueueFamilyProperties*)ptrpQueueFamilyProperties);

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
				NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties(m, format, type, samples, usage, tiling, &pPropertyCount, null);
				if (pPropertyCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SparseImageFormatProperties));
				var ptrpProperties = Marshal.AllocHGlobal((int)(size * pPropertyCount));
				NativeMethods.vkGetPhysicalDeviceSparseImageFormatProperties(m, format, type, samples, usage, tiling, &pPropertyCount, (SparseImageFormatProperties*)ptrpProperties);

				if (pPropertyCount <= 0) return null;
				var arr = new SparseImageFormatProperties[pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr[i] = ((SparseImageFormatProperties*)ptrpProperties)[i];
				}

				return arr;
			}
		}

		public SurfaceCapabilitiesKhr GetSurfaceCapabilitiesKHR(SurfaceKhr surface) {
			Result result;
			SurfaceCapabilitiesKhr pSurfaceCapabilities;
			unsafe {
				pSurfaceCapabilities = new SurfaceCapabilitiesKhr();
				result = NativeMethods.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(m, surface.m, &pSurfaceCapabilities);
				if (result != Result.Success) throw new ResultException(result);

				return pSurfaceCapabilities;
			}
		}

		public SurfaceFormatKhr[] GetSurfaceFormatsKHR(SurfaceKhr surface) {
			Result result;
			unsafe {
				uint pSurfaceFormatCount;
				result = NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR(m, surface.m, &pSurfaceFormatCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pSurfaceFormatCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SurfaceFormatKhr));
				var ptrpSurfaceFormats = Marshal.AllocHGlobal((int)(size * pSurfaceFormatCount));
				result = NativeMethods.vkGetPhysicalDeviceSurfaceFormatsKHR(m, surface.m, &pSurfaceFormatCount, (SurfaceFormatKhr*)ptrpSurfaceFormats);
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
			Result result;
			unsafe {
				uint pPresentModeCount;
				result = NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR(m, surface.m, &pPresentModeCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pPresentModeCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(PresentModeKhr));
				var ptrpPresentModes = Marshal.AllocHGlobal((int)(size * pPresentModeCount));
				result = NativeMethods.vkGetPhysicalDeviceSurfacePresentModesKHR(m, surface.m, &pPresentModeCount, (PresentModeKhr*)ptrpPresentModes);
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
			Result result;
			Bool32 pSupported;
			unsafe {
				pSupported = new Bool32();
				result = NativeMethods.vkGetPhysicalDeviceSurfaceSupportKHR(m, queueFamilyIndex, surface.m, &pSupported);
				if (result != Result.Success) throw new ResultException(result);

				return pSupported;
			}
		}
	}

	public partial class Device
	{
		public IntPtr m;

		public uint AcquireNextImageKHR(SwapchainKhr swapchain, ulong timeout, Semaphore semaphore, Fence fence) {
			Result result;
			uint pImageIndex;
			unsafe {
				pImageIndex = new uint();
				result = NativeMethods.vkAcquireNextImageKHR(m, swapchain.m, timeout, semaphore.m, fence.m, &pImageIndex);
				if (result != Result.Success) throw new ResultException(result);

				return pImageIndex;
			}
		}

		public CommandBuffer[] AllocateCommandBuffers(CommandBufferAllocateInfo pAllocateInfo) {
			Result result;
			unsafe {
				if (pAllocateInfo.CommandBufferCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(IntPtr));
				var ptrpCommandBuffers = Marshal.AllocHGlobal((int)(size * pAllocateInfo.CommandBufferCount));
				result = NativeMethods.vkAllocateCommandBuffers(m, pAllocateInfo.m, (IntPtr*)ptrpCommandBuffers);
				if (result != Result.Success) throw new ResultException(result);

				if (pAllocateInfo.CommandBufferCount <= 0) return null;
				var arr = new CommandBuffer[pAllocateInfo.CommandBufferCount];
				for (var i = 0; i < pAllocateInfo.CommandBufferCount; i++) {
					arr[i] = new CommandBuffer();
					arr[i].m = ((IntPtr*)ptrpCommandBuffers)[i];
				}

				return arr;
			}
		}

		public DescriptorSet[] AllocateDescriptorSets(DescriptorSetAllocateInfo pAllocateInfo) {
			Result result;
			unsafe {
				if (pAllocateInfo.DescriptorSetCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpDescriptorSets = Marshal.AllocHGlobal((int)(size * pAllocateInfo.DescriptorSetCount));
				result = NativeMethods.vkAllocateDescriptorSets(m, pAllocateInfo.m, (ulong*)ptrpDescriptorSets);
				if (result != Result.Success) throw new ResultException(result);

				if (pAllocateInfo.DescriptorSetCount <= 0) return null;
				var arr = new DescriptorSet[pAllocateInfo.DescriptorSetCount];
				for (var i = 0; i < pAllocateInfo.DescriptorSetCount; i++) {
					arr[i] = new DescriptorSet();
					arr[i].m = ((ulong*)ptrpDescriptorSets)[i];
				}

				return arr;
			}
		}

		public DeviceMemory AllocateMemory(MemoryAllocateInfo pAllocateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pMemory = new DeviceMemory();

				Result result;
				fixed (ulong* ptrpMemory = &pMemory.m) result = NativeMethods.vkAllocateMemory(m, pAllocateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpMemory);
				if (result != Result.Success) throw new ResultException(result);

				return pMemory;
			}
		}

		public void BindBufferMemory(Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset) {
			var result = NativeMethods.vkBindBufferMemory(m, buffer.m, memory.m, memoryOffset);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void BindImageMemory(Image image, DeviceMemory memory, DeviceSize memoryOffset) {
			var result = NativeMethods.vkBindImageMemory(m, image.m, memory.m, memoryOffset);
			if (result != Result.Success) throw new ResultException(result);
		}

		public Buffer CreateBuffer(BufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			unsafe {
				var pBuffer = new Buffer();

				Result result;
				fixed (ulong* ptrpBuffer = &pBuffer.m) result = NativeMethods.vkCreateBuffer(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpBuffer);
				if (result != Result.Success) throw new ResultException(result);

				return pBuffer;
			}
		}

		public BufferView CreateBufferView(BufferViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			BufferView pView;
			unsafe {
				pView = new BufferView();

				fixed (ulong* ptrpView = &pView.m) result = NativeMethods.vkCreateBufferView(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				if (result != Result.Success) throw new ResultException(result);

				return pView;
			}
		}

		public CommandPool CreateCommandPool(CommandPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			CommandPool pCommandPool;
			unsafe {
				pCommandPool = new CommandPool();

				fixed (ulong* ptrpCommandPool = &pCommandPool.m) result = NativeMethods.vkCreateCommandPool(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpCommandPool);
				if (result != Result.Success) throw new ResultException(result);

				return pCommandPool;
			}
		}

		public Pipeline[] CreateComputePipelines(PipelineCache pipelineCache, uint createInfoCount, ComputePipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator) {
			Result result;
			unsafe {
				if (createInfoCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpPipelines = Marshal.AllocHGlobal((int)(size * createInfoCount));
				result = NativeMethods.vkCreateComputePipelines(m, pipelineCache.m, createInfoCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpPipelines);
				if (result != Result.Success) throw new ResultException(result);

				if (createInfoCount <= 0) return null;
				var arr = new Pipeline[createInfoCount];
				for (var i = 0; i < createInfoCount; i++) {
					arr[i] = new Pipeline();
					arr[i].m = ((ulong*)ptrpPipelines)[i];
				}

				return arr;
			}
		}

		public DescriptorPool CreateDescriptorPool(DescriptorPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			DescriptorPool pDescriptorPool;
			unsafe {
				pDescriptorPool = new DescriptorPool();

				fixed (ulong* ptrpDescriptorPool = &pDescriptorPool.m) result = NativeMethods.vkCreateDescriptorPool(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpDescriptorPool);
				if (result != Result.Success) throw new ResultException(result);

				return pDescriptorPool;
			}
		}

		public DescriptorSetLayout CreateDescriptorSetLayout(DescriptorSetLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			DescriptorSetLayout pSetLayout;
			unsafe {
				pSetLayout = new DescriptorSetLayout();

				fixed (ulong* ptrpSetLayout = &pSetLayout.m) result = NativeMethods.vkCreateDescriptorSetLayout(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSetLayout);
				if (result != Result.Success) throw new ResultException(result);

				return pSetLayout;
			}
		}

		public Event CreateEvent(EventCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Event pEvent;
			unsafe {
				pEvent = new Event();

				fixed (ulong* ptrpEvent = &pEvent.m) result = NativeMethods.vkCreateEvent(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpEvent);
				if (result != Result.Success) throw new ResultException(result);

				return pEvent;
			}
		}

		public Fence CreateFence(FenceCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Fence pFence;
			unsafe {
				pFence = new Fence();

				fixed (ulong* ptrpFence = &pFence.m) result = NativeMethods.vkCreateFence(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpFence);
				if (result != Result.Success) throw new ResultException(result);

				return pFence;
			}
		}

		public Framebuffer CreateFramebuffer(FramebufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Framebuffer pFramebuffer;
			unsafe {
				pFramebuffer = new Framebuffer();

				fixed (ulong* ptrpFramebuffer = &pFramebuffer.m) result = NativeMethods.vkCreateFramebuffer(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpFramebuffer);
				if (result != Result.Success) throw new ResultException(result);

				return pFramebuffer;
			}
		}

		public Pipeline[] CreateGraphicsPipelines(PipelineCache pipelineCache, uint createInfoCount, GraphicsPipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator) {
			Result result;
			unsafe {
				if (createInfoCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpPipelines = Marshal.AllocHGlobal((int)(size * createInfoCount));
				result = NativeMethods.vkCreateGraphicsPipelines(m, pipelineCache.m, createInfoCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpPipelines);
				if (result != Result.Success) throw new ResultException(result);

				if (createInfoCount <= 0) return null;
				var arr = new Pipeline[createInfoCount];
				for (var i = 0; i < createInfoCount; i++) {
					arr[i] = new Pipeline();
					arr[i].m = ((ulong*)ptrpPipelines)[i];
				}

				return arr;
			}
		}

		public Image CreateImage(ImageCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Image pImage;
			unsafe {
				pImage = new Image();

				fixed (ulong* ptrpImage = &pImage.m) result = NativeMethods.vkCreateImage(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpImage);
				if (result != Result.Success) throw new ResultException(result);

				return pImage;
			}
		}

		public ImageView CreateImageView(ImageViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			ImageView pView;
			unsafe {
				pView = new ImageView();

				fixed (ulong* ptrpView = &pView.m) result = NativeMethods.vkCreateImageView(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpView);
				if (result != Result.Success) throw new ResultException(result);

				return pView;
			}
		}

		public PipelineCache CreatePipelineCache(PipelineCacheCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			PipelineCache pPipelineCache;
			unsafe {
				pPipelineCache = new PipelineCache();

				fixed (ulong* ptrpPipelineCache = &pPipelineCache.m) result = NativeMethods.vkCreatePipelineCache(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineCache);
				if (result != Result.Success) throw new ResultException(result);

				return pPipelineCache;
			}
		}

		public PipelineLayout CreatePipelineLayout(PipelineLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			PipelineLayout pPipelineLayout;
			unsafe {
				pPipelineLayout = new PipelineLayout();

				fixed (ulong* ptrpPipelineLayout = &pPipelineLayout.m) result = NativeMethods.vkCreatePipelineLayout(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpPipelineLayout);
				if (result != Result.Success) throw new ResultException(result);

				return pPipelineLayout;
			}
		}

		public QueryPool CreateQueryPool(QueryPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			QueryPool pQueryPool;
			unsafe {
				pQueryPool = new QueryPool();

				fixed (ulong* ptrpQueryPool = &pQueryPool.m) result = NativeMethods.vkCreateQueryPool(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpQueryPool);
				if (result != Result.Success) throw new ResultException(result);

				return pQueryPool;
			}
		}

		public RenderPass CreateRenderPass(RenderPassCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			RenderPass pRenderPass;
			unsafe {
				pRenderPass = new RenderPass();

				fixed (ulong* ptrpRenderPass = &pRenderPass.m) result = NativeMethods.vkCreateRenderPass(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpRenderPass);
				if (result != Result.Success) throw new ResultException(result);

				return pRenderPass;
			}
		}

		public Sampler CreateSampler(SamplerCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Sampler pSampler;
			unsafe {
				pSampler = new Sampler();

				fixed (ulong* ptrpSampler = &pSampler.m) result = NativeMethods.vkCreateSampler(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSampler);
				if (result != Result.Success) throw new ResultException(result);

				return pSampler;
			}
		}

		public Semaphore CreateSemaphore(SemaphoreCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			Semaphore pSemaphore;
			unsafe {
				pSemaphore = new Semaphore();

				fixed (ulong* ptrpSemaphore = &pSemaphore.m) result = NativeMethods.vkCreateSemaphore(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSemaphore);
				if (result != Result.Success) throw new ResultException(result);

				return pSemaphore;
			}
		}

		public ShaderModule CreateShaderModule(ShaderModuleCreateInfo pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			ShaderModule pShaderModule;
			unsafe {
				pShaderModule = new ShaderModule();

				fixed (ulong* ptrpShaderModule = &pShaderModule.m) result = NativeMethods.vkCreateShaderModule(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpShaderModule);
				if (result != Result.Success) throw new ResultException(result);

				return pShaderModule;
			}
		}

		public SwapchainKhr[] CreateSharedSwapchainsKHR(uint swapchainCount, SwapchainCreateInfoKhr pCreateInfos, AllocationCallbacks pAllocator) {
			Result result;
			unsafe {
				if (swapchainCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpSwapchains = Marshal.AllocHGlobal((int)(size * swapchainCount));
				result = NativeMethods.vkCreateSharedSwapchainsKHR(m, swapchainCount, pCreateInfos.m, pAllocator != null ? pAllocator.Handle : null, (ulong*)ptrpSwapchains);
				if (result != Result.Success) throw new ResultException(result);

				if (swapchainCount <= 0) return null;
				var arr = new SwapchainKhr[swapchainCount];
				for (var i = 0; i < swapchainCount; i++) {
					arr[i] = new SwapchainKhr();
					arr[i].m = ((ulong*)ptrpSwapchains)[i];
				}

				return arr;
			}
		}

		public SwapchainKhr CreateSwapchainKHR(SwapchainCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator) {
			Result result;
			SwapchainKhr pSwapchain;
			unsafe {
				pSwapchain = new SwapchainKhr();

				fixed (ulong* ptrpSwapchain = &pSwapchain.m) result = NativeMethods.vkCreateSwapchainKHR(m, pCreateInfo.m, pAllocator != null ? pAllocator.Handle : null, ptrpSwapchain);
				if (result != Result.Success) throw new ResultException(result);

				return pSwapchain;
			}
		}

		public DebugMarkerObjectNameInfoExt DebugMarkerSetObjectNameEXT() {
			Result result;
			DebugMarkerObjectNameInfoExt pNameInfo;
			unsafe {
				pNameInfo = new DebugMarkerObjectNameInfoExt();
				result = NativeMethods.vkDebugMarkerSetObjectNameEXT(m, pNameInfo.m);
				if (result != Result.Success) throw new ResultException(result);

				return pNameInfo;
			}
		}

		public DebugMarkerObjectTagInfoExt DebugMarkerSetObjectTagEXT() {
			Result result;
			DebugMarkerObjectTagInfoExt pTagInfo;
			unsafe {
				pTagInfo = new DebugMarkerObjectTagInfoExt();
				result = NativeMethods.vkDebugMarkerSetObjectTagEXT(m, pTagInfo.m);
				if (result != Result.Success) throw new ResultException(result);

				return pTagInfo;
			}
		}

		public void Destroy(AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyDevice(m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyBuffer(Buffer buffer, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyBuffer(m, buffer.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyBufferView(BufferView bufferView, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyBufferView(m, bufferView.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyCommandPool(CommandPool commandPool, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyCommandPool(m, commandPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDescriptorPool(DescriptorPool descriptorPool, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyDescriptorPool(m, descriptorPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyDescriptorSetLayout(DescriptorSetLayout descriptorSetLayout, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyDescriptorSetLayout(m, descriptorSetLayout.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyEvent(Event @event, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyEvent(m, @event.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyFence(Fence fence, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyFence(m, fence.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyFramebuffer(Framebuffer framebuffer, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyFramebuffer(m, framebuffer.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyImage(Image image, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyImage(m, image.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyImageView(ImageView imageView, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyImageView(m, imageView.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipeline(Pipeline pipeline, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyPipeline(m, pipeline.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipelineCache(PipelineCache pipelineCache, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyPipelineCache(m, pipelineCache.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyPipelineLayout(PipelineLayout pipelineLayout, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyPipelineLayout(m, pipelineLayout.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyQueryPool(QueryPool queryPool, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyQueryPool(m, queryPool.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyRenderPass(RenderPass renderPass, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyRenderPass(m, renderPass.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySampler(Sampler sampler, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroySampler(m, sampler.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySemaphore(Semaphore semaphore, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroySemaphore(m, semaphore.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroyShaderModule(ShaderModule shaderModule, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroyShaderModule(m, shaderModule.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void DestroySwapchainKHR(SwapchainKhr swapchain, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkDestroySwapchainKHR(m, swapchain.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public void FlushMappedMemoryRanges(uint memoryRangeCount, MappedMemoryRange pMemoryRanges) {
			Result result;
			unsafe {
				result = NativeMethods.vkFlushMappedMemoryRanges(m, memoryRangeCount, pMemoryRanges.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void FreeCommandBuffers(CommandPool commandPool, uint commandBufferCount, CommandBuffer pCommandBuffers) {
			unsafe {
				fixed (IntPtr* ptrpCommandBuffers = &pCommandBuffers.m) NativeMethods.vkFreeCommandBuffers(m, commandPool.m, commandBufferCount, ptrpCommandBuffers);
			}
		}

		public void FreeDescriptorSets(DescriptorPool descriptorPool, uint descriptorSetCount, DescriptorSet pDescriptorSets) {
			Result result;
			unsafe {
				fixed (ulong* ptrpDescriptorSets = &pDescriptorSets.m) result = NativeMethods.vkFreeDescriptorSets(m, descriptorPool.m, descriptorSetCount, ptrpDescriptorSets);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void FreeMemory(DeviceMemory memory, AllocationCallbacks pAllocator) {
			unsafe {
				NativeMethods.vkFreeMemory(m, memory.m, pAllocator != null ? pAllocator.Handle : null);
			}
		}

		public MemoryRequirements GetBufferMemoryRequirements(Buffer buffer) {
			MemoryRequirements pMemoryRequirements;
			unsafe {
				pMemoryRequirements = new MemoryRequirements();
				NativeMethods.vkGetBufferMemoryRequirements(m, buffer.m, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public void GetEventStatus(Event @event) {
			Result result;
			result = NativeMethods.vkGetEventStatus(m, @event.m);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void GetFenceStatus(Fence fence) {
			Result result;
			result = NativeMethods.vkGetFenceStatus(m, fence.m);
			if (result != Result.Success) throw new ResultException(result);
		}

		public MemoryRequirements GetImageMemoryRequirements(Image image) {
			MemoryRequirements pMemoryRequirements;
			unsafe {
				pMemoryRequirements = new MemoryRequirements();
				NativeMethods.vkGetImageMemoryRequirements(m, image.m, &pMemoryRequirements);

				return pMemoryRequirements;
			}
		}

		public SparseImageMemoryRequirements[] GetImageSparseMemoryRequirements(Image image) {
			unsafe {
				uint pSparseMemoryRequirementCount;
				NativeMethods.vkGetImageSparseMemoryRequirements(m, image.m, &pSparseMemoryRequirementCount, null);
				if (pSparseMemoryRequirementCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(SparseImageMemoryRequirements));
				var ptrpSparseMemoryRequirements = Marshal.AllocHGlobal((int)(size * pSparseMemoryRequirementCount));
				NativeMethods.vkGetImageSparseMemoryRequirements(m, image.m, &pSparseMemoryRequirementCount, (SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements);

				if (pSparseMemoryRequirementCount <= 0) return null;
				var arr = new SparseImageMemoryRequirements[pSparseMemoryRequirementCount];
				for (var i = 0; i < pSparseMemoryRequirementCount; i++) {
					arr[i] = ((SparseImageMemoryRequirements*)ptrpSparseMemoryRequirements)[i];
				}

				return arr;
			}
		}

		public SubresourceLayout GetImageSubresourceLayout(Image image, ImageSubresource pSubresource) {
			SubresourceLayout pLayout;
			unsafe {
				pLayout = new SubresourceLayout();
				NativeMethods.vkGetImageSubresourceLayout(m, image.m, &pSubresource, &pLayout);

				return pLayout;
			}
		}

		public DeviceSize GetMemoryCommitment(DeviceMemory memory) {
			DeviceSize pCommittedMemoryInBytes;
			unsafe {
				pCommittedMemoryInBytes = new DeviceSize();
				NativeMethods.vkGetDeviceMemoryCommitment(m, memory.m, &pCommittedMemoryInBytes);

				return pCommittedMemoryInBytes;
			}
		}

		public void GetPipelineCacheData(PipelineCache pipelineCache, out UIntPtr pDataSize, IntPtr pData) {
			Result result;
			unsafe {
				fixed (UIntPtr* ptrpDataSize = &pDataSize) result = NativeMethods.vkGetPipelineCacheData(m, pipelineCache.m, ptrpDataSize, pData);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public IntPtr GetProcAddr(string pName) {
			return NativeMethods.vkGetDeviceProcAddr(m, pName);
		}

		public IntPtr GetQueryPoolResults(QueryPool queryPool, uint firstQuery, uint queryCount, UIntPtr dataSize, DeviceSize stride, QueryResultFlags flags) {
			Result result;
			IntPtr pData;
			pData = new IntPtr();
			result = NativeMethods.vkGetQueryPoolResults(m, queryPool.m, firstQuery, queryCount, dataSize, pData, stride, flags);
			if (result != Result.Success) throw new ResultException(result);

			return pData;
		}

		public Queue GetQueue(uint queueFamilyIndex, uint queueIndex) {
			Queue pQueue;
			unsafe {
				pQueue = new Queue();

				fixed (IntPtr* ptrpQueue = &pQueue.m) NativeMethods.vkGetDeviceQueue(m, queueFamilyIndex, queueIndex, ptrpQueue);

				return pQueue;
			}
		}

		public Extent2D GetRenderAreaGranularity(RenderPass renderPass) {
			Extent2D pGranularity;
			unsafe {
				pGranularity = new Extent2D();
				NativeMethods.vkGetRenderAreaGranularity(m, renderPass.m, &pGranularity);

				return pGranularity;
			}
		}

		public Image[] GetSwapchainImagesKHR(SwapchainKhr swapchain) {
			Result result;
			unsafe {
				uint pSwapchainImageCount;
				result = NativeMethods.vkGetSwapchainImagesKHR(m, swapchain.m, &pSwapchainImageCount, null);
				if (result != Result.Success) throw new ResultException(result);
				if (pSwapchainImageCount <= 0) return null;

				var size = Marshal.SizeOf(typeof(ulong));
				var ptrpSwapchainImages = Marshal.AllocHGlobal((int)(size * pSwapchainImageCount));
				result = NativeMethods.vkGetSwapchainImagesKHR(m, swapchain.m, &pSwapchainImageCount, (ulong*)ptrpSwapchainImages);
				if (result != Result.Success) throw new ResultException(result);

				if (pSwapchainImageCount <= 0) return null;
				var arr = new Image[pSwapchainImageCount];
				for (var i = 0; i < pSwapchainImageCount; i++) {
					arr[i] = new Image();
					arr[i].m = ((ulong*)ptrpSwapchainImages)[i];
				}

				return arr;
			}
		}

		public void InvalidateMappedMemoryRanges(uint memoryRangeCount, MappedMemoryRange pMemoryRanges) {
			Result result;
			unsafe {
				result = NativeMethods.vkInvalidateMappedMemoryRanges(m, memoryRangeCount, pMemoryRanges.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public IntPtr MapMemory(DeviceMemory memory, DeviceSize offset, DeviceSize size, uint flags) {
			Result result;
			IntPtr ppData;
			unsafe {
				ppData = new IntPtr();
				result = NativeMethods.vkMapMemory(m, memory.m, offset, size, flags, &ppData);
				if (result != Result.Success) throw new ResultException(result);

				return ppData;
			}
		}

		public void MergePipelineCaches(PipelineCache dstCache, uint srcCacheCount, PipelineCache pSrcCaches) {
			Result result;
			unsafe {
				fixed (ulong* ptrpSrcCaches = &pSrcCaches.m) result = NativeMethods.vkMergePipelineCaches(m, dstCache.m, srcCacheCount, ptrpSrcCaches);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void ResetCommandPool(CommandPool commandPool, CommandPoolResetFlags flags) {
			Result result;
			result = NativeMethods.vkResetCommandPool(m, commandPool.m, flags);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void ResetDescriptorPool(DescriptorPool descriptorPool, uint flags) {
			Result result;
			result = NativeMethods.vkResetDescriptorPool(m, descriptorPool.m, flags);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void ResetEvent(Event @event) {
			Result result;
			result = NativeMethods.vkResetEvent(m, @event.m);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void ResetFences(uint fenceCount, Fence pFences) {
			Result result;
			unsafe {
				fixed (ulong* ptrpFences = &pFences.m) result = NativeMethods.vkResetFences(m, fenceCount, ptrpFences);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void SetEvent(Event @event) {
			Result result;
			result = NativeMethods.vkSetEvent(m, @event.m);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void UnmapMemory(DeviceMemory memory) {
			NativeMethods.vkUnmapMemory(m, memory.m);
		}

		public void UpdateDescriptorSets(uint descriptorWriteCount, WriteDescriptorSet pDescriptorWrites, uint descriptorCopyCount, CopyDescriptorSet pDescriptorCopies) {
			unsafe {
				NativeMethods.vkUpdateDescriptorSets(m, descriptorWriteCount, pDescriptorWrites.m, descriptorCopyCount, pDescriptorCopies.m);
			}
		}

		public void WaitForFences(uint fenceCount, Fence pFences, Bool32 waitAll, ulong timeout) {
			Result result;
			unsafe {
				fixed (ulong* ptrpFences = &pFences.m) result = NativeMethods.vkWaitForFences(m, fenceCount, ptrpFences, waitAll, timeout);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void WaitIdle() {
			Result result;
			result = NativeMethods.vkDeviceWaitIdle(m);
			if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class Queue
	{
		public IntPtr m;

		public void BindSparse(uint bindInfoCount, BindSparseInfo pBindInfo, Fence fence) {
			Result result;
			unsafe {
				result = NativeMethods.vkQueueBindSparse(m, bindInfoCount, pBindInfo.m, fence.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void PresentKHR(PresentInfoKhr pPresentInfo) {
			Result result;
			unsafe {
				result = NativeMethods.vkQueuePresentKHR(m, pPresentInfo.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void Submit(uint submitCount, SubmitInfo pSubmits, Fence fence) {
			Result result;
			unsafe {
				result = NativeMethods.vkQueueSubmit(m, submitCount, pSubmits.m, fence.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void WaitIdle() {
			Result result;
			result = NativeMethods.vkQueueWaitIdle(m);
			if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class CommandBuffer
	{
		public IntPtr m;

		public void Begin(CommandBufferBeginInfo pBeginInfo) {
			Result result;
			unsafe {
				result = NativeMethods.vkBeginCommandBuffer(m, pBeginInfo.m);
				if (result != Result.Success) throw new ResultException(result);
			}
		}

		public void CmdBeginQuery(QueryPool queryPool, uint query, QueryControlFlags flags) {
			NativeMethods.vkCmdBeginQuery(m, queryPool.m, query, flags);
		}

		public void CmdBeginRenderPass(RenderPassBeginInfo pRenderPassBegin, SubpassContents contents) {
			unsafe {
				NativeMethods.vkCmdBeginRenderPass(m, pRenderPassBegin.m, contents);
			}
		}

		public void CmdBindDescriptorSets(PipelineBindPoint pipelineBindPoint, PipelineLayout layout, uint firstSet, uint descriptorSetCount, DescriptorSet pDescriptorSets, uint dynamicOffsetCount, uint pDynamicOffsets) {
			unsafe {
				fixed (ulong* ptrpDescriptorSets = &pDescriptorSets.m) NativeMethods.vkCmdBindDescriptorSets(m, pipelineBindPoint, layout.m, firstSet, descriptorSetCount, ptrpDescriptorSets, dynamicOffsetCount, &pDynamicOffsets);
			}
		}

		public void CmdBindIndexBuffer(Buffer buffer, DeviceSize offset, IndexType indexType) {
			NativeMethods.vkCmdBindIndexBuffer(m, buffer.m, offset, indexType);
		}

		public void CmdBindPipeline(PipelineBindPoint pipelineBindPoint, Pipeline pipeline) {
			NativeMethods.vkCmdBindPipeline(m, pipelineBindPoint, pipeline.m);
		}

		public void CmdBindVertexBuffers(uint firstBinding, uint bindingCount, Buffer pBuffers, DeviceSize pOffsets) {
			unsafe {
				fixed (ulong* ptrpBuffers = &pBuffers.m) NativeMethods.vkCmdBindVertexBuffers(m, firstBinding, bindingCount, ptrpBuffers, &pOffsets);
			}
		}

		public void CmdBlitImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageBlit pRegions, Filter filter) {
			unsafe {
				NativeMethods.vkCmdBlitImage(m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, pRegions.m, filter);
			}
		}

		public void CmdClearAttachments(uint attachmentCount, ClearAttachment pAttachments, uint rectCount, ClearRect pRects) {
			unsafe {
				NativeMethods.vkCmdClearAttachments(m, attachmentCount, &pAttachments, rectCount, &pRects);
			}
		}

		public void CmdClearColorImage(Image image, ImageLayout imageLayout, ClearColorValue pColor, uint rangeCount, ImageSubresourceRange pRanges) {
			unsafe {
				NativeMethods.vkCmdClearColorImage(m, image.m, imageLayout, pColor.m, rangeCount, &pRanges);
			}
		}

		public void CmdClearDepthStencilImage(Image image, ImageLayout imageLayout, ClearDepthStencilValue pDepthStencil, uint rangeCount, ImageSubresourceRange pRanges) {
			unsafe {
				NativeMethods.vkCmdClearDepthStencilImage(m, image.m, imageLayout, &pDepthStencil, rangeCount, &pRanges);
			}
		}

		public void CmdCopyBuffer(Buffer srcBuffer, Buffer dstBuffer, uint regionCount, BufferCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyBuffer(m, srcBuffer.m, dstBuffer.m, regionCount, &pRegions);
			}
		}

		public void CmdCopyBufferToImage(Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, uint regionCount, BufferImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyBufferToImage(m, srcBuffer.m, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdCopyImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyImage(m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdCopyImageToBuffer(Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, uint regionCount, BufferImageCopy pRegions) {
			unsafe {
				NativeMethods.vkCmdCopyImageToBuffer(m, srcImage.m, srcImageLayout, dstBuffer.m, regionCount, &pRegions);
			}
		}

		public void CmdCopyQueryPoolResults(QueryPool queryPool, uint firstQuery, uint queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags) {
			NativeMethods.vkCmdCopyQueryPoolResults(m, queryPool.m, firstQuery, queryCount, dstBuffer.m, dstOffset, stride, flags);
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerBeginEXT() {
			DebugMarkerMarkerInfoExt pMarkerInfo;
			unsafe {
				pMarkerInfo = new DebugMarkerMarkerInfoExt();
				NativeMethods.vkCmdDebugMarkerBeginEXT(m, pMarkerInfo.m);

				return pMarkerInfo;
			}
		}

		public void CmdDebugMarkerEndEXT() {
			NativeMethods.vkCmdDebugMarkerEndEXT(m);
		}

		public DebugMarkerMarkerInfoExt CmdDebugMarkerInsertEXT() {
			DebugMarkerMarkerInfoExt pMarkerInfo;
			unsafe {
				pMarkerInfo = new DebugMarkerMarkerInfoExt();
				NativeMethods.vkCmdDebugMarkerInsertEXT(m, pMarkerInfo.m);

				return pMarkerInfo;
			}
		}

		public void CmdDispatch(uint x, uint y, uint z) {
			NativeMethods.vkCmdDispatch(m, x, y, z);
		}

		public void CmdDispatchIndirect(Buffer buffer, DeviceSize offset) {
			NativeMethods.vkCmdDispatchIndirect(m, buffer.m, offset);
		}

		public void CmdDraw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) {
			NativeMethods.vkCmdDraw(m, vertexCount, instanceCount, firstVertex, firstInstance);
		}

		public void CmdDrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int vertexOffset, uint firstInstance) {
			NativeMethods.vkCmdDrawIndexed(m, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
		}

		public void CmdDrawIndexedIndirect(Buffer buffer, DeviceSize offset, uint drawCount, uint stride) {
			NativeMethods.vkCmdDrawIndexedIndirect(m, buffer.m, offset, drawCount, stride);
		}

		public void CmdDrawIndirect(Buffer buffer, DeviceSize offset, uint drawCount, uint stride) {
			NativeMethods.vkCmdDrawIndirect(m, buffer.m, offset, drawCount, stride);
		}

		public void CmdEndQuery(QueryPool queryPool, uint query) {
			NativeMethods.vkCmdEndQuery(m, queryPool.m, query);
		}

		public void CmdEndRenderPass() {
			NativeMethods.vkCmdEndRenderPass(m);
		}

		public void CmdExecuteCommands(uint commandBufferCount, CommandBuffer pCommandBuffers) {
			unsafe {
				fixed (IntPtr* ptrpCommandBuffers = &pCommandBuffers.m) NativeMethods.vkCmdExecuteCommands(m, commandBufferCount, ptrpCommandBuffers);
			}
		}

		public void CmdFillBuffer(Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, uint data) {
			NativeMethods.vkCmdFillBuffer(m, dstBuffer.m, dstOffset, size, data);
		}

		public void CmdNextSubpass(SubpassContents contents) {
			NativeMethods.vkCmdNextSubpass(m, contents);
		}

		public void CmdPipelineBarrier(PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, uint memoryBarrierCount, MemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers) {
			unsafe {
				NativeMethods.vkCmdPipelineBarrier(m, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers.m, bufferMemoryBarrierCount, pBufferMemoryBarriers.m, imageMemoryBarrierCount, pImageMemoryBarriers.m);
			}
		}

		public void CmdPushConstants(PipelineLayout layout, ShaderStageFlags stageFlags, uint offset, uint size, IntPtr pValues) {
			NativeMethods.vkCmdPushConstants(m, layout.m, stageFlags, offset, size, pValues);
		}

		public void CmdResetEvent(Event @event, PipelineStageFlags stageMask) {
			NativeMethods.vkCmdResetEvent(m, @event.m, stageMask);
		}

		public void CmdResetQueryPool(QueryPool queryPool, uint firstQuery, uint queryCount) {
			NativeMethods.vkCmdResetQueryPool(m, queryPool.m, firstQuery, queryCount);
		}

		public void CmdResolveImage(Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, uint regionCount, ImageResolve pRegions) {
			unsafe {
				NativeMethods.vkCmdResolveImage(m, srcImage.m, srcImageLayout, dstImage.m, dstImageLayout, regionCount, &pRegions);
			}
		}

		public void CmdSetBlendConstants(float blendConstants) {
			NativeMethods.vkCmdSetBlendConstants(m, blendConstants);
		}

		public void CmdSetDepthBias(float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor) {
			NativeMethods.vkCmdSetDepthBias(m, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
		}

		public void CmdSetDepthBounds(float minDepthBounds, float maxDepthBounds) {
			NativeMethods.vkCmdSetDepthBounds(m, minDepthBounds, maxDepthBounds);
		}

		public void CmdSetEvent(Event @event, PipelineStageFlags stageMask) {
			NativeMethods.vkCmdSetEvent(m, @event.m, stageMask);
		}

		public void CmdSetLineWidth(float lineWidth) {
			NativeMethods.vkCmdSetLineWidth(m, lineWidth);
		}

		public void CmdSetScissor(uint firstScissor, uint scissorCount, Rect2D pScissors) {
			unsafe {
				NativeMethods.vkCmdSetScissor(m, firstScissor, scissorCount, &pScissors);
			}
		}

		public void CmdSetStencilCompareMask(StencilFaceFlags faceMask, uint compareMask) {
			NativeMethods.vkCmdSetStencilCompareMask(m, faceMask, compareMask);
		}

		public void CmdSetStencilReference(StencilFaceFlags faceMask, uint reference) {
			NativeMethods.vkCmdSetStencilReference(m, faceMask, reference);
		}

		public void CmdSetStencilWriteMask(StencilFaceFlags faceMask, uint writeMask) {
			NativeMethods.vkCmdSetStencilWriteMask(m, faceMask, writeMask);
		}

		public void CmdSetViewport(uint firstViewport, uint viewportCount, Viewport pViewports) {
			unsafe {
				NativeMethods.vkCmdSetViewport(m, firstViewport, viewportCount, &pViewports);
			}
		}

		public void CmdUpdateBuffer(Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, uint pData) {
			unsafe {
				NativeMethods.vkCmdUpdateBuffer(m, dstBuffer.m, dstOffset, dataSize, &pData);
			}
		}

		public void CmdWaitEvents(uint eventCount, Event pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, uint memoryBarrierCount, MemoryBarrier pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier pImageMemoryBarriers) {
			unsafe {
				fixed (ulong* ptrpEvents = &pEvents.m) NativeMethods.vkCmdWaitEvents(m, eventCount, ptrpEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers.m, bufferMemoryBarrierCount, pBufferMemoryBarriers.m, imageMemoryBarrierCount, pImageMemoryBarriers.m);
			}
		}

		public void CmdWriteTimestamp(PipelineStageFlags pipelineStage, QueryPool queryPool, uint query) {
			NativeMethods.vkCmdWriteTimestamp(m, pipelineStage, queryPool.m, query);
		}

		public void End() {
			Result result;
			result = NativeMethods.vkEndCommandBuffer(m);
			if (result != Result.Success) throw new ResultException(result);
		}

		public void Reset(CommandBufferResetFlags flags) {
			Result result;
			result = NativeMethods.vkResetCommandBuffer(m, flags);
			if (result != Result.Success) throw new ResultException(result);
		}
	}

	public class DeviceMemory
	{
		public ulong m;
	}

	public class CommandPool
	{
		public ulong m;
	}

	public class Buffer
	{
		public ulong m;
	}

	public class BufferView
	{
		public ulong m;
	}

	public class Image
	{
		public ulong m;
	}

	public class ImageView
	{
		public ulong m;
	}

	public class ShaderModule
	{
		public ulong m;
	}

	public class Pipeline
	{
		public ulong m;
	}

	public class PipelineLayout
	{
		public ulong m;
	}

	public class Sampler
	{
		public ulong m;
	}

	public class DescriptorSet
	{
		public ulong m;
	}

	public class DescriptorSetLayout
	{
		public ulong m;
	}

	public class DescriptorPool
	{
		public ulong m;
	}

	public class Fence
	{
		public ulong m;
	}

	public class Semaphore
	{
		public ulong m;
	}

	public class Event
	{
		public ulong m;
	}

	public class QueryPool
	{
		public ulong m;
	}

	public class Framebuffer
	{
		public ulong m;
	}

	public class RenderPass
	{
		public ulong m;
	}

	public class PipelineCache
	{
		public ulong m;
	}

	public class DisplayKhr
	{
		public ulong m;
	}

	public class DisplayModeKhr
	{
		public ulong m;
	}

	public class SurfaceKhr
	{
		public ulong m;
	}

	public class SwapchainKhr
	{
		public ulong m;
	}

	public class DebugReportCallbackExt
	{
		public ulong m;
	}
}