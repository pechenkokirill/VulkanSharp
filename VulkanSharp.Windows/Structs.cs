using System;
using VulkanSharp.Interop;

namespace VulkanSharp.Windows
{
	unsafe public partial class Win32SurfaceCreateInfoKhr
	{
		public UInt32 Flags {
			get { return m->Flags; }
			set { m->Flags = value; }
		}

		public IntPtr Hinstance {
			get { return m->Hinstance; }
			set { m->Hinstance = value; }
		}

		public IntPtr Hwnd {
			get { return m->Hwnd; }
			set { m->Hwnd = value; }
		}
		internal Windows.Interop.Win32SurfaceCreateInfoKhr* m;

		public Win32SurfaceCreateInfoKhr ()
		{
			m = (Windows.Interop.Win32SurfaceCreateInfoKhr*) Structure.Allocate (typeof (Windows.Interop.Win32SurfaceCreateInfoKhr));
			Initialize ();
		}

		internal Win32SurfaceCreateInfoKhr (Windows.Interop.Win32SurfaceCreateInfoKhr* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			m->SType = StructureType.Win32SurfaceCreateInfoKhr;
		}

	}

}
