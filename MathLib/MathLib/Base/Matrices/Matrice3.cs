using LeoDeg.MathLib.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.MathLib.Matrices
{
	public struct Matrice3
	{
		private float[,] m_Matrix;

		#region Constructors

		public Matrice3 (float n00, float n01, float n02,
						 float n10, float n11, float n12,
						 float n20, float n21, float n22)
		{
			m_Matrix = new float[3, 3];
			m_Matrix[0, 0] = n00; m_Matrix[0, 1] = n01; m_Matrix[0, 2] = n02;
			m_Matrix[1, 0] = n10; m_Matrix[1, 1] = n11; m_Matrix[1, 2] = n12;
			m_Matrix[2, 0] = n20; m_Matrix[2, 1] = n21; m_Matrix[2, 2] = n22;

		}

		public Matrice3 (Vector3 a, Vector3 b, Vector3 c)
		{
			m_Matrix = new float[3, 3];
			m_Matrix[0, 0] = a.x; m_Matrix[0, 1] = a.y; m_Matrix[0, 2] = a.z;
			m_Matrix[1, 0] = b.x; m_Matrix[1, 1] = b.y; m_Matrix[1, 2] = b.z;
			m_Matrix[2, 0] = c.x; m_Matrix[2, 1] = c.y; m_Matrix[2, 2] = c.z;
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

			m_Matrix = new float[3, 3];
			m_Matrix = matrix;
		}

		#endregion

		#region Indexers

		/// <summary>
		/// Return particular value.
		/// </summary>
		public float this[int x, int y]
		{
			get { return m_Matrix[x, y]; }
			set { m_Matrix[x, y] = value; }
		}

		/// <summary>
		/// Return new Vector3 with matrix row.
		/// </summary>
		/// <param name="index">matrix row</param>
		/// <returns></returns>
		public Vector3 this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return new Vector3 (m_Matrix[0, 0], m_Matrix[0, 1], m_Matrix[0, 2]);
					case 1:
						return new Vector3 (m_Matrix[1, 0], m_Matrix[1, 1], m_Matrix[1, 2]);
					case 2:
						return new Vector3 (m_Matrix[2, 0], m_Matrix[2, 1], m_Matrix[2, 2]);
					default:
						throw new ArgumentOutOfRangeException ();
				}
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Return zero matrix.
		/// </summary>
		public static Matrice3 zero
		{
			get { return new Matrice3 (new float[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }); }
		}

		/// <summary>
		/// Return determinant of current matrix.
		/// </summary>
		public float determinant => Determinant (this);

		/// <summary>
		/// Return inverse matrix of the current matrix.
		/// </summary>
		public Matrice3 inverse => Inverse (this);

		#endregion

		#region Matrice3 Methods

		/// <summary>
		/// Return determinant of matrix m.
		/// </summary>
		public static float Determinant (Matrice3 m)
		{
			return m[0, 0] * ( m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1] )
				 + m[0, 1] * ( m[1, 2] * m[2, 0] - m[1, 0] * m[2, 2] )
				 + m[0, 2] * ( m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0] );
		}

		/// <summary>
		/// Return inverse matrix.
		/// </summary>
		public static Matrice3 Inverse (Matrice3 m)
		{
			Vector3 a = m[0];
			Vector3 b = m[1];
			Vector3 c = m[2];

			Vector3 r0 = Vector3.Cross (b, c);
			Vector3 r1 = Vector3.Cross (c, a);
			Vector3 r2 = Vector3.Cross (a, b);

			float invDet = 1.0f / Vector3.Dot (r1, c);

			return new Matrice3
			(
				r0.x * invDet, r0.y * invDet, r0.z * invDet,
				r1.x * invDet, r1.y * invDet, r1.z * invDet,
				r2.x * invDet, r2.y * invDet, r2.z * invDet

			);
		}

		#endregion

		#region Operators Overloading

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

		public static Matrice3 operator + (Matrice3 a, Matrice3 b)
		{
			return new Matrice3
			(
				a[0, 0] + b[0, 0], a[0, 1] + b[0, 1], a[0, 2] + b[0, 2],
				a[1, 0] + b[1, 0], a[1, 1] + b[1, 1], a[1, 2] + b[1, 2],
				a[2, 0] + b[2, 0], a[2, 1] + b[2, 1], a[2, 2] + b[2, 2]
			);
		}

		#endregion
	}
}
