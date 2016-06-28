using System;
using System.Runtime.InteropServices;

namespace VulkanSharp.Interop
{
	internal static class NativeMethods
	{
		const string VulkanLibrary = "vulkan-1";

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateInstance (InstanceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, IntPtr* pInstance);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyInstance (IntPtr instance, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEnumeratePhysicalDevices (IntPtr instance, UInt32* pPhysicalDeviceCount, IntPtr* pPhysicalDevices);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern IntPtr vkGetDeviceProcAddr (IntPtr device, string pName);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern IntPtr vkGetInstanceProcAddr (IntPtr instance, string pName);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceProperties (IntPtr physicalDevice, PhysicalDeviceProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceQueueFamilyProperties (IntPtr physicalDevice, UInt32* pQueueFamilyPropertyCount, QueueFamilyProperties* pQueueFamilyProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceMemoryProperties (IntPtr physicalDevice, PhysicalDeviceMemoryProperties* pMemoryProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceFeatures (IntPtr physicalDevice, PhysicalDeviceFeatures* pFeatures);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceFormatProperties (IntPtr physicalDevice, Format format, FormatProperties* pFormatProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceImageFormatProperties (IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* pImageFormatProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDevice (IntPtr physicalDevice, DeviceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, IntPtr* pDevice);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyDevice (IntPtr device, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEnumerateInstanceLayerProperties (UInt32* pPropertyCount, LayerProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEnumerateInstanceExtensionProperties (string pLayerName, UInt32* pPropertyCount, ExtensionProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEnumerateDeviceLayerProperties (IntPtr physicalDevice, UInt32* pPropertyCount, LayerProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEnumerateDeviceExtensionProperties (IntPtr physicalDevice, string pLayerName, UInt32* pPropertyCount, ExtensionProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetDeviceQueue (IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, IntPtr* pQueue);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkQueueSubmit (IntPtr queue, UInt32 submitCount, SubmitInfo* pSubmits, UInt64 fence);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkQueueWaitIdle (IntPtr queue);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkDeviceWaitIdle (IntPtr device);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkAllocateMemory (IntPtr device, MemoryAllocateInfo* pAllocateInfo, AllocationCallbacks* pAllocator, UInt64* pMemory);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkFreeMemory (IntPtr device, UInt64 memory, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkMapMemory (IntPtr device, UInt64 memory, DeviceSize offset, DeviceSize size, UInt32 flags, IntPtr* ppData);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkUnmapMemory (IntPtr device, UInt64 memory);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkFlushMappedMemoryRanges (IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* pMemoryRanges);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkInvalidateMappedMemoryRanges (IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* pMemoryRanges);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetDeviceMemoryCommitment (IntPtr device, UInt64 memory, DeviceSize* pCommittedMemoryInBytes);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetBufferMemoryRequirements (IntPtr device, UInt64 buffer, MemoryRequirements* pMemoryRequirements);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkBindBufferMemory (IntPtr device, UInt64 buffer, UInt64 memory, DeviceSize memoryOffset);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetImageMemoryRequirements (IntPtr device, UInt64 image, MemoryRequirements* pMemoryRequirements);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkBindImageMemory (IntPtr device, UInt64 image, UInt64 memory, DeviceSize memoryOffset);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetImageSparseMemoryRequirements (IntPtr device, UInt64 image, UInt32* pSparseMemoryRequirementCount, SparseImageMemoryRequirements* pSparseMemoryRequirements);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetPhysicalDeviceSparseImageFormatProperties (IntPtr physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* pPropertyCount, SparseImageFormatProperties* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkQueueBindSparse (IntPtr queue, UInt32 bindInfoCount, BindSparseInfo* pBindInfo, UInt64 fence);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateFence (IntPtr device, FenceCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pFence);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyFence (IntPtr device, UInt64 fence, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkResetFences (IntPtr device, UInt32 fenceCount, UInt64* pFences);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetFenceStatus (IntPtr device, UInt64 fence);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkWaitForFences (IntPtr device, UInt32 fenceCount, UInt64* pFences, Bool32 waitAll, UInt64 timeout);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateSemaphore (IntPtr device, SemaphoreCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSemaphore);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroySemaphore (IntPtr device, UInt64 semaphore, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateEvent (IntPtr device, EventCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pEvent);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyEvent (IntPtr device, UInt64 @event, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetEventStatus (IntPtr device, UInt64 @event);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkSetEvent (IntPtr device, UInt64 @event);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkResetEvent (IntPtr device, UInt64 @event);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateQueryPool (IntPtr device, QueryPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pQueryPool);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyQueryPool (IntPtr device, UInt64 queryPool, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetQueryPoolResults (IntPtr device, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr pData, DeviceSize stride, QueryResultFlags flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateBuffer (IntPtr device, BufferCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pBuffer);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyBuffer (IntPtr device, UInt64 buffer, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateBufferView (IntPtr device, BufferViewCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pView);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyBufferView (IntPtr device, UInt64 bufferView, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateImage (IntPtr device, ImageCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pImage);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyImage (IntPtr device, UInt64 image, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetImageSubresourceLayout (IntPtr device, UInt64 image, ImageSubresource* pSubresource, SubresourceLayout* pLayout);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateImageView (IntPtr device, ImageViewCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pView);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyImageView (IntPtr device, UInt64 imageView, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateShaderModule (IntPtr device, ShaderModuleCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pShaderModule);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyShaderModule (IntPtr device, UInt64 shaderModule, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreatePipelineCache (IntPtr device, PipelineCacheCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pPipelineCache);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyPipelineCache (IntPtr device, UInt64 pipelineCache, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPipelineCacheData (IntPtr device, UInt64 pipelineCache, UIntPtr* pDataSize, IntPtr pData);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkMergePipelineCaches (IntPtr device, UInt64 dstCache, UInt32 srcCacheCount, UInt64* pSrcCaches);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateGraphicsPipelines (IntPtr device, UInt64 pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* pCreateInfos, AllocationCallbacks* pAllocator, UInt64* pPipelines);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateComputePipelines (IntPtr device, UInt64 pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* pCreateInfos, AllocationCallbacks* pAllocator, UInt64* pPipelines);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyPipeline (IntPtr device, UInt64 pipeline, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreatePipelineLayout (IntPtr device, PipelineLayoutCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pPipelineLayout);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyPipelineLayout (IntPtr device, UInt64 pipelineLayout, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateSampler (IntPtr device, SamplerCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSampler);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroySampler (IntPtr device, UInt64 sampler, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDescriptorSetLayout (IntPtr device, DescriptorSetLayoutCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSetLayout);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyDescriptorSetLayout (IntPtr device, UInt64 descriptorSetLayout, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDescriptorPool (IntPtr device, DescriptorPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pDescriptorPool);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyDescriptorPool (IntPtr device, UInt64 descriptorPool, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkResetDescriptorPool (IntPtr device, UInt64 descriptorPool, UInt32 flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkAllocateDescriptorSets (IntPtr device, DescriptorSetAllocateInfo* pAllocateInfo, UInt64* pDescriptorSets);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkFreeDescriptorSets (IntPtr device, UInt64 descriptorPool, UInt32 descriptorSetCount, UInt64* pDescriptorSets);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkUpdateDescriptorSets (IntPtr device, UInt32 descriptorWriteCount, WriteDescriptorSet* pDescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* pDescriptorCopies);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateFramebuffer (IntPtr device, FramebufferCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pFramebuffer);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyFramebuffer (IntPtr device, UInt64 framebuffer, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateRenderPass (IntPtr device, RenderPassCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pRenderPass);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyRenderPass (IntPtr device, UInt64 renderPass, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkGetRenderAreaGranularity (IntPtr device, UInt64 renderPass, Extent2D* pGranularity);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateCommandPool (IntPtr device, CommandPoolCreateInfo* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pCommandPool);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyCommandPool (IntPtr device, UInt64 commandPool, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkResetCommandPool (IntPtr device, UInt64 commandPool, CommandPoolResetFlags flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkAllocateCommandBuffers (IntPtr device, CommandBufferAllocateInfo* pAllocateInfo, IntPtr* pCommandBuffers);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkFreeCommandBuffers (IntPtr device, UInt64 commandPool, UInt32 commandBufferCount, IntPtr* pCommandBuffers);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkBeginCommandBuffer (IntPtr commandBuffer, CommandBufferBeginInfo* pBeginInfo);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkEndCommandBuffer (IntPtr commandBuffer);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkResetCommandBuffer (IntPtr commandBuffer, CommandBufferResetFlags flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBindPipeline (IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, UInt64 pipeline);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetViewport (IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* pViewports);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetScissor (IntPtr commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* pScissors);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetLineWidth (IntPtr commandBuffer, float lineWidth);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetDepthBias (IntPtr commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetBlendConstants (IntPtr commandBuffer, float blendConstants);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetDepthBounds (IntPtr commandBuffer, float minDepthBounds, float maxDepthBounds);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetStencilCompareMask (IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetStencilWriteMask (IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetStencilReference (IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 reference);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBindDescriptorSets (IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, UInt64 layout, UInt32 firstSet, UInt32 descriptorSetCount, UInt64* pDescriptorSets, UInt32 dynamicOffsetCount, UInt32* pDynamicOffsets);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBindIndexBuffer (IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, IndexType indexType);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBindVertexBuffers (IntPtr commandBuffer, UInt32 firstBinding, UInt32 bindingCount, UInt64* pBuffers, DeviceSize* pOffsets);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDraw (IntPtr commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDrawIndexed (IntPtr commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDrawIndirect (IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDrawIndexedIndirect (IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDispatch (IntPtr commandBuffer, UInt32 x, UInt32 y, UInt32 z);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDispatchIndirect (IntPtr commandBuffer, UInt64 buffer, DeviceSize offset);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdCopyBuffer (IntPtr commandBuffer, UInt64 srcBuffer, UInt64 dstBuffer, UInt32 regionCount, BufferCopy* pRegions);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdCopyImage (IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* pRegions);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBlitImage (IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* pRegions, Filter filter);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdCopyBufferToImage (IntPtr commandBuffer, UInt64 srcBuffer, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* pRegions);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdCopyImageToBuffer (IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstBuffer, UInt32 regionCount, BufferImageCopy* pRegions);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdUpdateBuffer (IntPtr commandBuffer, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32* pData);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdFillBuffer (IntPtr commandBuffer, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdClearColorImage (IntPtr commandBuffer, UInt64 image, ImageLayout imageLayout, ClearColorValue* pColor, UInt32 rangeCount, ImageSubresourceRange* pRanges);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdClearDepthStencilImage (IntPtr commandBuffer, UInt64 image, ImageLayout imageLayout, ClearDepthStencilValue* pDepthStencil, UInt32 rangeCount, ImageSubresourceRange* pRanges);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdClearAttachments (IntPtr commandBuffer, UInt32 attachmentCount, ClearAttachment* pAttachments, UInt32 rectCount, ClearRect* pRects);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdResolveImage (IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* pRegions);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdSetEvent (IntPtr commandBuffer, UInt64 @event, PipelineStageFlags stageMask);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdResetEvent (IntPtr commandBuffer, UInt64 @event, PipelineStageFlags stageMask);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdWaitEvents (IntPtr commandBuffer, UInt32 eventCount, UInt64* pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* pImageMemoryBarriers);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdPipelineBarrier (IntPtr commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* pImageMemoryBarriers);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBeginQuery (IntPtr commandBuffer, UInt64 queryPool, UInt32 query, QueryControlFlags flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdEndQuery (IntPtr commandBuffer, UInt64 queryPool, UInt32 query);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdResetQueryPool (IntPtr commandBuffer, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdWriteTimestamp (IntPtr commandBuffer, PipelineStageFlags pipelineStage, UInt64 queryPool, UInt32 query);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdCopyQueryPoolResults (IntPtr commandBuffer, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdPushConstants (IntPtr commandBuffer, UInt64 layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr pValues);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdBeginRenderPass (IntPtr commandBuffer, RenderPassBeginInfo* pRenderPassBegin, SubpassContents contents);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdNextSubpass (IntPtr commandBuffer, SubpassContents contents);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdEndRenderPass (IntPtr commandBuffer);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdExecuteCommands (IntPtr commandBuffer, UInt32 commandBufferCount, IntPtr* pCommandBuffers);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceDisplayPropertiesKHR (IntPtr physicalDevice, UInt32* pPropertyCount, DisplayPropertiesKhr* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR (IntPtr physicalDevice, UInt32* pPropertyCount, DisplayPlanePropertiesKhr* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetDisplayPlaneSupportedDisplaysKHR (IntPtr physicalDevice, UInt32 planeIndex, UInt32* pDisplayCount, UInt64* pDisplays);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetDisplayModePropertiesKHR (IntPtr physicalDevice, UInt64 display, UInt32* pPropertyCount, DisplayModePropertiesKhr* pProperties);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDisplayModeKHR (IntPtr physicalDevice, UInt64 display, DisplayModeCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pMode);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetDisplayPlaneCapabilitiesKHR (IntPtr physicalDevice, UInt64 mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKhr* pCapabilities);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDisplayPlaneSurfaceKHR (IntPtr instance, DisplaySurfaceCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSurface);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateSharedSwapchainsKHR (IntPtr device, UInt32 swapchainCount, SwapchainCreateInfoKhr* pCreateInfos, AllocationCallbacks* pAllocator, UInt64* pSwapchains);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroySurfaceKHR (IntPtr instance, UInt64 surface, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceSurfaceSupportKHR (IntPtr physicalDevice, UInt32 queueFamilyIndex, UInt64 surface, Bool32* pSupported);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR (IntPtr physicalDevice, UInt64 surface, SurfaceCapabilitiesKhr* pSurfaceCapabilities);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceSurfaceFormatsKHR (IntPtr physicalDevice, UInt64 surface, UInt32* pSurfaceFormatCount, SurfaceFormatKhr* pSurfaceFormats);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetPhysicalDeviceSurfacePresentModesKHR (IntPtr physicalDevice, UInt64 surface, UInt32* pPresentModeCount, PresentModeKhr* pPresentModes);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateSwapchainKHR (IntPtr device, SwapchainCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSwapchain);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroySwapchainKHR (IntPtr device, UInt64 swapchain, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkGetSwapchainImagesKHR (IntPtr device, UInt64 swapchain, UInt32* pSwapchainImageCount, UInt64* pSwapchainImages);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkAcquireNextImageKHR (IntPtr device, UInt64 swapchain, UInt64 timeout, UInt64 semaphore, UInt64 fence, UInt32* pImageIndex);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkQueuePresentKHR (IntPtr queue, PresentInfoKhr* pPresentInfo);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkCreateDebugReportCallbackEXT (IntPtr instance, DebugReportCallbackCreateInfoExt* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pCallback);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDestroyDebugReportCallbackEXT (IntPtr instance, UInt64 callback, AllocationCallbacks* pAllocator);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkDebugReportMessageEXT (IntPtr instance, DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, UInt64 @object, UIntPtr location, Int32 messageCode, string pLayerPrefix, string pMessage);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkDebugMarkerSetObjectNameEXT (IntPtr device, DebugMarkerObjectNameInfoExt* pNameInfo);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern Result vkDebugMarkerSetObjectTagEXT (IntPtr device, DebugMarkerObjectTagInfoExt* pTagInfo);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDebugMarkerBeginEXT (IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDebugMarkerEndEXT (IntPtr commandBuffer);

		[DllImport (VulkanLibrary, CallingConvention = CallingConvention.Winapi)]
		internal static unsafe extern void vkCmdDebugMarkerInsertEXT (IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);
	}
}
