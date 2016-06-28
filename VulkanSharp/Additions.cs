using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	public partial class Instance
	{
		public Instance (InstanceCreateInfo CreateInfo, AllocationCallbacks Allocator = null)
		{
			Result result;

			unsafe {
				fixed (IntPtr* ptrInstance = &_handle) {
					result = Interop.NativeMethods.vkCreateInstance (CreateInfo._handle, Allocator != null ? Allocator.Handle : null, ptrInstance);
				}
			}

			if (result != Result.Success)
				throw new ResultException (result);
		}

		public Instance () : this (new InstanceCreateInfo ())
		{
		}
	}

	public unsafe partial class ShaderModuleCreateInfo
	{
		public byte[] CodeBytes {
			set {
				/* todo free allocated memory when already set */
				if (value == null) {
					_handle->CodeSize = UIntPtr.Zero;
					_handle->Code = IntPtr.Zero;
					return;
				}
				_handle->CodeSize = (UIntPtr)value.Length;
				_handle->Code = Marshal.AllocHGlobal (value.Length);
				Marshal.Copy (value, 0, _handle->Code, value.Length);
			}
		}
	}

	public partial class Device
	{
		public ShaderModule CreateShaderModule (byte[] shaderCode, uint flags = 0, AllocationCallbacks allocator = null)
		{
			var createInfo = new ShaderModuleCreateInfo {
				CodeBytes = shaderCode,
				Flags = flags
			};
			return CreateShaderModule (createInfo, allocator);
		}
	}

	public partial class ClearColorValue
	{
		public ClearColorValue (float[] floatArray) : this ()
		{
			Float32 = floatArray;
		}

		public ClearColorValue (int[] intArray) : this ()
		{
			Int32 = intArray;
		}

		public ClearColorValue (uint[] uintArray) : this ()
		{
			Uint32 = uintArray;
		}
	}
}
