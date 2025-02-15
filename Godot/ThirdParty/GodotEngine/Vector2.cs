using System;
using System.Globalization;

namespace Godot
{
    [Serializable]
    public struct Vector2: IEquatable<Vector2>
    {
        public static readonly Vector2 zero = new Vector2();
        public static readonly Vector2 one = new Vector2(1f, 1f);
        
        public float X;
        public float Y;
        
        public static implicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.X, v.Y, 0.0f);
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(float value)
        {
            this.X = this.Y = value;
        }

        public float this[int index]
        {
            get
            {
                if (index == 0)
                    return this.X;
                if (index == 1)
                    return this.Y;
                throw new IndexOutOfRangeException("Invalid Vector2 index!");
            }
            set
            {
                if (index != 0)
                {
                    if (index != 1)
                        throw new IndexOutOfRangeException("Invalid Vector2 index!");
                    this.Y = value;
                }
                else
                    this.X = value;
            }
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{0}, {1}",
                                 new object[2]
                                 {
                                     this.X.ToString(currentCulture),
                                     this.Y.ToString(currentCulture)
                                 });
        }

        public bool Equals(Vector2 other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector2)
                flag = this.Equals((Vector2) obj);
            return flag;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }

        public float Length()
        {
            return (float) Math.Sqrt(this.X * (double) this.X + this.Y * (double) this.Y);
        }

        public float LengthSquared()
        {
            return (float) (this.X * (double) this.X + this.Y * (double) this.Y);
        }
        
        public float magnitude
        {
            get
            {
                return this.Length();
            }
        }
        
        public float sqrMagnitude
        {
            get
            {
                return this.LengthSquared();
            }
        }

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            return (float) Math.Sqrt(num1 * (double) num1 + num2 * (double) num2);
        }

        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = (float) (num1 * (double) num1 + num2 * (double) num2);
            result = (float) Math.Sqrt(num3);
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            return (float) (num1 * (double) num1 + num2 * (double) num2);
        }

        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            float num1 = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            result = (float) (num1 * (double) num1 + num2 * (double) num2);
        }

        public void Normalize()
        {
            float num1 = (float) (this.X * (double) this.X + this.Y * (double) this.Y);
            if (num1 < 9.99999974737875E-06)
                return;
            float num2 = 1f / (float) Math.Sqrt(num1);
            this.X *= num2;
            this.Y *= num2;
        }

        public static Vector2 Normalize(Vector2 value)
        {
            float num1 = (float) (value.X * (double) value.X + value.Y * (double) value.Y);
            if (num1 < 9.99999974737875E-06)
                return value;
            float num2 = 1f / (float) Math.Sqrt(num1);
            Vector2 vector2;
            vector2.X = value.X * num2;
            vector2.Y = value.Y * num2;
            return vector2;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float num1 = (float) (value.X * (double) value.X + value.Y * (double) value.Y);
            if (num1 < 9.99999974737875E-06)
            {
                result = value;
            }
            else
            {
                float num2 = 1f / (float) Math.Sqrt(num1);
                result.X = value.X * num2;
                result.Y = value.Y * num2;
            }
        }
        
        public Vector2 normalized
        {
            get
            {
                return Vector2.Normalize(this);
            }
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            float num = (float) (vector.X * (double) normal.X + vector.Y * (double) normal.Y);
            Vector2 vector2;
            vector2.X = vector.X - 2f * num * normal.X;
            vector2.Y = vector.Y - 2f * num * normal.Y;
            return vector2;
        }

        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            float num = (float) (vector.X * (double) normal.X + vector.Y * (double) normal.Y);
            result.X = vector.X - 2f * num * normal.X;
            result.Y = vector.Y - 2f * num * normal.Y;
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            vector2.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
            return vector2;
        }

        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = (double) value1.X < (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y < (double) value2.Y? value1.Y : value2.Y;
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            vector2.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
            return vector2;
        }

        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = (double) value1.X > (double) value2.X? value1.X : value2.X;
            result.Y = (double) value1.Y > (double) value2.Y? value1.Y : value2.Y;
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            Vector2 vector2;
            vector2.X = num2;
            vector2.Y = num4;
            return vector2;
        }

        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            float x = value1.X;
            float num1 = (double) x > (double) max.X? max.X : x;
            float num2 = (double) num1 < (double) min.X? min.X : num1;
            float y = value1.Y;
            float num3 = (double) y > (double) max.Y? max.Y : y;
            float num4 = (double) num3 < (double) min.Y? min.Y : num3;
            result.X = num2;
            result.Y = num4;
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            Vector2 vector2;
            vector2.X = value1.X + (value2.X - value1.X) * amount;
            vector2.Y = value1.Y + (value2.Y - value1.Y) * amount;
            return vector2;
        }

        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            Vector2 vector2;
            vector2.X = value1.X + (value2.X - value1.X) * amount;
            vector2.Y = value1.Y + (value2.Y - value1.Y) * amount;
            return vector2;
        }

        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            amount = (double) amount > 1.0? 1f : ((double) amount < 0.0? 0.0f : amount);
            amount = (float) (amount * (double) amount * (3.0 - 2.0 * amount));
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;
        }

        public static Vector2 Negate(Vector2 value)
        {
            Vector2 vector2;
            vector2.X = -value.X;
            vector2.Y = -value.Y;
            return vector2;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return (float) (value1.X * (double) value2.X + value1.Y * (double) value2.Y);
        }

        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = (float) (value1.X * (double) value2.X + value1.Y * (double) value2.Y);
        }

        public static float Angle(Vector2 from, Vector2 to)
        {
            from.Normalize();
            to.Normalize();
            float result;
            Vector2.Dot(ref from, ref to, out result);
            return Mathf.Cos(Mathf.Clamp(result, -1f, 1f)) * 57.29578f;
        }

        public static void Angle(ref Vector2 from, ref Vector2 to, out float result)
        {
            from.Normalize();
            to.Normalize();
            float result1;
            Vector2.Dot(ref from, ref to, out result1);
            result = Mathf.Cos(Mathf.Clamp(result1, -1f, 1f)) * 57.29578f;
        }

        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X + value2.X;
            vector2.Y = value1.Y + value2.Y;
            return vector2;
        }

        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static Vector2 Sub(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X - value2.X;
            vector2.Y = value1.Y - value2.Y;
            return vector2;
        }

        public static void Sub(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X * value2.X;
            vector2.Y = value1.Y * value2.Y;
            return vector2;
        }

        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static Vector2 Multiply(Vector2 value1, float scaleFactor)
        {
            Vector2 vector2;
            vector2.X = value1.X * scaleFactor;
            vector2.Y = value1.Y * scaleFactor;
            return vector2;
        }

        public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X / value2.X;
            vector2.Y = value1.Y / value2.Y;
            return vector2;
        }

        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static Vector2 Divide(Vector2 value1, float divider)
        {
            float num = 1f / divider;
            Vector2 vector2;
            vector2.X = value1.X * num;
            vector2.Y = value1.Y * num;
            return vector2;
        }

        public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
        {
            float num = 1f / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
        }

        public static Vector2 operator -(Vector2 value)
        {
            Vector2 vector2;
            vector2.X = -value.X;
            vector2.Y = -value.Y;
            return vector2;
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return (lhs - rhs).sqrMagnitude < 9.99999943962493E-11;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X + value2.X;
            vector2.Y = value1.Y + value2.Y;
            return vector2;
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X - value2.X;
            vector2.Y = value1.Y - value2.Y;
            return vector2;
        }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X * value2.X;
            vector2.Y = value1.Y * value2.Y;
            return vector2;
        }

        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            Vector2 vector2;
            vector2.X = value.X * scaleFactor;
            vector2.Y = value.Y * scaleFactor;
            return vector2;
        }

        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            Vector2 vector2;
            vector2.X = value.X * scaleFactor;
            vector2.Y = value.Y * scaleFactor;
            return vector2;
        }

        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            Vector2 vector2;
            vector2.X = value1.X / value2.X;
            vector2.Y = value1.Y / value2.Y;
            return vector2;
        }

        public static Vector2 operator /(Vector2 value1, float divider)
        {
            float num = 1f / divider;
            Vector2 vector2;
            vector2.X = value1.X * num;
            vector2.Y = value1.Y * num;
            return vector2;
        }
    }
}