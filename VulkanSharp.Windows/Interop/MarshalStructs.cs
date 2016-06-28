using System;

namespace VulkanSharp.Windows.Interop
{
	internal partial struct Win32SurfaceCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal UInt32 Flags;
		internal IntPtr Hinstance;
		internal IntPtr Hwnd;
	}

}
