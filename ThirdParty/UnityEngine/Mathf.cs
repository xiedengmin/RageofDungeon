#region 程序集 GodotSharp, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Administrator\.nuget\packages\godotsharp\4.4.0-beta\lib\net8.0\GodotSharp.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Runtime.CompilerServices;

namespace Godot;

//
// 摘要:
//     Provides constants and static methods for common mathematical functions.
public static class Mathf
{
    //
    // 摘要:
    //     The circle constant, the circumference of the unit circle in radians.
    public const float Tau = MathF.PI * 2f;

    //
    // 摘要:
    //     Constant that represents how many times the diameter of a circle fits around
    //     its perimeter. This is equivalent to Mathf.Tau / 2.
    public const float Pi = MathF.PI;

    //
    // 摘要:
    //     Positive infinity. For negative infinity, use -Mathf.Inf.
    public const float Inf = float.PositiveInfinity;

    //
    // 摘要:
    //     "Not a Number", an invalid value. NaN has special properties, including that
    //     it is not equal to itself. It is output by some invalid operations, such as dividing
    //     zero by zero.
    public const float NaN = float.NaN;

    private const float DegToRadConstF = MathF.PI / 180f;

    private const double DegToRadConstD = Math.PI / 180.0;

    private const float RadToDegConstF = 57.29578f;

    private const double RadToDegConstD = 57.295779513082316;

    //
    // 摘要:
    //     The natural number e.
    public const float E = MathF.E;

    //
    // 摘要:
    //     The square root of 2.
    public const float Sqrt2 = 1.41421354f;

    private const float EpsilonF = 1E-06f;

    private const double EpsilonD = 1E-14;

    //
    // 摘要:
    //     A very small number used for float comparison with error tolerance. 1e-06 with
    //     single-precision floats, but 1e-14 if REAL_T_IS_DOUBLE.
    public const float Epsilon = 1E-06f;

    //
    // 摘要:
    //     Returns the absolute value of s (i.e. positive value).
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     The absolute value of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Abs(int s)
    {
        return Math.Abs(s);
    }

    //
    // 摘要:
    //     Returns the absolute value of s (i.e. positive value).
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     The absolute value of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Abs(float s)
    {
        return Math.Abs(s);
    }

    //
    // 摘要:
    //     Returns the absolute value of s (i.e. positive value).
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     The absolute value of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Abs(double s)
    {
        return Math.Abs(s);
    }

    //
    // 摘要:
    //     Returns the arc cosine of s in radians. Use to get the angle of cosine s.
    //
    // 参数:
    //   s:
    //     The input cosine value. Must be on the range of -1.0 to 1.0.
    //
    // 返回结果:
    //     An angle that would result in the given cosine value. On the range 0 to Tau/2.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Acos(float s)
    {
        return MathF.Acos(s);
    }

    //
    // 摘要:
    //     Returns the arc cosine of s in radians. Use to get the angle of cosine s.
    //
    // 参数:
    //   s:
    //     The input cosine value. Must be on the range of -1.0 to 1.0.
    //
    // 返回结果:
    //     An angle that would result in the given cosine value. On the range 0 to Tau/2.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Acos(double s)
    {
        return Math.Acos(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) cosine of s in radians. Use
    //     it to get the angle from an angle's cosine in hyperbolic space if s is larger
    //     or equal to 1.
    //
    // 参数:
    //   s:
    //     The input hyperbolic cosine value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic cosine value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Acosh(float s)
    {
        return MathF.Acosh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) cosine of s in radians. Use
    //     it to get the angle from an angle's cosine in hyperbolic space if s is larger
    //     or equal to 1.
    //
    // 参数:
    //   s:
    //     The input hyperbolic cosine value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic cosine value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Acosh(double s)
    {
        return Math.Acosh(s);
    }

    //
    // 摘要:
    //     Returns the difference between the two angles, in range of -Godot.Mathf.Pi, Godot.Mathf.Pi.
    //     When from and to are opposite, returns -Godot.Mathf.Pi if from is smaller than
    //     to, or Godot.Mathf.Pi otherwise.
    //
    // 参数:
    //   from:
    //     The start angle.
    //
    //   to:
    //     The destination angle.
    //
    // 返回结果:
    //     The difference between the two angles.
    public static float AngleDifference(float from, float to)
    {
        float num = (to - from) % (MathF.PI * 2f);
        return 2f * num % (MathF.PI * 2f) - num;
    }

    //
    // 摘要:
    //     Returns the difference between the two angles, in range of -Godot.Mathf.Pi, Godot.Mathf.Pi.
    //     When from and to are opposite, returns -Godot.Mathf.Pi if from is smaller than
    //     to, or Godot.Mathf.Pi otherwise.
    //
    // 参数:
    //   from:
    //     The start angle.
    //
    //   to:
    //     The destination angle.
    //
    // 返回结果:
    //     The difference between the two angles.
    public static double AngleDifference(double from, double to)
    {
        double num = (to - from) % (Math.PI * 2.0);
        return 2.0 * num % (Math.PI * 2.0) - num;
    }

    //
    // 摘要:
    //     Returns the arc sine of s in radians. Use to get the angle of sine s.
    //
    // 参数:
    //   s:
    //     The input sine value. Must be on the range of -1.0 to 1.0.
    //
    // 返回结果:
    //     An angle that would result in the given sine value. On the range -Tau/4 to Tau/4.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Asin(float s)
    {
        return MathF.Asin(s);
    }

    //
    // 摘要:
    //     Returns the arc sine of s in radians. Use to get the angle of sine s.
    //
    // 参数:
    //   s:
    //     The input sine value. Must be on the range of -1.0 to 1.0.
    //
    // 返回结果:
    //     An angle that would result in the given sine value. On the range -Tau/4 to Tau/4.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Asin(double s)
    {
        return Math.Asin(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) sine of s in radians. Use it
    //     to get the angle from an angle's sine in hyperbolic space if s is larger or equal
    //     to 1.
    //
    // 参数:
    //   s:
    //     The input hyperbolic sine value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic sine value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Asinh(float s)
    {
        return MathF.Asinh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) sine of s in radians. Use it
    //     to get the angle from an angle's sine in hyperbolic space if s is larger or equal
    //     to 1.
    //
    // 参数:
    //   s:
    //     The input hyperbolic sine value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic sine value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Asinh(double s)
    {
        return Math.Asinh(s);
    }

    //
    // 摘要:
    //     Returns the arc tangent of s in radians. Use to get the angle of tangent s. The
    //     method cannot know in which quadrant the angle should fall. See Godot.Mathf.Atan2(System.Single,System.Single)
    //     if you have both y and x.
    //
    // 参数:
    //   s:
    //     The input tangent value.
    //
    // 返回结果:
    //     An angle that would result in the given tangent value. On the range -Tau/4 to
    //     Tau/4.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Atan(float s)
    {
        return MathF.Atan(s);
    }

    //
    // 摘要:
    //     Returns the arc tangent of s in radians. Use to get the angle of tangent s. The
    //     method cannot know in which quadrant the angle should fall. See Godot.Mathf.Atan2(System.Double,System.Double)
    //     if you have both y and x.
    //
    // 参数:
    //   s:
    //     The input tangent value.
    //
    // 返回结果:
    //     An angle that would result in the given tangent value. On the range -Tau/4 to
    //     Tau/4.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Atan(double s)
    {
        return Math.Atan(s);
    }

    //
    // 摘要:
    //     Returns the arc tangent of y and x in radians. Use to get the angle of the tangent
    //     of y/x. To compute the value, the method takes into account the sign of both
    //     arguments in order to determine the quadrant. Important note: The Y coordinate
    //     comes first, by convention.
    //
    // 参数:
    //   y:
    //     The Y coordinate of the point to find the angle to.
    //
    //   x:
    //     The X coordinate of the point to find the angle to.
    //
    // 返回结果:
    //     An angle that would result in the given tangent value. On the range -Tau/2 to
    //     Tau/2.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Atan2(float y, float x)
    {
        return MathF.Atan2(y, x);
    }

    //
    // 摘要:
    //     Returns the arc tangent of y and x in radians. Use to get the angle of the tangent
    //     of y/x. To compute the value, the method takes into account the sign of both
    //     arguments in order to determine the quadrant. Important note: The Y coordinate
    //     comes first, by convention.
    //
    // 参数:
    //   y:
    //     The Y coordinate of the point to find the angle to.
    //
    //   x:
    //     The X coordinate of the point to find the angle to.
    //
    // 返回结果:
    //     An angle that would result in the given tangent value. On the range -Tau/2 to
    //     Tau/2.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Atan2(double y, double x)
    {
        return Math.Atan2(y, x);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) tangent of s in radians. Use
    //     it to get the angle from an angle's tangent in hyperbolic space if s is between
    //     -1 and 1 (non-inclusive).
    //
    // 参数:
    //   s:
    //     The input hyperbolic tangent value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic tangent value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Atanh(float s)
    {
        return MathF.Atanh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic arc (also called inverse) tangent of s in radians. Use
    //     it to get the angle from an angle's tangent in hyperbolic space if s is between
    //     -1 and 1 (non-inclusive).
    //
    // 参数:
    //   s:
    //     The input hyperbolic tangent value.
    //
    // 返回结果:
    //     An angle that would result in the given hyperbolic tangent value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Atanh(double s)
    {
        return Math.Atanh(s);
    }

    //
    // 摘要:
    //     Rounds s upward (towards positive infinity).
    //
    // 参数:
    //   s:
    //     The number to ceil.
    //
    // 返回结果:
    //     The smallest whole number that is not less than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Ceil(float s)
    {
        return MathF.Ceiling(s);
    }

    //
    // 摘要:
    //     Rounds s upward (towards positive infinity).
    //
    // 参数:
    //   s:
    //     The number to ceil.
    //
    // 返回结果:
    //     The smallest whole number that is not less than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Ceil(double s)
    {
        return Math.Ceiling(s);
    }

    //
    // 摘要:
    //     Clamps a value so that it is not less than min and not more than max.
    //
    // 参数:
    //   value:
    //     The value to clamp.
    //
    //   min:
    //     The minimum allowed value.
    //
    //   max:
    //     The maximum allowed value.
    //
    // 返回结果:
    //     The clamped value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Clamp(int value, int min, int max)
    {
        return Math.Clamp(value, min, max);
    }

    //
    // 摘要:
    //     Clamps a value so that it is not less than min and not more than max.
    //
    // 参数:
    //   value:
    //     The value to clamp.
    //
    //   min:
    //     The minimum allowed value.
    //
    //   max:
    //     The maximum allowed value.
    //
    // 返回结果:
    //     The clamped value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamp(float value, float min, float max)
    {
        return Math.Clamp(value, min, max);
    }

    //
    // 摘要:
    //     Clamps a value so that it is not less than min and not more than max.
    //
    // 参数:
    //   value:
    //     The value to clamp.
    //
    //   min:
    //     The minimum allowed value.
    //
    //   max:
    //     The maximum allowed value.
    //
    // 返回结果:
    //     The clamped value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Clamp(double value, double min, double max)
    {
        return Math.Clamp(value, min, max);
    }

    //
    // 摘要:
    //     Returns the cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The cosine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Cos(float s)
    {
        return MathF.Cos(s);
    }

    //
    // 摘要:
    //     Returns the cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The cosine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Cos(double s)
    {
        return Math.Cos(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic cosine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Cosh(float s)
    {
        return MathF.Cosh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic cosine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Cosh(double s)
    {
        return Math.Cosh(s);
    }

    //
    // 摘要:
    //     Cubic interpolates between two values by the factor defined in weight with pre
    //     and post values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float CubicInterpolate(float from, float to, float pre, float post, float weight)
    {
        return 0.5f * (from * 2f + (0f - pre + to) * weight + (2f * pre - 5f * from + 4f * to - post) * (weight * weight) + (0f - pre + 3f * from - 3f * to + post) * (weight * weight * weight));
    }

    //
    // 摘要:
    //     Cubic interpolates between two values by the factor defined in weight with pre
    //     and post values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double CubicInterpolate(double from, double to, double pre, double post, double weight)
    {
        return 0.5 * (from * 2.0 + (0.0 - pre + to) * weight + (2.0 * pre - 5.0 * from + 4.0 * to - post) * (weight * weight) + (0.0 - pre + 3.0 * from - 3.0 * to + post) * (weight * weight * weight));
    }

    //
    // 摘要:
    //     Cubic interpolates between two rotation values with shortest path by the factor
    //     defined in weight with pre and post values. See also Godot.Mathf.LerpAngle(System.Single,System.Single,System.Single).
    //
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float CubicInterpolateAngle(float from, float to, float pre, float post, float weight)
    {
        float num = from % (MathF.PI * 2f);
        float num2 = (pre - num) % (MathF.PI * 2f);
        float pre2 = num + 2f * num2 % (MathF.PI * 2f) - num2;
        float num3 = (to - num) % (MathF.PI * 2f);
        float num4 = num + 2f * num3 % (MathF.PI * 2f) - num3;
        float num5 = (post - num4) % (MathF.PI * 2f);
        float post2 = num4 + 2f * num5 % (MathF.PI * 2f) - num5;
        return CubicInterpolate(num, num4, pre2, post2, weight);
    }

    //
    // 摘要:
    //     Cubic interpolates between two rotation values with shortest path by the factor
    //     defined in weight with pre and post values. See also Godot.Mathf.LerpAngle(System.Double,System.Double,System.Double).
    //
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double CubicInterpolateAngle(double from, double to, double pre, double post, double weight)
    {
        double num = from % (Math.PI * 2.0);
        double num2 = (pre - num) % (Math.PI * 2.0);
        double pre2 = num + 2.0 * num2 % (Math.PI * 2.0) - num2;
        double num3 = (to - num) % (Math.PI * 2.0);
        double num4 = num + 2.0 * num3 % (Math.PI * 2.0) - num3;
        double num5 = (post - num4) % (Math.PI * 2.0);
        double post2 = num4 + 2.0 * num5 % (Math.PI * 2.0) - num5;
        return CubicInterpolate(num, num4, pre2, post2, weight);
    }

    //
    // 摘要:
    //     Cubic interpolates between two values by the factor defined in weight with pre
    //     and post values. It can perform smoother interpolation than Godot.Mathf.CubicInterpolate(System.Single,System.Single,System.Single,System.Single,System.Single)
    //     by the time values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   toT:
    //
    //   preT:
    //
    //   postT:
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float CubicInterpolateInTime(float from, float to, float pre, float post, float weight, float toT, float preT, float postT)
    {
        float num = Lerp(0f, toT, weight);
        float from2 = Lerp(pre, from, (preT == 0f) ? 0f : ((num - preT) / (0f - preT)));
        float num2 = Lerp(from, to, (toT == 0f) ? 0.5f : (num / toT));
        float to2 = Lerp(to, post, (postT - toT == 0f) ? 1f : ((num - toT) / (postT - toT)));
        float from3 = Lerp(from2, num2, (toT - preT == 0f) ? 0f : ((num - preT) / (toT - preT)));
        float to3 = Lerp(num2, to2, (postT == 0f) ? 1f : (num / postT));
        return Lerp(from3, to3, (toT == 0f) ? 0.5f : (num / toT));
    }

    //
    // 摘要:
    //     Cubic interpolates between two values by the factor defined in weight with pre
    //     and post values. It can perform smoother interpolation than Godot.Mathf.CubicInterpolate(System.Double,System.Double,System.Double,System.Double,System.Double)
    //     by the time values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   toT:
    //
    //   preT:
    //
    //   postT:
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double CubicInterpolateInTime(double from, double to, double pre, double post, double weight, double toT, double preT, double postT)
    {
        double num = Lerp(0.0, toT, weight);
        double from2 = Lerp(pre, from, (preT == 0.0) ? 0.0 : ((num - preT) / (0.0 - preT)));
        double num2 = Lerp(from, to, (toT == 0.0) ? 0.5 : (num / toT));
        double to2 = Lerp(to, post, (postT - toT == 0.0) ? 1.0 : ((num - toT) / (postT - toT)));
        double from3 = Lerp(from2, num2, (toT - preT == 0.0) ? 0.0 : ((num - preT) / (toT - preT)));
        double to3 = Lerp(num2, to2, (postT == 0.0) ? 1.0 : (num / postT));
        return Lerp(from3, to3, (toT == 0.0) ? 0.5 : (num / toT));
    }

    //
    // 摘要:
    //     Cubic interpolates between two rotation values with shortest path by the factor
    //     defined in weight with pre and post values. See also Godot.Mathf.LerpAngle(System.Single,System.Single,System.Single).
    //     It can perform smoother interpolation than Godot.Mathf.CubicInterpolateAngle(System.Single,System.Single,System.Single,System.Single,System.Single)
    //     by the time values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   toT:
    //
    //   preT:
    //
    //   postT:
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float CubicInterpolateAngleInTime(float from, float to, float pre, float post, float weight, float toT, float preT, float postT)
    {
        float num = from % (MathF.PI * 2f);
        float num2 = (pre - num) % (MathF.PI * 2f);
        float pre2 = num + 2f * num2 % (MathF.PI * 2f) - num2;
        float num3 = (to - num) % (MathF.PI * 2f);
        float num4 = num + 2f * num3 % (MathF.PI * 2f) - num3;
        float num5 = (post - num4) % (MathF.PI * 2f);
        float post2 = num4 + 2f * num5 % (MathF.PI * 2f) - num5;
        return CubicInterpolateInTime(num, num4, pre2, post2, weight, toT, preT, postT);
    }

    //
    // 摘要:
    //     Cubic interpolates between two rotation values with shortest path by the factor
    //     defined in weight with pre and post values. See also Godot.Mathf.LerpAngle(System.Double,System.Double,System.Double).
    //     It can perform smoother interpolation than Godot.Mathf.CubicInterpolateAngle(System.Double,System.Double,System.Double,System.Double,System.Double)
    //     by the time values.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   pre:
    //     The value which before "from" value for interpolation.
    //
    //   post:
    //     The value which after "to" value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    //   toT:
    //
    //   preT:
    //
    //   postT:
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double CubicInterpolateAngleInTime(double from, double to, double pre, double post, double weight, double toT, double preT, double postT)
    {
        double num = from % (Math.PI * 2.0);
        double num2 = (pre - num) % (Math.PI * 2.0);
        double pre2 = num + 2.0 * num2 % (Math.PI * 2.0) - num2;
        double num3 = (to - num) % (Math.PI * 2.0);
        double num4 = num + 2.0 * num3 % (Math.PI * 2.0) - num3;
        double num5 = (post - num4) % (Math.PI * 2.0);
        double post2 = num4 + 2.0 * num5 % (Math.PI * 2.0) - num5;
        return CubicInterpolateInTime(num, num4, pre2, post2, weight, toT, preT, postT);
    }

    //
    // 摘要:
    //     Returns the point at the given t on a one-dimensional Bezier curve defined by
    //     the given control1, control2, and end points.
    //
    // 参数:
    //   start:
    //     The start value for the interpolation.
    //
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
    public static float BezierInterpolate(float start, float control1, float control2, float end, float t)
    {
        float num = 1f - t;
        float num2 = num * num;
        float num3 = num2 * num;
        float num4 = t * t;
        float num5 = num4 * t;
        return start * num3 + control1 * num2 * t * 3f + control2 * num * num4 * 3f + end * num5;
    }

    //
    // 摘要:
    //     Returns the point at the given t on a one-dimensional Bezier curve defined by
    //     the given control1, control2, and end points.
    //
    // 参数:
    //   start:
    //     The start value for the interpolation.
    //
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
    public static double BezierInterpolate(double start, double control1, double control2, double end, double t)
    {
        double num = 1.0 - t;
        double num2 = num * num;
        double num3 = num2 * num;
        double num4 = t * t;
        double num5 = num4 * t;
        return start * num3 + control1 * num2 * t * 3.0 + control2 * num * num4 * 3.0 + end * num5;
    }

    //
    // 摘要:
    //     Returns the derivative at the given t on a one dimensional Bezier curve defined
    //     by the given control1, control2, and end points.
    //
    // 参数:
    //   start:
    //     The start value for the interpolation.
    //
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
    public static float BezierDerivative(float start, float control1, float control2, float end, float t)
    {
        float num = 1f - t;
        float num2 = num * num;
        float num3 = t * t;
        return (control1 - start) * 3f * num2 + (control2 - control1) * 6f * num * t + (end - control2) * 3f * num3;
    }

    //
    // 摘要:
    //     Returns the derivative at the given t on a one dimensional Bezier curve defined
    //     by the given control1, control2, and end points.
    //
    // 参数:
    //   start:
    //     The start value for the interpolation.
    //
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
    public static double BezierDerivative(double start, double control1, double control2, double end, double t)
    {
        double num = 1.0 - t;
        double num2 = num * num;
        double num3 = t * t;
        return (control1 - start) * 3.0 * num2 + (control2 - control1) * 6.0 * num * t + (end - control2) * 3.0 * num3;
    }

    //
    // 摘要:
    //     Converts from decibels to linear energy (audio).
    //
    // 参数:
    //   db:
    //     Decibels to convert.
    //
    // 返回结果:
    //     Audio volume as linear energy.
    public static float DbToLinear(float db)
    {
        return MathF.Exp(db * 0.115129255f);
    }

    //
    // 摘要:
    //     Converts from decibels to linear energy (audio).
    //
    // 参数:
    //   db:
    //     Decibels to convert.
    //
    // 返回结果:
    //     Audio volume as linear energy.
    public static double DbToLinear(double db)
    {
        return Math.Exp(db * 0.11512925464970228);
    }

    //
    // 摘要:
    //     Converts an angle expressed in degrees to radians.
    //
    // 参数:
    //   deg:
    //     An angle expressed in degrees.
    //
    // 返回结果:
    //     The same angle expressed in radians.
    public static float DegToRad(float deg)
    {
        return deg * (MathF.PI / 180f);
    }

    //
    // 摘要:
    //     Converts an angle expressed in degrees to radians.
    //
    // 参数:
    //   deg:
    //     An angle expressed in degrees.
    //
    // 返回结果:
    //     The same angle expressed in radians.
    public static double DegToRad(double deg)
    {
        return deg * (Math.PI / 180.0);
    }

    //
    // 摘要:
    //     Easing function, based on exponent. The curve values are: 0 is constant, 1 is
    //     linear, 0 to 1 is ease-in, 1 or more is ease-out. Negative values are in-out/out-in.
    //
    //
    // 参数:
    //   s:
    //     The value to ease.
    //
    //   curve:
    //     0 is constant, 1 is linear, 0 to 1 is ease-in, 1 or more is ease-out.
    //
    // 返回结果:
    //     The eased value.
    public static float Ease(float s, float curve)
    {
        if (s < 0f)
        {
            s = 0f;
        }
        else if (s > 1f)
        {
            s = 1f;
        }

        if (curve > 0f)
        {
            if (curve < 1f)
            {
                return 1f - MathF.Pow(1f - s, 1f / curve);
            }

            return MathF.Pow(s, curve);
        }

        if (curve < 0f)
        {
            if (s < 0.5f)
            {
                return MathF.Pow(s * 2f, 0f - curve) * 0.5f;
            }

            return (1f - MathF.Pow(1f - (s - 0.5f) * 2f, 0f - curve)) * 0.5f + 0.5f;
        }

        return 0f;
    }

    //
    // 摘要:
    //     Easing function, based on exponent. The curve values are: 0 is constant, 1 is
    //     linear, 0 to 1 is ease-in, 1 or more is ease-out. Negative values are in-out/out-in.
    //
    //
    // 参数:
    //   s:
    //     The value to ease.
    //
    //   curve:
    //     0 is constant, 1 is linear, 0 to 1 is ease-in, 1 or more is ease-out.
    //
    // 返回结果:
    //     The eased value.
    public static double Ease(double s, double curve)
    {
        if (s < 0.0)
        {
            s = 0.0;
        }
        else if (s > 1.0)
        {
            s = 1.0;
        }

        if (curve > 0.0)
        {
            if (curve < 1.0)
            {
                return 1.0 - Math.Pow(1.0 - s, 1.0 / curve);
            }

            return Math.Pow(s, curve);
        }

        if (curve < 0.0)
        {
            if (s < 0.5)
            {
                return Math.Pow(s * 2.0, 0.0 - curve) * 0.5;
            }

            return (1.0 - Math.Pow(1.0 - (s - 0.5) * 2.0, 0.0 - curve)) * 0.5 + 0.5;
        }

        return 0.0;
    }

    //
    // 摘要:
    //     The natural exponential function. It raises the mathematical constant e to the
    //     power of s and returns it.
    //
    // 参数:
    //   s:
    //     The exponent to raise e to.
    //
    // 返回结果:
    //     e raised to the power of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Exp(float s)
    {
        return MathF.Exp(s);
    }

    //
    // 摘要:
    //     The natural exponential function. It raises the mathematical constant e to the
    //     power of s and returns it.
    //
    // 参数:
    //   s:
    //     The exponent to raise e to.
    //
    // 返回结果:
    //     e raised to the power of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Exp(double s)
    {
        return Math.Exp(s);
    }

    //
    // 摘要:
    //     Rounds s downward (towards negative infinity).
    //
    // 参数:
    //   s:
    //     The number to floor.
    //
    // 返回结果:
    //     The largest whole number that is not more than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Floor(float s)
    {
        return MathF.Floor(s);
    }

    //
    // 摘要:
    //     Rounds s downward (towards negative infinity).
    //
    // 参数:
    //   s:
    //     The number to floor.
    //
    // 返回结果:
    //     The largest whole number that is not more than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Floor(double s)
    {
        return Math.Floor(s);
    }

    //
    // 摘要:
    //     Returns a normalized value considering the given range. This is the opposite
    //     of Godot.Mathf.Lerp(System.Single,System.Single,System.Single).
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     The interpolated value.
    //
    // 返回结果:
    //     The resulting value of the inverse interpolation. The returned value will be
    //     between 0.0 and 1.0 if weight is between from and to (inclusive).
    public static float InverseLerp(float from, float to, float weight)
    {
        return (weight - from) / (to - from);
    }

    //
    // 摘要:
    //     Returns a normalized value considering the given range. This is the opposite
    //     of Godot.Mathf.Lerp(System.Double,System.Double,System.Double).
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     The interpolated value.
    //
    // 返回结果:
    //     The resulting value of the inverse interpolation. The returned value will be
    //     between 0.0 and 1.0 if weight is between from and to (inclusive).
    public static double InverseLerp(double from, double to, double weight)
    {
        return (weight - from) / (to - from);
    }

    //
    // 摘要:
    //     Returns true if a and b are approximately equal to each other. The comparison
    //     is done using a tolerance calculation with Godot.Mathf.Epsilon.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     A bool for whether or not the two values are approximately equal.
    public static bool IsEqualApprox(float a, float b)
    {
        if (a == b)
        {
            return true;
        }

        float num = 1E-06f * Math.Abs(a);
        if (num < 1E-06f)
        {
            num = 1E-06f;
        }

        return Math.Abs(a - b) < num;
    }

    //
    // 摘要:
    //     Returns true if a and b are approximately equal to each other. The comparison
    //     is done using a tolerance calculation with Godot.Mathf.Epsilon.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     A bool for whether or not the two values are approximately equal.
    public static bool IsEqualApprox(double a, double b)
    {
        if (a == b)
        {
            return true;
        }

        double num = 1E-14 * Math.Abs(a);
        if (num < 1E-14)
        {
            num = 1E-14;
        }

        return Math.Abs(a - b) < num;
    }

    //
    // 摘要:
    //     Returns whether s is a finite value, i.e. it is not Godot.Mathf.NaN, positive
    //     infinite, or negative infinity.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is a finite value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsFinite(float s)
    {
        return float.IsFinite(s);
    }

    //
    // 摘要:
    //     Returns whether s is a finite value, i.e. it is not Godot.Mathf.NaN, positive
    //     infinite, or negative infinity.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is a finite value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsFinite(double s)
    {
        return double.IsFinite(s);
    }

    //
    // 摘要:
    //     Returns whether s is an infinity value (either positive infinity or negative
    //     infinity).
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is an infinity value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInf(float s)
    {
        return float.IsInfinity(s);
    }

    //
    // 摘要:
    //     Returns whether s is an infinity value (either positive infinity or negative
    //     infinity).
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is an infinity value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInf(double s)
    {
        return double.IsInfinity(s);
    }

    //
    // 摘要:
    //     Returns whether s is a NaN ("Not a Number" or invalid) value.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is a NaN value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNaN(float s)
    {
        return float.IsNaN(s);
    }

    //
    // 摘要:
    //     Returns whether s is a NaN ("Not a Number" or invalid) value.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is a NaN value.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNaN(double s)
    {
        return double.IsNaN(s);
    }

    //
    // 摘要:
    //     Returns true if s is zero or almost zero. The comparison is done using a tolerance
    //     calculation with Godot.Mathf.Epsilon. This method is faster than using Godot.Mathf.IsEqualApprox(System.Single,System.Single)
    //     with one value as zero.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is nearly zero.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroApprox(float s)
    {
        return Math.Abs(s) < 1E-06f;
    }

    //
    // 摘要:
    //     Returns true if s is zero or almost zero. The comparison is done using a tolerance
    //     calculation with Godot.Mathf.Epsilon. This method is faster than using Godot.Mathf.IsEqualApprox(System.Double,System.Double)
    //     with one value as zero.
    //
    // 参数:
    //   s:
    //     The value to check.
    //
    // 返回结果:
    //     A bool for whether or not the value is nearly zero.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroApprox(double s)
    {
        return Math.Abs(s) < 1E-14;
    }

    //
    // 摘要:
    //     Linearly interpolates between two values by a normalized value. This is the opposite
    //     Godot.Mathf.InverseLerp(System.Single,System.Single,System.Single).
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float Lerp(float from, float to, float weight)
    {
        return from + (to - from) * weight;
    }

    //
    // 摘要:
    //     Linearly interpolates between two values by a normalized value. This is the opposite
    //     Godot.Mathf.InverseLerp(System.Double,System.Double,System.Double).
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double Lerp(double from, double to, double weight)
    {
        return from + (to - from) * weight;
    }

    //
    // 摘要:
    //     Linearly interpolates between two angles (in radians) by a normalized value.
    //     Similar to Godot.Mathf.Lerp(System.Single,System.Single,System.Single), but interpolates
    //     correctly when the angles wrap around Godot.Mathf.Tau.
    //
    // 参数:
    //   from:
    //     The start angle for interpolation.
    //
    //   to:
    //     The destination angle for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting angle of the interpolation.
    public static float LerpAngle(float from, float to, float weight)
    {
        return from + AngleDifference(from, to) * weight;
    }

    //
    // 摘要:
    //     Linearly interpolates between two angles (in radians) by a normalized value.
    //     Similar to Godot.Mathf.Lerp(System.Double,System.Double,System.Double), but interpolates
    //     correctly when the angles wrap around Godot.Mathf.Tau.
    //
    // 参数:
    //   from:
    //     The start angle for interpolation.
    //
    //   to:
    //     The destination angle for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting angle of the interpolation.
    public static double LerpAngle(double from, double to, double weight)
    {
        return from + AngleDifference(from, to) * weight;
    }

    //
    // 摘要:
    //     Converts from linear energy to decibels (audio). This can be used to implement
    //     volume sliders that behave as expected (since volume isn't linear).
    //
    // 参数:
    //   linear:
    //     The linear energy to convert.
    //
    // 返回结果:
    //     Audio as decibels.
    public static float LinearToDb(float linear)
    {
        return MathF.Log(linear) * 8.685889f;
    }

    //
    // 摘要:
    //     Converts from linear energy to decibels (audio). This can be used to implement
    //     volume sliders that behave as expected (since volume isn't linear).
    //
    // 参数:
    //   linear:
    //     The linear energy to convert.
    //
    // 返回结果:
    //     Audio as decibels.
    public static double LinearToDb(double linear)
    {
        return Math.Log(linear) * 8.6858896380650368;
    }

    //
    // 摘要:
    //     Natural logarithm. The amount of time needed to reach a certain level of continuous
    //     growth. Note: This is not the same as the "log" function on most calculators,
    //     which uses a base 10 logarithm.
    //
    // 参数:
    //   s:
    //     The input value.
    //
    // 返回结果:
    //     The natural log of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Log(float s)
    {
        return MathF.Log(s);
    }

    //
    // 摘要:
    //     Natural logarithm. The amount of time needed to reach a certain level of continuous
    //     growth. Note: This is not the same as the "log" function on most calculators,
    //     which uses a base 10 logarithm.
    //
    // 参数:
    //   s:
    //     The input value.
    //
    // 返回结果:
    //     The natural log of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Log(double s)
    {
        return Math.Log(s);
    }

    //
    // 摘要:
    //     Returns the maximum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is higher.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Max(int a, int b)
    {
        return Math.Max(a, b);
    }

    //
    // 摘要:
    //     Returns the maximum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is higher.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Max(float a, float b)
    {
        return Math.Max(a, b);
    }

    //
    // 摘要:
    //     Returns the maximum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is higher.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Max(double a, double b)
    {
        return Math.Max(a, b);
    }

    //
    // 摘要:
    //     Returns the minimum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is lower.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Min(int a, int b)
    {
        return Math.Min(a, b);
    }

    //
    // 摘要:
    //     Returns the minimum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is lower.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Min(float a, float b)
    {
        return Math.Min(a, b);
    }

    //
    // 摘要:
    //     Returns the minimum of two values.
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    // 返回结果:
    //     Whichever of the two values is lower.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Min(double a, double b)
    {
        return Math.Min(a, b);
    }

    //
    // 摘要:
    //     Moves from toward to by the delta value. Use a negative delta value to move away.
    //
    //
    // 参数:
    //   from:
    //     The start value.
    //
    //   to:
    //     The value to move towards.
    //
    //   delta:
    //     The amount to move by.
    //
    // 返回结果:
    //     The value after moving.
    public static float MoveToward(float from, float to, float delta)
    {
        if (Math.Abs(to - from) <= delta)
        {
            return to;
        }

        return from + (float)Math.Sign(to - from) * delta;
    }

    //
    // 摘要:
    //     Moves from toward to by the delta value. Use a negative delta value to move away.
    //
    //
    // 参数:
    //   from:
    //     The start value.
    //
    //   to:
    //     The value to move towards.
    //
    //   delta:
    //     The amount to move by.
    //
    // 返回结果:
    //     The value after moving.
    public static double MoveToward(double from, double to, double delta)
    {
        if (Math.Abs(to - from) <= delta)
        {
            return to;
        }

        return from + (double)Math.Sign(to - from) * delta;
    }

    //
    // 摘要:
    //     Returns the nearest larger power of 2 for the integer value.
    //
    // 参数:
    //   value:
    //     The input value.
    //
    // 返回结果:
    //     The nearest larger power of 2.
    public static int NearestPo2(int value)
    {
        value--;
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;
        value++;
        return value;
    }

    //
    // 摘要:
    //     Performs a canonical Modulus operation, where the output is on the range [0,
    //     b).
    //
    // 参数:
    //   a:
    //     The dividend, the primary input.
    //
    //   b:
    //     The divisor. The output is on the range [0, b).
    //
    // 返回结果:
    //     The resulting output.
    public static int PosMod(int a, int b)
    {
        int num = a % b;
        if ((num < 0 && b > 0) || (num > 0 && b < 0))
        {
            num += b;
        }

        return num;
    }

    //
    // 摘要:
    //     Performs a canonical Modulus operation, where the output is on the range [0,
    //     b).
    //
    // 参数:
    //   a:
    //     The dividend, the primary input.
    //
    //   b:
    //     The divisor. The output is on the range [0, b).
    //
    // 返回结果:
    //     The resulting output.
    public static float PosMod(float a, float b)
    {
        float num = a % b;
        if ((num < 0f && b > 0f) || (num > 0f && b < 0f))
        {
            num += b;
        }

        return num;
    }

    //
    // 摘要:
    //     Performs a canonical Modulus operation, where the output is on the range [0,
    //     b).
    //
    // 参数:
    //   a:
    //     The dividend, the primary input.
    //
    //   b:
    //     The divisor. The output is on the range [0, b).
    //
    // 返回结果:
    //     The resulting output.
    public static double PosMod(double a, double b)
    {
        double num = a % b;
        if ((num < 0.0 && b > 0.0) || (num > 0.0 && b < 0.0))
        {
            num += b;
        }

        return num;
    }

    //
    // 摘要:
    //     Returns the result of x raised to the power of y.
    //
    // 参数:
    //   x:
    //     The base.
    //
    //   y:
    //     The exponent.
    //
    // 返回结果:
    //     x raised to the power of y.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Pow(float x, float y)
    {
        return MathF.Pow(x, y);
    }

    //
    // 摘要:
    //     Returns the result of x raised to the power of y.
    //
    // 参数:
    //   x:
    //     The base.
    //
    //   y:
    //     The exponent.
    //
    // 返回结果:
    //     x raised to the power of y.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Pow(double x, double y)
    {
        return Math.Pow(x, y);
    }

    //
    // 摘要:
    //     Converts an angle expressed in radians to degrees.
    //
    // 参数:
    //   rad:
    //     An angle expressed in radians.
    //
    // 返回结果:
    //     The same angle expressed in degrees.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float RadToDeg(float rad)
    {
        return rad * 57.29578f;
    }

    //
    // 摘要:
    //     Converts an angle expressed in radians to degrees.
    //
    // 参数:
    //   rad:
    //     An angle expressed in radians.
    //
    // 返回结果:
    //     The same angle expressed in degrees.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double RadToDeg(double rad)
    {
        return rad * 57.295779513082316;
    }

    //
    // 摘要:
    //     Maps a value from [inFrom, inTo] to [outFrom, outTo].
    //
    // 参数:
    //   value:
    //     The value to map.
    //
    //   inFrom:
    //     The start value for the input interpolation.
    //
    //   inTo:
    //     The destination value for the input interpolation.
    //
    //   outFrom:
    //     The start value for the output interpolation.
    //
    //   outTo:
    //     The destination value for the output interpolation.
    //
    // 返回结果:
    //     The resulting mapped value mapped.
    public static float Remap(float value, float inFrom, float inTo, float outFrom, float outTo)
    {
        return Lerp(outFrom, outTo, InverseLerp(inFrom, inTo, value));
    }

    //
    // 摘要:
    //     Maps a value from [inFrom, inTo] to [outFrom, outTo].
    //
    // 参数:
    //   value:
    //     The value to map.
    //
    //   inFrom:
    //     The start value for the input interpolation.
    //
    //   inTo:
    //     The destination value for the input interpolation.
    //
    //   outFrom:
    //     The start value for the output interpolation.
    //
    //   outTo:
    //     The destination value for the output interpolation.
    //
    // 返回结果:
    //     The resulting mapped value mapped.
    public static double Remap(double value, double inFrom, double inTo, double outFrom, double outTo)
    {
        return Lerp(outFrom, outTo, InverseLerp(inFrom, inTo, value));
    }

    //
    // 摘要:
    //     Rotates from toward to by the delta amount. Will not go past to. Similar to Godot.Mathf.MoveToward(System.Single,System.Single,System.Single)
    //     but interpolates correctly when the angles wrap around Godot.Mathf.Tau. If delta
    //     is negative, this function will rotate away from to, toward the opposite angle,
    //     and will not go past the opposite angle.
    //
    // 参数:
    //   from:
    //     The start angle.
    //
    //   to:
    //     The angle to move towards.
    //
    //   delta:
    //     The amount to move by.
    //
    // 返回结果:
    //     The angle after moving.
    public static float RotateToward(float from, float to, float delta)
    {
        float num = AngleDifference(from, to);
        float num2 = Math.Abs(num);
        return from + Math.Clamp(delta, num2 - MathF.PI, num2) * ((num >= 0f) ? 1f : (-1f));
    }

    //
    // 摘要:
    //     Rotates from toward to by the delta amount. Will not go past to. Similar to Godot.Mathf.MoveToward(System.Double,System.Double,System.Double)
    //     but interpolates correctly when the angles wrap around Godot.Mathf.Tau. If delta
    //     is negative, this function will rotate away from to, toward the opposite angle,
    //     and will not go past the opposite angle.
    //
    // 参数:
    //   from:
    //     The start angle.
    //
    //   to:
    //     The angle to move towards.
    //
    //   delta:
    //     The amount to move by.
    //
    // 返回结果:
    //     The angle after moving.
    public static double RotateToward(double from, double to, double delta)
    {
        double num = AngleDifference(from, to);
        double num2 = Math.Abs(num);
        return from + Math.Clamp(delta, num2 - Math.PI, num2) * ((num >= 0.0) ? 1.0 : (-1.0));
    }

    //
    // 摘要:
    //     Rounds s to the nearest whole number, with halfway cases rounded towards the
    //     nearest multiple of two.
    //
    // 参数:
    //   s:
    //     The number to round.
    //
    // 返回结果:
    //     The rounded number.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Round(float s)
    {
        return MathF.Round(s);
    }

    //
    // 摘要:
    //     Rounds s to the nearest whole number, with halfway cases rounded towards the
    //     nearest multiple of two.
    //
    // 参数:
    //   s:
    //     The number to round.
    //
    // 返回结果:
    //     The rounded number.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Round(double s)
    {
        return Math.Round(s);
    }

    //
    // 摘要:
    //     Returns the sign of s: -1 or 1. Returns 0 if s is 0.
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     One of three possible values: 1, -1, or 0.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(int s)
    {
        return Math.Sign(s);
    }

    //
    // 摘要:
    //     Returns the sign of s: -1 or 1. Returns 0 if s is 0.
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     One of three possible values: 1, -1, or 0.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(float s)
    {
        return Math.Sign(s);
    }

    //
    // 摘要:
    //     Returns the sign of s: -1 or 1. Returns 0 if s is 0.
    //
    // 参数:
    //   s:
    //     The input number.
    //
    // 返回结果:
    //     One of three possible values: 1, -1, or 0.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(double s)
    {
        return Math.Sign(s);
    }

    //
    // 摘要:
    //     Returns the sine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The sine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Sin(float s)
    {
        return MathF.Sin(s);
    }

    //
    // 摘要:
    //     Returns the sine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The sine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Sin(double s)
    {
        return Math.Sin(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic sine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic sine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Sinh(float s)
    {
        return MathF.Sinh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic sine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic sine of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Sinh(double s)
    {
        return Math.Sinh(s);
    }

    //
    // 摘要:
    //     Returns a number smoothly interpolated between from and to, based on the weight.
    //     Similar to Godot.Mathf.Lerp(System.Single,System.Single,System.Single), but interpolates
    //     faster at the beginning and slower at the end.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     A value representing the amount of interpolation.
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static float SmoothStep(float from, float to, float weight)
    {
        if (IsEqualApprox(from, to))
        {
            return from;
        }

        float num = Math.Clamp((weight - from) / (to - from), 0f, 1f);
        return num * num * (3f - 2f * num);
    }

    //
    // 摘要:
    //     Returns a number smoothly interpolated between from and to, based on the weight.
    //     Similar to Godot.Mathf.Lerp(System.Double,System.Double,System.Double), but interpolates
    //     faster at the beginning and slower at the end.
    //
    // 参数:
    //   from:
    //     The start value for interpolation.
    //
    //   to:
    //     The destination value for interpolation.
    //
    //   weight:
    //     A value representing the amount of interpolation.
    //
    // 返回结果:
    //     The resulting value of the interpolation.
    public static double SmoothStep(double from, double to, double weight)
    {
        if (IsEqualApprox(from, to))
        {
            return from;
        }

        double num = Math.Clamp((weight - from) / (to - from), 0.0, 1.0);
        return num * num * (3.0 - 2.0 * num);
    }

    //
    // 摘要:
    //     Returns the square root of s, where s is a non-negative number. If you need negative
    //     inputs, use System.Numerics.Complex.
    //
    // 参数:
    //   s:
    //     The input number. Must not be negative.
    //
    // 返回结果:
    //     The square root of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Sqrt(float s)
    {
        return MathF.Sqrt(s);
    }

    //
    // 摘要:
    //     Returns the square root of s, where s is a non-negative number. If you need negative
    //     inputs, use System.Numerics.Complex.
    //
    // 参数:
    //   s:
    //     The input number. Must not be negative.
    //
    // 返回结果:
    //     The square root of s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Sqrt(double s)
    {
        return Math.Sqrt(s);
    }

    //
    // 摘要:
    //     Returns the position of the first non-zero digit, after the decimal point. Note
    //     that the maximum return value is 10, which is a design decision in the implementation.
    //
    //
    // 参数:
    //   step:
    //     The input value.
    //
    // 返回结果:
    //     The position of the first non-zero digit.
    public static int StepDecimals(double step)
    {
        double[] array = new double[9] { 0.9999, 0.09999, 0.009999, 0.0009999, 9.999E-05, 9.999E-06, 9.999E-07, 9.999E-08, 9.999E-09 };
        double num = Math.Abs(step);
        double num2 = num - (double)(int)num;
        for (int i = 0; i < array.Length; i++)
        {
            if (num2 >= array[i])
            {
                return i;
            }
        }

        return 0;
    }

    //
    // 摘要:
    //     Snaps float value s to a given step. This can also be used to round a floating
    //     point number to an arbitrary number of decimals.
    //
    // 参数:
    //   s:
    //     The value to snap.
    //
    //   step:
    //     The step size to snap to.
    //
    // 返回结果:
    //     The snapped value.
    public static float Snapped(float s, float step)
    {
        if (step != 0f)
        {
            return MathF.Floor(s / step + 0.5f) * step;
        }

        return s;
    }

    //
    // 摘要:
    //     Snaps float value s to a given step. This can also be used to round a floating
    //     point number to an arbitrary number of decimals.
    //
    // 参数:
    //   s:
    //     The value to snap.
    //
    //   step:
    //     The step size to snap to.
    //
    // 返回结果:
    //     The snapped value.
    public static double Snapped(double s, double step)
    {
        if (step != 0.0)
        {
            return Math.Floor(s / step + 0.5) * step;
        }

        return s;
    }

    //
    // 摘要:
    //     Returns the tangent of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The tangent of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Tan(float s)
    {
        return MathF.Tan(s);
    }

    //
    // 摘要:
    //     Returns the tangent of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The tangent of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Tan(double s)
    {
        return Math.Tan(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic tangent of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic tangent of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Tanh(float s)
    {
        return MathF.Tanh(s);
    }

    //
    // 摘要:
    //     Returns the hyperbolic tangent of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The hyperbolic tangent of that angle.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Tanh(double s)
    {
        return Math.Tanh(s);
    }

    //
    // 摘要:
    //     Wraps value between min and max. Usable for creating loop-alike behavior or infinite
    //     surfaces. If min is 0, this is equivalent to Godot.Mathf.PosMod(System.Int32,System.Int32),
    //     so prefer using that instead.
    //
    // 参数:
    //   value:
    //     The value to wrap.
    //
    //   min:
    //     The minimum allowed value and lower bound of the range.
    //
    //   max:
    //     The maximum allowed value and upper bound of the range.
    //
    // 返回结果:
    //     The wrapped value.
    public static int Wrap(int value, int min, int max)
    {
        int num = max - min;
        if (num == 0)
        {
            return min;
        }

        return min + ((value - min) % num + num) % num;
    }

    //
    // 摘要:
    //     Wraps value between min and max. Usable for creating loop-alike behavior or infinite
    //     surfaces. If min is 0, this is equivalent to Godot.Mathf.PosMod(System.Single,System.Single),
    //     so prefer using that instead.
    //
    // 参数:
    //   value:
    //     The value to wrap.
    //
    //   min:
    //     The minimum allowed value and lower bound of the range.
    //
    //   max:
    //     The maximum allowed value and upper bound of the range.
    //
    // 返回结果:
    //     The wrapped value.
    public static float Wrap(float value, float min, float max)
    {
        float num = max - min;
        if (IsZeroApprox(num))
        {
            return min;
        }

        return min + ((value - min) % num + num) % num;
    }

    //
    // 摘要:
    //     Wraps value between min and max. Usable for creating loop-alike behavior or infinite
    //     surfaces. If min is 0, this is equivalent to Godot.Mathf.PosMod(System.Double,System.Double),
    //     so prefer using that instead.
    //
    // 参数:
    //   value:
    //     The value to wrap.
    //
    //   min:
    //     The minimum allowed value and lower bound of the range.
    //
    //   max:
    //     The maximum allowed value and upper bound of the range.
    //
    // 返回结果:
    //     The wrapped value.
    public static double Wrap(double value, double min, double max)
    {
        double num = max - min;
        if (IsZeroApprox(num))
        {
            return min;
        }

        return min + ((value - min) % num + num) % num;
    }

    //
    // 摘要:
    //     Returns the value wrapped between 0 and the length. If the limit is reached,
    //     the next value the function returned is decreased to the 0 side or increased
    //     to the length side (like a triangle wave). If length is less than zero, it becomes
    //     positive.
    //
    // 参数:
    //   value:
    //     The value to pingpong.
    //
    //   length:
    //     The maximum value of the function.
    //
    // 返回结果:
    //     The ping-ponged value.
    public static float PingPong(float value, float length)
    {
        if (length == 0f)
        {
            return 0f;
        }

        return Math.Abs(Fract((value - length) / (length * 2f)) * length * 2f - length);
        static float Fract(float value)
        {
            return value - MathF.Floor(value);
        }
    }

    //
    // 摘要:
    //     Returns the value wrapped between 0 and the length. If the limit is reached,
    //     the next value the function returned is decreased to the 0 side or increased
    //     to the length side (like a triangle wave). If length is less than zero, it becomes
    //     positive.
    //
    // 参数:
    //   value:
    //     The value to pingpong.
    //
    //   length:
    //     The maximum value of the function.
    //
    // 返回结果:
    //     The ping-ponged value.
    public static double PingPong(double value, double length)
    {
        if (length == 0.0)
        {
            return 0.0;
        }

        return Math.Abs(Fract((value - length) / (length * 2.0)) * length * 2.0 - length);
        static double Fract(double value)
        {
            return value - Math.Floor(value);
        }
    }

    //
    // 摘要:
    //     Returns the amount of digits after the decimal place.
    //
    // 参数:
    //   s:
    //     The input value.
    //
    // 返回结果:
    //     The amount of digits.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DecimalCount(double s)
    {
        return DecimalCount((decimal)s);
    }

    //
    // 摘要:
    //     Returns the amount of digits after the decimal place.
    //
    // 参数:
    //   s:
    //     The input decimal value.
    //
    // 返回结果:
    //     The amount of digits.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DecimalCount(decimal s)
    {
        return BitConverter.GetBytes(decimal.GetBits(s)[3])[2];
    }

    //
    // 摘要:
    //     Rounds s upward (towards positive infinity). This is the same as Godot.Mathf.Ceil(System.Single),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to ceil.
    //
    // 返回结果:
    //     The smallest whole number that is not less than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CeilToInt(float s)
    {
        return (int)MathF.Ceiling(s);
    }

    //
    // 摘要:
    //     Rounds s upward (towards positive infinity). This is the same as Godot.Mathf.Ceil(System.Double),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to ceil.
    //
    // 返回结果:
    //     The smallest whole number that is not less than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CeilToInt(double s)
    {
        return (int)Math.Ceiling(s);
    }

    //
    // 摘要:
    //     Rounds s downward (towards negative infinity). This is the same as Godot.Mathf.Floor(System.Single),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to floor.
    //
    // 返回结果:
    //     The largest whole number that is not more than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FloorToInt(float s)
    {
        return (int)MathF.Floor(s);
    }

    //
    // 摘要:
    //     Rounds s downward (towards negative infinity). This is the same as Godot.Mathf.Floor(System.Double),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to floor.
    //
    // 返回结果:
    //     The largest whole number that is not more than s.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FloorToInt(double s)
    {
        return (int)Math.Floor(s);
    }

    //
    // 摘要:
    //     Rounds s to the nearest whole number. This is the same as Godot.Mathf.Round(System.Single),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to round.
    //
    // 返回结果:
    //     The rounded number.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RoundToInt(float s)
    {
        return (int)MathF.Round(s);
    }

    //
    // 摘要:
    //     Rounds s to the nearest whole number. This is the same as Godot.Mathf.Round(System.Double),
    //     but returns an int.
    //
    // 参数:
    //   s:
    //     The number to round.
    //
    // 返回结果:
    //     The rounded number.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RoundToInt(double s)
    {
        return (int)Math.Round(s);
    }

    //
    // 摘要:
    //     Returns the sine and cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The sine and cosine of that angle.
    public static (float Sin, float Cos) SinCos(float s)
    {
        return MathF.SinCos(s);
    }

    //
    // 摘要:
    //     Returns the sine and cosine of angle s in radians.
    //
    // 参数:
    //   s:
    //     The angle in radians.
    //
    // 返回结果:
    //     The sine and cosine of that angle.
    public static (double Sin, double Cos) SinCos(double s)
    {
        return Math.SinCos(s);
    }

    //
    // 摘要:
    //     Returns true if a and b are approximately equal to each other. The comparison
    //     is done using the provided tolerance value. If you want the tolerance to be calculated
    //     for you, use Godot.Mathf.IsEqualApprox(System.Single,System.Single).
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    //   tolerance:
    //     The pre-calculated tolerance value.
    //
    // 返回结果:
    //     A bool for whether or not the two values are equal.
    public static bool IsEqualApprox(float a, float b, float tolerance)
    {
        if (a == b)
        {
            return true;
        }

        return Math.Abs(a - b) < tolerance;
    }

    //
    // 摘要:
    //     Returns true if a and b are approximately equal to each other. The comparison
    //     is done using the provided tolerance value. If you want the tolerance to be calculated
    //     for you, use Godot.Mathf.IsEqualApprox(System.Double,System.Double).
    //
    // 参数:
    //   a:
    //     One of the values.
    //
    //   b:
    //     The other value.
    //
    //   tolerance:
    //     The pre-calculated tolerance value.
    //
    // 返回结果:
    //     A bool for whether or not the two values are equal.
    public static bool IsEqualApprox(double a, double b, double tolerance)
    {
        if (a == b)
        {
            return true;
        }

        return Math.Abs(a - b) < tolerance;
    }
    public const float CompareEpsilon = 0.000001f;

    public static bool CompareApproximate(float f0, float f1, float epsilon = CompareEpsilon)
    {
        return System.Math.Abs(f0 - f1) < epsilon;
    }
    public static bool CompareApproximate(double f0, double f1, float epsilon = CompareEpsilon)
    {
        return System.Math.Abs(f0 - f1) < epsilon;
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
