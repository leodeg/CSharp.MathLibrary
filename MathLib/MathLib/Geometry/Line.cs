using System;
using LeoDeg.Math.Matrices;
using LeoDeg.Math.Vectors;
using LeoDeg.MathLib;

namespace LeoDeg.Math.Geometry
{
	public class Line
	{
		public enum LineType { Line, Segment, Ray }

		private Vector3 startPoint;
		private Vector3 endPoint;
		private LineType type;

		public Line ()
		{
			startPoint = Vector3.Zero;
			endPoint = Vector3.Zero;
		}

		public Line (Vector3 startPoint, Vector3 endPoint)
		{
			if (startPoint == null || endPoint == null)
				throw new ArgumentNullException (nameof (startPoint));

			this.startPoint = startPoint;
			this.endPoint = endPoint;
			this.type = LineType.Segment;
		}

		public Line (Vector3 startPoint, Vector3 endPoint, LineType lineType)
		{
			this.startPoint = startPoint;
			this.endPoint = endPoint;
			this.type = lineType;
		}

		public Vector3 Direction { get { return Vector3.Direction (startPoint, endPoint); } }

		/// <summary>
		/// Get point position at a time on the current line.
		/// </summary>
		public Vector3 Lerp (float time)
		{
			time = ClampTime (time);
			return new Vector3 (
				startPoint.x + Direction.x * time,
				startPoint.y + Direction.y * time,
				startPoint.z + Direction.z * time
			);
		}

		private float ClampTime (float time)
		{
			switch (type)
			{
				case LineType.Line:
					return time;

				case LineType.Segment:
					return LeoMath.Clamp (time, 0, 1);

				case LineType.Ray:
					if (time < 0) return 0;
					return time;

				default:
					throw new ArgumentOutOfRangeException ("Line::Error::Invalid line type.");
			}
		}
	}
}
