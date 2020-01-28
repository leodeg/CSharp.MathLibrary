using System;
using System.Collections;

namespace LeoDeg.Math.Vectors
{
	public struct Vector2
	{
		/// <summary>
		/// Vector2(0, 1)
		/// </summary>
		public static readonly Vector2 Up = new Vector2 (0, 1);

		/// <summary>
		/// Vector2(0, -1)
		/// </summary>
		public static readonly Vector2 Down = new Vector2 (0, -1);

		/// <summary>
		/// Vector2(-1, 0)
		/// </summary>
		public static readonly Vector2 Left = new Vector2 (-1, 0);

		/// <summary>
		/// Vector2(1, 0)
		/// </summary>
		public static readonly Vector2 Right = new Vector2 (1, 0);

		/// <summary>
		/// Vector2(0, 0)
		/// </summary>
		public static readonly Vector2 Zero = new Vector2 (0, 0);

		/// <summary>
		/// Vector2(1, 1)
		/// </summary>
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

		#region Properties

		public float x { get; set; }
		public float y { get; set; }

		/// <summary>
		/// Return normalized vector.
		/// </summary>
		public Vector2 normalized { get { return this / magnitude; } }

		/// <summary>
		/// Return magnitude of this vector.
		/// </summary>
		public float magnitude { get { return Convert.ToSingle (System.Math.Sqrt (Dot (this, this))); } }

		#endregion

		#region Dot Product

		/// <summary>
		/// Return dot product of two vectors.
		/// </summary>
		public static float Dot (Vector2 a, Vector2 b)
		{
			return (a.x * b.x) + (a.y * b.y);
		}

		/// <summary>
		/// Return dot product of a two values.
		/// </summary>
		public static float Dot (float x, float y)
		{
			return (x * x) + (y * y);
		}

		/// <summary>
		/// Return dot product of the current vector and a vector.
		/// </summary>
		public float Dot (Vector2 vector)
		{
			return (this.x * vector.x) + (this.y * vector.y);
		}

		#endregion

		#region Magnitude

		/// <summary>
		/// Return magnitude/length of two vectors
		/// </summary>
		public static float Magnitude (Vector2 a, Vector2 b)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (a, b)));
		}

		/// <summary>
		/// Return magnitude/length of a vector.
		/// </summary>
		public static float Magnitude (Vector2 vector)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (vector, vector)));
		}

		/// <summary>
		/// Return magnitude/length of a vector.
		/// </summary>
		public static float Magnitude (float x, float y)
		{
			return Convert.ToSingle (System.Math.Sqrt (Dot (x, y)));
		}

		#endregion

		#region Normalize

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

		#endregion

		#region Distance

		/// <summary>
		/// Return distance between 'from' and 'to'.
		/// </summary>
		public static float Distance (Vector2 from, Vector2 to)
		{
			float distX = to.x - from.x;
			float distY = to.y - from.y;
			return Magnitude (distX, distY);
		}

		/// <summary>
		/// Return distance from current position and 'to'.
		/// </summary>
		public float Distance (Vector2 target)
		{
			float distX = this.x - target.x;
			float distY = this.y - target.y;
			return Magnitude (distX, distY);
		}

		/// <summary>
		/// Return direction vector between two vectors.
		/// </summary>
		public static Vector2 Direction (Vector2 from, Vector2 to)
		{
			return to - from;
		}

		/// <summary>
		/// Return direction vector from current position to target.
		/// </summary>
		public Vector2 Direction (Vector2 target)
		{
			return new Vector2 (target.x - this.x, target.y - this.y);
		}

		#endregion

		#region Angle

		/// <summary>
		/// Return angle between two vectors.
		/// </summary>
		public static float GetAngle (Vector2 from, Vector2 to)
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
		public static int GetAngleType (Vector2 from, Vector2 to)
		{
			float angle = GetAngle (from, to);
			if (angle.Equals (0f)) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		/// <summary>
		/// Check angle type: (0) is right angle, (1) is acute angle, (-1) is obtuse angle.
		/// </summary>
		/// /// <returns>
		/// (0) - is right angle
		/// (1) - is acute angle, 
		/// (-1) - is obtuse angle.
		/// </returns>
		public static int GetAngleType (float angle)
		{
			if (angle.Equals (0f)) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		#endregion

		#region Projectile

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

		#endregion

		#region Override Methods

		/// <summary>
		/// Compares the passed vector to this one for equality.
		/// </summary>
		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Vector2 && this.Equals ((Vector2)obj);
		}

		/// <summary>
		/// Compares the passed vector to this one for equality.
		/// </summary>
		public bool Equals (Vector2 other)
		{
			return x.Equals (other.x) && y.Equals (other.y);
		}

		/// <summary>
		/// Return the hash code for this instance.
		/// </summary>
		public override int GetHashCode ()
		{
			return x.GetHashCode () ^ y.GetHashCode ();
		}

		#endregion

		#region Operators Overloading

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

		#endregion
	}
}
