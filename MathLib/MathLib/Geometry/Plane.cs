using System;
using LeoDeg.Math.Matrices;
using LeoDeg.Math.Vectors;
using LeoDeg.Math;

namespace LeoDeg.Math.Geometry
{
	public class Plane
	{
		public Vector3 Start { get; set; }
		public Vector3 FirstVector { get; set; }
		public Vector3 SecondVector { get; set; }
		public Vector3 End { get { return FirstVector + SecondVector; } }

		public Vector3 DirToFirst { get { return Vector3.Direction (Start, FirstVector); } }
		public Vector3 DirToSecond { get { return Vector3.Direction (Start, SecondVector); } }
		public Vector3 DirToEnd { get { return Vector3.Direction (Start, End); } }

		public Plane (Vector3 start, Vector3 firstVector, Vector3 secondVector)
		{
			Start = start;
			FirstVector = firstVector;
			SecondVector = secondVector;
		}

		public Vector3 Lerp (float height, float width)
		{
			return new Vector3 (
				Start.x + DirToFirst.x * height + DirToSecond.x * width,
				Start.y + DirToFirst.y * height + DirToSecond.y * width,
				Start.z + DirToFirst.z * height + DirToSecond.z * width);
		}
	}
}
