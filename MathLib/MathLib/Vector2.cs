using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
	public struct Vector2
	{
		private float _x, _y;

		public Vector2 (float x, float y)
		{
			_x = x;
			_y = y;
		}

		#region Properties

		public float x { get => _x; }
		public float y { get => _y; }

		public Vector2 up { get => new Vector2 (0, 1); }
		public Vector2 down { get => new Vector2 (0, -1); }
		public Vector2 left { get => new Vector2 (-1, 0); }
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

		#region Static Methods

		/// <summary>
		/// Return dot product of two vectors.
		/// </summary>
		public static float Dot (Vector2 a, Vector2 b) => ( a._x * b._x ) + ( a._y * b._y );

		/// <summary>
		/// Return dot product of a vector.
		/// </summary>
		public float Dot (Vector2 a) => Dot (this, a);

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

		/// <summary>
		/// Make vector a unit vector.
		/// </summary>
		public static Vector2 Normalize (Vector2 a) => a / Magnitude (a);

		/// <summary>
		/// Return angle between two vectors.
		/// </summary>
		public static float Angle (Vector2 a, Vector2 b)
		{
			float dot = Dot (a, b);
			float magnitude = Magnitude (a) * Magnitude (b);

			return dot / magnitude;
		}

		#endregion

		#region Methods Operations


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
		public static Vector2 Substract (Vector2 a, Vector2 b) => a - b;

		#endregion

		#region Overloading Operators

		public static Vector2 operator + (Vector2 a, Vector2 b) => new Vector2 (a._x + b._x, a._y + b._y);
		public static Vector2 operator - (Vector2 a, Vector2 b) => new Vector2 (a._x - b._x, a._y - b._y);
		public static Vector2 operator - (Vector2 a) => new Vector2 (-a.x, -a.y);
		public static Vector2 operator * (Vector2 a, float scalar) => new Vector2 (a._x * scalar, a._y * scalar);
		public static Vector2 operator * (float scalar, Vector2 a) => new Vector2 (a._x * scalar, a._y * scalar);
		public static Vector2 operator * (Vector2 a, Vector2 b) => new Vector2 (a.x * b.x + a.y * b.x, a.x * b.y + a.y * b.y);
		public static bool operator == (Vector2 a, Vector2 b) => a.Equals (b);
		public static bool operator != (Vector2 a, Vector2 b) => !( a.Equals (b) );

		public static Vector2 operator / (Vector2 a, float scalar)
		{
			scalar = 1f / scalar;
			return new Vector2 (a.x * scalar, a.y * scalar);
		}

		public static Vector2 operator / (float scalar, Vector2 a)
		{
			scalar = 1f / scalar;
			return new Vector2 (a.x * scalar, a.y * scalar);
		}

		#endregion
	}
}
