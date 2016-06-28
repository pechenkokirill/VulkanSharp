using System;
using System.Runtime.InteropServices;

namespace VulkanSharp.Interop
{
	public static class NativeMethods
	{
		public const string VULKAN_LIBRARY = "vulkan-1";

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateInstance (InstanceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, IntPtr* pInstance);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyInstance (IntPtr instance, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkEnumeratePhysicalDevices (IntPtr instance, uint* pPhysicalDeviceCount, IntPtr* pPhysicalDevices);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern IntPtr vkGetDeviceProcAddr (IntPtr device, string pName);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern IntPtr vkGetInstanceProcAddr (IntPtr instance, string pName);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceProperties (IntPtr physicalDevice, PhysicalDeviceProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceQueueFamilyProperties (IntPtr physicalDevice, uint* pQueueFamilyPropertyCount, QueueFamilyProperties* pQueueFamilyProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceMemoryProperties (IntPtr physicalDevice, PhysicalDeviceMemoryProperties* pMemoryProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceFeatures (IntPtr physicalDevice, PhysicalDeviceFeatures* pFeatures);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceFormatProperties (IntPtr physicalDevice, Format format, FormatProperties* pFormatProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceImageFormatProperties (IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* pImageFormatProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDevice (IntPtr physicalDevice, DeviceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, IntPtr* pDevice);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyDevice (IntPtr device, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkEnumerateInstanceLayerProperties (uint* pPropertyCount, LayerProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkEnumerateInstanceExtensionProperties (string pLayerName, uint* pPropertyCount, ExtensionProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkEnumerateDeviceLayerProperties (IntPtr physicalDevice, uint* pPropertyCount, LayerProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkEnumerateDeviceExtensionProperties (IntPtr physicalDevice, string pLayerName, uint* pPropertyCount, ExtensionProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetDeviceQueue (IntPtr device, uint queueFamilyIndex, uint queueIndex, IntPtr* pQueue);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkQueueSubmit (IntPtr queue, uint submitCount, SubmitInfo* pSubmits, ulong fence);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkQueueWaitIdle (IntPtr queue);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkDeviceWaitIdle (IntPtr device);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkAllocateMemory (IntPtr device, MemoryAllocateInfo* pAllocateInfo, AllocationCallbacks* pAllocator, ulong* pMemory);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkFreeMemory (IntPtr device, ulong memory, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkMapMemory (IntPtr device, ulong memory, DeviceSize offset, DeviceSize size, uint flags, IntPtr* ppData);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkUnmapMemory (IntPtr device, ulong memory);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkFlushMappedMemoryRanges (IntPtr device, uint memoryRangeCount, MappedMemoryRange* pMemoryRanges);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkInvalidateMappedMemoryRanges (IntPtr device, uint memoryRangeCount, MappedMemoryRange* pMemoryRanges);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetDeviceMemoryCommitment (IntPtr device, ulong memory, DeviceSize* pCommittedMemoryInBytes);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetBufferMemoryRequirements (IntPtr device, ulong buffer, MemoryRequirements* pMemoryRequirements);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkBindBufferMemory (IntPtr device, ulong buffer, ulong memory, DeviceSize memoryOffset);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetImageMemoryRequirements (IntPtr device, ulong image, MemoryRequirements* pMemoryRequirements);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkBindImageMemory (IntPtr device, ulong image, ulong memory, DeviceSize memoryOffset);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetImageSparseMemoryRequirements (IntPtr device, ulong image, uint* pSparseMemoryRequirementCount, SparseImageMemoryRequirements* pSparseMemoryRequirements);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetPhysicalDeviceSparseImageFormatProperties (IntPtr physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, uint* pPropertyCount, SparseImageFormatProperties* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkQueueBindSparse (IntPtr queue, uint bindInfoCount, BindSparseInfo* pBindInfo, ulong fence);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateFence (IntPtr device, FenceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pFence);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyFence (IntPtr device, ulong fence, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkResetFences (IntPtr device, uint fenceCount, ulong* pFences);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkGetFenceStatus (IntPtr device, ulong fence);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkWaitForFences (IntPtr device, uint fenceCount, ulong* pFences, Bool32 waitAll, ulong timeout);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateSemaphore (IntPtr device, SemaphoreCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pSemaphore);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroySemaphore (IntPtr device, ulong semaphore, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateEvent (IntPtr device, EventCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pEvent);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyEvent (IntPtr device, ulong @event, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkGetEventStatus (IntPtr device, ulong @event);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkSetEvent (IntPtr device, ulong @event);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkResetEvent (IntPtr device, ulong @event);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateQueryPool (IntPtr device, QueryPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pQueryPool);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyQueryPool (IntPtr device, ulong queryPool, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkGetQueryPoolResults (IntPtr device, ulong queryPool, uint firstQuery, uint queryCount, UIntPtr dataSize, IntPtr pData, DeviceSize stride, QueryResultFlags flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateBuffer (IntPtr device, BufferCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pBuffer);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyBuffer (IntPtr device, ulong buffer, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateBufferView (IntPtr device, BufferViewCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pView);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyBufferView (IntPtr device, ulong bufferView, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateImage (IntPtr device, ImageCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pImage);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyImage (IntPtr device, ulong image, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetImageSubresourceLayout (IntPtr device, ulong image, ImageSubresource* pSubresource, SubresourceLayout* pLayout);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateImageView (IntPtr device, ImageViewCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pView);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyImageView (IntPtr device, ulong imageView, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateShaderModule (IntPtr device, ShaderModuleCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pShaderModule);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyShaderModule (IntPtr device, ulong shaderModule, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreatePipelineCache (IntPtr device, PipelineCacheCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pPipelineCache);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyPipelineCache (IntPtr device, ulong pipelineCache, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPipelineCacheData (IntPtr device, ulong pipelineCache, UIntPtr* pDataSize, IntPtr pData);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkMergePipelineCaches (IntPtr device, ulong dstCache, uint srcCacheCount, ulong* pSrcCaches);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateGraphicsPipelines (IntPtr device, ulong pipelineCache, uint createInfoCount, GraphicsPipelineCreateInfo* pCreateInfos, AllocationCallbacks* pAllocator, ulong* pPipelines);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateComputePipelines (IntPtr device, ulong pipelineCache, uint createInfoCount, ComputePipelineCreateInfo* pCreateInfos, AllocationCallbacks* pAllocator, ulong* pPipelines);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyPipeline (IntPtr device, ulong pipeline, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreatePipelineLayout (IntPtr device, PipelineLayoutCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pPipelineLayout);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyPipelineLayout (IntPtr device, ulong pipelineLayout, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateSampler (IntPtr device, SamplerCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pSampler);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroySampler (IntPtr device, ulong sampler, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDescriptorSetLayout (IntPtr device, DescriptorSetLayoutCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pSetLayout);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyDescriptorSetLayout (IntPtr device, ulong descriptorSetLayout, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDescriptorPool (IntPtr device, DescriptorPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pDescriptorPool);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyDescriptorPool (IntPtr device, ulong descriptorPool, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkResetDescriptorPool (IntPtr device, ulong descriptorPool, uint flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkAllocateDescriptorSets (IntPtr device, DescriptorSetAllocateInfo* pAllocateInfo, ulong* pDescriptorSets);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkFreeDescriptorSets (IntPtr device, ulong descriptorPool, uint descriptorSetCount, ulong* pDescriptorSets);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkUpdateDescriptorSets (IntPtr device, uint descriptorWriteCount, WriteDescriptorSet* pDescriptorWrites, uint descriptorCopyCount, CopyDescriptorSet* pDescriptorCopies);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateFramebuffer (IntPtr device, FramebufferCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pFramebuffer);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyFramebuffer (IntPtr device, ulong framebuffer, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateRenderPass (IntPtr device, RenderPassCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pRenderPass);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyRenderPass (IntPtr device, ulong renderPass, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkGetRenderAreaGranularity (IntPtr device, ulong renderPass, Extent2D* pGranularity);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateCommandPool (IntPtr device, CommandPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pCommandPool);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyCommandPool (IntPtr device, ulong commandPool, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkResetCommandPool (IntPtr device, ulong commandPool, CommandPoolResetFlags flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkAllocateCommandBuffers (IntPtr device, CommandBufferAllocateInfo* pAllocateInfo, IntPtr* pCommandBuffers);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkFreeCommandBuffers (IntPtr device, ulong commandPool, uint commandBufferCount, IntPtr* pCommandBuffers);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkBeginCommandBuffer (IntPtr commandBuffer, CommandBufferBeginInfo* pBeginInfo);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEndCommandBuffer (IntPtr commandBuffer);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkResetCommandBuffer (IntPtr commandBuffer, CommandBufferResetFlags flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdBindPipeline (IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, ulong pipeline);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdSetViewport (IntPtr commandBuffer, uint firstViewport, uint viewportCount, Viewport* pViewports);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdSetScissor (IntPtr commandBuffer, uint firstScissor, uint scissorCount, Rect2D* pScissors);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetLineWidth (IntPtr commandBuffer, float lineWidth);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetDepthBias (IntPtr commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetBlendConstants (IntPtr commandBuffer, float blendConstants);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetDepthBounds (IntPtr commandBuffer, float minDepthBounds, float maxDepthBounds);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetStencilCompareMask (IntPtr commandBuffer, StencilFaceFlags faceMask, uint compareMask);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetStencilWriteMask (IntPtr commandBuffer, StencilFaceFlags faceMask, uint writeMask);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetStencilReference (IntPtr commandBuffer, StencilFaceFlags faceMask, uint reference);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdBindDescriptorSets (IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, ulong layout, uint firstSet, uint descriptorSetCount, ulong* pDescriptorSets, uint dynamicOffsetCount, uint* pDynamicOffsets);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdBindIndexBuffer (IntPtr commandBuffer, ulong buffer, DeviceSize offset, IndexType indexType);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdBindVertexBuffers (IntPtr commandBuffer, uint firstBinding, uint bindingCount, ulong* pBuffers, DeviceSize* pOffsets);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDraw (IntPtr commandBuffer, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDrawIndexed (IntPtr commandBuffer, uint indexCount, uint instanceCount, uint firstIndex, int vertexOffset, uint firstInstance);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDrawIndirect (IntPtr commandBuffer, ulong buffer, DeviceSize offset, uint drawCount, uint stride);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDrawIndexedIndirect (IntPtr commandBuffer, ulong buffer, DeviceSize offset, uint drawCount, uint stride);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDispatch (IntPtr commandBuffer, uint x, uint y, uint z);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDispatchIndirect (IntPtr commandBuffer, ulong buffer, DeviceSize offset);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdCopyBuffer (IntPtr commandBuffer, ulong srcBuffer, ulong dstBuffer, uint regionCount, BufferCopy* pRegions);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdCopyImage (IntPtr commandBuffer, ulong srcImage, ImageLayout srcImageLayout, ulong dstImage, ImageLayout dstImageLayout, uint regionCount, ImageCopy* pRegions);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdBlitImage (IntPtr commandBuffer, ulong srcImage, ImageLayout srcImageLayout, ulong dstImage, ImageLayout dstImageLayout, uint regionCount, ImageBlit* pRegions, Filter filter);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdCopyBufferToImage (IntPtr commandBuffer, ulong srcBuffer, ulong dstImage, ImageLayout dstImageLayout, uint regionCount, BufferImageCopy* pRegions);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdCopyImageToBuffer (IntPtr commandBuffer, ulong srcImage, ImageLayout srcImageLayout, ulong dstBuffer, uint regionCount, BufferImageCopy* pRegions);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdUpdateBuffer (IntPtr commandBuffer, ulong dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, uint* pData);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdFillBuffer (IntPtr commandBuffer, ulong dstBuffer, DeviceSize dstOffset, DeviceSize size, uint data);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdClearColorImage (IntPtr commandBuffer, ulong image, ImageLayout imageLayout, ClearColorValue* pColor, uint rangeCount, ImageSubresourceRange* pRanges);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdClearDepthStencilImage (IntPtr commandBuffer, ulong image, ImageLayout imageLayout, ClearDepthStencilValue* pDepthStencil, uint rangeCount, ImageSubresourceRange* pRanges);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdClearAttachments (IntPtr commandBuffer, uint attachmentCount, ClearAttachment* pAttachments, uint rectCount, ClearRect* pRects);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdResolveImage (IntPtr commandBuffer, ulong srcImage, ImageLayout srcImageLayout, ulong dstImage, ImageLayout dstImageLayout, uint regionCount, ImageResolve* pRegions);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdSetEvent (IntPtr commandBuffer, ulong @event, PipelineStageFlags stageMask);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdResetEvent (IntPtr commandBuffer, ulong @event, PipelineStageFlags stageMask);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdWaitEvents (IntPtr commandBuffer, uint eventCount, ulong* pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, uint memoryBarrierCount, MemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier* pImageMemoryBarriers);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdPipelineBarrier (IntPtr commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, uint memoryBarrierCount, MemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, BufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, ImageMemoryBarrier* pImageMemoryBarriers);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdBeginQuery (IntPtr commandBuffer, ulong queryPool, uint query, QueryControlFlags flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdEndQuery (IntPtr commandBuffer, ulong queryPool, uint query);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdResetQueryPool (IntPtr commandBuffer, ulong queryPool, uint firstQuery, uint queryCount);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdWriteTimestamp (IntPtr commandBuffer, PipelineStageFlags pipelineStage, ulong queryPool, uint query);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdCopyQueryPoolResults (IntPtr commandBuffer, ulong queryPool, uint firstQuery, uint queryCount, ulong dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdPushConstants (IntPtr commandBuffer, ulong layout, ShaderStageFlags stageFlags, uint offset, uint size, IntPtr pValues);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdBeginRenderPass (IntPtr commandBuffer, RenderPassBeginInfo* pRenderPassBegin, SubpassContents contents);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdNextSubpass (IntPtr commandBuffer, SubpassContents contents);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdEndRenderPass (IntPtr commandBuffer);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdExecuteCommands (IntPtr commandBuffer, uint commandBufferCount, IntPtr* pCommandBuffers);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceDisplayPropertiesKHR (IntPtr physicalDevice, uint* pPropertyCount, DisplayPropertiesKhr* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR (IntPtr physicalDevice, uint* pPropertyCount, DisplayPlanePropertiesKhr* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetDisplayPlaneSupportedDisplaysKHR (IntPtr physicalDevice, uint planeIndex, uint* pDisplayCount, ulong* pDisplays);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetDisplayModePropertiesKHR (IntPtr physicalDevice, ulong display, uint* pPropertyCount, DisplayModePropertiesKhr* pProperties);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDisplayModeKHR (IntPtr physicalDevice, ulong display, DisplayModeCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pMode);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetDisplayPlaneCapabilitiesKHR (IntPtr physicalDevice, ulong mode, uint planeIndex, DisplayPlaneCapabilitiesKhr* pCapabilities);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDisplayPlaneSurfaceKHR (IntPtr instance, DisplaySurfaceCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pSurface);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateSharedSwapchainsKHR (IntPtr device, uint swapchainCount, SwapchainCreateInfoKhr* pCreateInfos, AllocationCallbacks* pAllocator, ulong* pSwapchains);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroySurfaceKHR (IntPtr instance, ulong surface, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceSurfaceSupportKHR (IntPtr physicalDevice, uint queueFamilyIndex, ulong surface, Bool32* pSupported);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR (IntPtr physicalDevice, ulong surface, SurfaceCapabilitiesKhr* pSurfaceCapabilities);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceSurfaceFormatsKHR (IntPtr physicalDevice, ulong surface, uint* pSurfaceFormatCount, SurfaceFormatKhr* pSurfaceFormats);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetPhysicalDeviceSurfacePresentModesKHR (IntPtr physicalDevice, ulong surface, uint* pPresentModeCount, PresentModeKhr* pPresentModes);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateSwapchainKHR (IntPtr device, SwapchainCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pSwapchain);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroySwapchainKHR (IntPtr device, ulong swapchain, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkGetSwapchainImagesKHR (IntPtr device, ulong swapchain, uint* pSwapchainImageCount, ulong* pSwapchainImages);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkAcquireNextImageKHR (IntPtr device, ulong swapchain, ulong timeout, ulong semaphore, ulong fence, uint* pImageIndex);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkQueuePresentKHR (IntPtr queue, PresentInfoKhr* pPresentInfo);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkCreateDebugReportCallbackEXT (IntPtr instance, DebugReportCallbackCreateInfoExt* pCreateInfo, AllocationCallbacks* pAllocator, ulong* pCallback);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkDestroyDebugReportCallbackEXT (IntPtr instance, ulong callback, AllocationCallbacks* pAllocator);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkDebugReportMessageEXT (IntPtr instance, DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, ulong @object, UIntPtr location, int messageCode, string pLayerPrefix, string pMessage);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkDebugMarkerSetObjectNameEXT (IntPtr device, DebugMarkerObjectNameInfoExt* pNameInfo);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe Result vkDebugMarkerSetObjectTagEXT (IntPtr device, DebugMarkerObjectTagInfoExt* pTagInfo);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdDebugMarkerBeginEXT (IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkCmdDebugMarkerEndEXT (IntPtr commandBuffer);

		[DllImport (VULKAN_LIBRARY, CallingConvention = CallingConvention.Winapi)]
		public static extern unsafe void vkCmdDebugMarkerInsertEXT (IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);
	}
}
