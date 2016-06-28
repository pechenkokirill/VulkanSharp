using System.Runtime.InteropServices;

namespace VulkanSharp.Interop
{
	[StructLayout (LayoutKind.Explicit)]
	public struct ClearColorValue
	{
		[FieldOffset (0)] public unsafe fixed float Float32[4];
		[FieldOffset (0)] public unsafe fixed int Int32[4];
		[FieldOffset (0)] public unsafe fixed uint Uint32[4];
	}

	[StructLayout (LayoutKind.Explicit)]
	public struct ClearValue
	{
		[FieldOffset (0)] public ClearColorValue Color;
		[FieldOffset (0)] public ClearDepthStencilValue DepthStencil;
	}
}
