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
	public class Matrice2Tests
	{
		[Test ()]
		public void Add_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 2, 2 }, { 2, 2 } });
			Matrice2 matrice2 = new Matrice2 (new float[,] { { 3, 3 }, { 3, 3 } });
			Matrice2 expected = new Matrice2 (new float[,] { { 5, 5 }, { 5, 5 } });
			Assert.AreEqual (expected, matrice + matrice2);
		}

		[Test ()]
		public void Substract_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 2, 2 }, { 2, 2 } });
			Matrice2 matrice2 = new Matrice2 (new float[,] { { 3, 3 }, { 3, 3 } });
			Matrice2 expected = new Matrice2 (new float[,] { { -1, -1 }, { -1, -1 } });
			Assert.AreEqual (expected, matrice - matrice2);
		}

		[Test ()]
		public void Multiply_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 2, 2 }, { 2, 2 } });
			Matrice2 matrice2 = new Matrice2 (new float[,] { { 3, 3 }, { 3, 3 } });
			Matrice2 expected = new Matrice2 (new float[,] { { 12, 12 }, { 12, 12 } });
			Assert.AreEqual (expected, matrice * matrice2);
		}

		[Test ()]
		public void MultiplyByScalar_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 2, 2 }, { 2, 2 } });
			Matrice2 expected = new Matrice2 (new float[,] { { 4, 4 }, { 4, 4 } });
			Assert.AreEqual (expected, matrice * 2);
		}

		[Test ()]
		public void Determinant_GivenMatrices_PreservesMatrix_ReturnPositiveValue ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 2 }, { 3, 4 } });
			Assert.AreEqual (-2, Matrice2.Determinant (matrice));
		}

		[Test ()]
		public void Symmetric_GivenMatrix_MatrixIsSymmetric_ReturnTrue ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 0 }, { 0, 1 } });
			Assert.AreEqual (true, Matrice2.Symmetric (matrice));
		}

		[Test ()]
		public void Symmetric_GivenMatrix_MatrixIsNotSymmetric_ReturnFalse ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 0 }, { 1, 1 } });
			Assert.AreEqual (false, Matrice2.Symmetric (matrice));
		}

		[Test ()]
		public void Diagonal_GivenMatrix_MatrixIsDiagonal_ReturnTrue ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 0 }, { 0, 1 } });
			Assert.AreEqual (true, Matrice2.Diagonal (matrice));
		}

		[Test ()]
		public void Diagonal_GivenMatrix_MatrixIsNotDiagonal_ReturnFalse ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 0 }, { 1, 1 } });
			Assert.AreEqual (false, Matrice2.Diagonal (matrice));
		}

		[Test ()]
		public void Transpose_GivenMatrix_ReturnTransposedMatrix ()
		{
			Matrice2 matrice = new Matrice2 (new float[,] { { 1, 2 }, { 3, 4 } });
			Matrice2 expected = new Matrice2 (new float[,] { { 1, 3 }, { 2, 4 } });
			Assert.AreEqual (expected, Matrice2.Transpose (matrice));
		}
	}
}