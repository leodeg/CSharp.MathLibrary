using NUnit.Framework;
using LeoDeg.Math.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.Math.Matrices
{
	[TestFixture ()]
	public class Matrice3Tests
	{
		[Test ()]
		public void Add_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } });
			Matrice3 matrice2 = new Matrice3 (new float[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } });
			Matrice3 expected = new Matrice3 (new float[,] { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } });
			Assert.AreEqual (expected, matrice + matrice2);
		}

		[Test ()]
		public void Substract_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } });
			Matrice3 matrice2 = new Matrice3 (new float[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } });
			Matrice3 expected = new Matrice3 (new float[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } });
			Assert.AreEqual (expected, matrice - matrice2);
		}

		[Test ()]
		public void Multiply_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } });
			Matrice3 matrice2 = new Matrice3 (new float[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } });
			Matrice3 expected = new Matrice3 (new float[,] { { 18, 18, 18 }, { 18, 18, 18 }, { 18, 18, 18 } });
			Assert.AreEqual (expected, matrice * matrice2);
		}

		[Test ()]
		public void MultiplyByScalar_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } });
			Matrice3 expected = new Matrice3 (new float[,] { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } });
			Assert.AreEqual (expected, matrice * 2);
		}

		[Test ()]
		public void Determinant_GivenMatrices_PreservesMatrix_ReturnPositiveValue ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
			Assert.AreEqual (0, Matrice3.Determinant (matrice));

			matrice = new Matrice3 (new float[,] { { 1, 2, 3 }, { 4, -5, 6 }, { 7, 8, 9 } });
			Assert.AreEqual (120, Matrice3.Determinant (matrice));
		}

		[Test ()]
		public void Symmetric_GivenMatrix_MatrixIsSymmetric_ReturnTrue ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] {
				{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ 0, 0, 1 }}
			);

			Assert.AreEqual (true, Matrice3.Symmetric (matrice));
		}

		[Test ()]
		public void Symmetric_GivenMatrix_MatrixIsNotSymmetric_ReturnFalse ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] {
				{ 1, 0, 1 },
				{ 1, 1, 0 },
				{ 0, 0, 1 }}
			);

			Assert.AreEqual (false, Matrice3.Symmetric (matrice));
		}

		[Test ()]
		public void Diagonal_GivenMatrix_MatrixIsDiagonal_ReturnTrue ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] {
				{ 5, 0, 0 },
				{ 0, 10, 0 },
				{ 0, 0, 1 }}
			);

			Assert.AreEqual (true, Matrice3.Diagonal (matrice));
		}

		[Test ()]
		public void Diagonal_GivenMatrix_MatrixIsNotDiagonal_ReturnFalse ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] {
				{ 5, 0, 0 },
				{ 7, 10, 0 },
				{ 6, 0, 1 }}
			);
			Assert.AreEqual (false, Matrice3.Diagonal (matrice));
		}

		[Test ()]
		public void Transpose_GivenMatrix_ReturnTransposedMatrix ()
		{
			Matrice3 matrice = new Matrice3 (new float[,] {
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }}
			);

			Matrice3 expected = new Matrice3 (new float[,] {
				{ 1, 4, 7 },
				{ 2, 5, 8 },
				{ 3, 6, 9 }}
			);

			Assert.AreEqual (expected, Matrice3.Transpose (matrice));
		}
	}
}