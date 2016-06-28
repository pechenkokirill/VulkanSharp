﻿using System;
using System.Runtime.InteropServices;

namespace VulkanSharp
{
	public partial class Instance
	{
		public Instance (InstanceCreateInfo CreateInfo, AllocationCallbacks Allocator = null)
		{
			Result result;

			unsafe {
				fixed (IntPtr* ptrInstance = &m) {
					result = Interop.NativeMethods.vkCreateInstance (CreateInfo.m, Allocator != null ? Allocator.Handle : null, ptrInstance);
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
					m->CodeSize = UIntPtr.Zero;
					m->Code = IntPtr.Zero;
					return;
				}
				m->CodeSize = (UIntPtr)value.Length;
				m->Code = Marshal.AllocHGlobal (value.Length);
				Marshal.Copy (value, 0, m->Code, value.Length);
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

	public unsafe partial class ClearColorValue
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
