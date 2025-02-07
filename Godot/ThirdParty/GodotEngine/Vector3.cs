#region 程序集 GodotSharp, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Administrator\.nuget\packages\godotsharp\4.4.0-beta\lib\net9.0\GodotSharp.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Godot;

//
// 摘要:
//     3-element structure that can be used to represent positions in 3D space or any
//     other pair of numeric values.
[Serializable]
public struct Vector3 : IEquatable<Vector3>
{
    //
    // 摘要:
    //     Enumerated index values for the axes. Returned by Godot.Vector3.MaxAxisIndex
    //     and Godot.Vector3.MinAxisIndex.
    public enum Axis
    {
        //
        // 摘要:
        //     The vector's X axis.
        X,
        //
        // 摘要:
        //     The vector's Y axis.
        Y,
        //
        // 摘要:
        //     The vector's Z axis.
        Z
    }

    //
    // 摘要:
    //     The vector's X component. Also accessible by using the index position [0].
    public float X;

    //
    // 摘要:
    //     The vector's Y component. Also accessible by using the index position [1].
    public float Y;

    //
    // 摘要:
    //     The vector's Z component. Also accessible by using the index position [2].
    public float Z;

    private static readonly Vector3 _zero = new Vector3(0f, 0f, 0f);

    private static readonly Vector3 _one = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 _inf = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

    private static readonly Vector3 _up = new Vector3(0f, 1f, 0f);

    private static readonly Vector3 _down = new Vector3(0f, -1f, 0f);

    private static readonly Vector3 _right = new Vector3(1f, 0f, 0f);

    private static readonly Vector3 _left = new Vector3(-1f, 0f, 0f);

    private static readonly Vector3 _forward = new Vector3(0f, 0f, -1f);

    private static readonly Vector3 _back = new Vector3(0f, 0f, 1f);

    private static readonly Vector3 _modelLeft = new Vector3(1f, 0f, 0f);

    private static readonly Vector3 _modelRight = new Vector3(-1f, 0f, 0f);

    private static readonly Vector3 _modelTop = new Vector3(0f, 1f, 0f);

    private static readonly Vector3 _modelBottom = new Vector3(0f, -1f, 0f);

    private static readonly Vector3 _modelFront = new Vector3(0f, 0f, 1f);

    private static readonly Vector3 _modelRear = new Vector3(0f, 0f, -1f);

    //
    // 摘要:
    //     Access vector components using their index.
    //
    // 值:
    //     [0] is equivalent to Godot.Vector3.X, [1] is equivalent to Godot.Vector3.Y, [2]
    //     is equivalent to Godot.Vector3.Z.
    //
    // 异常:
    //   T:System.ArgumentOutOfRangeException:
    //     index is not 0, 1 or 2.
    public float this[int index]
    {
        readonly get
        {
            return index switch
            {
                0 => X,
                1 => Y,
                2 => Z,
                _ => throw new ArgumentOutOfRangeException("index"),
            };
        }
        set
        {
            switch (index)
            {
                case 0:
                    X = value;
                    break;
                case 1:
                    Y = value;
                    break;
                case 2:
                    Z = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("index");
            }
        }
    }

    //
    // 摘要:
    //     Zero vector, a vector with all components set to 0.
    //
    // 值:
    //     Equivalent to new Vector3(0, 0, 0).
    public static Vector3 Zero => _zero;

    //
    // 摘要:
    //     One vector, a vector with all components set to 1.
    //
    // 值:
    //     Equivalent to new Vector3(1, 1, 1).
    public static Vector3 One => _one;

    //
    // 摘要:
    //     Infinity vector, a vector with all components set to Godot.Mathf.Inf.
    //
    // 值:
    //     Equivalent to new Vector3(Mathf.Inf, Mathf.Inf, Mathf.Inf).
    public static Vector3 Inf => _inf;

    //
    // 摘要:
    //     Up unit vector.
    //
    // 值:
    //     Equivalent to new Vector3(0, 1, 0).
    public static Vector3 Up => _up;

    //
    // 摘要:
    //     Down unit vector.
    //
    // 值:
    //     Equivalent to new Vector3(0, -1, 0).
    public static Vector3 Down => _down;

    //
    // 摘要:
    //     Right unit vector. Represents the local direction of right, and the global direction
    //     of east.
    //
    // 值:
    //     Equivalent to new Vector3(1, 0, 0).
    public static Vector3 Right => _right;

    //
    // 摘要:
    //     Left unit vector. Represents the local direction of left, and the global direction
    //     of west.
    //
    // 值:
    //     Equivalent to new Vector3(-1, 0, 0).
    public static Vector3 Left => _left;

    //
    // 摘要:
    //     Forward unit vector. Represents the local direction of forward, and the global
    //     direction of north.
    //
    // 值:
    //     Equivalent to new Vector3(0, 0, -1).
    public static Vector3 Forward => _forward;

    //
    // 摘要:
    //     Back unit vector. Represents the local direction of back, and the global direction
    //     of south.
    //
    // 值:
    //     Equivalent to new Vector3(0, 0, 1).
    public static Vector3 Back => _back;

    //
    // 摘要:
    //     Unit vector pointing towards the left side of imported 3D assets.
    public static Vector3 ModelLeft => _modelLeft;

    //
    // 摘要:
    //     Unit vector pointing towards the right side of imported 3D assets.
    public static Vector3 ModelRight => _modelRight;

    //
    // 摘要:
    //     Unit vector pointing towards the top side (up) of imported 3D assets.
    public static Vector3 ModelTop => _modelTop;

    //
    // 摘要:
    //     Unit vector pointing towards the bottom side (down) of imported 3D assets.
    public static Vector3 ModelBottom => _modelBottom;

    //
    // 摘要:
    //     Unit vector pointing towards the front side (facing forward) of imported 3D assets.
    public static Vector3 ModelFront => _modelFront;
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
    //
    // 摘要:
    //     Unit vector pointing towards the rear side (back) of imported 3D assets.
    public static Vector3 ModelRear => _modelRear;

    //
    // 摘要:
    //     Helper method for deconstruction into a tuple.
    public readonly void Deconstruct(out float x, out float y, out float z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    internal void Normalize()
    {
        float num = LengthSquared();
        if (num == 0f)
        {
            X = (Y = (Z = 0f));
            return;
        }

        float num2 = Mathf.Sqrt(num);
        X /= num2;
        Y /= num2;
        Z /= num2;
    }

    public static Vector3 Normalize(Vector3 value)
    {
        float num1 = (float)(value.X * (double)value.X + value.Y * (double)value.Y + value.Z * (double)value.Z);
        if (num1 < (double)Mathf.Epsilon)
            return value;
        float num2 = 1f / (float)Math.Sqrt(num1);
        Vector3 vector3;
        vector3.X = value.X * num2;
        vector3.Y = value.Y * num2;
        vector3.Z = value.Z * num2;
        return vector3;
    }

    public static void Normalize(ref Vector3 value, out Vector3 result)
    {
        float num1 = (float)(value.X * (double)value.X + value.Y * (double)value.Y + value.Z * (double)value.Z);
        if (num1 < (double)Mathf.Epsilon)
        {
            result = value;
        }
        else
        {
            float num2 = 1f / (float)Math.Sqrt(num1);
            result.X = value.X * num2;
            result.Y = value.Y * num2;
            result.Z = value.Z * num2;
        }
    }

    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        Vector3 vector3;
        vector3.X = (float)(vector1.Y * (double)vector2.Z - vector1.Z * (double)vector2.Y);
        vector3.Y = (float)(vector1.Z * (double)vector2.X - vector1.X * (double)vector2.Z);
        vector3.Z = (float)(vector1.X * (double)vector2.Y - vector1.Y * (double)vector2.X);
        return vector3;
    }

    public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
    {
        float num1 = (float)(vector1.Y * (double)vector2.Z - vector1.Z * (double)vector2.Y);
        float num2 = (float)(vector1.Z * (double)vector2.X - vector1.X * (double)vector2.Z);
        float num3 = (float)(vector1.X * (double)vector2.Y - vector1.Y * (double)vector2.X);
        result.X = num1;
        result.Y = num2;
        result.Z = num3;
    }

    //
    // 摘要:
    //     Returns a new vector with all components in absolute values (i.e. positive).
    //
    //
    // 返回结果:
    //     A vector with Godot.Mathf.Abs(System.Single) called on each component.
    public readonly Vector3 Abs()
    {
        return new Vector3(Mathf.Abs(X), Mathf.Abs(Y), Mathf.Abs(Z));
    }

    //
    // 摘要:
    //     Returns the unsigned minimum angle to the given vector, in radians.
    //
    // 参数:
    //   to:
    //     The other vector to compare this vector to.
    //
    // 返回结果:
    //     The unsigned angle between the two vectors, in radians.
    public readonly float AngleTo(Vector3 to)
    {
        return Mathf.Atan2(Cross(to).Length(), Dot(to));
    }

    //
    // 摘要:
    //     Returns this vector "bounced off" from a plane defined by the given normal.
    //
    // 参数:
    //   normal:
    //     The normal vector defining the plane to bounce off. Must be normalized.
    //
    // 返回结果:
    //     The bounced vector.
    public readonly Vector3 Bounce(Vector3 normal)
    {
        return -Reflect(normal);
    }

    //
    // 摘要:
    //     Returns a new vector with all components rounded up (towards positive infinity).
    //
    //
    // 返回结果:
    //     A vector with Godot.Mathf.Ceil(System.Single) called on each component.
    public readonly Vector3 Ceil()
    {
        return new Vector3(Mathf.Ceil(X), Mathf.Ceil(Y), Mathf.Ceil(Z));
    }

    //
    // 摘要:
    //     Returns a new vector with all components clamped between the components of min
    //     and max using Godot.Mathf.Clamp(System.Single,System.Single,System.Single).
    //
    // 参数:
    //   min:
    //     The vector with minimum allowed values.
    //
    //   max:
    //     The vector with maximum allowed values.
    //
    // 返回结果:
    //     The vector with all components clamped.
    public readonly Vector3 Clamp(Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(X, min.X, max.X), Mathf.Clamp(Y, min.Y, max.Y), Mathf.Clamp(Z, min.Z, max.Z));
    }

    //
    // 摘要:
    //     Returns a new vector with all components clamped between the min and max using
    //     Godot.Mathf.Clamp(System.Single,System.Single,System.Single).
    //
    // 参数:
    //   min:
    //     The minimum allowed value.
    //
    //   max:
    //     The maximum allowed value.
    //
    // 返回结果:
    //     The vector with all components clamped.
    public readonly Vector3 Clamp(float min, float max)
    {
        return new Vector3(Mathf.Clamp(X, min, max), Mathf.Clamp(Y, min, max), Mathf.Clamp(Z, min, max));
    }

    //
    // 摘要:
    //     Returns the cross product of this vector and with.
    //
    // 参数:
    //   with:
    //     The other vector.
    //
    // 返回结果:
    //     The cross product vector.
    public readonly Vector3 Cross(Vector3 with)
    {
        return new Vector3(Y * with.Z - Z * with.Y, Z * with.X - X * with.Z, X * with.Y - Y * with.X);
    }

    //
    // 摘要:
    //     Performs a cubic interpolation between vectors preA, this vector, b, and postB,
    //     by the given amount weight.
    //
    // 参数:
    //   b:
    //     The destination vector.
    //
    //   preA:
    //     A vector before this vector.
    //
    //   postB:
    //     A vector after b.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The interpolated vector.
    public readonly Vector3 CubicInterpolate(Vector3 b, Vector3 preA, Vector3 postB, float weight)
    {
        return new Vector3(Mathf.CubicInterpolate(X, b.X, preA.X, postB.X, weight), Mathf.CubicInterpolate(Y, b.Y, preA.Y, postB.Y, weight), Mathf.CubicInterpolate(Z, b.Z, preA.Z, postB.Z, weight));
    }

    //
    // 摘要:
    //     Performs a cubic interpolation between vectors preA, this vector, b, and postB,
    //     by the given amount weight. It can perform smoother interpolation than Godot.Vector3.CubicInterpolate(Godot.Vector3,Godot.Vector3,Godot.Vector3,System.Single)
    //     by the time values.
    //
    // 参数:
    //   b:
    //     The destination vector.
    //
    //   preA:
    //     A vector before this vector.
    //
    //   postB:
    //     A vector after b.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   t:
    //
    //   preAT:
    //
    //   postBT:
    //
    // 返回结果:
    //     The interpolated vector.
    public readonly Vector3 CubicInterpolateInTime(Vector3 b, Vector3 preA, Vector3 postB, float weight, float t, float preAT, float postBT)
    {
        return new Vector3(Mathf.CubicInterpolateInTime(X, b.X, preA.X, postB.X, weight, t, preAT, postBT), Mathf.CubicInterpolateInTime(Y, b.Y, preA.Y, postB.Y, weight, t, preAT, postBT), Mathf.CubicInterpolateInTime(Z, b.Z, preA.Z, postB.Z, weight, t, preAT, postBT));
    }

    //
    // 摘要:
    //     Returns the point at the given t on a one-dimensional Bezier curve defined by
    //     this vector and the given control1, control2, and end points.
    //
    // 参数:
    //   control1:
    //     Control point that defines the bezier curve.
    //
    //   control2:
    //     Control point that defines the bezier curve.
    //
    //   end:
    //     The destination vector.
    //
    //   t:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The interpolated vector.
    public readonly Vector3 BezierInterpolate(Vector3 control1, Vector3 control2, Vector3 end, float t)
    {
        return new Vector3(Mathf.BezierInterpolate(X, control1.X, control2.X, end.X, t), Mathf.BezierInterpolate(Y, control1.Y, control2.Y, end.Y, t), Mathf.BezierInterpolate(Z, control1.Z, control2.Z, end.Z, t));
    }

    //
    // 摘要:
    //     Returns the derivative at the given t on the Bezier curve defined by this vector
    //     and the given control1, control2, and end points.
    //
    // 参数:
    //   control1:
    //     Control point that defines the bezier curve.
    //
    //   control2:
    //     Control point that defines the bezier curve.
    //
    //   end:
    //     The destination value for the interpolation.
    //
    //   t:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public readonly Vector3 BezierDerivative(Vector3 control1, Vector3 control2, Vector3 end, float t)
    {
        return new Vector3(Mathf.BezierDerivative(X, control1.X, control2.X, end.X, t), Mathf.BezierDerivative(Y, control1.Y, control2.Y, end.Y, t), Mathf.BezierDerivative(Z, control1.Z, control2.Z, end.Z, t));
    }

    //
    // 摘要:
    //     Returns the normalized vector pointing from this vector to to.
    //
    // 参数:
    //   to:
    //     The other vector to point towards.
    //
    // 返回结果:
    //     The direction from this vector to to.
    public readonly Vector3 DirectionTo(Vector3 to)
    {
        return new Vector3(to.X - X, to.Y - Y, to.Z - Z).Normalized();
    }

    //
    // 摘要:
    //     Returns the squared distance between this vector and to. This method runs faster
    //     than Godot.Vector3.DistanceTo(Godot.Vector3), so prefer it if you need to compare
    //     vectors or need the squared distance for some formula.
    //
    // 参数:
    //   to:
    //     The other vector to use.
    //
    // 返回结果:
    //     The squared distance between the two vectors.
    public readonly float DistanceSquaredTo(Vector3 to)
    {
        return (to - this).LengthSquared();
    }

    //
    // 摘要:
    //     Returns the distance between this vector and to.
    //
    // 参数:
    //   to:
    //     The other vector to use.
    //
    // 返回结果:
    //     The distance between the two vectors.
    public readonly float DistanceTo(Vector3 to)
    {
        return (to - this).Length();
    }

    //
    // 摘要:
    //     Returns the dot product of this vector and with.
    //
    // 参数:
    //   with:
    //     The other vector to use.
    //
    // 返回结果:
    //     The dot product of the two vectors.
    public readonly float Dot(Vector3 with)
    {
        return X * with.X + Y * with.Y + Z * with.Z;
    }
    //自行添加 
    public static float Dot(Vector3 vector1, Vector3 vector2)
    {
        return (float)(vector1.X * (double)vector2.X + vector1.Y * (double)vector2.Y +
            vector1.Z * (double)vector2.Z);
    }

    public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
    {
        result = (float)(vector1.X * (double)vector2.X + vector1.Y * (double)vector2.Y +
            vector1.Z * (double)vector2.Z);
    }
    //
    // 摘要:
    //     Returns a new vector with all components rounded down (towards negative infinity).
    //
    //
    // 返回结果:
    //     A vector with Godot.Mathf.Floor(System.Single) called on each component.
    public readonly Vector3 Floor()
    {
        return new Vector3(Mathf.Floor(X), Mathf.Floor(Y), Mathf.Floor(Z));
    }

    //
    // 摘要:
    //     Returns the inverse of this vector. This is the same as new Vector3(1 / v.X,
    //     1 / v.Y, 1 / v.Z).
    //
    // 返回结果:
    //     The inverse of this vector.
    public readonly Vector3 Inverse()
    {
        return new Vector3(1f / X, 1f / Y, 1f / Z);
    }

    //
    // 摘要:
    //     Returns true if this vector is finite, by calling Godot.Mathf.IsFinite(System.Single)
    //     on each component.
    //
    // 返回结果:
    //     Whether this vector is finite or not.
    public readonly bool IsFinite()
    {
        if (Mathf.IsFinite(X) && Mathf.IsFinite(Y))
        {
            return Mathf.IsFinite(Z);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if the vector is normalized, and false otherwise.
    //
    // 返回结果:
    //     A bool indicating whether or not the vector is normalized.
    public readonly bool IsNormalized()
    {
        return Mathf.Abs(LengthSquared() - 1f) < 1E-06f;
    }

    //
    // 摘要:
    //     Returns the length (magnitude) of this vector.
    //
    // 返回结果:
    //     The length of this vector.
    public readonly float Length()
    {
        float num = X * X;
        float num2 = Y * Y;
        float num3 = Z * Z;
        return Mathf.Sqrt(num + num2 + num3);
    }

    //
    // 摘要:
    //     Returns the squared length (squared magnitude) of this vector. This method runs
    //     faster than Godot.Vector3.Length, so prefer it if you need to compare vectors
    //     or need the squared length for some formula.
    //
    // 返回结果:
    //     The squared length of this vector.
    public readonly float LengthSquared()
    {
        float num = X * X;
        float num2 = Y * Y;
        float num3 = Z * Z;
        return num + num2 + num3;
    }

    //
    // 摘要:
    //     Returns the result of the linear interpolation between this vector and to by
    //     amount weight.
    //
    // 参数:
    //   to:
    //     The destination vector for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting vector of the interpolation.
    public readonly Vector3 Lerp(Vector3 to, float weight)
    {
        return new Vector3(Mathf.Lerp(X, to.X, weight), Mathf.Lerp(Y, to.Y, weight), Mathf.Lerp(Z, to.Z, weight));
    }
    public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
    {
        Vector3 vector3;
        vector3.X = value1.X + (value2.X - value1.X) * amount;
        vector3.Y = value1.Y + (value2.Y - value1.Y) * amount;
        vector3.Z = value1.Z + (value2.Z - value1.Z) * amount;
        return vector3;
    }

    public static void Lerp(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
    {
        result.X = value1.X + (value2.X - value1.X) * amount;
        result.Y = value1.Y + (value2.Y - value1.Y) * amount;
        result.Z = value1.Z + (value2.Z - value1.Z) * amount;
    }
    //
    // 摘要:
    //     Returns the vector with a maximum length by limiting its length to length.
    //
    // 参数:
    //   length:
    //     The length to limit to.
    //
    // 返回结果:
    //     The vector with its length limited.
    public readonly Vector3 LimitLength(float length = 1f)
    {
        Vector3 result = this;
        float num = Length();
        if (num > 0f && length < num)
        {
            result /= num;
            result *= length;
        }

        return result;
    }

    //
    // 摘要:
    //     Returns the result of the component-wise maximum between this vector and with.
    //     Equivalent to new Vector3(Mathf.Max(X, with.X), Mathf.Max(Y, with.Y), Mathf.Max(Z,
    //     with.Z)).
    //
    // 参数:
    //   with:
    //     The other vector to use.
    //
    // 返回结果:
    //     The resulting maximum vector.
    public readonly Vector3 Max(Vector3 with)
    {
        return new Vector3(Mathf.Max(X, with.X), Mathf.Max(Y, with.Y), Mathf.Max(Z, with.Z));
    }

    //
    // 摘要:
    //     Returns the result of the component-wise maximum between this vector and with.
    //     Equivalent to new Vector3(Mathf.Max(X, with), Mathf.Max(Y, with), Mathf.Max(Z,
    //     with)).
    //
    // 参数:
    //   with:
    //     The other value to use.
    //
    // 返回结果:
    //     The resulting maximum vector.
    public readonly Vector3 Max(float with)
    {
        return new Vector3(Mathf.Max(X, with), Mathf.Max(Y, with), Mathf.Max(Z, with));
    }

    //
    // 摘要:
    //     Returns the result of the component-wise minimum between this vector and with.
    //     Equivalent to new Vector3(Mathf.Min(X, with.X), Mathf.Min(Y, with.Y), Mathf.Min(Z,
    //     with.Z)).
    //
    // 参数:
    //   with:
    //     The other vector to use.
    //
    // 返回结果:
    //     The resulting minimum vector.
    public readonly Vector3 Min(Vector3 with)
    {
        return new Vector3(Mathf.Min(X, with.X), Mathf.Min(Y, with.Y), Mathf.Min(Z, with.Z));
    }

    //
    // 摘要:
    //     Returns the axis of the vector's highest value. See Godot.Vector3.Axis. If all
    //     components are equal, this method returns Godot.Vector3.Axis.X.
    //
    // 返回结果:
    //     The index of the highest axis.
    public readonly Axis MaxAxisIndex()
    {
        if (!(X < Y))
        {
            if (!(X < Z))
            {
                return Axis.X;
            }

            return Axis.Z;
        }

        if (!(Y < Z))
        {
            return Axis.Y;
        }

        return Axis.Z;
    }

    //
    // 摘要:
    //     Returns the axis of the vector's lowest value. See Godot.Vector3.Axis. If all
    //     components are equal, this method returns Godot.Vector3.Axis.Z.
    //
    // 返回结果:
    //     The index of the lowest axis.
    public readonly Axis MinAxisIndex()
    {
        if (!(X < Y))
        {
            if (!(Y < Z))
            {
                return Axis.Z;
            }

            return Axis.Y;
        }

        if (!(X < Z))
        {
            return Axis.Z;
        }

        return Axis.X;
    }

    //
    // 摘要:
    //     Moves this vector toward to by the fixed delta amount.
    //
    // 参数:
    //   to:
    //     The vector to move towards.
    //
    //   delta:
    //     The amount to move towards by.
    //
    // 返回结果:
    //     The resulting vector.
    public readonly Vector3 MoveToward(Vector3 to, float delta)
    {
        Vector3 vector = this;
        Vector3 vector2 = to - vector;
        float num = vector2.Length();
        if (num <= delta || num < 1E-06f)
        {
            return to;
        }

        return vector + vector2 / num * delta;
    }

    //
    // 摘要:
    //     Returns the vector scaled to unit length. Equivalent to v / v.Length().
    //
    // 返回结果:
    //     A normalized version of the vector.
    public readonly Vector3 Normalized()
    {
        Vector3 result = this;
        result.Normalize();
        return result;
    }

    //
    // 摘要:
    //     Returns the outer product with with.
    //
    // 参数:
    //   with:
    //     The other vector.
    //
    // 返回结果:
    //     A Godot.Basis representing the outer product matrix.
    public readonly Basis Outer(Vector3 with)
    {
        return new Basis(X * with.X, X * with.Y, X * with.Z, Y * with.X, Y * with.Y, Y * with.Z, Z * with.X, Z * with.Y, Z * with.Z);
    }

    //
    // 摘要:
    //     Returns a vector composed of the Godot.Mathf.PosMod(System.Single,System.Single)
    //     of this vector's components and mod.
    //
    // 参数:
    //   mod:
    //     A value representing the divisor of the operation.
    //
    // 返回结果:
    //     A vector with each component Godot.Mathf.PosMod(System.Single,System.Single)
    //     by mod.
    public readonly Vector3 PosMod(float mod)
    {
        Vector3 result = default(Vector3);
        result.X = Mathf.PosMod(X, mod);
        result.Y = Mathf.PosMod(Y, mod);
        result.Z = Mathf.PosMod(Z, mod);
        return result;
    }

    //
    // 摘要:
    //     Returns a vector composed of the Godot.Mathf.PosMod(System.Single,System.Single)
    //     of this vector's components and modv's components.
    //
    // 参数:
    //   modv:
    //     A vector representing the divisors of the operation.
    //
    // 返回结果:
    //     A vector with each component Godot.Mathf.PosMod(System.Single,System.Single)
    //     by modv's components.
    public readonly Vector3 PosMod(Vector3 modv)
    {
        Vector3 result = default(Vector3);
        result.X = Mathf.PosMod(X, modv.X);
        result.Y = Mathf.PosMod(Y, modv.Y);
        result.Z = Mathf.PosMod(Z, modv.Z);
        return result;
    }

    //
    // 摘要:
    //     Returns a new vector resulting from projecting this vector onto the given vector
    //     onNormal. The resulting new vector is parallel to onNormal. See also Godot.Vector3.Slide(Godot.Vector3).
    //     Note: If the vector onNormal is a zero vector, the components of the resulting
    //     new vector will be System.Single.NaN.
    //
    // 参数:
    //   onNormal:
    //     The vector to project onto.
    //
    // 返回结果:
    //     The projected vector.
    public readonly Vector3 Project(Vector3 onNormal)
    {
        return onNormal * (Dot(onNormal) / onNormal.LengthSquared());
    }

    //
    // 摘要:
    //     Returns this vector reflected from a plane defined by the given normal.
    //
    // 参数:
    //   normal:
    //     The normal vector defining the plane to reflect from. Must be normalized.
    //
    // 返回结果:
    //     The reflected vector.
    public readonly Vector3 Reflect(Vector3 normal)
    {
        return 2f * Dot(normal) * normal - this;
    }

    //
    // 摘要:
    //     Rotates this vector around a given axis vector by angle (in radians). The axis
    //     vector must be a normalized vector.
    //
    // 参数:
    //   axis:
    //     The vector to rotate around. Must be normalized.
    //
    //   angle:
    //     The angle to rotate by, in radians.
    //
    // 返回结果:
    //     The rotated vector.
    public readonly Vector3 Rotated(Vector3 axis, float angle)
    {
        return new Basis(axis, angle) * this;
    }

    //
    // 摘要:
    //     Returns this vector with all components rounded to the nearest integer, with
    //     halfway cases rounded towards the nearest multiple of two.
    //
    // 返回结果:
    //     The rounded vector.
    public readonly Vector3 Round()
    {
        return new Vector3(Mathf.Round(X), Mathf.Round(Y), Mathf.Round(Z));
    }

    //
    // 摘要:
    //     Returns a vector with each component set to one or negative one, depending on
    //     the signs of this vector's components, or zero if the component is zero, by calling
    //     Godot.Mathf.Sign(System.Single) on each component.
    //
    // 返回结果:
    //     A vector with all components as either 1, -1, or 0.
    public readonly Vector3 Sign()
    {
        Vector3 result = default(Vector3);
        result.X = Mathf.Sign(X);
        result.Y = Mathf.Sign(Y);
        result.Z = Mathf.Sign(Z);
        return result;
    }

    //
    // 摘要:
    //     Returns the signed angle to the given vector, in radians. The sign of the angle
    //     is positive in a counter-clockwise direction and negative in a clockwise direction
    //     when viewed from the side specified by the axis.
    //
    // 参数:
    //   to:
    //     The other vector to compare this vector to.
    //
    //   axis:
    //     The reference axis to use for the angle sign.
    //
    // 返回结果:
    //     The signed angle between the two vectors, in radians.
    public readonly float SignedAngleTo(Vector3 to, Vector3 axis)
    {
        Vector3 vector = Cross(to);
        float num = Mathf.Atan2(vector.Length(), Dot(to));
        if (!(vector.Dot(axis) < 0f))
        {
            return num;
        }

        return 0f - num;
    }

    //
    // 摘要:
    //     Returns the result of the spherical linear interpolation between this vector
    //     and to by amount weight. This method also handles interpolating the lengths if
    //     the input vectors have different lengths. For the special case of one or both
    //     input vectors having zero length, this method behaves like Godot.Vector3.Lerp(Godot.Vector3,System.Single).
    //
    //
    // 参数:
    //   to:
    //     The destination vector for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting vector of the interpolation.
    public readonly Vector3 Slerp(Vector3 to, float weight)
    {
        float num = LengthSquared();
        float num2 = to.LengthSquared();
        if ((double)num == 0.0 || (double)num2 == 0.0)
        {
            return Lerp(to, weight);
        }

        Vector3 axis = Cross(to);
        float num3 = axis.LengthSquared();
        if ((double)num3 == 0.0)
        {
            return Lerp(to, weight);
        }

        axis /= Mathf.Sqrt(num3);
        float num4 = Mathf.Sqrt(num);
        float num5 = Mathf.Lerp(num4, Mathf.Sqrt(num2), weight);
        float num6 = AngleTo(to);
        return Rotated(axis, num6 * weight) * (num5 / num4);
    }

    //
    // 摘要:
    //     Returns a new vector resulting from sliding this vector along a plane with normal
    //     normal. The resulting new vector is perpendicular to normal, and is equivalent
    //     to this vector minus its projection on normal. See also Godot.Vector3.Project(Godot.Vector3).
    //     Note: The vector normal must be normalized. See also Godot.Vector3.Normalized.
    //
    //
    // 参数:
    //   normal:
    //     The normal vector of the plane to slide on.
    //
    // 返回结果:
    //     The slid vector.
    public readonly Vector3 Slide(Vector3 normal)
    {
        return this - normal * Dot(normal);
    }

    //
    // 摘要:
    //     Returns a new vector with each component snapped to the nearest multiple of the
    //     corresponding component in step. This can also be used to round to an arbitrary
    //     number of decimals.
    //
    // 参数:
    //   step:
    //     A vector value representing the step size to snap to.
    //
    // 返回结果:
    //     The snapped vector.
    public readonly Vector3 Snapped(Vector3 step)
    {
        return new Vector3(Mathf.Snapped(X, step.X), Mathf.Snapped(Y, step.Y), Mathf.Snapped(Z, step.Z));
    }

    //
    // 摘要:
    //     Returns a new vector with each component snapped to the nearest multiple of step.
    //     This can also be used to round to an arbitrary number of decimals.
    //
    // 参数:
    //   step:
    //     The step size to snap to.
    //
    // 返回结果:
    //     The snapped vector.
    public readonly Vector3 Snapped(float step)
    {
        return new Vector3(Mathf.Snapped(X, step), Mathf.Snapped(Y, step), Mathf.Snapped(Z, step));
    }

    //
    // 摘要:
    //     Constructs a new Godot.Vector3 with the given components.
    //
    // 参数:
    //   x:
    //     The vector's X component.
    //
    //   y:
    //     The vector's Y component.
    //
    //   z:
    //     The vector's Z component.
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    //
    // 摘要:
    //     Adds each component of the Godot.Vector3 with the components of the given Godot.Vector3.
    //
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     The added vector.
    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        left.X += right.X;
        left.Y += right.Y;
        left.Z += right.Z;
        return left;
    }

    //
    // 摘要:
    //     Subtracts each component of the Godot.Vector3 by the components of the given
    //     Godot.Vector3.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     The subtracted vector.
    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        left.X -= right.X;
        left.Y -= right.Y;
        left.Z -= right.Z;
        return left;
    }

    //
    // 摘要:
    //     Returns the negative value of the Godot.Vector3. This is the same as writing
    //     new Vector3(-v.X, -v.Y, -v.Z). This operation flips the direction of the vector
    //     while keeping the same magnitude. With floats, the number zero can be either
    //     positive or negative.
    //
    // 参数:
    //   vec:
    //     The vector to negate/flip.
    //
    // 返回结果:
    //     The negated/flipped vector.
    public static Vector3 operator -(Vector3 vec)
    {
        vec.X = 0f - vec.X;
        vec.Y = 0f - vec.Y;
        vec.Z = 0f - vec.Z;
        return vec;
    }

    //
    // 摘要:
    //     Multiplies each component of the Godot.Vector3 by the given System.Single.
    //
    // 参数:
    //   vec:
    //     The vector to multiply.
    //
    //   scale:
    //     The scale to multiply by.
    //
    // 返回结果:
    //     The multiplied vector.
    public static Vector3 operator *(Vector3 vec, float scale)
    {
        vec.X *= scale;
        vec.Y *= scale;
        vec.Z *= scale;
        return vec;
    }

    //
    // 摘要:
    //     Multiplies each component of the Godot.Vector3 by the given System.Single.
    //
    // 参数:
    //   scale:
    //     The scale to multiply by.
    //
    //   vec:
    //     The vector to multiply.
    //
    // 返回结果:
    //     The multiplied vector.
    public static Vector3 operator *(float scale, Vector3 vec)
    {
        vec.X *= scale;
        vec.Y *= scale;
        vec.Z *= scale;
        return vec;
    }

    //
    // 摘要:
    //     Multiplies each component of the Godot.Vector3 by the components of the given
    //     Godot.Vector3.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     The multiplied vector.
    public static Vector3 operator *(Vector3 left, Vector3 right)
    {
        left.X *= right.X;
        left.Y *= right.Y;
        left.Z *= right.Z;
        return left;
    }

    //
    // 摘要:
    //     Divides each component of the Godot.Vector3 by the given System.Single.
    //
    // 参数:
    //   vec:
    //     The dividend vector.
    //
    //   divisor:
    //     The divisor value.
    //
    // 返回结果:
    //     The divided vector.
    public static Vector3 operator /(Vector3 vec, float divisor)
    {
        vec.X /= divisor;
        vec.Y /= divisor;
        vec.Z /= divisor;
        return vec;
    }

    //
    // 摘要:
    //     Divides each component of the Godot.Vector3 by the components of the given Godot.Vector3.
    //
    //
    // 参数:
    //   vec:
    //     The dividend vector.
    //
    //   divisorv:
    //     The divisor vector.
    //
    // 返回结果:
    //     The divided vector.
    public static Vector3 operator /(Vector3 vec, Vector3 divisorv)
    {
        vec.X /= divisorv.X;
        vec.Y /= divisorv.Y;
        vec.Z /= divisorv.Z;
        return vec;
    }

    //
    // 摘要:
    //     Gets the remainder of each component of the Godot.Vector3 with the components
    //     of the given System.Single. This operation uses truncated division, which is
    //     often not desired as it does not work well with negative numbers. Consider using
    //     Godot.Vector3.PosMod(System.Single) instead if you want to handle negative numbers.
    //
    //
    // 参数:
    //   vec:
    //     The dividend vector.
    //
    //   divisor:
    //     The divisor value.
    //
    // 返回结果:
    //     The remainder vector.
    public static Vector3 operator %(Vector3 vec, float divisor)
    {
        vec.X %= divisor;
        vec.Y %= divisor;
        vec.Z %= divisor;
        return vec;
    }

    //
    // 摘要:
    //     Gets the remainder of each component of the Godot.Vector3 with the components
    //     of the given Godot.Vector3. This operation uses truncated division, which is
    //     often not desired as it does not work well with negative numbers. Consider using
    //     Godot.Vector3.PosMod(Godot.Vector3) instead if you want to handle negative numbers.
    //
    //
    // 参数:
    //   vec:
    //     The dividend vector.
    //
    //   divisorv:
    //     The divisor vector.
    //
    // 返回结果:
    //     The remainder vector.
    public static Vector3 operator %(Vector3 vec, Vector3 divisorv)
    {
        vec.X %= divisorv.X;
        vec.Y %= divisorv.Y;
        vec.Z %= divisorv.Z;
        return vec;
    }

    //
    // 摘要:
    //     Returns true if the vectors are exactly equal. Note: Due to floating-point precision
    //     errors, consider using Godot.Vector3.IsEqualApprox(Godot.Vector3) instead, which
    //     is more reliable.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the vectors are exactly equal.
    public static bool operator ==(Vector3 left, Vector3 right)
    {
        return left.Equals(right);
    }

    //
    // 摘要:
    //     Returns true if the vectors are not equal. Note: Due to floating-point precision
    //     errors, consider using Godot.Vector3.IsEqualApprox(Godot.Vector3) instead, which
    //     is more reliable.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the vectors are not equal.
    public static bool operator !=(Vector3 left, Vector3 right)
    {
        return !left.Equals(right);
    }

    //
    // 摘要:
    //     Compares two Godot.Vector3 vectors by first checking if the X value of the left
    //     vector is less than the X value of the right vector. If the X values are exactly
    //     equal, then it repeats this check with the Y values of the two vectors, and then
    //     with the Z values. This operator is useful for sorting vectors.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the left is less than the right.
    public static bool operator <(Vector3 left, Vector3 right)
    {
        if (left.X == right.X)
        {
            if (left.Y == right.Y)
            {
                return left.Z < right.Z;
            }

            return left.Y < right.Y;
        }

        return left.X < right.X;
    }

    //
    // 摘要:
    //     Compares two Godot.Vector3 vectors by first checking if the X value of the left
    //     vector is greater than the X value of the right vector. If the X values are exactly
    //     equal, then it repeats this check with the Y values of the two vectors, and then
    //     with the Z values. This operator is useful for sorting vectors.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the left is greater than the right.
    public static bool operator >(Vector3 left, Vector3 right)
    {
        if (left.X == right.X)
        {
            if (left.Y == right.Y)
            {
                return left.Z > right.Z;
            }

            return left.Y > right.Y;
        }

        return left.X > right.X;
    }

    //
    // 摘要:
    //     Compares two Godot.Vector3 vectors by first checking if the X value of the left
    //     vector is less than or equal to the X value of the right vector. If the X values
    //     are exactly equal, then it repeats this check with the Y values of the two vectors,
    //     and then with the Z values. This operator is useful for sorting vectors.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the left is less than or equal to the right.
    public static bool operator <=(Vector3 left, Vector3 right)
    {
        if (left.X == right.X)
        {
            if (left.Y == right.Y)
            {
                return left.Z <= right.Z;
            }

            return left.Y < right.Y;
        }

        return left.X < right.X;
    }

    //
    // 摘要:
    //     Compares two Godot.Vector3 vectors by first checking if the X value of the left
    //     vector is greater than or equal to the X value of the right vector. If the X
    //     values are exactly equal, then it repeats this check with the Y values of the
    //     two vectors, and then with the Z values. This operator is useful for sorting
    //     vectors.
    //
    // 参数:
    //   left:
    //     The left vector.
    //
    //   right:
    //     The right vector.
    //
    // 返回结果:
    //     Whether or not the left is greater than or equal to the right.
    public static bool operator >=(Vector3 left, Vector3 right)
    {
        if (left.X == right.X)
        {
            if (left.Y == right.Y)
            {
                return left.Z >= right.Z;
            }

            return left.Y > right.Y;
        }

        return left.X > right.X;
    }

    //
    // 摘要:
    //     Returns true if the vector is exactly equal to the given object (obj). Note:
    //     Due to floating-point precision errors, consider using Godot.Vector3.IsEqualApprox(Godot.Vector3)
    //     instead, which is more reliable.
    //
    // 参数:
    //   obj:
    //     The object to compare with.
    //
    // 返回结果:
    //     Whether or not the vector and the object are equal.
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is Vector3 other)
        {
            return Equals(other);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if the vectors are exactly equal. Note: Due to floating-point precision
    //     errors, consider using Godot.Vector3.IsEqualApprox(Godot.Vector3) instead, which
    //     is more reliable.
    //
    // 参数:
    //   other:
    //     The other vector.
    //
    // 返回结果:
    //     Whether or not the vectors are exactly equal.
    public readonly bool Equals(Vector3 other)
    {
        if (X == other.X && Y == other.Y)
        {
            return Z == other.Z;
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if this vector and other are approximately equal, by running Godot.Mathf.IsEqualApprox(System.Single,System.Single)
    //     on each component.
    //
    // 参数:
    //   other:
    //     The other vector to compare.
    //
    // 返回结果:
    //     Whether or not the vectors are approximately equal.
    public readonly bool IsEqualApprox(Vector3 other)
    {
        if (Mathf.IsEqualApprox(X, other.X) && Mathf.IsEqualApprox(Y, other.Y))
        {
            return Mathf.IsEqualApprox(Z, other.Z);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if this vector's values are approximately zero, by running Godot.Mathf.IsZeroApprox(System.Single)
    //     on each component. This method is faster than using Godot.Vector3.IsEqualApprox(Godot.Vector3)
    //     with one value as a zero vector.
    //
    // 返回结果:
    //     Whether or not the vector is approximately zero.
    public readonly bool IsZeroApprox()
    {
        if (Mathf.IsZeroApprox(X) && Mathf.IsZeroApprox(Y))
        {
            return Mathf.IsZeroApprox(Z);
        }

        return false;
    }

    //
    // 摘要:
    //     Serves as the hash function for Godot.Vector3.
    //
    // 返回结果:
    //     A hash code for this vector.
    public override readonly int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    //
    // 摘要:
    //     Converts this Godot.Vector3 to a string.
    //
    // 返回结果:
    //     A string representation of this vector.
    public override readonly string ToString()
    {
        return ToString(null);
    }

    //
    // 摘要:
    //     Converts this Godot.Vector3 to a string with the given format.
    //
    // 返回结果:
    //     A string representation of this vector.
    public readonly string ToString(string? format)
    {
        return $"({X.ToString(format, CultureInfo.InvariantCulture)}, {Y.ToString(format, CultureInfo.InvariantCulture)}, {Z.ToString(format, CultureInfo.InvariantCulture)})";
    }
}
#if false // 反编译日志
缓存中的 170 项
------------------
解析: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.dll"
------------------
解析: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.Loader.dll"
------------------
解析: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Collections.Concurrent.dll"
------------------
解析: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Collections.dll"
------------------
解析: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Diagnostics.StackTrace.dll"
------------------
解析: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.InteropServices.dll"
------------------
解析: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Threading.dll"
------------------
解析: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Diagnostics.TraceSource.dll"
------------------
解析: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Memory.dll"
------------------
解析: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Linq.dll"
------------------
解析: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Security.Cryptography.dll"
------------------
解析: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Text.RegularExpressions.dll"
------------------
解析: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Console.dll"
------------------
解析: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null"
找到单个程序集: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.CompilerServices.Unsafe.dll"
#endif
