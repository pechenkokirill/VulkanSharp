using System;

namespace VulkanSharp.Interop
{
	// ReSharper disable InconsistentNaming
	internal struct PhysicalDeviceProperties
	{
		internal uint ApiVersion;
		internal uint DriverVersion;
		internal uint VendorID;
		internal uint DeviceID;
		internal PhysicalDeviceType DeviceType;
		internal unsafe fixed byte DeviceName[256];
		internal unsafe fixed byte PipelineCacheUUID[16];
		internal PhysicalDeviceLimits Limits;
		internal PhysicalDeviceSparseProperties SparseProperties;
	}

	internal struct ExtensionProperties
	{
		internal unsafe fixed byte ExtensionName[256];
		internal uint SpecVersion;
	}

	internal struct LayerProperties
	{
		internal unsafe fixed byte LayerName[256];
		internal uint SpecVersion;
		internal uint ImplementationVersion;
		internal unsafe fixed byte Description[256];
	}

	internal struct ApplicationInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal IntPtr ApplicationName;
		internal uint ApplicationVersion;
		internal IntPtr EngineName;
		internal uint EngineVersion;
		internal uint ApiVersion;
	}

	public struct AllocationCallbacks
	{
		internal IntPtr UserData;
		internal IntPtr PfnAllocation;
		internal IntPtr PfnReallocation;
		internal IntPtr PfnFree;
		internal IntPtr PfnInternalAllocation;
		internal IntPtr PfnInternalFree;
	}

	internal struct DeviceQueueCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint QueueFamilyIndex;
		internal uint QueueCount;
		internal IntPtr QueuePriorities;
	}

	internal struct DeviceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint QueueCreateInfoCount;
		internal IntPtr QueueCreateInfos;
		internal uint EnabledLayerCount;
		internal IntPtr EnabledLayerNames;
		internal uint EnabledExtensionCount;
		internal IntPtr EnabledExtensionNames;
		internal IntPtr EnabledFeatures;
	}

	internal struct InstanceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal IntPtr ApplicationInfo;
		internal uint EnabledLayerCount;
		internal IntPtr EnabledLayerNames;
		internal uint EnabledExtensionCount;
		internal IntPtr EnabledExtensionNames;
	}

	internal struct PhysicalDeviceMemoryProperties
	{
		internal uint MemoryTypeCount;
		internal MemoryType MemoryTypes0;
		internal MemoryType MemoryTypes1;
		internal MemoryType MemoryTypes2;
		internal MemoryType MemoryTypes3;
		internal MemoryType MemoryTypes4;
		internal MemoryType MemoryTypes5;
		internal MemoryType MemoryTypes6;
		internal MemoryType MemoryTypes7;
		internal MemoryType MemoryTypes8;
		internal MemoryType MemoryTypes9;
		internal MemoryType MemoryTypes10;
		internal MemoryType MemoryTypes11;
		internal MemoryType MemoryTypes12;
		internal MemoryType MemoryTypes13;
		internal MemoryType MemoryTypes14;
		internal MemoryType MemoryTypes15;
		internal MemoryType MemoryTypes16;
		internal MemoryType MemoryTypes17;
		internal MemoryType MemoryTypes18;
		internal MemoryType MemoryTypes19;
		internal MemoryType MemoryTypes20;
		internal MemoryType MemoryTypes21;
		internal MemoryType MemoryTypes22;
		internal MemoryType MemoryTypes23;
		internal MemoryType MemoryTypes24;
		internal MemoryType MemoryTypes25;
		internal MemoryType MemoryTypes26;
		internal MemoryType MemoryTypes27;
		internal MemoryType MemoryTypes28;
		internal MemoryType MemoryTypes29;
		internal MemoryType MemoryTypes30;
		internal MemoryType MemoryTypes31;
		internal uint MemoryHeapCount;
		internal MemoryHeap MemoryHeaps0;
		internal MemoryHeap MemoryHeaps1;
		internal MemoryHeap MemoryHeaps2;
		internal MemoryHeap MemoryHeaps3;
		internal MemoryHeap MemoryHeaps4;
		internal MemoryHeap MemoryHeaps5;
		internal MemoryHeap MemoryHeaps6;
		internal MemoryHeap MemoryHeaps7;
		internal MemoryHeap MemoryHeaps8;
		internal MemoryHeap MemoryHeaps9;
		internal MemoryHeap MemoryHeaps10;
		internal MemoryHeap MemoryHeaps11;
		internal MemoryHeap MemoryHeaps12;
		internal MemoryHeap MemoryHeaps13;
		internal MemoryHeap MemoryHeaps14;
		internal MemoryHeap MemoryHeaps15;
	}

	internal struct MemoryAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DeviceSize AllocationSize;
		internal uint MemoryTypeIndex;
	}

	internal struct MappedMemoryRange
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong Memory;
		internal DeviceSize Offset;
		internal DeviceSize Size;
	}

	internal struct DescriptorBufferInfo
	{
		internal ulong Buffer;
		internal DeviceSize Offset;
		internal DeviceSize Range;
	}

	internal struct DescriptorImageInfo
	{
		internal ulong Sampler;
		internal ulong ImageView;
		internal ImageLayout ImageLayout;
	}

	internal struct WriteDescriptorSet
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong DstSet;
		internal uint DstBinding;
		internal uint DstArrayElement;
		internal uint DescriptorCount;
		internal DescriptorType DescriptorType;
		internal IntPtr ImageInfo;
		internal IntPtr BufferInfo;
		internal IntPtr TexelBufferView;
	}

	internal struct CopyDescriptorSet
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong SrcSet;
		internal uint SrcBinding;
		internal uint SrcArrayElement;
		internal ulong DstSet;
		internal uint DstBinding;
		internal uint DstArrayElement;
		internal uint DescriptorCount;
	}

	internal struct BufferCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal BufferCreateFlags Flags;
		internal DeviceSize Size;
		internal BufferUsageFlags Usage;
		internal SharingMode SharingMode;
		internal uint QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
	}

	internal struct BufferViewCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ulong Buffer;
		internal Format Format;
		internal DeviceSize Offset;
		internal DeviceSize Range;
	}

	internal struct MemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
	}

	internal struct BufferMemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
		internal uint SrcQueueFamilyIndex;
		internal uint DstQueueFamilyIndex;
		internal ulong Buffer;
		internal DeviceSize Offset;
		internal DeviceSize Size;
	}

	internal struct ImageMemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
		internal ImageLayout OldLayout;
		internal ImageLayout NewLayout;
		internal uint SrcQueueFamilyIndex;
		internal uint DstQueueFamilyIndex;
		internal ulong Image;
		internal ImageSubresourceRange SubresourceRange;
	}

	internal struct ImageCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ImageCreateFlags Flags;
		internal ImageType ImageType;
		internal Format Format;
		internal Extent3D Extent;
		internal uint MipLevels;
		internal uint ArrayLayers;
		internal SampleCountFlags Samples;
		internal ImageTiling Tiling;
		internal ImageUsageFlags Usage;
		internal SharingMode SharingMode;
		internal uint QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
		internal ImageLayout InitialLayout;
	}

	internal struct ImageViewCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ulong Image;
		internal ImageViewType ViewType;
		internal Format Format;
		internal ComponentMapping Components;
		internal ImageSubresourceRange SubresourceRange;
	}

	internal struct SparseMemoryBind
	{
		internal DeviceSize ResourceOffset;
		internal DeviceSize Size;
		internal ulong Memory;
		internal DeviceSize MemoryOffset;
		internal SparseMemoryBindFlags Flags;
	}

	internal struct SparseImageMemoryBind
	{
		internal ImageSubresource Subresource;
		internal Offset3D Offset;
		internal Extent3D Extent;
		internal ulong Memory;
		internal DeviceSize MemoryOffset;
		internal SparseMemoryBindFlags Flags;
	}

	internal struct SparseBufferMemoryBindInfo
	{
		internal ulong Buffer;
		internal uint BindCount;
		internal IntPtr Binds;
	}

	internal struct SparseImageOpaqueMemoryBindInfo
	{
		internal ulong Image;
		internal uint BindCount;
		internal IntPtr Binds;
	}

	internal struct SparseImageMemoryBindInfo
	{
		internal ulong Image;
		internal uint BindCount;
		internal IntPtr Binds;
	}

	internal struct BindSparseInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal uint BufferBindCount;
		internal IntPtr BufferBinds;
		internal uint ImageOpaqueBindCount;
		internal IntPtr ImageOpaqueBinds;
		internal uint ImageBindCount;
		internal IntPtr ImageBinds;
		internal uint SignalSemaphoreCount;
		internal IntPtr SignalSemaphores;
	}

	internal struct ImageBlit
	{
		internal ImageSubresourceLayers SrcSubresource;
		internal Offset3D SrcOffsets0;
		internal Offset3D SrcOffsets1;
		internal ImageSubresourceLayers DstSubresource;
		internal Offset3D DstOffsets0;
		internal Offset3D DstOffsets1;
	}

	internal struct ShaderModuleCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal UIntPtr CodeSize;
		internal IntPtr Code;
	}

	internal struct DescriptorSetLayoutBinding
	{
		internal uint Binding;
		internal DescriptorType DescriptorType;
		internal uint DescriptorCount;
		internal ShaderStageFlags StageFlags;
		internal IntPtr ImmutableSamplers;
	}

	internal struct DescriptorSetLayoutCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint BindingCount;
		internal IntPtr Bindings;
	}

	internal struct DescriptorPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DescriptorPoolCreateFlags Flags;
		internal uint MaxSets;
		internal uint PoolSizeCount;
		internal IntPtr PoolSizes;
	}

	internal struct DescriptorSetAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong DescriptorPool;
		internal uint DescriptorSetCount;
		internal IntPtr SetLayouts;
	}

	internal struct SpecializationInfo
	{
		internal uint MapEntryCount;
		internal IntPtr MapEntries;
		internal UIntPtr DataSize;
		internal IntPtr Data;
	}

	internal struct PipelineShaderStageCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ShaderStageFlags Stage;
		internal ulong Module;
		internal IntPtr Name;
		internal IntPtr SpecializationInfo;
	}

	internal struct ComputePipelineCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal PipelineCreateFlags Flags;
		internal PipelineShaderStageCreateInfo Stage;
		internal ulong Layout;
		internal ulong BasePipelineHandle;
		internal int BasePipelineIndex;
	}

	internal struct PipelineVertexInputStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint VertexBindingDescriptionCount;
		internal IntPtr VertexBindingDescriptions;
		internal uint VertexAttributeDescriptionCount;
		internal IntPtr VertexAttributeDescriptions;
	}

	internal struct PipelineInputAssemblyStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal PrimitiveTopology Topology;
		internal Bool32 PrimitiveRestartEnable;
	}

	internal struct PipelineTessellationStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint PatchControlPoints;
	}

	internal struct PipelineViewportStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint ViewportCount;
		internal IntPtr Viewports;
		internal uint ScissorCount;
		internal IntPtr Scissors;
	}

	internal struct PipelineRasterizationStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal Bool32 DepthClampEnable;
		internal Bool32 RasterizerDiscardEnable;
		internal PolygonMode PolygonMode;
		internal CullModeFlags CullMode;
		internal FrontFace FrontFace;
		internal Bool32 DepthBiasEnable;
		internal float DepthBiasConstantFactor;
		internal float DepthBiasClamp;
		internal float DepthBiasSlopeFactor;
		internal float LineWidth;
	}

	internal struct PipelineMultisampleStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal SampleCountFlags RasterizationSamples;
		internal Bool32 SampleShadingEnable;
		internal float MinSampleShading;
		internal IntPtr SampleMask;
		internal Bool32 AlphaToCoverageEnable;
		internal Bool32 AlphaToOneEnable;
	}

	internal struct PipelineColorBlendStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal Bool32 LogicOpEnable;
		internal LogicOp LogicOp;
		internal uint AttachmentCount;
		internal IntPtr Attachments;
		internal unsafe fixed float BlendConstants[4];
	}

	internal struct PipelineDynamicStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint DynamicStateCount;
		internal IntPtr DynamicStates;
	}

	internal struct PipelineDepthStencilStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal Bool32 DepthTestEnable;
		internal Bool32 DepthWriteEnable;
		internal CompareOp DepthCompareOp;
		internal Bool32 DepthBoundsTestEnable;
		internal Bool32 StencilTestEnable;
		internal StencilOpState Front;
		internal StencilOpState Back;
		internal float MinDepthBounds;
		internal float MaxDepthBounds;
	}

	internal struct GraphicsPipelineCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal PipelineCreateFlags Flags;
		internal uint StageCount;
		internal IntPtr Stages;
		internal IntPtr VertexInputState;
		internal IntPtr InputAssemblyState;
		internal IntPtr TessellationState;
		internal IntPtr ViewportState;
		internal IntPtr RasterizationState;
		internal IntPtr MultisampleState;
		internal IntPtr DepthStencilState;
		internal IntPtr ColorBlendState;
		internal IntPtr DynamicState;
		internal ulong Layout;
		internal ulong RenderPass;
		internal uint Subpass;
		internal ulong BasePipelineHandle;
		internal int BasePipelineIndex;
	}

	internal struct PipelineCacheCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal UIntPtr InitialDataSize;
		internal IntPtr InitialData;
	}

	internal struct PipelineLayoutCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint SetLayoutCount;
		internal IntPtr SetLayouts;
		internal uint PushConstantRangeCount;
		internal IntPtr PushConstantRanges;
	}

	internal struct SamplerCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal Filter MagFilter;
		internal Filter MinFilter;
		internal SamplerMipmapMode MipmapMode;
		internal SamplerAddressMode AddressModeU;
		internal SamplerAddressMode AddressModeV;
		internal SamplerAddressMode AddressModeW;
		internal float MipLodBias;
		internal Bool32 AnisotropyEnable;
		internal float MaxAnisotropy;
		internal Bool32 CompareEnable;
		internal CompareOp CompareOp;
		internal float MinLod;
		internal float MaxLod;
		internal BorderColor BorderColor;
		internal Bool32 UnnormalizedCoordinates;
	}

	internal struct CommandPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal CommandPoolCreateFlags Flags;
		internal uint QueueFamilyIndex;
	}

	internal struct CommandBufferAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong CommandPool;
		internal CommandBufferLevel Level;
		internal uint CommandBufferCount;
	}

	internal struct CommandBufferInheritanceInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong RenderPass;
		internal uint Subpass;
		internal ulong Framebuffer;
		internal Bool32 OcclusionQueryEnable;
		internal QueryControlFlags QueryFlags;
		internal QueryPipelineStatisticFlags PipelineStatistics;
	}

	internal struct CommandBufferBeginInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal CommandBufferUsageFlags Flags;
		internal IntPtr InheritanceInfo;
	}

	internal struct RenderPassBeginInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ulong RenderPass;
		internal ulong Framebuffer;
		internal Rect2D RenderArea;
		internal uint ClearValueCount;
		internal IntPtr ClearValues;
	}

	internal struct SubpassDescription
	{
		internal uint Flags;
		internal PipelineBindPoint PipelineBindPoint;
		internal uint InputAttachmentCount;
		internal IntPtr InputAttachments;
		internal uint ColorAttachmentCount;
		internal IntPtr ColorAttachments;
		internal IntPtr ResolveAttachments;
		internal IntPtr DepthStencilAttachment;
		internal uint PreserveAttachmentCount;
		internal IntPtr PreserveAttachments;
	}

	internal struct RenderPassCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal uint AttachmentCount;
		internal IntPtr Attachments;
		internal uint SubpassCount;
		internal IntPtr Subpasses;
		internal uint DependencyCount;
		internal IntPtr Dependencies;
	}

	internal struct EventCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
	}

	internal struct FenceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal FenceCreateFlags Flags;
	}

	internal struct PhysicalDeviceLimits
	{
		internal uint MaxImageDimension1D;
		internal uint MaxImageDimension2D;
		internal uint MaxImageDimension3D;
		internal uint MaxImageDimensionCube;
		internal uint MaxImageArrayLayers;
		internal uint MaxTexelBufferElements;
		internal uint MaxUniformBufferRange;
		internal uint MaxStorageBufferRange;
		internal uint MaxPushConstantsSize;
		internal uint MaxMemoryAllocationCount;
		internal uint MaxSamplerAllocationCount;
		internal DeviceSize BufferImageGranularity;
		internal DeviceSize SparseAddressSpaceSize;
		internal uint MaxBoundDescriptorSets;
		internal uint MaxPerStageDescriptorSamplers;
		internal uint MaxPerStageDescriptorUniformBuffers;
		internal uint MaxPerStageDescriptorStorageBuffers;
		internal uint MaxPerStageDescriptorSampledImages;
		internal uint MaxPerStageDescriptorStorageImages;
		internal uint MaxPerStageDescriptorInputAttachments;
		internal uint MaxPerStageResources;
		internal uint MaxDescriptorSetSamplers;
		internal uint MaxDescriptorSetUniformBuffers;
		internal uint MaxDescriptorSetUniformBuffersDynamic;
		internal uint MaxDescriptorSetStorageBuffers;
		internal uint MaxDescriptorSetStorageBuffersDynamic;
		internal uint MaxDescriptorSetSampledImages;
		internal uint MaxDescriptorSetStorageImages;
		internal uint MaxDescriptorSetInputAttachments;
		internal uint MaxVertexInputAttributes;
		internal uint MaxVertexInputBindings;
		internal uint MaxVertexInputAttributeOffset;
		internal uint MaxVertexInputBindingStride;
		internal uint MaxVertexOutputComponents;
		internal uint MaxTessellationGenerationLevel;
		internal uint MaxTessellationPatchSize;
		internal uint MaxTessellationControlPerVertexInputComponents;
		internal uint MaxTessellationControlPerVertexOutputComponents;
		internal uint MaxTessellationControlPerPatchOutputComponents;
		internal uint MaxTessellationControlTotalOutputComponents;
		internal uint MaxTessellationEvaluationInputComponents;
		internal uint MaxTessellationEvaluationOutputComponents;
		internal uint MaxGeometryShaderInvocations;
		internal uint MaxGeometryInputComponents;
		internal uint MaxGeometryOutputComponents;
		internal uint MaxGeometryOutputVertices;
		internal uint MaxGeometryTotalOutputComponents;
		internal uint MaxFragmentInputComponents;
		internal uint MaxFragmentOutputAttachments;
		internal uint MaxFragmentDualSrcAttachments;
		internal uint MaxFragmentCombinedOutputResources;
		internal uint MaxComputeSharedMemorySize;
		internal unsafe fixed uint MaxComputeWorkGroupCount[3];
		internal uint MaxComputeWorkGroupInvocations;
		internal unsafe fixed uint MaxComputeWorkGroupSize[3];
		internal uint SubPixelPrecisionBits;
		internal uint SubTexelPrecisionBits;
		internal uint MipmapPrecisionBits;
		internal uint MaxDrawIndexedIndexValue;
		internal uint MaxDrawIndirectCount;
		internal float MaxSamplerLodBias;
		internal float MaxSamplerAnisotropy;
		internal uint MaxViewports;
		internal unsafe fixed uint MaxViewportDimensions[2];
		internal unsafe fixed float ViewportBoundsRange[2];
		internal uint ViewportSubPixelBits;
		internal UIntPtr MinMemoryMapAlignment;
		internal DeviceSize MinTexelBufferOffsetAlignment;
		internal DeviceSize MinUniformBufferOffsetAlignment;
		internal DeviceSize MinStorageBufferOffsetAlignment;
		internal int MinTexelOffset;
		internal uint MaxTexelOffset;
		internal int MinTexelGatherOffset;
		internal uint MaxTexelGatherOffset;
		internal float MinInterpolationOffset;
		internal float MaxInterpolationOffset;
		internal uint SubPixelInterpolationOffsetBits;
		internal uint MaxFramebufferWidth;
		internal uint MaxFramebufferHeight;
		internal uint MaxFramebufferLayers;
		internal SampleCountFlags FramebufferColorSampleCounts;
		internal SampleCountFlags FramebufferDepthSampleCounts;
		internal SampleCountFlags FramebufferStencilSampleCounts;
		internal SampleCountFlags FramebufferNoAttachmentsSampleCounts;
		internal uint MaxColorAttachments;
		internal SampleCountFlags SampledImageColorSampleCounts;
		internal SampleCountFlags SampledImageIntegerSampleCounts;
		internal SampleCountFlags SampledImageDepthSampleCounts;
		internal SampleCountFlags SampledImageStencilSampleCounts;
		internal SampleCountFlags StorageImageSampleCounts;
		internal uint MaxSampleMaskWords;
		internal Bool32 TimestampComputeAndGraphics;
		internal float TimestampPeriod;
		internal uint MaxClipDistances;
		internal uint MaxCullDistances;
		internal uint MaxCombinedClipAndCullDistances;
		internal uint DiscreteQueuePriorities;
		internal unsafe fixed float PointSizeRange[2];
		internal unsafe fixed float LineWidthRange[2];
		internal float PointSizeGranularity;
		internal float LineWidthGranularity;
		internal Bool32 StrictLines;
		internal Bool32 StandardSampleLocations;
		internal DeviceSize OptimalBufferCopyOffsetAlignment;
		internal DeviceSize OptimalBufferCopyRowPitchAlignment;
		internal DeviceSize NonCoherentAtomSize;
	}

	internal struct SemaphoreCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
	}

	internal struct QueryPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal QueryType QueryType;
		internal uint QueryCount;
		internal QueryPipelineStatisticFlags PipelineStatistics;
	}

	internal struct FramebufferCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ulong RenderPass;
		internal uint AttachmentCount;
		internal IntPtr Attachments;
		internal uint Width;
		internal uint Height;
		internal uint Layers;
	}

	internal struct SubmitInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal IntPtr WaitDstStageMask;
		internal uint CommandBufferCount;
		internal IntPtr CommandBuffers;
		internal uint SignalSemaphoreCount;
		internal IntPtr SignalSemaphores;
	}

	internal struct DisplayPropertiesKhr
	{
		internal ulong Display;
		internal IntPtr DisplayName;
		internal Extent2D PhysicalDimensions;
		internal Extent2D PhysicalResolution;
		internal SurfaceTransformFlagsKhr SupportedTransforms;
		internal Bool32 PlaneReorderPossible;
		internal Bool32 PersistentContent;
	}

	internal struct DisplayPlanePropertiesKhr
	{
		internal ulong CurrentDisplay;
		internal uint CurrentStackIndex;
	}

	internal struct DisplayModePropertiesKhr
	{
		internal ulong DisplayMode;
		internal DisplayModeParametersKhr Parameters;
	}

	internal struct DisplayModeCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal DisplayModeParametersKhr Parameters;
	}

	internal struct DisplaySurfaceCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ulong DisplayMode;
		internal uint PlaneIndex;
		internal uint PlaneStackIndex;
		internal SurfaceTransformFlagsKhr Transform;
		internal float GlobalAlpha;
		internal DisplayPlaneAlphaFlagsKhr AlphaMode;
		internal Extent2D ImageExtent;
	}

	internal struct DisplayPresentInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal Rect2D SrcRect;
		internal Rect2D DstRect;
		internal Bool32 Persistent;
	}

	internal struct SwapchainCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal ulong Surface;
		internal uint MinImageCount;
		internal Format ImageFormat;
		internal ColorSpaceKhr ImageColorSpace;
		internal Extent2D ImageExtent;
		internal uint ImageArrayLayers;
		internal ImageUsageFlags ImageUsage;
		internal SharingMode ImageSharingMode;
		internal uint QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
		internal SurfaceTransformFlagsKhr PreTransform;
		internal CompositeAlphaFlagsKhr CompositeAlpha;
		internal PresentModeKhr PresentMode;
		internal Bool32 Clipped;
		internal ulong OldSwapchain;
	}

	internal struct PresentInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal uint SwapchainCount;
		internal IntPtr Swapchains;
		internal IntPtr ImageIndices;
		internal IntPtr Results;
	}

	internal struct DebugReportCallbackCreateInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportFlagsExt Flags;
		internal IntPtr PfnCallback;
		internal IntPtr UserData;
	}

	internal struct PipelineRasterizationStateRasterizationOrderAmd
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal RasterizationOrderAmd RasterizationOrder;
	}

	internal struct DebugMarkerObjectNameInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportObjectTypeExt ObjectType;
		internal ulong Object;
		internal IntPtr ObjectName;
	}

	internal struct DebugMarkerObjectTagInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportObjectTypeExt ObjectType;
		internal ulong Object;
		internal ulong TagName;
		internal UIntPtr TagSize;
		internal IntPtr Tag;
	}

	internal struct DebugMarkerMarkerInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal IntPtr MarkerName;
		internal unsafe fixed float Color[4];
	}
}
