using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.MathLib
{
	public struct Vector3
	{
		public Vector3 (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3 (float[] arr)
		{
			x = arr[0];
			y = arr[1];
			z = arr[2];
		}

		public Vector3 (Vector2 vector)
		{
			x = vector.x;
			y = vector.y;
			z = 0;
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
					default: throw new ArgumentOutOfRangeException ();
				}
			}
		}

		public float x { get; set; }
		public float y { get; set; }
		public float z { get; set; }

		/// <summary>
		/// Vector3 (0f,1f,0f)
		/// </summary>
		public Vector3 up => new Vector3 (0f, 1f, 0f);

		/// <summary>
		/// Vector3 (0f,-1f,0f)
		/// </summary>
		public Vector3 down => new Vector3 (0f, -1f, 0f);

		/// <summary>
		/// Vector3 (-1f,0f,0f)
		/// </summary>
		public Vector3 left => new Vector3 (-1f, 0f, 0f);

		/// <summary>
		/// Vector3 (1f,0f,0f)
		/// </summary>
		public Vector3 right => new Vector3 (1f, 0f, 0f);

		/// <summary>
		/// Vector3 (0f,0f,1f)
		/// </summary>
		public Vector3 forward => new Vector3 (0f, 0f, 1f);

		/// <summary>
		/// Vector3 (0f,0f,-1f)
		/// </summary>
		public Vector3 backward => new Vector3 (0f, 0f, -1f);

		/// <summary>
		/// Return current vector in unit form.
		/// </summary>
		public Vector3 normalized => Normalize (this);

		/// <summary>
		/// Return magnitude of the current vector.
		/// </summary>
		public float magnitude => Magnitude (this);


		#region Vector3 Methods

		/// <summary>
		/// Make vector a unit vector.
		/// </summary>
		public static Vector3 Normalize (Vector3 v)
		{
			return ( v / Magnitude (v) );
		}

		/// <summary>
		/// Return angle between two vectors.
		/// </summary>
		public static float Angle (Vector3 from, Vector3 to)
		{
			float magnitude = Magnitude (from) * Magnitude (to);
			float dot = Dot (from, to);
			return dot / magnitude;
		}

		/// <summary>
		/// Return dot product of two vectors.
		/// </summary>
		public static float Dot (Vector3 a, Vector3 b)
		{
			return ( a.x * b.x ) + ( a.y * b.y ) + ( a.z * b.z );
		}

		/// <summary>
		/// Return dot product of the vector (v).
		/// </summary>
		public static float Dot (Vector3 v)
		{
			return ( v.x * v.x ) + ( v.y * v.y ) + ( v.z * v.z );
		}

		/// <summary>
		/// Return dot product of three values.
		/// </summary>
		public static float Dot (float x, float y, float z)
		{
			return ( x * x ) + ( y * y ) + ( z * z );
		}

		/// <summary>
		/// Return cross product between two vectors.
		/// </summary>
		public static Vector3 Cross (Vector3 from, Vector3 to)
		{
			return new Vector3
			(
				from.y * to.z - from.z * to.y,
				from.z * to.x - from.x * to.z,
				from.x * to.y - from.y * to.x

			);
		}

		/// <summary>
		/// Return magnitude (speed) of two vectors
		/// </summary>
		public static float Magnitude (Vector3 a, Vector3 b)
		{
			return (float)Math.Sqrt (Dot (a, b));
		}

		/// <summary>
		/// Return magnitude (speed) of a vector.
		/// </summary>
		public static float Magnitude (Vector3 v)
		{
			return (float)Math.Sqrt (Dot (v));
		}

		/// <summary>
		/// Make projection of vector a onto vector b.
		/// <para>((a * b) / b^2) * b</para>
		/// </summary>
		public static Vector3 Project (Vector3 a, Vector3 b)
		{
			return b * ( Dot (a, b) / Dot (b, b) );
		}

		/// <summary>
		/// Make perpendicular vector from vector a to vector b.
		/// <para>a - (((a * b) / b^2 ) * b)</para>
		/// </summary>
		public static Vector3 Reject (Vector3 a, Vector3 b)
		{
			return a - ( b * ( Dot (a, b) / Dot (b, b) ) );
		}

		/// <summary>
		/// Return distance between 'from' and 'to'.
		/// </summary>
		public static float Distance (Vector3 from, Vector3 to)
		{
			float distX = to.x - from.x;
			float distY = to.y - from.y;
			float distZ = to.z - from.z;

			return (float)Math.Sqrt (Dot (distX, distY, distZ));
		}

		/// <summary>
		/// Return distance from current position and 'to'.
		/// </summary>
		public float Distance (Vector3 to)
		{
			return Distance (this, to);
		}

		/// <summary>
		/// Return direction vector between two vectors.
		/// </summary>
		public static Vector3 Direction (Vector3 from, Vector3 to)
		{
			return to - from;
		}

		#endregion

		#region Operators Overloading

		public static Vector3 operator + (Vector3 a, Vector3 b)
		{
			return new Vector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3 operator - (Vector3 a, Vector3 b)
		{
			return new Vector3 (a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3 operator - (Vector3 a)
		{
			return new Vector3 (-a.x, -a.y, -a.z);
		}

		public static Vector3 operator * (Vector3 a, float scalar)
		{
			return new Vector3 (a.x * scalar, a.y * scalar, a.z * scalar);
		}

		public static Vector3 operator * (float scalar, Vector3 a)
		{
			return new Vector3 (a.x * scalar, a.y * scalar, a.z * scalar);
		}

		public static Vector3 operator * (Matrice3 m, Vector3 v)
		{
			return new Vector3
			(
				m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z,
				m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z,
				m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z
			);
		}

		public static Vector3 operator / (Vector3 a, float scalar)
		{
			scalar = 1.0f / scalar;
			return new Vector3 (a.x * scalar, a.y * scalar, a.z * scalar);
		}

		#endregion
	}
}
