using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	unsafe public partial struct Offset2D
	{
		public Int32 X;
		public Int32 Y;
	}

	unsafe public partial struct Offset3D
	{
		public Int32 X;
		public Int32 Y;
		public Int32 Z;
	}

	unsafe public partial struct Extent2D
	{
		public UInt32 Width;
		public UInt32 Height;
	}

	unsafe public partial struct Extent3D
	{
		public UInt32 Width;
		public UInt32 Height;
		public UInt32 Depth;
	}

	unsafe public partial struct Viewport
	{
		public float X;
		public float Y;
		public float Width;
		public float Height;
		public float MinDepth;
		public float MaxDepth;
	}

	unsafe public partial struct Rect2D
	{
		public Offset2D Offset;
		public Extent2D Extent;
	}

	unsafe public partial struct Rect3D
	{
		public Offset3D Offset;
		public Extent3D Extent;
	}

	unsafe public partial struct ClearRect
	{
		public Rect2D Rect;
		public UInt32 BaseArrayLayer;
		public UInt32 LayerCount;
	}

	unsafe public partial struct ComponentMapping
	{
		public ComponentSwizzle R;
		public ComponentSwizzle G;
		public ComponentSwizzle B;
		public ComponentSwizzle A;
	}

	unsafe public partial class PhysicalDeviceProperties
	{
		public UInt32 ApiVersion {
			get { return m->ApiVersion; }
			set { m->ApiVersion = value; }
		}

		public UInt32 DriverVersion {
			get { return m->DriverVersion; }
			set { m->DriverVersion = value; }
		}

		public UInt32 VendorID {
			get { return m->VendorID; }
			set { m->VendorID = value; }
		}

		public UInt32 DeviceID {
			get { return m->DeviceID; }
			set { m->DeviceID = value; }
		}

		public PhysicalDeviceType DeviceType {
			get { return m->DeviceType; }
			set { m->DeviceType = value; }
		}

		public string DeviceName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)m->DeviceName); }
			set { Interop.Structure.MarshalFixedSizeString (m->DeviceName, value, 256); }
		}

		public byte[] PipelineCacheUUID {
			get {
				var arr = new byte [16];
				for (int i = 0; i < 16; i++)
					arr [i] = m->PipelineCacheUUID [i];
				return arr;
			}

			set {
				if (value.Length > 16)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->PipelineCacheUUID [i] = value [i];
				for (int i = value.Length; i < 16; i++)
					m->PipelineCacheUUID [i] = 0;
			}
		}

		PhysicalDeviceLimits lLimits;
		public PhysicalDeviceLimits Limits {
			get { return lLimits; }
			set { lLimits = value; m->Limits = *value.m; }
		}

		public PhysicalDeviceSparseProperties SparseProperties {
			get { return m->SparseProperties; }
			set { m->SparseProperties = value; }
		}
		internal Interop.PhysicalDeviceProperties* m;

		public PhysicalDeviceProperties ()
		{
			m = (Interop.PhysicalDeviceProperties*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceProperties));
			Initialize ();
		}

		internal PhysicalDeviceProperties (Interop.PhysicalDeviceProperties* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			lLimits = new PhysicalDeviceLimits (&m->Limits);
		}

	}

	unsafe public partial class ExtensionProperties
	{
		public string ExtensionName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)m->ExtensionName); }
			set { Interop.Structure.MarshalFixedSizeString (m->ExtensionName, value, 256); }
		}

		public UInt32 SpecVersion {
			get { return m->SpecVersion; }
			set { m->SpecVersion = value; }
		}
		internal Interop.ExtensionProperties* m;

		public ExtensionProperties ()
		{
			m = (Interop.ExtensionProperties*) Interop.Structure.Allocate (typeof (Interop.ExtensionProperties));
		}

		internal ExtensionProperties (Interop.ExtensionProperties* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class LayerProperties
	{
		public string LayerName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)m->LayerName); }
			set { Interop.Structure.MarshalFixedSizeString (m->LayerName, value, 256); }
		}

		public UInt32 SpecVersion {
			get { return m->SpecVersion; }
			set { m->SpecVersion = value; }
		}

		public UInt32 ImplementationVersion {
			get { return m->ImplementationVersion; }
			set { m->ImplementationVersion = value; }
		}

		public string Description {
			get { return Marshal.PtrToStringAnsi ((IntPtr)m->Description); }
			set { Interop.Structure.MarshalFixedSizeString (m->Description, value, 256); }
		}
		internal Interop.LayerProperties* m;

		public LayerProperties ()
		{
			m = (Interop.LayerProperties*) Interop.Structure.Allocate (typeof (Interop.LayerProperties));
		}

		internal LayerProperties (Interop.LayerProperties* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class ApplicationInfo
	{
		public string ApplicationName {
			get { return Marshal.PtrToStringAnsi (m->ApplicationName); }
			set { m->ApplicationName = Marshal.StringToHGlobalAnsi (value); }
		}

		public UInt32 ApplicationVersion {
			get { return m->ApplicationVersion; }
			set { m->ApplicationVersion = value; }
		}

		public string EngineName {
			get { return Marshal.PtrToStringAnsi (m->EngineName); }
			set { m->EngineName = Marshal.StringToHGlobalAnsi (value); }
		}

		public UInt32 EngineVersion {
			get { return m->EngineVersion; }
			set { m->EngineVersion = value; }
		}

		public UInt32 ApiVersion {
			get { return m->ApiVersion; }
			set { m->ApiVersion = value; }
		}
		internal Interop.ApplicationInfo* m;

		public ApplicationInfo ()
		{
			m = (Interop.ApplicationInfo*) Interop.Structure.Allocate (typeof (Interop.ApplicationInfo));
			Initialize ();
		}

		internal ApplicationInfo (Interop.ApplicationInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ApplicationInfo;
		}

	}

	unsafe public partial class AllocationCallbacks
	{
		public IntPtr UserData {
			get { return m->UserData; }
			set { m->UserData = value; }
		}

		public IntPtr PfnAllocation {
			get { return m->PfnAllocation; }
			set { m->PfnAllocation = value; }
		}

		public IntPtr PfnReallocation {
			get { return m->PfnReallocation; }
			set { m->PfnReallocation = value; }
		}

		public IntPtr PfnFree {
			get { return m->PfnFree; }
			set { m->PfnFree = value; }
		}

		public IntPtr PfnInternalAllocation {
			get { return m->PfnInternalAllocation; }
			set { m->PfnInternalAllocation = value; }
		}

		public IntPtr PfnInternalFree {
			get { return m->PfnInternalFree; }
			set { m->PfnInternalFree = value; }
		}
		private Interop.AllocationCallbacks* m;

		public AllocationCallbacks ()
		{
			m = (Interop.AllocationCallbacks*) Interop.Structure.Allocate (typeof (Interop.AllocationCallbacks));
		}

		internal AllocationCallbacks (Interop.AllocationCallbacks* ptr)
		{
			m = ptr;
		}

		public Interop.AllocationCallbacks* Handle => m;
	}

	unsafe public partial class DeviceQueueCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 QueueFamilyIndex {
			get { return m->QueueFamilyIndex; }
			set { m->QueueFamilyIndex = value; }
		}

		public UInt32 QueueCount {
			get { return m->QueueCount; }
			set { m->QueueCount = value; }
		}

		public float[] QueuePriorities {
			get {
				if (m->QueueCount == 0)
					return null;
				var values = new float [m->QueueCount];
				unsafe
				{
					float* ptr = (float*)m->QueuePriorities;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->QueueCount = 0;
					m->QueuePriorities = IntPtr.Zero;
					return;
				}
				m->QueueCount = (uint)value.Length;
				m->QueuePriorities = Marshal.AllocHGlobal ((int)(sizeof(float)*value.Length));
				unsafe
				{
					float* ptr = (float*)m->QueuePriorities;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.DeviceQueueCreateInfo* m;

		public DeviceQueueCreateInfo ()
		{
			m = (Interop.DeviceQueueCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DeviceQueueCreateInfo));
			Initialize ();
		}

		internal DeviceQueueCreateInfo (Interop.DeviceQueueCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DeviceQueueCreateInfo;
		}

	}

	unsafe public partial class DeviceCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 QueueCreateInfoCount {
			get { return m->QueueCreateInfoCount; }
			set { m->QueueCreateInfoCount = value; }
		}

		public DeviceQueueCreateInfo[] QueueCreateInfos {
			get {
				if (m->QueueCreateInfoCount == 0)
					return null;
				var values = new DeviceQueueCreateInfo [m->QueueCreateInfoCount];
				unsafe
				{
					Interop.DeviceQueueCreateInfo* ptr = (Interop.DeviceQueueCreateInfo*)m->QueueCreateInfos;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DeviceQueueCreateInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->QueueCreateInfoCount = 0;
					m->QueueCreateInfos = IntPtr.Zero;
					return;
				}
				m->QueueCreateInfoCount = (uint)value.Length;
				m->QueueCreateInfos = Marshal.AllocHGlobal ((int)(sizeof(Interop.DeviceQueueCreateInfo)*value.Length));
				unsafe
				{
					Interop.DeviceQueueCreateInfo* ptr = (Interop.DeviceQueueCreateInfo*)m->QueueCreateInfos;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public UInt32 EnabledLayerCount {
			get { return m->EnabledLayerCount; }
			set { m->EnabledLayerCount = value; }
		}

		public string[] EnabledLayerNames {
			get {
				if (m->EnabledLayerCount == 0)
					return null;
				var strings = new string [m->EnabledLayerCount];
				unsafe
				{
					void** ptr = (void**)m->EnabledLayerNames;
					for (int i = 0; i < m->EnabledLayerCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					m->EnabledLayerCount = 0;
					m->EnabledLayerNames = IntPtr.Zero;
					return;
				}
				m->EnabledLayerCount = (uint)value.Length;
				m->EnabledLayerNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*m->EnabledLayerCount));
				unsafe
				{
					void** ptr = (void**)m->EnabledLayerNames;
					for (int i = 0; i < m->EnabledLayerCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public UInt32 EnabledExtensionCount {
			get { return m->EnabledExtensionCount; }
			set { m->EnabledExtensionCount = value; }
		}

		public string[] EnabledExtensionNames {
			get {
				if (m->EnabledExtensionCount == 0)
					return null;
				var strings = new string [m->EnabledExtensionCount];
				unsafe
				{
					void** ptr = (void**)m->EnabledExtensionNames;
					for (int i = 0; i < m->EnabledExtensionCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					m->EnabledExtensionCount = 0;
					m->EnabledExtensionNames = IntPtr.Zero;
					return;
				}
				m->EnabledExtensionCount = (uint)value.Length;
				m->EnabledExtensionNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*m->EnabledExtensionCount));
				unsafe
				{
					void** ptr = (void**)m->EnabledExtensionNames;
					for (int i = 0; i < m->EnabledExtensionCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public PhysicalDeviceFeatures EnabledFeatures {
			get { return (PhysicalDeviceFeatures)Interop.Structure.MarshalPointerToObject (m->EnabledFeatures, typeof (PhysicalDeviceFeatures)); }
			set { m->EnabledFeatures = Interop.Structure.MarshalObjectToPointer (m->EnabledFeatures, value); }
		}
		internal Interop.DeviceCreateInfo* m;

		public DeviceCreateInfo ()
		{
			m = (Interop.DeviceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DeviceCreateInfo));
			Initialize ();
		}

		internal DeviceCreateInfo (Interop.DeviceCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DeviceCreateInfo;
		}

	}

	unsafe public partial class InstanceCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		ApplicationInfo lApplicationInfo;
		public ApplicationInfo ApplicationInfo {
			get { return lApplicationInfo; }
			set { lApplicationInfo = value; m->ApplicationInfo = (IntPtr)value.m; }
		}

		public UInt32 EnabledLayerCount {
			get { return m->EnabledLayerCount; }
			set { m->EnabledLayerCount = value; }
		}

		public string[] EnabledLayerNames {
			get {
				if (m->EnabledLayerCount == 0)
					return null;
				var strings = new string [m->EnabledLayerCount];
				unsafe
				{
					void** ptr = (void**)m->EnabledLayerNames;
					for (int i = 0; i < m->EnabledLayerCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					m->EnabledLayerCount = 0;
					m->EnabledLayerNames = IntPtr.Zero;
					return;
				}
				m->EnabledLayerCount = (uint)value.Length;
				m->EnabledLayerNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*m->EnabledLayerCount));
				unsafe
				{
					void** ptr = (void**)m->EnabledLayerNames;
					for (int i = 0; i < m->EnabledLayerCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public UInt32 EnabledExtensionCount {
			get { return m->EnabledExtensionCount; }
			set { m->EnabledExtensionCount = value; }
		}

		public string[] EnabledExtensionNames {
			get {
				if (m->EnabledExtensionCount == 0)
					return null;
				var strings = new string [m->EnabledExtensionCount];
				unsafe
				{
					void** ptr = (void**)m->EnabledExtensionNames;
					for (int i = 0; i < m->EnabledExtensionCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					m->EnabledExtensionCount = 0;
					m->EnabledExtensionNames = IntPtr.Zero;
					return;
				}
				m->EnabledExtensionCount = (uint)value.Length;
				m->EnabledExtensionNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*m->EnabledExtensionCount));
				unsafe
				{
					void** ptr = (void**)m->EnabledExtensionNames;
					for (int i = 0; i < m->EnabledExtensionCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}
		internal Interop.InstanceCreateInfo* m;

		public InstanceCreateInfo ()
		{
			m = (Interop.InstanceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.InstanceCreateInfo));
			Initialize ();
		}

		internal InstanceCreateInfo (Interop.InstanceCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.InstanceCreateInfo;
		}

	}

	unsafe public partial struct QueueFamilyProperties
	{
		public QueueFlags QueueFlags;
		public UInt32 QueueCount;
		public UInt32 TimestampValidBits;
		public Extent3D MinImageTransferGranularity;
	}

	unsafe public partial class PhysicalDeviceMemoryProperties
	{
		public UInt32 MemoryTypeCount {
			get { return m->MemoryTypeCount; }
			set { m->MemoryTypeCount = value; }
		}

		public MemoryType[] MemoryTypes {
			get {
				var arr = new MemoryType [m->MemoryTypeCount];
				for (int i = 0; i < m->MemoryTypeCount; i++)
					unsafe
					{
						arr [i] = (&m->MemoryTypes0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > m->MemoryTypeCount)
					throw new Exception ("array too long");
				m->MemoryTypeCount = (uint)value.Length;
				for (int i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->MemoryTypes0) [i] = value [i];
					}
			}
		}

		public UInt32 MemoryHeapCount {
			get { return m->MemoryHeapCount; }
			set { m->MemoryHeapCount = value; }
		}

		public MemoryHeap[] MemoryHeaps {
			get {
				var arr = new MemoryHeap [m->MemoryHeapCount];
				for (int i = 0; i < m->MemoryHeapCount; i++)
					unsafe
					{
						arr [i] = (&m->MemoryHeaps0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > m->MemoryHeapCount)
					throw new Exception ("array too long");
				m->MemoryHeapCount = (uint)value.Length;
				for (int i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->MemoryHeaps0) [i] = value [i];
					}
			}
		}
		internal Interop.PhysicalDeviceMemoryProperties* m;

		public PhysicalDeviceMemoryProperties ()
		{
			m = (Interop.PhysicalDeviceMemoryProperties*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceMemoryProperties));
		}

		internal PhysicalDeviceMemoryProperties (Interop.PhysicalDeviceMemoryProperties* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class MemoryAllocateInfo
	{
		public DeviceSize AllocationSize {
			get { return m->AllocationSize; }
			set { m->AllocationSize = value; }
		}

		public UInt32 MemoryTypeIndex {
			get { return m->MemoryTypeIndex; }
			set { m->MemoryTypeIndex = value; }
		}
		internal Interop.MemoryAllocateInfo* m;

		public MemoryAllocateInfo ()
		{
			m = (Interop.MemoryAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.MemoryAllocateInfo));
			Initialize ();
		}

		internal MemoryAllocateInfo (Interop.MemoryAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.MemoryAllocateInfo;
		}

	}

	unsafe public partial struct MemoryRequirements
	{
		public DeviceSize Size;
		public DeviceSize Alignment;
		public UInt32 MemoryTypeBits;
	}

	unsafe public partial struct SparseImageFormatProperties
	{
		public ImageAspectFlags AspectMask;
		public Extent3D ImageGranularity;
		public SparseImageFormatFlags Flags;
	}

	unsafe public partial struct SparseImageMemoryRequirements
	{
		public SparseImageFormatProperties FormatProperties;
		public UInt32 ImageMipTailFirstLod;
		public DeviceSize ImageMipTailSize;
		public DeviceSize ImageMipTailOffset;
		public DeviceSize ImageMipTailStride;
	}

	unsafe public partial struct MemoryType
	{
		public MemoryPropertyFlags PropertyFlags;
		public UInt32 HeapIndex;
	}

	unsafe public partial struct MemoryHeap
	{
		public DeviceSize Size;
		public MemoryHeapFlags Flags;
	}

	unsafe public partial class MappedMemoryRange
	{
		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; m->Memory = (UInt64)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}
		internal Interop.MappedMemoryRange* m;

		public MappedMemoryRange ()
		{
			m = (Interop.MappedMemoryRange*) Interop.Structure.Allocate (typeof (Interop.MappedMemoryRange));
			Initialize ();
		}

		internal MappedMemoryRange (Interop.MappedMemoryRange* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.MappedMemoryRange;
		}

	}

	unsafe public partial struct FormatProperties
	{
		public FormatFeatureFlags LinearTilingFeatures;
		public FormatFeatureFlags OptimalTilingFeatures;
		public FormatFeatureFlags BufferFeatures;
	}

	unsafe public partial struct ImageFormatProperties
	{
		public Extent3D MaxExtent;
		public UInt32 MaxMipLevels;
		public UInt32 MaxArrayLayers;
		public SampleCountFlags SampleCounts;
		public DeviceSize MaxResourceSize;
	}

	unsafe public partial class DescriptorBufferInfo
	{
		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (UInt64)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Range {
			get { return m->Range; }
			set { m->Range = value; }
		}
		internal Interop.DescriptorBufferInfo* m;

		public DescriptorBufferInfo ()
		{
			m = (Interop.DescriptorBufferInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorBufferInfo));
			Initialize ();
		}

		internal DescriptorBufferInfo (Interop.DescriptorBufferInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class DescriptorImageInfo
	{
		Sampler lSampler;
		public Sampler Sampler {
			get { return lSampler; }
			set { lSampler = value; m->Sampler = (UInt64)value.m; }
		}

		ImageView lImageView;
		public ImageView ImageView {
			get { return lImageView; }
			set { lImageView = value; m->ImageView = (UInt64)value.m; }
		}

		public ImageLayout ImageLayout {
			get { return m->ImageLayout; }
			set { m->ImageLayout = value; }
		}
		internal Interop.DescriptorImageInfo* m;

		public DescriptorImageInfo ()
		{
			m = (Interop.DescriptorImageInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorImageInfo));
			Initialize ();
		}

		internal DescriptorImageInfo (Interop.DescriptorImageInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class WriteDescriptorSet
	{
		DescriptorSet lDstSet;
		public DescriptorSet DstSet {
			get { return lDstSet; }
			set { lDstSet = value; m->DstSet = (UInt64)value.m; }
		}

		public UInt32 DstBinding {
			get { return m->DstBinding; }
			set { m->DstBinding = value; }
		}

		public UInt32 DstArrayElement {
			get { return m->DstArrayElement; }
			set { m->DstArrayElement = value; }
		}

		public UInt32 DescriptorCount {
			get { return m->DescriptorCount; }
			set { m->DescriptorCount = value; }
		}

		public DescriptorType DescriptorType {
			get { return m->DescriptorType; }
			set { m->DescriptorType = value; }
		}

		public DescriptorImageInfo[] ImageInfo {
			get {
				if (m->DescriptorCount == 0)
					return null;
				var values = new DescriptorImageInfo [m->DescriptorCount];
				unsafe
				{
					Interop.DescriptorImageInfo* ptr = (Interop.DescriptorImageInfo*)m->ImageInfo;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DescriptorImageInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->DescriptorCount = 0;
					m->ImageInfo = IntPtr.Zero;
					return;
				}
				m->DescriptorCount = (uint)value.Length;
				m->ImageInfo = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorImageInfo)*value.Length));
				unsafe
				{
					Interop.DescriptorImageInfo* ptr = (Interop.DescriptorImageInfo*)m->ImageInfo;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public DescriptorBufferInfo[] BufferInfo {
			get {
				if (m->DescriptorCount == 0)
					return null;
				var values = new DescriptorBufferInfo [m->DescriptorCount];
				unsafe
				{
					Interop.DescriptorBufferInfo* ptr = (Interop.DescriptorBufferInfo*)m->BufferInfo;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DescriptorBufferInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->DescriptorCount = 0;
					m->BufferInfo = IntPtr.Zero;
					return;
				}
				m->DescriptorCount = (uint)value.Length;
				m->BufferInfo = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorBufferInfo)*value.Length));
				unsafe
				{
					Interop.DescriptorBufferInfo* ptr = (Interop.DescriptorBufferInfo*)m->BufferInfo;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public BufferView[] TexelBufferView {
			get {
				if (m->DescriptorCount == 0)
					return null;
				var values = new BufferView [m->DescriptorCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->TexelBufferView;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new BufferView ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->DescriptorCount = 0;
					m->TexelBufferView = IntPtr.Zero;
					return;
				}
				m->DescriptorCount = (uint)value.Length;
				m->TexelBufferView = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->TexelBufferView;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		internal Interop.WriteDescriptorSet* m;

		public WriteDescriptorSet ()
		{
			m = (Interop.WriteDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.WriteDescriptorSet));
			Initialize ();
		}

		internal WriteDescriptorSet (Interop.WriteDescriptorSet* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.WriteDescriptorSet;
		}

	}

	unsafe public partial class CopyDescriptorSet
	{
		DescriptorSet lSrcSet;
		public DescriptorSet SrcSet {
			get { return lSrcSet; }
			set { lSrcSet = value; m->SrcSet = (UInt64)value.m; }
		}

		public UInt32 SrcBinding {
			get { return m->SrcBinding; }
			set { m->SrcBinding = value; }
		}

		public UInt32 SrcArrayElement {
			get { return m->SrcArrayElement; }
			set { m->SrcArrayElement = value; }
		}

		DescriptorSet lDstSet;
		public DescriptorSet DstSet {
			get { return lDstSet; }
			set { lDstSet = value; m->DstSet = (UInt64)value.m; }
		}

		public UInt32 DstBinding {
			get { return m->DstBinding; }
			set { m->DstBinding = value; }
		}

		public UInt32 DstArrayElement {
			get { return m->DstArrayElement; }
			set { m->DstArrayElement = value; }
		}

		public UInt32 DescriptorCount {
			get { return m->DescriptorCount; }
			set { m->DescriptorCount = value; }
		}
		internal Interop.CopyDescriptorSet* m;

		public CopyDescriptorSet ()
		{
			m = (Interop.CopyDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.CopyDescriptorSet));
			Initialize ();
		}

		internal CopyDescriptorSet (Interop.CopyDescriptorSet* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.CopyDescriptorSet;
		}

	}

	unsafe public partial class BufferCreateInfo
	{
		public BufferCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}

		public BufferUsageFlags Usage {
			get { return m->Usage; }
			set { m->Usage = value; }
		}

		public SharingMode SharingMode {
			get { return m->SharingMode; }
			set { m->SharingMode = value; }
		}

		public UInt32 QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public UInt32[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new UInt32 [m->QueueFamilyIndexCount];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->QueueFamilyIndexCount = 0;
					m->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				m->QueueFamilyIndexCount = (uint)value.Length;
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.BufferCreateInfo* m;

		public BufferCreateInfo ()
		{
			m = (Interop.BufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferCreateInfo));
			Initialize ();
		}

		internal BufferCreateInfo (Interop.BufferCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.BufferCreateInfo;
		}

	}

	unsafe public partial class BufferViewCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (UInt64)value.m; }
		}

		public Format Format {
			get { return m->Format; }
			set { m->Format = value; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Range {
			get { return m->Range; }
			set { m->Range = value; }
		}
		internal Interop.BufferViewCreateInfo* m;

		public BufferViewCreateInfo ()
		{
			m = (Interop.BufferViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferViewCreateInfo));
			Initialize ();
		}

		internal BufferViewCreateInfo (Interop.BufferViewCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.BufferViewCreateInfo;
		}

	}

	unsafe public partial struct ImageSubresource
	{
		public ImageAspectFlags AspectMask;
		public UInt32 MipLevel;
		public UInt32 ArrayLayer;
	}

	unsafe public partial struct ImageSubresourceLayers
	{
		public ImageAspectFlags AspectMask;
		public UInt32 MipLevel;
		public UInt32 BaseArrayLayer;
		public UInt32 LayerCount;
	}

	unsafe public partial struct ImageSubresourceRange
	{
		public ImageAspectFlags AspectMask;
		public UInt32 BaseMipLevel;
		public UInt32 LevelCount;
		public UInt32 BaseArrayLayer;
		public UInt32 LayerCount;
	}

	unsafe public partial class MemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return m->SrcAccessMask; }
			set { m->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return m->DstAccessMask; }
			set { m->DstAccessMask = value; }
		}
		internal Interop.MemoryBarrier* m;

		public MemoryBarrier ()
		{
			m = (Interop.MemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.MemoryBarrier));
			Initialize ();
		}

		internal MemoryBarrier (Interop.MemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.MemoryBarrier;
		}

	}

	unsafe public partial class BufferMemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return m->SrcAccessMask; }
			set { m->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return m->DstAccessMask; }
			set { m->DstAccessMask = value; }
		}

		public UInt32 SrcQueueFamilyIndex {
			get { return m->SrcQueueFamilyIndex; }
			set { m->SrcQueueFamilyIndex = value; }
		}

		public UInt32 DstQueueFamilyIndex {
			get { return m->DstQueueFamilyIndex; }
			set { m->DstQueueFamilyIndex = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (UInt64)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}
		internal Interop.BufferMemoryBarrier* m;

		public BufferMemoryBarrier ()
		{
			m = (Interop.BufferMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.BufferMemoryBarrier));
			Initialize ();
		}

		internal BufferMemoryBarrier (Interop.BufferMemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.BufferMemoryBarrier;
		}

	}

	unsafe public partial class ImageMemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return m->SrcAccessMask; }
			set { m->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return m->DstAccessMask; }
			set { m->DstAccessMask = value; }
		}

		public ImageLayout OldLayout {
			get { return m->OldLayout; }
			set { m->OldLayout = value; }
		}

		public ImageLayout NewLayout {
			get { return m->NewLayout; }
			set { m->NewLayout = value; }
		}

		public UInt32 SrcQueueFamilyIndex {
			get { return m->SrcQueueFamilyIndex; }
			set { m->SrcQueueFamilyIndex = value; }
		}

		public UInt32 DstQueueFamilyIndex {
			get { return m->DstQueueFamilyIndex; }
			set { m->DstQueueFamilyIndex = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (UInt64)value.m; }
		}

		public ImageSubresourceRange SubresourceRange {
			get { return m->SubresourceRange; }
			set { m->SubresourceRange = value; }
		}
		internal Interop.ImageMemoryBarrier* m;

		public ImageMemoryBarrier ()
		{
			m = (Interop.ImageMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.ImageMemoryBarrier));
			Initialize ();
		}

		internal ImageMemoryBarrier (Interop.ImageMemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ImageMemoryBarrier;
		}

	}

	unsafe public partial class ImageCreateInfo
	{
		public ImageCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public ImageType ImageType {
			get { return m->ImageType; }
			set { m->ImageType = value; }
		}

		public Format Format {
			get { return m->Format; }
			set { m->Format = value; }
		}

		public Extent3D Extent {
			get { return m->Extent; }
			set { m->Extent = value; }
		}

		public UInt32 MipLevels {
			get { return m->MipLevels; }
			set { m->MipLevels = value; }
		}

		public UInt32 ArrayLayers {
			get { return m->ArrayLayers; }
			set { m->ArrayLayers = value; }
		}

		public SampleCountFlags Samples {
			get { return m->Samples; }
			set { m->Samples = value; }
		}

		public ImageTiling Tiling {
			get { return m->Tiling; }
			set { m->Tiling = value; }
		}

		public ImageUsageFlags Usage {
			get { return m->Usage; }
			set { m->Usage = value; }
		}

		public SharingMode SharingMode {
			get { return m->SharingMode; }
			set { m->SharingMode = value; }
		}

		public UInt32 QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public UInt32[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new UInt32 [m->QueueFamilyIndexCount];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->QueueFamilyIndexCount = 0;
					m->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				m->QueueFamilyIndexCount = (uint)value.Length;
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public ImageLayout InitialLayout {
			get { return m->InitialLayout; }
			set { m->InitialLayout = value; }
		}
		internal Interop.ImageCreateInfo* m;

		public ImageCreateInfo ()
		{
			m = (Interop.ImageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageCreateInfo));
			Initialize ();
		}

		internal ImageCreateInfo (Interop.ImageCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ImageCreateInfo;
		}

	}

	unsafe public partial struct SubresourceLayout
	{
		public DeviceSize Offset;
		public DeviceSize Size;
		public DeviceSize RowPitch;
		public DeviceSize ArrayPitch;
		public DeviceSize DepthPitch;
	}

	unsafe public partial class ImageViewCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (UInt64)value.m; }
		}

		public ImageViewType ViewType {
			get { return m->ViewType; }
			set { m->ViewType = value; }
		}

		public Format Format {
			get { return m->Format; }
			set { m->Format = value; }
		}

		public ComponentMapping Components {
			get { return m->Components; }
			set { m->Components = value; }
		}

		public ImageSubresourceRange SubresourceRange {
			get { return m->SubresourceRange; }
			set { m->SubresourceRange = value; }
		}
		internal Interop.ImageViewCreateInfo* m;

		public ImageViewCreateInfo ()
		{
			m = (Interop.ImageViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageViewCreateInfo));
			Initialize ();
		}

		internal ImageViewCreateInfo (Interop.ImageViewCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ImageViewCreateInfo;
		}

	}

	unsafe public partial struct BufferCopy
	{
		public DeviceSize SrcOffset;
		public DeviceSize DstOffset;
		public DeviceSize Size;
	}

	unsafe public partial class SparseMemoryBind
	{
		public DeviceSize ResourceOffset {
			get { return m->ResourceOffset; }
			set { m->ResourceOffset = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}

		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; m->Memory = (UInt64)value.m; }
		}

		public DeviceSize MemoryOffset {
			get { return m->MemoryOffset; }
			set { m->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		internal Interop.SparseMemoryBind* m;

		public SparseMemoryBind ()
		{
			m = (Interop.SparseMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseMemoryBind));
			Initialize ();
		}

		internal SparseMemoryBind (Interop.SparseMemoryBind* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class SparseImageMemoryBind
	{
		public ImageSubresource Subresource {
			get { return m->Subresource; }
			set { m->Subresource = value; }
		}

		public Offset3D Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public Extent3D Extent {
			get { return m->Extent; }
			set { m->Extent = value; }
		}

		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; m->Memory = (UInt64)value.m; }
		}

		public DeviceSize MemoryOffset {
			get { return m->MemoryOffset; }
			set { m->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		internal Interop.SparseImageMemoryBind* m;

		public SparseImageMemoryBind ()
		{
			m = (Interop.SparseImageMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBind));
			Initialize ();
		}

		internal SparseImageMemoryBind (Interop.SparseImageMemoryBind* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class SparseBufferMemoryBindInfo
	{
		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (UInt64)value.m; }
		}

		public UInt32 BindCount {
			get { return m->BindCount; }
			set { m->BindCount = value; }
		}

		public SparseMemoryBind[] Binds {
			get {
				if (m->BindCount == 0)
					return null;
				var values = new SparseMemoryBind [m->BindCount];
				unsafe
				{
					Interop.SparseMemoryBind* ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseMemoryBind ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->BindCount = 0;
					m->Binds = IntPtr.Zero;
					return;
				}
				m->BindCount = (uint)value.Length;
				m->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseMemoryBind)*value.Length));
				unsafe
				{
					Interop.SparseMemoryBind* ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		internal Interop.SparseBufferMemoryBindInfo* m;

		public SparseBufferMemoryBindInfo ()
		{
			m = (Interop.SparseBufferMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseBufferMemoryBindInfo));
			Initialize ();
		}

		internal SparseBufferMemoryBindInfo (Interop.SparseBufferMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class SparseImageOpaqueMemoryBindInfo
	{
		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (UInt64)value.m; }
		}

		public UInt32 BindCount {
			get { return m->BindCount; }
			set { m->BindCount = value; }
		}

		public SparseMemoryBind[] Binds {
			get {
				if (m->BindCount == 0)
					return null;
				var values = new SparseMemoryBind [m->BindCount];
				unsafe
				{
					Interop.SparseMemoryBind* ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseMemoryBind ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->BindCount = 0;
					m->Binds = IntPtr.Zero;
					return;
				}
				m->BindCount = (uint)value.Length;
				m->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseMemoryBind)*value.Length));
				unsafe
				{
					Interop.SparseMemoryBind* ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		internal Interop.SparseImageOpaqueMemoryBindInfo* m;

		public SparseImageOpaqueMemoryBindInfo ()
		{
			m = (Interop.SparseImageOpaqueMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageOpaqueMemoryBindInfo));
			Initialize ();
		}

		internal SparseImageOpaqueMemoryBindInfo (Interop.SparseImageOpaqueMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class SparseImageMemoryBindInfo
	{
		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (UInt64)value.m; }
		}

		public UInt32 BindCount {
			get { return m->BindCount; }
			set { m->BindCount = value; }
		}

		public SparseImageMemoryBind[] Binds {
			get {
				if (m->BindCount == 0)
					return null;
				var values = new SparseImageMemoryBind [m->BindCount];
				unsafe
				{
					Interop.SparseImageMemoryBind* ptr = (Interop.SparseImageMemoryBind*)m->Binds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseImageMemoryBind ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->BindCount = 0;
					m->Binds = IntPtr.Zero;
					return;
				}
				m->BindCount = (uint)value.Length;
				m->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageMemoryBind)*value.Length));
				unsafe
				{
					Interop.SparseImageMemoryBind* ptr = (Interop.SparseImageMemoryBind*)m->Binds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		internal Interop.SparseImageMemoryBindInfo* m;

		public SparseImageMemoryBindInfo ()
		{
			m = (Interop.SparseImageMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBindInfo));
			Initialize ();
		}

		internal SparseImageMemoryBindInfo (Interop.SparseImageMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class BindSparseInfo
	{
		public UInt32 WaitSemaphoreCount {
			get { return m->WaitSemaphoreCount; }
			set { m->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (m->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [m->WaitSemaphoreCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->WaitSemaphoreCount = 0;
					m->WaitSemaphores = IntPtr.Zero;
					return;
				}
				m->WaitSemaphoreCount = (uint)value.Length;
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32 BufferBindCount {
			get { return m->BufferBindCount; }
			set { m->BufferBindCount = value; }
		}

		public SparseBufferMemoryBindInfo[] BufferBinds {
			get {
				if (m->BufferBindCount == 0)
					return null;
				var values = new SparseBufferMemoryBindInfo [m->BufferBindCount];
				unsafe
				{
					Interop.SparseBufferMemoryBindInfo* ptr = (Interop.SparseBufferMemoryBindInfo*)m->BufferBinds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseBufferMemoryBindInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->BufferBindCount = 0;
					m->BufferBinds = IntPtr.Zero;
					return;
				}
				m->BufferBindCount = (uint)value.Length;
				m->BufferBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseBufferMemoryBindInfo)*value.Length));
				unsafe
				{
					Interop.SparseBufferMemoryBindInfo* ptr = (Interop.SparseBufferMemoryBindInfo*)m->BufferBinds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public UInt32 ImageOpaqueBindCount {
			get { return m->ImageOpaqueBindCount; }
			set { m->ImageOpaqueBindCount = value; }
		}

		public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds {
			get {
				if (m->ImageOpaqueBindCount == 0)
					return null;
				var values = new SparseImageOpaqueMemoryBindInfo [m->ImageOpaqueBindCount];
				unsafe
				{
					Interop.SparseImageOpaqueMemoryBindInfo* ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)m->ImageOpaqueBinds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseImageOpaqueMemoryBindInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->ImageOpaqueBindCount = 0;
					m->ImageOpaqueBinds = IntPtr.Zero;
					return;
				}
				m->ImageOpaqueBindCount = (uint)value.Length;
				m->ImageOpaqueBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageOpaqueMemoryBindInfo)*value.Length));
				unsafe
				{
					Interop.SparseImageOpaqueMemoryBindInfo* ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)m->ImageOpaqueBinds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public UInt32 ImageBindCount {
			get { return m->ImageBindCount; }
			set { m->ImageBindCount = value; }
		}

		public SparseImageMemoryBindInfo[] ImageBinds {
			get {
				if (m->ImageBindCount == 0)
					return null;
				var values = new SparseImageMemoryBindInfo [m->ImageBindCount];
				unsafe
				{
					Interop.SparseImageMemoryBindInfo* ptr = (Interop.SparseImageMemoryBindInfo*)m->ImageBinds;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SparseImageMemoryBindInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->ImageBindCount = 0;
					m->ImageBinds = IntPtr.Zero;
					return;
				}
				m->ImageBindCount = (uint)value.Length;
				m->ImageBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageMemoryBindInfo)*value.Length));
				unsafe
				{
					Interop.SparseImageMemoryBindInfo* ptr = (Interop.SparseImageMemoryBindInfo*)m->ImageBinds;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public UInt32 SignalSemaphoreCount {
			get { return m->SignalSemaphoreCount; }
			set { m->SignalSemaphoreCount = value; }
		}

		public Semaphore[] SignalSemaphores {
			get {
				if (m->SignalSemaphoreCount == 0)
					return null;
				var values = new Semaphore [m->SignalSemaphoreCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SignalSemaphores;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->SignalSemaphoreCount = 0;
					m->SignalSemaphores = IntPtr.Zero;
					return;
				}
				m->SignalSemaphoreCount = (uint)value.Length;
				m->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SignalSemaphores;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		internal Interop.BindSparseInfo* m;

		public BindSparseInfo ()
		{
			m = (Interop.BindSparseInfo*) Interop.Structure.Allocate (typeof (Interop.BindSparseInfo));
			Initialize ();
		}

		internal BindSparseInfo (Interop.BindSparseInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.BindSparseInfo;
		}

	}

	unsafe public partial struct ImageCopy
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffset;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffset;
		public Extent3D Extent;
	}

	unsafe public partial class ImageBlit
	{
		public ImageSubresourceLayers SrcSubresource {
			get { return m->SrcSubresource; }
			set { m->SrcSubresource = value; }
		}

		public Offset3D[] SrcOffsets {
			get {
				var arr = new Offset3D [2];
				for (int i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&m->SrcOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->SrcOffsets0) [i] = value [i];
					}
			}
		}

		public ImageSubresourceLayers DstSubresource {
			get { return m->DstSubresource; }
			set { m->DstSubresource = value; }
		}

		public Offset3D[] DstOffsets {
			get {
				var arr = new Offset3D [2];
				for (int i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&m->DstOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->DstOffsets0) [i] = value [i];
					}
			}
		}
		internal Interop.ImageBlit* m;

		public ImageBlit ()
		{
			m = (Interop.ImageBlit*) Interop.Structure.Allocate (typeof (Interop.ImageBlit));
		}

		internal ImageBlit (Interop.ImageBlit* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial struct BufferImageCopy
	{
		public DeviceSize BufferOffset;
		public UInt32 BufferRowLength;
		public UInt32 BufferImageHeight;
		public ImageSubresourceLayers ImageSubresource;
		public Offset3D ImageOffset;
		public Extent3D ImageExtent;
	}

	unsafe public partial struct ImageResolve
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffset;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffset;
		public Extent3D Extent;
	}

	unsafe public partial class ShaderModuleCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UIntPtr CodeSize {
			get { return m->CodeSize; }
			set { m->CodeSize = value; }
		}

		public UInt32[] Code {
			get {
				if (m->CodeSize == UIntPtr.Zero)
					return null;
				var values = new UInt32 [((uint)m->CodeSize >> 2)];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->Code;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->CodeSize = UIntPtr.Zero;
					m->Code = IntPtr.Zero;
					return;
				}
				m->CodeSize = (UIntPtr)(value.Length << 2);
				m->Code = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->Code;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.ShaderModuleCreateInfo* m;

		public ShaderModuleCreateInfo ()
		{
			m = (Interop.ShaderModuleCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ShaderModuleCreateInfo));
			Initialize ();
		}

		internal ShaderModuleCreateInfo (Interop.ShaderModuleCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ShaderModuleCreateInfo;
		}

	}

	unsafe public partial class DescriptorSetLayoutBinding
	{
		public UInt32 Binding {
			get { return m->Binding; }
			set { m->Binding = value; }
		}

		public DescriptorType DescriptorType {
			get { return m->DescriptorType; }
			set { m->DescriptorType = value; }
		}

		public UInt32 DescriptorCount {
			get { return m->DescriptorCount; }
			set { m->DescriptorCount = value; }
		}

		public ShaderStageFlags StageFlags {
			get { return m->StageFlags; }
			set { m->StageFlags = value; }
		}

		public Sampler[] ImmutableSamplers {
			get {
				if (m->DescriptorCount == 0)
					return null;
				var values = new Sampler [m->DescriptorCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->ImmutableSamplers;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Sampler ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->DescriptorCount = 0;
					m->ImmutableSamplers = IntPtr.Zero;
					return;
				}
				m->DescriptorCount = (uint)value.Length;
				m->ImmutableSamplers = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->ImmutableSamplers;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		internal Interop.DescriptorSetLayoutBinding* m;

		public DescriptorSetLayoutBinding ()
		{
			m = (Interop.DescriptorSetLayoutBinding*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutBinding));
		}

		internal DescriptorSetLayoutBinding (Interop.DescriptorSetLayoutBinding* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class DescriptorSetLayoutCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 BindingCount {
			get { return m->BindingCount; }
			set { m->BindingCount = value; }
		}

		public DescriptorSetLayoutBinding[] Bindings {
			get {
				if (m->BindingCount == 0)
					return null;
				var values = new DescriptorSetLayoutBinding [m->BindingCount];
				unsafe
				{
					Interop.DescriptorSetLayoutBinding* ptr = (Interop.DescriptorSetLayoutBinding*)m->Bindings;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayoutBinding ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->BindingCount = 0;
					m->Bindings = IntPtr.Zero;
					return;
				}
				m->BindingCount = (uint)value.Length;
				m->Bindings = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorSetLayoutBinding)*value.Length));
				unsafe
				{
					Interop.DescriptorSetLayoutBinding* ptr = (Interop.DescriptorSetLayoutBinding*)m->Bindings;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		internal Interop.DescriptorSetLayoutCreateInfo* m;

		public DescriptorSetLayoutCreateInfo ()
		{
			m = (Interop.DescriptorSetLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutCreateInfo));
			Initialize ();
		}

		internal DescriptorSetLayoutCreateInfo (Interop.DescriptorSetLayoutCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DescriptorSetLayoutCreateInfo;
		}

	}

	unsafe public partial struct DescriptorPoolSize
	{
		public DescriptorType Type;
		public UInt32 DescriptorCount;
	}

	unsafe public partial class DescriptorPoolCreateInfo
	{
		public DescriptorPoolCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 MaxSets {
			get { return m->MaxSets; }
			set { m->MaxSets = value; }
		}

		public UInt32 PoolSizeCount {
			get { return m->PoolSizeCount; }
			set { m->PoolSizeCount = value; }
		}

		public DescriptorPoolSize[] PoolSizes {
			get {
				if (m->PoolSizeCount == 0)
					return null;
				var values = new DescriptorPoolSize [m->PoolSizeCount];
				unsafe
				{
					DescriptorPoolSize* ptr = (DescriptorPoolSize*)m->PoolSizes;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->PoolSizeCount = 0;
					m->PoolSizes = IntPtr.Zero;
					return;
				}
				m->PoolSizeCount = (uint)value.Length;
				m->PoolSizes = Marshal.AllocHGlobal ((int)(sizeof(DescriptorPoolSize)*value.Length));
				unsafe
				{
					DescriptorPoolSize* ptr = (DescriptorPoolSize*)m->PoolSizes;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.DescriptorPoolCreateInfo* m;

		public DescriptorPoolCreateInfo ()
		{
			m = (Interop.DescriptorPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorPoolCreateInfo));
			Initialize ();
		}

		internal DescriptorPoolCreateInfo (Interop.DescriptorPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DescriptorPoolCreateInfo;
		}

	}

	unsafe public partial class DescriptorSetAllocateInfo
	{
		DescriptorPool lDescriptorPool;
		public DescriptorPool DescriptorPool {
			get { return lDescriptorPool; }
			set { lDescriptorPool = value; m->DescriptorPool = (UInt64)value.m; }
		}

		public UInt32 DescriptorSetCount {
			get { return m->DescriptorSetCount; }
			set { m->DescriptorSetCount = value; }
		}

		public DescriptorSetLayout[] SetLayouts {
			get {
				if (m->DescriptorSetCount == 0)
					return null;
				var values = new DescriptorSetLayout [m->DescriptorSetCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SetLayouts;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayout ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->DescriptorSetCount = 0;
					m->SetLayouts = IntPtr.Zero;
					return;
				}
				m->DescriptorSetCount = (uint)value.Length;
				m->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SetLayouts;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		internal Interop.DescriptorSetAllocateInfo* m;

		public DescriptorSetAllocateInfo ()
		{
			m = (Interop.DescriptorSetAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetAllocateInfo));
			Initialize ();
		}

		internal DescriptorSetAllocateInfo (Interop.DescriptorSetAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DescriptorSetAllocateInfo;
		}

	}

	unsafe public partial struct SpecializationMapEntry
	{
		public UInt32 ConstantID;
		public UInt32 Offset;
		public UIntPtr Size;
	}

	unsafe public partial class SpecializationInfo
	{
		public UInt32 MapEntryCount {
			get { return m->MapEntryCount; }
			set { m->MapEntryCount = value; }
		}

		public SpecializationMapEntry[] MapEntries {
			get {
				if (m->MapEntryCount == 0)
					return null;
				var values = new SpecializationMapEntry [m->MapEntryCount];
				unsafe
				{
					SpecializationMapEntry* ptr = (SpecializationMapEntry*)m->MapEntries;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->MapEntryCount = 0;
					m->MapEntries = IntPtr.Zero;
					return;
				}
				m->MapEntryCount = (uint)value.Length;
				m->MapEntries = Marshal.AllocHGlobal ((int)(sizeof(SpecializationMapEntry)*value.Length));
				unsafe
				{
					SpecializationMapEntry* ptr = (SpecializationMapEntry*)m->MapEntries;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UIntPtr DataSize {
			get { return m->DataSize; }
			set { m->DataSize = value; }
		}

		public IntPtr Data {
			get { return m->Data; }
			set { m->Data = value; }
		}
		internal Interop.SpecializationInfo* m;

		public SpecializationInfo ()
		{
			m = (Interop.SpecializationInfo*) Interop.Structure.Allocate (typeof (Interop.SpecializationInfo));
		}

		internal SpecializationInfo (Interop.SpecializationInfo* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class PipelineShaderStageCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public ShaderStageFlags Stage {
			get { return m->Stage; }
			set { m->Stage = value; }
		}

		ShaderModule lModule;
		public ShaderModule Module {
			get { return lModule; }
			set { lModule = value; m->Module = (UInt64)value.m; }
		}

		public string Name {
			get { return Marshal.PtrToStringAnsi (m->Name); }
			set { m->Name = Marshal.StringToHGlobalAnsi (value); }
		}

		SpecializationInfo lSpecializationInfo;
		public SpecializationInfo SpecializationInfo {
			get { return lSpecializationInfo; }
			set { lSpecializationInfo = value; m->SpecializationInfo = (IntPtr)value.m; }
		}
		internal Interop.PipelineShaderStageCreateInfo* m;

		public PipelineShaderStageCreateInfo ()
		{
			m = (Interop.PipelineShaderStageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineShaderStageCreateInfo));
			Initialize ();
		}

		internal PipelineShaderStageCreateInfo (Interop.PipelineShaderStageCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineShaderStageCreateInfo;
		}

	}

	unsafe public partial class ComputePipelineCreateInfo
	{
		public PipelineCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		PipelineShaderStageCreateInfo lStage;
		public PipelineShaderStageCreateInfo Stage {
			get { return lStage; }
			set { lStage = value; m->Stage = *value.m; }
		}

		PipelineLayout lLayout;
		public PipelineLayout Layout {
			get { return lLayout; }
			set { lLayout = value; m->Layout = (UInt64)value.m; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; m->BasePipelineHandle = (UInt64)value.m; }
		}

		public Int32 BasePipelineIndex {
			get { return m->BasePipelineIndex; }
			set { m->BasePipelineIndex = value; }
		}
		internal Interop.ComputePipelineCreateInfo* m;

		public ComputePipelineCreateInfo ()
		{
			m = (Interop.ComputePipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ComputePipelineCreateInfo));
			Initialize ();
		}

		internal ComputePipelineCreateInfo (Interop.ComputePipelineCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.ComputePipelineCreateInfo;
			lStage = new PipelineShaderStageCreateInfo (&m->Stage);
		}

	}

	unsafe public partial struct VertexInputBindingDescription
	{
		public UInt32 Binding;
		public UInt32 Stride;
		public VertexInputRate InputRate;
	}

	unsafe public partial struct VertexInputAttributeDescription
	{
		public UInt32 Location;
		public UInt32 Binding;
		public Format Format;
		public UInt32 Offset;
	}

	unsafe public partial class PipelineVertexInputStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 VertexBindingDescriptionCount {
			get { return m->VertexBindingDescriptionCount; }
			set { m->VertexBindingDescriptionCount = value; }
		}

		public VertexInputBindingDescription[] VertexBindingDescriptions {
			get {
				if (m->VertexBindingDescriptionCount == 0)
					return null;
				var values = new VertexInputBindingDescription [m->VertexBindingDescriptionCount];
				unsafe
				{
					VertexInputBindingDescription* ptr = (VertexInputBindingDescription*)m->VertexBindingDescriptions;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->VertexBindingDescriptionCount = 0;
					m->VertexBindingDescriptions = IntPtr.Zero;
					return;
				}
				m->VertexBindingDescriptionCount = (uint)value.Length;
				m->VertexBindingDescriptions = Marshal.AllocHGlobal ((int)(sizeof(VertexInputBindingDescription)*value.Length));
				unsafe
				{
					VertexInputBindingDescription* ptr = (VertexInputBindingDescription*)m->VertexBindingDescriptions;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UInt32 VertexAttributeDescriptionCount {
			get { return m->VertexAttributeDescriptionCount; }
			set { m->VertexAttributeDescriptionCount = value; }
		}

		public VertexInputAttributeDescription[] VertexAttributeDescriptions {
			get {
				if (m->VertexAttributeDescriptionCount == 0)
					return null;
				var values = new VertexInputAttributeDescription [m->VertexAttributeDescriptionCount];
				unsafe
				{
					VertexInputAttributeDescription* ptr = (VertexInputAttributeDescription*)m->VertexAttributeDescriptions;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->VertexAttributeDescriptionCount = 0;
					m->VertexAttributeDescriptions = IntPtr.Zero;
					return;
				}
				m->VertexAttributeDescriptionCount = (uint)value.Length;
				m->VertexAttributeDescriptions = Marshal.AllocHGlobal ((int)(sizeof(VertexInputAttributeDescription)*value.Length));
				unsafe
				{
					VertexInputAttributeDescription* ptr = (VertexInputAttributeDescription*)m->VertexAttributeDescriptions;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.PipelineVertexInputStateCreateInfo* m;

		public PipelineVertexInputStateCreateInfo ()
		{
			m = (Interop.PipelineVertexInputStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineVertexInputStateCreateInfo));
			Initialize ();
		}

		internal PipelineVertexInputStateCreateInfo (Interop.PipelineVertexInputStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineVertexInputStateCreateInfo;
		}

	}

	unsafe public partial class PipelineInputAssemblyStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public PrimitiveTopology Topology {
			get { return m->Topology; }
			set { m->Topology = value; }
		}

		public bool PrimitiveRestartEnable {
			get { return m->PrimitiveRestartEnable; }
			set { m->PrimitiveRestartEnable = value; }
		}
		internal Interop.PipelineInputAssemblyStateCreateInfo* m;

		public PipelineInputAssemblyStateCreateInfo ()
		{
			m = (Interop.PipelineInputAssemblyStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineInputAssemblyStateCreateInfo));
			Initialize ();
		}

		internal PipelineInputAssemblyStateCreateInfo (Interop.PipelineInputAssemblyStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
		}

	}

	unsafe public partial class PipelineTessellationStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 PatchControlPoints {
			get { return m->PatchControlPoints; }
			set { m->PatchControlPoints = value; }
		}
		internal Interop.PipelineTessellationStateCreateInfo* m;

		public PipelineTessellationStateCreateInfo ()
		{
			m = (Interop.PipelineTessellationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineTessellationStateCreateInfo));
			Initialize ();
		}

		internal PipelineTessellationStateCreateInfo (Interop.PipelineTessellationStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineTessellationStateCreateInfo;
		}

	}

	unsafe public partial class PipelineViewportStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 ViewportCount {
			get { return m->ViewportCount; }
			set { m->ViewportCount = value; }
		}

		public Viewport[] Viewports {
			get {
				if (m->ViewportCount == 0)
					return null;
				var values = new Viewport [m->ViewportCount];
				unsafe
				{
					Viewport* ptr = (Viewport*)m->Viewports;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->ViewportCount = 0;
					m->Viewports = IntPtr.Zero;
					return;
				}
				m->ViewportCount = (uint)value.Length;
				m->Viewports = Marshal.AllocHGlobal ((int)(sizeof(Viewport)*value.Length));
				unsafe
				{
					Viewport* ptr = (Viewport*)m->Viewports;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UInt32 ScissorCount {
			get { return m->ScissorCount; }
			set { m->ScissorCount = value; }
		}

		public Rect2D[] Scissors {
			get {
				if (m->ScissorCount == 0)
					return null;
				var values = new Rect2D [m->ScissorCount];
				unsafe
				{
					Rect2D* ptr = (Rect2D*)m->Scissors;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->ScissorCount = 0;
					m->Scissors = IntPtr.Zero;
					return;
				}
				m->ScissorCount = (uint)value.Length;
				m->Scissors = Marshal.AllocHGlobal ((int)(sizeof(Rect2D)*value.Length));
				unsafe
				{
					Rect2D* ptr = (Rect2D*)m->Scissors;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.PipelineViewportStateCreateInfo* m;

		public PipelineViewportStateCreateInfo ()
		{
			m = (Interop.PipelineViewportStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineViewportStateCreateInfo));
			Initialize ();
		}

		internal PipelineViewportStateCreateInfo (Interop.PipelineViewportStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineViewportStateCreateInfo;
		}

	}

	unsafe public partial class PipelineRasterizationStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public bool DepthClampEnable {
			get { return m->DepthClampEnable; }
			set { m->DepthClampEnable = value; }
		}

		public bool RasterizerDiscardEnable {
			get { return m->RasterizerDiscardEnable; }
			set { m->RasterizerDiscardEnable = value; }
		}

		public PolygonMode PolygonMode {
			get { return m->PolygonMode; }
			set { m->PolygonMode = value; }
		}

		public CullModeFlags CullMode {
			get { return m->CullMode; }
			set { m->CullMode = value; }
		}

		public FrontFace FrontFace {
			get { return m->FrontFace; }
			set { m->FrontFace = value; }
		}

		public bool DepthBiasEnable {
			get { return m->DepthBiasEnable; }
			set { m->DepthBiasEnable = value; }
		}

		public float DepthBiasConstantFactor {
			get { return m->DepthBiasConstantFactor; }
			set { m->DepthBiasConstantFactor = value; }
		}

		public float DepthBiasClamp {
			get { return m->DepthBiasClamp; }
			set { m->DepthBiasClamp = value; }
		}

		public float DepthBiasSlopeFactor {
			get { return m->DepthBiasSlopeFactor; }
			set { m->DepthBiasSlopeFactor = value; }
		}

		public float LineWidth {
			get { return m->LineWidth; }
			set { m->LineWidth = value; }
		}
		internal Interop.PipelineRasterizationStateCreateInfo* m;

		public PipelineRasterizationStateCreateInfo ()
		{
			m = (Interop.PipelineRasterizationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateCreateInfo));
			Initialize ();
		}

		internal PipelineRasterizationStateCreateInfo (Interop.PipelineRasterizationStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineRasterizationStateCreateInfo;
		}

	}

	unsafe public partial class PipelineMultisampleStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public SampleCountFlags RasterizationSamples {
			get { return m->RasterizationSamples; }
			set { m->RasterizationSamples = value; }
		}

		public bool SampleShadingEnable {
			get { return m->SampleShadingEnable; }
			set { m->SampleShadingEnable = value; }
		}

		public float MinSampleShading {
			get { return m->MinSampleShading; }
			set { m->MinSampleShading = value; }
		}

		public UInt32[] SampleMask {
			get {
				if (m->RasterizationSamples == 0)
					return null;
				var values = new UInt32 [((uint)m->RasterizationSamples >> 5)];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->SampleMask;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->RasterizationSamples = 0;
					m->SampleMask = IntPtr.Zero;
					return;
				}
				m->RasterizationSamples = (SampleCountFlags)(value.Length << 5);
				m->SampleMask = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->SampleMask;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public bool AlphaToCoverageEnable {
			get { return m->AlphaToCoverageEnable; }
			set { m->AlphaToCoverageEnable = value; }
		}

		public bool AlphaToOneEnable {
			get { return m->AlphaToOneEnable; }
			set { m->AlphaToOneEnable = value; }
		}
		internal Interop.PipelineMultisampleStateCreateInfo* m;

		public PipelineMultisampleStateCreateInfo ()
		{
			m = (Interop.PipelineMultisampleStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineMultisampleStateCreateInfo));
			Initialize ();
		}

		internal PipelineMultisampleStateCreateInfo (Interop.PipelineMultisampleStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineMultisampleStateCreateInfo;
		}

	}

	unsafe public partial struct PipelineColorBlendAttachmentState
	{
		public Bool32 BlendEnable;
		public BlendFactor SrcColorBlendFactor;
		public BlendFactor DstColorBlendFactor;
		public BlendOp ColorBlendOp;
		public BlendFactor SrcAlphaBlendFactor;
		public BlendFactor DstAlphaBlendFactor;
		public BlendOp AlphaBlendOp;
		public ColorComponentFlags ColorWriteMask;
	}

	unsafe public partial class PipelineColorBlendStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public bool LogicOpEnable {
			get { return m->LogicOpEnable; }
			set { m->LogicOpEnable = value; }
		}

		public LogicOp LogicOp {
			get { return m->LogicOp; }
			set { m->LogicOp = value; }
		}

		public UInt32 AttachmentCount {
			get { return m->AttachmentCount; }
			set { m->AttachmentCount = value; }
		}

		public PipelineColorBlendAttachmentState[] Attachments {
			get {
				if (m->AttachmentCount == 0)
					return null;
				var values = new PipelineColorBlendAttachmentState [m->AttachmentCount];
				unsafe
				{
					PipelineColorBlendAttachmentState* ptr = (PipelineColorBlendAttachmentState*)m->Attachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->AttachmentCount = 0;
					m->Attachments = IntPtr.Zero;
					return;
				}
				m->AttachmentCount = (uint)value.Length;
				m->Attachments = Marshal.AllocHGlobal ((int)(sizeof(PipelineColorBlendAttachmentState)*value.Length));
				unsafe
				{
					PipelineColorBlendAttachmentState* ptr = (PipelineColorBlendAttachmentState*)m->Attachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public float[] BlendConstants {
			get {
				var arr = new float [4];
				for (int i = 0; i < 4; i++)
					arr [i] = m->BlendConstants [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->BlendConstants [i] = value [i];
				for (int i = value.Length; i < 4; i++)
					m->BlendConstants [i] = 0;
			}
		}
		internal Interop.PipelineColorBlendStateCreateInfo* m;

		public PipelineColorBlendStateCreateInfo ()
		{
			m = (Interop.PipelineColorBlendStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineColorBlendStateCreateInfo));
			Initialize ();
		}

		internal PipelineColorBlendStateCreateInfo (Interop.PipelineColorBlendStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineColorBlendStateCreateInfo;
		}

	}

	unsafe public partial class PipelineDynamicStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 DynamicStateCount {
			get { return m->DynamicStateCount; }
			set { m->DynamicStateCount = value; }
		}

		public DynamicState[] DynamicStates {
			get {
				if (m->DynamicStateCount == 0)
					return null;
				var values = new DynamicState [m->DynamicStateCount];
				unsafe
				{
					DynamicState* ptr = (DynamicState*)m->DynamicStates;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->DynamicStateCount = 0;
					m->DynamicStates = IntPtr.Zero;
					return;
				}
				m->DynamicStateCount = (uint)value.Length;
				m->DynamicStates = Marshal.AllocHGlobal ((int)(sizeof(DynamicState)*value.Length));
				unsafe
				{
					DynamicState* ptr = (DynamicState*)m->DynamicStates;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.PipelineDynamicStateCreateInfo* m;

		public PipelineDynamicStateCreateInfo ()
		{
			m = (Interop.PipelineDynamicStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDynamicStateCreateInfo));
			Initialize ();
		}

		internal PipelineDynamicStateCreateInfo (Interop.PipelineDynamicStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineDynamicStateCreateInfo;
		}

	}

	unsafe public partial struct StencilOpState
	{
		public StencilOp FailOp;
		public StencilOp PassOp;
		public StencilOp DepthFailOp;
		public CompareOp CompareOp;
		public UInt32 CompareMask;
		public UInt32 WriteMask;
		public UInt32 Reference;
	}

	unsafe public partial class PipelineDepthStencilStateCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public bool DepthTestEnable {
			get { return m->DepthTestEnable; }
			set { m->DepthTestEnable = value; }
		}

		public bool DepthWriteEnable {
			get { return m->DepthWriteEnable; }
			set { m->DepthWriteEnable = value; }
		}

		public CompareOp DepthCompareOp {
			get { return m->DepthCompareOp; }
			set { m->DepthCompareOp = value; }
		}

		public bool DepthBoundsTestEnable {
			get { return m->DepthBoundsTestEnable; }
			set { m->DepthBoundsTestEnable = value; }
		}

		public bool StencilTestEnable {
			get { return m->StencilTestEnable; }
			set { m->StencilTestEnable = value; }
		}

		public StencilOpState Front {
			get { return m->Front; }
			set { m->Front = value; }
		}

		public StencilOpState Back {
			get { return m->Back; }
			set { m->Back = value; }
		}

		public float MinDepthBounds {
			get { return m->MinDepthBounds; }
			set { m->MinDepthBounds = value; }
		}

		public float MaxDepthBounds {
			get { return m->MaxDepthBounds; }
			set { m->MaxDepthBounds = value; }
		}
		internal Interop.PipelineDepthStencilStateCreateInfo* m;

		public PipelineDepthStencilStateCreateInfo ()
		{
			m = (Interop.PipelineDepthStencilStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDepthStencilStateCreateInfo));
			Initialize ();
		}

		internal PipelineDepthStencilStateCreateInfo (Interop.PipelineDepthStencilStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineDepthStencilStateCreateInfo;
		}

	}

	unsafe public partial class GraphicsPipelineCreateInfo
	{
		public PipelineCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 StageCount {
			get { return m->StageCount; }
			set { m->StageCount = value; }
		}

		public PipelineShaderStageCreateInfo[] Stages {
			get {
				if (m->StageCount == 0)
					return null;
				var values = new PipelineShaderStageCreateInfo [m->StageCount];
				unsafe
				{
					Interop.PipelineShaderStageCreateInfo* ptr = (Interop.PipelineShaderStageCreateInfo*)m->Stages;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new PipelineShaderStageCreateInfo ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->StageCount = 0;
					m->Stages = IntPtr.Zero;
					return;
				}
				m->StageCount = (uint)value.Length;
				m->Stages = Marshal.AllocHGlobal ((int)(sizeof(Interop.PipelineShaderStageCreateInfo)*value.Length));
				unsafe
				{
					Interop.PipelineShaderStageCreateInfo* ptr = (Interop.PipelineShaderStageCreateInfo*)m->Stages;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		PipelineVertexInputStateCreateInfo lVertexInputState;
		public PipelineVertexInputStateCreateInfo VertexInputState {
			get { return lVertexInputState; }
			set { lVertexInputState = value; m->VertexInputState = (IntPtr)value.m; }
		}

		PipelineInputAssemblyStateCreateInfo lInputAssemblyState;
		public PipelineInputAssemblyStateCreateInfo InputAssemblyState {
			get { return lInputAssemblyState; }
			set { lInputAssemblyState = value; m->InputAssemblyState = (IntPtr)value.m; }
		}

		PipelineTessellationStateCreateInfo lTessellationState;
		public PipelineTessellationStateCreateInfo TessellationState {
			get { return lTessellationState; }
			set { lTessellationState = value; m->TessellationState = (IntPtr)value.m; }
		}

		PipelineViewportStateCreateInfo lViewportState;
		public PipelineViewportStateCreateInfo ViewportState {
			get { return lViewportState; }
			set { lViewportState = value; m->ViewportState = (IntPtr)value.m; }
		}

		PipelineRasterizationStateCreateInfo lRasterizationState;
		public PipelineRasterizationStateCreateInfo RasterizationState {
			get { return lRasterizationState; }
			set { lRasterizationState = value; m->RasterizationState = (IntPtr)value.m; }
		}

		PipelineMultisampleStateCreateInfo lMultisampleState;
		public PipelineMultisampleStateCreateInfo MultisampleState {
			get { return lMultisampleState; }
			set { lMultisampleState = value; m->MultisampleState = (IntPtr)value.m; }
		}

		PipelineDepthStencilStateCreateInfo lDepthStencilState;
		public PipelineDepthStencilStateCreateInfo DepthStencilState {
			get { return lDepthStencilState; }
			set { lDepthStencilState = value; m->DepthStencilState = (IntPtr)value.m; }
		}

		PipelineColorBlendStateCreateInfo lColorBlendState;
		public PipelineColorBlendStateCreateInfo ColorBlendState {
			get { return lColorBlendState; }
			set { lColorBlendState = value; m->ColorBlendState = (IntPtr)value.m; }
		}

		PipelineDynamicStateCreateInfo lDynamicState;
		public PipelineDynamicStateCreateInfo DynamicState {
			get { return lDynamicState; }
			set { lDynamicState = value; m->DynamicState = (IntPtr)value.m; }
		}

		PipelineLayout lLayout;
		public PipelineLayout Layout {
			get { return lLayout; }
			set { lLayout = value; m->Layout = (UInt64)value.m; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (UInt64)value.m; }
		}

		public UInt32 Subpass {
			get { return m->Subpass; }
			set { m->Subpass = value; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; m->BasePipelineHandle = (UInt64)value.m; }
		}

		public Int32 BasePipelineIndex {
			get { return m->BasePipelineIndex; }
			set { m->BasePipelineIndex = value; }
		}
		internal Interop.GraphicsPipelineCreateInfo* m;

		public GraphicsPipelineCreateInfo ()
		{
			m = (Interop.GraphicsPipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.GraphicsPipelineCreateInfo));
			Initialize ();
		}

		internal GraphicsPipelineCreateInfo (Interop.GraphicsPipelineCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.GraphicsPipelineCreateInfo;
		}

	}

	unsafe public partial class PipelineCacheCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UIntPtr InitialDataSize {
			get { return m->InitialDataSize; }
			set { m->InitialDataSize = value; }
		}

		public IntPtr InitialData {
			get { return m->InitialData; }
			set { m->InitialData = value; }
		}
		internal Interop.PipelineCacheCreateInfo* m;

		public PipelineCacheCreateInfo ()
		{
			m = (Interop.PipelineCacheCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineCacheCreateInfo));
			Initialize ();
		}

		internal PipelineCacheCreateInfo (Interop.PipelineCacheCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineCacheCreateInfo;
		}

	}

	unsafe public partial struct PushConstantRange
	{
		public ShaderStageFlags StageFlags;
		public UInt32 Offset;
		public UInt32 Size;
	}

	unsafe public partial class PipelineLayoutCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 SetLayoutCount {
			get { return m->SetLayoutCount; }
			set { m->SetLayoutCount = value; }
		}

		public DescriptorSetLayout[] SetLayouts {
			get {
				if (m->SetLayoutCount == 0)
					return null;
				var values = new DescriptorSetLayout [m->SetLayoutCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SetLayouts;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayout ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->SetLayoutCount = 0;
					m->SetLayouts = IntPtr.Zero;
					return;
				}
				m->SetLayoutCount = (uint)value.Length;
				m->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SetLayouts;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32 PushConstantRangeCount {
			get { return m->PushConstantRangeCount; }
			set { m->PushConstantRangeCount = value; }
		}

		public PushConstantRange[] PushConstantRanges {
			get {
				if (m->PushConstantRangeCount == 0)
					return null;
				var values = new PushConstantRange [m->PushConstantRangeCount];
				unsafe
				{
					PushConstantRange* ptr = (PushConstantRange*)m->PushConstantRanges;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->PushConstantRangeCount = 0;
					m->PushConstantRanges = IntPtr.Zero;
					return;
				}
				m->PushConstantRangeCount = (uint)value.Length;
				m->PushConstantRanges = Marshal.AllocHGlobal ((int)(sizeof(PushConstantRange)*value.Length));
				unsafe
				{
					PushConstantRange* ptr = (PushConstantRange*)m->PushConstantRanges;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.PipelineLayoutCreateInfo* m;

		public PipelineLayoutCreateInfo ()
		{
			m = (Interop.PipelineLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineLayoutCreateInfo));
			Initialize ();
		}

		internal PipelineLayoutCreateInfo (Interop.PipelineLayoutCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineLayoutCreateInfo;
		}

	}

	unsafe public partial class SamplerCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public Filter MagFilter {
			get { return m->MagFilter; }
			set { m->MagFilter = value; }
		}

		public Filter MinFilter {
			get { return m->MinFilter; }
			set { m->MinFilter = value; }
		}

		public SamplerMipmapMode MipmapMode {
			get { return m->MipmapMode; }
			set { m->MipmapMode = value; }
		}

		public SamplerAddressMode AddressModeU {
			get { return m->AddressModeU; }
			set { m->AddressModeU = value; }
		}

		public SamplerAddressMode AddressModeV {
			get { return m->AddressModeV; }
			set { m->AddressModeV = value; }
		}

		public SamplerAddressMode AddressModeW {
			get { return m->AddressModeW; }
			set { m->AddressModeW = value; }
		}

		public float MipLodBias {
			get { return m->MipLodBias; }
			set { m->MipLodBias = value; }
		}

		public bool AnisotropyEnable {
			get { return m->AnisotropyEnable; }
			set { m->AnisotropyEnable = value; }
		}

		public float MaxAnisotropy {
			get { return m->MaxAnisotropy; }
			set { m->MaxAnisotropy = value; }
		}

		public bool CompareEnable {
			get { return m->CompareEnable; }
			set { m->CompareEnable = value; }
		}

		public CompareOp CompareOp {
			get { return m->CompareOp; }
			set { m->CompareOp = value; }
		}

		public float MinLod {
			get { return m->MinLod; }
			set { m->MinLod = value; }
		}

		public float MaxLod {
			get { return m->MaxLod; }
			set { m->MaxLod = value; }
		}

		public BorderColor BorderColor {
			get { return m->BorderColor; }
			set { m->BorderColor = value; }
		}

		public bool UnnormalizedCoordinates {
			get { return m->UnnormalizedCoordinates; }
			set { m->UnnormalizedCoordinates = value; }
		}
		internal Interop.SamplerCreateInfo* m;

		public SamplerCreateInfo ()
		{
			m = (Interop.SamplerCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SamplerCreateInfo));
			Initialize ();
		}

		internal SamplerCreateInfo (Interop.SamplerCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.SamplerCreateInfo;
		}

	}

	unsafe public partial class CommandPoolCreateInfo
	{
		public CommandPoolCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 QueueFamilyIndex {
			get { return m->QueueFamilyIndex; }
			set { m->QueueFamilyIndex = value; }
		}
		internal Interop.CommandPoolCreateInfo* m;

		public CommandPoolCreateInfo ()
		{
			m = (Interop.CommandPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandPoolCreateInfo));
			Initialize ();
		}

		internal CommandPoolCreateInfo (Interop.CommandPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.CommandPoolCreateInfo;
		}

	}

	unsafe public partial class CommandBufferAllocateInfo
	{
		CommandPool lCommandPool;
		public CommandPool CommandPool {
			get { return lCommandPool; }
			set { lCommandPool = value; m->CommandPool = (UInt64)value.m; }
		}

		public CommandBufferLevel Level {
			get { return m->Level; }
			set { m->Level = value; }
		}

		public UInt32 CommandBufferCount {
			get { return m->CommandBufferCount; }
			set { m->CommandBufferCount = value; }
		}
		internal Interop.CommandBufferAllocateInfo* m;

		public CommandBufferAllocateInfo ()
		{
			m = (Interop.CommandBufferAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferAllocateInfo));
			Initialize ();
		}

		internal CommandBufferAllocateInfo (Interop.CommandBufferAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.CommandBufferAllocateInfo;
		}

	}

	unsafe public partial class CommandBufferInheritanceInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (UInt64)value.m; }
		}

		public UInt32 Subpass {
			get { return m->Subpass; }
			set { m->Subpass = value; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; m->Framebuffer = (UInt64)value.m; }
		}

		public bool OcclusionQueryEnable {
			get { return m->OcclusionQueryEnable; }
			set { m->OcclusionQueryEnable = value; }
		}

		public QueryControlFlags QueryFlags {
			get { return m->QueryFlags; }
			set { m->QueryFlags = value; }
		}

		public QueryPipelineStatisticFlags PipelineStatistics {
			get { return m->PipelineStatistics; }
			set { m->PipelineStatistics = value; }
		}
		internal Interop.CommandBufferInheritanceInfo* m;

		public CommandBufferInheritanceInfo ()
		{
			m = (Interop.CommandBufferInheritanceInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferInheritanceInfo));
			Initialize ();
		}

		internal CommandBufferInheritanceInfo (Interop.CommandBufferInheritanceInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.CommandBufferInheritanceInfo;
		}

	}

	unsafe public partial class CommandBufferBeginInfo
	{
		public CommandBufferUsageFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		CommandBufferInheritanceInfo lInheritanceInfo;
		public CommandBufferInheritanceInfo InheritanceInfo {
			get { return lInheritanceInfo; }
			set { lInheritanceInfo = value; m->InheritanceInfo = (IntPtr)value.m; }
		}
		internal Interop.CommandBufferBeginInfo* m;

		public CommandBufferBeginInfo ()
		{
			m = (Interop.CommandBufferBeginInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferBeginInfo));
			Initialize ();
		}

		internal CommandBufferBeginInfo (Interop.CommandBufferBeginInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.CommandBufferBeginInfo;
		}

	}

	unsafe public partial class RenderPassBeginInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (UInt64)value.m; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; m->Framebuffer = (UInt64)value.m; }
		}

		public Rect2D RenderArea {
			get { return m->RenderArea; }
			set { m->RenderArea = value; }
		}

		public UInt32 ClearValueCount {
			get { return m->ClearValueCount; }
			set { m->ClearValueCount = value; }
		}

		public ClearValue[] ClearValues {
			get {
				if (m->ClearValueCount == 0)
					return null;
				var values = new ClearValue [m->ClearValueCount];
				unsafe
				{
					Interop.ClearValue* ptr = (Interop.ClearValue*)m->ClearValues;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new ClearValue ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->ClearValueCount = 0;
					m->ClearValues = IntPtr.Zero;
					return;
				}
				m->ClearValueCount = (uint)value.Length;
				m->ClearValues = Marshal.AllocHGlobal ((int)(sizeof(Interop.ClearValue)*value.Length));
				unsafe
				{
					Interop.ClearValue* ptr = (Interop.ClearValue*)m->ClearValues;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		internal Interop.RenderPassBeginInfo* m;

		public RenderPassBeginInfo ()
		{
			m = (Interop.RenderPassBeginInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassBeginInfo));
			Initialize ();
		}

		internal RenderPassBeginInfo (Interop.RenderPassBeginInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.RenderPassBeginInfo;
		}

	}

	unsafe public partial struct ClearDepthStencilValue
	{
		public float Depth;
		public UInt32 Stencil;
	}

	unsafe public partial struct ClearAttachment
	{
		public ImageAspectFlags AspectMask;
		public UInt32 ColorAttachment;
		public IntPtr ClearValue;
	}

	unsafe public partial struct AttachmentDescription
	{
		public AttachmentDescriptionFlags Flags;
		public Format Format;
		public SampleCountFlags Samples;
		public AttachmentLoadOp LoadOp;
		public AttachmentStoreOp StoreOp;
		public AttachmentLoadOp StencilLoadOp;
		public AttachmentStoreOp StencilStoreOp;
		public ImageLayout InitialLayout;
		public ImageLayout FinalLayout;
	}

	unsafe public partial struct AttachmentReference
	{
		public UInt32 Attachment;
		public ImageLayout Layout;
	}

	unsafe public partial class SubpassDescription
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public PipelineBindPoint PipelineBindPoint {
			get { return m->PipelineBindPoint; }
			set { m->PipelineBindPoint = value; }
		}

		public UInt32 InputAttachmentCount {
			get { return m->InputAttachmentCount; }
			set { m->InputAttachmentCount = value; }
		}

		public AttachmentReference[] InputAttachments {
			get {
				if (m->InputAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [m->InputAttachmentCount];
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->InputAttachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->InputAttachmentCount = 0;
					m->InputAttachments = IntPtr.Zero;
					return;
				}
				m->InputAttachmentCount = (uint)value.Length;
				m->InputAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->InputAttachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UInt32 ColorAttachmentCount {
			get { return m->ColorAttachmentCount; }
			set { m->ColorAttachmentCount = value; }
		}

		public AttachmentReference[] ColorAttachments {
			get {
				if (m->ColorAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [m->ColorAttachmentCount];
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->ColorAttachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->ColorAttachmentCount = 0;
					m->ColorAttachments = IntPtr.Zero;
					return;
				}
				m->ColorAttachmentCount = (uint)value.Length;
				m->ColorAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->ColorAttachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public AttachmentReference[] ResolveAttachments {
			get {
				if (m->ColorAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [m->ColorAttachmentCount];
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->ResolveAttachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->ColorAttachmentCount = 0;
					m->ResolveAttachments = IntPtr.Zero;
					return;
				}
				m->ColorAttachmentCount = (uint)value.Length;
				m->ResolveAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					AttachmentReference* ptr = (AttachmentReference*)m->ResolveAttachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public AttachmentReference DepthStencilAttachment {
			get { return (AttachmentReference)Interop.Structure.MarshalPointerToObject (m->DepthStencilAttachment, typeof (AttachmentReference)); }
			set { m->DepthStencilAttachment = Interop.Structure.MarshalObjectToPointer (m->DepthStencilAttachment, value); }
		}

		public UInt32 PreserveAttachmentCount {
			get { return m->PreserveAttachmentCount; }
			set { m->PreserveAttachmentCount = value; }
		}

		public UInt32[] PreserveAttachments {
			get {
				if (m->PreserveAttachmentCount == 0)
					return null;
				var values = new UInt32 [m->PreserveAttachmentCount];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->PreserveAttachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->PreserveAttachmentCount = 0;
					m->PreserveAttachments = IntPtr.Zero;
					return;
				}
				m->PreserveAttachmentCount = (uint)value.Length;
				m->PreserveAttachments = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->PreserveAttachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.SubpassDescription* m;

		public SubpassDescription ()
		{
			m = (Interop.SubpassDescription*) Interop.Structure.Allocate (typeof (Interop.SubpassDescription));
		}

		internal SubpassDescription (Interop.SubpassDescription* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial struct SubpassDependency
	{
		public UInt32 SrcSubpass;
		public UInt32 DstSubpass;
		public PipelineStageFlags SrcStageMask;
		public PipelineStageFlags DstStageMask;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public DependencyFlags DependencyFlags;
	}

	unsafe public partial class RenderPassCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UInt32 AttachmentCount {
			get { return m->AttachmentCount; }
			set { m->AttachmentCount = value; }
		}

		public AttachmentDescription[] Attachments {
			get {
				if (m->AttachmentCount == 0)
					return null;
				var values = new AttachmentDescription [m->AttachmentCount];
				unsafe
				{
					AttachmentDescription* ptr = (AttachmentDescription*)m->Attachments;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->AttachmentCount = 0;
					m->Attachments = IntPtr.Zero;
					return;
				}
				m->AttachmentCount = (uint)value.Length;
				m->Attachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentDescription)*value.Length));
				unsafe
				{
					AttachmentDescription* ptr = (AttachmentDescription*)m->Attachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UInt32 SubpassCount {
			get { return m->SubpassCount; }
			set { m->SubpassCount = value; }
		}

		public SubpassDescription[] Subpasses {
			get {
				if (m->SubpassCount == 0)
					return null;
				var values = new SubpassDescription [m->SubpassCount];
				unsafe
				{
					Interop.SubpassDescription* ptr = (Interop.SubpassDescription*)m->Subpasses;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SubpassDescription ();
						*values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->SubpassCount = 0;
					m->Subpasses = IntPtr.Zero;
					return;
				}
				m->SubpassCount = (uint)value.Length;
				m->Subpasses = Marshal.AllocHGlobal ((int)(sizeof(Interop.SubpassDescription)*value.Length));
				unsafe
				{
					Interop.SubpassDescription* ptr = (Interop.SubpassDescription*)m->Subpasses;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public UInt32 DependencyCount {
			get { return m->DependencyCount; }
			set { m->DependencyCount = value; }
		}

		public SubpassDependency[] Dependencies {
			get {
				if (m->DependencyCount == 0)
					return null;
				var values = new SubpassDependency [m->DependencyCount];
				unsafe
				{
					SubpassDependency* ptr = (SubpassDependency*)m->Dependencies;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->DependencyCount = 0;
					m->Dependencies = IntPtr.Zero;
					return;
				}
				m->DependencyCount = (uint)value.Length;
				m->Dependencies = Marshal.AllocHGlobal ((int)(sizeof(SubpassDependency)*value.Length));
				unsafe
				{
					SubpassDependency* ptr = (SubpassDependency*)m->Dependencies;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.RenderPassCreateInfo* m;

		public RenderPassCreateInfo ()
		{
			m = (Interop.RenderPassCreateInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassCreateInfo));
			Initialize ();
		}

		internal RenderPassCreateInfo (Interop.RenderPassCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.RenderPassCreateInfo;
		}

	}

	unsafe public partial class EventCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		internal Interop.EventCreateInfo* m;

		public EventCreateInfo ()
		{
			m = (Interop.EventCreateInfo*) Interop.Structure.Allocate (typeof (Interop.EventCreateInfo));
			Initialize ();
		}

		internal EventCreateInfo (Interop.EventCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.EventCreateInfo;
		}

	}

	unsafe public partial class FenceCreateInfo
	{
		public FenceCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		internal Interop.FenceCreateInfo* m;

		public FenceCreateInfo ()
		{
			m = (Interop.FenceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FenceCreateInfo));
			Initialize ();
		}

		internal FenceCreateInfo (Interop.FenceCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.FenceCreateInfo;
		}

	}

	unsafe public partial struct PhysicalDeviceFeatures
	{
		public Bool32 RobustBufferAccess;
		public Bool32 FullDrawIndexUint32;
		public Bool32 ImageCubeArray;
		public Bool32 IndependentBlend;
		public Bool32 GeometryShader;
		public Bool32 TessellationShader;
		public Bool32 SampleRateShading;
		public Bool32 DualSrcBlend;
		public Bool32 LogicOp;
		public Bool32 MultiDrawIndirect;
		public Bool32 DrawIndirectFirstInstance;
		public Bool32 DepthClamp;
		public Bool32 DepthBiasClamp;
		public Bool32 FillModeNonSolid;
		public Bool32 DepthBounds;
		public Bool32 WideLines;
		public Bool32 LargePoints;
		public Bool32 AlphaToOne;
		public Bool32 MultiViewport;
		public Bool32 SamplerAnisotropy;
		public Bool32 TextureCompressionETC2;
		public Bool32 TextureCompressionASTCLdr;
		public Bool32 TextureCompressionBC;
		public Bool32 OcclusionQueryPrecise;
		public Bool32 PipelineStatisticsQuery;
		public Bool32 VertexPipelineStoresAndAtomics;
		public Bool32 FragmentStoresAndAtomics;
		public Bool32 ShaderTessellationAndGeometryPointSize;
		public Bool32 ShaderImageGatherExtended;
		public Bool32 ShaderStorageImageExtendedFormats;
		public Bool32 ShaderStorageImageMultisample;
		public Bool32 ShaderStorageImageReadWithoutFormat;
		public Bool32 ShaderStorageImageWriteWithoutFormat;
		public Bool32 ShaderUniformBufferArrayDynamicIndexing;
		public Bool32 ShaderSampledImageArrayDynamicIndexing;
		public Bool32 ShaderStorageBufferArrayDynamicIndexing;
		public Bool32 ShaderStorageImageArrayDynamicIndexing;
		public Bool32 ShaderClipDistance;
		public Bool32 ShaderCullDistance;
		public Bool32 ShaderFloat64;
		public Bool32 ShaderInt64;
		public Bool32 ShaderInt16;
		public Bool32 ShaderResourceResidency;
		public Bool32 ShaderResourceMinLod;
		public Bool32 SparseBinding;
		public Bool32 SparseResidencyBuffer;
		public Bool32 SparseResidencyImage2D;
		public Bool32 SparseResidencyImage3D;
		public Bool32 SparseResidency2Samples;
		public Bool32 SparseResidency4Samples;
		public Bool32 SparseResidency8Samples;
		public Bool32 SparseResidency16Samples;
		public Bool32 SparseResidencyAliased;
		public Bool32 VariableMultisampleRate;
		public Bool32 InheritedQueries;
	}

	unsafe public partial struct PhysicalDeviceSparseProperties
	{
		public Bool32 ResidencyStandard2DBlockShape;
		public Bool32 ResidencyStandard2DMultisampleBlockShape;
		public Bool32 ResidencyStandard3DBlockShape;
		public Bool32 ResidencyAlignedMipSize;
		public Bool32 ResidencyNonResidentStrict;
	}

	unsafe public partial class PhysicalDeviceLimits
	{
		public UInt32 MaxImageDimension1D {
			get { return m->MaxImageDimension1D; }
			set { m->MaxImageDimension1D = value; }
		}

		public UInt32 MaxImageDimension2D {
			get { return m->MaxImageDimension2D; }
			set { m->MaxImageDimension2D = value; }
		}

		public UInt32 MaxImageDimension3D {
			get { return m->MaxImageDimension3D; }
			set { m->MaxImageDimension3D = value; }
		}

		public UInt32 MaxImageDimensionCube {
			get { return m->MaxImageDimensionCube; }
			set { m->MaxImageDimensionCube = value; }
		}

		public UInt32 MaxImageArrayLayers {
			get { return m->MaxImageArrayLayers; }
			set { m->MaxImageArrayLayers = value; }
		}

		public UInt32 MaxTexelBufferElements {
			get { return m->MaxTexelBufferElements; }
			set { m->MaxTexelBufferElements = value; }
		}

		public UInt32 MaxUniformBufferRange {
			get { return m->MaxUniformBufferRange; }
			set { m->MaxUniformBufferRange = value; }
		}

		public UInt32 MaxStorageBufferRange {
			get { return m->MaxStorageBufferRange; }
			set { m->MaxStorageBufferRange = value; }
		}

		public UInt32 MaxPushConstantsSize {
			get { return m->MaxPushConstantsSize; }
			set { m->MaxPushConstantsSize = value; }
		}

		public UInt32 MaxMemoryAllocationCount {
			get { return m->MaxMemoryAllocationCount; }
			set { m->MaxMemoryAllocationCount = value; }
		}

		public UInt32 MaxSamplerAllocationCount {
			get { return m->MaxSamplerAllocationCount; }
			set { m->MaxSamplerAllocationCount = value; }
		}

		public DeviceSize BufferImageGranularity {
			get { return m->BufferImageGranularity; }
			set { m->BufferImageGranularity = value; }
		}

		public DeviceSize SparseAddressSpaceSize {
			get { return m->SparseAddressSpaceSize; }
			set { m->SparseAddressSpaceSize = value; }
		}

		public UInt32 MaxBoundDescriptorSets {
			get { return m->MaxBoundDescriptorSets; }
			set { m->MaxBoundDescriptorSets = value; }
		}

		public UInt32 MaxPerStageDescriptorSamplers {
			get { return m->MaxPerStageDescriptorSamplers; }
			set { m->MaxPerStageDescriptorSamplers = value; }
		}

		public UInt32 MaxPerStageDescriptorUniformBuffers {
			get { return m->MaxPerStageDescriptorUniformBuffers; }
			set { m->MaxPerStageDescriptorUniformBuffers = value; }
		}

		public UInt32 MaxPerStageDescriptorStorageBuffers {
			get { return m->MaxPerStageDescriptorStorageBuffers; }
			set { m->MaxPerStageDescriptorStorageBuffers = value; }
		}

		public UInt32 MaxPerStageDescriptorSampledImages {
			get { return m->MaxPerStageDescriptorSampledImages; }
			set { m->MaxPerStageDescriptorSampledImages = value; }
		}

		public UInt32 MaxPerStageDescriptorStorageImages {
			get { return m->MaxPerStageDescriptorStorageImages; }
			set { m->MaxPerStageDescriptorStorageImages = value; }
		}

		public UInt32 MaxPerStageDescriptorInputAttachments {
			get { return m->MaxPerStageDescriptorInputAttachments; }
			set { m->MaxPerStageDescriptorInputAttachments = value; }
		}

		public UInt32 MaxPerStageResources {
			get { return m->MaxPerStageResources; }
			set { m->MaxPerStageResources = value; }
		}

		public UInt32 MaxDescriptorSetSamplers {
			get { return m->MaxDescriptorSetSamplers; }
			set { m->MaxDescriptorSetSamplers = value; }
		}

		public UInt32 MaxDescriptorSetUniformBuffers {
			get { return m->MaxDescriptorSetUniformBuffers; }
			set { m->MaxDescriptorSetUniformBuffers = value; }
		}

		public UInt32 MaxDescriptorSetUniformBuffersDynamic {
			get { return m->MaxDescriptorSetUniformBuffersDynamic; }
			set { m->MaxDescriptorSetUniformBuffersDynamic = value; }
		}

		public UInt32 MaxDescriptorSetStorageBuffers {
			get { return m->MaxDescriptorSetStorageBuffers; }
			set { m->MaxDescriptorSetStorageBuffers = value; }
		}

		public UInt32 MaxDescriptorSetStorageBuffersDynamic {
			get { return m->MaxDescriptorSetStorageBuffersDynamic; }
			set { m->MaxDescriptorSetStorageBuffersDynamic = value; }
		}

		public UInt32 MaxDescriptorSetSampledImages {
			get { return m->MaxDescriptorSetSampledImages; }
			set { m->MaxDescriptorSetSampledImages = value; }
		}

		public UInt32 MaxDescriptorSetStorageImages {
			get { return m->MaxDescriptorSetStorageImages; }
			set { m->MaxDescriptorSetStorageImages = value; }
		}

		public UInt32 MaxDescriptorSetInputAttachments {
			get { return m->MaxDescriptorSetInputAttachments; }
			set { m->MaxDescriptorSetInputAttachments = value; }
		}

		public UInt32 MaxVertexInputAttributes {
			get { return m->MaxVertexInputAttributes; }
			set { m->MaxVertexInputAttributes = value; }
		}

		public UInt32 MaxVertexInputBindings {
			get { return m->MaxVertexInputBindings; }
			set { m->MaxVertexInputBindings = value; }
		}

		public UInt32 MaxVertexInputAttributeOffset {
			get { return m->MaxVertexInputAttributeOffset; }
			set { m->MaxVertexInputAttributeOffset = value; }
		}

		public UInt32 MaxVertexInputBindingStride {
			get { return m->MaxVertexInputBindingStride; }
			set { m->MaxVertexInputBindingStride = value; }
		}

		public UInt32 MaxVertexOutputComponents {
			get { return m->MaxVertexOutputComponents; }
			set { m->MaxVertexOutputComponents = value; }
		}

		public UInt32 MaxTessellationGenerationLevel {
			get { return m->MaxTessellationGenerationLevel; }
			set { m->MaxTessellationGenerationLevel = value; }
		}

		public UInt32 MaxTessellationPatchSize {
			get { return m->MaxTessellationPatchSize; }
			set { m->MaxTessellationPatchSize = value; }
		}

		public UInt32 MaxTessellationControlPerVertexInputComponents {
			get { return m->MaxTessellationControlPerVertexInputComponents; }
			set { m->MaxTessellationControlPerVertexInputComponents = value; }
		}

		public UInt32 MaxTessellationControlPerVertexOutputComponents {
			get { return m->MaxTessellationControlPerVertexOutputComponents; }
			set { m->MaxTessellationControlPerVertexOutputComponents = value; }
		}

		public UInt32 MaxTessellationControlPerPatchOutputComponents {
			get { return m->MaxTessellationControlPerPatchOutputComponents; }
			set { m->MaxTessellationControlPerPatchOutputComponents = value; }
		}

		public UInt32 MaxTessellationControlTotalOutputComponents {
			get { return m->MaxTessellationControlTotalOutputComponents; }
			set { m->MaxTessellationControlTotalOutputComponents = value; }
		}

		public UInt32 MaxTessellationEvaluationInputComponents {
			get { return m->MaxTessellationEvaluationInputComponents; }
			set { m->MaxTessellationEvaluationInputComponents = value; }
		}

		public UInt32 MaxTessellationEvaluationOutputComponents {
			get { return m->MaxTessellationEvaluationOutputComponents; }
			set { m->MaxTessellationEvaluationOutputComponents = value; }
		}

		public UInt32 MaxGeometryShaderInvocations {
			get { return m->MaxGeometryShaderInvocations; }
			set { m->MaxGeometryShaderInvocations = value; }
		}

		public UInt32 MaxGeometryInputComponents {
			get { return m->MaxGeometryInputComponents; }
			set { m->MaxGeometryInputComponents = value; }
		}

		public UInt32 MaxGeometryOutputComponents {
			get { return m->MaxGeometryOutputComponents; }
			set { m->MaxGeometryOutputComponents = value; }
		}

		public UInt32 MaxGeometryOutputVertices {
			get { return m->MaxGeometryOutputVertices; }
			set { m->MaxGeometryOutputVertices = value; }
		}

		public UInt32 MaxGeometryTotalOutputComponents {
			get { return m->MaxGeometryTotalOutputComponents; }
			set { m->MaxGeometryTotalOutputComponents = value; }
		}

		public UInt32 MaxFragmentInputComponents {
			get { return m->MaxFragmentInputComponents; }
			set { m->MaxFragmentInputComponents = value; }
		}

		public UInt32 MaxFragmentOutputAttachments {
			get { return m->MaxFragmentOutputAttachments; }
			set { m->MaxFragmentOutputAttachments = value; }
		}

		public UInt32 MaxFragmentDualSrcAttachments {
			get { return m->MaxFragmentDualSrcAttachments; }
			set { m->MaxFragmentDualSrcAttachments = value; }
		}

		public UInt32 MaxFragmentCombinedOutputResources {
			get { return m->MaxFragmentCombinedOutputResources; }
			set { m->MaxFragmentCombinedOutputResources = value; }
		}

		public UInt32 MaxComputeSharedMemorySize {
			get { return m->MaxComputeSharedMemorySize; }
			set { m->MaxComputeSharedMemorySize = value; }
		}

		public UInt32[] MaxComputeWorkGroupCount {
			get {
				var arr = new UInt32 [3];
				for (int i = 0; i < 3; i++)
					arr [i] = m->MaxComputeWorkGroupCount [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->MaxComputeWorkGroupCount [i] = value [i];
				for (int i = value.Length; i < 3; i++)
					m->MaxComputeWorkGroupCount [i] = 0;
			}
		}

		public UInt32 MaxComputeWorkGroupInvocations {
			get { return m->MaxComputeWorkGroupInvocations; }
			set { m->MaxComputeWorkGroupInvocations = value; }
		}

		public UInt32[] MaxComputeWorkGroupSize {
			get {
				var arr = new UInt32 [3];
				for (int i = 0; i < 3; i++)
					arr [i] = m->MaxComputeWorkGroupSize [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->MaxComputeWorkGroupSize [i] = value [i];
				for (int i = value.Length; i < 3; i++)
					m->MaxComputeWorkGroupSize [i] = 0;
			}
		}

		public UInt32 SubPixelPrecisionBits {
			get { return m->SubPixelPrecisionBits; }
			set { m->SubPixelPrecisionBits = value; }
		}

		public UInt32 SubTexelPrecisionBits {
			get { return m->SubTexelPrecisionBits; }
			set { m->SubTexelPrecisionBits = value; }
		}

		public UInt32 MipmapPrecisionBits {
			get { return m->MipmapPrecisionBits; }
			set { m->MipmapPrecisionBits = value; }
		}

		public UInt32 MaxDrawIndexedIndexValue {
			get { return m->MaxDrawIndexedIndexValue; }
			set { m->MaxDrawIndexedIndexValue = value; }
		}

		public UInt32 MaxDrawIndirectCount {
			get { return m->MaxDrawIndirectCount; }
			set { m->MaxDrawIndirectCount = value; }
		}

		public float MaxSamplerLodBias {
			get { return m->MaxSamplerLodBias; }
			set { m->MaxSamplerLodBias = value; }
		}

		public float MaxSamplerAnisotropy {
			get { return m->MaxSamplerAnisotropy; }
			set { m->MaxSamplerAnisotropy = value; }
		}

		public UInt32 MaxViewports {
			get { return m->MaxViewports; }
			set { m->MaxViewports = value; }
		}

		public UInt32[] MaxViewportDimensions {
			get {
				var arr = new UInt32 [2];
				for (int i = 0; i < 2; i++)
					arr [i] = m->MaxViewportDimensions [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->MaxViewportDimensions [i] = value [i];
				for (int i = value.Length; i < 2; i++)
					m->MaxViewportDimensions [i] = 0;
			}
		}

		public float[] ViewportBoundsRange {
			get {
				var arr = new float [2];
				for (int i = 0; i < 2; i++)
					arr [i] = m->ViewportBoundsRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->ViewportBoundsRange [i] = value [i];
				for (int i = value.Length; i < 2; i++)
					m->ViewportBoundsRange [i] = 0;
			}
		}

		public UInt32 ViewportSubPixelBits {
			get { return m->ViewportSubPixelBits; }
			set { m->ViewportSubPixelBits = value; }
		}

		public UIntPtr MinMemoryMapAlignment {
			get { return m->MinMemoryMapAlignment; }
			set { m->MinMemoryMapAlignment = value; }
		}

		public DeviceSize MinTexelBufferOffsetAlignment {
			get { return m->MinTexelBufferOffsetAlignment; }
			set { m->MinTexelBufferOffsetAlignment = value; }
		}

		public DeviceSize MinUniformBufferOffsetAlignment {
			get { return m->MinUniformBufferOffsetAlignment; }
			set { m->MinUniformBufferOffsetAlignment = value; }
		}

		public DeviceSize MinStorageBufferOffsetAlignment {
			get { return m->MinStorageBufferOffsetAlignment; }
			set { m->MinStorageBufferOffsetAlignment = value; }
		}

		public Int32 MinTexelOffset {
			get { return m->MinTexelOffset; }
			set { m->MinTexelOffset = value; }
		}

		public UInt32 MaxTexelOffset {
			get { return m->MaxTexelOffset; }
			set { m->MaxTexelOffset = value; }
		}

		public Int32 MinTexelGatherOffset {
			get { return m->MinTexelGatherOffset; }
			set { m->MinTexelGatherOffset = value; }
		}

		public UInt32 MaxTexelGatherOffset {
			get { return m->MaxTexelGatherOffset; }
			set { m->MaxTexelGatherOffset = value; }
		}

		public float MinInterpolationOffset {
			get { return m->MinInterpolationOffset; }
			set { m->MinInterpolationOffset = value; }
		}

		public float MaxInterpolationOffset {
			get { return m->MaxInterpolationOffset; }
			set { m->MaxInterpolationOffset = value; }
		}

		public UInt32 SubPixelInterpolationOffsetBits {
			get { return m->SubPixelInterpolationOffsetBits; }
			set { m->SubPixelInterpolationOffsetBits = value; }
		}

		public UInt32 MaxFramebufferWidth {
			get { return m->MaxFramebufferWidth; }
			set { m->MaxFramebufferWidth = value; }
		}

		public UInt32 MaxFramebufferHeight {
			get { return m->MaxFramebufferHeight; }
			set { m->MaxFramebufferHeight = value; }
		}

		public UInt32 MaxFramebufferLayers {
			get { return m->MaxFramebufferLayers; }
			set { m->MaxFramebufferLayers = value; }
		}

		public SampleCountFlags FramebufferColorSampleCounts {
			get { return m->FramebufferColorSampleCounts; }
			set { m->FramebufferColorSampleCounts = value; }
		}

		public SampleCountFlags FramebufferDepthSampleCounts {
			get { return m->FramebufferDepthSampleCounts; }
			set { m->FramebufferDepthSampleCounts = value; }
		}

		public SampleCountFlags FramebufferStencilSampleCounts {
			get { return m->FramebufferStencilSampleCounts; }
			set { m->FramebufferStencilSampleCounts = value; }
		}

		public SampleCountFlags FramebufferNoAttachmentsSampleCounts {
			get { return m->FramebufferNoAttachmentsSampleCounts; }
			set { m->FramebufferNoAttachmentsSampleCounts = value; }
		}

		public UInt32 MaxColorAttachments {
			get { return m->MaxColorAttachments; }
			set { m->MaxColorAttachments = value; }
		}

		public SampleCountFlags SampledImageColorSampleCounts {
			get { return m->SampledImageColorSampleCounts; }
			set { m->SampledImageColorSampleCounts = value; }
		}

		public SampleCountFlags SampledImageIntegerSampleCounts {
			get { return m->SampledImageIntegerSampleCounts; }
			set { m->SampledImageIntegerSampleCounts = value; }
		}

		public SampleCountFlags SampledImageDepthSampleCounts {
			get { return m->SampledImageDepthSampleCounts; }
			set { m->SampledImageDepthSampleCounts = value; }
		}

		public SampleCountFlags SampledImageStencilSampleCounts {
			get { return m->SampledImageStencilSampleCounts; }
			set { m->SampledImageStencilSampleCounts = value; }
		}

		public SampleCountFlags StorageImageSampleCounts {
			get { return m->StorageImageSampleCounts; }
			set { m->StorageImageSampleCounts = value; }
		}

		public UInt32 MaxSampleMaskWords {
			get { return m->MaxSampleMaskWords; }
			set { m->MaxSampleMaskWords = value; }
		}

		public bool TimestampComputeAndGraphics {
			get { return m->TimestampComputeAndGraphics; }
			set { m->TimestampComputeAndGraphics = value; }
		}

		public float TimestampPeriod {
			get { return m->TimestampPeriod; }
			set { m->TimestampPeriod = value; }
		}

		public UInt32 MaxClipDistances {
			get { return m->MaxClipDistances; }
			set { m->MaxClipDistances = value; }
		}

		public UInt32 MaxCullDistances {
			get { return m->MaxCullDistances; }
			set { m->MaxCullDistances = value; }
		}

		public UInt32 MaxCombinedClipAndCullDistances {
			get { return m->MaxCombinedClipAndCullDistances; }
			set { m->MaxCombinedClipAndCullDistances = value; }
		}

		public UInt32 DiscreteQueuePriorities {
			get { return m->DiscreteQueuePriorities; }
			set { m->DiscreteQueuePriorities = value; }
		}

		public float[] PointSizeRange {
			get {
				var arr = new float [2];
				for (int i = 0; i < 2; i++)
					arr [i] = m->PointSizeRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->PointSizeRange [i] = value [i];
				for (int i = value.Length; i < 2; i++)
					m->PointSizeRange [i] = 0;
			}
		}

		public float[] LineWidthRange {
			get {
				var arr = new float [2];
				for (int i = 0; i < 2; i++)
					arr [i] = m->LineWidthRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->LineWidthRange [i] = value [i];
				for (int i = value.Length; i < 2; i++)
					m->LineWidthRange [i] = 0;
			}
		}

		public float PointSizeGranularity {
			get { return m->PointSizeGranularity; }
			set { m->PointSizeGranularity = value; }
		}

		public float LineWidthGranularity {
			get { return m->LineWidthGranularity; }
			set { m->LineWidthGranularity = value; }
		}

		public bool StrictLines {
			get { return m->StrictLines; }
			set { m->StrictLines = value; }
		}

		public bool StandardSampleLocations {
			get { return m->StandardSampleLocations; }
			set { m->StandardSampleLocations = value; }
		}

		public DeviceSize OptimalBufferCopyOffsetAlignment {
			get { return m->OptimalBufferCopyOffsetAlignment; }
			set { m->OptimalBufferCopyOffsetAlignment = value; }
		}

		public DeviceSize OptimalBufferCopyRowPitchAlignment {
			get { return m->OptimalBufferCopyRowPitchAlignment; }
			set { m->OptimalBufferCopyRowPitchAlignment = value; }
		}

		public DeviceSize NonCoherentAtomSize {
			get { return m->NonCoherentAtomSize; }
			set { m->NonCoherentAtomSize = value; }
		}
		internal Interop.PhysicalDeviceLimits* m;

		public PhysicalDeviceLimits ()
		{
			m = (Interop.PhysicalDeviceLimits*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceLimits));
		}

		internal PhysicalDeviceLimits (Interop.PhysicalDeviceLimits* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class SemaphoreCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		internal Interop.SemaphoreCreateInfo* m;

		public SemaphoreCreateInfo ()
		{
			m = (Interop.SemaphoreCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SemaphoreCreateInfo));
			Initialize ();
		}

		internal SemaphoreCreateInfo (Interop.SemaphoreCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.SemaphoreCreateInfo;
		}

	}

	unsafe public partial class QueryPoolCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public QueryType QueryType {
			get { return m->QueryType; }
			set { m->QueryType = value; }
		}

		public UInt32 QueryCount {
			get { return m->QueryCount; }
			set { m->QueryCount = value; }
		}

		public QueryPipelineStatisticFlags PipelineStatistics {
			get { return m->PipelineStatistics; }
			set { m->PipelineStatistics = value; }
		}
		internal Interop.QueryPoolCreateInfo* m;

		public QueryPoolCreateInfo ()
		{
			m = (Interop.QueryPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.QueryPoolCreateInfo));
			Initialize ();
		}

		internal QueryPoolCreateInfo (Interop.QueryPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.QueryPoolCreateInfo;
		}

	}

	unsafe public partial class FramebufferCreateInfo
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (UInt64)value.m; }
		}

		public UInt32 AttachmentCount {
			get { return m->AttachmentCount; }
			set { m->AttachmentCount = value; }
		}

		public ImageView[] Attachments {
			get {
				if (m->AttachmentCount == 0)
					return null;
				var values = new ImageView [m->AttachmentCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->Attachments;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new ImageView ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->AttachmentCount = 0;
					m->Attachments = IntPtr.Zero;
					return;
				}
				m->AttachmentCount = (uint)value.Length;
				m->Attachments = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->Attachments;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32 Width {
			get { return m->Width; }
			set { m->Width = value; }
		}

		public UInt32 Height {
			get { return m->Height; }
			set { m->Height = value; }
		}

		public UInt32 Layers {
			get { return m->Layers; }
			set { m->Layers = value; }
		}
		internal Interop.FramebufferCreateInfo* m;

		public FramebufferCreateInfo ()
		{
			m = (Interop.FramebufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FramebufferCreateInfo));
			Initialize ();
		}

		internal FramebufferCreateInfo (Interop.FramebufferCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.FramebufferCreateInfo;
		}

	}

	unsafe public partial struct DrawIndirectCommand
	{
		public UInt32 VertexCount;
		public UInt32 InstanceCount;
		public UInt32 FirstVertex;
		public UInt32 FirstInstance;
	}

	unsafe public partial struct DrawIndexedIndirectCommand
	{
		public UInt32 IndexCount;
		public UInt32 InstanceCount;
		public UInt32 FirstIndex;
		public Int32 VertexOffset;
		public UInt32 FirstInstance;
	}

	unsafe public partial struct DispatchIndirectCommand
	{
		public UInt32 X;
		public UInt32 Y;
		public UInt32 Z;
	}

	unsafe public partial class SubmitInfo
	{
		public UInt32 WaitSemaphoreCount {
			get { return m->WaitSemaphoreCount; }
			set { m->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (m->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [m->WaitSemaphoreCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->WaitSemaphoreCount = 0;
					m->WaitSemaphores = IntPtr.Zero;
					return;
				}
				m->WaitSemaphoreCount = (uint)value.Length;
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public PipelineStageFlags[] WaitDstStageMask {
			get {
				if (m->WaitSemaphoreCount == 0)
					return null;
				var values = new PipelineStageFlags [m->WaitSemaphoreCount];
				unsafe
				{
					PipelineStageFlags* ptr = (PipelineStageFlags*)m->WaitDstStageMask;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->WaitSemaphoreCount = 0;
					m->WaitDstStageMask = IntPtr.Zero;
					return;
				}
				m->WaitSemaphoreCount = (uint)value.Length;
				m->WaitDstStageMask = Marshal.AllocHGlobal ((int)(sizeof(PipelineStageFlags)*value.Length));
				unsafe
				{
					PipelineStageFlags* ptr = (PipelineStageFlags*)m->WaitDstStageMask;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UInt32 CommandBufferCount {
			get { return m->CommandBufferCount; }
			set { m->CommandBufferCount = value; }
		}

		public CommandBuffer[] CommandBuffers {
			get {
				if (m->CommandBufferCount == 0)
					return null;
				var values = new CommandBuffer [m->CommandBufferCount];
				unsafe
				{
					IntPtr* ptr = (IntPtr*)m->CommandBuffers;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new CommandBuffer ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->CommandBufferCount = 0;
					m->CommandBuffers = IntPtr.Zero;
					return;
				}
				m->CommandBufferCount = (uint)value.Length;
				m->CommandBuffers = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*value.Length));
				unsafe
				{
					IntPtr* ptr = (IntPtr*)m->CommandBuffers;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32 SignalSemaphoreCount {
			get { return m->SignalSemaphoreCount; }
			set { m->SignalSemaphoreCount = value; }
		}

		public Semaphore[] SignalSemaphores {
			get {
				if (m->SignalSemaphoreCount == 0)
					return null;
				var values = new Semaphore [m->SignalSemaphoreCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SignalSemaphores;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->SignalSemaphoreCount = 0;
					m->SignalSemaphores = IntPtr.Zero;
					return;
				}
				m->SignalSemaphoreCount = (uint)value.Length;
				m->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->SignalSemaphores;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		internal Interop.SubmitInfo* m;

		public SubmitInfo ()
		{
			m = (Interop.SubmitInfo*) Interop.Structure.Allocate (typeof (Interop.SubmitInfo));
			Initialize ();
		}

		internal SubmitInfo (Interop.SubmitInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.SubmitInfo;
		}

	}

	unsafe public partial class DisplayPropertiesKhr
	{
		DisplayKhr lDisplay;
		public DisplayKhr Display {
			get { return lDisplay; }
			set { lDisplay = value; m->Display = (UInt64)value.m; }
		}

		public string DisplayName {
			get { return Marshal.PtrToStringAnsi (m->DisplayName); }
			set { m->DisplayName = Marshal.StringToHGlobalAnsi (value); }
		}

		public Extent2D PhysicalDimensions {
			get { return m->PhysicalDimensions; }
			set { m->PhysicalDimensions = value; }
		}

		public Extent2D PhysicalResolution {
			get { return m->PhysicalResolution; }
			set { m->PhysicalResolution = value; }
		}

		public SurfaceTransformFlagsKhr SupportedTransforms {
			get { return m->SupportedTransforms; }
			set { m->SupportedTransforms = value; }
		}

		public bool PlaneReorderPossible {
			get { return m->PlaneReorderPossible; }
			set { m->PlaneReorderPossible = value; }
		}

		public bool PersistentContent {
			get { return m->PersistentContent; }
			set { m->PersistentContent = value; }
		}
		internal Interop.DisplayPropertiesKhr* m;

		public DisplayPropertiesKhr ()
		{
			m = (Interop.DisplayPropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPropertiesKhr));
			Initialize ();
		}

		internal DisplayPropertiesKhr (Interop.DisplayPropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class DisplayPlanePropertiesKhr
	{
		DisplayKhr lCurrentDisplay;
		public DisplayKhr CurrentDisplay {
			get { return lCurrentDisplay; }
			set { lCurrentDisplay = value; m->CurrentDisplay = (UInt64)value.m; }
		}

		public UInt32 CurrentStackIndex {
			get { return m->CurrentStackIndex; }
			set { m->CurrentStackIndex = value; }
		}
		internal Interop.DisplayPlanePropertiesKhr* m;

		public DisplayPlanePropertiesKhr ()
		{
			m = (Interop.DisplayPlanePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPlanePropertiesKhr));
			Initialize ();
		}

		internal DisplayPlanePropertiesKhr (Interop.DisplayPlanePropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial struct DisplayModeParametersKhr
	{
		public Extent2D VisibleRegion;
		public UInt32 RefreshRate;
	}

	unsafe public partial class DisplayModePropertiesKhr
	{
		DisplayModeKhr lDisplayMode;
		public DisplayModeKhr DisplayMode {
			get { return lDisplayMode; }
			set { lDisplayMode = value; m->DisplayMode = (UInt64)value.m; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return m->Parameters; }
			set { m->Parameters = value; }
		}
		internal Interop.DisplayModePropertiesKhr* m;

		public DisplayModePropertiesKhr ()
		{
			m = (Interop.DisplayModePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModePropertiesKhr));
			Initialize ();
		}

		internal DisplayModePropertiesKhr (Interop.DisplayModePropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
		}

	}

	unsafe public partial class DisplayModeCreateInfoKhr
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return m->Parameters; }
			set { m->Parameters = value; }
		}
		internal Interop.DisplayModeCreateInfoKhr* m;

		public DisplayModeCreateInfoKhr ()
		{
			m = (Interop.DisplayModeCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModeCreateInfoKhr));
			Initialize ();
		}

		internal DisplayModeCreateInfoKhr (Interop.DisplayModeCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DisplayModeCreateInfoKhr;
		}

	}

	unsafe public partial struct DisplayPlaneCapabilitiesKhr
	{
		public DisplayPlaneAlphaFlagsKhr SupportedAlpha;
		public Offset2D MinSrcPosition;
		public Offset2D MaxSrcPosition;
		public Extent2D MinSrcExtent;
		public Extent2D MaxSrcExtent;
		public Offset2D MinDstPosition;
		public Offset2D MaxDstPosition;
		public Extent2D MinDstExtent;
		public Extent2D MaxDstExtent;
	}

	unsafe public partial class DisplaySurfaceCreateInfoKhr
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		DisplayModeKhr lDisplayMode;
		public DisplayModeKhr DisplayMode {
			get { return lDisplayMode; }
			set { lDisplayMode = value; m->DisplayMode = (UInt64)value.m; }
		}

		public UInt32 PlaneIndex {
			get { return m->PlaneIndex; }
			set { m->PlaneIndex = value; }
		}

		public UInt32 PlaneStackIndex {
			get { return m->PlaneStackIndex; }
			set { m->PlaneStackIndex = value; }
		}

		public SurfaceTransformFlagsKhr Transform {
			get { return m->Transform; }
			set { m->Transform = value; }
		}

		public float GlobalAlpha {
			get { return m->GlobalAlpha; }
			set { m->GlobalAlpha = value; }
		}

		public DisplayPlaneAlphaFlagsKhr AlphaMode {
			get { return m->AlphaMode; }
			set { m->AlphaMode = value; }
		}

		public Extent2D ImageExtent {
			get { return m->ImageExtent; }
			set { m->ImageExtent = value; }
		}
		internal Interop.DisplaySurfaceCreateInfoKhr* m;

		public DisplaySurfaceCreateInfoKhr ()
		{
			m = (Interop.DisplaySurfaceCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplaySurfaceCreateInfoKhr));
			Initialize ();
		}

		internal DisplaySurfaceCreateInfoKhr (Interop.DisplaySurfaceCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DisplaySurfaceCreateInfoKhr;
		}

	}

	unsafe public partial class DisplayPresentInfoKhr
	{
		public Rect2D SrcRect {
			get { return m->SrcRect; }
			set { m->SrcRect = value; }
		}

		public Rect2D DstRect {
			get { return m->DstRect; }
			set { m->DstRect = value; }
		}

		public bool Persistent {
			get { return m->Persistent; }
			set { m->Persistent = value; }
		}
		internal Interop.DisplayPresentInfoKhr* m;

		public DisplayPresentInfoKhr ()
		{
			m = (Interop.DisplayPresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPresentInfoKhr));
			Initialize ();
		}

		internal DisplayPresentInfoKhr (Interop.DisplayPresentInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DisplayPresentInfoKhr;
		}

	}

	unsafe public partial struct SurfaceCapabilitiesKhr
	{
		public UInt32 MinImageCount;
		public UInt32 MaxImageCount;
		public Extent2D CurrentExtent;
		public Extent2D MinImageExtent;
		public Extent2D MaxImageExtent;
		public UInt32 MaxImageArrayLayers;
		public SurfaceTransformFlagsKhr SupportedTransforms;
		public SurfaceTransformFlagsKhr CurrentTransform;
		public CompositeAlphaFlagsKhr SupportedCompositeAlpha;
		public ImageUsageFlags SupportedUsageFlags;
	}

	unsafe public partial struct SurfaceFormatKhr
	{
		public Format Format;
		public ColorSpaceKhr ColorSpace;
	}

	unsafe public partial class SwapchainCreateInfoKhr
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		SurfaceKhr lSurface;
		public SurfaceKhr Surface {
			get { return lSurface; }
			set { lSurface = value; m->Surface = (UInt64)value.m; }
		}

		public UInt32 MinImageCount {
			get { return m->MinImageCount; }
			set { m->MinImageCount = value; }
		}

		public Format ImageFormat {
			get { return m->ImageFormat; }
			set { m->ImageFormat = value; }
		}

		public ColorSpaceKhr ImageColorSpace {
			get { return m->ImageColorSpace; }
			set { m->ImageColorSpace = value; }
		}

		public Extent2D ImageExtent {
			get { return m->ImageExtent; }
			set { m->ImageExtent = value; }
		}

		public UInt32 ImageArrayLayers {
			get { return m->ImageArrayLayers; }
			set { m->ImageArrayLayers = value; }
		}

		public ImageUsageFlags ImageUsage {
			get { return m->ImageUsage; }
			set { m->ImageUsage = value; }
		}

		public SharingMode ImageSharingMode {
			get { return m->ImageSharingMode; }
			set { m->ImageSharingMode = value; }
		}

		public UInt32 QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public UInt32[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new UInt32 [m->QueueFamilyIndexCount];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->QueueFamilyIndexCount = 0;
					m->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				m->QueueFamilyIndexCount = (uint)value.Length;
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->QueueFamilyIndices;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public SurfaceTransformFlagsKhr PreTransform {
			get { return m->PreTransform; }
			set { m->PreTransform = value; }
		}

		public CompositeAlphaFlagsKhr CompositeAlpha {
			get { return m->CompositeAlpha; }
			set { m->CompositeAlpha = value; }
		}

		public PresentModeKhr PresentMode {
			get { return m->PresentMode; }
			set { m->PresentMode = value; }
		}

		public bool Clipped {
			get { return m->Clipped; }
			set { m->Clipped = value; }
		}

		SwapchainKhr lOldSwapchain;
		public SwapchainKhr OldSwapchain {
			get { return lOldSwapchain; }
			set { lOldSwapchain = value; m->OldSwapchain = (UInt64)value.m; }
		}
		internal Interop.SwapchainCreateInfoKhr* m;

		public SwapchainCreateInfoKhr ()
		{
			m = (Interop.SwapchainCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.SwapchainCreateInfoKhr));
			Initialize ();
		}

		internal SwapchainCreateInfoKhr (Interop.SwapchainCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.SwapchainCreateInfoKhr;
		}

	}

	unsafe public partial class PresentInfoKhr
	{
		public UInt32 WaitSemaphoreCount {
			get { return m->WaitSemaphoreCount; }
			set { m->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (m->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [m->WaitSemaphoreCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->WaitSemaphoreCount = 0;
					m->WaitSemaphores = IntPtr.Zero;
					return;
				}
				m->WaitSemaphoreCount = (uint)value.Length;
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->WaitSemaphores;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32 SwapchainCount {
			get { return m->SwapchainCount; }
			set { m->SwapchainCount = value; }
		}

		public SwapchainKhr[] Swapchains {
			get {
				if (m->SwapchainCount == 0)
					return null;
				var values = new SwapchainKhr [m->SwapchainCount];
				unsafe
				{
					UInt64* ptr = (UInt64*)m->Swapchains;
					for (int i = 0; i < values.Length; i++) {
						values [i] = new SwapchainKhr ();
						values [i].m = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					m->SwapchainCount = 0;
					m->Swapchains = IntPtr.Zero;
					return;
				}
				m->SwapchainCount = (uint)value.Length;
				m->Swapchains = Marshal.AllocHGlobal ((int)(sizeof(UInt64)*value.Length));
				unsafe
				{
					UInt64* ptr = (UInt64*)m->Swapchains;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public UInt32[] ImageIndices {
			get {
				if (m->SwapchainCount == 0)
					return null;
				var values = new UInt32 [m->SwapchainCount];
				unsafe
				{
					UInt32* ptr = (UInt32*)m->ImageIndices;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->SwapchainCount = 0;
					m->ImageIndices = IntPtr.Zero;
					return;
				}
				m->SwapchainCount = (uint)value.Length;
				m->ImageIndices = Marshal.AllocHGlobal ((int)(sizeof(UInt32)*value.Length));
				unsafe
				{
					UInt32* ptr = (UInt32*)m->ImageIndices;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public Result[] Results {
			get {
				if (m->SwapchainCount == 0)
					return null;
				var values = new Result [m->SwapchainCount];
				unsafe
				{
					Result* ptr = (Result*)m->Results;
					for (int i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					m->SwapchainCount = 0;
					m->Results = IntPtr.Zero;
					return;
				}
				m->SwapchainCount = (uint)value.Length;
				m->Results = Marshal.AllocHGlobal ((int)(sizeof(Result)*value.Length));
				unsafe
				{
					Result* ptr = (Result*)m->Results;
					for (int i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		internal Interop.PresentInfoKhr* m;

		public PresentInfoKhr ()
		{
			m = (Interop.PresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.PresentInfoKhr));
			Initialize ();
		}

		internal PresentInfoKhr (Interop.PresentInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PresentInfoKhr;
		}

	}

	unsafe public partial class DebugReportCallbackCreateInfoExt
	{
		public DebugReportFlagsExt Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public IntPtr PfnCallback {
			get { return m->PfnCallback; }
			set { m->PfnCallback = value; }
		}

		public IntPtr UserData {
			get { return m->UserData; }
			set { m->UserData = value; }
		}
		internal Interop.DebugReportCallbackCreateInfoExt* m;

		public DebugReportCallbackCreateInfoExt ()
		{
			m = (Interop.DebugReportCallbackCreateInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugReportCallbackCreateInfoExt));
			Initialize ();
		}

		internal DebugReportCallbackCreateInfoExt (Interop.DebugReportCallbackCreateInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DebugReportCallbackCreateInfoExt;
		}

	}

	unsafe public partial class PipelineRasterizationStateRasterizationOrderAmd
	{
		public RasterizationOrderAmd RasterizationOrder {
			get { return m->RasterizationOrder; }
			set { m->RasterizationOrder = value; }
		}
		internal Interop.PipelineRasterizationStateRasterizationOrderAmd* m;

		public PipelineRasterizationStateRasterizationOrderAmd ()
		{
			m = (Interop.PipelineRasterizationStateRasterizationOrderAmd*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateRasterizationOrderAmd));
			Initialize ();
		}

		internal PipelineRasterizationStateRasterizationOrderAmd (Interop.PipelineRasterizationStateRasterizationOrderAmd* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.PipelineRasterizationStateRasterizationOrderAmd;
		}

	}

	unsafe public partial class DebugMarkerObjectNameInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return m->ObjectType; }
			set { m->ObjectType = value; }
		}

		public UInt64 Object {
			get { return m->Object; }
			set { m->Object = value; }
		}

		public string ObjectName {
			get { return Marshal.PtrToStringAnsi (m->ObjectName); }
			set { m->ObjectName = Marshal.StringToHGlobalAnsi (value); }
		}
		internal Interop.DebugMarkerObjectNameInfoExt* m;

		public DebugMarkerObjectNameInfoExt ()
		{
			m = (Interop.DebugMarkerObjectNameInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectNameInfoExt));
			Initialize ();
		}

		internal DebugMarkerObjectNameInfoExt (Interop.DebugMarkerObjectNameInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DebugMarkerObjectNameInfoExt;
		}

	}

	unsafe public partial class DebugMarkerObjectTagInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return m->ObjectType; }
			set { m->ObjectType = value; }
		}

		public UInt64 Object {
			get { return m->Object; }
			set { m->Object = value; }
		}

		public UInt64 TagName {
			get { return m->TagName; }
			set { m->TagName = value; }
		}

		public UIntPtr TagSize {
			get { return m->TagSize; }
			set { m->TagSize = value; }
		}

		public IntPtr Tag {
			get { return m->Tag; }
			set { m->Tag = value; }
		}
		internal Interop.DebugMarkerObjectTagInfoExt* m;

		public DebugMarkerObjectTagInfoExt ()
		{
			m = (Interop.DebugMarkerObjectTagInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectTagInfoExt));
			Initialize ();
		}

		internal DebugMarkerObjectTagInfoExt (Interop.DebugMarkerObjectTagInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DebugMarkerObjectTagInfoExt;
		}

	}

	unsafe public partial class DebugMarkerMarkerInfoExt
	{
		public string MarkerName {
			get { return Marshal.PtrToStringAnsi (m->MarkerName); }
			set { m->MarkerName = Marshal.StringToHGlobalAnsi (value); }
		}

		public float[] Color {
			get {
				var arr = new float [4];
				for (int i = 0; i < 4; i++)
					arr [i] = m->Color [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->Color [i] = value [i];
				for (int i = value.Length; i < 4; i++)
					m->Color [i] = 0;
			}
		}
		internal Interop.DebugMarkerMarkerInfoExt* m;

		public DebugMarkerMarkerInfoExt ()
		{
			m = (Interop.DebugMarkerMarkerInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerMarkerInfoExt));
			Initialize ();
		}

		internal DebugMarkerMarkerInfoExt (Interop.DebugMarkerMarkerInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.DebugMarkerMarkerInfoExt;
		}

	}
}
