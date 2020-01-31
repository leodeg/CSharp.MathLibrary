using System;
using System.Collections;

namespace LeoDeg.Math.Vectors
{
	public class Vector2
	{
		public static readonly Vector2 Up = new Vector2 (0, 1);
		public static readonly Vector2 Down = new Vector2 (0, -1);
		public static readonly Vector2 Left = new Vector2 (-1, 0);
		public static readonly Vector2 Right = new Vector2 (1, 0);
		public static readonly Vector2 Zero = new Vector2 (0, 0);
		public static readonly Vector2 Identity = new Vector2 (1, 1);

		public Vector2 (float x = 0, float y = 0)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2 (Vector2 vector)
		{
			if (vector == null)
				throw new ArgumentNullException ();

			x = vector.x;
			y = vector.y;
		}

		public Vector2 (float[] vector2)
		{
			if (vector2.Length != 2)
				throw new ArgumentOutOfRangeException ();

			x = vector2[0];
			y = vector2[1];
		}

		public float this[int index]
		{
			get
			{
				if (index == 0) return x;
				else if (index == 1) return y;
				else throw new ArgumentOutOfRangeException ();
			}
			set
			{
				if (index == 0) x = value;
				else if (index == 1) y = value;
				else throw new ArgumentOutOfRangeException ();
			}
		}

		public float x { get; set; }
		public float y { get; set; }
		public Vector2 normalized { get { return this / magnitude; } }
		public float magnitude { get { return Convert.ToSingle (System.Math.Sqrt (Dot (this, this))); } }


		public static float Dot (Vector2 a, Vector2 b)
		{
			return (a.x * b.x) + (a.y * b.y);
		}

		public static float Dot (float x, float y)
		{
			return (x * x) + (y * y);
		}

		public float Dot (Vector2 vector)
		{
			return (this.x * vector.x) + (this.y * vector.y);
		}

		public static float Magnitude (Vector2 a, Vector2 b)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (a, b)));
		}

		public static float Magnitude (Vector2 vector)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (vector, vector)));
		}

		public static float Magnitude (float x, float y)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (x, y)));
		}

		/// <summary>
		/// Return a unit vector.
		/// </summary>
		public static Vector2 Normalize (Vector2 vector)
		{
			return vector / Magnitude (vector);
		}

		/// <summary>
		/// Return a unit vector of the current vector.
		/// </summary>
		public Vector2 Normalize ()
		{
			return this / Magnitude (this);
		}

		public static float Distance (Vector2 from, Vector2 to)
		{
			float distX = to.x - from.x;
			float distY = to.y - from.y;
			return Magnitude (distX, distY);
		}

		public float Distance (Vector2 target)
		{
			float distX = this.x - target.x;
			float distY = this.y - target.y;
			return Magnitude (distX, distY);
		}

		public static Vector2 Direction (Vector2 from, Vector2 to)
		{
			return to - from;
		}

		public Vector2 Direction (Vector2 target)
		{
			return new Vector2 (target.x - this.x, target.y - this.y);
		}

		public static float Angle (Vector2 from, Vector2 to)
		{
			float magnitude = Magnitude (from) * Magnitude (to);
			float dot = Dot (from, to);
			return dot / magnitude;
		}

		/// <summary>
		/// Check angle type: (0) is right angle, (1) is acute angle, (-1) is obtuse angle.
		/// </summary>
		/// <returns>
		/// (0) - is right angle
		/// (1) - is acute angle, 
		/// (-1) - is obtuse angle.
		/// </returns>
		public static int AngleType (Vector2 from, Vector2 to)
		{
			float angle = Angle (from, to);
			if (angle.Equals (0f)) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		/// <summary>
		/// Make projection of vector a onto vector b.
		/// <para>((a * b) / b^2) * b</para>
		/// </summary>
		public static Vector2 Project (Vector2 a, Vector2 b)
		{
			return b * (Dot (a, b) / Dot (b, b));
		}

		/// <summary>
		/// Make perpendicular vector from vector a to vector b.
		/// <para>a - (((a * b) / b^2 ) * b)</para>
		/// </summary>
		public static Vector2 Reject (Vector2 a, Vector2 b)
		{
			return a - (b * (Dot (a, b) / Dot (b, b)));
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Vector2 && this.Equals ((Vector2)obj);
		}

		public bool Equals (Vector2 other)
		{
			return x.Equals (other.x) && y.Equals (other.y);
		}

		public override int GetHashCode ()
		{
			return x.GetHashCode () ^ y.GetHashCode ();
		}

		public static Vector2 operator + (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.x + b.x, a.y + b.y);
		}

		public static Vector2 operator - (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.x - b.x, a.y - b.y);
		}

		public static Vector2 operator - (Vector2 a)
		{
			return new Vector2 (-a.x, -a.y);
		}

		public static Vector2 operator * (Vector2 a, float scalar)
		{
			return new Vector2 (a.x * scalar, a.y * scalar);
		}

		public static Vector2 operator * (float scalar, Vector2 a)
		{
			return new Vector2 (a.x * scalar, a.y * scalar);
		}


		public static Vector2 operator / (Vector2 a, float scalar)
		{
			scalar = 1f / scalar;
			return new Vector2 (a.x * scalar, a.y * scalar);
		}

		public static bool operator == (Vector2 a, Vector2 b)
		{
			return a.Equals (b);
		}

		public static bool operator != (Vector2 a, Vector2 b)
		{
			return !a.Equals (b);
		}
	}
}
