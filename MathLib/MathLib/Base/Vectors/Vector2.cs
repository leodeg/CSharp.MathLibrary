using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.MathLib
{
	public struct Vector2
	{
		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
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

		/// <summary>
		/// X axes value.
		/// </summary>
		public float x { get; set; }

		/// <summary>
		/// Y axes value.
		/// </summary>
		public float y { get; set; }

		/// <summary>
		/// return Vector (0, 1)
		/// </summary>
		public Vector2 up { get => new Vector2 (0, 1); }

		/// <summary>
		/// return Vector (0, -1)
		/// </summary>
		public Vector2 down { get => new Vector2 (0, -1); }

		/// <summary>
		/// return Vector (-1, 0)
		/// </summary>
		public Vector2 left { get => new Vector2 (-1, 0); }

		/// <summary>
		/// return Vector (1, 0)
		/// </summary>
		public Vector2 right { get => new Vector2 (1, 0); }

		/// <summary>
		/// Return normalized vector.
		/// </summary>
		public Vector2 normalized => ( this / magnitude );

		/// <summary>
		/// Return magnitude of this vector.
		/// </summary>
		public float magnitude => (float)Math.Sqrt (magnitudeSquared);

		/// <summary>
		/// Return squared magnitude of this vector.
		/// </summary>
		public float magnitudeSquared => Dot (this, this);

		#endregion

		/// <summary>
		/// Make vector a unit vector.
		/// </summary>
		public static Vector2 Normalize (Vector2 a) => a / Magnitude (a);

		/// <summary>
		/// Return angle between two vectors.
		/// </summary>
		public static float Angle (Vector2 from, Vector2 to)
		{
			float magnitude = Magnitude (from) * Magnitude (to);
			float dot = Dot (from, to);
			return dot / magnitude;
		}

		/// <summary>
		/// Check angle type: (0) is right angle, (1) is acute angle, (-1) is obtuse angle.
		/// </summary>
		public static int AngleType (Vector2 from, Vector2 to)
		{
			float angle = Angle (from, to);
			if (angle.Equals (0f)) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		/// <summary>
		/// Check angle type: (0) is right angle, (1) is acute angle, (-1) is obtuse angle.
		/// </summary>
		public static int AngleType (float angle)
		{
			if (angle.Equals (0f)) return 0;
			if (angle < 0) return -1;
			return 1;
		}

		#region Dot Product

		/// <summary>
		/// Return dot product of two vectors.
		/// </summary>
		public static float Dot (Vector2 a, Vector2 b) => ( a.x * b.x ) + ( a.y * b.y );

		/// <summary>
		/// Return dot product of a vector.
		/// </summary>
		public float Dot (Vector2 a) => Dot (this, a);

		/// <summary>
		/// Return dot product of a two values.
		/// </summary>
		public static float Dot (float x, float y) => ( x * x ) + ( y * y );

		#endregion

		#region Magnitude

		/// <summary>
		/// Return squared magnitude (speed) of two vectors.
		/// </summary>
		public static float MagnitudeSquared (Vector2 a, Vector2 b) => Dot (a, b);

		/// <summary>
		/// Return squared magnitude (speed) of a vector.
		/// </summary>
		public static float MagnitudeSquared (Vector2 a) => Dot (a, a);

		/// <summary>
		/// Return magnitude (speed) of two vectors
		/// </summary>
		public static float Magnitude (Vector2 a, Vector2 b) => (float)Math.Sqrt (Dot (a, b));

		/// <summary>
		/// Return magnitude (speed) of a vector.
		/// </summary>
		public static float Magnitude (Vector2 a) => (float)Math.Sqrt (Dot (a, a));

		#endregion

		#region Projectile

		/// <summary>
		/// Make projection of vector a onto vector b.
		/// <para>((a * b) / b^2) * b</para>
		/// </summary>
		public static Vector2 Project (Vector2 a, Vector2 b)
		{
			return b * ( Dot (a, b) / Dot (b, b) );
		}

		/// <summary>
		/// Make perpendicular vector from vector a to vector b.
		/// <para>a - (((a * b) / b^2 ) * b)</para>
		/// </summary>
		public static Vector2 Reject (Vector2 a, Vector2 b)
		{
			return a - ( b * ( Dot (a, b) / Dot (b, b) ) );
		}

		#endregion

		#region Distance

		/// <summary>
		/// Return squared distance between 'from' and 'to'.
		/// </summary>
		public static float DistanceSquared (Vector2 from, Vector2 to)
		{
			float distX = from.x - to.x;
			float distY = from.y - to.y;
			return Dot (distX, distY);
		}

		/// <summary>
		/// Return distance from current position to 'to'.
		/// </summary>
		public float DistanceSquared (Vector2 to) => DistanceSquared (this, to);

		/// <summary>
		/// Return distance between 'from' and 'to'.
		/// </summary>
		public static float Distance (Vector2 from, Vector2 to)
		{
			float distX = to.x - from.x;
			float distY = to.y - from.y;
			return (float)Math.Sqrt (Dot (distX, distY));
		}

		/// <summary>
		/// Return distance from current position and 'to'.
		/// </summary>
		public float Distance (Vector2 to) => Distance (this, to);

		/// <summary>
		/// Return direction vector between two vectors.
		/// </summary>
		public static Vector2 Direction (Vector2 from, Vector2 to)
		{
			return to - from;
		}

		#endregion

		#region Basic Math Operations

		/// <summary>
		/// Add two vectors together.
		/// </summary>
		public static Vector2 Add (Vector2 a, Vector2 b) => a + b;

		/// <summary>
		/// Multiply first vector by second vector.
		/// </summary>
		public static Vector2 Mult (Vector2 a, Vector2 b) => a * b;

		/// <summary>
		/// Multiply the vector by the scalar value.
		/// </summary>
		public static Vector2 Mult (Vector2 a, float factor) => a * factor;

		/// <summary>
		/// Subtract second vector from first vector.
		/// </summary>
		public static Vector2 Sub (Vector2 a, Vector2 b) => a - b;

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

		public static Vector2 operator * (Vector2 a, Vector2 b)
		{
			return new Vector2 (( a.x * b.x ) + ( a.y * b.x ),
								( a.x * b.y ) + ( a.y * b.y ));
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
