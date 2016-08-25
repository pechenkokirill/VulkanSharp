using System;

namespace VulkanSharp
{
	public unsafe partial class ClearColorValue
	{
		public float[] Float32 {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = _handle->Float32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->Float32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					_handle->Float32 [i] = 0;
			}
		}

		public int[] Int32 {
			get {
				var arr = new int [4];
				for (var i = 0; i < 4; i++)
					arr [i] = _handle->Int32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->Int32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					_handle->Int32 [i] = 0;
			}
		}

		public uint[] Uint32 {
			get {
				var arr = new uint [4];
				for (var i = 0; i < 4; i++)
					arr [i] = _handle->Uint32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					_handle->Uint32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					_handle->Uint32 [i] = 0;
			}
		}
		public Interop.ClearColorValue* _handle;

		public ClearColorValue ()
		{
			_handle = (Interop.ClearColorValue*) Interop.Structure.Allocate (typeof (Interop.ClearColorValue));
		}

		public ClearColorValue (Interop.ClearColorValue* ptr)
		{
			_handle = ptr;
		}

	}

	public unsafe class ClearValue
	{
		ClearColorValue _lColor;
		public ClearColorValue Color {
			get { return _lColor; }
			set { _lColor = value; _handle->Color = *value._handle; }
		}

		public ClearDepthStencilValue DepthStencil {
			get { return _handle->DepthStencil; }
			set { _handle->DepthStencil = value; }
		}
		public Interop.ClearValue* _handle;

		public ClearValue ()
		{
			_handle = (Interop.ClearValue*) Interop.Structure.Allocate (typeof (Interop.ClearValue));
			Initialize ();
		}

		public ClearValue (Interop.ClearValue* ptr)
		{
			_handle = ptr;
			Initialize ();
		}

		public void Initialize ()
		{
			_lColor = new ClearColorValue (&_handle->Color);
		}
	}
}
