using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	// ReSharper disable InconsistentNaming
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
			set { lLimits = value; _handle->Limits = *value._handle; }
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		ApplicationInfo lApplicationInfo;
		public ApplicationInfo ApplicationInfo {
			get { return lApplicationInfo; }
			set { lApplicationInfo = value; _handle->ApplicationInfo = (IntPtr)value._handle; }
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
		public Interop.InstanceCreateInfo* _handle;

		public InstanceCreateInfo ()
		{
			_handle = (Interop.InstanceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.InstanceCreateInfo));
			Initialize ();
		}

		public InstanceCreateInfo (Interop.InstanceCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.InstanceCreateInfo;
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
			get { return _handle->MemoryTypeCount; }
			set { _handle->MemoryTypeCount = value; }
		}

		public MemoryType[] MemoryTypes {
			get {
				var arr = new MemoryType [_handle->MemoryTypeCount];
				for (var i = 0; i < _handle->MemoryTypeCount; i++)
					unsafe
					{
						arr [i] = (&_handle->MemoryTypes0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > _handle->MemoryTypeCount)
					throw new Exception ("array too long");
				_handle->MemoryTypeCount = (uint)value.Length;
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&_handle->MemoryTypes0) [i] = value [i];
					}
			}
		}

		public uint MemoryHeapCount {
			get { return _handle->MemoryHeapCount; }
			set { _handle->MemoryHeapCount = value; }
		}

		public MemoryHeap[] MemoryHeaps {
			get {
				var arr = new MemoryHeap [_handle->MemoryHeapCount];
				for (var i = 0; i < _handle->MemoryHeapCount; i++)
					unsafe
					{
						arr [i] = (&_handle->MemoryHeaps0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > _handle->MemoryHeapCount)
					throw new Exception ("array too long");
				_handle->MemoryHeapCount = (uint)value.Length;
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&_handle->MemoryHeaps0) [i] = value [i];
					}
			}
		}
		public Interop.PhysicalDeviceMemoryProperties* _handle;

		public PhysicalDeviceMemoryProperties ()
		{
			_handle = (Interop.PhysicalDeviceMemoryProperties*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceMemoryProperties));
		}

		public PhysicalDeviceMemoryProperties (Interop.PhysicalDeviceMemoryProperties* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class MemoryAllocateInfo
	{
		public DeviceSize AllocationSize {
			get { return _handle->AllocationSize; }
			set { _handle->AllocationSize = value; }
		}

		public uint MemoryTypeIndex {
			get { return _handle->MemoryTypeIndex; }
			set { _handle->MemoryTypeIndex = value; }
		}
		public Interop.MemoryAllocateInfo* _handle;

		public MemoryAllocateInfo ()
		{
			_handle = (Interop.MemoryAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.MemoryAllocateInfo));
			Initialize ();
		}

		public MemoryAllocateInfo (Interop.MemoryAllocateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.MemoryAllocateInfo;
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
			set { lMemory = value; _handle->Memory = (ulong)value._handle; }
		}

		public DeviceSize Offset {
			get { return _handle->Offset; }
			set { _handle->Offset = value; }
		}

		public DeviceSize Size {
			get { return _handle->Size; }
			set { _handle->Size = value; }
		}
		public Interop.MappedMemoryRange* _handle;

		public MappedMemoryRange ()
		{
			_handle = (Interop.MappedMemoryRange*) Interop.Structure.Allocate (typeof (Interop.MappedMemoryRange));
			Initialize ();
		}

		public MappedMemoryRange (Interop.MappedMemoryRange* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.MappedMemoryRange;
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
			set { lBuffer = value; _handle->Buffer = (ulong)value._handle; }
		}

		public DeviceSize Offset {
			get { return _handle->Offset; }
			set { _handle->Offset = value; }
		}

		public DeviceSize Range {
			get { return _handle->Range; }
			set { _handle->Range = value; }
		}
		public Interop.DescriptorBufferInfo* _handle;

		public DescriptorBufferInfo ()
		{
			_handle = (Interop.DescriptorBufferInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorBufferInfo));
			Initialize ();
		}

		public DescriptorBufferInfo (Interop.DescriptorBufferInfo* ptr)
		{
			_handle = ptr;
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
			set { lSampler = value; _handle->Sampler = (ulong)value._handle; }
		}

		ImageView lImageView;
		public ImageView ImageView {
			get { return lImageView; }
			set { lImageView = value; _handle->ImageView = (ulong)value._handle; }
		}

		public ImageLayout ImageLayout {
			get { return _handle->ImageLayout; }
			set { _handle->ImageLayout = value; }
		}
		public Interop.DescriptorImageInfo* _handle;

		public DescriptorImageInfo ()
		{
			_handle = (Interop.DescriptorImageInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorImageInfo));
			Initialize ();
		}

		public DescriptorImageInfo (Interop.DescriptorImageInfo* ptr)
		{
			_handle = ptr;
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
			set { lDstSet = value; _handle->DstSet = (ulong)value._handle; }
		}

		public uint DstBinding {
			get { return _handle->DstBinding; }
			set { _handle->DstBinding = value; }
		}

		public uint DstArrayElement {
			get { return _handle->DstArrayElement; }
			set { _handle->DstArrayElement = value; }
		}

		public uint DescriptorCount {
			get { return _handle->DescriptorCount; }
			set { _handle->DescriptorCount = value; }
		}

		public DescriptorType DescriptorType {
			get { return _handle->DescriptorType; }
			set { _handle->DescriptorType = value; }
		}

		public DescriptorImageInfo[] ImageInfo {
			get {
				if (_handle->DescriptorCount == 0)
					return null;
				var values = new DescriptorImageInfo [_handle->DescriptorCount];
				unsafe
				{
					var ptr = (Interop.DescriptorImageInfo*)_handle->ImageInfo;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DescriptorImageInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DescriptorCount = 0;
					_handle->ImageInfo = IntPtr.Zero;
					return;
				}
				_handle->DescriptorCount = (uint)value.Length;
				_handle->ImageInfo = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorImageInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.DescriptorImageInfo*)_handle->ImageInfo;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public DescriptorBufferInfo[] BufferInfo {
			get {
				if (_handle->DescriptorCount == 0)
					return null;
				var values = new DescriptorBufferInfo [_handle->DescriptorCount];
				unsafe
				{
					var ptr = (Interop.DescriptorBufferInfo*)_handle->BufferInfo;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DescriptorBufferInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DescriptorCount = 0;
					_handle->BufferInfo = IntPtr.Zero;
					return;
				}
				_handle->DescriptorCount = (uint)value.Length;
				_handle->BufferInfo = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorBufferInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.DescriptorBufferInfo*)_handle->BufferInfo;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public BufferView[] TexelBufferView {
			get {
				if (_handle->DescriptorCount == 0)
					return null;
				var values = new BufferView [_handle->DescriptorCount];
				unsafe
				{
					var ptr = (ulong*)_handle->TexelBufferView;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new BufferView ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DescriptorCount = 0;
					_handle->TexelBufferView = IntPtr.Zero;
					return;
				}
				_handle->DescriptorCount = (uint)value.Length;
				_handle->TexelBufferView = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->TexelBufferView;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}
		public Interop.WriteDescriptorSet* _handle;

		public WriteDescriptorSet ()
		{
			_handle = (Interop.WriteDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.WriteDescriptorSet));
			Initialize ();
		}

		public WriteDescriptorSet (Interop.WriteDescriptorSet* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.WriteDescriptorSet;
		}

	}

	public unsafe class CopyDescriptorSet
	{
		DescriptorSet lSrcSet;
		public DescriptorSet SrcSet {
			get { return lSrcSet; }
			set { lSrcSet = value; _handle->SrcSet = (ulong)value._handle; }
		}

		public uint SrcBinding {
			get { return _handle->SrcBinding; }
			set { _handle->SrcBinding = value; }
		}

		public uint SrcArrayElement {
			get { return _handle->SrcArrayElement; }
			set { _handle->SrcArrayElement = value; }
		}

		DescriptorSet lDstSet;
		public DescriptorSet DstSet {
			get { return lDstSet; }
			set { lDstSet = value; _handle->DstSet = (ulong)value._handle; }
		}

		public uint DstBinding {
			get { return _handle->DstBinding; }
			set { _handle->DstBinding = value; }
		}

		public uint DstArrayElement {
			get { return _handle->DstArrayElement; }
			set { _handle->DstArrayElement = value; }
		}

		public uint DescriptorCount {
			get { return _handle->DescriptorCount; }
			set { _handle->DescriptorCount = value; }
		}
		public Interop.CopyDescriptorSet* _handle;

		public CopyDescriptorSet ()
		{
			_handle = (Interop.CopyDescriptorSet*) Interop.Structure.Allocate (typeof (Interop.CopyDescriptorSet));
			Initialize ();
		}

		public CopyDescriptorSet (Interop.CopyDescriptorSet* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.CopyDescriptorSet;
		}

	}

	public unsafe class BufferCreateInfo
	{
		public BufferCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public DeviceSize Size {
			get { return _handle->Size; }
			set { _handle->Size = value; }
		}

		public BufferUsageFlags Usage {
			get { return _handle->Usage; }
			set { _handle->Usage = value; }
		}

		public SharingMode SharingMode {
			get { return _handle->SharingMode; }
			set { _handle->SharingMode = value; }
		}

		public uint QueueFamilyIndexCount {
			get { return _handle->QueueFamilyIndexCount; }
			set { _handle->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (_handle->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [_handle->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->QueueFamilyIndexCount = 0;
					_handle->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				_handle->QueueFamilyIndexCount = (uint)value.Length;
				_handle->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.BufferCreateInfo* _handle;

		public BufferCreateInfo ()
		{
			_handle = (Interop.BufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferCreateInfo));
			Initialize ();
		}

		public BufferCreateInfo (Interop.BufferCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.BufferCreateInfo;
		}

	}

	public unsafe class BufferViewCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; _handle->Buffer = (ulong)value._handle; }
		}

		public Format Format {
			get { return _handle->Format; }
			set { _handle->Format = value; }
		}

		public DeviceSize Offset {
			get { return _handle->Offset; }
			set { _handle->Offset = value; }
		}

		public DeviceSize Range {
			get { return _handle->Range; }
			set { _handle->Range = value; }
		}
		public Interop.BufferViewCreateInfo* _handle;

		public BufferViewCreateInfo ()
		{
			_handle = (Interop.BufferViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.BufferViewCreateInfo));
			Initialize ();
		}

		public BufferViewCreateInfo (Interop.BufferViewCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.BufferViewCreateInfo;
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
			get { return _handle->SrcAccessMask; }
			set { _handle->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return _handle->DstAccessMask; }
			set { _handle->DstAccessMask = value; }
		}
		public Interop.MemoryBarrier* _handle;

		public MemoryBarrier ()
		{
			_handle = (Interop.MemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.MemoryBarrier));
			Initialize ();
		}

		public MemoryBarrier (Interop.MemoryBarrier* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.MemoryBarrier;
		}

	}

	public unsafe class BufferMemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return _handle->SrcAccessMask; }
			set { _handle->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return _handle->DstAccessMask; }
			set { _handle->DstAccessMask = value; }
		}

		public uint SrcQueueFamilyIndex {
			get { return _handle->SrcQueueFamilyIndex; }
			set { _handle->SrcQueueFamilyIndex = value; }
		}

		public uint DstQueueFamilyIndex {
			get { return _handle->DstQueueFamilyIndex; }
			set { _handle->DstQueueFamilyIndex = value; }
		}

		Buffer lBuffer;
		public Buffer Buffer {
			get { return lBuffer; }
			set { lBuffer = value; _handle->Buffer = (ulong)value._handle; }
		}

		public DeviceSize Offset {
			get { return _handle->Offset; }
			set { _handle->Offset = value; }
		}

		public DeviceSize Size {
			get { return _handle->Size; }
			set { _handle->Size = value; }
		}
		public Interop.BufferMemoryBarrier* _handle;

		public BufferMemoryBarrier ()
		{
			_handle = (Interop.BufferMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.BufferMemoryBarrier));
			Initialize ();
		}

		public BufferMemoryBarrier (Interop.BufferMemoryBarrier* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.BufferMemoryBarrier;
		}

	}

	public unsafe class ImageMemoryBarrier
	{
		public AccessFlags SrcAccessMask {
			get { return _handle->SrcAccessMask; }
			set { _handle->SrcAccessMask = value; }
		}

		public AccessFlags DstAccessMask {
			get { return _handle->DstAccessMask; }
			set { _handle->DstAccessMask = value; }
		}

		public ImageLayout OldLayout {
			get { return _handle->OldLayout; }
			set { _handle->OldLayout = value; }
		}

		public ImageLayout NewLayout {
			get { return _handle->NewLayout; }
			set { _handle->NewLayout = value; }
		}

		public uint SrcQueueFamilyIndex {
			get { return _handle->SrcQueueFamilyIndex; }
			set { _handle->SrcQueueFamilyIndex = value; }
		}

		public uint DstQueueFamilyIndex {
			get { return _handle->DstQueueFamilyIndex; }
			set { _handle->DstQueueFamilyIndex = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; _handle->Image = (ulong)value._handle; }
		}

		public ImageSubresourceRange SubresourceRange {
			get { return _handle->SubresourceRange; }
			set { _handle->SubresourceRange = value; }
		}
		public Interop.ImageMemoryBarrier* _handle;

		public ImageMemoryBarrier ()
		{
			_handle = (Interop.ImageMemoryBarrier*) Interop.Structure.Allocate (typeof (Interop.ImageMemoryBarrier));
			Initialize ();
		}

		public ImageMemoryBarrier (Interop.ImageMemoryBarrier* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ImageMemoryBarrier;
		}

	}

	public unsafe class ImageCreateInfo
	{
		public ImageCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public ImageType ImageType {
			get { return _handle->ImageType; }
			set { _handle->ImageType = value; }
		}

		public Format Format {
			get { return _handle->Format; }
			set { _handle->Format = value; }
		}

		public Extent3D Extent {
			get { return _handle->Extent; }
			set { _handle->Extent = value; }
		}

		public uint MipLevels {
			get { return _handle->MipLevels; }
			set { _handle->MipLevels = value; }
		}

		public uint ArrayLayers {
			get { return _handle->ArrayLayers; }
			set { _handle->ArrayLayers = value; }
		}

		public SampleCountFlags Samples {
			get { return _handle->Samples; }
			set { _handle->Samples = value; }
		}

		public ImageTiling Tiling {
			get { return _handle->Tiling; }
			set { _handle->Tiling = value; }
		}

		public ImageUsageFlags Usage {
			get { return _handle->Usage; }
			set { _handle->Usage = value; }
		}

		public SharingMode SharingMode {
			get { return _handle->SharingMode; }
			set { _handle->SharingMode = value; }
		}

		public uint QueueFamilyIndexCount {
			get { return _handle->QueueFamilyIndexCount; }
			set { _handle->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (_handle->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [_handle->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->QueueFamilyIndexCount = 0;
					_handle->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				_handle->QueueFamilyIndexCount = (uint)value.Length;
				_handle->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public ImageLayout InitialLayout {
			get { return _handle->InitialLayout; }
			set { _handle->InitialLayout = value; }
		}
		public Interop.ImageCreateInfo* _handle;

		public ImageCreateInfo ()
		{
			_handle = (Interop.ImageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageCreateInfo));
			Initialize ();
		}

		public ImageCreateInfo (Interop.ImageCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ImageCreateInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		Image lImage;
		public Image Image {
			get { return lImage; }
			set { lImage = value; _handle->Image = (ulong)value._handle; }
		}

		public ImageViewType ViewType {
			get { return _handle->ViewType; }
			set { _handle->ViewType = value; }
		}

		public Format Format {
			get { return _handle->Format; }
			set { _handle->Format = value; }
		}

		public ComponentMapping Components {
			get { return _handle->Components; }
			set { _handle->Components = value; }
		}

		public ImageSubresourceRange SubresourceRange {
			get { return _handle->SubresourceRange; }
			set { _handle->SubresourceRange = value; }
		}
		public Interop.ImageViewCreateInfo* _handle;

		public ImageViewCreateInfo ()
		{
			_handle = (Interop.ImageViewCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ImageViewCreateInfo));
			Initialize ();
		}

		public ImageViewCreateInfo (Interop.ImageViewCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ImageViewCreateInfo;
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
			get { return _handle->ResourceOffset; }
			set { _handle->ResourceOffset = value; }
		}

		public DeviceSize Size {
			get { return _handle->Size; }
			set { _handle->Size = value; }
		}

		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; _handle->Memory = (ulong)value._handle; }
		}

		public DeviceSize MemoryOffset {
			get { return _handle->MemoryOffset; }
			set { _handle->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}
		public Interop.SparseMemoryBind* _handle;

		public SparseMemoryBind ()
		{
			_handle = (Interop.SparseMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseMemoryBind));
			Initialize ();
		}

		public SparseMemoryBind (Interop.SparseMemoryBind* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class SparseImageMemoryBind
	{
		public ImageSubresource Subresource {
			get { return _handle->Subresource; }
			set { _handle->Subresource = value; }
		}

		public Offset3D Offset {
			get { return _handle->Offset; }
			set { _handle->Offset = value; }
		}

		public Extent3D Extent {
			get { return _handle->Extent; }
			set { _handle->Extent = value; }
		}

		DeviceMemory lMemory;
		public DeviceMemory Memory {
			get { return lMemory; }
			set { lMemory = value; _handle->Memory = (ulong)value._handle; }
		}

		public DeviceSize MemoryOffset {
			get { return _handle->MemoryOffset; }
			set { _handle->MemoryOffset = value; }
		}

		public SparseMemoryBindFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}
		public Interop.SparseImageMemoryBind* _handle;

		public SparseImageMemoryBind ()
		{
			_handle = (Interop.SparseImageMemoryBind*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBind));
			Initialize ();
		}

		public SparseImageMemoryBind (Interop.SparseImageMemoryBind* ptr)
		{
			_handle = ptr;
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
			set { lBuffer = value; _handle->Buffer = (ulong)value._handle; }
		}

		public uint BindCount {
			get { return _handle->BindCount; }
			set { _handle->BindCount = value; }
		}

		public SparseMemoryBind[] Binds {
			get {
				if (_handle->BindCount == 0)
					return null;
				var values = new SparseMemoryBind [_handle->BindCount];
				unsafe
				{
					var ptr = (Interop.SparseMemoryBind*)_handle->Binds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseMemoryBind ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->BindCount = 0;
					_handle->Binds = IntPtr.Zero;
					return;
				}
				_handle->BindCount = (uint)value.Length;
				_handle->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseMemoryBind)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseMemoryBind*)_handle->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}
		public Interop.SparseBufferMemoryBindInfo* _handle;

		public SparseBufferMemoryBindInfo ()
		{
			_handle = (Interop.SparseBufferMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseBufferMemoryBindInfo));
			Initialize ();
		}

		public SparseBufferMemoryBindInfo (Interop.SparseBufferMemoryBindInfo* ptr)
		{
			_handle = ptr;
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
			set { lImage = value; _handle->Image = (ulong)value._handle; }
		}

		public uint BindCount {
			get { return _handle->BindCount; }
			set { _handle->BindCount = value; }
		}

		public SparseMemoryBind[] Binds {
			get {
				if (_handle->BindCount == 0)
					return null;
				var values = new SparseMemoryBind [_handle->BindCount];
				unsafe
				{
					var ptr = (Interop.SparseMemoryBind*)_handle->Binds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseMemoryBind ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->BindCount = 0;
					_handle->Binds = IntPtr.Zero;
					return;
				}
				_handle->BindCount = (uint)value.Length;
				_handle->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseMemoryBind)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseMemoryBind*)_handle->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}
		public Interop.SparseImageOpaqueMemoryBindInfo* _handle;

		public SparseImageOpaqueMemoryBindInfo ()
		{
			_handle = (Interop.SparseImageOpaqueMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageOpaqueMemoryBindInfo));
			Initialize ();
		}

		public SparseImageOpaqueMemoryBindInfo (Interop.SparseImageOpaqueMemoryBindInfo* ptr)
		{
			_handle = ptr;
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
			set { lImage = value; _handle->Image = (ulong)value._handle; }
		}

		public uint BindCount {
			get { return _handle->BindCount; }
			set { _handle->BindCount = value; }
		}

		public SparseImageMemoryBind[] Binds {
			get {
				if (_handle->BindCount == 0)
					return null;
				var values = new SparseImageMemoryBind [_handle->BindCount];
				unsafe
				{
					var ptr = (Interop.SparseImageMemoryBind*)_handle->Binds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseImageMemoryBind ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->BindCount = 0;
					_handle->Binds = IntPtr.Zero;
					return;
				}
				_handle->BindCount = (uint)value.Length;
				_handle->Binds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageMemoryBind)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseImageMemoryBind*)_handle->Binds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}
		public Interop.SparseImageMemoryBindInfo* _handle;

		public SparseImageMemoryBindInfo ()
		{
			_handle = (Interop.SparseImageMemoryBindInfo*) Interop.Structure.Allocate (typeof (Interop.SparseImageMemoryBindInfo));
			Initialize ();
		}

		public SparseImageMemoryBindInfo (Interop.SparseImageMemoryBindInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class BindSparseInfo
	{
		public uint WaitSemaphoreCount {
			get { return _handle->WaitSemaphoreCount; }
			set { _handle->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (_handle->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [_handle->WaitSemaphoreCount];
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->WaitSemaphoreCount = 0;
					_handle->WaitSemaphores = IntPtr.Zero;
					return;
				}
				_handle->WaitSemaphoreCount = (uint)value.Length;
				_handle->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint BufferBindCount {
			get { return _handle->BufferBindCount; }
			set { _handle->BufferBindCount = value; }
		}

		public SparseBufferMemoryBindInfo[] BufferBinds {
			get {
				if (_handle->BufferBindCount == 0)
					return null;
				var values = new SparseBufferMemoryBindInfo [_handle->BufferBindCount];
				unsafe
				{
					var ptr = (Interop.SparseBufferMemoryBindInfo*)_handle->BufferBinds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseBufferMemoryBindInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->BufferBindCount = 0;
					_handle->BufferBinds = IntPtr.Zero;
					return;
				}
				_handle->BufferBindCount = (uint)value.Length;
				_handle->BufferBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseBufferMemoryBindInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseBufferMemoryBindInfo*)_handle->BufferBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public uint ImageOpaqueBindCount {
			get { return _handle->ImageOpaqueBindCount; }
			set { _handle->ImageOpaqueBindCount = value; }
		}

		public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds {
			get {
				if (_handle->ImageOpaqueBindCount == 0)
					return null;
				var values = new SparseImageOpaqueMemoryBindInfo [_handle->ImageOpaqueBindCount];
				unsafe
				{
					var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)_handle->ImageOpaqueBinds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseImageOpaqueMemoryBindInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ImageOpaqueBindCount = 0;
					_handle->ImageOpaqueBinds = IntPtr.Zero;
					return;
				}
				_handle->ImageOpaqueBindCount = (uint)value.Length;
				_handle->ImageOpaqueBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageOpaqueMemoryBindInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)_handle->ImageOpaqueBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public uint ImageBindCount {
			get { return _handle->ImageBindCount; }
			set { _handle->ImageBindCount = value; }
		}

		public SparseImageMemoryBindInfo[] ImageBinds {
			get {
				if (_handle->ImageBindCount == 0)
					return null;
				var values = new SparseImageMemoryBindInfo [_handle->ImageBindCount];
				unsafe
				{
					var ptr = (Interop.SparseImageMemoryBindInfo*)_handle->ImageBinds;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SparseImageMemoryBindInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ImageBindCount = 0;
					_handle->ImageBinds = IntPtr.Zero;
					return;
				}
				_handle->ImageBindCount = (uint)value.Length;
				_handle->ImageBinds = Marshal.AllocHGlobal ((int)(sizeof(Interop.SparseImageMemoryBindInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.SparseImageMemoryBindInfo*)_handle->ImageBinds;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public uint SignalSemaphoreCount {
			get { return _handle->SignalSemaphoreCount; }
			set { _handle->SignalSemaphoreCount = value; }
		}

		public Semaphore[] SignalSemaphores {
			get {
				if (_handle->SignalSemaphoreCount == 0)
					return null;
				var values = new Semaphore [_handle->SignalSemaphoreCount];
				unsafe
				{
					var ptr = (ulong*)_handle->SignalSemaphores;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SignalSemaphoreCount = 0;
					_handle->SignalSemaphores = IntPtr.Zero;
					return;
				}
				_handle->SignalSemaphoreCount = (uint)value.Length;
				_handle->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->SignalSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}
		public Interop.BindSparseInfo* _handle;

		public BindSparseInfo ()
		{
			_handle = (Interop.BindSparseInfo*) Interop.Structure.Allocate (typeof (Interop.BindSparseInfo));
			Initialize ();
		}

		public BindSparseInfo (Interop.BindSparseInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.BindSparseInfo;
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
			get { return _handle->SrcSubresource; }
			set { _handle->SrcSubresource = value; }
		}

		public Offset3D[] SrcOffsets {
			get {
				var arr = new Offset3D [2];
				for (var i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&_handle->SrcOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&_handle->SrcOffsets0) [i] = value [i];
					}
			}
		}

		public ImageSubresourceLayers DstSubresource {
			get { return _handle->DstSubresource; }
			set { _handle->DstSubresource = value; }
		}

		public Offset3D[] DstOffsets {
			get {
				var arr = new Offset3D [2];
				for (var i = 0; i < 2; i++)
					unsafe
					{
						arr [i] = (&_handle->DstOffsets0) [i];
					}
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					unsafe
					{
						(&_handle->DstOffsets0) [i] = value [i];
					}
			}
		}
		public Interop.ImageBlit* _handle;

		public ImageBlit ()
		{
			_handle = (Interop.ImageBlit*) Interop.Structure.Allocate (typeof (Interop.ImageBlit));
		}

		public ImageBlit (Interop.ImageBlit* ptr)
		{
			_handle = ptr;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public UIntPtr CodeSize {
			get { return _handle->CodeSize; }
			set { _handle->CodeSize = value; }
		}

		public uint[] Code {
			get {
				if (_handle->CodeSize == UIntPtr.Zero)
					return null;
				var values = new uint [((uint)_handle->CodeSize >> 2)];
				unsafe
				{
					var ptr = (uint*)_handle->Code;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->CodeSize = UIntPtr.Zero;
					_handle->Code = IntPtr.Zero;
					return;
				}
				_handle->CodeSize = (UIntPtr)(value.Length << 2);
				_handle->Code = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->Code;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.ShaderModuleCreateInfo* _handle;

		public ShaderModuleCreateInfo ()
		{
			_handle = (Interop.ShaderModuleCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ShaderModuleCreateInfo));
			Initialize ();
		}

		public ShaderModuleCreateInfo (Interop.ShaderModuleCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ShaderModuleCreateInfo;
		}

	}

	public unsafe class DescriptorSetLayoutBinding
	{
		public uint Binding {
			get { return _handle->Binding; }
			set { _handle->Binding = value; }
		}

		public DescriptorType DescriptorType {
			get { return _handle->DescriptorType; }
			set { _handle->DescriptorType = value; }
		}

		public uint DescriptorCount {
			get { return _handle->DescriptorCount; }
			set { _handle->DescriptorCount = value; }
		}

		public ShaderStageFlags StageFlags {
			get { return _handle->StageFlags; }
			set { _handle->StageFlags = value; }
		}

		public Sampler[] ImmutableSamplers {
			get {
				if (_handle->DescriptorCount == 0)
					return null;
				var values = new Sampler [_handle->DescriptorCount];
				unsafe
				{
					var ptr = (ulong*)_handle->ImmutableSamplers;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Sampler ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DescriptorCount = 0;
					_handle->ImmutableSamplers = IntPtr.Zero;
					return;
				}
				_handle->DescriptorCount = (uint)value.Length;
				_handle->ImmutableSamplers = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->ImmutableSamplers;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}
		public Interop.DescriptorSetLayoutBinding* _handle;

		public DescriptorSetLayoutBinding ()
		{
			_handle = (Interop.DescriptorSetLayoutBinding*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutBinding));
		}

		public DescriptorSetLayoutBinding (Interop.DescriptorSetLayoutBinding* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class DescriptorSetLayoutCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint BindingCount {
			get { return _handle->BindingCount; }
			set { _handle->BindingCount = value; }
		}

		public DescriptorSetLayoutBinding[] Bindings {
			get {
				if (_handle->BindingCount == 0)
					return null;
				var values = new DescriptorSetLayoutBinding [_handle->BindingCount];
				unsafe
				{
					var ptr = (Interop.DescriptorSetLayoutBinding*)_handle->Bindings;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayoutBinding ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->BindingCount = 0;
					_handle->Bindings = IntPtr.Zero;
					return;
				}
				_handle->BindingCount = (uint)value.Length;
				_handle->Bindings = Marshal.AllocHGlobal ((int)(sizeof(Interop.DescriptorSetLayoutBinding)*value.Length));
				unsafe
				{
					var ptr = (Interop.DescriptorSetLayoutBinding*)_handle->Bindings;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}
		public Interop.DescriptorSetLayoutCreateInfo* _handle;

		public DescriptorSetLayoutCreateInfo ()
		{
			_handle = (Interop.DescriptorSetLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetLayoutCreateInfo));
			Initialize ();
		}

		public DescriptorSetLayoutCreateInfo (Interop.DescriptorSetLayoutCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DescriptorSetLayoutCreateInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint MaxSets {
			get { return _handle->MaxSets; }
			set { _handle->MaxSets = value; }
		}

		public uint PoolSizeCount {
			get { return _handle->PoolSizeCount; }
			set { _handle->PoolSizeCount = value; }
		}

		public DescriptorPoolSize[] PoolSizes {
			get {
				if (_handle->PoolSizeCount == 0)
					return null;
				var values = new DescriptorPoolSize [_handle->PoolSizeCount];
				unsafe
				{
					var ptr = (DescriptorPoolSize*)_handle->PoolSizes;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->PoolSizeCount = 0;
					_handle->PoolSizes = IntPtr.Zero;
					return;
				}
				_handle->PoolSizeCount = (uint)value.Length;
				_handle->PoolSizes = Marshal.AllocHGlobal ((int)(sizeof(DescriptorPoolSize)*value.Length));
				unsafe
				{
					var ptr = (DescriptorPoolSize*)_handle->PoolSizes;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.DescriptorPoolCreateInfo* _handle;

		public DescriptorPoolCreateInfo ()
		{
			_handle = (Interop.DescriptorPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorPoolCreateInfo));
			Initialize ();
		}

		public DescriptorPoolCreateInfo (Interop.DescriptorPoolCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DescriptorPoolCreateInfo;
		}

	}

	public unsafe class DescriptorSetAllocateInfo
	{
		DescriptorPool lDescriptorPool;
		public DescriptorPool DescriptorPool {
			get { return lDescriptorPool; }
			set { lDescriptorPool = value; _handle->DescriptorPool = (ulong)value._handle; }
		}

		public uint DescriptorSetCount {
			get { return _handle->DescriptorSetCount; }
			set { _handle->DescriptorSetCount = value; }
		}

		public DescriptorSetLayout[] SetLayouts {
			get {
				if (_handle->DescriptorSetCount == 0)
					return null;
				var values = new DescriptorSetLayout [_handle->DescriptorSetCount];
				unsafe
				{
					var ptr = (ulong*)_handle->SetLayouts;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayout ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DescriptorSetCount = 0;
					_handle->SetLayouts = IntPtr.Zero;
					return;
				}
				_handle->DescriptorSetCount = (uint)value.Length;
				_handle->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->SetLayouts;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}
		public Interop.DescriptorSetAllocateInfo* _handle;

		public DescriptorSetAllocateInfo ()
		{
			_handle = (Interop.DescriptorSetAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.DescriptorSetAllocateInfo));
			Initialize ();
		}

		public DescriptorSetAllocateInfo (Interop.DescriptorSetAllocateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DescriptorSetAllocateInfo;
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
			get { return _handle->MapEntryCount; }
			set { _handle->MapEntryCount = value; }
		}

		public SpecializationMapEntry[] MapEntries {
			get {
				if (_handle->MapEntryCount == 0)
					return null;
				var values = new SpecializationMapEntry [_handle->MapEntryCount];
				unsafe
				{
					var ptr = (SpecializationMapEntry*)_handle->MapEntries;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->MapEntryCount = 0;
					_handle->MapEntries = IntPtr.Zero;
					return;
				}
				_handle->MapEntryCount = (uint)value.Length;
				_handle->MapEntries = Marshal.AllocHGlobal ((int)(sizeof(SpecializationMapEntry)*value.Length));
				unsafe
				{
					var ptr = (SpecializationMapEntry*)_handle->MapEntries;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public UIntPtr DataSize {
			get { return _handle->DataSize; }
			set { _handle->DataSize = value; }
		}

		public IntPtr Data {
			get { return _handle->Data; }
			set { _handle->Data = value; }
		}
		public Interop.SpecializationInfo* _handle;

		public SpecializationInfo ()
		{
			_handle = (Interop.SpecializationInfo*) Interop.Structure.Allocate (typeof (Interop.SpecializationInfo));
		}

		public SpecializationInfo (Interop.SpecializationInfo* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class PipelineShaderStageCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public ShaderStageFlags Stage {
			get { return _handle->Stage; }
			set { _handle->Stage = value; }
		}

		ShaderModule lModule;
		public ShaderModule Module {
			get { return lModule; }
			set { lModule = value; _handle->Module = (ulong)value._handle; }
		}

		public string Name {
			get { return Marshal.PtrToStringAnsi (_handle->Name); }
			set { _handle->Name = Marshal.StringToHGlobalAnsi (value); }
		}

		SpecializationInfo lSpecializationInfo;
		public SpecializationInfo SpecializationInfo {
			get { return lSpecializationInfo; }
			set { lSpecializationInfo = value; _handle->SpecializationInfo = (IntPtr)value._handle; }
		}
		public Interop.PipelineShaderStageCreateInfo* _handle;

		public PipelineShaderStageCreateInfo ()
		{
			_handle = (Interop.PipelineShaderStageCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineShaderStageCreateInfo));
			Initialize ();
		}

		public PipelineShaderStageCreateInfo (Interop.PipelineShaderStageCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineShaderStageCreateInfo;
		}

	}

	public unsafe class ComputePipelineCreateInfo
	{
		public PipelineCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		PipelineShaderStageCreateInfo lStage;
		public PipelineShaderStageCreateInfo Stage {
			get { return lStage; }
			set { lStage = value; _handle->Stage = *value._handle; }
		}

		PipelineLayout lLayout;
		public PipelineLayout Layout {
			get { return lLayout; }
			set { lLayout = value; _handle->Layout = (ulong)value._handle; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; _handle->BasePipelineHandle = (ulong)value._handle; }
		}

		public int BasePipelineIndex {
			get { return _handle->BasePipelineIndex; }
			set { _handle->BasePipelineIndex = value; }
		}
		public Interop.ComputePipelineCreateInfo* _handle;

		public ComputePipelineCreateInfo ()
		{
			_handle = (Interop.ComputePipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.ComputePipelineCreateInfo));
			Initialize ();
		}

		public ComputePipelineCreateInfo (Interop.ComputePipelineCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.ComputePipelineCreateInfo;
			lStage = new PipelineShaderStageCreateInfo (&_handle->Stage);
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint VertexBindingDescriptionCount {
			get { return _handle->VertexBindingDescriptionCount; }
			set { _handle->VertexBindingDescriptionCount = value; }
		}

		public VertexInputBindingDescription[] VertexBindingDescriptions {
			get {
				if (_handle->VertexBindingDescriptionCount == 0)
					return null;
				var values = new VertexInputBindingDescription [_handle->VertexBindingDescriptionCount];
				unsafe
				{
					var ptr = (VertexInputBindingDescription*)_handle->VertexBindingDescriptions;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->VertexBindingDescriptionCount = 0;
					_handle->VertexBindingDescriptions = IntPtr.Zero;
					return;
				}
				_handle->VertexBindingDescriptionCount = (uint)value.Length;
				_handle->VertexBindingDescriptions = Marshal.AllocHGlobal ((int)(sizeof(VertexInputBindingDescription)*value.Length));
				unsafe
				{
					var ptr = (VertexInputBindingDescription*)_handle->VertexBindingDescriptions;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint VertexAttributeDescriptionCount {
			get { return _handle->VertexAttributeDescriptionCount; }
			set { _handle->VertexAttributeDescriptionCount = value; }
		}

		public VertexInputAttributeDescription[] VertexAttributeDescriptions {
			get {
				if (_handle->VertexAttributeDescriptionCount == 0)
					return null;
				var values = new VertexInputAttributeDescription [_handle->VertexAttributeDescriptionCount];
				unsafe
				{
					var ptr = (VertexInputAttributeDescription*)_handle->VertexAttributeDescriptions;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->VertexAttributeDescriptionCount = 0;
					_handle->VertexAttributeDescriptions = IntPtr.Zero;
					return;
				}
				_handle->VertexAttributeDescriptionCount = (uint)value.Length;
				_handle->VertexAttributeDescriptions = Marshal.AllocHGlobal ((int)(sizeof(VertexInputAttributeDescription)*value.Length));
				unsafe
				{
					var ptr = (VertexInputAttributeDescription*)_handle->VertexAttributeDescriptions;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineVertexInputStateCreateInfo* _handle;

		public PipelineVertexInputStateCreateInfo ()
		{
			_handle = (Interop.PipelineVertexInputStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineVertexInputStateCreateInfo));
			Initialize ();
		}

		public PipelineVertexInputStateCreateInfo (Interop.PipelineVertexInputStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineVertexInputStateCreateInfo;
		}

	}

	public unsafe class PipelineInputAssemblyStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public PrimitiveTopology Topology {
			get { return _handle->Topology; }
			set { _handle->Topology = value; }
		}

		public bool PrimitiveRestartEnable {
			get { return _handle->PrimitiveRestartEnable; }
			set { _handle->PrimitiveRestartEnable = value; }
		}
		public Interop.PipelineInputAssemblyStateCreateInfo* _handle;

		public PipelineInputAssemblyStateCreateInfo ()
		{
			_handle = (Interop.PipelineInputAssemblyStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineInputAssemblyStateCreateInfo));
			Initialize ();
		}

		public PipelineInputAssemblyStateCreateInfo (Interop.PipelineInputAssemblyStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
		}

	}

	public unsafe class PipelineTessellationStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint PatchControlPoints {
			get { return _handle->PatchControlPoints; }
			set { _handle->PatchControlPoints = value; }
		}
		public Interop.PipelineTessellationStateCreateInfo* _handle;

		public PipelineTessellationStateCreateInfo ()
		{
			_handle = (Interop.PipelineTessellationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineTessellationStateCreateInfo));
			Initialize ();
		}

		public PipelineTessellationStateCreateInfo (Interop.PipelineTessellationStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineTessellationStateCreateInfo;
		}

	}

	public unsafe class PipelineViewportStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint ViewportCount {
			get { return _handle->ViewportCount; }
			set { _handle->ViewportCount = value; }
		}

		public Viewport[] Viewports {
			get {
				if (_handle->ViewportCount == 0)
					return null;
				var values = new Viewport [_handle->ViewportCount];
				unsafe
				{
					var ptr = (Viewport*)_handle->Viewports;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ViewportCount = 0;
					_handle->Viewports = IntPtr.Zero;
					return;
				}
				_handle->ViewportCount = (uint)value.Length;
				_handle->Viewports = Marshal.AllocHGlobal ((int)(sizeof(Viewport)*value.Length));
				unsafe
				{
					var ptr = (Viewport*)_handle->Viewports;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint ScissorCount {
			get { return _handle->ScissorCount; }
			set { _handle->ScissorCount = value; }
		}

		public Rect2D[] Scissors {
			get {
				if (_handle->ScissorCount == 0)
					return null;
				var values = new Rect2D [_handle->ScissorCount];
				unsafe
				{
					var ptr = (Rect2D*)_handle->Scissors;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ScissorCount = 0;
					_handle->Scissors = IntPtr.Zero;
					return;
				}
				_handle->ScissorCount = (uint)value.Length;
				_handle->Scissors = Marshal.AllocHGlobal ((int)(sizeof(Rect2D)*value.Length));
				unsafe
				{
					var ptr = (Rect2D*)_handle->Scissors;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineViewportStateCreateInfo* _handle;

		public PipelineViewportStateCreateInfo ()
		{
			_handle = (Interop.PipelineViewportStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineViewportStateCreateInfo));
			Initialize ();
		}

		public PipelineViewportStateCreateInfo (Interop.PipelineViewportStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineViewportStateCreateInfo;
		}

	}

	public unsafe class PipelineRasterizationStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public bool DepthClampEnable {
			get { return _handle->DepthClampEnable; }
			set { _handle->DepthClampEnable = value; }
		}

		public bool RasterizerDiscardEnable {
			get { return _handle->RasterizerDiscardEnable; }
			set { _handle->RasterizerDiscardEnable = value; }
		}

		public PolygonMode PolygonMode {
			get { return _handle->PolygonMode; }
			set { _handle->PolygonMode = value; }
		}

		public CullModeFlags CullMode {
			get { return _handle->CullMode; }
			set { _handle->CullMode = value; }
		}

		public FrontFace FrontFace {
			get { return _handle->FrontFace; }
			set { _handle->FrontFace = value; }
		}

		public bool DepthBiasEnable {
			get { return _handle->DepthBiasEnable; }
			set { _handle->DepthBiasEnable = value; }
		}

		public float DepthBiasConstantFactor {
			get { return _handle->DepthBiasConstantFactor; }
			set { _handle->DepthBiasConstantFactor = value; }
		}

		public float DepthBiasClamp {
			get { return _handle->DepthBiasClamp; }
			set { _handle->DepthBiasClamp = value; }
		}

		public float DepthBiasSlopeFactor {
			get { return _handle->DepthBiasSlopeFactor; }
			set { _handle->DepthBiasSlopeFactor = value; }
		}

		public float LineWidth {
			get { return _handle->LineWidth; }
			set { _handle->LineWidth = value; }
		}
		public Interop.PipelineRasterizationStateCreateInfo* _handle;

		public PipelineRasterizationStateCreateInfo ()
		{
			_handle = (Interop.PipelineRasterizationStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateCreateInfo));
			Initialize ();
		}

		public PipelineRasterizationStateCreateInfo (Interop.PipelineRasterizationStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineRasterizationStateCreateInfo;
		}

	}

	public unsafe class PipelineMultisampleStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public SampleCountFlags RasterizationSamples {
			get { return _handle->RasterizationSamples; }
			set { _handle->RasterizationSamples = value; }
		}

		public bool SampleShadingEnable {
			get { return _handle->SampleShadingEnable; }
			set { _handle->SampleShadingEnable = value; }
		}

		public float MinSampleShading {
			get { return _handle->MinSampleShading; }
			set { _handle->MinSampleShading = value; }
		}

		public uint[] SampleMask {
			get {
				if (_handle->RasterizationSamples == 0)
					return null;
				var values = new uint [((uint)_handle->RasterizationSamples >> 5)];
				unsafe
				{
					var ptr = (uint*)_handle->SampleMask;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->RasterizationSamples = 0;
					_handle->SampleMask = IntPtr.Zero;
					return;
				}
				_handle->RasterizationSamples = (SampleCountFlags)(value.Length << 5);
				_handle->SampleMask = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->SampleMask;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public bool AlphaToCoverageEnable {
			get { return _handle->AlphaToCoverageEnable; }
			set { _handle->AlphaToCoverageEnable = value; }
		}

		public bool AlphaToOneEnable {
			get { return _handle->AlphaToOneEnable; }
			set { _handle->AlphaToOneEnable = value; }
		}
		public Interop.PipelineMultisampleStateCreateInfo* _handle;

		public PipelineMultisampleStateCreateInfo ()
		{
			_handle = (Interop.PipelineMultisampleStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineMultisampleStateCreateInfo));
			Initialize ();
		}

		public PipelineMultisampleStateCreateInfo (Interop.PipelineMultisampleStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineMultisampleStateCreateInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public bool LogicOpEnable {
			get { return _handle->LogicOpEnable; }
			set { _handle->LogicOpEnable = value; }
		}

		public LogicOp LogicOp {
			get { return _handle->LogicOp; }
			set { _handle->LogicOp = value; }
		}

		public uint AttachmentCount {
			get { return _handle->AttachmentCount; }
			set { _handle->AttachmentCount = value; }
		}

		public PipelineColorBlendAttachmentState[] Attachments {
			get {
				if (_handle->AttachmentCount == 0)
					return null;
				var values = new PipelineColorBlendAttachmentState [_handle->AttachmentCount];
				unsafe
				{
					var ptr = (PipelineColorBlendAttachmentState*)_handle->Attachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->AttachmentCount = 0;
					_handle->Attachments = IntPtr.Zero;
					return;
				}
				_handle->AttachmentCount = (uint)value.Length;
				_handle->Attachments = Marshal.AllocHGlobal ((int)(sizeof(PipelineColorBlendAttachmentState)*value.Length));
				unsafe
				{
					var ptr = (PipelineColorBlendAttachmentState*)_handle->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public float[] BlendConstants {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = _handle->BlendConstants [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->BlendConstants [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					_handle->BlendConstants [i] = 0;
			}
		}
		public Interop.PipelineColorBlendStateCreateInfo* _handle;

		public PipelineColorBlendStateCreateInfo ()
		{
			_handle = (Interop.PipelineColorBlendStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineColorBlendStateCreateInfo));
			Initialize ();
		}

		public PipelineColorBlendStateCreateInfo (Interop.PipelineColorBlendStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineColorBlendStateCreateInfo;
		}

	}

	public unsafe class PipelineDynamicStateCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint DynamicStateCount {
			get { return _handle->DynamicStateCount; }
			set { _handle->DynamicStateCount = value; }
		}

		public DynamicState[] DynamicStates {
			get {
				if (_handle->DynamicStateCount == 0)
					return null;
				var values = new DynamicState [_handle->DynamicStateCount];
				unsafe
				{
					var ptr = (DynamicState*)_handle->DynamicStates;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DynamicStateCount = 0;
					_handle->DynamicStates = IntPtr.Zero;
					return;
				}
				_handle->DynamicStateCount = (uint)value.Length;
				_handle->DynamicStates = Marshal.AllocHGlobal ((int)(sizeof(DynamicState)*value.Length));
				unsafe
				{
					var ptr = (DynamicState*)_handle->DynamicStates;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineDynamicStateCreateInfo* _handle;

		public PipelineDynamicStateCreateInfo ()
		{
			_handle = (Interop.PipelineDynamicStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDynamicStateCreateInfo));
			Initialize ();
		}

		public PipelineDynamicStateCreateInfo (Interop.PipelineDynamicStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineDynamicStateCreateInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public bool DepthTestEnable {
			get { return _handle->DepthTestEnable; }
			set { _handle->DepthTestEnable = value; }
		}

		public bool DepthWriteEnable {
			get { return _handle->DepthWriteEnable; }
			set { _handle->DepthWriteEnable = value; }
		}

		public CompareOp DepthCompareOp {
			get { return _handle->DepthCompareOp; }
			set { _handle->DepthCompareOp = value; }
		}

		public bool DepthBoundsTestEnable {
			get { return _handle->DepthBoundsTestEnable; }
			set { _handle->DepthBoundsTestEnable = value; }
		}

		public bool StencilTestEnable {
			get { return _handle->StencilTestEnable; }
			set { _handle->StencilTestEnable = value; }
		}

		public StencilOpState Front {
			get { return _handle->Front; }
			set { _handle->Front = value; }
		}

		public StencilOpState Back {
			get { return _handle->Back; }
			set { _handle->Back = value; }
		}

		public float MinDepthBounds {
			get { return _handle->MinDepthBounds; }
			set { _handle->MinDepthBounds = value; }
		}

		public float MaxDepthBounds {
			get { return _handle->MaxDepthBounds; }
			set { _handle->MaxDepthBounds = value; }
		}
		public Interop.PipelineDepthStencilStateCreateInfo* _handle;

		public PipelineDepthStencilStateCreateInfo ()
		{
			_handle = (Interop.PipelineDepthStencilStateCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineDepthStencilStateCreateInfo));
			Initialize ();
		}

		public PipelineDepthStencilStateCreateInfo (Interop.PipelineDepthStencilStateCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineDepthStencilStateCreateInfo;
		}

	}

	public unsafe class GraphicsPipelineCreateInfo
	{
		public PipelineCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint StageCount {
			get { return _handle->StageCount; }
			set { _handle->StageCount = value; }
		}

		public PipelineShaderStageCreateInfo[] Stages {
			get {
				if (_handle->StageCount == 0)
					return null;
				var values = new PipelineShaderStageCreateInfo [_handle->StageCount];
				unsafe
				{
					var ptr = (Interop.PipelineShaderStageCreateInfo*)_handle->Stages;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new PipelineShaderStageCreateInfo ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->StageCount = 0;
					_handle->Stages = IntPtr.Zero;
					return;
				}
				_handle->StageCount = (uint)value.Length;
				_handle->Stages = Marshal.AllocHGlobal ((int)(sizeof(Interop.PipelineShaderStageCreateInfo)*value.Length));
				unsafe
				{
					var ptr = (Interop.PipelineShaderStageCreateInfo*)_handle->Stages;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		PipelineVertexInputStateCreateInfo lVertexInputState;
		public PipelineVertexInputStateCreateInfo VertexInputState {
			get { return lVertexInputState; }
			set { lVertexInputState = value; _handle->VertexInputState = (IntPtr)value._handle; }
		}

		PipelineInputAssemblyStateCreateInfo lInputAssemblyState;
		public PipelineInputAssemblyStateCreateInfo InputAssemblyState {
			get { return lInputAssemblyState; }
			set { lInputAssemblyState = value; _handle->InputAssemblyState = (IntPtr)value._handle; }
		}

		PipelineTessellationStateCreateInfo lTessellationState;
		public PipelineTessellationStateCreateInfo TessellationState {
			get { return lTessellationState; }
			set { lTessellationState = value; _handle->TessellationState = (IntPtr)value._handle; }
		}

		PipelineViewportStateCreateInfo lViewportState;
		public PipelineViewportStateCreateInfo ViewportState {
			get { return lViewportState; }
			set { lViewportState = value; _handle->ViewportState = (IntPtr)value._handle; }
		}

		PipelineRasterizationStateCreateInfo lRasterizationState;
		public PipelineRasterizationStateCreateInfo RasterizationState {
			get { return lRasterizationState; }
			set { lRasterizationState = value; _handle->RasterizationState = (IntPtr)value._handle; }
		}

		PipelineMultisampleStateCreateInfo lMultisampleState;
		public PipelineMultisampleStateCreateInfo MultisampleState {
			get { return lMultisampleState; }
			set { lMultisampleState = value; _handle->MultisampleState = (IntPtr)value._handle; }
		}

		PipelineDepthStencilStateCreateInfo lDepthStencilState;
		public PipelineDepthStencilStateCreateInfo DepthStencilState {
			get { return lDepthStencilState; }
			set { lDepthStencilState = value; _handle->DepthStencilState = (IntPtr)value._handle; }
		}

		PipelineColorBlendStateCreateInfo lColorBlendState;
		public PipelineColorBlendStateCreateInfo ColorBlendState {
			get { return lColorBlendState; }
			set { lColorBlendState = value; _handle->ColorBlendState = (IntPtr)value._handle; }
		}

		PipelineDynamicStateCreateInfo lDynamicState;
		public PipelineDynamicStateCreateInfo DynamicState {
			get { return lDynamicState; }
			set { lDynamicState = value; _handle->DynamicState = (IntPtr)value._handle; }
		}

		PipelineLayout lLayout;
		public PipelineLayout Layout {
			get { return lLayout; }
			set { lLayout = value; _handle->Layout = (ulong)value._handle; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; _handle->RenderPass = (ulong)value._handle; }
		}

		public uint Subpass {
			get { return _handle->Subpass; }
			set { _handle->Subpass = value; }
		}

		Pipeline lBasePipelineHandle;
		public Pipeline BasePipelineHandle {
			get { return lBasePipelineHandle; }
			set { lBasePipelineHandle = value; _handle->BasePipelineHandle = (ulong)value._handle; }
		}

		public int BasePipelineIndex {
			get { return _handle->BasePipelineIndex; }
			set { _handle->BasePipelineIndex = value; }
		}
		public Interop.GraphicsPipelineCreateInfo* _handle;

		public GraphicsPipelineCreateInfo ()
		{
			_handle = (Interop.GraphicsPipelineCreateInfo*) Interop.Structure.Allocate (typeof (Interop.GraphicsPipelineCreateInfo));
			Initialize ();
		}

		public GraphicsPipelineCreateInfo (Interop.GraphicsPipelineCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.GraphicsPipelineCreateInfo;
		}

	}

	public unsafe class PipelineCacheCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public UIntPtr InitialDataSize {
			get { return _handle->InitialDataSize; }
			set { _handle->InitialDataSize = value; }
		}

		public IntPtr InitialData {
			get { return _handle->InitialData; }
			set { _handle->InitialData = value; }
		}
		public Interop.PipelineCacheCreateInfo* _handle;

		public PipelineCacheCreateInfo ()
		{
			_handle = (Interop.PipelineCacheCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineCacheCreateInfo));
			Initialize ();
		}

		public PipelineCacheCreateInfo (Interop.PipelineCacheCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineCacheCreateInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint SetLayoutCount {
			get { return _handle->SetLayoutCount; }
			set { _handle->SetLayoutCount = value; }
		}

		public DescriptorSetLayout[] SetLayouts {
			get {
				if (_handle->SetLayoutCount == 0)
					return null;
				var values = new DescriptorSetLayout [_handle->SetLayoutCount];
				unsafe
				{
					var ptr = (ulong*)_handle->SetLayouts;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new DescriptorSetLayout ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SetLayoutCount = 0;
					_handle->SetLayouts = IntPtr.Zero;
					return;
				}
				_handle->SetLayoutCount = (uint)value.Length;
				_handle->SetLayouts = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->SetLayouts;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint PushConstantRangeCount {
			get { return _handle->PushConstantRangeCount; }
			set { _handle->PushConstantRangeCount = value; }
		}

		public PushConstantRange[] PushConstantRanges {
			get {
				if (_handle->PushConstantRangeCount == 0)
					return null;
				var values = new PushConstantRange [_handle->PushConstantRangeCount];
				unsafe
				{
					var ptr = (PushConstantRange*)_handle->PushConstantRanges;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->PushConstantRangeCount = 0;
					_handle->PushConstantRanges = IntPtr.Zero;
					return;
				}
				_handle->PushConstantRangeCount = (uint)value.Length;
				_handle->PushConstantRanges = Marshal.AllocHGlobal ((int)(sizeof(PushConstantRange)*value.Length));
				unsafe
				{
					var ptr = (PushConstantRange*)_handle->PushConstantRanges;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PipelineLayoutCreateInfo* _handle;

		public PipelineLayoutCreateInfo ()
		{
			_handle = (Interop.PipelineLayoutCreateInfo*) Interop.Structure.Allocate (typeof (Interop.PipelineLayoutCreateInfo));
			Initialize ();
		}

		public PipelineLayoutCreateInfo (Interop.PipelineLayoutCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineLayoutCreateInfo;
		}

	}

	public unsafe class SamplerCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public Filter MagFilter {
			get { return _handle->MagFilter; }
			set { _handle->MagFilter = value; }
		}

		public Filter MinFilter {
			get { return _handle->MinFilter; }
			set { _handle->MinFilter = value; }
		}

		public SamplerMipmapMode MipmapMode {
			get { return _handle->MipmapMode; }
			set { _handle->MipmapMode = value; }
		}

		public SamplerAddressMode AddressModeU {
			get { return _handle->AddressModeU; }
			set { _handle->AddressModeU = value; }
		}

		public SamplerAddressMode AddressModeV {
			get { return _handle->AddressModeV; }
			set { _handle->AddressModeV = value; }
		}

		public SamplerAddressMode AddressModeW {
			get { return _handle->AddressModeW; }
			set { _handle->AddressModeW = value; }
		}

		public float MipLodBias {
			get { return _handle->MipLodBias; }
			set { _handle->MipLodBias = value; }
		}

		public bool AnisotropyEnable {
			get { return _handle->AnisotropyEnable; }
			set { _handle->AnisotropyEnable = value; }
		}

		public float MaxAnisotropy {
			get { return _handle->MaxAnisotropy; }
			set { _handle->MaxAnisotropy = value; }
		}

		public bool CompareEnable {
			get { return _handle->CompareEnable; }
			set { _handle->CompareEnable = value; }
		}

		public CompareOp CompareOp {
			get { return _handle->CompareOp; }
			set { _handle->CompareOp = value; }
		}

		public float MinLod {
			get { return _handle->MinLod; }
			set { _handle->MinLod = value; }
		}

		public float MaxLod {
			get { return _handle->MaxLod; }
			set { _handle->MaxLod = value; }
		}

		public BorderColor BorderColor {
			get { return _handle->BorderColor; }
			set { _handle->BorderColor = value; }
		}

		public bool UnnormalizedCoordinates {
			get { return _handle->UnnormalizedCoordinates; }
			set { _handle->UnnormalizedCoordinates = value; }
		}
		public Interop.SamplerCreateInfo* _handle;

		public SamplerCreateInfo ()
		{
			_handle = (Interop.SamplerCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SamplerCreateInfo));
			Initialize ();
		}

		public SamplerCreateInfo (Interop.SamplerCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.SamplerCreateInfo;
		}

	}

	public unsafe class CommandPoolCreateInfo
	{
		public CommandPoolCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint QueueFamilyIndex {
			get { return _handle->QueueFamilyIndex; }
			set { _handle->QueueFamilyIndex = value; }
		}
		public Interop.CommandPoolCreateInfo* _handle;

		public CommandPoolCreateInfo ()
		{
			_handle = (Interop.CommandPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandPoolCreateInfo));
			Initialize ();
		}

		public CommandPoolCreateInfo (Interop.CommandPoolCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.CommandPoolCreateInfo;
		}

	}

	public unsafe class CommandBufferAllocateInfo
	{
		CommandPool lCommandPool;
		public CommandPool CommandPool {
			get { return lCommandPool; }
			set { lCommandPool = value; _handle->CommandPool = (ulong)value._handle; }
		}

		public CommandBufferLevel Level {
			get { return _handle->Level; }
			set { _handle->Level = value; }
		}

		public uint CommandBufferCount {
			get { return _handle->CommandBufferCount; }
			set { _handle->CommandBufferCount = value; }
		}
		public Interop.CommandBufferAllocateInfo* _handle;

		public CommandBufferAllocateInfo ()
		{
			_handle = (Interop.CommandBufferAllocateInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferAllocateInfo));
			Initialize ();
		}

		public CommandBufferAllocateInfo (Interop.CommandBufferAllocateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.CommandBufferAllocateInfo;
		}

	}

	public unsafe class CommandBufferInheritanceInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; _handle->RenderPass = (ulong)value._handle; }
		}

		public uint Subpass {
			get { return _handle->Subpass; }
			set { _handle->Subpass = value; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; _handle->Framebuffer = (ulong)value._handle; }
		}

		public bool OcclusionQueryEnable {
			get { return _handle->OcclusionQueryEnable; }
			set { _handle->OcclusionQueryEnable = value; }
		}

		public QueryControlFlags QueryFlags {
			get { return _handle->QueryFlags; }
			set { _handle->QueryFlags = value; }
		}

		public QueryPipelineStatisticFlags PipelineStatistics {
			get { return _handle->PipelineStatistics; }
			set { _handle->PipelineStatistics = value; }
		}
		public Interop.CommandBufferInheritanceInfo* _handle;

		public CommandBufferInheritanceInfo ()
		{
			_handle = (Interop.CommandBufferInheritanceInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferInheritanceInfo));
			Initialize ();
		}

		public CommandBufferInheritanceInfo (Interop.CommandBufferInheritanceInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.CommandBufferInheritanceInfo;
		}

	}

	public unsafe class CommandBufferBeginInfo
	{
		public CommandBufferUsageFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		CommandBufferInheritanceInfo lInheritanceInfo;
		public CommandBufferInheritanceInfo InheritanceInfo {
			get { return lInheritanceInfo; }
			set { lInheritanceInfo = value; _handle->InheritanceInfo = (IntPtr)value._handle; }
		}
		public Interop.CommandBufferBeginInfo* _handle;

		public CommandBufferBeginInfo ()
		{
			_handle = (Interop.CommandBufferBeginInfo*) Interop.Structure.Allocate (typeof (Interop.CommandBufferBeginInfo));
			Initialize ();
		}

		public CommandBufferBeginInfo (Interop.CommandBufferBeginInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.CommandBufferBeginInfo;
		}

	}

	public unsafe class RenderPassBeginInfo
	{
		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; _handle->RenderPass = (ulong)value._handle; }
		}

		Framebuffer lFramebuffer;
		public Framebuffer Framebuffer {
			get { return lFramebuffer; }
			set { lFramebuffer = value; _handle->Framebuffer = (ulong)value._handle; }
		}

		public Rect2D RenderArea {
			get { return _handle->RenderArea; }
			set { _handle->RenderArea = value; }
		}

		public uint ClearValueCount {
			get { return _handle->ClearValueCount; }
			set { _handle->ClearValueCount = value; }
		}

		public ClearValue[] ClearValues {
			get {
				if (_handle->ClearValueCount == 0)
					return null;
				var values = new ClearValue [_handle->ClearValueCount];
				unsafe
				{
					var ptr = (Interop.ClearValue*)_handle->ClearValues;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new ClearValue ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ClearValueCount = 0;
					_handle->ClearValues = IntPtr.Zero;
					return;
				}
				_handle->ClearValueCount = (uint)value.Length;
				_handle->ClearValues = Marshal.AllocHGlobal ((int)(sizeof(Interop.ClearValue)*value.Length));
				unsafe
				{
					var ptr = (Interop.ClearValue*)_handle->ClearValues;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}
		public Interop.RenderPassBeginInfo* _handle;

		public RenderPassBeginInfo ()
		{
			_handle = (Interop.RenderPassBeginInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassBeginInfo));
			Initialize ();
		}

		public RenderPassBeginInfo (Interop.RenderPassBeginInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.RenderPassBeginInfo;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public PipelineBindPoint PipelineBindPoint {
			get { return _handle->PipelineBindPoint; }
			set { _handle->PipelineBindPoint = value; }
		}

		public uint InputAttachmentCount {
			get { return _handle->InputAttachmentCount; }
			set { _handle->InputAttachmentCount = value; }
		}

		public AttachmentReference[] InputAttachments {
			get {
				if (_handle->InputAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [_handle->InputAttachmentCount];
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->InputAttachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->InputAttachmentCount = 0;
					_handle->InputAttachments = IntPtr.Zero;
					return;
				}
				_handle->InputAttachmentCount = (uint)value.Length;
				_handle->InputAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->InputAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint ColorAttachmentCount {
			get { return _handle->ColorAttachmentCount; }
			set { _handle->ColorAttachmentCount = value; }
		}

		public AttachmentReference[] ColorAttachments {
			get {
				if (_handle->ColorAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [_handle->ColorAttachmentCount];
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->ColorAttachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ColorAttachmentCount = 0;
					_handle->ColorAttachments = IntPtr.Zero;
					return;
				}
				_handle->ColorAttachmentCount = (uint)value.Length;
				_handle->ColorAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->ColorAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public AttachmentReference[] ResolveAttachments {
			get {
				if (_handle->ColorAttachmentCount == 0)
					return null;
				var values = new AttachmentReference [_handle->ColorAttachmentCount];
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->ResolveAttachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->ColorAttachmentCount = 0;
					_handle->ResolveAttachments = IntPtr.Zero;
					return;
				}
				_handle->ColorAttachmentCount = (uint)value.Length;
				_handle->ResolveAttachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentReference)*value.Length));
				unsafe
				{
					var ptr = (AttachmentReference*)_handle->ResolveAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public AttachmentReference DepthStencilAttachment {
			get { return (AttachmentReference)Interop.Structure.MarshalPointerToObject (_handle->DepthStencilAttachment, typeof (AttachmentReference)); }
			set { _handle->DepthStencilAttachment = Interop.Structure.MarshalObjectToPointer (_handle->DepthStencilAttachment, value); }
		}

		public uint PreserveAttachmentCount {
			get { return _handle->PreserveAttachmentCount; }
			set { _handle->PreserveAttachmentCount = value; }
		}

		public uint[] PreserveAttachments {
			get {
				if (_handle->PreserveAttachmentCount == 0)
					return null;
				var values = new uint [_handle->PreserveAttachmentCount];
				unsafe
				{
					var ptr = (uint*)_handle->PreserveAttachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->PreserveAttachmentCount = 0;
					_handle->PreserveAttachments = IntPtr.Zero;
					return;
				}
				_handle->PreserveAttachmentCount = (uint)value.Length;
				_handle->PreserveAttachments = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->PreserveAttachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.SubpassDescription* _handle;

		public SubpassDescription ()
		{
			_handle = (Interop.SubpassDescription*) Interop.Structure.Allocate (typeof (Interop.SubpassDescription));
		}

		public SubpassDescription (Interop.SubpassDescription* ptr)
		{
			_handle = ptr;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public uint AttachmentCount {
			get { return _handle->AttachmentCount; }
			set { _handle->AttachmentCount = value; }
		}

		public AttachmentDescription[] Attachments {
			get {
				if (_handle->AttachmentCount == 0)
					return null;
				var values = new AttachmentDescription [_handle->AttachmentCount];
				unsafe
				{
					var ptr = (AttachmentDescription*)_handle->Attachments;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->AttachmentCount = 0;
					_handle->Attachments = IntPtr.Zero;
					return;
				}
				_handle->AttachmentCount = (uint)value.Length;
				_handle->Attachments = Marshal.AllocHGlobal ((int)(sizeof(AttachmentDescription)*value.Length));
				unsafe
				{
					var ptr = (AttachmentDescription*)_handle->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint SubpassCount {
			get { return _handle->SubpassCount; }
			set { _handle->SubpassCount = value; }
		}

		public SubpassDescription[] Subpasses {
			get {
				if (_handle->SubpassCount == 0)
					return null;
				var values = new SubpassDescription [_handle->SubpassCount];
				unsafe
				{
					var ptr = (Interop.SubpassDescription*)_handle->Subpasses;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SubpassDescription ();
						*values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SubpassCount = 0;
					_handle->Subpasses = IntPtr.Zero;
					return;
				}
				_handle->SubpassCount = (uint)value.Length;
				_handle->Subpasses = Marshal.AllocHGlobal ((int)(sizeof(Interop.SubpassDescription)*value.Length));
				unsafe
				{
					var ptr = (Interop.SubpassDescription*)_handle->Subpasses;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = *value [i]._handle;
				}
			}
		}

		public uint DependencyCount {
			get { return _handle->DependencyCount; }
			set { _handle->DependencyCount = value; }
		}

		public SubpassDependency[] Dependencies {
			get {
				if (_handle->DependencyCount == 0)
					return null;
				var values = new SubpassDependency [_handle->DependencyCount];
				unsafe
				{
					var ptr = (SubpassDependency*)_handle->Dependencies;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->DependencyCount = 0;
					_handle->Dependencies = IntPtr.Zero;
					return;
				}
				_handle->DependencyCount = (uint)value.Length;
				_handle->Dependencies = Marshal.AllocHGlobal ((int)(sizeof(SubpassDependency)*value.Length));
				unsafe
				{
					var ptr = (SubpassDependency*)_handle->Dependencies;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.RenderPassCreateInfo* _handle;

		public RenderPassCreateInfo ()
		{
			_handle = (Interop.RenderPassCreateInfo*) Interop.Structure.Allocate (typeof (Interop.RenderPassCreateInfo));
			Initialize ();
		}

		public RenderPassCreateInfo (Interop.RenderPassCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.RenderPassCreateInfo;
		}

	}

	public unsafe class EventCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}
		public Interop.EventCreateInfo* _handle;

		public EventCreateInfo ()
		{
			_handle = (Interop.EventCreateInfo*) Interop.Structure.Allocate (typeof (Interop.EventCreateInfo));
			Initialize ();
		}

		public EventCreateInfo (Interop.EventCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.EventCreateInfo;
		}

	}

	public unsafe class FenceCreateInfo
	{
		public FenceCreateFlags Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}
		public Interop.FenceCreateInfo* _handle;

		public FenceCreateInfo ()
		{
			_handle = (Interop.FenceCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FenceCreateInfo));
			Initialize ();
		}

		public FenceCreateInfo (Interop.FenceCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.FenceCreateInfo;
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
			get { return _handle->MaxImageDimension1D; }
			set { _handle->MaxImageDimension1D = value; }
		}

		public uint MaxImageDimension2D {
			get { return _handle->MaxImageDimension2D; }
			set { _handle->MaxImageDimension2D = value; }
		}

		public uint MaxImageDimension3D {
			get { return _handle->MaxImageDimension3D; }
			set { _handle->MaxImageDimension3D = value; }
		}

		public uint MaxImageDimensionCube {
			get { return _handle->MaxImageDimensionCube; }
			set { _handle->MaxImageDimensionCube = value; }
		}

		public uint MaxImageArrayLayers {
			get { return _handle->MaxImageArrayLayers; }
			set { _handle->MaxImageArrayLayers = value; }
		}

		public uint MaxTexelBufferElements {
			get { return _handle->MaxTexelBufferElements; }
			set { _handle->MaxTexelBufferElements = value; }
		}

		public uint MaxUniformBufferRange {
			get { return _handle->MaxUniformBufferRange; }
			set { _handle->MaxUniformBufferRange = value; }
		}

		public uint MaxStorageBufferRange {
			get { return _handle->MaxStorageBufferRange; }
			set { _handle->MaxStorageBufferRange = value; }
		}

		public uint MaxPushConstantsSize {
			get { return _handle->MaxPushConstantsSize; }
			set { _handle->MaxPushConstantsSize = value; }
		}

		public uint MaxMemoryAllocationCount {
			get { return _handle->MaxMemoryAllocationCount; }
			set { _handle->MaxMemoryAllocationCount = value; }
		}

		public uint MaxSamplerAllocationCount {
			get { return _handle->MaxSamplerAllocationCount; }
			set { _handle->MaxSamplerAllocationCount = value; }
		}

		public DeviceSize BufferImageGranularity {
			get { return _handle->BufferImageGranularity; }
			set { _handle->BufferImageGranularity = value; }
		}

		public DeviceSize SparseAddressSpaceSize {
			get { return _handle->SparseAddressSpaceSize; }
			set { _handle->SparseAddressSpaceSize = value; }
		}

		public uint MaxBoundDescriptorSets {
			get { return _handle->MaxBoundDescriptorSets; }
			set { _handle->MaxBoundDescriptorSets = value; }
		}

		public uint MaxPerStageDescriptorSamplers {
			get { return _handle->MaxPerStageDescriptorSamplers; }
			set { _handle->MaxPerStageDescriptorSamplers = value; }
		}

		public uint MaxPerStageDescriptorUniformBuffers {
			get { return _handle->MaxPerStageDescriptorUniformBuffers; }
			set { _handle->MaxPerStageDescriptorUniformBuffers = value; }
		}

		public uint MaxPerStageDescriptorStorageBuffers {
			get { return _handle->MaxPerStageDescriptorStorageBuffers; }
			set { _handle->MaxPerStageDescriptorStorageBuffers = value; }
		}

		public uint MaxPerStageDescriptorSampledImages {
			get { return _handle->MaxPerStageDescriptorSampledImages; }
			set { _handle->MaxPerStageDescriptorSampledImages = value; }
		}

		public uint MaxPerStageDescriptorStorageImages {
			get { return _handle->MaxPerStageDescriptorStorageImages; }
			set { _handle->MaxPerStageDescriptorStorageImages = value; }
		}

		public uint MaxPerStageDescriptorInputAttachments {
			get { return _handle->MaxPerStageDescriptorInputAttachments; }
			set { _handle->MaxPerStageDescriptorInputAttachments = value; }
		}

		public uint MaxPerStageResources {
			get { return _handle->MaxPerStageResources; }
			set { _handle->MaxPerStageResources = value; }
		}

		public uint MaxDescriptorSetSamplers {
			get { return _handle->MaxDescriptorSetSamplers; }
			set { _handle->MaxDescriptorSetSamplers = value; }
		}

		public uint MaxDescriptorSetUniformBuffers {
			get { return _handle->MaxDescriptorSetUniformBuffers; }
			set { _handle->MaxDescriptorSetUniformBuffers = value; }
		}

		public uint MaxDescriptorSetUniformBuffersDynamic {
			get { return _handle->MaxDescriptorSetUniformBuffersDynamic; }
			set { _handle->MaxDescriptorSetUniformBuffersDynamic = value; }
		}

		public uint MaxDescriptorSetStorageBuffers {
			get { return _handle->MaxDescriptorSetStorageBuffers; }
			set { _handle->MaxDescriptorSetStorageBuffers = value; }
		}

		public uint MaxDescriptorSetStorageBuffersDynamic {
			get { return _handle->MaxDescriptorSetStorageBuffersDynamic; }
			set { _handle->MaxDescriptorSetStorageBuffersDynamic = value; }
		}

		public uint MaxDescriptorSetSampledImages {
			get { return _handle->MaxDescriptorSetSampledImages; }
			set { _handle->MaxDescriptorSetSampledImages = value; }
		}

		public uint MaxDescriptorSetStorageImages {
			get { return _handle->MaxDescriptorSetStorageImages; }
			set { _handle->MaxDescriptorSetStorageImages = value; }
		}

		public uint MaxDescriptorSetInputAttachments {
			get { return _handle->MaxDescriptorSetInputAttachments; }
			set { _handle->MaxDescriptorSetInputAttachments = value; }
		}

		public uint MaxVertexInputAttributes {
			get { return _handle->MaxVertexInputAttributes; }
			set { _handle->MaxVertexInputAttributes = value; }
		}

		public uint MaxVertexInputBindings {
			get { return _handle->MaxVertexInputBindings; }
			set { _handle->MaxVertexInputBindings = value; }
		}

		public uint MaxVertexInputAttributeOffset {
			get { return _handle->MaxVertexInputAttributeOffset; }
			set { _handle->MaxVertexInputAttributeOffset = value; }
		}

		public uint MaxVertexInputBindingStride {
			get { return _handle->MaxVertexInputBindingStride; }
			set { _handle->MaxVertexInputBindingStride = value; }
		}

		public uint MaxVertexOutputComponents {
			get { return _handle->MaxVertexOutputComponents; }
			set { _handle->MaxVertexOutputComponents = value; }
		}

		public uint MaxTessellationGenerationLevel {
			get { return _handle->MaxTessellationGenerationLevel; }
			set { _handle->MaxTessellationGenerationLevel = value; }
		}

		public uint MaxTessellationPatchSize {
			get { return _handle->MaxTessellationPatchSize; }
			set { _handle->MaxTessellationPatchSize = value; }
		}

		public uint MaxTessellationControlPerVertexInputComponents {
			get { return _handle->MaxTessellationControlPerVertexInputComponents; }
			set { _handle->MaxTessellationControlPerVertexInputComponents = value; }
		}

		public uint MaxTessellationControlPerVertexOutputComponents {
			get { return _handle->MaxTessellationControlPerVertexOutputComponents; }
			set { _handle->MaxTessellationControlPerVertexOutputComponents = value; }
		}

		public uint MaxTessellationControlPerPatchOutputComponents {
			get { return _handle->MaxTessellationControlPerPatchOutputComponents; }
			set { _handle->MaxTessellationControlPerPatchOutputComponents = value; }
		}

		public uint MaxTessellationControlTotalOutputComponents {
			get { return _handle->MaxTessellationControlTotalOutputComponents; }
			set { _handle->MaxTessellationControlTotalOutputComponents = value; }
		}

		public uint MaxTessellationEvaluationInputComponents {
			get { return _handle->MaxTessellationEvaluationInputComponents; }
			set { _handle->MaxTessellationEvaluationInputComponents = value; }
		}

		public uint MaxTessellationEvaluationOutputComponents {
			get { return _handle->MaxTessellationEvaluationOutputComponents; }
			set { _handle->MaxTessellationEvaluationOutputComponents = value; }
		}

		public uint MaxGeometryShaderInvocations {
			get { return _handle->MaxGeometryShaderInvocations; }
			set { _handle->MaxGeometryShaderInvocations = value; }
		}

		public uint MaxGeometryInputComponents {
			get { return _handle->MaxGeometryInputComponents; }
			set { _handle->MaxGeometryInputComponents = value; }
		}

		public uint MaxGeometryOutputComponents {
			get { return _handle->MaxGeometryOutputComponents; }
			set { _handle->MaxGeometryOutputComponents = value; }
		}

		public uint MaxGeometryOutputVertices {
			get { return _handle->MaxGeometryOutputVertices; }
			set { _handle->MaxGeometryOutputVertices = value; }
		}

		public uint MaxGeometryTotalOutputComponents {
			get { return _handle->MaxGeometryTotalOutputComponents; }
			set { _handle->MaxGeometryTotalOutputComponents = value; }
		}

		public uint MaxFragmentInputComponents {
			get { return _handle->MaxFragmentInputComponents; }
			set { _handle->MaxFragmentInputComponents = value; }
		}

		public uint MaxFragmentOutputAttachments {
			get { return _handle->MaxFragmentOutputAttachments; }
			set { _handle->MaxFragmentOutputAttachments = value; }
		}

		public uint MaxFragmentDualSrcAttachments {
			get { return _handle->MaxFragmentDualSrcAttachments; }
			set { _handle->MaxFragmentDualSrcAttachments = value; }
		}

		public uint MaxFragmentCombinedOutputResources {
			get { return _handle->MaxFragmentCombinedOutputResources; }
			set { _handle->MaxFragmentCombinedOutputResources = value; }
		}

		public uint MaxComputeSharedMemorySize {
			get { return _handle->MaxComputeSharedMemorySize; }
			set { _handle->MaxComputeSharedMemorySize = value; }
		}

		public uint[] MaxComputeWorkGroupCount {
			get {
				var arr = new uint [3];
				for (var i = 0; i < 3; i++)
					arr [i] = _handle->MaxComputeWorkGroupCount [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->MaxComputeWorkGroupCount [i] = value [i];
				for (var i = value.Length; i < 3; i++)
					_handle->MaxComputeWorkGroupCount [i] = 0;
			}
		}

		public uint MaxComputeWorkGroupInvocations {
			get { return _handle->MaxComputeWorkGroupInvocations; }
			set { _handle->MaxComputeWorkGroupInvocations = value; }
		}

		public uint[] MaxComputeWorkGroupSize {
			get {
				var arr = new uint [3];
				for (var i = 0; i < 3; i++)
					arr [i] = _handle->MaxComputeWorkGroupSize [i];
				return arr;
			}

			set {
				if (value.Length > 3)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->MaxComputeWorkGroupSize [i] = value [i];
				for (var i = value.Length; i < 3; i++)
					_handle->MaxComputeWorkGroupSize [i] = 0;
			}
		}

		public uint SubPixelPrecisionBits {
			get { return _handle->SubPixelPrecisionBits; }
			set { _handle->SubPixelPrecisionBits = value; }
		}

		public uint SubTexelPrecisionBits {
			get { return _handle->SubTexelPrecisionBits; }
			set { _handle->SubTexelPrecisionBits = value; }
		}

		public uint MipmapPrecisionBits {
			get { return _handle->MipmapPrecisionBits; }
			set { _handle->MipmapPrecisionBits = value; }
		}

		public uint MaxDrawIndexedIndexValue {
			get { return _handle->MaxDrawIndexedIndexValue; }
			set { _handle->MaxDrawIndexedIndexValue = value; }
		}

		public uint MaxDrawIndirectCount {
			get { return _handle->MaxDrawIndirectCount; }
			set { _handle->MaxDrawIndirectCount = value; }
		}

		public float MaxSamplerLodBias {
			get { return _handle->MaxSamplerLodBias; }
			set { _handle->MaxSamplerLodBias = value; }
		}

		public float MaxSamplerAnisotropy {
			get { return _handle->MaxSamplerAnisotropy; }
			set { _handle->MaxSamplerAnisotropy = value; }
		}

		public uint MaxViewports {
			get { return _handle->MaxViewports; }
			set { _handle->MaxViewports = value; }
		}

		public uint[] MaxViewportDimensions {
			get {
				var arr = new uint [2];
				for (var i = 0; i < 2; i++)
					arr [i] = _handle->MaxViewportDimensions [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->MaxViewportDimensions [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					_handle->MaxViewportDimensions [i] = 0;
			}
		}

		public float[] ViewportBoundsRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = _handle->ViewportBoundsRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->ViewportBoundsRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					_handle->ViewportBoundsRange [i] = 0;
			}
		}

		public uint ViewportSubPixelBits {
			get { return _handle->ViewportSubPixelBits; }
			set { _handle->ViewportSubPixelBits = value; }
		}

		public UIntPtr MinMemoryMapAlignment {
			get { return _handle->MinMemoryMapAlignment; }
			set { _handle->MinMemoryMapAlignment = value; }
		}

		public DeviceSize MinTexelBufferOffsetAlignment {
			get { return _handle->MinTexelBufferOffsetAlignment; }
			set { _handle->MinTexelBufferOffsetAlignment = value; }
		}

		public DeviceSize MinUniformBufferOffsetAlignment {
			get { return _handle->MinUniformBufferOffsetAlignment; }
			set { _handle->MinUniformBufferOffsetAlignment = value; }
		}

		public DeviceSize MinStorageBufferOffsetAlignment {
			get { return _handle->MinStorageBufferOffsetAlignment; }
			set { _handle->MinStorageBufferOffsetAlignment = value; }
		}

		public int MinTexelOffset {
			get { return _handle->MinTexelOffset; }
			set { _handle->MinTexelOffset = value; }
		}

		public uint MaxTexelOffset {
			get { return _handle->MaxTexelOffset; }
			set { _handle->MaxTexelOffset = value; }
		}

		public int MinTexelGatherOffset {
			get { return _handle->MinTexelGatherOffset; }
			set { _handle->MinTexelGatherOffset = value; }
		}

		public uint MaxTexelGatherOffset {
			get { return _handle->MaxTexelGatherOffset; }
			set { _handle->MaxTexelGatherOffset = value; }
		}

		public float MinInterpolationOffset {
			get { return _handle->MinInterpolationOffset; }
			set { _handle->MinInterpolationOffset = value; }
		}

		public float MaxInterpolationOffset {
			get { return _handle->MaxInterpolationOffset; }
			set { _handle->MaxInterpolationOffset = value; }
		}

		public uint SubPixelInterpolationOffsetBits {
			get { return _handle->SubPixelInterpolationOffsetBits; }
			set { _handle->SubPixelInterpolationOffsetBits = value; }
		}

		public uint MaxFramebufferWidth {
			get { return _handle->MaxFramebufferWidth; }
			set { _handle->MaxFramebufferWidth = value; }
		}

		public uint MaxFramebufferHeight {
			get { return _handle->MaxFramebufferHeight; }
			set { _handle->MaxFramebufferHeight = value; }
		}

		public uint MaxFramebufferLayers {
			get { return _handle->MaxFramebufferLayers; }
			set { _handle->MaxFramebufferLayers = value; }
		}

		public SampleCountFlags FramebufferColorSampleCounts {
			get { return _handle->FramebufferColorSampleCounts; }
			set { _handle->FramebufferColorSampleCounts = value; }
		}

		public SampleCountFlags FramebufferDepthSampleCounts {
			get { return _handle->FramebufferDepthSampleCounts; }
			set { _handle->FramebufferDepthSampleCounts = value; }
		}

		public SampleCountFlags FramebufferStencilSampleCounts {
			get { return _handle->FramebufferStencilSampleCounts; }
			set { _handle->FramebufferStencilSampleCounts = value; }
		}

		public SampleCountFlags FramebufferNoAttachmentsSampleCounts {
			get { return _handle->FramebufferNoAttachmentsSampleCounts; }
			set { _handle->FramebufferNoAttachmentsSampleCounts = value; }
		}

		public uint MaxColorAttachments {
			get { return _handle->MaxColorAttachments; }
			set { _handle->MaxColorAttachments = value; }
		}

		public SampleCountFlags SampledImageColorSampleCounts {
			get { return _handle->SampledImageColorSampleCounts; }
			set { _handle->SampledImageColorSampleCounts = value; }
		}

		public SampleCountFlags SampledImageIntegerSampleCounts {
			get { return _handle->SampledImageIntegerSampleCounts; }
			set { _handle->SampledImageIntegerSampleCounts = value; }
		}

		public SampleCountFlags SampledImageDepthSampleCounts {
			get { return _handle->SampledImageDepthSampleCounts; }
			set { _handle->SampledImageDepthSampleCounts = value; }
		}

		public SampleCountFlags SampledImageStencilSampleCounts {
			get { return _handle->SampledImageStencilSampleCounts; }
			set { _handle->SampledImageStencilSampleCounts = value; }
		}

		public SampleCountFlags StorageImageSampleCounts {
			get { return _handle->StorageImageSampleCounts; }
			set { _handle->StorageImageSampleCounts = value; }
		}

		public uint MaxSampleMaskWords {
			get { return _handle->MaxSampleMaskWords; }
			set { _handle->MaxSampleMaskWords = value; }
		}

		public bool TimestampComputeAndGraphics {
			get { return _handle->TimestampComputeAndGraphics; }
			set { _handle->TimestampComputeAndGraphics = value; }
		}

		public float TimestampPeriod {
			get { return _handle->TimestampPeriod; }
			set { _handle->TimestampPeriod = value; }
		}

		public uint MaxClipDistances {
			get { return _handle->MaxClipDistances; }
			set { _handle->MaxClipDistances = value; }
		}

		public uint MaxCullDistances {
			get { return _handle->MaxCullDistances; }
			set { _handle->MaxCullDistances = value; }
		}

		public uint MaxCombinedClipAndCullDistances {
			get { return _handle->MaxCombinedClipAndCullDistances; }
			set { _handle->MaxCombinedClipAndCullDistances = value; }
		}

		public uint DiscreteQueuePriorities {
			get { return _handle->DiscreteQueuePriorities; }
			set { _handle->DiscreteQueuePriorities = value; }
		}

		public float[] PointSizeRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = _handle->PointSizeRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->PointSizeRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					_handle->PointSizeRange [i] = 0;
			}
		}

		public float[] LineWidthRange {
			get {
				var arr = new float [2];
				for (var i = 0; i < 2; i++)
					arr [i] = _handle->LineWidthRange [i];
				return arr;
			}

			set {
				if (value.Length > 2)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->LineWidthRange [i] = value [i];
				for (var i = value.Length; i < 2; i++)
					_handle->LineWidthRange [i] = 0;
			}
		}

		public float PointSizeGranularity {
			get { return _handle->PointSizeGranularity; }
			set { _handle->PointSizeGranularity = value; }
		}

		public float LineWidthGranularity {
			get { return _handle->LineWidthGranularity; }
			set { _handle->LineWidthGranularity = value; }
		}

		public bool StrictLines {
			get { return _handle->StrictLines; }
			set { _handle->StrictLines = value; }
		}

		public bool StandardSampleLocations {
			get { return _handle->StandardSampleLocations; }
			set { _handle->StandardSampleLocations = value; }
		}

		public DeviceSize OptimalBufferCopyOffsetAlignment {
			get { return _handle->OptimalBufferCopyOffsetAlignment; }
			set { _handle->OptimalBufferCopyOffsetAlignment = value; }
		}

		public DeviceSize OptimalBufferCopyRowPitchAlignment {
			get { return _handle->OptimalBufferCopyRowPitchAlignment; }
			set { _handle->OptimalBufferCopyRowPitchAlignment = value; }
		}

		public DeviceSize NonCoherentAtomSize {
			get { return _handle->NonCoherentAtomSize; }
			set { _handle->NonCoherentAtomSize = value; }
		}
		public Interop.PhysicalDeviceLimits* _handle;

		public PhysicalDeviceLimits ()
		{
			_handle = (Interop.PhysicalDeviceLimits*) Interop.Structure.Allocate (typeof (Interop.PhysicalDeviceLimits));
		}

		public PhysicalDeviceLimits (Interop.PhysicalDeviceLimits* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class SemaphoreCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}
		public Interop.SemaphoreCreateInfo* _handle;

		public SemaphoreCreateInfo ()
		{
			_handle = (Interop.SemaphoreCreateInfo*) Interop.Structure.Allocate (typeof (Interop.SemaphoreCreateInfo));
			Initialize ();
		}

		public SemaphoreCreateInfo (Interop.SemaphoreCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.SemaphoreCreateInfo;
		}

	}

	public unsafe class QueryPoolCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public QueryType QueryType {
			get { return _handle->QueryType; }
			set { _handle->QueryType = value; }
		}

		public uint QueryCount {
			get { return _handle->QueryCount; }
			set { _handle->QueryCount = value; }
		}

		public QueryPipelineStatisticFlags PipelineStatistics {
			get { return _handle->PipelineStatistics; }
			set { _handle->PipelineStatistics = value; }
		}
		public Interop.QueryPoolCreateInfo* _handle;

		public QueryPoolCreateInfo ()
		{
			_handle = (Interop.QueryPoolCreateInfo*) Interop.Structure.Allocate (typeof (Interop.QueryPoolCreateInfo));
			Initialize ();
		}

		public QueryPoolCreateInfo (Interop.QueryPoolCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.QueryPoolCreateInfo;
		}

	}

	public unsafe class FramebufferCreateInfo
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		RenderPass lRenderPass;
		public RenderPass RenderPass {
			get { return lRenderPass; }
			set { lRenderPass = value; _handle->RenderPass = (ulong)value._handle; }
		}

		public uint AttachmentCount {
			get { return _handle->AttachmentCount; }
			set { _handle->AttachmentCount = value; }
		}

		public ImageView[] Attachments {
			get {
				if (_handle->AttachmentCount == 0)
					return null;
				var values = new ImageView [_handle->AttachmentCount];
				unsafe
				{
					var ptr = (ulong*)_handle->Attachments;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new ImageView ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->AttachmentCount = 0;
					_handle->Attachments = IntPtr.Zero;
					return;
				}
				_handle->AttachmentCount = (uint)value.Length;
				_handle->Attachments = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->Attachments;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint Width {
			get { return _handle->Width; }
			set { _handle->Width = value; }
		}

		public uint Height {
			get { return _handle->Height; }
			set { _handle->Height = value; }
		}

		public uint Layers {
			get { return _handle->Layers; }
			set { _handle->Layers = value; }
		}
		public Interop.FramebufferCreateInfo* _handle;

		public FramebufferCreateInfo ()
		{
			_handle = (Interop.FramebufferCreateInfo*) Interop.Structure.Allocate (typeof (Interop.FramebufferCreateInfo));
			Initialize ();
		}

		public FramebufferCreateInfo (Interop.FramebufferCreateInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.FramebufferCreateInfo;
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
			get { return _handle->WaitSemaphoreCount; }
			set { _handle->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (_handle->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [_handle->WaitSemaphoreCount];
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->WaitSemaphoreCount = 0;
					_handle->WaitSemaphores = IntPtr.Zero;
					return;
				}
				_handle->WaitSemaphoreCount = (uint)value.Length;
				_handle->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public PipelineStageFlags[] WaitDstStageMask {
			get {
				if (_handle->WaitSemaphoreCount == 0)
					return null;
				var values = new PipelineStageFlags [_handle->WaitSemaphoreCount];
				unsafe
				{
					var ptr = (PipelineStageFlags*)_handle->WaitDstStageMask;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->WaitSemaphoreCount = 0;
					_handle->WaitDstStageMask = IntPtr.Zero;
					return;
				}
				_handle->WaitSemaphoreCount = (uint)value.Length;
				_handle->WaitDstStageMask = Marshal.AllocHGlobal ((int)(sizeof(PipelineStageFlags)*value.Length));
				unsafe
				{
					var ptr = (PipelineStageFlags*)_handle->WaitDstStageMask;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public uint CommandBufferCount {
			get { return _handle->CommandBufferCount; }
			set { _handle->CommandBufferCount = value; }
		}

		public CommandBuffer[] CommandBuffers {
			get {
				if (_handle->CommandBufferCount == 0)
					return null;
				var values = new CommandBuffer [_handle->CommandBufferCount];
				unsafe
				{
					var ptr = (IntPtr*)_handle->CommandBuffers;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new CommandBuffer ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->CommandBufferCount = 0;
					_handle->CommandBuffers = IntPtr.Zero;
					return;
				}
				_handle->CommandBufferCount = (uint)value.Length;
				_handle->CommandBuffers = Marshal.AllocHGlobal ((int)(sizeof(IntPtr)*value.Length));
				unsafe
				{
					var ptr = (IntPtr*)_handle->CommandBuffers;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint SignalSemaphoreCount {
			get { return _handle->SignalSemaphoreCount; }
			set { _handle->SignalSemaphoreCount = value; }
		}

		public Semaphore[] SignalSemaphores {
			get {
				if (_handle->SignalSemaphoreCount == 0)
					return null;
				var values = new Semaphore [_handle->SignalSemaphoreCount];
				unsafe
				{
					var ptr = (ulong*)_handle->SignalSemaphores;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SignalSemaphoreCount = 0;
					_handle->SignalSemaphores = IntPtr.Zero;
					return;
				}
				_handle->SignalSemaphoreCount = (uint)value.Length;
				_handle->SignalSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->SignalSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}
		public Interop.SubmitInfo* _handle;

		public SubmitInfo ()
		{
			_handle = (Interop.SubmitInfo*) Interop.Structure.Allocate (typeof (Interop.SubmitInfo));
			Initialize ();
		}

		public SubmitInfo (Interop.SubmitInfo* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.SubmitInfo;
		}

	}

	public unsafe class DisplayPropertiesKhr
	{
		DisplayKhr lDisplay;
		public DisplayKhr Display {
			get { return lDisplay; }
			set { lDisplay = value; _handle->Display = (ulong)value._handle; }
		}

		public string DisplayName {
			get { return Marshal.PtrToStringAnsi (_handle->DisplayName); }
			set { _handle->DisplayName = Marshal.StringToHGlobalAnsi (value); }
		}

		public Extent2D PhysicalDimensions {
			get { return _handle->PhysicalDimensions; }
			set { _handle->PhysicalDimensions = value; }
		}

		public Extent2D PhysicalResolution {
			get { return _handle->PhysicalResolution; }
			set { _handle->PhysicalResolution = value; }
		}

		public SurfaceTransformFlagsKhr SupportedTransforms {
			get { return _handle->SupportedTransforms; }
			set { _handle->SupportedTransforms = value; }
		}

		public bool PlaneReorderPossible {
			get { return _handle->PlaneReorderPossible; }
			set { _handle->PlaneReorderPossible = value; }
		}

		public bool PersistentContent {
			get { return _handle->PersistentContent; }
			set { _handle->PersistentContent = value; }
		}
		public Interop.DisplayPropertiesKhr* _handle;

		public DisplayPropertiesKhr ()
		{
			_handle = (Interop.DisplayPropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPropertiesKhr));
			Initialize ();
		}

		public DisplayPropertiesKhr (Interop.DisplayPropertiesKhr* ptr)
		{
			_handle = ptr;
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
			set { lCurrentDisplay = value; _handle->CurrentDisplay = (ulong)value._handle; }
		}

		public uint CurrentStackIndex {
			get { return _handle->CurrentStackIndex; }
			set { _handle->CurrentStackIndex = value; }
		}
		public Interop.DisplayPlanePropertiesKhr* _handle;

		public DisplayPlanePropertiesKhr ()
		{
			_handle = (Interop.DisplayPlanePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPlanePropertiesKhr));
			Initialize ();
		}

		public DisplayPlanePropertiesKhr (Interop.DisplayPlanePropertiesKhr* ptr)
		{
			_handle = ptr;
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
			set { lDisplayMode = value; _handle->DisplayMode = (ulong)value._handle; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return _handle->Parameters; }
			set { _handle->Parameters = value; }
		}
		public Interop.DisplayModePropertiesKhr* _handle;

		public DisplayModePropertiesKhr ()
		{
			_handle = (Interop.DisplayModePropertiesKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModePropertiesKhr));
			Initialize ();
		}

		public DisplayModePropertiesKhr (Interop.DisplayModePropertiesKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
		}

	}

	public unsafe class DisplayModeCreateInfoKhr
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public DisplayModeParametersKhr Parameters {
			get { return _handle->Parameters; }
			set { _handle->Parameters = value; }
		}
		public Interop.DisplayModeCreateInfoKhr* _handle;

		public DisplayModeCreateInfoKhr ()
		{
			_handle = (Interop.DisplayModeCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayModeCreateInfoKhr));
			Initialize ();
		}

		public DisplayModeCreateInfoKhr (Interop.DisplayModeCreateInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DisplayModeCreateInfoKhr;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		DisplayModeKhr lDisplayMode;
		public DisplayModeKhr DisplayMode {
			get { return lDisplayMode; }
			set { lDisplayMode = value; _handle->DisplayMode = (ulong)value._handle; }
		}

		public uint PlaneIndex {
			get { return _handle->PlaneIndex; }
			set { _handle->PlaneIndex = value; }
		}

		public uint PlaneStackIndex {
			get { return _handle->PlaneStackIndex; }
			set { _handle->PlaneStackIndex = value; }
		}

		public SurfaceTransformFlagsKhr Transform {
			get { return _handle->Transform; }
			set { _handle->Transform = value; }
		}

		public float GlobalAlpha {
			get { return _handle->GlobalAlpha; }
			set { _handle->GlobalAlpha = value; }
		}

		public DisplayPlaneAlphaFlagsKhr AlphaMode {
			get { return _handle->AlphaMode; }
			set { _handle->AlphaMode = value; }
		}

		public Extent2D ImageExtent {
			get { return _handle->ImageExtent; }
			set { _handle->ImageExtent = value; }
		}
		public Interop.DisplaySurfaceCreateInfoKhr* _handle;

		public DisplaySurfaceCreateInfoKhr ()
		{
			_handle = (Interop.DisplaySurfaceCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplaySurfaceCreateInfoKhr));
			Initialize ();
		}

		public DisplaySurfaceCreateInfoKhr (Interop.DisplaySurfaceCreateInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DisplaySurfaceCreateInfoKhr;
		}

	}

	public unsafe class DisplayPresentInfoKhr
	{
		public Rect2D SrcRect {
			get { return _handle->SrcRect; }
			set { _handle->SrcRect = value; }
		}

		public Rect2D DstRect {
			get { return _handle->DstRect; }
			set { _handle->DstRect = value; }
		}

		public bool Persistent {
			get { return _handle->Persistent; }
			set { _handle->Persistent = value; }
		}
		public Interop.DisplayPresentInfoKhr* _handle;

		public DisplayPresentInfoKhr ()
		{
			_handle = (Interop.DisplayPresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.DisplayPresentInfoKhr));
			Initialize ();
		}

		public DisplayPresentInfoKhr (Interop.DisplayPresentInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DisplayPresentInfoKhr;
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
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		SurfaceKhr lSurface;
		public SurfaceKhr Surface {
			get { return lSurface; }
			set { lSurface = value; _handle->Surface = (ulong)value._handle; }
		}

		public uint MinImageCount {
			get { return _handle->MinImageCount; }
			set { _handle->MinImageCount = value; }
		}

		public Format ImageFormat {
			get { return _handle->ImageFormat; }
			set { _handle->ImageFormat = value; }
		}

		public ColorSpaceKhr ImageColorSpace {
			get { return _handle->ImageColorSpace; }
			set { _handle->ImageColorSpace = value; }
		}

		public Extent2D ImageExtent {
			get { return _handle->ImageExtent; }
			set { _handle->ImageExtent = value; }
		}

		public uint ImageArrayLayers {
			get { return _handle->ImageArrayLayers; }
			set { _handle->ImageArrayLayers = value; }
		}

		public ImageUsageFlags ImageUsage {
			get { return _handle->ImageUsage; }
			set { _handle->ImageUsage = value; }
		}

		public SharingMode ImageSharingMode {
			get { return _handle->ImageSharingMode; }
			set { _handle->ImageSharingMode = value; }
		}

		public uint QueueFamilyIndexCount {
			get { return _handle->QueueFamilyIndexCount; }
			set { _handle->QueueFamilyIndexCount = value; }
		}

		public uint[] QueueFamilyIndices {
			get {
				if (_handle->QueueFamilyIndexCount == 0)
					return null;
				var values = new uint [_handle->QueueFamilyIndexCount];
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->QueueFamilyIndexCount = 0;
					_handle->QueueFamilyIndices = IntPtr.Zero;
					return;
				}
				_handle->QueueFamilyIndexCount = (uint)value.Length;
				_handle->QueueFamilyIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->QueueFamilyIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public SurfaceTransformFlagsKhr PreTransform {
			get { return _handle->PreTransform; }
			set { _handle->PreTransform = value; }
		}

		public CompositeAlphaFlagsKhr CompositeAlpha {
			get { return _handle->CompositeAlpha; }
			set { _handle->CompositeAlpha = value; }
		}

		public PresentModeKhr PresentMode {
			get { return _handle->PresentMode; }
			set { _handle->PresentMode = value; }
		}

		public bool Clipped {
			get { return _handle->Clipped; }
			set { _handle->Clipped = value; }
		}

		SwapchainKhr lOldSwapchain;
		public SwapchainKhr OldSwapchain {
			get { return lOldSwapchain; }
			set { lOldSwapchain = value; _handle->OldSwapchain = (ulong)value._handle; }
		}
		public Interop.SwapchainCreateInfoKhr* _handle;

		public SwapchainCreateInfoKhr ()
		{
			_handle = (Interop.SwapchainCreateInfoKhr*) Interop.Structure.Allocate (typeof (Interop.SwapchainCreateInfoKhr));
			Initialize ();
		}

		public SwapchainCreateInfoKhr (Interop.SwapchainCreateInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.SwapchainCreateInfoKhr;
		}

	}

	public unsafe class PresentInfoKhr
	{
		public uint WaitSemaphoreCount {
			get { return _handle->WaitSemaphoreCount; }
			set { _handle->WaitSemaphoreCount = value; }
		}

		public Semaphore[] WaitSemaphores {
			get {
				if (_handle->WaitSemaphoreCount == 0)
					return null;
				var values = new Semaphore [_handle->WaitSemaphoreCount];
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new Semaphore ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->WaitSemaphoreCount = 0;
					_handle->WaitSemaphores = IntPtr.Zero;
					return;
				}
				_handle->WaitSemaphoreCount = (uint)value.Length;
				_handle->WaitSemaphores = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->WaitSemaphores;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint SwapchainCount {
			get { return _handle->SwapchainCount; }
			set { _handle->SwapchainCount = value; }
		}

		public SwapchainKhr[] Swapchains {
			get {
				if (_handle->SwapchainCount == 0)
					return null;
				var values = new SwapchainKhr [_handle->SwapchainCount];
				unsafe
				{
					var ptr = (ulong*)_handle->Swapchains;
					for (var i = 0; i < values.Length; i++) {
						values [i] = new SwapchainKhr ();
						values [i]._handle = ptr [i];
					}
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SwapchainCount = 0;
					_handle->Swapchains = IntPtr.Zero;
					return;
				}
				_handle->SwapchainCount = (uint)value.Length;
				_handle->Swapchains = Marshal.AllocHGlobal ((int)(sizeof(ulong)*value.Length));
				unsafe
				{
					var ptr = (ulong*)_handle->Swapchains;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i]._handle;
				}
			}
		}

		public uint[] ImageIndices {
			get {
				if (_handle->SwapchainCount == 0)
					return null;
				var values = new uint [_handle->SwapchainCount];
				unsafe
				{
					var ptr = (uint*)_handle->ImageIndices;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SwapchainCount = 0;
					_handle->ImageIndices = IntPtr.Zero;
					return;
				}
				_handle->SwapchainCount = (uint)value.Length;
				_handle->ImageIndices = Marshal.AllocHGlobal ((int)(sizeof(uint)*value.Length));
				unsafe
				{
					var ptr = (uint*)_handle->ImageIndices;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}

		public Result[] Results {
			get {
				if (_handle->SwapchainCount == 0)
					return null;
				var values = new Result [_handle->SwapchainCount];
				unsafe
				{
					var ptr = (Result*)_handle->Results;
					for (var i = 0; i < values.Length; i++) 
						values [i] = ptr [i];
				}
				return values;
			}

			set {
				if (value == null) {
					_handle->SwapchainCount = 0;
					_handle->Results = IntPtr.Zero;
					return;
				}
				_handle->SwapchainCount = (uint)value.Length;
				_handle->Results = Marshal.AllocHGlobal ((int)(sizeof(Result)*value.Length));
				unsafe
				{
					var ptr = (Result*)_handle->Results;
					for (var i = 0; i < value.Length; i++)
						ptr [i] = value [i];
				}
			}
		}
		public Interop.PresentInfoKhr* _handle;

		public PresentInfoKhr ()
		{
			_handle = (Interop.PresentInfoKhr*) Interop.Structure.Allocate (typeof (Interop.PresentInfoKhr));
			Initialize ();
		}

		public PresentInfoKhr (Interop.PresentInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PresentInfoKhr;
		}

	}

	public unsafe class DebugReportCallbackCreateInfoExt
	{
		public DebugReportFlagsExt Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public IntPtr PfnCallback {
			get { return _handle->PfnCallback; }
			set { _handle->PfnCallback = value; }
		}

		public IntPtr UserData {
			get { return _handle->UserData; }
			set { _handle->UserData = value; }
		}
		public Interop.DebugReportCallbackCreateInfoExt* _handle;

		public DebugReportCallbackCreateInfoExt ()
		{
			_handle = (Interop.DebugReportCallbackCreateInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugReportCallbackCreateInfoExt));
			Initialize ();
		}

		public DebugReportCallbackCreateInfoExt (Interop.DebugReportCallbackCreateInfoExt* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DebugReportCallbackCreateInfoExt;
		}

	}

	public unsafe class PipelineRasterizationStateRasterizationOrderAmd
	{
		public RasterizationOrderAmd RasterizationOrder {
			get { return _handle->RasterizationOrder; }
			set { _handle->RasterizationOrder = value; }
		}
		public Interop.PipelineRasterizationStateRasterizationOrderAmd* _handle;

		public PipelineRasterizationStateRasterizationOrderAmd ()
		{
			_handle = (Interop.PipelineRasterizationStateRasterizationOrderAmd*) Interop.Structure.Allocate (typeof (Interop.PipelineRasterizationStateRasterizationOrderAmd));
			Initialize ();
		}

		public PipelineRasterizationStateRasterizationOrderAmd (Interop.PipelineRasterizationStateRasterizationOrderAmd* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.PipelineRasterizationStateRasterizationOrderAmd;
		}

	}

	public unsafe class DebugMarkerObjectNameInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return _handle->ObjectType; }
			set { _handle->ObjectType = value; }
		}

		public ulong Object {
			get { return _handle->Object; }
			set { _handle->Object = value; }
		}

		public string ObjectName {
			get { return Marshal.PtrToStringAnsi (_handle->ObjectName); }
			set { _handle->ObjectName = Marshal.StringToHGlobalAnsi (value); }
		}
		public Interop.DebugMarkerObjectNameInfoExt* _handle;

		public DebugMarkerObjectNameInfoExt ()
		{
			_handle = (Interop.DebugMarkerObjectNameInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectNameInfoExt));
			Initialize ();
		}

		public DebugMarkerObjectNameInfoExt (Interop.DebugMarkerObjectNameInfoExt* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DebugMarkerObjectNameInfoExt;
		}

	}

	public unsafe class DebugMarkerObjectTagInfoExt
	{
		public DebugReportObjectTypeExt ObjectType {
			get { return _handle->ObjectType; }
			set { _handle->ObjectType = value; }
		}

		public ulong Object {
			get { return _handle->Object; }
			set { _handle->Object = value; }
		}

		public ulong TagName {
			get { return _handle->TagName; }
			set { _handle->TagName = value; }
		}

		public UIntPtr TagSize {
			get { return _handle->TagSize; }
			set { _handle->TagSize = value; }
		}

		public IntPtr Tag {
			get { return _handle->Tag; }
			set { _handle->Tag = value; }
		}
		public Interop.DebugMarkerObjectTagInfoExt* _handle;

		public DebugMarkerObjectTagInfoExt ()
		{
			_handle = (Interop.DebugMarkerObjectTagInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerObjectTagInfoExt));
			Initialize ();
		}

		public DebugMarkerObjectTagInfoExt (Interop.DebugMarkerObjectTagInfoExt* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DebugMarkerObjectTagInfoExt;
		}

	}

	public unsafe class DebugMarkerMarkerInfoExt
	{
		public string MarkerName {
			get { return Marshal.PtrToStringAnsi (_handle->MarkerName); }
			set { _handle->MarkerName = Marshal.StringToHGlobalAnsi (value); }
		}

		public float[] Color {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = _handle->Color [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->Color [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					_handle->Color [i] = 0;
			}
		}
		public Interop.DebugMarkerMarkerInfoExt* _handle;

		public DebugMarkerMarkerInfoExt ()
		{
			_handle = (Interop.DebugMarkerMarkerInfoExt*) Interop.Structure.Allocate (typeof (Interop.DebugMarkerMarkerInfoExt));
			Initialize ();
		}

		public DebugMarkerMarkerInfoExt (Interop.DebugMarkerMarkerInfoExt* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.DebugMarkerMarkerInfoExt;
		}

	}
}
