using System.Runtime.InteropServices;

namespace VulkanSharp.Interop
{
	[StructLayout (LayoutKind.Explicit)]
	internal struct ClearColorValue
	{
		[FieldOffset (0)] internal unsafe fixed float Float32[4];
		[FieldOffset (0)] internal unsafe fixed int Int32[4];
		[FieldOffset (0)] internal unsafe fixed uint Uint32[4];
	}

	[StructLayout (LayoutKind.Explicit)]
	internal struct ClearValue
	{
		[FieldOffset (0)] internal ClearColorValue Color;
		[FieldOffset (0)] internal ClearDepthStencilValue DepthStencil;
	}
}
