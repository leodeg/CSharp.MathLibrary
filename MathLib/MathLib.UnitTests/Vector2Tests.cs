using System;
using NUnit.Framework;
using LeoDeg.Math.Vectors;
using NUnit.Framework.Constraints;

namespace LeoDeg.MathLibUnitTests
{
	[TestFixture]
	public class Vector2Tests
	{
		[Test]
		public void Add_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector2 (4, 4), new Vector2 (2, 2) + new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (5, 8), new Vector2 (3, 6) + new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (-1, -3), new Vector2 (-3, -5) + new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (-5, -7), new Vector2 (-3, -5) + new Vector2 (-2, -2));
		}

		[Test]
		public void Substract_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector2 (0, 0), new Vector2 (2, 2) - new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (1, 4), new Vector2 (3, 6) - new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (-5, -7), new Vector2 (-3, -5) - new Vector2 (2, 2));
			Assert.AreEqual (new Vector2 (-1, -3), new Vector2 (-3, -5) - new Vector2 (-2, -2));
		}

		[Test]
		public void MultiplyByScalarValue_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector2 (4, 4), new Vector2 (2, 2) * 2);
			Assert.AreEqual (new Vector2 (9, 18), new Vector2 (3, 6) * 3);
			Assert.AreEqual (new Vector2 (6, 10), new Vector2 (-3, -5) * -2);
			Assert.AreEqual (new Vector2 (-9, -15), new Vector2 (3, 5) * -3);
		}

		[Test]
		public void DivideByScalarValue_GivenTwoVectors_ReturnNewVector ()
		{
			Assert.AreEqual (new Vector2 (1, 1), new Vector2 (2, 2) / 2);
			Assert.AreEqual (new Vector2 (1, 2), new Vector2 (3, 6) / 3);
		}

		[Test]
		public void Equals_GivenTwoVectors_VectorsAreEqualToEachOther_ReturnTrue ()
		{
			Assert.AreEqual (true, new Vector2 (2, 2) == new Vector2 (2, 2));
		}

		[Test]
		public void Equals_GivenTwoVectors_VectorsAreNotEqualToEachOther_ReturnFalse ()
		{
			Assert.AreEqual (false, new Vector2 (2, 2) == new Vector2 (3, 2));
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsHaveTheSameDirections_ReturnPositiveValue ()
		{
			float actual = Vector2.Dot (new Vector2 (2, 1), new Vector2 (2, 3));
			float expected = 7;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsHaveOppositeDirections_ReturnNegativeValue ()
		{
			float actual = Vector2.Dot (new Vector2 (-2, 1), new Vector2 (2, 3));
			float expected = -1;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoVectors_WhenVectorsAreOrthogonal_ReturnZeroVlue ()
		{
			float actual = Vector2.Dot (new Vector2 (0, 1), new Vector2 (1, 0));
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsHaveTheSameDirections_ReturnPositiveValue ()
		{
			Vector2 vector = new Vector2 (2, 1);
			float actual = vector.Dot (new Vector2 (2, 3));
			float expected = 7;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsHaveOppositeDirections_ReturnNegativeValue ()
		{
			Vector2 vector = new Vector2 (-2, 1);
			float actual = vector.Dot (new Vector2 (2, 3));
			float expected = -1;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenOtherVector_WhenVectorsAreOrthogonal_ReturnZeroVlue ()
		{
			Vector2 vector = new Vector2 (0, 1);
			float actual = vector.Dot (new Vector2 (1, 0));
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesPositive_ReturnPositiveValue ()
		{
			float actual = Vector2.Dot (2, 3);
			float expected = 13;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesNegative_ReturnPositiveValue ()
		{
			float actual = Vector2.Dot (-2, -3);
			float expected = 13;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Dot_GivenTwoValues_WhenValuesZero_ReturnZero ()
		{
			float actual = Vector2.Dot (0, 0);
			float expected = 0;
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void Magnitude_GivenVector_ReturnMagnitudeOfTheVector ()
		{
			Assert.AreEqual (5, Vector2.Magnitude (new Vector2 (4, 3)));
		}

		[Test]
		public void Direction_GivenTwoVectors_ReturnDirectionVector ()
		{
			Assert.AreEqual (new Vector2 (3, 3), Vector2.Direction (new Vector2 (3, 3), new Vector2 (6, 6)));
			Assert.AreEqual (new Vector2 (6, 7), Vector2.Direction (new Vector2 (3, 3), new Vector2 (9, 10)));
		}

		[Test]
		public void Distance_GivenTwoVectors_ReturnDistanceToTarget ()
		{
			Assert.AreEqual (3, Vector2.Distance (new Vector2 (3, 3), new Vector2 (3, 6)));
			Assert.AreEqual (7, Vector2.Distance (new Vector2 (3, 3), new Vector2 (3, 10)));
		}


		[Test]
		public void Normalize_GivenVectors_ReturnNormalizedVector ()
		{
			float expectedValue = Convert.ToSingle (1 / System.Math.Sqrt (2));
			Assert.AreEqual (new Vector2 (expectedValue, expectedValue), Vector2.Normalize (new Vector2 (2, 2)));

			Vector2 expectedVector = new Vector2 (
				Convert.ToSingle (5 / System.Math.Sqrt (89)),
				Convert.ToSingle (8 / System.Math.Sqrt (89))
			);

			Assert.AreEqual (expectedVector, Vector2.Normalize (new Vector2 (5, 8)));
		}
	}
}
