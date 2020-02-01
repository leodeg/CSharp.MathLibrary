using System;
using LeoDeg.Math.Matrices;
using LeoDeg.MathLib;

namespace LeoDeg.Math.Vectors
{
	public class Vector3
	{
		public static readonly Vector3 Up = new Vector3 (0, 1, 0);
		public static readonly Vector3 Down = new Vector3 (0, -1, 0);
		public static readonly Vector3 Left = new Vector3 (-1, 0, 0);
		public static readonly Vector3 Right = new Vector3 (1, 0, 0);
		public static readonly Vector3 Forward = new Vector3 (0, 0, 1);
		public static readonly Vector3 Backward = new Vector3 (0, 0, -1);
		public static readonly Vector3 Zero = new Vector3 (0, 0, 0);
		public static readonly Vector3 Identity = new Vector3 (1, 1, 1);

		public Vector3 (float x = 0, float y = 0, float z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3 (Vector2 vector)
		{
			if (vector == null)
				throw new ArgumentNullException ();

			x = vector.x;
			y = vector.y;
			z = 0;
		}

		public Vector3 (Vector3 vector)
		{
			if (vector == null)
				throw new ArgumentNullException ();

			x = vector.x;
			y = vector.y;
			z = vector.z;
		}

		public Vector3 (float[] vector3)
		{
			if (vector3.Length != 3)
				throw new InvalidOperationException ("Vector3::Error:: The array length not equal to 3.");

			x = vector3[0];
			y = vector3[1];
			z = vector3[2];
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
		/// Return current vector in unit form.
		/// </summary>
		public Vector3 normalized => Normalize (this);

		/// <summary>
		/// Return magnitude of the current vector.
		/// </summary>
		public float magnitude => Magnitude (this);

		/// <summary>
		/// Make vector a unit vector.
		/// </summary>
		public static Vector3 Normalize (Vector3 vector)
		{
			return vector / Magnitude (vector);
		}

		public static float Dot (Vector3 a, Vector3 b)
		{
			return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
		}

		public static float Dot (Vector3 v)
		{
			return (v.x * v.x) + (v.y * v.y) + (v.z * v.z);
		}

		public static float Dot (float x, float y, float z)
		{
			return (x * x) + (y * y) + (z * z);
		}

		public static Vector3 Cross (Vector3 from, Vector3 to)
		{
			return new Vector3
			(
				from.y * to.z - from.z * to.y,
				from.z * to.x - from.x * to.z,
				from.x * to.y - from.y * to.x

			);
		}

		public static float Magnitude (Vector3 a, Vector3 b)
		{
			return LeoMath.Sqrt (Dot (a, b));
		}


		public static float Magnitude (Vector3 v)
		{
			return LeoMath.Sqrt (Dot (v));
		}

		public static float Distance (Vector3 from, Vector3 to)
		{
			float distX = to.x - from.x;
			float distY = to.y - from.y;
			float distZ = to.z - from.z;

			return LeoMath.Sqrt (Dot (distX, distY, distZ));
		}


		public float Distance (Vector3 to)
		{
			float distX = to.x - this.x;
			float distY = to.y - this.y;
			float distZ = to.z - this.z;

			return LeoMath.Sqrt (Dot (distX, distY, distZ));
		}

		public static Vector3 Direction (Vector3 from, Vector3 to)
		{
			return to - from;
		}

		static public Vector3 LookAt (Vector3 forwardVector, Vector3 current, Vector3 target)
		{
			Vector3 direction = new Vector3 (
				target.x - current.x,
				target.y - current.y,
				target.z - current.z);

			float angle = Vector3.AngleRad (forwardVector, direction);

			bool clockwise = false;
			if (Vector3.Cross (forwardVector, direction).z < 0)
				clockwise = true;

			return Vector3.Rotate (forwardVector, angle, clockwise);
		}

		/// <summary>
		/// Rotate vector and by using radians.
		/// </summary>
		static public Vector3 Rotate (Vector3 vector, float angle, bool clockwise) //in radians
		{
			if (clockwise)
				angle = Convert.ToSingle (2 * System.Math.PI - angle);

			float xVal = Convert.ToSingle (vector.x * System.Math.Cos (angle) - vector.y * System.Math.Sin (angle));
			float yVal = Convert.ToSingle (vector.x * System.Math.Sin (angle) + vector.y * System.Math.Cos (angle));

			return new Vector3 (xVal, yVal, 0);
		}

		/// <summary>
		/// Return angle in degrees between two vectors.
		/// </summary>
		public static float Angle (Vector3 a, Vector3 b)
		{
			float angle = Dot (a, b) / (a.magnitude * b.magnitude);
			double toDegrees = 180 / System.Math.PI;
			return Convert.ToSingle (System.Math.Acos (angle) * toDegrees);
		}

		/// <summary>
		/// Return angle in rad between two vectors.
		/// </summary>
		public static float AngleRad (Vector3 a, Vector3 b)
		{
			float angle = Dot (a, b) / (a.magnitude * b.magnitude);
			return Convert.ToSingle (System.Math.Acos (angle));
		}

		/// <summary>
		/// Check angle type: (0) is right angle, (1) is acute angle, (-1) is obtuse angle.
		/// </summary>
		/// <returns>
		/// (0) - is right angle
		/// (1) - is acute angle, 
		/// (-1) - is obtuse angle.
		/// </returns>
		public static int AngleType (Vector3 a, Vector3 b)
		{
			float angle = Dot (a, b);
			if (angle == 0) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		static public Vector3 Translate (Vector3 start, Vector3 facing, Vector3 direction)
		{
			if (Distance (direction, new Vector3 (0, 0, 0)) <= 0) return start;
			float angle = AngleRad (direction, facing);
			float worldAngle = AngleRad (direction, new Vector3 (0, 1, 0));

			bool clockwise = false;
			if (Cross (direction, facing).z < 0)
				clockwise = true;

			direction = Rotate (direction, angle + worldAngle, clockwise);
			return new Vector3 (
				start.x + direction.x,
				start.y + direction.y,
				start.z + direction.z);
		}

		static public Vector3 Translate (Vector3 start, Vector3 vector)
		{
			if (Vector3.Distance (vector, new Vector3 (0, 0, 0)) <= 0) return start;
			return start + vector;
		}

		/// <summary>
		/// Make projection of vector a onto vector b.
		/// <para>((a * b) / b^2) * b</para>
		/// </summary>
		public static Vector3 Project (Vector3 a, Vector3 b)
		{
			return b * (Dot (a, b) / Dot (b, b));
		}

		/// <summary>
		/// Make perpendicular vector from vector a to vector b.
		/// <para>a - (((a * b) / b^2 ) * b)</para>
		/// </summary>
		public static Vector3 Reject (Vector3 a, Vector3 b)
		{
			return a - (b * (Dot (a, b) / Dot (b, b)));
		}

		public static Vector3 Perp (Vector3 vector)
		{
			return new Vector3 (vector.y, -vector.x);
		}

		public Vector3 Perp ()
		{
			return Perp (this);
		}


		public Vector2 ToVector2 ()
		{
			return new Vector2 (x, y);
		}

		public Vector4 ToVector4 ()
		{
			return new Vector4 (x, y, z, 0);
		}

		public float[] ToArray ()
		{
			return new float[] { x, y, z };
		}

		public override string ToString ()
		{
			return string.Format ("<{0}, {1}, {2}>", x, y, z);
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Vector3 && this.Equals ((Vector3)obj);
		}

		/// <summary>
		/// Compares the passed vector to this one for equality.
		/// </summary>
		public bool Equals (Vector3 other)
		{
			if (ReferenceEquals (null, other)) return false;
			if (ReferenceEquals (this, other)) return true;

			return x.Equals (other.x) && y.Equals (other.y) && z.Equals (other.z);
		}

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

		public static bool operator == (Vector3 a, Vector3 b)
		{
			return a.Equals (b);
		}

		public static bool operator != (Vector3 a, Vector3 b)
		{
			return !a.Equals (b);
		}
	}
}
