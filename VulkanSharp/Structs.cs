using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	public struct Offset2D
	{
		public int X;
		public int Y;
	}

	public struct Offset3D
	{
		public int X;
		public int Y;
		public int Z;
	}

	public struct Extent2D
	{
		public uint Width;
		public uint Height;
	}

	public struct Extent3D
	{
		public uint Width;
		public uint Height;
		public uint Depth;
	}

	public struct Viewport
	{
		public float X;
		public float Y;
		public float Width;
		public float Height;
		public float MinDepth;
		public float MaxDepth;
	}

	public struct Rect2D
	{
		public Offset2D Offset;
		public Extent2D Extent;
	}

	public struct Rect3D
	{
		public Offset3D Offset;
		public Extent3D Extent;
	}

	public struct ClearRect
	{
		public Rect2D Rect;
		public uint BaseArrayLayer;
		public uint LayerCount;
	}

	public struct ComponentMapping
	{
		public ComponentSwizzle R;
		public ComponentSwizzle G;
		public ComponentSwizzle B;
		public ComponentSwizzle A;
	}

	public unsafe class PhysicalDeviceProperties
	{
		public uint ApiVersion {
			get { return _handle->ApiVersion; }
			set { _handle->ApiVersion = value; }
		}

		public uint DriverVersion {
			get { return _handle->DriverVersion; }
			set { _handle->DriverVersion = value; }
		}

		public uint VendorID {
			get { return _handle->VendorID; }
			set { _handle->VendorID = value; }
		}

		public uint DeviceID {
			get { return _handle->DeviceID; }
			set { _handle->DeviceID = value; }
		}

		public PhysicalDeviceType DeviceType {
			get { return _handle->DeviceType; }
			set { _handle->DeviceType = value; }
		}

		public string DeviceName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)_handle->DeviceName); }
			set { Interop.Structure.MarshalFixedSizeString (_handle->DeviceName, value, 256); }
		}

		public byte[] PipelineCacheUUID {
			get {
				var arr = new byte [16];
				for (var i = 0; i < 16; i++)
					arr [i] = _handle->PipelineCacheUUID [i];
				return arr;
			}

			set {
				if (value.Length > 16)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->PipelineCacheUUID [i] = value [i];
				for (var i = value.Length; i < 16; i++)
					_handle->PipelineCacheUUID [i] = 0;
			}
		}

		PhysicalDeviceLimits lLimits;
		public PhysicalDeviceLimits Limits {
			get { return lLimits; }
			set { lLimits = value; _handle->Limits = *value.m; }
		}

		public PhysicalDeviceSparseProperties SparseProperties {
			get { return _handle->SparseProperties; }
			set { _handle->SparseProperties = value; }
		}
		public Interop.PhysicalDeviceProperties* _handle;

		public PhysicalDeviceProperties ()
		{
			_handle = (Interop.PhysicalDeviceProperties*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceProperties));
			Initialize ();
		}

		public PhysicalDeviceProperties (Interop.PhysicalDeviceProperties* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			lLimits = new PhysicalDeviceLimits (&_handle->Limits);
		}

	}

	public unsafe class ExtensionProperties
	{
		public string ExtensionName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)_handle->ExtensionName); }
			set { Interop.Structure.MarshalFixedSizeString (_handle->ExtensionName, value, 256); }
		}

		public uint SpecVersion {
			get { return _handle->SpecVersion; }
			set { _handle->SpecVersion = value; }
		}
		public Interop.ExtensionProperties* _handle;

		public ExtensionProperties ()
		{
			_handle = (Interop.ExtensionProperties*) Interop.Structure.Allocate (typeof (Interop.ExtensionProperties));
		}

		public ExtensionProperties (Interop.ExtensionProperties* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class LayerProperties
	{
		public string LayerName {
			get { return Marshal.PtrToStringAnsi ((IntPtr)_handle->LayerName); }
			set { Interop.Structure.MarshalFixedSizeString (_handle->LayerName, value, 256); }
		}

		public uint SpecVersion {
			get { return _handle->SpecVersion; }
			set { _handle->SpecVersion = value; }
		}

		public uint ImplementationVersion {
			get { return _handle->ImplementationVersion; }
			set { _handle->ImplementationVersion = value; }
		}

		public string Description {
			get { return Marshal.PtrToStringAnsi ((IntPtr)_handle->Description); }
			set { Interop.Structure.MarshalFixedSizeString (_handle->Description, value, 256); }
		}
		public Interop.LayerProperties* _handle;

		public LayerProperties ()
		{
			_handle = (Interop.LayerProperties*) Interop.Structure.Allocate (typeof (Interop.LayerProperties));
		}

		public LayerProperties (Interop.LayerProperties* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class ApplicationInfo
	{
		public string ApplicationName {
			get { return Marshal.PtrToStringAnsi (_handle->ApplicationName); }
			set { _handle->ApplicationName = Marshal.StringToHGlobalAnsi (value); }
		}

		public uint ApplicationVersion {
			get { return _handle->ApplicationVersion; }
			set { _handle->ApplicationVersion = value; }
		}

		public string EngineName {
			get { return Marshal.PtrToStringAnsi (_handle->EngineName); }
			set { _handle->EngineName = Marshal.StringToHGlobalAnsi (value); }
		}

		public uint EngineVersion {
			get { return _handle->EngineVersion; }
			set { _handle->EngineVersion = value; }
		}

		public uint ApiVersion {
			get { return _handle->ApiVersion; }
			set { _handle->ApiVersion = value; }
		}
		public Interop.ApplicationInfo* _handle;

		public ApplicationInfo ()
		{
			_handle = (Interop.ApplicationInfo*) Interop.Structure.Allocate (typeof (Interop.ApplicationInfo));
			Initialize ();
		}

		public ApplicationInfo (Interop.ApplicationInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ApplicationInfo;
		}

	}

	public unsafe class AllocationCallbacks
	{
		public IntPtr UserData {
			get { return _handle->UserData; }
			set { _handle->UserData = value; }
		}

		public IntPtr PfnAllocation {
			get { return _handle->PfnAllocation; }
			set { _handle->PfnAllocation = value; }
		}

		public IntPtr PfnReallocation {
			get { return _handle->PfnReallocation; }
			set { _handle->PfnReallocation = value; }
		}

		public IntPtr PfnFree {
			get { return _handle->PfnFree; }
			set { _handle->PfnFree = value; }
		}

		public IntPtr PfnInternalAllocation {
			get { return _handle->PfnInternalAllocation; }
			set { _handle->PfnInternalAllocation = value; }
		}

		public IntPtr PfnInternalFree {
			get { return _handle->PfnInternalFree; }
			set { _handle->PfnInternalFree = value; }
		}
		private Interop.AllocationCallbacks* _handle;

		public AllocationCallbacks ()
		{
			_handle = (Interop.AllocationCallbacks*) Interop.Structure.Allocate (typeof (Interop.AllocationCallbacks));
		}

		public AllocationCallbacks (Interop.AllocationCallbacks* ptr)
		{
			_handle = ptr;
		}

		public Interop.AllocationCallbacks* Handle => _handle;
	}

	public unsafe class DeviceQueueCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint QueueFamilyIndex {
			get { return _handle->QueueFamilyIndex; }
			set { _handle->QueueFamilyIndex = value; }
		}

		public uint QueueCount {
			get { return _handle->QueueCount; }
			set { _handle->QueueCount = value; }
		}

		public float[] QueuePriorities {
			get {
				if (_handle->QueueCount == 0)
					return null;
				var values = new float [_handle->QueueCount];
				unsafe
				{
					var ptr = (float*)_handle->QueuePriorities;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->QueueCount = 0;
					_handle->QueuePriorities = IntPtr.Zero;
					return;
				}
				_handle->QueueCount = (uint)value.Length;
				_handle->QueuePriorities = Marshal.AllocHGlobal ((int)(sizeof(float)*value.Length));
				unsafe
				{
					var ptr = (float*)_handle->QueuePriorities;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.DeviceQueueCreateInfo* _handle;

		public DeviceQueueCreateInfo ()
		{
			_handle = (Interop.DeviceQueueCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DeviceQueueCreateInfo));
			Initialize ();
		}

		public DeviceQueueCreateInfo (Interop.DeviceQueueCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DeviceQueueCreateInfo;
		}

	}

	public unsafe class DeviceCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint QueueCreateInfoCount {
			get { return _handle->QueueCreateInfoCount; }
			set { _handle->QueueCreateInfoCount = value; }
		}

		public DeviceQueueCreateInfo[] QueueCreateInfos {
			get {
				if (_handle->QueueCreateInfoCount == 0)
					return null;
				var values = new DeviceQueueCreateInfo [_handle->QueueCreateInfoCount];
				unsafe
				{
					var ptr = (Interop.DeviceQueueCreateInfo*)_handle->QueueCreateInfos;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DeviceQueueCreateInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->QueueCreateInfoCount = 0;
					_handle->QueueCreateInfos = IntPtr.Zero;
					return;
				}
				_handle->QueueCreateInfoCount = (uint)value.Length;
				_handle->QueueCreateInfos = Marshal.AllocHGlobal ((int)(sizeof(Interop.DeviceQueueCreateInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.DeviceQueueCreateInfo*)_handle->QueueCreateInfos;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public uint EnabledLayerCount {
			get { return _handle->EnabledLayerCount; }
			set { _handle->EnabledLayerCount = value; }
		}

		public string[] EnabledLayerNames {
			get {
				if (_handle->EnabledLayerCount == 0)
					return null;
				var strings = new string [_handle->EnabledLayerCount];
				unsafe
				{
					var ptr = (void**)_handle->EnabledLayerNames;
					for (var i = 0; i < _handle->EnabledLayerCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					_handle->EnabledLayerCount = 0;
					_handle->EnabledLayerNames = IntPtr.Zero;
					return;
				}
				_handle->EnabledLayerCount = (uint)value.Length;
				_handle->EnabledLayerNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*_handle->EnabledLayerCount));
				unsafe
				{
					var ptr = (void**)_handle->EnabledLayerNames;
					for (var i = 0; i < _handle->EnabledLayerCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public uint EnabledExtensionCount {
			get { return _handle->EnabledExtensionCount; }
			set { _handle->EnabledExtensionCount = value; }
		}

		public string[] EnabledExtensionNames {
			get {
				if (_handle->EnabledExtensionCount == 0)
					return null;
				var strings = new string [_handle->EnabledExtensionCount];
				unsafe
				{
					var ptr = (void**)_handle->EnabledExtensionNames;
					for (var i = 0; i < _handle->EnabledExtensionCount; i++)
						strings [i] = Marshal.PtrToStringAnsi ((IntPtr)ptr [i]);
				}
				return strings;
			}

			set {
				if (value == null) {
					_handle->EnabledExtensionCount = 0;
					_handle->EnabledExtensionNames = IntPtr.Zero;
					return;
				}
				_handle->EnabledExtensionCount = (uint)value.Length;
				_handle->EnabledExtensionNames = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*_handle->EnabledExtensionCount));
				unsafe
				{
					var ptr = (void**)_handle->EnabledExtensionNames;
					for (var i = 0; i < _handle->EnabledExtensionCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public PhysicalDeviceFeatures EnabledFeatures {
			get { return (PhysicalDeviceFeatures)Interop.Structure.MarshalPointerToObject (_handle->EnabledFeatures, typeof (PhysicalDeviceFeatures)); }
			set { _handle->EnabledFeatures = Interop.Structure.MarshalObjectToPointer (_handle->EnabledFeatures, value); }
		}
		public Interop.DeviceCreateInfo* _handle;

		public DeviceCreateInfo ()
		{
			_handle = (Interop.DeviceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DeviceCreateInfo));
			Initialize ();
		}

		public DeviceCreateInfo (Interop.DeviceCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DeviceCreateInfo;
		}

	}

	public unsafe class InstanceCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		ApplicationInfo lApplicationInfo;
		public ApplicationInfo ApplicationInfo {
			get { return lApplicationInfo; }
			set { lApplicationInfo = value; m->ApplicationInfo = (IntPtr)value._handle; }
		}

		public uint EnabledLayerCount {
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
					var ptr = (void**)m->EnabledLayerNames;
					for (var i = 0; i < m->EnabledLayerCount; i++)
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
					var ptr = (void**)m->EnabledLayerNames;
					for (var i = 0; i < m->EnabledLayerCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}

		public uint EnabledExtensionCount {
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
					var ptr = (void**)m->EnabledExtensionNames;
					for (var i = 0; i < m->EnabledExtensionCount; i++)
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
					var ptr = (void**)m->EnabledExtensionNames;
					for (var i = 0; i < m->EnabledExtensionCount; i++)
						ptr [i] = (void*) Marshal.StringToHGlobalAnsi (value [i]);
				}
			}
		}
		public Interop.InstanceCreateInfo* m;

		public InstanceCreateInfo ()
		{
			m = (Interop.InstanceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.InstanceCreateInfo));
			Initialize ();
		}

		public InstanceCreateInfo (Interop.InstanceCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.InstanceCreateInfo;
		}

	}

	public struct QueueFamilyProperties
	{
		public QueueFlags QueueFlags;
		public uint QueueCount;
		public uint TimestampValidBits;
		public Extent3D MinImageTransferGranularity;
	}

	public unsafe class PhysicalDeviceMemoryProperties
	{
		public uint MemoryTypeCount {
			get { return m->MemoryTypeCount; }
			set { m->MemoryTypeCount = value; }
		}

		public MemoryType[] MemoryTypes {
			get {
				var arr = new MemoryType [m->MemoryTypeCount];
				for (var i = 0; i < m->MemoryTypeCount; i++)
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
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->MemoryTypes0) [i] = value [i];
					}
			}
		}

		public uint MemoryHeapCount {
			get { return m->MemoryHeapCount; }
			set { m->MemoryHeapCount = value; }
		}

		public MemoryHeap[] MemoryHeaps {
			get {
				var arr = new MemoryHeap [m->MemoryHeapCount];
				for (var i = 0; i < m->MemoryHeapCount; i++)
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
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->MemoryHeaps0) [i] = value [i];
					}
			}
		}
		public Interop.PhysicalDeviceMemoryProperties* m;

		public PhysicalDeviceMemoryProperties ()
		{
			m = (Interop.PhysicalDeviceMemoryProperties*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceMemoryProperties));
		}

		public PhysicalDeviceMemoryProperties (Interop.PhysicalDeviceMemoryProperties* ptr)
		{
			m = ptr;
		}

	}

	public unsafe class MemoryAllocateInfo
	{
		public DeviceSize AllocationSize {
			get { return m->AllocationSize; }
			set { m->AllocationSize = value; }
		}

		public uint MemoryTypeIndex {
			get { return m->MemoryTypeIndex; }
			set { m->MemoryTypeIndex = value; }
		}
		public Interop.MemoryAllocateInfo* m;

		public MemoryAllocateInfo ()
		{
			m = (Interop.MemoryAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.MemoryAllocateInfo));
			Initialize ();
		}

		public MemoryAllocateInfo (Interop.MemoryAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.MemoryAllocateInfo;
		}

	}

	public struct MemoryRequirements
	{
		public DeviceSize Size;
		public DeviceSize Alignment;
		public uint MemoryTypeBits;
	}

	public struct SparseImageFormatProperties
	{
		public ImageAspectFlags AspectMask;
		public Extent3D ImageGranularity;
		public SparseImageFormatFlags Flags;
	}

	public struct SparseImageMemoryRequirements
	{
		public SparseImageFormatProperties FormatProperties;
		public uint ImageMipTailFirstLod;
		public DeviceSize ImageMipTailSize;
		public DeviceSize ImageMipTailOffset;
		public DeviceSize ImageMipTailStride;
	}

	public struct MemoryType
	{
		public MemoryPropertyFlags PropertyFlags;
		public uint HeapIndex;
	}

	public struct MemoryHeap
	{
		public DeviceSize Size;
		public MemoryHeapFlags Flags;
	}

	public unsafe class MappedMemoryRange
	{
		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; m->Memory = (ulong)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}
		public Interop.MappedMemoryRange* m;

		public MappedMemoryRange ()
		{
			m = (Interop.MappedMemoryRange*) Interop.Structure.Allocate (typeof (Interop.MappedMemoryRange));
			Initialize ();
		}

		public MappedMemoryRange (Interop.MappedMemoryRange* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.MappedMemoryRange;
		}

	}

	public struct FormatProperties
	{
		public FormatFeatureFlags LinearTilingFeatures;
		public FormatFeatureFlags OptimalTilingFeatures;
		public FormatFeatureFlags BufferFeatures;
	}

	public struct ImageFormatProperties
	{
		public Extent3D MaxExtent;
		public uint MaxMipLevels;
		public uint MaxArrayLayers;
		public SampleCountFlags SampleCounts;
		public DeviceSize MaxResourceSize;
	}

	public unsafe class DescriptorBufferInfo
	{
		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (ulong)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Range {
			get { return m->Range; }
			set { m->Range = value; }
		}
		public Interop.DescriptorBufferInfo* m;

		public DescriptorBufferInfo ()
		{
			m = (Interop.DescriptorBufferInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorBufferInfo));
			Initialize ();
		}

		public DescriptorBufferInfo (Interop.DescriptorBufferInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class DescriptorImageInfo
	{
		Sampler lSampler;
		public Sampler Sampler {
			get { return lSampler; }
			set { lSampler = value; m->Sampler = (ulong)value.m; }
		}

		ImageView lImageView;
		public ImageView ImageView {
			get { return lImageView; }
			set { lImageView = value; m->ImageView = (ulong)value.m; }
		}

		public ImageLayout ImageLayout {
			get { return m->ImageLayout; }
			set { m->ImageLayout = value; }
		}
		public Interop.DescriptorImageInfo* m;

		public DescriptorImageInfo ()
		{
			m = (Interop.DescriptorImageInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorImageInfo));
			Initialize ();
		}

		public DescriptorImageInfo (Interop.DescriptorImageInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class WriteDescriptorSet
	{
		DescriptorSet lDstSet;
		public DescriptorSet DstSet {
			get { return lDstSet; }
			set { lDstSet = value; m->DstSet = (ulong)value.m; }
		}

		public uint DstBinding {
			get { return m->DstBinding; }
			set { m->DstBinding = value; }
		}

		public uint DstArrayElement {
			get { return m->DstArrayElement; }
			set { m->DstArrayElement = value; }
		}

		public uint DescriptorCount {
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
					var ptr = (Interop.DescriptorImageInfo*)m->ImageInfo;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.DescriptorImageInfo*)m->ImageInfo;
					for (var i = 0; i < value.Length; i++)
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
					var ptr = (Interop.DescriptorBufferInfo*)m->BufferInfo;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.DescriptorBufferInfo*)m->BufferInfo;
					for (var i = 0; i < value.Length; i++)
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
					var ptr = (ulong*)m->TexelBufferView;
					for (var i = 0; i < values.Length; i++) {
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
				m->TexelBufferView = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->TexelBufferView;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		public Interop.WriteDescriptorSet* m;

		public WriteDescriptorSet ()
		{
			m = (Interop.WriteDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.WriteDescriptorSet));
			Initialize ();
		}

		public WriteDescriptorSet (Interop.WriteDescriptorSet* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.WriteDescriptorSet;
		}

	}

	public unsafe class CopyDescriptorSet
	{
		DescriptorSet lSrcSet;
		public DescriptorSet SrcSet {
			get { return lSrcSet; }
			set { lSrcSet = value; m->SrcSet = (ulong)value.m; }
		}

		public uint SrcBinding {
			get { return m->SrcBinding; }
			set { m->SrcBinding = value; }
		}

		public uint SrcArrayElement {
			get { return m->SrcArrayElement; }
			set { m->SrcArrayElement = value; }
		}

		DescriptorSet lDstSet;
		public DescriptorSet DstSet {
			get { return lDstSet; }
			set { lDstSet = value; m->DstSet = (ulong)value.m; }
		}

		public uint DstBinding {
			get { return m->DstBinding; }
			set { m->DstBinding = value; }
		}

		public uint DstArrayElement {
			get { return m->DstArrayElement; }
			set { m->DstArrayElement = value; }
		}

		public uint DescriptorCount {
			get { return m->DescriptorCount; }
			set { m->DescriptorCount = value; }
		}
		public Interop.CopyDescriptorSet* m;

		public CopyDescriptorSet ()
		{
			m = (Interop.CopyDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.CopyDescriptorSet));
			Initialize ();
		}

		public CopyDescriptorSet (Interop.CopyDescriptorSet* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.CopyDescriptorSet;
		}

	}

	public unsafe class BufferCreateInfo
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

		public uint QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [m->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
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
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.BufferCreateInfo* m;

		public BufferCreateInfo ()
		{
			m = (Interop.BufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferCreateInfo));
			Initialize ();
		}

		public BufferCreateInfo (Interop.BufferCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.BufferCreateInfo;
		}

	}

	public unsafe class BufferViewCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (ulong)value.m; }
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
		public Interop.BufferViewCreateInfo* m;

		public BufferViewCreateInfo ()
		{
			m = (Interop.BufferViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferViewCreateInfo));
			Initialize ();
		}

		public BufferViewCreateInfo (Interop.BufferViewCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.BufferViewCreateInfo;
		}

	}

	public struct ImageSubresource
	{
		public ImageAspectFlags AspectMask;
		public uint MipLevel;
		public uint ArrayLayer;
	}

	public struct ImageSubresourceLayers
	{
		public ImageAspectFlags AspectMask;
		public uint MipLevel;
		public uint BaseArrayLayer;
		public uint LayerCount;
	}

	public struct ImageSubresourceRange
	{
		public ImageAspectFlags AspectMask;
		public uint BaseMipLevel;
		public uint LevelCount;
		public uint BaseArrayLayer;
		public uint LayerCount;
	}

	public unsafe class MemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return m->SrcAccessMask; }
			set { m->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return m->DstAccessMask; }
			set { m->DstAccessMask = value; }
		}
		public Interop.MemoryBarrier* m;

		public MemoryBarrier ()
		{
			m = (Interop.MemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.MemoryBarrier));
			Initialize ();
		}

		public MemoryBarrier (Interop.MemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.MemoryBarrier;
		}

	}

	public unsafe class BufferMemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return m->SrcAccessMask; }
			set { m->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return m->DstAccessMask; }
			set { m->DstAccessMask = value; }
		}

		public uint SrcQueueFamilyIndex {
			get { return m->SrcQueueFamilyIndex; }
			set { m->SrcQueueFamilyIndex = value; }
		}

		public uint DstQueueFamilyIndex {
			get { return m->DstQueueFamilyIndex; }
			set { m->DstQueueFamilyIndex = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (ulong)value.m; }
		}

		public DeviceSize Offset {
			get { return m->Offset; }
			set { m->Offset = value; }
		}

		public DeviceSize Size {
			get { return m->Size; }
			set { m->Size = value; }
		}
		public Interop.BufferMemoryBarrier* m;

		public BufferMemoryBarrier ()
		{
			m = (Interop.BufferMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.BufferMemoryBarrier));
			Initialize ();
		}

		public BufferMemoryBarrier (Interop.BufferMemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.BufferMemoryBarrier;
		}

	}

	public unsafe class ImageMemoryBarrier
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

		public uint SrcQueueFamilyIndex {
			get { return m->SrcQueueFamilyIndex; }
			set { m->SrcQueueFamilyIndex = value; }
		}

		public uint DstQueueFamilyIndex {
			get { return m->DstQueueFamilyIndex; }
			set { m->DstQueueFamilyIndex = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (ulong)value.m; }
		}

		public ImageSubresourceRange SubresourceRange {
			get { return m->SubresourceRange; }
			set { m->SubresourceRange = value; }
		}
		public Interop.ImageMemoryBarrier* m;

		public ImageMemoryBarrier ()
		{
			m = (Interop.ImageMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.ImageMemoryBarrier));
			Initialize ();
		}

		public ImageMemoryBarrier (Interop.ImageMemoryBarrier* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.ImageMemoryBarrier;
		}

	}

	public unsafe class ImageCreateInfo
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

		public uint MipLevels {
			get { return m->MipLevels; }
			set { m->MipLevels = value; }
		}

		public uint ArrayLayers {
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

		public uint QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [m->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
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
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public ImageLayout InitialLayout {
			get { return m->InitialLayout; }
			set { m->InitialLayout = value; }
		}
		public Interop.ImageCreateInfo* m;

		public ImageCreateInfo ()
		{
			m = (Interop.ImageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageCreateInfo));
			Initialize ();
		}

		public ImageCreateInfo (Interop.ImageCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.ImageCreateInfo;
		}

	}

	public struct SubresourceLayout
	{
		public DeviceSize Offset;
		public DeviceSize Size;
		public DeviceSize RowPitch;
		public DeviceSize ArrayPitch;
		public DeviceSize DepthPitch;
	}

	public unsafe class ImageViewCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (ulong)value.m; }
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
		public Interop.ImageViewCreateInfo* m;

		public ImageViewCreateInfo ()
		{
			m = (Interop.ImageViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageViewCreateInfo));
			Initialize ();
		}

		public ImageViewCreateInfo (Interop.ImageViewCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.ImageViewCreateInfo;
		}

	}

	public struct BufferCopy
	{
		public DeviceSize SrcOffset;
		public DeviceSize DstOffset;
		public DeviceSize Size;
	}

	public unsafe class SparseMemoryBind
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
			set { lMemory = value; m->Memory = (ulong)value.m; }
		}

		public DeviceSize MemoryOffset {
			get { return m->MemoryOffset; }
			set { m->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		public Interop.SparseMemoryBind* m;

		public SparseMemoryBind ()
		{
			m = (Interop.SparseMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseMemoryBind));
			Initialize ();
		}

		public SparseMemoryBind (Interop.SparseMemoryBind* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class SparseImageMemoryBind
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
			set { lMemory = value; m->Memory = (ulong)value.m; }
		}

		public DeviceSize MemoryOffset {
			get { return m->MemoryOffset; }
			set { m->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		public Interop.SparseImageMemoryBind* m;

		public SparseImageMemoryBind ()
		{
			m = (Interop.SparseImageMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBind));
			Initialize ();
		}

		public SparseImageMemoryBind (Interop.SparseImageMemoryBind* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class SparseBufferMemoryBindInfo
	{
		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; m->Buffer = (ulong)value.m; }
		}

		public uint BindCount {
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
					var ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		public Interop.SparseBufferMemoryBindInfo* m;

		public SparseBufferMemoryBindInfo ()
		{
			m = (Interop.SparseBufferMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseBufferMemoryBindInfo));
			Initialize ();
		}

		public SparseBufferMemoryBindInfo (Interop.SparseBufferMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class SparseImageOpaqueMemoryBindInfo
	{
		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (ulong)value.m; }
		}

		public uint BindCount {
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
					var ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseMemoryBind*)m->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		public Interop.SparseImageOpaqueMemoryBindInfo* m;

		public SparseImageOpaqueMemoryBindInfo ()
		{
			m = (Interop.SparseImageOpaqueMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageOpaqueMemoryBindInfo));
			Initialize ();
		}

		public SparseImageOpaqueMemoryBindInfo (Interop.SparseImageOpaqueMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class SparseImageMemoryBindInfo
	{
		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; m->Image = (ulong)value.m; }
		}

		public uint BindCount {
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
					var ptr = (Interop.SparseImageMemoryBind*)m->Binds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseImageMemoryBind*)m->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		public Interop.SparseImageMemoryBindInfo* m;

		public SparseImageMemoryBindInfo ()
		{
			m = (Interop.SparseImageMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBindInfo));
			Initialize ();
		}

		public SparseImageMemoryBindInfo (Interop.SparseImageMemoryBindInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class BindSparseInfo
	{
		public uint WaitSemaphoreCount {
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
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
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
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint BufferBindCount {
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
					var ptr = (Interop.SparseBufferMemoryBindInfo*)m->BufferBinds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseBufferMemoryBindInfo*)m->BufferBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public uint ImageOpaqueBindCount {
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
					var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)m->ImageOpaqueBinds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)m->ImageOpaqueBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public uint ImageBindCount {
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
					var ptr = (Interop.SparseImageMemoryBindInfo*)m->ImageBinds;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SparseImageMemoryBindInfo*)m->ImageBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public uint SignalSemaphoreCount {
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
					var ptr = (ulong*)m->SignalSemaphores;
					for (var i = 0; i < values.Length; i++) {
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
				m->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->SignalSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		public Interop.BindSparseInfo* m;

		public BindSparseInfo ()
		{
			m = (Interop.BindSparseInfo*) Interop.Structure.Allocate (typeof (Interop.BindSparseInfo));
			Initialize ();
		}

		public BindSparseInfo (Interop.BindSparseInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.BindSparseInfo;
		}

	}

	public struct ImageCopy
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffset;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffset;
		public Extent3D Extent;
	}

	public unsafe class ImageBlit
	{
		public ImageSubresourceLayers SrcSubresource {
			get { return m->SrcSubresource; }
			set { m->SrcSubresource = value; }
		}

		public Offset3D[] SrcOffsets {
			get {
				var arr = new Offset3D [2];
				for (var i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&m->SrcOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
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
				for (var i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&m->DstOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&m->DstOffsets0) [i] = value [i];
					}
			}
		}
		public Interop.ImageBlit* m;

		public ImageBlit ()
		{
			m = (Interop.ImageBlit*) Interop.Structure.Allocate (typeof (Interop.ImageBlit));
		}

		public ImageBlit (Interop.ImageBlit* ptr)
		{
			m = ptr;
		}

	}

	public struct BufferImageCopy
	{
		public DeviceSize BufferOffset;
		public uint BufferRowLength;
		public uint BufferImageHeight;
		public ImageSubresourceLayers ImageSubresource;
		public Offset3D ImageOffset;
		public Extent3D ImageExtent;
	}

	public struct ImageResolve
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffset;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffset;
		public Extent3D Extent;
	}

	public unsafe partial class ShaderModuleCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public UIntPtr CodeSize {
			get { return m->CodeSize; }
			set { m->CodeSize = value; }
		}

		public uint[] Code {
			get {
				if (m->CodeSize == UIntPtr.Zero)
					return null;
				var values = new uint [((uint)m->CodeSize >> 2)];
				unsafe
				{
					var ptr = (uint*)m->Code;
					for (var i = 0; i < values.Length; i++) 
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
				m->Code = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->Code;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.ShaderModuleCreateInfo* m;

		public ShaderModuleCreateInfo ()
		{
			m = (Interop.ShaderModuleCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ShaderModuleCreateInfo));
			Initialize ();
		}

		public ShaderModuleCreateInfo (Interop.ShaderModuleCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.ShaderModuleCreateInfo;
		}

	}

	public unsafe class DescriptorSetLayoutBinding
	{
		public uint Binding {
			get { return m->Binding; }
			set { m->Binding = value; }
		}

		public DescriptorType DescriptorType {
			get { return m->DescriptorType; }
			set { m->DescriptorType = value; }
		}

		public uint DescriptorCount {
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
					var ptr = (ulong*)m->ImmutableSamplers;
					for (var i = 0; i < values.Length; i++) {
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
				m->ImmutableSamplers = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->ImmutableSamplers;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		public Interop.DescriptorSetLayoutBinding* m;

		public DescriptorSetLayoutBinding ()
		{
			m = (Interop.DescriptorSetLayoutBinding*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutBinding));
		}

		public DescriptorSetLayoutBinding (Interop.DescriptorSetLayoutBinding* ptr)
		{
			m = ptr;
		}

	}

	public unsafe class DescriptorSetLayoutCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint BindingCount {
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
					var ptr = (Interop.DescriptorSetLayoutBinding*)m->Bindings;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.DescriptorSetLayoutBinding*)m->Bindings;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		public Interop.DescriptorSetLayoutCreateInfo* m;

		public DescriptorSetLayoutCreateInfo ()
		{
			m = (Interop.DescriptorSetLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutCreateInfo));
			Initialize ();
		}

		public DescriptorSetLayoutCreateInfo (Interop.DescriptorSetLayoutCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DescriptorSetLayoutCreateInfo;
		}

	}

	public struct DescriptorPoolSize
	{
		public DescriptorType Type;
		public uint DescriptorCount;
	}

	public unsafe class DescriptorPoolCreateInfo
	{
		public DescriptorPoolCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint MaxSets {
			get { return m->MaxSets; }
			set { m->MaxSets = value; }
		}

		public uint PoolSizeCount {
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
					var ptr = (DescriptorPoolSize*)m->PoolSizes;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (DescriptorPoolSize*)m->PoolSizes;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.DescriptorPoolCreateInfo* m;

		public DescriptorPoolCreateInfo ()
		{
			m = (Interop.DescriptorPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorPoolCreateInfo));
			Initialize ();
		}

		public DescriptorPoolCreateInfo (Interop.DescriptorPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DescriptorPoolCreateInfo;
		}

	}

	public unsafe class DescriptorSetAllocateInfo
	{
		DescriptorPool lDescriptorPool;
		public DescriptorPool DescriptorPool {
			get { return lDescriptorPool; }
			set { lDescriptorPool = value; m->DescriptorPool = (ulong)value.m; }
		}

		public uint DescriptorSetCount {
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
					var ptr = (ulong*)m->SetLayouts;
					for (var i = 0; i < values.Length; i++) {
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
				m->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->SetLayouts;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		public Interop.DescriptorSetAllocateInfo* m;

		public DescriptorSetAllocateInfo ()
		{
			m = (Interop.DescriptorSetAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetAllocateInfo));
			Initialize ();
		}

		public DescriptorSetAllocateInfo (Interop.DescriptorSetAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DescriptorSetAllocateInfo;
		}

	}

	public struct SpecializationMapEntry
	{
		public uint ConstantID;
		public uint Offset;
		public UIntPtr Size;
	}

	public unsafe class SpecializationInfo
	{
		public uint MapEntryCount {
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
					var ptr = (SpecializationMapEntry*)m->MapEntries;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (SpecializationMapEntry*)m->MapEntries;
					for (var i = 0; i < value.Length; i++)
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
		public Interop.SpecializationInfo* m;

		public SpecializationInfo ()
		{
			m = (Interop.SpecializationInfo*) Interop.Structure.Allocate (typeof (Interop.SpecializationInfo));
		}

		public SpecializationInfo (Interop.SpecializationInfo* ptr)
		{
			m = ptr;
		}

	}

	public unsafe class PipelineShaderStageCreateInfo
	{
		public uint Flags {
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
			set { lModule = value; m->Module = (ulong)value.m; }
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
		public Interop.PipelineShaderStageCreateInfo* m;

		public PipelineShaderStageCreateInfo ()
		{
			m = (Interop.PipelineShaderStageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineShaderStageCreateInfo));
			Initialize ();
		}

		public PipelineShaderStageCreateInfo (Interop.PipelineShaderStageCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineShaderStageCreateInfo;
		}

	}

	public unsafe class ComputePipelineCreateInfo
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
			set { lLayout = value; m->Layout = (ulong)value.m; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; m->BasePipelineHandle = (ulong)value.m; }
		}

		public int BasePipelineIndex {
			get { return m->BasePipelineIndex; }
			set { m->BasePipelineIndex = value; }
		}
		public Interop.ComputePipelineCreateInfo* m;

		public ComputePipelineCreateInfo ()
		{
			m = (Interop.ComputePipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ComputePipelineCreateInfo));
			Initialize ();
		}

		public ComputePipelineCreateInfo (Interop.ComputePipelineCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.ComputePipelineCreateInfo;
			lStage = new PipelineShaderStageCreateInfo (&m->Stage);
		}

	}

	public struct VertexInputBindingDescription
	{
		public uint Binding;
		public uint Stride;
		public VertexInputRate InputRate;
	}

	public struct VertexInputAttributeDescription
	{
		public uint Location;
		public uint Binding;
		public Format Format;
		public uint Offset;
	}

	public unsafe class PipelineVertexInputStateCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint VertexBindingDescriptionCount {
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
					var ptr = (VertexInputBindingDescription*)m->VertexBindingDescriptions;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (VertexInputBindingDescription*)m->VertexBindingDescriptions;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint VertexAttributeDescriptionCount {
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
					var ptr = (VertexInputAttributeDescription*)m->VertexAttributeDescriptions;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (VertexInputAttributeDescription*)m->VertexAttributeDescriptions;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineVertexInputStateCreateInfo* m;

		public PipelineVertexInputStateCreateInfo ()
		{
			m = (Interop.PipelineVertexInputStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineVertexInputStateCreateInfo));
			Initialize ();
		}

		public PipelineVertexInputStateCreateInfo (Interop.PipelineVertexInputStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineVertexInputStateCreateInfo;
		}

	}

	public unsafe class PipelineInputAssemblyStateCreateInfo
	{
		public uint Flags {
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
		public Interop.PipelineInputAssemblyStateCreateInfo* m;

		public PipelineInputAssemblyStateCreateInfo ()
		{
			m = (Interop.PipelineInputAssemblyStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineInputAssemblyStateCreateInfo));
			Initialize ();
		}

		public PipelineInputAssemblyStateCreateInfo (Interop.PipelineInputAssemblyStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
		}

	}

	public unsafe class PipelineTessellationStateCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint PatchControlPoints {
			get { return m->PatchControlPoints; }
			set { m->PatchControlPoints = value; }
		}
		public Interop.PipelineTessellationStateCreateInfo* m;

		public PipelineTessellationStateCreateInfo ()
		{
			m = (Interop.PipelineTessellationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineTessellationStateCreateInfo));
			Initialize ();
		}

		public PipelineTessellationStateCreateInfo (Interop.PipelineTessellationStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineTessellationStateCreateInfo;
		}

	}

	public unsafe class PipelineViewportStateCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint ViewportCount {
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
					var ptr = (Viewport*)m->Viewports;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (Viewport*)m->Viewports;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint ScissorCount {
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
					var ptr = (Rect2D*)m->Scissors;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (Rect2D*)m->Scissors;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineViewportStateCreateInfo* m;

		public PipelineViewportStateCreateInfo ()
		{
			m = (Interop.PipelineViewportStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineViewportStateCreateInfo));
			Initialize ();
		}

		public PipelineViewportStateCreateInfo (Interop.PipelineViewportStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineViewportStateCreateInfo;
		}

	}

	public unsafe class PipelineRasterizationStateCreateInfo
	{
		public uint Flags {
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
		public Interop.PipelineRasterizationStateCreateInfo* m;

		public PipelineRasterizationStateCreateInfo ()
		{
			m = (Interop.PipelineRasterizationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateCreateInfo));
			Initialize ();
		}

		public PipelineRasterizationStateCreateInfo (Interop.PipelineRasterizationStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineRasterizationStateCreateInfo;
		}

	}

	public unsafe class PipelineMultisampleStateCreateInfo
	{
		public uint Flags {
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

		public uint[] SampleMask {
			get {
				if (m->RasterizationSamples == 0)
					return null;
				var values = new uint [((uint)m->RasterizationSamples >> 5)];
				unsafe
				{
					var ptr = (uint*)m->SampleMask;
					for (var i = 0; i < values.Length; i++) 
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
				m->SampleMask = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->SampleMask;
					for (var i = 0; i < value.Length; i++)
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
		public Interop.PipelineMultisampleStateCreateInfo* m;

		public PipelineMultisampleStateCreateInfo ()
		{
			m = (Interop.PipelineMultisampleStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineMultisampleStateCreateInfo));
			Initialize ();
		}

		public PipelineMultisampleStateCreateInfo (Interop.PipelineMultisampleStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineMultisampleStateCreateInfo;
		}

	}

	public struct PipelineColorBlendAttachmentState
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

	public unsafe class PipelineColorBlendStateCreateInfo
	{
		public uint Flags {
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

		public uint AttachmentCount {
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
					var ptr = (PipelineColorBlendAttachmentState*)m->Attachments;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (PipelineColorBlendAttachmentState*)m->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public float[] BlendConstants {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = m->BlendConstants [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->BlendConstants [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					m->BlendConstants [i] = 0;
			}
		}
		public Interop.PipelineColorBlendStateCreateInfo* m;

		public PipelineColorBlendStateCreateInfo ()
		{
			m = (Interop.PipelineColorBlendStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineColorBlendStateCreateInfo));
			Initialize ();
		}

		public PipelineColorBlendStateCreateInfo (Interop.PipelineColorBlendStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineColorBlendStateCreateInfo;
		}

	}

	public unsafe class PipelineDynamicStateCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint DynamicStateCount {
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
					var ptr = (DynamicState*)m->DynamicStates;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (DynamicState*)m->DynamicStates;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineDynamicStateCreateInfo* m;

		public PipelineDynamicStateCreateInfo ()
		{
			m = (Interop.PipelineDynamicStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDynamicStateCreateInfo));
			Initialize ();
		}

		public PipelineDynamicStateCreateInfo (Interop.PipelineDynamicStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineDynamicStateCreateInfo;
		}

	}

	public struct StencilOpState
	{
		public StencilOp FailOp;
		public StencilOp PassOp;
		public StencilOp DepthFailOp;
		public CompareOp CompareOp;
		public uint CompareMask;
		public uint WriteMask;
		public uint Reference;
	}

	public unsafe class PipelineDepthStencilStateCreateInfo
	{
		public uint Flags {
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
		public Interop.PipelineDepthStencilStateCreateInfo* m;

		public PipelineDepthStencilStateCreateInfo ()
		{
			m = (Interop.PipelineDepthStencilStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDepthStencilStateCreateInfo));
			Initialize ();
		}

		public PipelineDepthStencilStateCreateInfo (Interop.PipelineDepthStencilStateCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineDepthStencilStateCreateInfo;
		}

	}

	public unsafe class GraphicsPipelineCreateInfo
	{
		public PipelineCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint StageCount {
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
					var ptr = (Interop.PipelineShaderStageCreateInfo*)m->Stages;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.PipelineShaderStageCreateInfo*)m->Stages;
					for (var i = 0; i < value.Length; i++)
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
			set { lLayout = value; m->Layout = (ulong)value.m; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (ulong)value.m; }
		}

		public uint Subpass {
			get { return m->Subpass; }
			set { m->Subpass = value; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; m->BasePipelineHandle = (ulong)value.m; }
		}

		public int BasePipelineIndex {
			get { return m->BasePipelineIndex; }
			set { m->BasePipelineIndex = value; }
		}
		public Interop.GraphicsPipelineCreateInfo* m;

		public GraphicsPipelineCreateInfo ()
		{
			m = (Interop.GraphicsPipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.GraphicsPipelineCreateInfo));
			Initialize ();
		}

		public GraphicsPipelineCreateInfo (Interop.GraphicsPipelineCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.GraphicsPipelineCreateInfo;
		}

	}

	public unsafe class PipelineCacheCreateInfo
	{
		public uint Flags {
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
		public Interop.PipelineCacheCreateInfo* m;

		public PipelineCacheCreateInfo ()
		{
			m = (Interop.PipelineCacheCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineCacheCreateInfo));
			Initialize ();
		}

		public PipelineCacheCreateInfo (Interop.PipelineCacheCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineCacheCreateInfo;
		}

	}

	public struct PushConstantRange
	{
		public ShaderStageFlags StageFlags;
		public uint Offset;
		public uint Size;
	}

	public unsafe class PipelineLayoutCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint SetLayoutCount {
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
					var ptr = (ulong*)m->SetLayouts;
					for (var i = 0; i < values.Length; i++) {
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
				m->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->SetLayouts;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint PushConstantRangeCount {
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
					var ptr = (PushConstantRange*)m->PushConstantRanges;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (PushConstantRange*)m->PushConstantRanges;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineLayoutCreateInfo* m;

		public PipelineLayoutCreateInfo ()
		{
			m = (Interop.PipelineLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineLayoutCreateInfo));
			Initialize ();
		}

		public PipelineLayoutCreateInfo (Interop.PipelineLayoutCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineLayoutCreateInfo;
		}

	}

	public unsafe class SamplerCreateInfo
	{
		public uint Flags {
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
		public Interop.SamplerCreateInfo* m;

		public SamplerCreateInfo ()
		{
			m = (Interop.SamplerCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SamplerCreateInfo));
			Initialize ();
		}

		public SamplerCreateInfo (Interop.SamplerCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.SamplerCreateInfo;
		}

	}

	public unsafe class CommandPoolCreateInfo
	{
		public CommandPoolCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint QueueFamilyIndex {
			get { return m->QueueFamilyIndex; }
			set { m->QueueFamilyIndex = value; }
		}
		public Interop.CommandPoolCreateInfo* m;

		public CommandPoolCreateInfo ()
		{
			m = (Interop.CommandPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandPoolCreateInfo));
			Initialize ();
		}

		public CommandPoolCreateInfo (Interop.CommandPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.CommandPoolCreateInfo;
		}

	}

	public unsafe class CommandBufferAllocateInfo
	{
		CommandPool lCommandPool;
		public CommandPool CommandPool {
			get { return lCommandPool; }
			set { lCommandPool = value; m->CommandPool = (ulong)value.m; }
		}

		public CommandBufferLevel Level {
			get { return m->Level; }
			set { m->Level = value; }
		}

		public uint CommandBufferCount {
			get { return m->CommandBufferCount; }
			set { m->CommandBufferCount = value; }
		}
		public Interop.CommandBufferAllocateInfo* m;

		public CommandBufferAllocateInfo ()
		{
			m = (Interop.CommandBufferAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferAllocateInfo));
			Initialize ();
		}

		public CommandBufferAllocateInfo (Interop.CommandBufferAllocateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.CommandBufferAllocateInfo;
		}

	}

	public unsafe class CommandBufferInheritanceInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (ulong)value.m; }
		}

		public uint Subpass {
			get { return m->Subpass; }
			set { m->Subpass = value; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; m->Framebuffer = (ulong)value.m; }
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
		public Interop.CommandBufferInheritanceInfo* m;

		public CommandBufferInheritanceInfo ()
		{
			m = (Interop.CommandBufferInheritanceInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferInheritanceInfo));
			Initialize ();
		}

		public CommandBufferInheritanceInfo (Interop.CommandBufferInheritanceInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.CommandBufferInheritanceInfo;
		}

	}

	public unsafe class CommandBufferBeginInfo
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
		public Interop.CommandBufferBeginInfo* m;

		public CommandBufferBeginInfo ()
		{
			m = (Interop.CommandBufferBeginInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferBeginInfo));
			Initialize ();
		}

		public CommandBufferBeginInfo (Interop.CommandBufferBeginInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.CommandBufferBeginInfo;
		}

	}

	public unsafe class RenderPassBeginInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (ulong)value.m; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; m->Framebuffer = (ulong)value.m; }
		}

		public Rect2D RenderArea {
			get { return m->RenderArea; }
			set { m->RenderArea = value; }
		}

		public uint ClearValueCount {
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
					var ptr = (Interop.ClearValue*)m->ClearValues;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.ClearValue*)m->ClearValues;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}
		public Interop.RenderPassBeginInfo* m;

		public RenderPassBeginInfo ()
		{
			m = (Interop.RenderPassBeginInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassBeginInfo));
			Initialize ();
		}

		public RenderPassBeginInfo (Interop.RenderPassBeginInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.RenderPassBeginInfo;
		}

	}

	public struct ClearDepthStencilValue
	{
		public float Depth;
		public uint Stencil;
	}

	public struct ClearAttachment
	{
		public ImageAspectFlags AspectMask;
		public uint ColorAttachment;
		public IntPtr ClearValue;
	}

	public struct AttachmentDescription
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

	public struct AttachmentReference
	{
		public uint Attachment;
		public ImageLayout Layout;
	}

	public unsafe class SubpassDescription
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public PipelineBindPoint PipelineBindPoint {
			get { return m->PipelineBindPoint; }
			set { m->PipelineBindPoint = value; }
		}

		public uint InputAttachmentCount {
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
					var ptr = (AttachmentReference*)m->InputAttachments;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (AttachmentReference*)m->InputAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint ColorAttachmentCount {
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
					var ptr = (AttachmentReference*)m->ColorAttachments;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (AttachmentReference*)m->ColorAttachments;
					for (var i = 0; i < value.Length; i++)
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
					var ptr = (AttachmentReference*)m->ResolveAttachments;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (AttachmentReference*)m->ResolveAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public AttachmentReference DepthStencilAttachment {
			get { return (AttachmentReference)Interop.Structure.MarshalPointerToObject (m->DepthStencilAttachment, typeof (AttachmentReference)); }
			set { m->DepthStencilAttachment = Interop.Structure.MarshalObjectToPointer (m->DepthStencilAttachment, value); }
		}

		public uint PreserveAttachmentCount {
			get { return m->PreserveAttachmentCount; }
			set { m->PreserveAttachmentCount = value; }
		}

		public uint[] PreserveAttachments {
			get {
				if (m->PreserveAttachmentCount == 0)
					return null;
				var values = new uint [m->PreserveAttachmentCount];
				unsafe
				{
					var ptr = (uint*)m->PreserveAttachments;
					for (var i = 0; i < values.Length; i++) 
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
				m->PreserveAttachments = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->PreserveAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.SubpassDescription* m;

		public SubpassDescription ()
		{
			m = (Interop.SubpassDescription*) Interop.Structure.Allocate (typeof (Interop.SubpassDescription));
		}

		public SubpassDescription (Interop.SubpassDescription* ptr)
		{
			m = ptr;
		}

	}

	public struct SubpassDependency
	{
		public uint SrcSubpass;
		public uint DstSubpass;
		public PipelineStageFlags SrcStageMask;
		public PipelineStageFlags DstStageMask;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public DependencyFlags DependencyFlags;
	}

	public unsafe class RenderPassCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public uint AttachmentCount {
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
					var ptr = (AttachmentDescription*)m->Attachments;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (AttachmentDescription*)m->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint SubpassCount {
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
					var ptr = (Interop.SubpassDescription*)m->Subpasses;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (Interop.SubpassDescription*)m->Subpasses;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i].m;
				}
			}
		}

		public uint DependencyCount {
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
					var ptr = (SubpassDependency*)m->Dependencies;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (SubpassDependency*)m->Dependencies;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.RenderPassCreateInfo* m;

		public RenderPassCreateInfo ()
		{
			m = (Interop.RenderPassCreateInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassCreateInfo));
			Initialize ();
		}

		public RenderPassCreateInfo (Interop.RenderPassCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.RenderPassCreateInfo;
		}

	}

	public unsafe class EventCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		public Interop.EventCreateInfo* m;

		public EventCreateInfo ()
		{
			m = (Interop.EventCreateInfo*) Interop.Structure.Allocate (typeof (Interop.EventCreateInfo));
			Initialize ();
		}

		public EventCreateInfo (Interop.EventCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.EventCreateInfo;
		}

	}

	public unsafe class FenceCreateInfo
	{
		public FenceCreateFlags Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		public Interop.FenceCreateInfo* m;

		public FenceCreateInfo ()
		{
			m = (Interop.FenceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FenceCreateInfo));
			Initialize ();
		}

		public FenceCreateInfo (Interop.FenceCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.FenceCreateInfo;
		}

	}

	public struct PhysicalDeviceFeatures
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

	public struct PhysicalDeviceSparseProperties
	{
		public Bool32 ResidencyStandard2DBlockShape;
		public Bool32 ResidencyStandard2DMultisampleBlockShape;
		public Bool32 ResidencyStandard3DBlockShape;
		public Bool32 ResidencyAlignedMipSize;
		public Bool32 ResidencyNonResidentStrict;
	}

	public unsafe class PhysicalDeviceLimits
	{
		public uint MaxImageDimension1D {
			get { return m->MaxImageDimension1D; }
			set { m->MaxImageDimension1D = value; }
		}

		public uint MaxImageDimension2D {
			get { return m->MaxImageDimension2D; }
			set { m->MaxImageDimension2D = value; }
		}

		public uint MaxImageDimension3D {
			get { return m->MaxImageDimension3D; }
			set { m->MaxImageDimension3D = value; }
		}

		public uint MaxImageDimensionCube {
			get { return m->MaxImageDimensionCube; }
			set { m->MaxImageDimensionCube = value; }
		}

		public uint MaxImageArrayLayers {
			get { return m->MaxImageArrayLayers; }
			set { m->MaxImageArrayLayers = value; }
		}

		public uint MaxTexelBufferElements {
			get { return m->MaxTexelBufferElements; }
			set { m->MaxTexelBufferElements = value; }
		}

		public uint MaxUniformBufferRange {
			get { return m->MaxUniformBufferRange; }
			set { m->MaxUniformBufferRange = value; }
		}

		public uint MaxStorageBufferRange {
			get { return m->MaxStorageBufferRange; }
			set { m->MaxStorageBufferRange = value; }
		}

		public uint MaxPushConstantsSize {
			get { return m->MaxPushConstantsSize; }
			set { m->MaxPushConstantsSize = value; }
		}

		public uint MaxMemoryAllocationCount {
			get { return m->MaxMemoryAllocationCount; }
			set { m->MaxMemoryAllocationCount = value; }
		}

		public uint MaxSamplerAllocationCount {
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

		public uint MaxBoundDescriptorSets {
			get { return m->MaxBoundDescriptorSets; }
			set { m->MaxBoundDescriptorSets = value; }
		}

		public uint MaxPerStageDescriptorSamplers {
			get { return m->MaxPerStageDescriptorSamplers; }
			set { m->MaxPerStageDescriptorSamplers = value; }
		}

		public uint MaxPerStageDescriptorUniformBuffers {
			get { return m->MaxPerStageDescriptorUniformBuffers; }
			set { m->MaxPerStageDescriptorUniformBuffers = value; }
		}

		public uint MaxPerStageDescriptorStorageBuffers {
			get { return m->MaxPerStageDescriptorStorageBuffers; }
			set { m->MaxPerStageDescriptorStorageBuffers = value; }
		}

		public uint MaxPerStageDescriptorSampledImages {
			get { return m->MaxPerStageDescriptorSampledImages; }
			set { m->MaxPerStageDescriptorSampledImages = value; }
		}

		public uint MaxPerStageDescriptorStorageImages {
			get { return m->MaxPerStageDescriptorStorageImages; }
			set { m->MaxPerStageDescriptorStorageImages = value; }
		}

		public uint MaxPerStageDescriptorInputAttachments {
			get { return m->MaxPerStageDescriptorInputAttachments; }
			set { m->MaxPerStageDescriptorInputAttachments = value; }
		}

		public uint MaxPerStageResources {
			get { return m->MaxPerStageResources; }
			set { m->MaxPerStageResources = value; }
		}

		public uint MaxDescriptorSetSamplers {
			get { return m->MaxDescriptorSetSamplers; }
			set { m->MaxDescriptorSetSamplers = value; }
		}

		public uint MaxDescriptorSetUniformBuffers {
			get { return m->MaxDescriptorSetUniformBuffers; }
			set { m->MaxDescriptorSetUniformBuffers = value; }
		}

		public uint MaxDescriptorSetUniformBuffersDynamic {
			get { return m->MaxDescriptorSetUniformBuffersDynamic; }
			set { m->MaxDescriptorSetUniformBuffersDynamic = value; }
		}

		public uint MaxDescriptorSetStorageBuffers {
			get { return m->MaxDescriptorSetStorageBuffers; }
			set { m->MaxDescriptorSetStorageBuffers = value; }
		}

		public uint MaxDescriptorSetStorageBuffersDynamic {
			get { return m->MaxDescriptorSetStorageBuffersDynamic; }
			set { m->MaxDescriptorSetStorageBuffersDynamic = value; }
		}

		public uint MaxDescriptorSetSampledImages {
			get { return m->MaxDescriptorSetSampledImages; }
			set { m->MaxDescriptorSetSampledImages = value; }
		}

		public uint MaxDescriptorSetStorageImages {
			get { return m->MaxDescriptorSetStorageImages; }
			set { m->MaxDescriptorSetStorageImages = value; }
		}

		public uint MaxDescriptorSetInputAttachments {
			get { return m->MaxDescriptorSetInputAttachments; }
			set { m->MaxDescriptorSetInputAttachments = value; }
		}

		public uint MaxVertexInputAttributes {
			get { return m->MaxVertexInputAttributes; }
			set { m->MaxVertexInputAttributes = value; }
		}

		public uint MaxVertexInputBindings {
			get { return m->MaxVertexInputBindings; }
			set { m->MaxVertexInputBindings = value; }
		}

		public uint MaxVertexInputAttributeOffset {
			get { return m->MaxVertexInputAttributeOffset; }
			set { m->MaxVertexInputAttributeOffset = value; }
		}

		public uint MaxVertexInputBindingStride {
			get { return m->MaxVertexInputBindingStride; }
			set { m->MaxVertexInputBindingStride = value; }
		}

		public uint MaxVertexOutputComponents {
			get { return m->MaxVertexOutputComponents; }
			set { m->MaxVertexOutputComponents = value; }
		}

		public uint MaxTessellationGenerationLevel {
			get { return m->MaxTessellationGenerationLevel; }
			set { m->MaxTessellationGenerationLevel = value; }
		}

		public uint MaxTessellationPatchSize {
			get { return m->MaxTessellationPatchSize; }
			set { m->MaxTessellationPatchSize = value; }
		}

		public uint MaxTessellationControlPerVertexInputComponents {
			get { return m->MaxTessellationControlPerVertexInputComponents; }
			set { m->MaxTessellationControlPerVertexInputComponents = value; }
		}

		public uint MaxTessellationControlPerVertexOutputComponents {
			get { return m->MaxTessellationControlPerVertexOutputComponents; }
			set { m->MaxTessellationControlPerVertexOutputComponents = value; }
		}

		public uint MaxTessellationControlPerPatchOutputComponents {
			get { return m->MaxTessellationControlPerPatchOutputComponents; }
			set { m->MaxTessellationControlPerPatchOutputComponents = value; }
		}

		public uint MaxTessellationControlTotalOutputComponents {
			get { return m->MaxTessellationControlTotalOutputComponents; }
			set { m->MaxTessellationControlTotalOutputComponents = value; }
		}

		public uint MaxTessellationEvaluationInputComponents {
			get { return m->MaxTessellationEvaluationInputComponents; }
			set { m->MaxTessellationEvaluationInputComponents = value; }
		}

		public uint MaxTessellationEvaluationOutputComponents {
			get { return m->MaxTessellationEvaluationOutputComponents; }
			set { m->MaxTessellationEvaluationOutputComponents = value; }
		}

		public uint MaxGeometryShaderInvocations {
			get { return m->MaxGeometryShaderInvocations; }
			set { m->MaxGeometryShaderInvocations = value; }
		}

		public uint MaxGeometryInputComponents {
			get { return m->MaxGeometryInputComponents; }
			set { m->MaxGeometryInputComponents = value; }
		}

		public uint MaxGeometryOutputComponents {
			get { return m->MaxGeometryOutputComponents; }
			set { m->MaxGeometryOutputComponents = value; }
		}

		public uint MaxGeometryOutputVertices {
			get { return m->MaxGeometryOutputVertices; }
			set { m->MaxGeometryOutputVertices = value; }
		}

		public uint MaxGeometryTotalOutputComponents {
			get { return m->MaxGeometryTotalOutputComponents; }
			set { m->MaxGeometryTotalOutputComponents = value; }
		}

		public uint MaxFragmentInputComponents {
			get { return m->MaxFragmentInputComponents; }
			set { m->MaxFragmentInputComponents = value; }
		}

		public uint MaxFragmentOutputAttachments {
			get { return m->MaxFragmentOutputAttachments; }
			set { m->MaxFragmentOutputAttachments = value; }
		}

		public uint MaxFragmentDualSrcAttachments {
			get { return m->MaxFragmentDualSrcAttachments; }
			set { m->MaxFragmentDualSrcAttachments = value; }
		}

		public uint MaxFragmentCombinedOutputResources {
			get { return m->MaxFragmentCombinedOutputResources; }
			set { m->MaxFragmentCombinedOutputResources = value; }
		}

		public uint MaxComputeSharedMemorySize {
			get { return m->MaxComputeSharedMemorySize; }
			set { m->MaxComputeSharedMemorySize = value; }
		}

		public uint[] MaxComputeWorkGroupCount {
			get {
				var arr = new uint [3];
				for (var i = 0; i < 3; i++)
					arr [i] = m->MaxComputeWorkGroupCount [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->MaxComputeWorkGroupCount [i] = value [i];
				for (var i = value.Length; i < 3; i++)
					m->MaxComputeWorkGroupCount [i] = 0;
			}
		}

		public uint MaxComputeWorkGroupInvocations {
			get { return m->MaxComputeWorkGroupInvocations; }
			set { m->MaxComputeWorkGroupInvocations = value; }
		}

		public uint[] MaxComputeWorkGroupSize {
			get {
				var arr = new uint [3];
				for (var i = 0; i < 3; i++)
					arr [i] = m->MaxComputeWorkGroupSize [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->MaxComputeWorkGroupSize [i] = value [i];
				for (var i = value.Length; i < 3; i++)
					m->MaxComputeWorkGroupSize [i] = 0;
			}
		}

		public uint SubPixelPrecisionBits {
			get { return m->SubPixelPrecisionBits; }
			set { m->SubPixelPrecisionBits = value; }
		}

		public uint SubTexelPrecisionBits {
			get { return m->SubTexelPrecisionBits; }
			set { m->SubTexelPrecisionBits = value; }
		}

		public uint MipmapPrecisionBits {
			get { return m->MipmapPrecisionBits; }
			set { m->MipmapPrecisionBits = value; }
		}

		public uint MaxDrawIndexedIndexValue {
			get { return m->MaxDrawIndexedIndexValue; }
			set { m->MaxDrawIndexedIndexValue = value; }
		}

		public uint MaxDrawIndirectCount {
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

		public uint MaxViewports {
			get { return m->MaxViewports; }
			set { m->MaxViewports = value; }
		}

		public uint[] MaxViewportDimensions {
			get {
				var arr = new uint [2];
				for (var i = 0; i < 2; i++)
					arr [i] = m->MaxViewportDimensions [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->MaxViewportDimensions [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					m->MaxViewportDimensions [i] = 0;
			}
		}

		public float[] ViewportBoundsRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = m->ViewportBoundsRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->ViewportBoundsRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					m->ViewportBoundsRange [i] = 0;
			}
		}

		public uint ViewportSubPixelBits {
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

		public int MinTexelOffset {
			get { return m->MinTexelOffset; }
			set { m->MinTexelOffset = value; }
		}

		public uint MaxTexelOffset {
			get { return m->MaxTexelOffset; }
			set { m->MaxTexelOffset = value; }
		}

		public int MinTexelGatherOffset {
			get { return m->MinTexelGatherOffset; }
			set { m->MinTexelGatherOffset = value; }
		}

		public uint MaxTexelGatherOffset {
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

		public uint SubPixelInterpolationOffsetBits {
			get { return m->SubPixelInterpolationOffsetBits; }
			set { m->SubPixelInterpolationOffsetBits = value; }
		}

		public uint MaxFramebufferWidth {
			get { return m->MaxFramebufferWidth; }
			set { m->MaxFramebufferWidth = value; }
		}

		public uint MaxFramebufferHeight {
			get { return m->MaxFramebufferHeight; }
			set { m->MaxFramebufferHeight = value; }
		}

		public uint MaxFramebufferLayers {
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

		public uint MaxColorAttachments {
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

		public uint MaxSampleMaskWords {
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

		public uint MaxClipDistances {
			get { return m->MaxClipDistances; }
			set { m->MaxClipDistances = value; }
		}

		public uint MaxCullDistances {
			get { return m->MaxCullDistances; }
			set { m->MaxCullDistances = value; }
		}

		public uint MaxCombinedClipAndCullDistances {
			get { return m->MaxCombinedClipAndCullDistances; }
			set { m->MaxCombinedClipAndCullDistances = value; }
		}

		public uint DiscreteQueuePriorities {
			get { return m->DiscreteQueuePriorities; }
			set { m->DiscreteQueuePriorities = value; }
		}

		public float[] PointSizeRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = m->PointSizeRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->PointSizeRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					m->PointSizeRange [i] = 0;
			}
		}

		public float[] LineWidthRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = m->LineWidthRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->LineWidthRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
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
		public Interop.PhysicalDeviceLimits* m;

		public PhysicalDeviceLimits ()
		{
			m = (Interop.PhysicalDeviceLimits*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceLimits));
		}

		public PhysicalDeviceLimits (Interop.PhysicalDeviceLimits* ptr)
		{
			m = ptr;
		}

	}

	public unsafe class SemaphoreCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}
		public Interop.SemaphoreCreateInfo* m;

		public SemaphoreCreateInfo ()
		{
			m = (Interop.SemaphoreCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SemaphoreCreateInfo));
			Initialize ();
		}

		public SemaphoreCreateInfo (Interop.SemaphoreCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.SemaphoreCreateInfo;
		}

	}

	public unsafe class QueryPoolCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public QueryType QueryType {
			get { return m->QueryType; }
			set { m->QueryType = value; }
		}

		public uint QueryCount {
			get { return m->QueryCount; }
			set { m->QueryCount = value; }
		}

		public QueryPipelineStatisticFlags PipelineStatistics {
			get { return m->PipelineStatistics; }
			set { m->PipelineStatistics = value; }
		}
		public Interop.QueryPoolCreateInfo* m;

		public QueryPoolCreateInfo ()
		{
			m = (Interop.QueryPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.QueryPoolCreateInfo));
			Initialize ();
		}

		public QueryPoolCreateInfo (Interop.QueryPoolCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.QueryPoolCreateInfo;
		}

	}

	public unsafe class FramebufferCreateInfo
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; m->RenderPass = (ulong)value.m; }
		}

		public uint AttachmentCount {
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
					var ptr = (ulong*)m->Attachments;
					for (var i = 0; i < values.Length; i++) {
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
				m->Attachments = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint Width {
			get { return m->Width; }
			set { m->Width = value; }
		}

		public uint Height {
			get { return m->Height; }
			set { m->Height = value; }
		}

		public uint Layers {
			get { return m->Layers; }
			set { m->Layers = value; }
		}
		public Interop.FramebufferCreateInfo* m;

		public FramebufferCreateInfo ()
		{
			m = (Interop.FramebufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FramebufferCreateInfo));
			Initialize ();
		}

		public FramebufferCreateInfo (Interop.FramebufferCreateInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.FramebufferCreateInfo;
		}

	}

	public struct DrawIndirectCommand
	{
		public uint VertexCount;
		public uint InstanceCount;
		public uint FirstVertex;
		public uint FirstInstance;
	}

	public struct DrawIndexedIndirectCommand
	{
		public uint IndexCount;
		public uint InstanceCount;
		public uint FirstIndex;
		public int VertexOffset;
		public uint FirstInstance;
	}

	public struct DispatchIndirectCommand
	{
		public uint X;
		public uint Y;
		public uint Z;
	}

	public unsafe class SubmitInfo
	{
		public uint WaitSemaphoreCount {
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
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
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
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
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
					var ptr = (PipelineStageFlags*)m->WaitDstStageMask;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (PipelineStageFlags*)m->WaitDstStageMask;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint CommandBufferCount {
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
					var ptr = (IntPtr*)m->CommandBuffers;
					for (var i = 0; i < values.Length; i++) {
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
					var ptr = (IntPtr*)m->CommandBuffers;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint SignalSemaphoreCount {
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
					var ptr = (ulong*)m->SignalSemaphores;
					for (var i = 0; i < values.Length; i++) {
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
				m->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->SignalSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}
		public Interop.SubmitInfo* m;

		public SubmitInfo ()
		{
			m = (Interop.SubmitInfo*) Interop.Structure.Allocate (typeof (Interop.SubmitInfo));
			Initialize ();
		}

		public SubmitInfo (Interop.SubmitInfo* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.SubmitInfo;
		}

	}

	public unsafe class DisplayPropertiesKhr
	{
		DisplayKhr lDisplay;
		public DisplayKhr Display {
			get { return lDisplay; }
			set { lDisplay = value; m->Display = (ulong)value.m; }
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
		public Interop.DisplayPropertiesKhr* m;

		public DisplayPropertiesKhr ()
		{
			m = (Interop.DisplayPropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPropertiesKhr));
			Initialize ();
		}

		public DisplayPropertiesKhr (Interop.DisplayPropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class DisplayPlanePropertiesKhr
	{
		DisplayKhr lCurrentDisplay;
		public DisplayKhr CurrentDisplay {
			get { return lCurrentDisplay; }
			set { lCurrentDisplay = value; m->CurrentDisplay = (ulong)value.m; }
		}

		public uint CurrentStackIndex {
			get { return m->CurrentStackIndex; }
			set { m->CurrentStackIndex = value; }
		}
		public Interop.DisplayPlanePropertiesKhr* m;

		public DisplayPlanePropertiesKhr ()
		{
			m = (Interop.DisplayPlanePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPlanePropertiesKhr));
			Initialize ();
		}

		public DisplayPlanePropertiesKhr (Interop.DisplayPlanePropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public struct DisplayModeParametersKhr
	{
		public Extent2D VisibleRegion;
		public uint RefreshRate;
	}

	public unsafe class DisplayModePropertiesKhr
	{
		DisplayModeKhr lDisplayMode;
		public DisplayModeKhr DisplayMode {
			get { return lDisplayMode; }
			set { lDisplayMode = value; m->DisplayMode = (ulong)value.m; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return m->Parameters; }
			set { m->Parameters = value; }
		}
		public Interop.DisplayModePropertiesKhr* m;

		public DisplayModePropertiesKhr ()
		{
			m = (Interop.DisplayModePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModePropertiesKhr));
			Initialize ();
		}

		public DisplayModePropertiesKhr (Interop.DisplayModePropertiesKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class DisplayModeCreateInfoKhr
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return m->Parameters; }
			set { m->Parameters = value; }
		}
		public Interop.DisplayModeCreateInfoKhr* m;

		public DisplayModeCreateInfoKhr ()
		{
			m = (Interop.DisplayModeCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModeCreateInfoKhr));
			Initialize ();
		}

		public DisplayModeCreateInfoKhr (Interop.DisplayModeCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DisplayModeCreateInfoKhr;
		}

	}

	public struct DisplayPlaneCapabilitiesKhr
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

	public unsafe class DisplaySurfaceCreateInfoKhr
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		DisplayModeKhr lDisplayMode;
		public DisplayModeKhr DisplayMode {
			get { return lDisplayMode; }
			set { lDisplayMode = value; m->DisplayMode = (ulong)value.m; }
		}

		public uint PlaneIndex {
			get { return m->PlaneIndex; }
			set { m->PlaneIndex = value; }
		}

		public uint PlaneStackIndex {
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
		public Interop.DisplaySurfaceCreateInfoKhr* m;

		public DisplaySurfaceCreateInfoKhr ()
		{
			m = (Interop.DisplaySurfaceCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplaySurfaceCreateInfoKhr));
			Initialize ();
		}

		public DisplaySurfaceCreateInfoKhr (Interop.DisplaySurfaceCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DisplaySurfaceCreateInfoKhr;
		}

	}

	public unsafe class DisplayPresentInfoKhr
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
		public Interop.DisplayPresentInfoKhr* m;

		public DisplayPresentInfoKhr ()
		{
			m = (Interop.DisplayPresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPresentInfoKhr));
			Initialize ();
		}

		public DisplayPresentInfoKhr (Interop.DisplayPresentInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DisplayPresentInfoKhr;
		}

	}

	public struct SurfaceCapabilitiesKhr
	{
		public uint MinImageCount;
		public uint MaxImageCount;
		public Extent2D CurrentExtent;
		public Extent2D MinImageExtent;
		public Extent2D MaxImageExtent;
		public uint MaxImageArrayLayers;
		public SurfaceTransformFlagsKhr SupportedTransforms;
		public SurfaceTransformFlagsKhr CurrentTransform;
		public CompositeAlphaFlagsKhr SupportedCompositeAlpha;
		public ImageUsageFlags SupportedUsageFlags;
	}

	public struct SurfaceFormatKhr
	{
		public Format Format;
		public ColorSpaceKhr ColorSpace;
	}

	public unsafe class SwapchainCreateInfoKhr
	{
		public uint Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		SurfaceKhr lSurface;
		public SurfaceKhr Surface {
			get { return lSurface; }
			set { lSurface = value; m->Surface = (ulong)value.m; }
		}

		public uint MinImageCount {
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

		public uint ImageArrayLayers {
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

		public uint QueueFamilyIndexCount {
			get { return m->QueueFamilyIndexCount; }
			set { m->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (m->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [m->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
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
				m->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
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
			set { lOldSwapchain = value; m->OldSwapchain = (ulong)value.m; }
		}
		public Interop.SwapchainCreateInfoKhr* m;

		public SwapchainCreateInfoKhr ()
		{
			m = (Interop.SwapchainCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.SwapchainCreateInfoKhr));
			Initialize ();
		}

		public SwapchainCreateInfoKhr (Interop.SwapchainCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.SwapchainCreateInfoKhr;
		}

	}

	public unsafe class PresentInfoKhr
	{
		public uint WaitSemaphoreCount {
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
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
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
				m->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint SwapchainCount {
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
					var ptr = (ulong*)m->Swapchains;
					for (var i = 0; i < values.Length; i++) {
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
				m->Swapchains = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)m->Swapchains;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i].m;
				}
			}
		}

		public uint[] ImageIndices {
			get {
				if (m->SwapchainCount == 0)
					return null;
				var values = new uint [m->SwapchainCount];
				unsafe
				{
					var ptr = (uint*)m->ImageIndices;
					for (var i = 0; i < values.Length; i++) 
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
				m->ImageIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)m->ImageIndices;
					for (var i = 0; i < value.Length; i++)
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
					var ptr = (Result*)m->Results;
					for (var i = 0; i < values.Length; i++) 
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
					var ptr = (Result*)m->Results;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PresentInfoKhr* m;

		public PresentInfoKhr ()
		{
			m = (Interop.PresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.PresentInfoKhr));
			Initialize ();
		}

		public PresentInfoKhr (Interop.PresentInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PresentInfoKhr;
		}

	}

	public unsafe class DebugReportCallbackCreateInfoExt
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
		public Interop.DebugReportCallbackCreateInfoExt* m;

		public DebugReportCallbackCreateInfoExt ()
		{
			m = (Interop.DebugReportCallbackCreateInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugReportCallbackCreateInfoExt));
			Initialize ();
		}

		public DebugReportCallbackCreateInfoExt (Interop.DebugReportCallbackCreateInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DebugReportCallbackCreateInfoExt;
		}

	}

	public unsafe class PipelineRasterizationStateRasterizationOrderAmd
	{
		public RasterizationOrderAmd RasterizationOrder {
			get { return m->RasterizationOrder; }
			set { m->RasterizationOrder = value; }
		}
		public Interop.PipelineRasterizationStateRasterizationOrderAmd* m;

		public PipelineRasterizationStateRasterizationOrderAmd ()
		{
			m = (Interop.PipelineRasterizationStateRasterizationOrderAmd*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateRasterizationOrderAmd));
			Initialize ();
		}

		public PipelineRasterizationStateRasterizationOrderAmd (Interop.PipelineRasterizationStateRasterizationOrderAmd* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.PipelineRasterizationStateRasterizationOrderAmd;
		}

	}

	public unsafe class DebugMarkerObjectNameInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return m->ObjectType; }
			set { m->ObjectType = value; }
		}

		public ulong Object {
			get { return m->Object; }
			set { m->Object = value; }
		}

		public string ObjectName {
			get { return Marshal.PtrToStringAnsi (m->ObjectName); }
			set { m->ObjectName = Marshal.StringToHGlobalAnsi (value); }
		}
		public Interop.DebugMarkerObjectNameInfoExt* m;

		public DebugMarkerObjectNameInfoExt ()
		{
			m = (Interop.DebugMarkerObjectNameInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectNameInfoExt));
			Initialize ();
		}

		public DebugMarkerObjectNameInfoExt (Interop.DebugMarkerObjectNameInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DebugMarkerObjectNameInfoExt;
		}

	}

	public unsafe class DebugMarkerObjectTagInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return m->ObjectType; }
			set { m->ObjectType = value; }
		}

		public ulong Object {
			get { return m->Object; }
			set { m->Object = value; }
		}

		public ulong TagName {
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
		public Interop.DebugMarkerObjectTagInfoExt* m;

		public DebugMarkerObjectTagInfoExt ()
		{
			m = (Interop.DebugMarkerObjectTagInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectTagInfoExt));
			Initialize ();
		}

		public DebugMarkerObjectTagInfoExt (Interop.DebugMarkerObjectTagInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DebugMarkerObjectTagInfoExt;
		}

	}

	public unsafe class DebugMarkerMarkerInfoExt
	{
		public string MarkerName {
			get { return Marshal.PtrToStringAnsi (m->MarkerName); }
			set { m->MarkerName = Marshal.StringToHGlobalAnsi (value); }
		}

		public float[] Color {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = m->Color [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->Color [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					m->Color [i] = 0;
			}
		}
		public Interop.DebugMarkerMarkerInfoExt* m;

		public DebugMarkerMarkerInfoExt ()
		{
			m = (Interop.DebugMarkerMarkerInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerMarkerInfoExt));
			Initialize ();
		}

		public DebugMarkerMarkerInfoExt (Interop.DebugMarkerMarkerInfoExt* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			m->SType = StructureType.DebugMarkerMarkerInfoExt;
		}

	}
}
