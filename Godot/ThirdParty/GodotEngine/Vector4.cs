using System;
using System.Globalization;

namespace Godot
{
    [Serializable]
    public struct Vector4: IEquatable<Vector4>
    {
        public static readonly Vector4 zero = new Vector4();
        public static readonly Vector4 one = new Vector4(1f, 1f, 1f, 1f);
        public float X;
        public float Y;
        public float Z;
        public float W;
        
        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4(Vector2 value, float z, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
            this.W = w;
        }

        public Vector4(Vector3 value, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public Vector4(float value)
        {
            this.X = this.Y = this.Z = this.W = value;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{0}, {1}, {2}, {3}", (object) this.X.ToString(currentCulture),
                                 (object) this.Y.ToString(currentCulture),
                                 (object) this.Z.ToString(currentCulture),
                                 (object) this.W.ToString(currentCulture));
        }

        public bool Equals(Vector4 other)
        {
            if (this.X == (double) other.X && this.Y == (double) other.Y && this.Z == (double) other.Z)
                return this.W == (double) other.W;
            return false;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector4)
                flag = this.Equals((Vector4) obj);
            return flag;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode() + this.W.GetHashCode();
        }

        public float Length()
        {
            return (float) Math.Sqrt(this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z +
                                     this.W * (double) this.W);
        }

        public float LengthSquared()
        {
            return (float) (this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z +
                this.W * (double) this.W);
        }

        public static float Distance(Vector4 value1, Vector4 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            return (float) Math.Sqrt(num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3 +
                                     num4 * (double) num4);
        }

        public static void Distance(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            float num5 = (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3 +
                num4 * (double) num4);
            result = (float) Math.Sqrt(num5);
        }

        public static float DistanceSquared(Vector4 value1, Vector4 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            return (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3 +
                num4 * (double) num4);
        }

        public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            result = (float) (num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3 +
                num4 * (double) num4);
        }

        public static float Dot(Vector4 vector1, Vector4 vector2)
        {
            return (float) (vector1.X * (double) vector2.X + vector1.Y * (double) vector2.Y +
                vector1.Z * (double) vector2.Z + vector1.W * (double) vector2.W);
        }

        public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out float result)
        {
            result = (float) (vector1.X * (double) vector2.X + vector1.Y * (double) vector2.Y +
                vector1.Z * (double) vector2.Z + vector1.W * (double) vector2.W);
        }

        public void Normalize()
        {
            float num1 = (float) (this.X * (double) this.X + this.Y * (double) this.Y + this.Z * (double) this.Z +
                this.W * (double) this.W);
            if (num1 < (double) Mathf.Epsilon)
                return;
            float num2 = 1f / (float) Math.Sqrt(num1);
            this.X *= num2;
            this.Y *= num2;
            this.Z *= num2;
            this.W *= num2;
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            float num1 = (float) (vector.X * (double) vector.X + vector.Y * (double) vector.Y +
                vector.Z * (double) vector.Z + vector.W * (double) vector.W);
            if (num1 < (double) Mathf.Epsilon)
                return vector;
            float num2 = 1f / (float) Math.Sqrt(num1);
            Vector4 vector4;
            vector4.X = vector.X * num2;
            vector4.Y = vector.Y * num2;
            vector4.Z = vector.Z * num2;
            vector4.W = vector.W * num2;
            return vector4;
        }

        public static void Normalize(ref Vector4 vector, out Vector4 result)
        {
            float num1 = (float) (vector.X * (double) vector.X + vector.Y * (double) vector.Y +
                vector.Z * (double) vector.Z + vector.W * (double) vector.W);
            if (num1 < (double) Mathf.Epsilon)
            {
                result = vector;
            }
            else
            {
                float num2 = 1f / (float) Math.Sqrt(num1);
                result.X = vector.X * num2;
                result.Y = vector.Y * num2;
                result.Z = vector.Z * num2;
                result.W = vector.W * num2;
            }
        }

        public static Vector4 Min(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            vector4.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
            vector4.Z = (double) value1.Z < (double) value2.Z? value1.Z : value2.Z;
            vector4.W = (double) value1.W < (double) value2.W? value1.W : value2.W;
            return vector4;
        }

        public static void Min(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
            result.Z = (double) value1.Z < (double) value2.Z? value1.Z : value2.Z;
            result.W = (double) value1.W < (double) value2.W? value1.W : value2.W;
        }

        public static Vector4 Max(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            vector4.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
            vector4.Z = (double) value1.Z > (double) value2.Z? value1.Z : value2.Z;
            vector4.W = (double) value1.W > (double) value2.W? value1.W : value2.W;
            return vector4;
        }

        public static void Max(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
            result.Z = (double) value1.Z > (double) value2.Z? value1.Z : value2.Z;
            result.W = (double) value1.W > (double) value2.W? value1.W : value2.W;
        }

        public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            float z = value1.Z;
            float num5 = (double) z > (double) max.Z? max.Z : z;
            float num6 = (double) num5 < (double) min.Z? min.Z : num5;
            float w = value1.W;
            float num7 = (double) w > (double) max.W? max.W : w;
            float num8 = (double) num7 < (double) min.W? min.W : num7;
            Vector4 vector4;
            vector4.X = num2;
            vector4.Y = num4;
            vector4.Z = num6;
            vector4.W = num8;
            return vector4;
        }

        public static void Clamp(ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            float z = value1.Z;
            float num5 = (double) z > (double) max.Z? max.Z : z;
            float num6 = (double) num5 < (double) min.Z? min.Z : num5;
            float w = value1.W;
            float num7 = (double) w > (double) max.W? max.W : w;
            float num8 = (double) num7 < (double) min.W? min.W : num7;
            result.X = num2;
            result.Y = num4;
            result.Z = num6;
            result.W = num8;
        }

        public static Vector4 Lerp(Vector4 value1, Vector4 value2, float amount)
        {
            Vector4 vector4;
            vector4.X = value1.X + (value2.X - value1.X) * amount;
            vector4.Y = value1.Y + (value2.Y - value1.Y) * amount;
            vector4.Z = value1.Z + (value2.Z - value1.Z) * amount;
            vector4.W = value1.W + (value2.W - value1.W) * amount;
            return vector4;
        }

        public static void Lerp(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
            result.Z = value1.Z + (value2.Z - value1.Z) * amount;
            result.W = value1.W + (value2.W - value1.W) * amount;
        }

        public static Vector4 SmoothStep(Vector4 value1, Vector4 value2, float amount)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            Vector4 vector4;
            vector4.X = value1.X + (value2.X - value1.X) * amount;
            vector4.Y = value1.Y + (value2.Y - value1.Y) * amount;
            vector4.Z = value1.Z + (value2.Z - value1.Z) * amount;
            vector4.W = value1.W + (value2.W - value1.W) * amount;
            return vector4;
        }

        public static void SmoothStep(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
            result.Z = value1.Z + (value2.Z - value1.Z) * amount;
            result.W = value1.W + (value2.W - value1.W) * amount;
        }

        public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
        {
            float num1 = amount * amount;
            float num2 = amount * num1;
            float num3 = (float) (2.0 * num2 - 3.0 * num1 + 1.0);
            float num4 = (float) (-2.0 * num2 + 3.0 * num1);
            float num5 = num2 - 2f * num1 + amount;
            float num6 = num2 - num1;
            Vector4 vector4;
            vector4.X = (float) (value1.X * (double) num3 + value2.X * (double) num4 + tangent1.X * (double) num5 +
                tangent2.X * (double) num6);
            vector4.Y = (float) (value1.Y * (double) num3 + value2.Y * (double) num4 + tangent1.Y * (double) num5 +
                tangent2.Y * (double) num6);
            vector4.Z = (float) (value1.Z * (double) num3 + value2.Z * (double) num4 + tangent1.Z * (double) num5 +
                tangent2.Z * (double) num6);
            vector4.W = (float) (value1.W * (double) num3 + value2.W * (double) num4 + tangent1.W * (double) num5 +
                tangent2.W * (double) num6);
            return vector4;
        }

        public static void Hermite(
            ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result)
        {
            float num1 = amount * amount;
            float num2 = amount * num1;
            float num3 = (float) (2.0 * num2 - 3.0 * num1 + 1.0);
            float num4 = (float) (-2.0 * num2 + 3.0 * num1);
            float num5 = num2 - 2f * num1 + amount;
            float num6 = num2 - num1;
            result.X = (float) (value1.X * (double) num3 + value2.X * (double) num4 + tangent1.X * (double) num5 +
                tangent2.X * (double) num6);
            result.Y = (float) (value1.Y * (double) num3 + value2.Y * (double) num4 + tangent1.Y * (double) num5 +
                tangent2.Y * (double) num6);
            result.Z = (float) (value1.Z * (double) num3 + value2.Z * (double) num4 + tangent1.Z * (double) num5 +
                tangent2.Z * (double) num6);
            result.W = (float) (value1.W * (double) num3 + value2.W * (double) num4 + tangent1.W * (double) num5 +
                tangent2.W * (double) num6);
        }

        public static Vector4 Project(Vector4 vector, Vector4 onNormal)
        {
            return onNormal * Vector4.Dot(vector, onNormal) / Vector4.Dot(onNormal, onNormal);
        }

        public static void Project(ref Vector4 vector, ref Vector4 onNormal, out Vector4 result)
        {
            result = onNormal * Vector4.Dot(vector, onNormal) / Vector4.Dot(onNormal, onNormal);
        }

        public static Vector4 Negate(Vector4 value)
        {
            Vector4 vector4;
            vector4.X = -value.X;
            vector4.Y = -value.Y;
            vector4.Z = -value.Z;
            vector4.W = -value.W;
            return vector4;
        }

        public static void Negate(ref Vector4 value, out Vector4 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = -value.W;
        }

        public static Vector4 Add(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X + value2.X;
            vector4.Y = value1.Y + value2.Y;
            vector4.Z = value1.Z + value2.Z;
            vector4.W = value1.W + value2.W;
            return vector4;
        }

        public static void Add(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
            result.W = value1.W + value2.W;
        }

        public static Vector4 Sub(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X - value2.X;
            vector4.Y = value1.Y - value2.Y;
            vector4.Z = value1.Z - value2.Z;
            vector4.W = value1.W - value2.W;
            return vector4;
        }

        public static void Sub(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
            result.W = value1.W - value2.W;
        }

        public static Vector4 Multiply(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X * value2.X;
            vector4.Y = value1.Y * value2.Y;
            vector4.Z = value1.Z * value2.Z;
            vector4.W = value1.W * value2.W;
            return vector4;
        }

        public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
            result.W = value1.W * value2.W;
        }

        public static Vector4 Multiply(Vector4 value1, float scaleFactor)
        {
            Vector4 vector4;
            vector4.X = value1.X * scaleFactor;
            vector4.Y = value1.Y * scaleFactor;
            vector4.Z = value1.Z * scaleFactor;
            vector4.W = value1.W * scaleFactor;
            return vector4;
        }

        public static void Multiply(ref Vector4 value1, float scaleFactor, out Vector4 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
            result.W = value1.W * scaleFactor;
        }

        public static Vector4 Divide(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X / value2.X;
            vector4.Y = value1.Y / value2.Y;
            vector4.Z = value1.Z / value2.Z;
            vector4.W = value1.W / value2.W;
            return vector4;
        }

        public static void Divide(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
            result.W = value1.W / value2.W;
        }

        public static Vector4 Divide(Vector4 value1, float divider)
        {
            float num = 1f / divider;
            Vector4 vector4;
            vector4.X = value1.X * num;
            vector4.Y = value1.Y * num;
            vector4.Z = value1.Z * num;
            vector4.W = value1.W * num;
            return vector4;
        }

        public static void Divide(ref Vector4 value1, float divider, out Vector4 result)
        {
            float num = 1f / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
            result.W = value1.W * num;
        }

        public static Vector4 operator -(Vector4 value)
        {
            Vector4 vector4;
            vector4.X = -value.X;
            vector4.Y = -value.Y;
            vector4.Z = -value.Z;
            vector4.W = -value.W;
            return vector4;
        }

        public static bool operator ==(Vector4 value1, Vector4 value2)
        {
            if (value1.X == (double) value2.X && value1.Y == (double) value2.Y && value1.Z == (double) value2.Z)
                return value1.W == (double) value2.W;
            return false;
        }

        public static bool operator !=(Vector4 value1, Vector4 value2)
        {
            if (value1.X == (double) value2.X && value1.Y == (double) value2.Y && value1.Z == (double) value2.Z)
                return value1.W != (double) value2.W;
            return true;
        }

        public static Vector4 operator +(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X + value2.X;
            vector4.Y = value1.Y + value2.Y;
            vector4.Z = value1.Z + value2.Z;
            vector4.W = value1.W + value2.W;
            return vector4;
        }

        public static Vector4 operator -(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X - value2.X;
            vector4.Y = value1.Y - value2.Y;
            vector4.Z = value1.Z - value2.Z;
            vector4.W = value1.W - value2.W;
            return vector4;
        }

        public static Vector4 operator *(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X * value2.X;
            vector4.Y = value1.Y * value2.Y;
            vector4.Z = value1.Z * value2.Z;
            vector4.W = value1.W * value2.W;
            return vector4;
        }

        public static Vector4 operator *(Vector4 value1, float scaleFactor)
        {
            Vector4 vector4;
            vector4.X = value1.X * scaleFactor;
            vector4.Y = value1.Y * scaleFactor;
            vector4.Z = value1.Z * scaleFactor;
            vector4.W = value1.W * scaleFactor;
            return vector4;
        }

        public static Vector4 operator *(float scaleFactor, Vector4 value1)
        {
            Vector4 vector4;
            vector4.X = value1.X * scaleFactor;
            vector4.Y = value1.Y * scaleFactor;
            vector4.Z = value1.Z * scaleFactor;
            vector4.W = value1.W * scaleFactor;
            return vector4;
        }

        public static Vector4 operator /(Vector4 value1, Vector4 value2)
        {
            Vector4 vector4;
            vector4.X = value1.X / value2.X;
            vector4.Y = value1.Y / value2.Y;
            vector4.Z = value1.Z / value2.Z;
            vector4.W = value1.W / value2.W;
            return vector4;
        }

        public static Vector4 operator /(Vector4 value1, float divider)
        {
            float num = 1f / divider;
            Vector4 vector4;
            vector4.X = value1.X * num;
            vector4.Y = value1.Y * num;
            vector4.Z = value1.Z * num;
            vector4.W = value1.W * num;
            return vector4;
        }
    }
}