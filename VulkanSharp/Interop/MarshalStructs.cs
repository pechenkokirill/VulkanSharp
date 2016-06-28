using System;

namespace VulkanSharp.Interop
{
	internal partial struct PhysicalDeviceProperties
	{
		internal UInt32 ApiVersion;
		internal UInt32 DriverVersion;
		internal UInt32 VendorID;
		internal UInt32 DeviceID;
		internal PhysicalDeviceType DeviceType;
		internal unsafe fixed byte DeviceName[256];
		internal unsafe fixed byte PipelineCacheUUID[16];
		internal PhysicalDeviceLimits Limits;
		internal PhysicalDeviceSparseProperties SparseProperties;
	}

	internal partial struct ExtensionProperties
	{
		internal unsafe fixed byte ExtensionName[256];
		internal UInt32 SpecVersion;
	}

	internal partial struct LayerProperties
	{
		internal unsafe fixed byte LayerName[256];
		internal UInt32 SpecVersion;
		internal UInt32 ImplementationVersion;
		internal unsafe fixed byte Description[256];
	}

	internal partial struct ApplicationInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal IntPtr ApplicationName;
		internal UInt32 ApplicationVersion;
		internal IntPtr EngineName;
		internal UInt32 EngineVersion;
		internal UInt32 ApiVersion;
	}

	public partial struct AllocationCallbacks
	{
		internal IntPtr UserData;
		internal IntPtr PfnAllocation;
		internal IntPtr PfnReallocation;
		internal IntPtr PfnFree;
		internal IntPtr PfnInternalAllocation;
		internal IntPtr PfnInternalFree;
	}

	internal partial struct DeviceQueueCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 QueueFamilyIndex;
		internal UInt32 QueueCount;
		internal IntPtr QueuePriorities;
	}

	internal partial struct DeviceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 QueueCreateInfoCount;
		internal IntPtr QueueCreateInfos;
		internal UInt32 EnabledLayerCount;
		internal IntPtr EnabledLayerNames;
		internal UInt32 EnabledExtensionCount;
		internal IntPtr EnabledExtensionNames;
		internal IntPtr EnabledFeatures;
	}

	internal partial struct InstanceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal IntPtr ApplicationInfo;
		internal UInt32 EnabledLayerCount;
		internal IntPtr EnabledLayerNames;
		internal UInt32 EnabledExtensionCount;
		internal IntPtr EnabledExtensionNames;
	}

	internal partial struct PhysicalDeviceMemoryProperties
	{
		internal UInt32 MemoryTypeCount;
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
		internal UInt32 MemoryHeapCount;
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

	internal partial struct MemoryAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DeviceSize AllocationSize;
		internal UInt32 MemoryTypeIndex;
	}

	internal partial struct MappedMemoryRange
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 Memory;
		internal DeviceSize Offset;
		internal DeviceSize Size;
	}

	internal partial struct DescriptorBufferInfo
	{
		internal UInt64 Buffer;
		internal DeviceSize Offset;
		internal DeviceSize Range;
	}

	internal partial struct DescriptorImageInfo
	{
		internal UInt64 Sampler;
		internal UInt64 ImageView;
		internal ImageLayout ImageLayout;
	}

	internal partial struct WriteDescriptorSet
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 DstSet;
		internal UInt32 DstBinding;
		internal UInt32 DstArrayElement;
		internal UInt32 DescriptorCount;
		internal DescriptorType DescriptorType;
		internal IntPtr ImageInfo;
		internal IntPtr BufferInfo;
		internal IntPtr TexelBufferView;
	}

	internal partial struct CopyDescriptorSet
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 SrcSet;
		internal UInt32 SrcBinding;
		internal UInt32 SrcArrayElement;
		internal UInt64 DstSet;
		internal UInt32 DstBinding;
		internal UInt32 DstArrayElement;
		internal UInt32 DescriptorCount;
	}

	internal partial struct BufferCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal BufferCreateFlags Flags;
		internal DeviceSize Size;
		internal BufferUsageFlags Usage;
		internal SharingMode SharingMode;
		internal UInt32 QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
	}

	internal partial struct BufferViewCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt64 Buffer;
		internal Format Format;
		internal DeviceSize Offset;
		internal DeviceSize Range;
	}

	internal partial struct MemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
	}

	internal partial struct BufferMemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
		internal UInt32 SrcQueueFamilyIndex;
		internal UInt32 DstQueueFamilyIndex;
		internal UInt64 Buffer;
		internal DeviceSize Offset;
		internal DeviceSize Size;
	}

	internal partial struct ImageMemoryBarrier
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal AccessFlags SrcAccessMask;
		internal AccessFlags DstAccessMask;
		internal ImageLayout OldLayout;
		internal ImageLayout NewLayout;
		internal UInt32 SrcQueueFamilyIndex;
		internal UInt32 DstQueueFamilyIndex;
		internal UInt64 Image;
		internal ImageSubresourceRange SubresourceRange;
	}

	internal partial struct ImageCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal ImageCreateFlags Flags;
		internal ImageType ImageType;
		internal Format Format;
		internal Extent3D Extent;
		internal UInt32 MipLevels;
		internal UInt32 ArrayLayers;
		internal SampleCountFlags Samples;
		internal ImageTiling Tiling;
		internal ImageUsageFlags Usage;
		internal SharingMode SharingMode;
		internal UInt32 QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
		internal ImageLayout InitialLayout;
	}

	internal partial struct ImageViewCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt64 Image;
		internal ImageViewType ViewType;
		internal Format Format;
		internal ComponentMapping Components;
		internal ImageSubresourceRange SubresourceRange;
	}

	internal partial struct SparseMemoryBind
	{
		internal DeviceSize ResourceOffset;
		internal DeviceSize Size;
		internal UInt64 Memory;
		internal DeviceSize MemoryOffset;
		internal SparseMemoryBindFlags Flags;
	}

	internal partial struct SparseImageMemoryBind
	{
		internal ImageSubresource Subresource;
		internal Offset3D Offset;
		internal Extent3D Extent;
		internal UInt64 Memory;
		internal DeviceSize MemoryOffset;
		internal SparseMemoryBindFlags Flags;
	}

	internal partial struct SparseBufferMemoryBindInfo
	{
		internal UInt64 Buffer;
		internal UInt32 BindCount;
		internal IntPtr Binds;
	}

	internal partial struct SparseImageOpaqueMemoryBindInfo
	{
		internal UInt64 Image;
		internal UInt32 BindCount;
		internal IntPtr Binds;
	}

	internal partial struct SparseImageMemoryBindInfo
	{
		internal UInt64 Image;
		internal UInt32 BindCount;
		internal IntPtr Binds;
	}

	internal partial struct BindSparseInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal UInt32 BufferBindCount;
		internal IntPtr BufferBinds;
		internal UInt32 ImageOpaqueBindCount;
		internal IntPtr ImageOpaqueBinds;
		internal UInt32 ImageBindCount;
		internal IntPtr ImageBinds;
		internal UInt32 SignalSemaphoreCount;
		internal IntPtr SignalSemaphores;
	}

	internal partial struct ImageBlit
	{
		internal ImageSubresourceLayers SrcSubresource;
		internal Offset3D SrcOffsets0;
		internal Offset3D SrcOffsets1;
		internal ImageSubresourceLayers DstSubresource;
		internal Offset3D DstOffsets0;
		internal Offset3D DstOffsets1;
	}

	internal partial struct ShaderModuleCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UIntPtr CodeSize;
		internal IntPtr Code;
	}

	internal partial struct DescriptorSetLayoutBinding
	{
		internal UInt32 Binding;
		internal DescriptorType DescriptorType;
		internal UInt32 DescriptorCount;
		internal ShaderStageFlags StageFlags;
		internal IntPtr ImmutableSamplers;
	}

	internal partial struct DescriptorSetLayoutCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 BindingCount;
		internal IntPtr Bindings;
	}

	internal partial struct DescriptorPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DescriptorPoolCreateFlags Flags;
		internal UInt32 MaxSets;
		internal UInt32 PoolSizeCount;
		internal IntPtr PoolSizes;
	}

	internal partial struct DescriptorSetAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 DescriptorPool;
		internal UInt32 DescriptorSetCount;
		internal IntPtr SetLayouts;
	}

	internal partial struct SpecializationInfo
	{
		internal UInt32 MapEntryCount;
		internal IntPtr MapEntries;
		internal UIntPtr DataSize;
		internal IntPtr Data;
	}

	internal partial struct PipelineShaderStageCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal ShaderStageFlags Stage;
		internal UInt64 Module;
		internal IntPtr Name;
		internal IntPtr SpecializationInfo;
	}

	internal partial struct ComputePipelineCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal PipelineCreateFlags Flags;
		internal PipelineShaderStageCreateInfo Stage;
		internal UInt64 Layout;
		internal UInt64 BasePipelineHandle;
		internal Int32 BasePipelineIndex;
	}

	internal partial struct PipelineVertexInputStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 VertexBindingDescriptionCount;
		internal IntPtr VertexBindingDescriptions;
		internal UInt32 VertexAttributeDescriptionCount;
		internal IntPtr VertexAttributeDescriptions;
	}

	internal partial struct PipelineInputAssemblyStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal PrimitiveTopology Topology;
		internal Bool32 PrimitiveRestartEnable;
	}

	internal partial struct PipelineTessellationStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 PatchControlPoints;
	}

	internal partial struct PipelineViewportStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 ViewportCount;
		internal IntPtr Viewports;
		internal UInt32 ScissorCount;
		internal IntPtr Scissors;
	}

	internal partial struct PipelineRasterizationStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
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

	internal partial struct PipelineMultisampleStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal SampleCountFlags RasterizationSamples;
		internal Bool32 SampleShadingEnable;
		internal float MinSampleShading;
		internal IntPtr SampleMask;
		internal Bool32 AlphaToCoverageEnable;
		internal Bool32 AlphaToOneEnable;
	}

	internal partial struct PipelineColorBlendStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal Bool32 LogicOpEnable;
		internal LogicOp LogicOp;
		internal UInt32 AttachmentCount;
		internal IntPtr Attachments;
		internal unsafe fixed float BlendConstants[4];
	}

	internal partial struct PipelineDynamicStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 DynamicStateCount;
		internal IntPtr DynamicStates;
	}

	internal partial struct PipelineDepthStencilStateCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
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

	internal partial struct GraphicsPipelineCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal PipelineCreateFlags Flags;
		internal UInt32 StageCount;
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
		internal UInt64 Layout;
		internal UInt64 RenderPass;
		internal UInt32 Subpass;
		internal UInt64 BasePipelineHandle;
		internal Int32 BasePipelineIndex;
	}

	internal partial struct PipelineCacheCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UIntPtr InitialDataSize;
		internal IntPtr InitialData;
	}

	internal partial struct PipelineLayoutCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 SetLayoutCount;
		internal IntPtr SetLayouts;
		internal UInt32 PushConstantRangeCount;
		internal IntPtr PushConstantRanges;
	}

	internal partial struct SamplerCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
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

	internal partial struct CommandPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal CommandPoolCreateFlags Flags;
		internal UInt32 QueueFamilyIndex;
	}

	internal partial struct CommandBufferAllocateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 CommandPool;
		internal CommandBufferLevel Level;
		internal UInt32 CommandBufferCount;
	}

	internal partial struct CommandBufferInheritanceInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 RenderPass;
		internal UInt32 Subpass;
		internal UInt64 Framebuffer;
		internal Bool32 OcclusionQueryEnable;
		internal QueryControlFlags QueryFlags;
		internal QueryPipelineStatisticFlags PipelineStatistics;
	}

	internal partial struct CommandBufferBeginInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal CommandBufferUsageFlags Flags;
		internal IntPtr InheritanceInfo;
	}

	internal partial struct RenderPassBeginInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt64 RenderPass;
		internal UInt64 Framebuffer;
		internal Rect2D RenderArea;
		internal UInt32 ClearValueCount;
		internal IntPtr ClearValues;
	}

	internal partial struct SubpassDescription
	{
		internal UInt32 Flags;
		internal PipelineBindPoint PipelineBindPoint;
		internal UInt32 InputAttachmentCount;
		internal IntPtr InputAttachments;
		internal UInt32 ColorAttachmentCount;
		internal IntPtr ColorAttachments;
		internal IntPtr ResolveAttachments;
		internal IntPtr DepthStencilAttachment;
		internal UInt32 PreserveAttachmentCount;
		internal IntPtr PreserveAttachments;
	}

	internal partial struct RenderPassCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt32 AttachmentCount;
		internal IntPtr Attachments;
		internal UInt32 SubpassCount;
		internal IntPtr Subpasses;
		internal UInt32 DependencyCount;
		internal IntPtr Dependencies;
	}

	internal partial struct EventCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
	}

	internal partial struct FenceCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal FenceCreateFlags Flags;
	}

	internal partial struct PhysicalDeviceLimits
	{
		internal UInt32 MaxImageDimension1D;
		internal UInt32 MaxImageDimension2D;
		internal UInt32 MaxImageDimension3D;
		internal UInt32 MaxImageDimensionCube;
		internal UInt32 MaxImageArrayLayers;
		internal UInt32 MaxTexelBufferElements;
		internal UInt32 MaxUniformBufferRange;
		internal UInt32 MaxStorageBufferRange;
		internal UInt32 MaxPushConstantsSize;
		internal UInt32 MaxMemoryAllocationCount;
		internal UInt32 MaxSamplerAllocationCount;
		internal DeviceSize BufferImageGranularity;
		internal DeviceSize SparseAddressSpaceSize;
		internal UInt32 MaxBoundDescriptorSets;
		internal UInt32 MaxPerStageDescriptorSamplers;
		internal UInt32 MaxPerStageDescriptorUniformBuffers;
		internal UInt32 MaxPerStageDescriptorStorageBuffers;
		internal UInt32 MaxPerStageDescriptorSampledImages;
		internal UInt32 MaxPerStageDescriptorStorageImages;
		internal UInt32 MaxPerStageDescriptorInputAttachments;
		internal UInt32 MaxPerStageResources;
		internal UInt32 MaxDescriptorSetSamplers;
		internal UInt32 MaxDescriptorSetUniformBuffers;
		internal UInt32 MaxDescriptorSetUniformBuffersDynamic;
		internal UInt32 MaxDescriptorSetStorageBuffers;
		internal UInt32 MaxDescriptorSetStorageBuffersDynamic;
		internal UInt32 MaxDescriptorSetSampledImages;
		internal UInt32 MaxDescriptorSetStorageImages;
		internal UInt32 MaxDescriptorSetInputAttachments;
		internal UInt32 MaxVertexInputAttributes;
		internal UInt32 MaxVertexInputBindings;
		internal UInt32 MaxVertexInputAttributeOffset;
		internal UInt32 MaxVertexInputBindingStride;
		internal UInt32 MaxVertexOutputComponents;
		internal UInt32 MaxTessellationGenerationLevel;
		internal UInt32 MaxTessellationPatchSize;
		internal UInt32 MaxTessellationControlPerVertexInputComponents;
		internal UInt32 MaxTessellationControlPerVertexOutputComponents;
		internal UInt32 MaxTessellationControlPerPatchOutputComponents;
		internal UInt32 MaxTessellationControlTotalOutputComponents;
		internal UInt32 MaxTessellationEvaluationInputComponents;
		internal UInt32 MaxTessellationEvaluationOutputComponents;
		internal UInt32 MaxGeometryShaderInvocations;
		internal UInt32 MaxGeometryInputComponents;
		internal UInt32 MaxGeometryOutputComponents;
		internal UInt32 MaxGeometryOutputVertices;
		internal UInt32 MaxGeometryTotalOutputComponents;
		internal UInt32 MaxFragmentInputComponents;
		internal UInt32 MaxFragmentOutputAttachments;
		internal UInt32 MaxFragmentDualSrcAttachments;
		internal UInt32 MaxFragmentCombinedOutputResources;
		internal UInt32 MaxComputeSharedMemorySize;
		internal unsafe fixed UInt32 MaxComputeWorkGroupCount[3];
		internal UInt32 MaxComputeWorkGroupInvocations;
		internal unsafe fixed UInt32 MaxComputeWorkGroupSize[3];
		internal UInt32 SubPixelPrecisionBits;
		internal UInt32 SubTexelPrecisionBits;
		internal UInt32 MipmapPrecisionBits;
		internal UInt32 MaxDrawIndexedIndexValue;
		internal UInt32 MaxDrawIndirectCount;
		internal float MaxSamplerLodBias;
		internal float MaxSamplerAnisotropy;
		internal UInt32 MaxViewports;
		internal unsafe fixed UInt32 MaxViewportDimensions[2];
		internal unsafe fixed float ViewportBoundsRange[2];
		internal UInt32 ViewportSubPixelBits;
		internal UIntPtr MinMemoryMapAlignment;
		internal DeviceSize MinTexelBufferOffsetAlignment;
		internal DeviceSize MinUniformBufferOffsetAlignment;
		internal DeviceSize MinStorageBufferOffsetAlignment;
		internal Int32 MinTexelOffset;
		internal UInt32 MaxTexelOffset;
		internal Int32 MinTexelGatherOffset;
		internal UInt32 MaxTexelGatherOffset;
		internal float MinInterpolationOffset;
		internal float MaxInterpolationOffset;
		internal UInt32 SubPixelInterpolationOffsetBits;
		internal UInt32 MaxFramebufferWidth;
		internal UInt32 MaxFramebufferHeight;
		internal UInt32 MaxFramebufferLayers;
		internal SampleCountFlags FramebufferColorSampleCounts;
		internal SampleCountFlags FramebufferDepthSampleCounts;
		internal SampleCountFlags FramebufferStencilSampleCounts;
		internal SampleCountFlags FramebufferNoAttachmentsSampleCounts;
		internal UInt32 MaxColorAttachments;
		internal SampleCountFlags SampledImageColorSampleCounts;
		internal SampleCountFlags SampledImageIntegerSampleCounts;
		internal SampleCountFlags SampledImageDepthSampleCounts;
		internal SampleCountFlags SampledImageStencilSampleCounts;
		internal SampleCountFlags StorageImageSampleCounts;
		internal UInt32 MaxSampleMaskWords;
		internal Bool32 TimestampComputeAndGraphics;
		internal float TimestampPeriod;
		internal UInt32 MaxClipDistances;
		internal UInt32 MaxCullDistances;
		internal UInt32 MaxCombinedClipAndCullDistances;
		internal UInt32 DiscreteQueuePriorities;
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

	internal partial struct SemaphoreCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
	}

	internal partial struct QueryPoolCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal QueryType QueryType;
		internal UInt32 QueryCount;
		internal QueryPipelineStatisticFlags PipelineStatistics;
	}

	internal partial struct FramebufferCreateInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt64 RenderPass;
		internal UInt32 AttachmentCount;
		internal IntPtr Attachments;
		internal UInt32 Width;
		internal UInt32 Height;
		internal UInt32 Layers;
	}

	internal partial struct SubmitInfo
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal IntPtr WaitDstStageMask;
		internal UInt32 CommandBufferCount;
		internal IntPtr CommandBuffers;
		internal UInt32 SignalSemaphoreCount;
		internal IntPtr SignalSemaphores;
	}

	internal partial struct DisplayPropertiesKhr
	{
		internal UInt64 Display;
		internal IntPtr DisplayName;
		internal Extent2D PhysicalDimensions;
		internal Extent2D PhysicalResolution;
		internal SurfaceTransformFlagsKhr SupportedTransforms;
		internal Bool32 PlaneReorderPossible;
		internal Bool32 PersistentContent;
	}

	internal partial struct DisplayPlanePropertiesKhr
	{
		internal UInt64 CurrentDisplay;
		internal UInt32 CurrentStackIndex;
	}

	internal partial struct DisplayModePropertiesKhr
	{
		internal UInt64 DisplayMode;
		internal DisplayModeParametersKhr Parameters;
	}

	internal partial struct DisplayModeCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal DisplayModeParametersKhr Parameters;
	}

	internal partial struct DisplaySurfaceCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt64 DisplayMode;
		internal UInt32 PlaneIndex;
		internal UInt32 PlaneStackIndex;
		internal SurfaceTransformFlagsKhr Transform;
		internal float GlobalAlpha;
		internal DisplayPlaneAlphaFlagsKhr AlphaMode;
		internal Extent2D ImageExtent;
	}

	internal partial struct DisplayPresentInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal Rect2D SrcRect;
		internal Rect2D DstRect;
		internal Bool32 Persistent;
	}

	internal partial struct SwapchainCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal UInt64 Surface;
		internal UInt32 MinImageCount;
		internal Format ImageFormat;
		internal ColorSpaceKhr ImageColorSpace;
		internal Extent2D ImageExtent;
		internal UInt32 ImageArrayLayers;
		internal ImageUsageFlags ImageUsage;
		internal SharingMode ImageSharingMode;
		internal UInt32 QueueFamilyIndexCount;
		internal IntPtr QueueFamilyIndices;
		internal SurfaceTransformFlagsKhr PreTransform;
		internal CompositeAlphaFlagsKhr CompositeAlpha;
		internal PresentModeKhr PresentMode;
		internal Bool32 Clipped;
		internal UInt64 OldSwapchain;
	}

	internal partial struct PresentInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 WaitSemaphoreCount;
		internal IntPtr WaitSemaphores;
		internal UInt32 SwapchainCount;
		internal IntPtr Swapchains;
		internal IntPtr ImageIndices;
		internal IntPtr Results;
	}

	internal partial struct DebugReportCallbackCreateInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportFlagsExt Flags;
		internal IntPtr PfnCallback;
		internal IntPtr UserData;
	}

	internal partial struct PipelineRasterizationStateRasterizationOrderAmd
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal RasterizationOrderAmd RasterizationOrder;
	}

	internal partial struct DebugMarkerObjectNameInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportObjectTypeExt ObjectType;
		internal UInt64 Object;
		internal IntPtr ObjectName;
	}

	internal partial struct DebugMarkerObjectTagInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal DebugReportObjectTypeExt ObjectType;
		internal UInt64 Object;
		internal UInt64 TagName;
		internal UIntPtr TagSize;
		internal IntPtr Tag;
	}

	internal partial struct DebugMarkerMarkerInfoExt
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal IntPtr MarkerName;
		internal unsafe fixed float Color[4];
	}
}
