using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.MathLib
{
	static class LeoMath
	{
		public static T Clamp<T> (T value, T min, T max) where T : IComparable<T>
		{
			if (value.CompareTo (min) < 0) return min;
			if (value.CompareTo (max) > 0) return max;
			return value;
		}

		public static int Abs (int value)
		{
			return System.Math.Abs (value);
		}

		public static float Abs (float value)
		{
			return System.Math.Abs (value);
		}

		public static float ToFloat (double value)
		{
			return Convert.ToSingle (value);
		}

		public static float Sqrt (float value)
		{
			return Convert.ToSingle (System.Math.Sqrt (value));
		}
	}
}
