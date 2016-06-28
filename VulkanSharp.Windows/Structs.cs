using System;
using VulkanSharp.Interop;

namespace VulkanSharp.Windows
{
	public unsafe class Win32SurfaceCreateInfoKhr
	{
		public uint Flags {
			get { return _handle->Flags; }
			set { _handle->Flags = value; }
		}

		public IntPtr Hinstance {
			get { return _handle->Hinstance; }
			set { _handle->Hinstance = value; }
		}

		public IntPtr Hwnd {
			get { return _handle->Hwnd; }
			set { _handle->Hwnd = value; }
		}
		public Interop.Win32SurfaceCreateInfoKhr* _handle;

		public Win32SurfaceCreateInfoKhr ()
		{
			_handle = (Interop.Win32SurfaceCreateInfoKhr*) Structure.Allocate (typeof (Interop.Win32SurfaceCreateInfoKhr));
			Initialize ();
		}

		public Win32SurfaceCreateInfoKhr (Interop.Win32SurfaceCreateInfoKhr* ptr)
		{
			_handle = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_handle->SType = StructureType.Win32SurfaceCreateInfoKhr;
		}

	}

}
