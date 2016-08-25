using System.Runtime.InteropServices;

namespace VulkanSharp
{
	public static class Commands
	{
		public static LayerProperties[] EnumerateInstanceLayerProperties ()
		{
		    unsafe {
				uint pPropertyCount;
				var result = Interop.NativeMethods.vkEnumerateInstanceLayerProperties (&pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				var size = Marshal.SizeOf (typeof (Interop.LayerProperties));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkEnumerateInstanceLayerProperties (&pPropertyCount, (Interop.LayerProperties*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new LayerProperties [pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr [i] = new LayerProperties (&((Interop.LayerProperties*)ptrpProperties) [i]);
				}

				return arr;
			}
		}

		public static ExtensionProperties[] EnumerateInstanceExtensionProperties (string pLayerName)
		{
		    unsafe {
				uint pPropertyCount;
				var result = Interop.NativeMethods.vkEnumerateInstanceExtensionProperties (pLayerName, &pPropertyCount, null);
				if (result != Result.Success)
					throw new ResultException (result);
				if (pPropertyCount <= 0)
					return null;

				var size = Marshal.SizeOf (typeof (Interop.ExtensionProperties));
				var ptrpProperties = Marshal.AllocHGlobal ((int)(size * pPropertyCount));
				result = Interop.NativeMethods.vkEnumerateInstanceExtensionProperties (pLayerName, &pPropertyCount, (Interop.ExtensionProperties*)ptrpProperties);
				if (result != Result.Success)
					throw new ResultException (result);

				if (pPropertyCount <= 0)
					return null;
				var arr = new ExtensionProperties [pPropertyCount];
				for (var i = 0; i < pPropertyCount; i++) {
					arr [i] = new ExtensionProperties (&((Interop.ExtensionProperties*)ptrpProperties) [i]);
				}

				return arr;
			}
		}
	}
}
