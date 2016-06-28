using System;

namespace VulkanSharp
{
	public unsafe partial class ClearColorValue
	{
		public float[] Float32 {
			get {
				var arr = new float [4];
				for (var i = 0; i < 4; i++)
					arr [i] = m->Float32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->Float32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					m->Float32 [i] = 0;
			}
		}

		public int[] Int32 {
			get {
				var arr = new int [4];
				for (var i = 0; i < 4; i++)
					arr [i] = m->Int32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->Int32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					m->Int32 [i] = 0;
			}
		}

		public uint[] Uint32 {
			get {
				var arr = new uint [4];
				for (var i = 0; i < 4; i++)
					arr [i] = m->Uint32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (var i = 0; i < value.Length; i++)
					m->Uint32 [i] = value [i];
				for (var i = value.Length; i < 4; i++)
					m->Uint32 [i] = 0;
			}
		}
		public Interop.ClearColorValue* m;

		public ClearColorValue ()
		{
			m = (Interop.ClearColorValue*) Interop.Structure.Allocate (typeof (Interop.ClearColorValue));
		}

		public ClearColorValue (Interop.ClearColorValue* ptr)
		{
			m = ptr;
		}

	}

	public unsafe class ClearValue
	{
		ClearColorValue _lColor;
		public ClearColorValue Color {
			get { return _lColor; }
			set { _lColor = value; m->Color = *value.m; }
		}

		public ClearDepthStencilValue DepthStencil {
			get { return m->DepthStencil; }
			set { m->DepthStencil = value; }
		}
		public Interop.ClearValue* m;

		public ClearValue ()
		{
			m = (Interop.ClearValue*) Interop.Structure.Allocate (typeof (Interop.ClearValue));
			Initialize ();
		}

		public ClearValue (Interop.ClearValue* ptr)
		{
			m = ptr;
			Initialize ();
		}


		public void Initialize ()
		{
			_lColor = new ClearColorValue (&m->Color);
		}

	}
}
