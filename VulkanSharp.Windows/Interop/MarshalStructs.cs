using System;

namespace VulkanSharp.Windows.Interop
{
	// ReSharper disable InconsistentNaming
	internal struct Win32SurfaceCreateInfoKhr
	{
		internal StructureType SType;
		internal IntPtr Next;
		internal uint Flags;
		internal IntPtr Hinstance;
		internal IntPtr Hwnd;
	}
}