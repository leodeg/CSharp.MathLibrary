using LeoDeg.Math.Matrices;
using LeoDeg.Math.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeoDeg.Math.Quaternions
{
	public class Quaternion
	{
		float x, y, z, w;

		public Quaternion (float x, float y, float z, float w)
		{
			this.x = x; this.y = y;
			this.z = z; this.w = w;
		}

		public Quaternion (Vector3 xyz, float w)
		{
			this.x = xyz.x; this.y = xyz.y;
			this.z = xyz.z; this.w = w;
		}

		public Quaternion (Vector4 values)
		{
			this.x = values.x; this.y = values.y;
			this.z = values.z; this.w = values.w;
		}

		public Vector3 ToVector3 ()
		{
			return new Vector3 (x, y, z);
		}

		public Vector4 ToVector4 ()
		{
			return new Vector4 (x, y, z, w);
		}

		public override string ToString ()
		{
			return string.Format ("<{0}, {1}, {2}, {3}>", x, y, z, w);
		}

		public static Quaternion operator * (Quaternion q1, Quaternion q2)
		{
			return new Quaternion (
				(q1.w * q2.x) + (q1.x * q2.w) + (q1.y * q2.z) - (q1.z * q2.y),
				(q1.w * q2.y) - (q1.x * q2.z) + (q1.y * q2.w) + (q1.z * q2.x),
				(q1.w * q2.z) + (q1.x * q2.y) - (q1.y * q2.x) + (q1.z * q2.w),
				(q1.w * q2.w) - (q1.x * q2.x) - (q1.y * q2.y) - (q1.z * q2.z));
		}

		public static Vector3 Transform (Vector3 vector, Quaternion quaternion)
		{
			Vector3 qVector = quaternion.ToVector3 ();
			return
				(vector * ((quaternion.w * quaternion.w) - Vector3.Dot (qVector))) +
				(qVector * (Vector3.Dot (vector, qVector) * 2.0F)) +
				(Vector3.Cross (qVector, vector) * (quaternion.w * 2.0F));
		}

		public Matrice3 GetRotationMatrix ()
		{
			float x2 = x * x;
			float y2 = y * y;
			float z2 = z * z;
			float xy = x * y;
			float xz = x * z;
			float yz = y * z;
			float wx = w * x;
			float wy = w * y;
			float wz = w * z;

			return new Matrice3 (
				1.0F - 2.0F * (y2 + z2), 2.0F * (xy - wz), 2.0F * (xz + wy),
				2.0F * (xy + wz), 1.0F - 2.0F * (x2 + z2), 2.0F * (yz - wx),
				2.0F * (xz - wy), 2.0F * (yz + wx), 1.0F - 2.0F * (x2 + y2));
		}

		public void SetRotationMatrix (Matrice3 rotation)
		{
			float rotation00 = rotation[0, 0];
			float rotation11 = rotation[1, 1];
			float rotation22 = rotation[2, 2];
			float sum = rotation00 + rotation11 + rotation22;

			if (sum > 0.0F)
			{
				w = LeoMath.Sqrt (sum + 1.0F) * 0.5F;
				float f = 0.25F / w;

				x = (rotation[2, 1] - rotation[1, 2]) * f;
				y = (rotation[0, 2] - rotation[2, 0]) * f;
				z = (rotation[1, 0] - rotation[0, 1]) * f;
			}
			else if ((rotation00 > rotation11) && (rotation00 > rotation22))
			{
				x = LeoMath.Sqrt (rotation00 - rotation11 - rotation22 + 1.0F) * 0.5F;
				float f = 0.25F / x;

				y = (rotation[1, 0] + rotation[0, 1]) * f;
				z = (rotation[0, 2] + rotation[2, 0]) * f;
				w = (rotation[2, 1] - rotation[1, 2]) * f;
			}
			else if (rotation11 > rotation22)
			{
				y = LeoMath.Sqrt (rotation11 - rotation00 - rotation22 + 1.0F) * 0.5F;
				float f = 0.25F / y;

				x = (rotation[1, 0] + rotation[0, 1]) * f;
				z = (rotation[2, 1] + rotation[1, 2]) * f;
				w = (rotation[0, 2] - rotation[2, 0]) * f;
			}
			else
			{
				z = LeoMath.Sqrt (rotation22 - rotation00 - rotation11 + 1.0F) * 0.5F;
				float f = 0.25F / z;

				x = (rotation[0, 2] + rotation[2, 0]) * f;
				y = (rotation[2, 1] + rotation[1, 2]) * f;
				w = (rotation[1, 0] - rotation[0, 1]) * f;
			}
		}
	}
}
