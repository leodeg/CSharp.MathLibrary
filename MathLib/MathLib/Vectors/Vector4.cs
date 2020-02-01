using LeoDeg.Math.Matrices;
using LeoDeg.MathLib;
using System;
using System.Collections;

namespace LeoDeg.Math.Vectors
{
	public class Vector4
	{
		public Vector4 (float x = 0, float y = 0, float z = 0, float w = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public Vector4 (Vector2 xy, Vector2 zw)
		{
			if (xy == null || zw == null)
				throw new ArgumentNullException ();

			x = xy.x;
			y = xy.y;
			z = zw.x;
			w = zw.y;
		}

		public Vector4 (Vector3 vector)
		{
			if (vector == null)
				throw new ArgumentNullException ();

			x = vector.x;
			y = vector.y;
			z = vector.z;
			w = 0;
		}

		public Vector4 (Vector4 vector)
		{
			if (vector == null)
				throw new ArgumentNullException ();

			x = vector.x;
			y = vector.y;
			z = vector.z;
			w = vector.w;
		}

		public Vector4 (float[] vector4)
		{
			if (vector4.Length != 4)
				throw new InvalidOperationException ("Vector4::Error:: The array length not equal to 4.");

			x = vector4[0];
			y = vector4[1];
			z = vector4[2];
			w = vector4[3];
		}

		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
					case 3: return w;
					default: throw new ArgumentOutOfRangeException ();
				}
			}
			set
			{
				switch (index)
				{
					case 0: x = value; break;
					case 1: y = value; break;
					case 2: z = value; break;
					case 3: w = value; break;
					default: throw new ArgumentOutOfRangeException ();
				}
			}
		}

		public float x { get; set; }
		public float y { get; set; }
		public float z { get; set; }
		public float w { get; set; }

		public Vector3 ToVector3 ()
		{
			return new Vector3 (x, y, z);
		}

		public float[] ToArray ()
		{
			return new float[] { x, y, z, w };
		}

		public static float Dot (Vector4 a, Vector4 b)
		{
			return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
		}

		public float Dot (Vector4 other)
		{
			return Dot (this, other);
		}

		public static float Magnitude (Vector4 a, Vector4 b)
		{
			return LeoMath.Sqrt (Dot (a, b));
		}

		public float Magnitude (Vector4 b)
		{
			return LeoMath.Sqrt (Dot (this, b));
		}

		public override string ToString ()
		{
			return string.Format ("<{0}, {1}, {2}, {3}>", x, y, z, w);
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Vector4 && this.Equals ((Vector4)obj);
		}

		public bool Equals (Vector4 other)
		{
			if (ReferenceEquals (null, other)) return false;
			if (ReferenceEquals (this, other)) return true;

			return x.Equals (other.x) &&
				y.Equals (other.y) &&
				z.Equals (other.z) &&
				w.Equals (other.w);
		}

		public static Vector4 operator + (Vector4 a, Vector4 b)
		{
			return new Vector4 (a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}

		public static Vector4 operator - (Vector4 a, Vector4 b)
		{
			return new Vector4 (a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}

		public static Vector4 operator - (Vector4 a)
		{
			return new Vector4 (-a.x, -a.y, -a.z, -a.w);
		}

		public static Vector4 operator * (Vector4 a, float scalar)
		{
			return new Vector4 (a.x * scalar, a.y * scalar, a.z * scalar, a.w * scalar);
		}

		public static Vector4 operator * (float scalar, Vector4 a)
		{
			return new Vector4 (a.x * scalar, a.y * scalar, a.z * scalar, a.w * scalar);
		}

		public static Vector4 operator / (Vector4 a, float scalar)
		{
			scalar = 1.0f / scalar;
			return new Vector4 (a.x * scalar, a.y * scalar, a.z * scalar, a.w * scalar);
		}

		public static bool operator == (Vector4 a, Vector4 b)
		{
			return a.Equals (b);
		}

		public static bool operator != (Vector4 a, Vector4 b)
		{
			return !a.Equals (b);
		}
	}
}
