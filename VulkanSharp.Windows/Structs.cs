using System;
using VulkanSharp.Interop;

namespace VulkanSharp.Windows
{
	public unsafe class Win32SurfaceCreateInfoKhr
	{
		public uint Flags {
			get { return _m->Flags; }
			set { _m->Flags = value; }
		}

		public IntPtr Hinstance {
			get { return _m->Hinstance; }
			set { _m->Hinstance = value; }
		}

		public IntPtr Hwnd {
			get { return _m->Hwnd; }
			set { _m->Hwnd = value; }
		}
		internal Interop.Win32SurfaceCreateInfoKhr* _m;

		public Win32SurfaceCreateInfoKhr ()
		{
			_m = (Interop.Win32SurfaceCreateInfoKhr*) Structure.Allocate (typeof (Interop.Win32SurfaceCreateInfoKhr));
			Initialize ();
		}

		internal Win32SurfaceCreateInfoKhr (Interop.Win32SurfaceCreateInfoKhr* ptr)
		{
			_m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			_m->SType = StructureType.Win32SurfaceCreateInfoKhr;
		}

	}

}
