using System;
using System.Collections;
using System.Collections.Generic;
using LeoDeg.Math.Vectors;
using LeoDeg.MathLib;

namespace LeoDeg.Math.Matrices
{
	public class Matrice3 : IEnumerable
	{
		private float[,] Matrix;

		public Matrice3 ()
		{
			Matrix = new float[3, 3];
		}

		public Matrice3 (float n00, float n01, float n02,
						 float n10, float n11, float n12,
						 float n20, float n21, float n22)
		{
			Matrix = new float[3, 3];
			Matrix[0, 0] = n00; Matrix[0, 1] = n01; Matrix[0, 2] = n02;
			Matrix[1, 0] = n10; Matrix[1, 1] = n11; Matrix[1, 2] = n12;
			Matrix[2, 0] = n20; Matrix[2, 1] = n21; Matrix[2, 2] = n22;

		}

		public Matrice3 (Vector3 a, Vector3 b, Vector3 c)
		{
			Matrix = new float[3, 3];
			Matrix[0, 0] = a.x; Matrix[0, 1] = a.y; Matrix[0, 2] = a.z;
			Matrix[1, 0] = b.x; Matrix[1, 1] = b.y; Matrix[1, 2] = b.z;
			Matrix[2, 0] = c.x; Matrix[2, 1] = c.y; Matrix[2, 2] = c.z;
		}

		/// <summary>
		/// Required 3x3 array.
		/// </summary>
		public Matrice3 (float[,] matrix)
		{
			if (matrix.Length != 9)
			{
				throw new ArgumentOutOfRangeException ();
			}

			Matrix = new float[3, 3];
			Matrix = matrix;
		}

		public float this[int x, int y]
		{
			get
			{
				if (x < 0 || x > 2 || y < 0 || y > 2)
					throw new IndexOutOfRangeException ("Indexes [" + x + ", " + y + "], is out of range 3x3.");
				return Matrix[x, y];
			}
			set
			{
				if (x < 0 || x > 2 || y < 0 || y > 2)
					throw new IndexOutOfRangeException ("Indexes [" + x + ", " + y + "], is out of range 3x3.");
				Matrix[x, y] = value;
			}
		}

		/// <summary>
		/// Return matrix row by index.
		/// </summary>
		public Vector3 this[int rowIndex]
		{
			get
			{
				switch (rowIndex)
				{
					case 0: return new Vector3 (Matrix[0, 0], Matrix[0, 1], Matrix[0, 2]);
					case 1: return new Vector3 (Matrix[1, 0], Matrix[1, 1], Matrix[1, 2]);
					case 2: return new Vector3 (Matrix[2, 0], Matrix[2, 1], Matrix[2, 2]);
					default: throw new ArgumentOutOfRangeException ();
				}
			}
		}

		public static Matrice3 zero
		{
			get
			{
				return new Matrice3 (new float[,] {
				{ 0, 0, 0 },
				{ 0, 0, 0 },
				{ 0, 0, 0 } });
			}
		}

		public static Matrice3 diagonal
		{
			get
			{
				return new Matrice3 (new float[,] {
				{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ 0, 0, 1 } });
			}
		}

		public float determinant => Determinant (this);
		public bool isDiagonal => IsDiagonal (this);
		public bool isSymmetric => IsSymmetric (this);
		public bool isAntiSymmetric => IsAntiSymmetric (this);
		public Matrice3 inverse => Inverse (this);
		public Matrice3 transposed => Transpose (this);

		public static float Determinant (Matrice3 m)
		{
			return m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
				 + m[0, 1] * (m[1, 2] * m[2, 0] - m[1, 0] * m[2, 2])
				 + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);
		}

		public static bool IsDiagonal (Matrice3 matrix)
		{
			return
				matrix[0, 1] == 0f &&
				matrix[0, 2] == 0f &&
				matrix[1, 0] == 0f &&
				matrix[1, 2] == 0f &&
				matrix[2, 0] == 0f &&
				matrix[2, 1] == 0f;
		}

		public static Matrice3 Transpose (Matrice3 matrix)
		{
			return new Matrice3 (
				matrix[0, 0], matrix[1, 0], matrix[2, 0],
				matrix[0, 1], matrix[1, 1], matrix[2, 1],
				matrix[0, 2], matrix[1, 2], matrix[2, 2]
			);
		}

		public static bool IsSymmetric (Matrice3 matrix)
		{
			return
				matrix[0, 1] == matrix[1, 0] &&
				matrix[0, 2] == matrix[2, 0] &&
				matrix[1, 2] == matrix[2, 1];
		}

		public static bool IsAntiSymmetric (Matrice3 matrice)
		{
			return matrice.transposed == -matrice;
		}

		public static Matrice3 Inverse (Matrice3 m)
		{
			Vector3 a = m[0];
			Vector3 b = m[1];
			Vector3 c = m[2];

			Vector3 row0 = Vector3.Cross (b, c);
			Vector3 row1 = Vector3.Cross (c, a);
			Vector3 row2 = Vector3.Cross (a, b);

			float invDet = 1.0f / Vector3.Dot (row1, c);

			return new Matrice3
			(
				row0.x * invDet, row0.y * invDet, row0.z * invDet,
				row1.x * invDet, row1.y * invDet, row1.z * invDet,
				row2.x * invDet, row2.y * invDet, row2.z * invDet

			);
		}

		public IEnumerator GetEnumerator ()
		{
			return Matrix.GetEnumerator ();
		}

		public override string ToString ()
		{
			return string.Format ("[{0},{1},{2}]\n[{3},{4},{5}]\n[{6},{7},{8}]",
				Matrix[0, 0], Matrix[0, 1], Matrix[0, 2],
				Matrix[1, 0], Matrix[1, 1], Matrix[1, 2],
				Matrix[2, 0], Matrix[2, 1], Matrix[2, 2]);
		}

		public Matrice2 ToMatrice2 ()
		{
			return new Matrice2 (
				Matrix[0, 0], Matrix[0, 1],
				Matrix[1, 0], Matrix[1, 1]
			);
		}

		public Matrice4 ToMatrice4 ()
		{
			return new Matrice4 (
				Matrix[0, 0], Matrix[0, 1], Matrix[0, 2], 0,
				Matrix[1, 0], Matrix[1, 1], Matrix[1, 2], 0,
				Matrix[2, 0], Matrix[2, 1], Matrix[2, 2], 0,
				0, 0, 0, 0
			);
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Matrice3 && this.Equals ((Matrice3)obj);
		}

		public bool Equals (Matrice3 other)
		{
			if (ReferenceEquals (null, other)) return false;
			if (ReferenceEquals (this, other)) return true;

			return
				Matrix[0, 0] == other[0, 0] && Matrix[1, 0] == other[1, 0] && Matrix[2, 0] == other[2, 0] &&
				Matrix[0, 1] == other[0, 1] && Matrix[1, 1] == other[1, 1] && Matrix[2, 1] == other[2, 1] &&
				Matrix[0, 2] == other[0, 2] && Matrix[1, 2] == other[1, 2] && Matrix[2, 2] == other[2, 2];
		}

		public static Vector3 operator * (Matrice3 matrice, Vector3 vector)
		{
			return new Vector3 (
				matrice[0, 0] * vector.x + matrice[0, 1] * vector.y + matrice[0, 2] * vector.z,
				matrice[1, 0] * vector.x + matrice[1, 1] * vector.y + matrice[1, 2] * vector.z,
				matrice[2, 0] * vector.x + matrice[2, 1] * vector.y + matrice[2, 2] * vector.z
			);
		}

		public static Matrice3 operator * (Matrice3 a, Matrice3 b)
		{
			return new Matrice3
			(
				// First
				a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0] + a[0, 2] * b[2, 0],
				a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] + a[0, 2] * b[2, 1],
				a[0, 0] * b[0, 2] + a[0, 1] * b[1, 2] + a[0, 2] * b[2, 2],
				// Second
				a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0] + a[1, 2] * b[2, 0],
				a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1],
				a[1, 0] * b[0, 2] + a[1, 1] * b[1, 2] + a[1, 2] * b[2, 2],
				// Third
				a[2, 0] * b[0, 0] + a[2, 1] * b[1, 0] + a[2, 2] * b[2, 0],
				a[2, 0] * b[0, 1] + a[2, 1] * b[1, 1] + a[2, 2] * b[2, 1],
				a[2, 0] * b[0, 2] + a[2, 1] * b[1, 2] + a[2, 2] * b[2, 2]

			);
		}

		public static Matrice3 operator * (Matrice3 a, float scalar)
		{
			return new Matrice3
			(
				a[0, 0] * scalar, a[0, 1] * scalar, a[0, 2] * scalar,
				a[1, 0] * scalar, a[1, 1] * scalar, a[1, 2] * scalar,
				a[2, 0] * scalar, a[2, 1] * scalar, a[2, 2] * scalar
			);
		}

		public static Matrice3 operator * (float scalar, Matrice3 a)
		{
			return a * scalar;
		}

		public static Matrice3 operator + (Matrice3 a, Matrice3 b)
		{
			return new Matrice3
			(
				a[0, 0] + b[0, 0], a[0, 1] + b[0, 1], a[0, 2] + b[0, 2],
				a[1, 0] + b[1, 0], a[1, 1] + b[1, 1], a[1, 2] + b[1, 2],
				a[2, 0] + b[2, 0], a[2, 1] + b[2, 1], a[2, 2] + b[2, 2]
			);
		}

		public static Matrice3 operator - (Matrice3 a, Matrice3 b)
		{
			return new Matrice3
			(
				a[0, 0] - b[0, 0], a[1, 0] - b[1, 0], a[2, 0] - b[2, 0],
				a[0, 1] - b[0, 1], a[1, 1] - b[1, 1], a[2, 1] - b[2, 1],
				a[0, 2] - b[0, 2], a[1, 2] - b[1, 2], a[2, 2] - b[2, 2]
			);
		}

		public static Matrice3 operator - (Matrice3 a)
		{
			return new Matrice3
			(
				-a[0, 0], -a[0, 1], -a[0, 2],
				-a[1, 0], -a[1, 1], -a[1, 2],
				-a[2, 0], -a[2, 1], -a[2, 2]
			);
		}

		public static bool operator == (Matrice3 a, Matrice3 b)
		{
			return a.Equals (b);
		}

		public static bool operator != (Matrice3 a, Matrice3 b)
		{
			return !a.Equals (b);
		}
	}
}
