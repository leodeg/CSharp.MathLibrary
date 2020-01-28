using System;
using System.Collections;
using LeoDeg.Math.Vectors;

namespace LeoDeg.Math.Matrices
{
	public class Matrice2 : IEnumerable
	{
		private float[,] matrix;

		public Matrice2 (float[,] matrix)
		{
			if (matrix.Length != 4)
				throw new ArgumentOutOfRangeException ();

			this.matrix = new float[2, 2];
			this.matrix = matrix;
		}

		public Matrice2 (float n00, float n01, float n10, float n11)
		{
			matrix = new float[2, 2];
			matrix[0, 0] = n00;
			matrix[0, 1] = n01;
			matrix[1, 0] = n10;
			matrix[1, 1] = n11;
		}

		public Matrice2 (Vector2 a, Vector2 b)
		{
			matrix = new float[2, 2];
			matrix[0, 0] = a.x;
			matrix[0, 1] = a.y;
			matrix[1, 0] = b.x;
			matrix[1, 1] = b.y;
		}


		public float this[int a, int b]
		{
			get { return matrix[a, b]; }
			set { matrix[a, b] = value; }
		}

		/// <summary>
		/// Return zero matrix (0,0,0,0).
		/// </summary>
		public Matrice2 zero => new Matrice2 (0f, 0f, 0f, 0f);

		/// <summary>
		/// Return identity matrix (1,1,1,1).
		/// </summary>
		public Matrice2 identity => new Matrice2 (1f, 1f, 1f, 1f);
		public bool isDiagonal => Diagonal (this);
		public Matrice2 transposed => Transpose (this);
		public bool isSymmetric => Symmetric (this);
		public bool isAntiSymmetric => AntiSymmetric (this);
		public float determinant => Determinant (this);


		public static Matrice2 Transpose (Matrice2 matrix)
		{
			return new Matrice2 (
				matrix[0, 0], matrix[1, 0],
				matrix[0, 1], matrix[1, 1]
			);
		}

		public static bool Diagonal (Matrice2 matrix)
		{
			return matrix[0, 1].Equals (0f) && matrix[1, 0].Equals (0f);
		}

		public static bool Symmetric (Matrice2 matrix)
		{
			return matrix[0, 1].Equals (matrix[1, 0]);
		}

		public static bool AntiSymmetric (Matrice2 matrix)
		{
			throw new NotImplementedException ();
		}


		public static float Determinant (Matrice2 matrix)
		{
			return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Matrice2 && this.Equals ((Matrice2)obj);
		}

		public bool Equals (Matrice2 other)
		{
			return matrix[0, 0].Equals (other[0, 0])
				&& matrix[0, 1].Equals (other[0, 1])
				&& matrix[1, 0].Equals (other[1, 0])
				&& matrix[1, 1].Equals (other[1, 1]);
		}

		public IEnumerator GetEnumerator () => matrix.GetEnumerator ();

		public override int GetHashCode ()
		{
			return matrix.GetHashCode () + this.GetType ().GetHashCode ();
		}

		public static Matrice2 operator + (Matrice2 a, Matrice2 b)
		{
			return new Matrice2
			(
				a[0, 0] + b[0, 0],
				a[0, 1] + b[0, 1],
				a[1, 0] + b[1, 0],
				a[1, 1] + b[1, 1]
			);
		}

		public static Matrice2 operator - (Matrice2 a, Matrice2 b)
		{
			return new Matrice2
			(
				a[0, 0] - b[0, 0],
				a[0, 1] - b[0, 1],
				a[1, 0] - b[1, 0],
				a[1, 1] - b[1, 1]
			);
		}

		public static Matrice2 operator - (Matrice2 a)
		{
			return new Matrice2 (-a[0, 0], -a[0, 1], -a[1, 0], -a[1, 1]);
		}

		public static Matrice2 operator * (Matrice2 a, Matrice2 b)
		{
			return new Matrice2
			(
				a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0],
				a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0],
				a[1, 0] * b[0, 1] + a[0, 1] * b[1, 1],
				a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1]
			);
		}

		public static Matrice2 operator * (Matrice2 a, Vector2 b)
		{
			return new Matrice2
			(
				a[0, 0] * b.x,
				a[1, 0] * b.y,
				a[1, 0] * b.x,
				a[1, 0] * b.y
			);
		}

		public static Matrice2 operator * (Matrice2 a, float scalar)
		{
			return new Matrice2
			(
				a[0, 0] * scalar,
				a[0, 1] * scalar,
				a[1, 0] * scalar,
				a[1, 1] * scalar
			);
		}

		public static Matrice2 operator * (float scalar, Matrice2 a)
		{
			return new Matrice2
			(
				a[0, 0] * scalar,
				a[0, 1] * scalar,
				a[1, 0] * scalar,
				a[1, 1] * scalar
			);
		}
	}
}
