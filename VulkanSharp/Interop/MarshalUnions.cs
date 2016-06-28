using System;
using System.Runtime.InteropServices;

namespace VulkanSharp.Interop
{
	[StructLayout (LayoutKind.Explicit)]
	internal partial struct ClearColorValue
	{
		[FieldOffset (0)] internal unsafe fixed float Float32[4];
		[FieldOffset (0)] internal unsafe fixed Int32 Int32[4];
		[FieldOffset (0)] internal unsafe fixed UInt32 Uint32[4];
	}

	[StructLayout (LayoutKind.Explicit)]
	internal partial struct ClearValue
	{
		[FieldOffset (0)] internal ClearColorValue Color;
		[FieldOffset (0)] internal ClearDepthStencilValue DepthStencil;
	}
}
