using System;
using NUnit.Framework;
using LeoDeg.MathLib.Vectors;

namespace LeoDeg.MathLibUnitTests
{
    [TestFixture]
    public class Vector2Tests
    {
		[Test]
		public void Dot_WhenCalled_ReturnDotProductOfTwoVectors ()
		{
            float actual = Vector2.Dot (new Vector2 (2, 1), new Vector2 (2, 3));
            float expected = 7;
            Assert.AreEqual (expected, actual);
		}

        [Test]
        public void Dot_WhenCalled_ReturnDotProductBetweenCurrentPosAndTarget ()
        {
            Vector2 vector = new Vector2 (2, 1);
            float actual = vector.Dot (new Vector2 (2, 3));
            float expected = 7;
            Assert.AreEqual (expected, actual);
        }

        [Test]
        public void Dot_WhenCalled_ReturnDotProductOfTwoValues ()
        {
            float actual = Vector2.Dot (2, 3);
            float expected = 13;
            Assert.AreEqual (expected, actual);
        }
    }
}
