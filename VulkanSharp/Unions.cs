using System;

namespace VulkanSharp
{
	unsafe public partial class ClearColorValue
	{
		public float[] Float32 {
			get {
				var arr = new float [4];
				for (int i = 0; i < 4; i++)
					arr [i] = m->Float32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->Float32 [i] = value [i];
				for (int i = value.Length; i < 4; i++)
					m->Float32 [i] = 0;
			}
		}

		public Int32[] Int32 {
			get {
				var arr = new Int32 [4];
				for (int i = 0; i < 4; i++)
					arr [i] = m->Int32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->Int32 [i] = value [i];
				for (int i = value.Length; i < 4; i++)
					m->Int32 [i] = 0;
			}
		}

		public UInt32[] Uint32 {
			get {
				var arr = new UInt32 [4];
				for (int i = 0; i < 4; i++)
					arr [i] = m->Uint32 [i];
				return arr;
			}

			set {
				if (value.Length > 4)
					throw new Exception ("array too long");
				for (int i = 0; i < value.Length; i++)
					m->Uint32 [i] = value [i];
				for (int i = value.Length; i < 4; i++)
					m->Uint32 [i] = 0;
			}
		}
		internal Interop.ClearColorValue* m;

		public ClearColorValue ()
		{
			m = (Interop.ClearColorValue*) Interop.Structure.Allocate (typeof (Interop.ClearColorValue));
		}

		internal ClearColorValue (Interop.ClearColorValue* ptr)
		{
			m = ptr;
		}

	}

	unsafe public partial class ClearValue
	{
		ClearColorValue lColor;
		public ClearColorValue Color {
			get { return lColor; }
			set { lColor = value; m->Color = *value.m; }
		}

		public ClearDepthStencilValue DepthStencil {
			get { return m->DepthStencil; }
			set { m->DepthStencil = value; }
		}
		internal Interop.ClearValue* m;

		public ClearValue ()
		{
			m = (Interop.ClearValue*) Interop.Structure.Allocate (typeof (Interop.ClearValue));
			Initialize ();
		}

		internal ClearValue (Interop.ClearValue* ptr)
		{
			m = ptr;
			Initialize ();
		}


		internal void Initialize ()
		{
			lColor = new ClearColorValue (&m->Color);
		}

	}
}
