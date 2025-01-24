#region 程序集 GodotSharp, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Administrator\.nuget\packages\godotsharp\4.4.0-beta\lib\net8.0\GodotSharp.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Godot;

//
// 摘要:
//     A unit quaternion used for representing 3D rotations. Quaternions need to be
//     normalized to be used for rotation. It is similar to Godot.Basis, which implements
//     matrix representation of rotations, and can be parametrized using both an axis-angle
//     pair or Euler angles. Basis stores rotation, scale, and shearing, while Quaternion
//     only stores rotation. Due to its compactness and the way it is stored in memory,
//     certain operations (obtaining axis-angle and performing SLERP, in particular)
//     are more efficient and robust against floating-point errors.
[Serializable]
public struct Quaternion : IEquatable<Quaternion>
{
    //
    // 摘要:
    //     X component of the quaternion (imaginary i axis part). Quaternion components
    //     should usually not be manipulated directly.
    public float X;

    //
    // 摘要:
    //     Y component of the quaternion (imaginary j axis part). Quaternion components
    //     should usually not be manipulated directly.
    public float Y;

    //
    // 摘要:
    //     Z component of the quaternion (imaginary k axis part). Quaternion components
    //     should usually not be manipulated directly.
    public float Z;

    //
    // 摘要:
    //     W component of the quaternion (real part). Quaternion components should usually
    //     not be manipulated directly.
    public float W;

    private static readonly Quaternion _identity = new Quaternion(0f, 0f, 0f, 1f);

    //
    // 摘要:
    //     Access quaternion components using their index.
    //
    // 值:
    //     [0] is equivalent to Godot.Quaternion.X, [1] is equivalent to Godot.Quaternion.Y,
    //     [2] is equivalent to Godot.Quaternion.Z, [3] is equivalent to Godot.Quaternion.W.
    //
    //
    // 异常:
    //   T:System.ArgumentOutOfRangeException:
    //     index is not 0, 1, 2 or 3.
    public float this[int index]
    {
        readonly get
        {
            return index switch
            {
                0 => X,
                1 => Y,
                2 => Z,
                3 => W,
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
                case 3:
                    W = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("index");
            }
        }
    }

    //
    // 摘要:
    //     The identity quaternion, representing no rotation. Equivalent to an identity
    //     Godot.Basis matrix. If a vector is transformed by an identity quaternion, it
    //     will not change.
    //
    // 值:
    //     Equivalent to new Quaternion(0, 0, 0, 1).
    public static Quaternion Identity => _identity;

    //
    // 摘要:
    //     Returns the angle between this quaternion and to. This is the magnitude of the
    //     angle you would need to rotate by to get from one to the other. Note: This method
    //     has an abnormally high amount of floating-point error, so methods such as Godot.Mathf.IsZeroApprox(System.Single)
    //     will not work reliably.
    //
    // 参数:
    //   to:
    //     The other quaternion.
    //
    // 返回结果:
    //     The angle between the quaternions.
    public readonly float AngleTo(Quaternion to)
    {
        float num = Dot(to);
        return Mathf.Acos(Mathf.Clamp(num * num * 2f - 1f, -1f, 1f));
    }

    //
    // 摘要:
    //     Performs a spherical cubic interpolation between quaternions preA, this quaternion,
    //     b, and postB, by the given amount weight.
    //
    // 参数:
    //   b:
    //     The destination quaternion.
    //
    //   preA:
    //     A quaternion before this quaternion.
    //
    //   postB:
    //     A quaternion after b.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The interpolated quaternion.
    public readonly Quaternion SphericalCubicInterpolate(Quaternion b, Quaternion preA, Quaternion postB, float weight)
    {
        Quaternion rotationQuaternion = new Basis(this).GetRotationQuaternion();
        Quaternion rotationQuaternion2 = new Basis(preA).GetRotationQuaternion();
        Quaternion rotationQuaternion3 = new Basis(b).GetRotationQuaternion();
        Quaternion rotationQuaternion4 = new Basis(postB).GetRotationQuaternion();
        rotationQuaternion2 = ((Math.Sign(rotationQuaternion.Dot(rotationQuaternion2)) < 0) ? (-rotationQuaternion2) : rotationQuaternion2);
        bool num = Math.Sign(rotationQuaternion.Dot(rotationQuaternion3)) < 0;
        rotationQuaternion3 = (num ? (-rotationQuaternion3) : rotationQuaternion3);
        rotationQuaternion4 = ((num ? (rotationQuaternion3.Dot(rotationQuaternion4) <= 0f) : (Math.Sign(rotationQuaternion3.Dot(rotationQuaternion4)) < 0)) ? (-rotationQuaternion4) : rotationQuaternion4);
        Quaternion quaternion = new Quaternion(0f, 0f, 0f, 0f);
        Quaternion quaternion2 = (rotationQuaternion.Inverse() * rotationQuaternion3).Log();
        Quaternion quaternion3 = (rotationQuaternion.Inverse() * rotationQuaternion2).Log();
        Quaternion quaternion4 = (rotationQuaternion.Inverse() * rotationQuaternion4).Log();
        Quaternion quaternion5 = new Quaternion(Mathf.CubicInterpolate(quaternion.X, quaternion2.X, quaternion3.X, quaternion4.X, weight), Mathf.CubicInterpolate(quaternion.Y, quaternion2.Y, quaternion3.Y, quaternion4.Y, weight), Mathf.CubicInterpolate(quaternion.Z, quaternion2.Z, quaternion3.Z, quaternion4.Z, weight), 0f);
        Quaternion quaternion6 = rotationQuaternion * quaternion5.Exp();
        quaternion = (rotationQuaternion3.Inverse() * rotationQuaternion).Log();
        quaternion2 = new Quaternion(0f, 0f, 0f, 0f);
        quaternion3 = (rotationQuaternion3.Inverse() * rotationQuaternion2).Log();
        quaternion4 = (rotationQuaternion3.Inverse() * rotationQuaternion4).Log();
        quaternion5 = new Quaternion(Mathf.CubicInterpolate(quaternion.X, quaternion2.X, quaternion3.X, quaternion4.X, weight), Mathf.CubicInterpolate(quaternion.Y, quaternion2.Y, quaternion3.Y, quaternion4.Y, weight), Mathf.CubicInterpolate(quaternion.Z, quaternion2.Z, quaternion3.Z, quaternion4.Z, weight), 0f);
        Quaternion to = rotationQuaternion3 * quaternion5.Exp();
        return quaternion6.Slerp(to, weight);
    }

    //
    // 摘要:
    //     Performs a spherical cubic interpolation between quaternions preA, this quaternion,
    //     b, and postB, by the given amount weight. It can perform smoother interpolation
    //     than Godot.Quaternion.SphericalCubicInterpolate(Godot.Quaternion,Godot.Quaternion,Godot.Quaternion,System.Single)
    //     by the time values.
    //
    // 参数:
    //   b:
    //     The destination quaternion.
    //
    //   preA:
    //     A quaternion before this quaternion.
    //
    //   postB:
    //     A quaternion after b.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   bT:
    //
    //   preAT:
    //
    //   postBT:
    //
    // 返回结果:
    //     The interpolated quaternion.
    public readonly Quaternion SphericalCubicInterpolateInTime(Quaternion b, Quaternion preA, Quaternion postB, float weight, float bT, float preAT, float postBT)
    {
        Quaternion rotationQuaternion = new Basis(this).GetRotationQuaternion();
        Quaternion rotationQuaternion2 = new Basis(preA).GetRotationQuaternion();
        Quaternion rotationQuaternion3 = new Basis(b).GetRotationQuaternion();
        Quaternion rotationQuaternion4 = new Basis(postB).GetRotationQuaternion();
        rotationQuaternion2 = ((Math.Sign(rotationQuaternion.Dot(rotationQuaternion2)) < 0) ? (-rotationQuaternion2) : rotationQuaternion2);
        bool num = Math.Sign(rotationQuaternion.Dot(rotationQuaternion3)) < 0;
        rotationQuaternion3 = (num ? (-rotationQuaternion3) : rotationQuaternion3);
        rotationQuaternion4 = ((num ? (rotationQuaternion3.Dot(rotationQuaternion4) <= 0f) : (Math.Sign(rotationQuaternion3.Dot(rotationQuaternion4)) < 0)) ? (-rotationQuaternion4) : rotationQuaternion4);
        Quaternion quaternion = new Quaternion(0f, 0f, 0f, 0f);
        Quaternion quaternion2 = (rotationQuaternion.Inverse() * rotationQuaternion3).Log();
        Quaternion quaternion3 = (rotationQuaternion.Inverse() * rotationQuaternion2).Log();
        Quaternion quaternion4 = (rotationQuaternion.Inverse() * rotationQuaternion4).Log();
        Quaternion quaternion5 = new Quaternion(Mathf.CubicInterpolateInTime(quaternion.X, quaternion2.X, quaternion3.X, quaternion4.X, weight, bT, preAT, postBT), Mathf.CubicInterpolateInTime(quaternion.Y, quaternion2.Y, quaternion3.Y, quaternion4.Y, weight, bT, preAT, postBT), Mathf.CubicInterpolateInTime(quaternion.Z, quaternion2.Z, quaternion3.Z, quaternion4.Z, weight, bT, preAT, postBT), 0f);
        Quaternion quaternion6 = rotationQuaternion * quaternion5.Exp();
        quaternion = (rotationQuaternion3.Inverse() * rotationQuaternion).Log();
        quaternion2 = new Quaternion(0f, 0f, 0f, 0f);
        quaternion3 = (rotationQuaternion3.Inverse() * rotationQuaternion2).Log();
        quaternion4 = (rotationQuaternion3.Inverse() * rotationQuaternion4).Log();
        quaternion5 = new Quaternion(Mathf.CubicInterpolateInTime(quaternion.X, quaternion2.X, quaternion3.X, quaternion4.X, weight, bT, preAT, postBT), Mathf.CubicInterpolateInTime(quaternion.Y, quaternion2.Y, quaternion3.Y, quaternion4.Y, weight, bT, preAT, postBT), Mathf.CubicInterpolateInTime(quaternion.Z, quaternion2.Z, quaternion3.Z, quaternion4.Z, weight, bT, preAT, postBT), 0f);
        Quaternion to = rotationQuaternion3 * quaternion5.Exp();
        return quaternion6.Slerp(to, weight);
    }

    //
    // 摘要:
    //     Returns the dot product of two quaternions.
    //
    // 参数:
    //   b:
    //     The other quaternion.
    //
    // 返回结果:
    //     The dot product.
    public readonly float Dot(Quaternion b)
    {
        return X * b.X + Y * b.Y + Z * b.Z + W * b.W;
    }

    public readonly Quaternion Exp()
    {
        Vector3 vector = new Vector3(X, Y, Z);
        float num = vector.Length();
        vector = vector.Normalized();
        if (num < 1E-06f || !vector.IsNormalized())
        {
            return new Quaternion(0f, 0f, 0f, 1f);
        }

        return new Quaternion(vector, num);
    }

    public readonly float GetAngle()
    {
        return 2f * Mathf.Acos(W);
    }

    public readonly Vector3 GetAxis()
    {
        if (Mathf.Abs(W) > 0.999999f)
        {
            return new Vector3(X, Y, Z);
        }

        float num = 1f / Mathf.Sqrt(1f - W * W);
        return new Vector3(X * num, Y * num, Z * num);
    }

    //
    // 摘要:
    //     Returns Euler angles (in the YXZ convention: when decomposing, first Z, then
    //     X, and Y last) corresponding to the rotation represented by the unit quaternion.
    //     Returned vector contains the rotation angles in the format (X angle, Y angle,
    //     Z angle).
    //
    // 返回结果:
    //     The Euler angle representation of this quaternion.
    public readonly Vector3 GetEuler(EulerOrder order = EulerOrder.Yxz)
    {
        return new Basis(this).GetEuler(order);
    }

    //
    // 摘要:
    //     Returns the inverse of the quaternion.
    //
    // 返回结果:
    //     The inverse quaternion.
    public readonly Quaternion Inverse()
    {
        return new Quaternion(0f - X, 0f - Y, 0f - Z, W);
    }

    //
    // 摘要:
    //     Returns true if this quaternion is finite, by calling Godot.Mathf.IsFinite(System.Single)
    //     on each component.
    //
    // 返回结果:
    //     Whether this vector is finite or not.
    public readonly bool IsFinite()
    {
        if (Mathf.IsFinite(X) && Mathf.IsFinite(Y) && Mathf.IsFinite(Z))
        {
            return Mathf.IsFinite(W);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns whether the quaternion is normalized or not.
    //
    // 返回结果:
    //     A bool for whether the quaternion is normalized or not.
    public readonly bool IsNormalized()
    {
        return Mathf.Abs(LengthSquared() - 1f) <= 1E-06f;
    }

    public readonly Quaternion Log()
    {
        Vector3 vector = GetAxis() * GetAngle();
        return new Quaternion(vector.X, vector.Y, vector.Z, 0f);
    }

    //
    // 摘要:
    //     Returns the length (magnitude) of the quaternion.
    //
    // 值:
    //     Equivalent to Mathf.Sqrt(LengthSquared).
    public readonly float Length()
    {
        return Mathf.Sqrt(LengthSquared());
    }

    //
    // 摘要:
    //     Returns the squared length (squared magnitude) of the quaternion. This method
    //     runs faster than Godot.Quaternion.Length, so prefer it if you need to compare
    //     quaternions or need the squared length for some formula.
    //
    // 值:
    //     Equivalent to Dot(this).
    public readonly float LengthSquared()
    {
        return Dot(this);
    }

    //
    // 摘要:
    //     Returns a copy of the quaternion, normalized to unit length.
    //
    // 返回结果:
    //     The normalized quaternion.
    public readonly Quaternion Normalized()
    {
        return this / Length();
    }

    public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
    {
        float num1 = roll * 0.5f;
        float num2 = (float)Math.Sin((double)num1);
        float num3 = (float)Math.Cos((double)num1);
        float num4 = pitch * 0.5f;
        float num5 = (float)Math.Sin((double)num4);
        float num6 = (float)Math.Cos((double)num4);
        float num7 = yaw * 0.5f;
        float num8 = (float)Math.Sin((double)num7);
        float num9 = (float)Math.Cos((double)num7);
        Quaternion quaternion;
        quaternion.X = (float)((double)num9 * (double)num5 * (double)num3 + (double)num8 * (double)num6 * (double)num2);
        quaternion.Y = (float)((double)num8 * (double)num6 * (double)num3 - (double)num9 * (double)num5 * (double)num2);
        quaternion.Z = (float)((double)num9 * (double)num6 * (double)num2 - (double)num8 * (double)num5 * (double)num3);
        quaternion.W = (float)((double)num9 * (double)num6 * (double)num3 + (double)num8 * (double)num5 * (double)num2);
        return quaternion;
    }

    public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
    {
        float num1 = roll * 0.5f;
        float num2 = (float)Math.Sin((double)num1);
        float num3 = (float)Math.Cos((double)num1);
        float num4 = pitch * 0.5f;
        float num5 = (float)Math.Sin((double)num4);
        float num6 = (float)Math.Cos((double)num4);
        float num7 = yaw * 0.5f;
        float num8 = (float)Math.Sin((double)num7);
        float num9 = (float)Math.Cos((double)num7);
        result.X = (float)((double)num9 * (double)num5 * (double)num3 + (double)num8 * (double)num6 * (double)num2);
        result.Y = (float)((double)num8 * (double)num6 * (double)num3 - (double)num9 * (double)num5 * (double)num2);
        result.Z = (float)((double)num9 * (double)num6 * (double)num2 - (double)num8 * (double)num5 * (double)num3);
        result.W = (float)((double)num9 * (double)num6 * (double)num3 + (double)num8 * (double)num5 * (double)num2);
    }
    public static Quaternion CreateFromRotationMatrix(Matrix4x4 matrix)
    {
        float num1 = matrix.m00 + matrix.m11 + matrix.m22;
        Quaternion quaternion = new Quaternion();
        if ((double)num1 > 0.0)
        {
            float num2 = (float)Math.Sqrt((double)num1 + 1.0);
            quaternion.W = num2 * 0.5f;
            float num3 = 0.5f / num2;
            quaternion.X = (matrix.m21 - matrix.m12) * num3;
            quaternion.Y = (matrix.m02 - matrix.m20) * num3;
            quaternion.Z = (matrix.m10 - matrix.m01) * num3;
            return quaternion;
        }

        if ((double)matrix.m00 >= (double)matrix.m11 && (double)matrix.m00 >= (double)matrix.m22)
        {
            float num2 = (float)Math.Sqrt(1.0 + (double)matrix.m00 - (double)matrix.m11 - (double)matrix.m22);
            float num3 = 0.5f / num2;
            quaternion.X = 0.5f * num2;
            quaternion.Y = (matrix.m10 + matrix.m01) * num3;
            quaternion.Z = (matrix.m20 + matrix.m02) * num3;
            quaternion.W = (matrix.m21 - matrix.m12) * num3;
            return quaternion;
        }

        if ((double)matrix.m11 > (double)matrix.m22)
        {
            float num2 = (float)Math.Sqrt(1.0 + (double)matrix.m11 - (double)matrix.m00 - (double)matrix.m22);
            float num3 = 0.5f / num2;
            quaternion.X = (matrix.m01 + matrix.m10) * num3;
            quaternion.Y = 0.5f * num2;
            quaternion.Z = (matrix.m12 + matrix.m21) * num3;
            quaternion.W = (matrix.m02 - matrix.m20) * num3;
            return quaternion;
        }

        float num4 = (float)Math.Sqrt(1.0 + (double)matrix.m22 - (double)matrix.m00 - (double)matrix.m11);
        float num5 = 0.5f / num4;
        quaternion.X = (matrix.m02 + matrix.m20) * num5;
        quaternion.Y = (matrix.m12 + matrix.m21) * num5;
        quaternion.Z = 0.5f * num4;
        quaternion.W = (matrix.m10 - matrix.m01) * num5;
        return quaternion;
    }
    public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
    {
        float num1 = amount;
        float num2 = (float)((double)quaternion1.X * (double)quaternion2.X + (double)quaternion1.Y * (double)quaternion2.Y +
            (double)quaternion1.Z * (double)quaternion2.Z + (double)quaternion1.W * (double)quaternion2.W);
        bool flag = false;
        if ((double)num2 < 0.0)
        {
            flag = true;
            num2 = -num2;
        }

        float num3;
        float num4;
        if ((double)num2 > 0.999998986721039)
        {
            num3 = 1f - num1;
            num4 = flag ? -num1 : num1;
        }
        else
        {
            float num5 = (float)Math.Acos((double)num2);
            float num6 = (float)(1.0 / Math.Sin((double)num5));
            num3 = (float)Math.Sin((1.0 - (double)num1) * (double)num5) * num6;
            num4 = flag ? (float)-Math.Sin((double)num1 * (double)num5) * num6 : (float)Math.Sin((double)num1 * (double)num5) * num6;
        }

        Quaternion quaternion;
        quaternion.X = (float)((double)num3 * (double)quaternion1.X + (double)num4 * (double)quaternion2.X);
        quaternion.Y = (float)((double)num3 * (double)quaternion1.Y + (double)num4 * (double)quaternion2.Y);
        quaternion.Z = (float)((double)num3 * (double)quaternion1.Z + (double)num4 * (double)quaternion2.Z);
        quaternion.W = (float)((double)num3 * (double)quaternion1.W + (double)num4 * (double)quaternion2.W);
        return quaternion;
    }

    public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
    {
        float num1 = amount;
        float num2 = (float)((double)quaternion1.X * (double)quaternion2.X + (double)quaternion1.Y * (double)quaternion2.Y +
            (double)quaternion1.Z * (double)quaternion2.Z + (double)quaternion1.W * (double)quaternion2.W);
        bool flag = false;
        if ((double)num2 < 0.0)
        {
            flag = true;
            num2 = -num2;
        }

        float num3;
        float num4;
        if ((double)num2 > 0.999998986721039)
        {
            num3 = 1f - num1;
            num4 = flag ? -num1 : num1;
        }
        else
        {
            float num5 = (float)Math.Acos((double)num2);
            float num6 = (float)(1.0 / Math.Sin((double)num5));
            num3 = (float)Math.Sin((1.0 - (double)num1) * (double)num5) * num6;
            num4 = flag ? (float)-Math.Sin((double)num1 * (double)num5) * num6 : (float)Math.Sin((double)num1 * (double)num5) * num6;
        }

        result.X = (float)((double)num3 * (double)quaternion1.X + (double)num4 * (double)quaternion2.X);
        result.Y = (float)((double)num3 * (double)quaternion1.Y + (double)num4 * (double)quaternion2.Y);
        result.Z = (float)((double)num3 * (double)quaternion1.Z + (double)num4 * (double)quaternion2.Z);
        result.W = (float)((double)num3 * (double)quaternion1.W + (double)num4 * (double)quaternion2.W);
    }
    //
    // 摘要:Z
    //     Returns the result of the spherical linear interpolation between this quaternion
    //     and to by amount weight. Note: Both quaternions must be normalized.
    //
    // 参数:
    //   to:
    //     The destination quaternion for interpolation. Must be normalized.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting quaternion of the interpolation.
    public readonly Quaternion Slerp(Quaternion to, float weight)
    {
        float num = Dot(to);
        Quaternion quaternion = default(Quaternion);
        if ((double)num < 0.0)
        {
            num = 0f - num;
            quaternion = -to;
        }
        else
        {
            quaternion = to;
        }

        float num4;
        float num5;
        if (1.0 - (double)num > 9.9999999747524271E-07)
        {
            float num2 = Mathf.Acos(num);
            float num3 = Mathf.Sin(num2);
            num4 = Mathf.Sin((1f - weight) * num2) / num3;
            num5 = Mathf.Sin(weight * num2) / num3;
        }
        else
        {
            num4 = 1f - weight;
            num5 = weight;
        }

        return new Quaternion(num4 * X + num5 * quaternion.X, num4 * Y + num5 * quaternion.Y, num4 * Z + num5 * quaternion.Z, num4 * W + num5 * quaternion.W);
    }

    //
    // 摘要:
    //     Returns the result of the spherical linear interpolation between this quaternion
    //     and to by amount weight, but without checking if the rotation path is not bigger
    //     than 90 degrees.
    //
    // 参数:
    //   to:
    //     The destination quaternion for interpolation. Must be normalized.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting quaternion of the interpolation.
    public readonly Quaternion Slerpni(Quaternion to, float weight)
    {
        float s = Dot(to);
        if (Mathf.Abs(s) > 0.9999f)
        {
            return this;
        }

        float num = Mathf.Acos(s);
        float num2 = 1f / Mathf.Sin(num);
        float num3 = Mathf.Sin(weight * num) * num2;
        float num4 = Mathf.Sin((1f - weight) * num) * num2;
        return new Quaternion(num4 * X + num3 * to.X, num4 * Y + num3 * to.Y, num4 * Z + num3 * to.Z, num4 * W + num3 * to.W);
    }

    //
    // 摘要:
    //     Constructs a Godot.Quaternion defined by the given values.
    //
    // 参数:
    //   x:
    //     X component of the quaternion (imaginary i axis part).
    //
    //   y:
    //     Y component of the quaternion (imaginary j axis part).
    //
    //   z:
    //     Z component of the quaternion (imaginary k axis part).
    //
    //   w:
    //     W component of the quaternion (real part).
    public Quaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    //
    // 摘要:
    //     Constructs a Godot.Quaternion from the given Godot.Basis.
    //
    // 参数:
    //   basis:
    //     The Godot.Basis to construct from.
    public Quaternion(Basis basis)
    {
        this = basis.GetQuaternion();
    }

    //
    // 摘要:
    //     Constructs a Godot.Quaternion that will rotate around the given axis by the specified
    //     angle. The axis must be a normalized vector.
    //
    // 参数:
    //   axis:
    //     The axis to rotate around. Must be normalized.
    //
    //   angle:
    //     The angle to rotate, in radians.
    public Quaternion(Vector3 axis, float angle)
    {
        float num = axis.Length();
        if (num == 0f)
        {
            X = 0f;
            Y = 0f;
            Z = 0f;
            W = 0f;
            return;
        }

        (float Sin, float Cos) tuple = Mathf.SinCos(angle * 0.5f);
        float item = tuple.Sin;
        float item2 = tuple.Cos;
        float num2 = item / num;
        X = axis.X * num2;
        Y = axis.Y * num2;
        Z = axis.Z * num2;
        W = item2;
    }

    public Quaternion(Vector3 arcFrom, Vector3 arcTo)
    {
        Vector3 vector = arcFrom.Cross(arcTo);
        float num = arcFrom.Dot(arcTo);
        if (num < -0.999999f)
        {
            X = 0f;
            Y = 1f;
            Z = 0f;
            W = 0f;
        }
        else
        {
            float num2 = Mathf.Sqrt((1f + num) * 2f);
            float num3 = 1f / num2;
            X = vector.X * num3;
            Y = vector.Y * num3;
            Z = vector.Z * num3;
            W = num2 * 0.5f;
        }
    }

    //
    // 摘要:
    //     Constructs a Godot.Quaternion that will perform a rotation specified by Euler
    //     angles (in the YXZ convention: when decomposing, first Z, then X, and Y last),
    //     given in the vector format as (X angle, Y angle, Z angle).
    //
    // 参数:
    //   eulerYXZ:
    //     Euler angles that the quaternion will be rotated by.
    public static Quaternion FromEuler(Vector3 eulerYXZ)
    {
        float s = eulerYXZ.Y * 0.5f;
        float s2 = eulerYXZ.X * 0.5f;
        float s3 = eulerYXZ.Z * 0.5f;
        var (num, num2) = Mathf.SinCos(s);
        var (num3, num4) = Mathf.SinCos(s2);
        var (num5, num6) = Mathf.SinCos(s3);
        return new Quaternion(num * num4 * num5 + num2 * num3 * num6, num * num4 * num6 - num2 * num3 * num5, num2 * num4 * num5 - num * num3 * num6, num * num3 * num5 + num2 * num4 * num6);
    }

    //
    // 摘要:
    //     Composes these two quaternions by multiplying them together. This has the effect
    //     of rotating the second quaternion (the child) by the first quaternion (the parent).
    //
    //
    // 参数:
    //   left:
    //     The parent quaternion.
    //
    //   right:
    //     The child quaternion.
    //
    // 返回结果:
    //     The composed quaternion.
    public static Quaternion operator *(Quaternion left, Quaternion right)
    {
        return new Quaternion(left.W * right.X + left.X * right.W + left.Y * right.Z - left.Z * right.Y, left.W * right.Y + left.Y * right.W + left.Z * right.X - left.X * right.Z, left.W * right.Z + left.Z * right.W + left.X * right.Y - left.Y * right.X, left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    //
    // 摘要:
    //     Returns a Vector3 rotated (multiplied) by the quaternion.
    //
    // 参数:
    //   quaternion:
    //     The quaternion to rotate by.
    //
    //   vector:
    //     A Vector3 to transform.
    //
    // 返回结果:
    //     The rotated Vector3.
    public static Vector3 operator *(Quaternion quaternion, Vector3 vector)
    {
        Vector3 vector2 = new Vector3(quaternion.X, quaternion.Y, quaternion.Z);
        Vector3 vector3 = vector2.Cross(vector);
        return vector + (vector3 * quaternion.W + vector2.Cross(vector3)) * 2f;
    }

    //
    // 摘要:
    //     Returns a Vector3 rotated (multiplied) by the inverse quaternion. vector * quaternion
    //     is equivalent to quaternion.Inverse() * vector. See Godot.Quaternion.Inverse.
    //
    //
    // 参数:
    //   vector:
    //     A Vector3 to inversely rotate.
    //
    //   quaternion:
    //     The quaternion to rotate by.
    //
    // 返回结果:
    //     The inversely rotated Vector3.
    public static Vector3 operator *(Vector3 vector, Quaternion quaternion)
    {
        return quaternion.Inverse() * vector;
    }

    //
    // 摘要:
    //     Adds each component of the left Godot.Quaternion to the right Godot.Quaternion.
    //     This operation is not meaningful on its own, but it can be used as a part of
    //     a larger expression, such as approximating an intermediate rotation between two
    //     nearby rotations.
    //
    // 参数:
    //   left:
    //     The left quaternion to add.
    //
    //   right:
    //     The right quaternion to add.
    //
    // 返回结果:
    //     The added quaternion.
    public static Quaternion operator +(Quaternion left, Quaternion right)
    {
        return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
    }

    //
    // 摘要:
    //     Subtracts each component of the left Godot.Quaternion by the right Godot.Quaternion.
    //     This operation is not meaningful on its own, but it can be used as a part of
    //     a larger expression.
    //
    // 参数:
    //   left:
    //     The left quaternion to subtract.
    //
    //   right:
    //     The right quaternion to subtract.
    //
    // 返回结果:
    //     The subtracted quaternion.
    public static Quaternion operator -(Quaternion left, Quaternion right)
    {
        return new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
    }

    //
    // 摘要:
    //     Returns the negative value of the Godot.Quaternion. This is the same as writing
    //     new Quaternion(-q.X, -q.Y, -q.Z, -q.W). This operation results in a quaternion
    //     that represents the same rotation.
    //
    // 参数:
    //   quat:
    //     The quaternion to negate.
    //
    // 返回结果:
    //     The negated quaternion.
    public static Quaternion operator -(Quaternion quat)
    {
        return new Quaternion(0f - quat.X, 0f - quat.Y, 0f - quat.Z, 0f - quat.W);
    }

    //
    // 摘要:
    //     Multiplies each component of the Godot.Quaternion by the given System.Single.
    //     This operation is not meaningful on its own, but it can be used as a part of
    //     a larger expression.
    //
    // 参数:
    //   left:
    //     The quaternion to multiply.
    //
    //   right:
    //     The value to multiply by.
    //
    // 返回结果:
    //     The multiplied quaternion.
    public static Quaternion operator *(Quaternion left, float right)
    {
        return new Quaternion(left.X * right, left.Y * right, left.Z * right, left.W * right);
    }

    //
    // 摘要:
    //     Multiplies each component of the Godot.Quaternion by the given System.Single.
    //     This operation is not meaningful on its own, but it can be used as a part of
    //     a larger expression.
    //
    // 参数:
    //   left:
    //     The value to multiply by.
    //
    //   right:
    //     The quaternion to multiply.
    //
    // 返回结果:
    //     The multiplied quaternion.
    public static Quaternion operator *(float left, Quaternion right)
    {
        return new Quaternion(right.X * left, right.Y * left, right.Z * left, right.W * left);
    }

    //
    // 摘要:
    //     Divides each component of the Godot.Quaternion by the given System.Single. This
    //     operation is not meaningful on its own, but it can be used as a part of a larger
    //     expression.
    //
    // 参数:
    //   left:
    //     The quaternion to divide.
    //
    //   right:
    //     The value to divide by.
    //
    // 返回结果:
    //     The divided quaternion.
    public static Quaternion operator /(Quaternion left, float right)
    {
        return left * (1f / right);
    }

    //
    // 摘要:
    //     Returns true if the quaternions are exactly equal. Note: Due to floating-point
    //     precision errors, consider using Godot.Quaternion.IsEqualApprox(Godot.Quaternion)
    //     instead, which is more reliable.
    //
    // 参数:
    //   left:
    //     The left quaternion.
    //
    //   right:
    //     The right quaternion.
    //
    // 返回结果:
    //     Whether or not the quaternions are exactly equal.
    public static bool operator ==(Quaternion left, Quaternion right)
    {
        return left.Equals(right);
    }

    //
    // 摘要:
    //     Returns true if the quaternions are not equal. Note: Due to floating-point precision
    //     errors, consider using Godot.Quaternion.IsEqualApprox(Godot.Quaternion) instead,
    //     which is more reliable.
    //
    // 参数:
    //   left:
    //     The left quaternion.
    //
    //   right:
    //     The right quaternion.
    //
    // 返回结果:
    //     Whether or not the quaternions are not equal.
    public static bool operator !=(Quaternion left, Quaternion right)
    {
        return !left.Equals(right);
    }

    //
    // 摘要:
    //     Returns true if this quaternion and obj are equal.
    //
    // 参数:
    //   obj:
    //     The other object to compare.
    //
    // 返回结果:
    //     Whether or not the quaternion and the other object are exactly equal.
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is Quaternion other)
        {
            return Equals(other);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if this quaternion and other are equal.
    //
    // 参数:
    //   other:
    //     The other quaternion to compare.
    //
    // 返回结果:
    //     Whether or not the quaternions are exactly equal.
    public readonly bool Equals(Quaternion other)
    {
        if (X == other.X && Y == other.Y && Z == other.Z)
        {
            return W == other.W;
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if this quaternion and other are approximately equal, by running
    //     Godot.Mathf.IsEqualApprox(System.Single,System.Single) on each component.
    //
    // 参数:
    //   other:
    //     The other quaternion to compare.
    //
    // 返回结果:
    //     Whether or not the quaternions are approximately equal.
    public readonly bool IsEqualApprox(Quaternion other)
    {
        if (Mathf.IsEqualApprox(X, other.X) && Mathf.IsEqualApprox(Y, other.Y) && Mathf.IsEqualApprox(Z, other.Z))
        {
            return Mathf.IsEqualApprox(W, other.W);
        }

        return false;
    }

    //
    // 摘要:
    //     Serves as the hash function for Godot.Quaternion.
    //
    // 返回结果:
    //     A hash code for this quaternion.
    public override readonly int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }

    //
    // 摘要:
    //     Converts this Godot.Quaternion to a string.
    //
    // 返回结果:
    //     A string representation of this quaternion.
    public override readonly string ToString()
    {
        return ToString(null);
    }

    //
    // 摘要:
    //     Converts this Godot.Quaternion to a string with the given format.
    //
    // 返回结果:
    //     A string representation of this quaternion.
    public readonly string ToString(string? format)
    {
        return $"({X.ToString(format, CultureInfo.InvariantCulture)}, {Y.ToString(format, CultureInfo.InvariantCulture)}, {Z.ToString(format, CultureInfo.InvariantCulture)}, {W.ToString(format, CultureInfo.InvariantCulture)})";
    }
    public static Quaternion LookRotation(Vector3 viewVec, Vector3 upVec)
    {
        var lookingAt = Basis.LookingAt(viewVec, upVec);
        return lookingAt.GetRotationQuaternion();
    }

}
#if false // 反编译日志
缓存中的 170 项
------------------
解析: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Runtime.dll"
------------------
解析: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Runtime.Loader.dll"
------------------
解析: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Collections.Concurrent.dll"
------------------
解析: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Collections.dll"
------------------
解析: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Diagnostics.StackTrace.dll"
------------------
解析: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Runtime.InteropServices.dll"
------------------
解析: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Threading.dll"
------------------
解析: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Diagnostics.TraceSource.dll"
------------------
解析: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Memory.dll"
------------------
解析: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Linq.dll"
------------------
解析: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Security.Cryptography.dll"
------------------
解析: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Text.RegularExpressions.dll"
------------------
解析: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Console.dll"
------------------
解析: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null"
找到单个程序集: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net8.0\System.Runtime.CompilerServices.Unsafe.dll"
#endif
