using LeoDeg.Math.Vectors;
using LeoDeg.MathLib;
using System;
using System.Collections;

namespace LeoDeg.Math.Matrices
{
	public class Matrice4 : IEnumerable
	{
		private float[,] Matrix;

		public Matrice4 ()
		{
			Matrix = new float[4, 4];
		}

		public Matrice4 (float n00, float n01, float n02, float n03,
						 float n10, float n11, float n12, float n13,
						 float n20, float n21, float n22, float n23,
						 float n30, float n31, float n32, float n33)
		{
			Matrix = new float[4, 4];
			Matrix[0, 0] = n00; Matrix[0, 1] = n01; Matrix[0, 2] = n02; Matrix[0, 3] = n03;
			Matrix[1, 0] = n10; Matrix[1, 1] = n11; Matrix[1, 2] = n12; Matrix[1, 3] = n13;
			Matrix[2, 0] = n20; Matrix[2, 1] = n21; Matrix[2, 2] = n22; Matrix[2, 3] = n23;
			Matrix[3, 0] = n30; Matrix[3, 1] = n31; Matrix[3, 2] = n32; Matrix[3, 3] = n33;

		}

		public Matrice4 (Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
		{
			Matrix = new float[4, 4];
			Matrix[0, 0] = row1.x; Matrix[0, 1] = row1.y; Matrix[0, 2] = row1.z; Matrix[0, 3] = row1.w;
			Matrix[1, 0] = row2.x; Matrix[1, 1] = row2.y; Matrix[1, 2] = row2.z; Matrix[1, 3] = row2.w;
			Matrix[2, 0] = row3.x; Matrix[2, 1] = row3.y; Matrix[2, 2] = row3.z; Matrix[2, 3] = row3.w;
			Matrix[3, 0] = row4.x; Matrix[3, 1] = row4.y; Matrix[3, 2] = row4.z; Matrix[3, 3] = row4.w;
		}

		/// <summary>
		/// Required 4x4 array.
		/// </summary>
		public Matrice4 (float[,] matrix)
		{
			if (matrix.Length != 16)
			{
				throw new ArgumentOutOfRangeException ();
			}

			Matrix = new float[4, 4];
			Matrix = matrix;
		}

		public bool isDiagonal { get { return IsDiagonal (this); } }
		public bool isSymmetric { get { return IsSymmetric (this); } }
		public bool isAntiSymmetric { get { return IsAntiSymmetric (this); } }
		public Matrice4 transposed { get { return Transpose (this); } }
		public Matrice4 inversed { get { return Inverse (this); } }

		public static Matrice4 zero
		{
			get
			{
				return new Matrice4 (new float[,] {
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 } });
			}
		}

		public static Matrice4 diagonal
		{
			get
			{
				return new Matrice4 (new float[,] {
				{ 1, 0, 0, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 0, 1, 0 },
				{ 0, 0, 0, 1 } });
			}
		}

		public float this[int x, int y]
		{
			get
			{
				if (x < 0 || x > 3 || y < 0 || y > 3)
					throw new IndexOutOfRangeException ("Indexes [" + x + ", " + y + "], is out of range 4x4.");
				return Matrix[x, y];
			}
			set
			{
				if (x < 0 || x > 3 || y < 0 || y > 3)
					throw new IndexOutOfRangeException ("Indexes [" + x + ", " + y + "], is out of range 4x4.");
				Matrix[x, y] = value;
			}
		}

		/// <summary>
		/// Return matrix row by index.
		/// </summary>
		public Vector4 this[int rowIndex]
		{
			get
			{
				switch (rowIndex)
				{
					case 0: return new Vector4 (Matrix[0, 0], Matrix[0, 1], Matrix[0, 2], Matrix[0, 3]);
					case 1: return new Vector4 (Matrix[1, 0], Matrix[1, 1], Matrix[1, 2], Matrix[1, 3]);
					case 2: return new Vector4 (Matrix[2, 0], Matrix[2, 1], Matrix[2, 2], Matrix[2, 3]);
					case 3: return new Vector4 (Matrix[3, 0], Matrix[3, 1], Matrix[3, 2], Matrix[3, 3]);
					default: throw new ArgumentOutOfRangeException ();
				}
			}
		}

		public static Matrice4 Transpose (Matrice4 matrix)
		{
			return new Matrice4 (
				matrix[0, 0], matrix[1, 0], matrix[2, 0], matrix[3, 0],
				matrix[0, 1], matrix[1, 1], matrix[2, 1], matrix[3, 1],
				matrix[0, 2], matrix[1, 2], matrix[2, 2], matrix[3, 2],
				matrix[0, 3], matrix[1, 3], matrix[2, 3], matrix[3, 3]
			);
		}

		public static bool IsDiagonal (Matrice4 matrix)
		{
			return
				matrix[0, 1] == 0f && matrix[0, 2] == 0f && matrix[0, 3] == 0f &&
				matrix[1, 0] == 0f && matrix[1, 2] == 0f && matrix[1, 3] == 0f &&
				matrix[2, 0] == 0f && matrix[2, 1] == 0f && matrix[2, 3] == 0f &&
				matrix[3, 0] == 0f && matrix[3, 1] == 0f && matrix[3, 2] == 0f;
		}

		public static bool IsSymmetric (Matrice4 matrix)
		{
			return
				matrix[0, 1] == matrix[1, 0] &&
				matrix[0, 2] == matrix[2, 0] &&
				matrix[0, 3] == matrix[3, 0] &&
				matrix[1, 2] == matrix[2, 1] &&
				matrix[1, 3] == matrix[3, 1] &&
				matrix[2, 3] == matrix[3, 2];

		}

		public static bool IsAntiSymmetric (Matrice4 matrice)
		{
			return matrice.transposed == -matrice;
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			if (obj.GetType () != this.GetType ()) return false;

			return obj is Matrice4 && this.Equals ((Matrice4)obj);
		}

		public bool Equals (Matrice4 other)
		{
			if (ReferenceEquals (null, other)) return false;
			if (ReferenceEquals (this, other)) return true;

			return
				Matrix[0, 0] == other[0, 0] && Matrix[1, 0] == other[1, 0] && Matrix[2, 0] == other[2, 0] && Matrix[3, 0] == other[3, 0] &&
				Matrix[0, 1] == other[0, 1] && Matrix[1, 1] == other[1, 1] && Matrix[2, 1] == other[2, 1] && Matrix[3, 1] == other[3, 1] &&
				Matrix[0, 2] == other[0, 2] && Matrix[1, 2] == other[1, 2] && Matrix[2, 2] == other[2, 2] && Matrix[3, 2] == other[3, 2] &&
				Matrix[0, 3] == other[0, 3] && Matrix[1, 3] == other[1, 3] && Matrix[2, 3] == other[2, 3] && Matrix[3, 3] == other[3, 3];
		}

		public static Matrice4 operator * (Matrice4 a, Matrice4 b)
		{
			return new Matrice4
			(
				// First
				a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0] + a[0, 2] * b[2, 0] + a[0, 3] * b[3, 0],  // n00
				a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] + a[0, 2] * b[2, 1] + a[0, 3] * b[3, 1],  // n01
				a[0, 0] * b[0, 2] + a[0, 1] * b[1, 2] + a[0, 2] * b[2, 2] + a[0, 3] * b[3, 2],  // n02
				a[0, 0] * b[0, 3] + a[0, 1] * b[1, 3] + a[0, 2] * b[2, 3] + a[0, 3] * b[3, 3],  // n03

				// Second
				a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0] + a[1, 2] * b[2, 0] + a[1, 3] * b[3, 0],  // n10
				a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] + a[1, 2] * b[2, 1] + a[1, 3] * b[3, 1],  // n11
				a[1, 0] * b[0, 2] + a[1, 1] * b[1, 2] + a[1, 2] * b[2, 2] + a[1, 3] * b[3, 2],  // n12
				a[1, 0] * b[0, 3] + a[1, 1] * b[1, 3] + a[1, 2] * b[2, 3] + a[1, 3] * b[3, 3],  // n13

				// Third
				a[2, 0] * b[0, 0] + a[2, 1] * b[1, 0] + a[2, 2] * b[2, 0] + a[2, 3] * b[3, 0],  // n20
				a[2, 0] * b[0, 1] + a[2, 1] * b[1, 1] + a[2, 2] * b[2, 1] + a[2, 3] * b[3, 1],  // n21
				a[2, 0] * b[0, 2] + a[2, 1] * b[1, 2] + a[2, 2] * b[2, 2] + a[2, 3] * b[3, 2],  // n22
				a[2, 0] * b[0, 3] + a[2, 1] * b[1, 3] + a[2, 2] * b[2, 3] + a[2, 3] * b[3, 3],  // n23

				// Fourth
				a[3, 0] * b[0, 0] + a[3, 1] * b[1, 0] + a[3, 2] * b[2, 0] + a[3, 3] * b[3, 0],  // n30
				a[3, 0] * b[0, 1] + a[3, 1] * b[1, 1] + a[3, 2] * b[2, 1] + a[3, 3] * b[3, 1],  // n31
				a[3, 0] * b[0, 2] + a[3, 1] * b[1, 2] + a[3, 2] * b[2, 2] + a[3, 3] * b[3, 2],  // n32
				a[3, 0] * b[0, 3] + a[3, 1] * b[1, 3] + a[3, 2] * b[2, 3] + a[3, 3] * b[3, 3]   // n33

			);
		}

		public static Matrice4 operator * (Matrice4 a, float scalar)
		{
			return new Matrice4
			(
				a[0, 0] * scalar, a[0, 1] * scalar, a[0, 2] * scalar, a[0, 3] * scalar,
				a[1, 0] * scalar, a[1, 1] * scalar, a[1, 2] * scalar, a[1, 3] * scalar,
				a[2, 0] * scalar, a[2, 1] * scalar, a[2, 2] * scalar, a[2, 3] * scalar,
				a[3, 0] * scalar, a[3, 1] * scalar, a[3, 2] * scalar, a[3, 3] * scalar
			);
		}

		public static Matrice4 operator * (float scalar, Matrice4 a)
		{
			return a * scalar;
		}

		public static Matrice4 operator + (Matrice4 a, Matrice4 b)
		{
			return new Matrice4
			(
				a[0, 0] + b[0, 0], a[0, 1] + b[0, 1], a[0, 2] + b[0, 2], a[0, 3] + b[0, 3],
				a[1, 0] + b[1, 0], a[1, 1] + b[1, 1], a[1, 2] + b[1, 2], a[1, 3] + b[1, 3],
				a[2, 0] + b[2, 0], a[2, 1] + b[2, 1], a[2, 2] + b[2, 2], a[2, 3] + b[2, 3],
				a[3, 0] + b[3, 0], a[3, 1] + b[3, 1], a[3, 2] + b[3, 2], a[3, 3] + b[3, 3]
			);
		}

		public static Matrice4 operator - (Matrice4 a, Matrice4 b)
		{
			return new Matrice4
			(
				a[0, 0] - b[0, 0], a[0, 1] - b[0, 1], a[0, 2] - b[0, 2], a[0, 3] - b[0, 3],
				a[1, 0] - b[1, 0], a[1, 1] - b[1, 1], a[1, 2] - b[1, 2], a[1, 3] - b[1, 3],
				a[2, 0] - b[2, 0], a[2, 1] - b[2, 1], a[2, 2] - b[2, 2], a[2, 3] - b[2, 3],
				a[3, 0] - b[3, 0], a[3, 1] - b[3, 1], a[3, 2] - b[3, 2], a[3, 3] - b[3, 3]
			);
		}

		public static Matrice4 operator - (Matrice4 a)
		{
			return new Matrice4
			(
				-a[0, 0], -a[0, 1], -a[0, 2], -a[0, 3],
				-a[1, 0], -a[1, 1], -a[1, 2], -a[1, 3],
				-a[2, 0], -a[2, 1], -a[2, 2], -a[2, 3],
				-a[3, 0], -a[3, 1], -a[3, 2], -a[3, 3]
			);
		}

		public static Vector4 operator * (Matrice4 m, Vector4 v)
		{
			return new Vector4
			(
				m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
				m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
				m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
				m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
			);
		}

		public IEnumerator GetEnumerator ()
		{
			return Matrix.GetEnumerator ();
		}

		public override string ToString ()
		{
			return string.Format ("[{0},{1},{2},{3}]\n[{4},{5},{6},{7}]\n[{8},{9},{10},{11}]\n[{12},{13},{14},{15}]",
				Matrix[0, 0], Matrix[0, 1], Matrix[0, 2], Matrix[0, 3],
				Matrix[1, 0], Matrix[1, 1], Matrix[1, 2], Matrix[1, 3],
				Matrix[2, 0], Matrix[2, 1], Matrix[2, 2], Matrix[2, 3],
				Matrix[3, 0], Matrix[3, 1], Matrix[3, 2], Matrix[3, 3]);
		}

		public static Matrice4 Inverse (Matrice4 M)
		{
			Vector3 a = M[0].ToVector3 ();
			Vector3 b = M[1].ToVector3 ();
			Vector3 c = M[2].ToVector3 ();
			Vector3 d = M[3].ToVector3 ();

			float x = M[3, 0];
			float y = M[3, 1];
			float z = M[3, 2];
			float w = M[3, 3];

			Vector3 s = Vector3.Cross (a, b);
			Vector3 t = Vector3.Cross (c, d);
			Vector3 u = a * y - b * x;
			Vector3 v = c * w - d * z;

			float invDet = 1.0F / (Vector3.Dot (s, v) + Vector3.Dot (t, u));
			s *= invDet;
			t *= invDet;
			u *= invDet;
			v *= invDet;

			Vector3 row0 = Vector3.Cross (b, v) + t * y;
			Vector3 row1 = Vector3.Cross (v, a) - t * x;
			Vector3 row2 = Vector3.Cross (d, u) + s * w;
			Vector3 row3 = Vector3.Cross (u, c) - s * z;

			return (new Matrice4 (
				row0.x, row0.y, row0.z, -Vector3.Dot (b, t),
				row1.x, row1.y, row1.z, Vector3.Dot (a, t),
				row2.x, row2.y, row2.z, -Vector3.Dot (d, s),
				row3.x, row3.y, row3.z, Vector3.Dot (c, s))
			);
		}
	}
}
