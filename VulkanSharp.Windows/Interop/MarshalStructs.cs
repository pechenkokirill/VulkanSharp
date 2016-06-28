using System;

namespace VulkanSharp.Windows.Interop
{
	// ReSharper disable InconsistentNaming
	public struct Win32SurfaceCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public uint Flags;
		public IntPtr Hinstance;
		public IntPtr Hwnd;
	}
}