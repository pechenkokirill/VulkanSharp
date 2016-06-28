using System;

namespace VulkanSharp.Interop
{
	// ReSharper disable InconsistentNaming
	public struct PhysicalDeviceProperties
	{
		public uint ApiVersion;
		public uint DriverVersion;
		public uint VendorID;
		public uint DeviceID;
		public PhysicalDeviceType DeviceType;
		public unsafe fixed byte DeviceName[256];
		public unsafe fixed byte PipelineCacheUUID[16];
		public PhysicalDeviceLimits Limits;
		public PhysicalDeviceSparseProperties SparseProperties;
	}

	public struct ExtensionProperties
	{
		public unsafe fixed byte ExtensionName[256];
		public uint SpecVersion;
	}

	public struct LayerProperties
	{
		public unsafe fixed byte LayerName[256];
		public uint SpecVersion;
		public uint ImplementationVersion;
		public unsafe fixed byte Description[256];
	}

	public struct ApplicationInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public IntPtr ApplicationName;
		public uint ApplicationVersion;
		public IntPtr EngineName;
		public uint EngineVersion;
		public uint ApiVersion;
	}

	public struct AllocationCallbacks
	{
		public IntPtr UserData;
		public IntPtr PfnAllocation;
		public IntPtr PfnReallocation;
		public IntPtr PfnFree;
		public IntPtr PfnInternalAllocation;
		public IntPtr PfnInternalFree;
	}

	public struct DeviceQueueCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint QueueFamilyIndex;
		public uint QueueCount;
		public IntPtr QueuePriorities;
	}

	public struct DeviceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint QueueCreateInfoCount;
		public IntPtr QueueCreateInfos;
		public uint EnabledLayerCount;
		public IntPtr EnabledLayerNames;
		public uint EnabledExtensionCount;
		public IntPtr EnabledExtensionNames;
		public IntPtr EnabledFeatures;
	}

	public struct InstanceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public IntPtr ApplicationInfo;
		public uint EnabledLayerCount;
		public IntPtr EnabledLayerNames;
		public uint EnabledExtensionCount;
		public IntPtr EnabledExtensionNames;
	}

	public struct PhysicalDeviceMemoryProperties
	{
		public uint MemoryTypeCount;
		public MemoryType MemoryTypes0;
		public MemoryType MemoryTypes1;
		public MemoryType MemoryTypes2;
		public MemoryType MemoryTypes3;
		public MemoryType MemoryTypes4;
		public MemoryType MemoryTypes5;
		public MemoryType MemoryTypes6;
		public MemoryType MemoryTypes7;
		public MemoryType MemoryTypes8;
		public MemoryType MemoryTypes9;
		public MemoryType MemoryTypes10;
		public MemoryType MemoryTypes11;
		public MemoryType MemoryTypes12;
		public MemoryType MemoryTypes13;
		public MemoryType MemoryTypes14;
		public MemoryType MemoryTypes15;
		public MemoryType MemoryTypes16;
		public MemoryType MemoryTypes17;
		public MemoryType MemoryTypes18;
		public MemoryType MemoryTypes19;
		public MemoryType MemoryTypes20;
		public MemoryType MemoryTypes21;
		public MemoryType MemoryTypes22;
		public MemoryType MemoryTypes23;
		public MemoryType MemoryTypes24;
		public MemoryType MemoryTypes25;
		public MemoryType MemoryTypes26;
		public MemoryType MemoryTypes27;
		public MemoryType MemoryTypes28;
		public MemoryType MemoryTypes29;
		public MemoryType MemoryTypes30;
		public MemoryType MemoryTypes31;
		public uint MemoryHeapCount;
		public MemoryHeap MemoryHeaps0;
		public MemoryHeap MemoryHeaps1;
		public MemoryHeap MemoryHeaps2;
		public MemoryHeap MemoryHeaps3;
		public MemoryHeap MemoryHeaps4;
		public MemoryHeap MemoryHeaps5;
		public MemoryHeap MemoryHeaps6;
		public MemoryHeap MemoryHeaps7;
		public MemoryHeap MemoryHeaps8;
		public MemoryHeap MemoryHeaps9;
		public MemoryHeap MemoryHeaps10;
		public MemoryHeap MemoryHeaps11;
		public MemoryHeap MemoryHeaps12;
		public MemoryHeap MemoryHeaps13;
		public MemoryHeap MemoryHeaps14;
		public MemoryHeap MemoryHeaps15;
	}

	public struct MemoryAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public DeviceSize AllocationSize;
		public uint MemoryTypeIndex;
	}

	public struct MappedMemoryRange
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong Memory;
		public DeviceSize Offset;
		public DeviceSize Size;
	}

	public struct DescriptorBufferInfo
	{
		public ulong Buffer;
		public DeviceSize Offset;
		public DeviceSize Range;
	}

	public struct DescriptorImageInfo
	{
		public ulong Sampler;
		public ulong ImageView;
		public ImageLayout ImageLayout;
	}

	public struct WriteDescriptorSet
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong DstSet;
		public uint DstBinding;
		public uint DstArrayElement;
		public uint DescriptorCount;
		public DescriptorType DescriptorType;
		public IntPtr ImageInfo;
		public IntPtr BufferInfo;
		public IntPtr TexelBufferView;
	}

	public struct CopyDescriptorSet
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong SrcSet;
		public uint SrcBinding;
		public uint SrcArrayElement;
		public ulong DstSet;
		public uint DstBinding;
		public uint DstArrayElement;
		public uint DescriptorCount;
	}

	public struct BufferCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public BufferCreateFlags Flags;
		public DeviceSize Size;
		public BufferUsageFlags Usage;
		public SharingMode SharingMode;
		public uint QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
	}

	public struct BufferViewCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ulong Buffer;
		public Format Format;
		public DeviceSize Offset;
		public DeviceSize Range;
	}

	public struct MemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
	}

	public struct BufferMemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public uint SrcQueueFamilyIndex;
		public uint DstQueueFamilyIndex;
		public ulong Buffer;
		public DeviceSize Offset;
		public DeviceSize Size;
	}

	public struct ImageMemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public ImageLayout OldLayout;
		public ImageLayout NewLayout;
		public uint SrcQueueFamilyIndex;
		public uint DstQueueFamilyIndex;
		public ulong Image;
		public ImageSubresourceRange SubresourceRange;
	}

	public struct ImageCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ImageCreateFlags Flags;
		public ImageType ImageType;
		public Format Format;
		public Extent3D Extent;
		public uint MipLevels;
		public uint ArrayLayers;
		public SampleCountFlags Samples;
		public ImageTiling Tiling;
		public ImageUsageFlags Usage;
		public SharingMode SharingMode;
		public uint QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
		public ImageLayout InitialLayout;
	}

	public struct ImageViewCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ulong Image;
		public ImageViewType ViewType;
		public Format Format;
		public ComponentMapping Components;
		public ImageSubresourceRange SubresourceRange;
	}

	public struct SparseMemoryBind
	{
		public DeviceSize ResourceOffset;
		public DeviceSize Size;
		public ulong Memory;
		public DeviceSize MemoryOffset;
		public SparseMemoryBindFlags Flags;
	}

	public struct SparseImageMemoryBind
	{
		public ImageSubresource Subresource;
		public Offset3D Offset;
		public Extent3D Extent;
		public ulong Memory;
		public DeviceSize MemoryOffset;
		public SparseMemoryBindFlags Flags;
	}

	public struct SparseBufferMemoryBindInfo
	{
		public ulong Buffer;
		public uint BindCount;
		public IntPtr Binds;
	}

	public struct SparseImageOpaqueMemoryBindInfo
	{
		public ulong Image;
		public uint BindCount;
		public IntPtr Binds;
	}

	public struct SparseImageMemoryBindInfo
	{
		public ulong Image;
		public uint BindCount;
		public IntPtr Binds;
	}

	public struct BindSparseInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public uint BufferBindCount;
		public IntPtr BufferBinds;
		public uint ImageOpaqueBindCount;
		public IntPtr ImageOpaqueBinds;
		public uint ImageBindCount;
		public IntPtr ImageBinds;
		public uint SignalSemaphoreCount;
		public IntPtr SignalSemaphores;
	}

	public struct ImageBlit
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffsets0;
		public Offset3D SrcOffsets1;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffsets0;
		public Offset3D DstOffsets1;
	}

	public struct ShaderModuleCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public UIntPtr CodeSize;
		public IntPtr Code;
	}

	public struct DescriptorSetLayoutBinding
	{
		public uint Binding;
		public DescriptorType DescriptorType;
		public uint DescriptorCount;
		public ShaderStageFlags StageFlags;
		public IntPtr ImmutableSamplers;
	}

	public struct DescriptorSetLayoutCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint BindingCount;
		public IntPtr Bindings;
	}

	public struct DescriptorPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public DescriptorPoolCreateFlags Flags;
		public uint MaxSets;
		public uint PoolSizeCount;
		public IntPtr PoolSizes;
	}

	public struct DescriptorSetAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong DescriptorPool;
		public uint DescriptorSetCount;
		public IntPtr SetLayouts;
	}

	public struct SpecializationInfo
	{
		public uint MapEntryCount;
		public IntPtr MapEntries;
		public UIntPtr DataSize;
		public IntPtr Data;
	}

	public struct PipelineShaderStageCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ShaderStageFlags Stage;
		public ulong Module;
		public IntPtr Name;
		public IntPtr SpecializationInfo;
	}

	public struct ComputePipelineCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public PipelineCreateFlags Flags;
		public PipelineShaderStageCreateInfo Stage;
		public ulong Layout;
		public ulong BasePipelineHandle;
		public int BasePipelineIndex;
	}

	public struct PipelineVertexInputStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint VertexBindingDescriptionCount;
		public IntPtr VertexBindingDescriptions;
		public uint VertexAttributeDescriptionCount;
		public IntPtr VertexAttributeDescriptions;
	}

	public struct PipelineInputAssemblyStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public PrimitiveTopology Topology;
		public Bool32 PrimitiveRestartEnable;
	}

	public struct PipelineTessellationStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint PatchControlPoints;
	}

	public struct PipelineViewportStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint ViewportCount;
		public IntPtr Viewports;
		public uint ScissorCount;
		public IntPtr Scissors;
	}

	public struct PipelineRasterizationStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public Bool32 DepthClampEnable;
		public Bool32 RasterizerDiscardEnable;
		public PolygonMode PolygonMode;
		public CullModeFlags CullMode;
		public FrontFace FrontFace;
		public Bool32 DepthBiasEnable;
		public float DepthBiasConstantFactor;
		public float DepthBiasClamp;
		public float DepthBiasSlopeFactor;
		public float LineWidth;
	}

	public struct PipelineMultisampleStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public SampleCountFlags RasterizationSamples;
		public Bool32 SampleShadingEnable;
		public float MinSampleShading;
		public IntPtr SampleMask;
		public Bool32 AlphaToCoverageEnable;
		public Bool32 AlphaToOneEnable;
	}

	public struct PipelineColorBlendStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public Bool32 LogicOpEnable;
		public LogicOp LogicOp;
		public uint AttachmentCount;
		public IntPtr Attachments;
		public unsafe fixed float BlendConstants[4];
	}

	public struct PipelineDynamicStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint DynamicStateCount;
		public IntPtr DynamicStates;
	}

	public struct PipelineDepthStencilStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public Bool32 DepthTestEnable;
		public Bool32 DepthWriteEnable;
		public CompareOp DepthCompareOp;
		public Bool32 DepthBoundsTestEnable;
		public Bool32 StencilTestEnable;
		public StencilOpState Front;
		public StencilOpState Back;
		public float MinDepthBounds;
		public float MaxDepthBounds;
	}

	public struct GraphicsPipelineCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public PipelineCreateFlags Flags;
		public uint StageCount;
		public IntPtr Stages;
		public IntPtr VertexInputState;
		public IntPtr InputAssemblyState;
		public IntPtr TessellationState;
		public IntPtr ViewportState;
		public IntPtr RasterizationState;
		public IntPtr MultisampleState;
		public IntPtr DepthStencilState;
		public IntPtr ColorBlendState;
		public IntPtr DynamicState;
		public ulong Layout;
		public ulong RenderPass;
		public uint Subpass;
		public ulong BasePipelineHandle;
		public int BasePipelineIndex;
	}

	public struct PipelineCacheCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public UIntPtr InitialDataSize;
		public IntPtr InitialData;
	}

	public struct PipelineLayoutCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint SetLayoutCount;
		public IntPtr SetLayouts;
		public uint PushConstantRangeCount;
		public IntPtr PushConstantRanges;
	}

	public struct SamplerCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public Filter MagFilter;
		public Filter MinFilter;
		public SamplerMipmapMode MipmapMode;
		public SamplerAddressMode AddressModeU;
		public SamplerAddressMode AddressModeV;
		public SamplerAddressMode AddressModeW;
		public float MipLodBias;
		public Bool32 AnisotropyEnable;
		public float MaxAnisotropy;
		public Bool32 CompareEnable;
		public CompareOp CompareOp;
		public float MinLod;
		public float MaxLod;
		public BorderColor BorderColor;
		public Bool32 UnnormalizedCoordinates;
	}

	public struct CommandPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public CommandPoolCreateFlags Flags;
		public uint QueueFamilyIndex;
	}

	public struct CommandBufferAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong CommandPool;
		public CommandBufferLevel Level;
		public uint CommandBufferCount;
	}

	public struct CommandBufferInheritanceInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong RenderPass;
		public uint Subpass;
		public ulong Framebuffer;
		public Bool32 OcclusionQueryEnable;
		public QueryControlFlags QueryFlags;
		public QueryPipelineStatisticFlags PipelineStatistics;
	}

	public struct CommandBufferBeginInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public CommandBufferUsageFlags Flags;
		public IntPtr InheritanceInfo;
	}

	public struct RenderPassBeginInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ulong RenderPass;
		public ulong Framebuffer;
		public Rect2D RenderArea;
		public uint ClearValueCount;
		public IntPtr ClearValues;
	}

	public struct SubpassDescription
	{
		public uint Flags;
		public PipelineBindPoint PipelineBindPoint;
		public uint InputAttachmentCount;
		public IntPtr InputAttachments;
		public uint ColorAttachmentCount;
		public IntPtr ColorAttachments;
		public IntPtr ResolveAttachments;
		public IntPtr DepthStencilAttachment;
		public uint PreserveAttachmentCount;
		public IntPtr PreserveAttachments;
	}

	public struct RenderPassCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public uint AttachmentCount;
		public IntPtr Attachments;
		public uint SubpassCount;
		public IntPtr Subpasses;
		public uint DependencyCount;
		public IntPtr Dependencies;
	}

	public struct EventCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
	}

	public struct FenceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public FenceCreateFlags Flags;
	}

	public struct PhysicalDeviceLimits
	{
		public uint MaxImageDimension1D;
		public uint MaxImageDimension2D;
		public uint MaxImageDimension3D;
		public uint MaxImageDimensionCube;
		public uint MaxImageArrayLayers;
		public uint MaxTexelBufferElements;
		public uint MaxUniformBufferRange;
		public uint MaxStorageBufferRange;
		public uint MaxPushConstantsSize;
		public uint MaxMemoryAllocationCount;
		public uint MaxSamplerAllocationCount;
		public DeviceSize BufferImageGranularity;
		public DeviceSize SparseAddressSpaceSize;
		public uint MaxBoundDescriptorSets;
		public uint MaxPerStageDescriptorSamplers;
		public uint MaxPerStageDescriptorUniformBuffers;
		public uint MaxPerStageDescriptorStorageBuffers;
		public uint MaxPerStageDescriptorSampledImages;
		public uint MaxPerStageDescriptorStorageImages;
		public uint MaxPerStageDescriptorInputAttachments;
		public uint MaxPerStageResources;
		public uint MaxDescriptorSetSamplers;
		public uint MaxDescriptorSetUniformBuffers;
		public uint MaxDescriptorSetUniformBuffersDynamic;
		public uint MaxDescriptorSetStorageBuffers;
		public uint MaxDescriptorSetStorageBuffersDynamic;
		public uint MaxDescriptorSetSampledImages;
		public uint MaxDescriptorSetStorageImages;
		public uint MaxDescriptorSetInputAttachments;
		public uint MaxVertexInputAttributes;
		public uint MaxVertexInputBindings;
		public uint MaxVertexInputAttributeOffset;
		public uint MaxVertexInputBindingStride;
		public uint MaxVertexOutputComponents;
		public uint MaxTessellationGenerationLevel;
		public uint MaxTessellationPatchSize;
		public uint MaxTessellationControlPerVertexInputComponents;
		public uint MaxTessellationControlPerVertexOutputComponents;
		public uint MaxTessellationControlPerPatchOutputComponents;
		public uint MaxTessellationControlTotalOutputComponents;
		public uint MaxTessellationEvaluationInputComponents;
		public uint MaxTessellationEvaluationOutputComponents;
		public uint MaxGeometryShaderInvocations;
		public uint MaxGeometryInputComponents;
		public uint MaxGeometryOutputComponents;
		public uint MaxGeometryOutputVertices;
		public uint MaxGeometryTotalOutputComponents;
		public uint MaxFragmentInputComponents;
		public uint MaxFragmentOutputAttachments;
		public uint MaxFragmentDualSrcAttachments;
		public uint MaxFragmentCombinedOutputResources;
		public uint MaxComputeSharedMemorySize;
		public unsafe fixed uint MaxComputeWorkGroupCount[3];
		public uint MaxComputeWorkGroupInvocations;
		public unsafe fixed uint MaxComputeWorkGroupSize[3];
		public uint SubPixelPrecisionBits;
		public uint SubTexelPrecisionBits;
		public uint MipmapPrecisionBits;
		public uint MaxDrawIndexedIndexValue;
		public uint MaxDrawIndirectCount;
		public float MaxSamplerLodBias;
		public float MaxSamplerAnisotropy;
		public uint MaxViewports;
		public unsafe fixed uint MaxViewportDimensions[2];
		public unsafe fixed float ViewportBoundsRange[2];
		public uint ViewportSubPixelBits;
		public UIntPtr MinMemoryMapAlignment;
		public DeviceSize MinTexelBufferOffsetAlignment;
		public DeviceSize MinUniformBufferOffsetAlignment;
		public DeviceSize MinStorageBufferOffsetAlignment;
		public int MinTexelOffset;
		public uint MaxTexelOffset;
		public int MinTexelGatherOffset;
		public uint MaxTexelGatherOffset;
		public float MinInterpolationOffset;
		public float MaxInterpolationOffset;
		public uint SubPixelInterpolationOffsetBits;
		public uint MaxFramebufferWidth;
		public uint MaxFramebufferHeight;
		public uint MaxFramebufferLayers;
		public SampleCountFlags FramebufferColorSampleCounts;
		public SampleCountFlags FramebufferDepthSampleCounts;
		public SampleCountFlags FramebufferStencilSampleCounts;
		public SampleCountFlags FramebufferNoAttachmentsSampleCounts;
		public uint MaxColorAttachments;
		public SampleCountFlags SampledImageColorSampleCounts;
		public SampleCountFlags SampledImageIntegerSampleCounts;
		public SampleCountFlags SampledImageDepthSampleCounts;
		public SampleCountFlags SampledImageStencilSampleCounts;
		public SampleCountFlags StorageImageSampleCounts;
		public uint MaxSampleMaskWords;
		public Bool32 TimestampComputeAndGraphics;
		public float TimestampPeriod;
		public uint MaxClipDistances;
		public uint MaxCullDistances;
		public uint MaxCombinedClipAndCullDistances;
		public uint DiscreteQueuePriorities;
		public unsafe fixed float PointSizeRange[2];
		public unsafe fixed float LineWidthRange[2];
		public float PointSizeGranularity;
		public float LineWidthGranularity;
		public Bool32 StrictLines;
		public Bool32 StandardSampleLocations;
		public DeviceSize OptimalBufferCopyOffsetAlignment;
		public DeviceSize OptimalBufferCopyRowPitchAlignment;
		public DeviceSize NonCoherentAtomSize;
	}

	public struct SemaphoreCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
	}

	public struct QueryPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public QueryType QueryType;
		public uint QueryCount;
		public QueryPipelineStatisticFlags PipelineStatistics;
	}

	public struct FramebufferCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ulong RenderPass;
		public uint AttachmentCount;
		public IntPtr Attachments;
		public uint Width;
		public uint Height;
		public uint Layers;
	}

	public struct SubmitInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public uint WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public IntPtr WaitDstStageMask;
		public uint CommandBufferCount;
		public IntPtr CommandBuffers;
		public uint SignalSemaphoreCount;
		public IntPtr SignalSemaphores;
	}

	public struct DisplayPropertiesKhr
	{
		public ulong Display;
		public IntPtr DisplayName;
		public Extent2D PhysicalDimensions;
		public Extent2D PhysicalResolution;
		public SurfaceTransformFlagsKhr SupportedTransforms;
		public Bool32 PlaneReorderPossible;
		public Bool32 PersistentContent;
	}

	public struct DisplayPlanePropertiesKhr
	{
		public ulong CurrentDisplay;
		public uint CurrentStackIndex;
	}

	public struct DisplayModePropertiesKhr
	{
		public ulong DisplayMode;
		public DisplayModeParametersKhr Parameters;
	}

	public struct DisplayModeCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public DisplayModeParametersKhr Parameters;
	}

	public struct DisplaySurfaceCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ulong DisplayMode;
		public uint PlaneIndex;
		public uint PlaneStackIndex;
		public SurfaceTransformFlagsKhr Transform;
		public float GlobalAlpha;
		public DisplayPlaneAlphaFlagsKhr AlphaMode;
		public Extent2D ImageExtent;
	}

	public struct DisplayPresentInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public Rect2D SrcRect;
		public Rect2D DstRect;
		public Bool32 Persistent;
	}

	public struct SwapchainCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public ulong Surface;
		public uint MinImageCount;
		public Format ImageFormat;
		public ColorSpaceKhr ImageColorSpace;
		public Extent2D ImageExtent;
		public uint ImageArrayLayers;
		public ImageUsageFlags ImageUsage;
		public SharingMode ImageSharingMode;
		public uint QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
		public SurfaceTransformFlagsKhr PreTransform;
		public CompositeAlphaFlagsKhr CompositeAlpha;
		public PresentModeKhr PresentMode;
		public Bool32 Clipped;
		public ulong OldSwapchain;
	}

	public struct PresentInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public uint WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public uint SwapchainCount;
		public IntPtr Swapchains;
		public IntPtr ImageIndices;
		public IntPtr Results;
	}

	public struct DebugReportCallbackCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportFlagsExt Flags;
		public IntPtr PfnCallback;
		public IntPtr UserData;
	}

	public struct PipelineRasterizationStateRasterizationOrderAmd
	{
		public StructureType SType;
		public IntPtr Next;
		public RasterizationOrderAmd RasterizationOrder;
	}

	public struct DebugMarkerObjectNameInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportObjectTypeExt ObjectType;
		public ulong Object;
		public IntPtr ObjectName;
	}

	public struct DebugMarkerObjectTagInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportObjectTypeExt ObjectType;
		public ulong Object;
		public ulong TagName;
		public UIntPtr TagSize;
		public IntPtr Tag;
	}

	public struct DebugMarkerMarkerInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public IntPtr MarkerName;
		public unsafe fixed float Color[4];
	}
}
