using NUnit.Framework;
using LeoDeg.Math.Vectors;
using System;

namespace LeoDeg.Math.Vector3Tests
{
	[TestFixture]
	public class Vector3Tests
	{
		[Test]
		public void Add_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector3 (4, 4), new Vector3 (2, 2) + new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (5, 8), new Vector3 (3, 6) + new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (-1, -3), new Vector3 (-3, -5) + new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (-5, -7), new Vector3 (-3, -5) + new Vector3 (-2, -2));
		}

		[Test]
		public void Substract_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector3 (0, 0), new Vector3 (2, 2) - new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (1, 4), new Vector3 (3, 6) - new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (-5, -7), new Vector3 (-3, -5) - new Vector3 (2, 2));
			Assert.AreEqual (new Vector3 (-1, -3), new Vector3 (-3, -5) - new Vector3 (-2, -2));
		}

		[Test]
		public void MultiplyByScalarValue_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector3 (4, 4), new Vector3 (2, 2) * 2);
			Assert.AreEqual (new Vector3 (9, 18), new Vector3 (3, 6) * 3);
			Assert.AreEqual (new Vector3 (6, 10), new Vector3 (-3, -5) * -2);
			Assert.AreEqual (new Vector3 (-9, -15), new Vector3 (3, 5) * -3);
		}

		[Test]
		public void DivideByScalarValue_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector3 (1, 1), new Vector3 (2, 2) / 2);
			Assert.AreEqual (new Vector3 (1, 2), new Vector3 (3, 6) / 3);
		}

		[Test]
		public void Equals_GivenTwoVectors_VectorsAreEqualToEachOther_ReturnTrue ()
		{
			Assert.AreEqual (true, new Vector3 (2, 2) == new Vector3 (2, 2));
		}

		[Test]
		public void Equals_GivenTwoVectors_VectorsAreNotEqualToEachOther_ReturnFalse ()
		{
			Assert.AreEqual (false, new Vector3 (2, 2) == new Vector3 (3, 2));
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsHaveTheSameDirections_ReturnPositiveValue ()
		{
			float actual = Vector3.Dot (new Vector3 (2, 1), new Vector3 (2, 3));
			float expected = 7;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsHaveOppositeDirections_ReturnNegativeValue ()
		{
			float actual = Vector3.Dot (new Vector3 (-2, 1), new Vector3 (2, 3));
			float expected = -1;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsAreOrthogonal_ReturnZeroVlue ()
		{
			float actual = Vector3.Dot (new Vector3 (0, 1), new Vector3 (1, 0));
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsHaveTheSameDirections_ReturnPositiveValue ()
		{
			Vector3 vector = new Vector3 (2, 1);
			float actual = Vector3.Dot (vector, new Vector3 (2, 3));
			float expected = 7;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsHaveOppositeDirections_ReturnNegativeValue ()
		{
			Vector3 vector = new Vector3 (-2, 1);
			float actual = Vector3.Dot (vector, new Vector3 (2, 3));
			float expected = -1;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsAreOrthogonal_ReturnZeroVlue ()
		{
			Vector3 vector = new Vector3 (0, 1);
			float actual = Vector3.Dot (vector, new Vector3 (1, 0));
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesPositive_ReturnPositiveValue ()
		{
			float actual = Vector3.Dot (2, 3, 0);
			float expected = 13;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesNegative_ReturnPositiveValue ()
		{
			float actual = Vector3.Dot (-2, -3, 0);
			float expected = 13;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesZero_ReturnZero ()
		{
			float actual = Vector3.Dot (0, 0, 0);
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Cross_GivenTwoVectors_ReturnOrthogonalVectorToThisBoth ()
		{
			Vector3 actual = Vector3.Cross (new Vector3 (2,5,6), new Vector3 (6, 5, 2));
			Assert.AreEqual (new Vector3 (-20, 32, -20), actual);
		}

		[Test]
		public void Magnitude_GivenVector_ReturnMagnitudeOfTheVector ()
		{
			Assert.AreEqual (5, Vector3.Magnitude (new Vector3 (4, 3)));
		}

		[Test]
		public void Direction_GivenTwoVectors_ReturnDirectionVector ()
		{
			Assert.AreEqual (new Vector3 (3, 3), Vector3.Direction (new Vector3 (3, 3), new Vector3 (6, 6)));
			Assert.AreEqual (new Vector3 (6, 7), Vector3.Direction (new Vector3 (3, 3), new Vector3 (9, 10)));
		}

		[Test]
		public void Distance_GivenTwoVectors_ReturnDistanceToTarget ()
		{
			Assert.AreEqual (3, Vector3.Distance (new Vector3 (3, 3), new Vector3 (3, 6)));
			Assert.AreEqual (7, Vector3.Distance (new Vector3 (3, 3), new Vector3 (3, 10)));
		}

		[Test]
		public void Normalize_GivenVector_ReturnNormalizedVector ()
		{
			float expectedValue = Convert.ToSingle (1 / System.Math.Sqrt (2));
			Assert.AreEqual (new Vector3 (expectedValue, expectedValue), Vector3.Normalize (new Vector3 (2, 2)));

			Vector3 expectedVector = new Vector3 (
				Convert.ToSingle (5 / System.Math.Sqrt (89)),
				Convert.ToSingle (8 / System.Math.Sqrt (89))
			);

			Assert.AreEqual (expectedVector, Vector3.Normalize (new Vector3 (5, 8)));
		}
	}
}