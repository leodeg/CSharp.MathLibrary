﻿using NUnit.Framework;
using LeoDeg.Math.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeoDeg.Math.Vectors;

namespace LeoDeg.Math.Matrices
{
	[TestFixture ()]
	public class Matrice4Tests
	{
		[Test ()]
		public void Add_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 } });
			Matrice4 matrice2 = new Matrice4 (new float[,] { { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 } });
			Matrice4 expected = new Matrice4 (new float[,] { { 5, 5, 5, 5 }, { 5, 5, 5, 5 }, { 5, 5, 5, 5 }, { 5, 5, 5, 5 } });
			Assert.AreEqual (expected, matrice + matrice2);
		}

		[Test ()]
		public void Substract_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 } });
			Matrice4 matrice2 = new Matrice4 (new float[,] { { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 } });
			Matrice4 expected = new Matrice4 (new float[,] { { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } });
			Assert.AreEqual (expected, matrice - matrice2);
		}

		[Test ()]
		public void Multiply_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 } });
			Matrice4 matrice2 = new Matrice4 (new float[,] { { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 }, { 3, 3, 3, 3 } });
			Matrice4 expected = new Matrice4 (new float[,] { { 24, 24, 24, 24 }, { 24, 24, 24, 24 }, { 24, 24, 24, 24 }, { 24, 24, 24, 24 } });
			Assert.AreEqual (expected, matrice * matrice2);
		}

		[Test ()]
		public void Multiply_GivenMatrixAndVector_ReturnNewVector4 ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 } });
			Vector4 vector = new Vector4 (3, 3, 3, 3);
			Vector4 expected = new Vector4 (24, 24, 24, 24);
			Assert.AreEqual (expected, matrice * vector);
		}

		[Test ()]
		public void MultiplyByScalar_GivenTwoMatrix_ReturnNewMatrix ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] { { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 }, { 2, 2, 2, 2 } });
			Matrice4 expected = new Matrice4 (new float[,] { { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 }, { 4, 4, 4, 4 } });
			Assert.AreEqual (expected, matrice * 2);
		}

		[Test ()]
		public void Inverse_GivenMatrix_ReturnInversedMatrix ()
		{
			Matrice4 matrice = new Matrice4 (new float[,] {
				{ 5, 3, 2, 1 },
				{ 1, 2, 3, 6 },
				{ 7, 3, 2, 1 },
				{ 1, 2, 3, 4 } });

			Matrice4 expected = new Matrice4 (new float[,] {
				{ -10/20, 0/20, 10/20, 0/20},
				{ 38/20, 10/20, -26/20, -18/20 },
				{ -22/20, -20/20, 14/20, 32/20 },
				{ 0/20, 10/20, 0/20, -10/20 } });

			Assert.AreEqual (expected, Matrice4.Inverse (matrice));
		}
	}
}