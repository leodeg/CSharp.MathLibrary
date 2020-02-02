using System;
using LeoDeg.Math.Matrices;
using LeoDeg.Math.Vectors;
using LeoDeg.Math;

namespace LeoDeg.Math.Geometry
{
	public class Line
	{
		public enum LineType { Line, Segment, Ray }

		public Line ()
		{
			StartPoint = Vector3.Zero;
			EndPoint = Vector3.Zero;
		}

		public Line (Vector3 startPoint, Vector3 endPoint)
		{
			if (startPoint == null || endPoint == null)
				throw new ArgumentNullException (nameof (startPoint));

			this.StartPoint = startPoint;
			this.EndPoint = endPoint;
			this.Type = LineType.Segment;
		}

		public Line (Vector3 startPoint, Vector3 endPoint, LineType lineType)
		{
			this.StartPoint = startPoint;
			this.EndPoint = endPoint;
			this.Type = lineType;
		}

		public Vector3 StartPoint { get; set; }
		public Vector3 EndPoint { get; set; }
		public LineType Type { get; set; }
		public Vector3 Direction { get { return Vector3.Direction (StartPoint, EndPoint); } }

		/// <summary>
		/// If lines is parallel to each other return float.Nan, otherwise return position at the current line.
		/// </summary>
		public float IntersectAt (Line other)
		{
			if (Vector3.Dot (Vector3.Perp (other.Direction), this.Direction) == 0)
				return float.NaN;

			Vector3 directionToOtherStart = Vector3.Direction (this.StartPoint, other.StartPoint);
			float dotToDirectionBetweenStarts = Vector3.Dot (Vector3.Perp (other.Direction), directionToOtherStart);
			float dotToCurrentDirection = Vector3.Dot (Vector3.Perp (other.Direction), Direction);
			float position = dotToDirectionBetweenStarts / dotToCurrentDirection;

			if ((position < 0 || position > 1) && Type == LineType.Segment)
				return float.NaN;

			return position;
		}

		public Vector3 Reflect (Vector3 normal)
		{
			Vector3 directionNormal = Direction.normalized;
			float dot = Vector3.Dot (directionNormal, normal);
			if (dot == 0) return this.Direction;

			return directionNormal - (2.0f * Vector3.Dot (directionNormal, normal) * normal);
		}

		/// <summary>
		/// Get point position at a time on the current line.
		/// </summary>
		public Vector3 Lerp (float time)
		{
			time = ClampTime (time);
			return new Vector3 (
				StartPoint.x + Direction.x * time,
				StartPoint.y + Direction.y * time,
				StartPoint.z + Direction.z * time
			);
		}

		private float ClampTime (float time)
		{
			switch (Type)
			{
				case LineType.Line: return time;
				case LineType.Segment: return LeoMath.Clamp (time, 0, 1);
				case LineType.Ray:
					if (time < 0) return 0;
					return time;

				default: throw new ArgumentOutOfRangeException ("Line::Error::Invalid line type.");
			}
		}
	}
}
