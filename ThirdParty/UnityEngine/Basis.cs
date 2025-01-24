#region 程序集 GodotSharp, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Administrator\.nuget\packages\godotsharp\4.4.0-beta\lib\net8.0\GodotSharp.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Godot;

//
// 摘要:
//     3×3 matrix used for 3D rotation and scale. Almost always used as an orthogonal
//     basis for a Transform. Contains 3 vector fields X, Y and Z as its columns, which
//     are typically interpreted as the local basis vectors of a 3D transformation.
//     For such use, it is composed of a scaling and a rotation matrix, in that order
//     (M = R.S). Can also be accessed as array of 3D vectors. These vectors are normally
//     orthogonal to each other, but are not necessarily normalized (due to scaling).
//     For more information, read this documentation article: https://docs.godotengine.org/en/latest/tutorials/math/matrices_and_transforms.html
[Serializable]
public struct Basis : IEquatable<Basis>
{
    //
    // 摘要:
    //     Row 0 of the basis matrix. Shows which vectors contribute to the X direction.
    //     Rows are not very useful for user code, but are more efficient for some internal
    //     calculations.
    public Vector3 Row0;

    //
    // 摘要:
    //     Row 1 of the basis matrix. Shows which vectors contribute to the Y direction.
    //     Rows are not very useful for user code, but are more efficient for some internal
    //     calculations.
    public Vector3 Row1;

    //
    // 摘要:
    //     Row 2 of the basis matrix. Shows which vectors contribute to the Z direction.
    //     Rows are not very useful for user code, but are more efficient for some internal
    //     calculations.
    public Vector3 Row2;

    private static readonly Basis[] _orthoBases = new Basis[24]
    {
        new Basis(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f),
        new Basis(0f, -1f, 0f, 1f, 0f, 0f, 0f, 0f, 1f),
        new Basis(-1f, 0f, 0f, 0f, -1f, 0f, 0f, 0f, 1f),
        new Basis(0f, 1f, 0f, -1f, 0f, 0f, 0f, 0f, 1f),
        new Basis(1f, 0f, 0f, 0f, 0f, -1f, 0f, 1f, 0f),
        new Basis(0f, 0f, 1f, 1f, 0f, 0f, 0f, 1f, 0f),
        new Basis(-1f, 0f, 0f, 0f, 0f, 1f, 0f, 1f, 0f),
        new Basis(0f, 0f, -1f, -1f, 0f, 0f, 0f, 1f, 0f),
        new Basis(1f, 0f, 0f, 0f, -1f, 0f, 0f, 0f, -1f),
        new Basis(0f, 1f, 0f, 1f, 0f, 0f, 0f, 0f, -1f),
        new Basis(-1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, -1f),
        new Basis(0f, -1f, 0f, -1f, 0f, 0f, 0f, 0f, -1f),
        new Basis(1f, 0f, 0f, 0f, 0f, 1f, 0f, -1f, 0f),
        new Basis(0f, 0f, -1f, 1f, 0f, 0f, 0f, -1f, 0f),
        new Basis(-1f, 0f, 0f, 0f, 0f, -1f, 0f, -1f, 0f),
        new Basis(0f, 0f, 1f, -1f, 0f, 0f, 0f, -1f, 0f),
        new Basis(0f, 0f, 1f, 0f, 1f, 0f, -1f, 0f, 0f),
        new Basis(0f, -1f, 0f, 0f, 0f, 1f, -1f, 0f, 0f),
        new Basis(0f, 0f, -1f, 0f, -1f, 0f, -1f, 0f, 0f),
        new Basis(0f, 1f, 0f, 0f, 0f, -1f, -1f, 0f, 0f),
        new Basis(0f, 0f, 1f, 0f, -1f, 0f, 1f, 0f, 0f),
        new Basis(0f, 1f, 0f, 0f, 0f, 1f, 1f, 0f, 0f),
        new Basis(0f, 0f, -1f, 0f, 1f, 0f, 1f, 0f, 0f),
        new Basis(0f, -1f, 0f, 0f, 0f, -1f, 1f, 0f, 0f)
    };

    private static readonly Basis _identity = new Basis(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

    private static readonly Basis _flipX = new Basis(-1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

    private static readonly Basis _flipY = new Basis(1f, 0f, 0f, 0f, -1f, 0f, 0f, 0f, 1f);

    private static readonly Basis _flipZ = new Basis(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, -1f);

    //
    // 摘要:
    //     The basis matrix's X vector (column 0).
    //
    // 值:
    //     Equivalent to Godot.Basis.Column0 and array index [0].
    public Vector3 X
    {
        readonly get
        {
            return Column0;
        }
        set
        {
            Column0 = value;
        }
    }

    //
    // 摘要:
    //     The basis matrix's Y vector (column 1).
    //
    // 值:
    //     Equivalent to Godot.Basis.Column1 and array index [1].
    public Vector3 Y
    {
        readonly get
        {
            return Column1;
        }
        set
        {
            Column1 = value;
        }
    }

    //
    // 摘要:
    //     The basis matrix's Z vector (column 2).
    //
    // 值:
    //     Equivalent to Godot.Basis.Column2 and array index [2].
    public Vector3 Z
    {
        readonly get
        {
            return Column2;
        }
        set
        {
            Column2 = value;
        }
    }

    //
    // 摘要:
    //     Column 0 of the basis matrix (the X vector).
    //
    // 值:
    //     Equivalent to Godot.Basis.X and array index [0].
    public Vector3 Column0
    {
        readonly get
        {
            return new Vector3(Row0.X, Row1.X, Row2.X);
        }
        set
        {
            Row0.X = value.X;
            Row1.X = value.Y;
            Row2.X = value.Z;
        }
    }

    //
    // 摘要:
    //     Column 1 of the basis matrix (the Y vector).
    //
    // 值:
    //     Equivalent to Godot.Basis.Y and array index [1].
    public Vector3 Column1
    {
        readonly get
        {
            return new Vector3(Row0.Y, Row1.Y, Row2.Y);
        }
        set
        {
            Row0.Y = value.X;
            Row1.Y = value.Y;
            Row2.Y = value.Z;
        }
    }

    //
    // 摘要:
    //     Column 2 of the basis matrix (the Z vector).
    //
    // 值:
    //     Equivalent to Godot.Basis.Z and array index [2].
    public Vector3 Column2
    {
        readonly get
        {
            return new Vector3(Row0.Z, Row1.Z, Row2.Z);
        }
        set
        {
            Row0.Z = value.X;
            Row1.Z = value.Y;
            Row2.Z = value.Z;
        }
    }

    //
    // 摘要:
    //     Assuming that the matrix is the combination of a rotation and scaling, return
    //     the absolute value of scaling factors along each axis.
    public readonly Vector3 Scale => Mathf.Sign(Determinant()) * new Vector3(Column0.Length(), Column1.Length(), Column2.Length());

    //
    // 摘要:
    //     Access whole columns in the form of Godot.Vector3.
    //
    // 参数:
    //   column:
    //     Which column vector.
    //
    // 值:
    //     The basis column.
    //
    // 异常:
    //   T:System.ArgumentOutOfRangeException:
    //     column is not 0, 1, 2 or 3.
    public Vector3 this[int column]
    {
        readonly get
        {
            return column switch
            {
                0 => Column0,
                1 => Column1,
                2 => Column2,
                _ => throw new ArgumentOutOfRangeException("column"),
            };
        }
        set
        {
            switch (column)
            {
                case 0:
                    Column0 = value;
                    break;
                case 1:
                    Column1 = value;
                    break;
                case 2:
                    Column2 = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("column");
            }
        }
    }

    //
    // 摘要:
    //     Access matrix elements in column-major order.
    //
    // 参数:
    //   column:
    //     Which column, the matrix horizontal position.
    //
    //   row:
    //     Which row, the matrix vertical position.
    //
    // 值:
    //     The matrix element.
    public float this[int column, int row]
    {
        readonly get
        {
            return this[column][row];
        }
        set
        {
            Vector3 value2 = this[column];
            value2[row] = value;
            this[column] = value2;
        }
    }

    //
    // 摘要:
    //     The identity basis, with no rotation or scaling applied. This is used as a replacement
    //     for Basis() in GDScript. Do not use new Basis() with no arguments in C#, because
    //     it sets all values to zero.
    //
    // 值:
    //     Equivalent to new Basis(Vector3.Right, Vector3.Up, Vector3.Back).
    public static Basis Identity => _identity;

    //
    // 摘要:
    //     The basis that will flip something along the X axis when used in a transformation.
    //
    //
    // 值:
    //     Equivalent to new Basis(Vector3.Left, Vector3.Up, Vector3.Back).
    public static Basis FlipX => _flipX;

    //
    // 摘要:
    //     The basis that will flip something along the Y axis when used in a transformation.
    //
    //
    // 值:
    //     Equivalent to new Basis(Vector3.Right, Vector3.Down, Vector3.Back).
    public static Basis FlipY => _flipY;

    //
    // 摘要:
    //     The basis that will flip something along the Z axis when used in a transformation.
    //
    //
    // 值:
    //     Equivalent to new Basis(Vector3.Right, Vector3.Up, Vector3.Forward).
    public static Basis FlipZ => _flipZ;

    internal void SetQuaternionScale(Quaternion quaternion, Vector3 scale)
    {
        SetDiagonal(scale);
        Rotate(quaternion);
    }

    private void Rotate(Quaternion quaternion)
    {
        this = new Basis(quaternion) * this;
    }

    private void SetDiagonal(Vector3 diagonal)
    {
        Row0 = new Vector3(diagonal.X, 0f, 0f);
        Row1 = new Vector3(0f, diagonal.Y, 0f);
        Row2 = new Vector3(0f, 0f, diagonal.Z);
    }

    //
    // 摘要:
    //     Returns the determinant of the basis matrix. If the basis is uniformly scaled,
    //     its determinant is the square of the scale. A negative determinant means the
    //     basis has a negative scale. A zero determinant means the basis isn't invertible,
    //     and is usually considered invalid.
    //
    // 返回结果:
    //     The determinant of the basis matrix.
    public readonly float Determinant()
    {
        float num = Row1[1] * Row2[2] - Row1[2] * Row2[1];
        float num2 = Row1[2] * Row2[0] - Row1[0] * Row2[2];
        float num3 = Row1[0] * Row2[1] - Row1[1] * Row2[0];
        return Row0[0] * num + Row0[1] * num2 + Row0[2] * num3;
    }

    //
    // 摘要:
    //     Returns the basis's rotation in the form of Euler angles. The Euler order depends
    //     on the order parameter, by default it uses the YXZ convention: when decomposing,
    //     first Z, then X, and Y last. The returned vector contains the rotation angles
    //     in the format (X angle, Y angle, Z angle). Consider using the Godot.Basis.GetRotationQuaternion
    //     method instead, which returns a Godot.Quaternion quaternion instead of Euler
    //     angles.
    //
    // 参数:
    //   order:
    //     The Euler order to use. By default, use YXZ order (most common).
    //
    // 返回结果:
    //     A Godot.Vector3 representing the basis rotation in Euler angles.
    public readonly Vector3 GetEuler(EulerOrder order = EulerOrder.Yxz)
    {
        if ((ulong)order <= 5uL)
        {
            switch (order)
            {
                case EulerOrder.Xyz:
                    {
                        float num5 = Row0[2];
                        Vector3 result5 = default(Vector3);
                        if (num5 < 0.999999f)
                        {
                            if (num5 > -0.999999f)
                            {
                                if (Row1[0] == 0f && Row0[1] == 0f && Row1[2] == 0f && Row2[1] == 0f && Row1[1] == 1f)
                                {
                                    result5.X = 0f;
                                    result5.Y = Mathf.Atan2(Row0[2], Row0[0]);
                                    result5.Z = 0f;
                                }
                                else
                                {
                                    result5.X = Mathf.Atan2(0f - Row1[2], Row2[2]);
                                    result5.Y = Mathf.Asin(num5);
                                    result5.Z = Mathf.Atan2(0f - Row0[1], Row0[0]);
                                }
                            }
                            else
                            {
                                result5.X = Mathf.Atan2(Row2[1], Row1[1]);
                                result5.Y = -MathF.PI / 2f;
                                result5.Z = 0f;
                            }
                        }
                        else
                        {
                            result5.X = Mathf.Atan2(Row2[1], Row1[1]);
                            result5.Y = MathF.PI / 2f;
                            result5.Z = 0f;
                        }

                        return result5;
                    }
                case EulerOrder.Xzy:
                    {
                        float num3 = Row0[1];
                        Vector3 result3 = default(Vector3);
                        if (num3 < 0.999999f)
                        {
                            if (num3 > -0.999999f)
                            {
                                result3.X = Mathf.Atan2(Row2[1], Row1[1]);
                                result3.Y = Mathf.Atan2(Row0[2], Row0[0]);
                                result3.Z = Mathf.Asin(0f - num3);
                            }
                            else
                            {
                                result3.X = 0f - Mathf.Atan2(Row1[2], Row2[2]);
                                result3.Y = 0f;
                                result3.Z = MathF.PI / 2f;
                            }
                        }
                        else
                        {
                            result3.X = 0f - Mathf.Atan2(Row1[2], Row2[2]);
                            result3.Y = 0f;
                            result3.Z = -MathF.PI / 2f;
                        }

                        return result3;
                    }
                case EulerOrder.Yxz:
                    {
                        float num4 = Row1[2];
                        Vector3 result4 = default(Vector3);
                        if (num4 < 0.999999f)
                        {
                            if (num4 > -0.999999f)
                            {
                                if (Row1[0] == 0f && Row0[1] == 0f && Row0[2] == 0f && Row2[0] == 0f && Row0[0] == 1f)
                                {
                                    result4.X = Mathf.Atan2(0f - num4, Row1[1]);
                                    result4.Y = 0f;
                                    result4.Z = 0f;
                                }
                                else
                                {
                                    result4.X = Mathf.Asin(0f - num4);
                                    result4.Y = Mathf.Atan2(Row0[2], Row2[2]);
                                    result4.Z = Mathf.Atan2(Row1[0], Row1[1]);
                                }
                            }
                            else
                            {
                                result4.X = MathF.PI / 2f;
                                result4.Y = Mathf.Atan2(Row0[1], Row0[0]);
                                result4.Z = 0f;
                            }
                        }
                        else
                        {
                            result4.X = -MathF.PI / 2f;
                            result4.Y = 0f - Mathf.Atan2(Row0[1], Row0[0]);
                            result4.Z = 0f;
                        }

                        return result4;
                    }
                case EulerOrder.Yzx:
                    {
                        float num2 = Row1[0];
                        Vector3 result2 = default(Vector3);
                        if (num2 < 0.999999f)
                        {
                            if (num2 > -0.999999f)
                            {
                                result2.X = Mathf.Atan2(0f - Row1[2], Row1[1]);
                                result2.Y = Mathf.Atan2(0f - Row2[0], Row0[0]);
                                result2.Z = Mathf.Asin(num2);
                            }
                            else
                            {
                                result2.X = Mathf.Atan2(Row2[1], Row2[2]);
                                result2.Y = 0f;
                                result2.Z = -MathF.PI / 2f;
                            }
                        }
                        else
                        {
                            result2.X = Mathf.Atan2(Row2[1], Row2[2]);
                            result2.Y = 0f;
                            result2.Z = MathF.PI / 2f;
                        }

                        return result2;
                    }
                case EulerOrder.Zxy:
                    {
                        float num6 = Row2[1];
                        Vector3 result6 = default(Vector3);
                        if (num6 < 0.999999f)
                        {
                            if (num6 > -0.999999f)
                            {
                                result6.X = Mathf.Asin(num6);
                                result6.Y = Mathf.Atan2(0f - Row2[0], Row2[2]);
                                result6.Z = Mathf.Atan2(0f - Row0[1], Row1[1]);
                            }
                            else
                            {
                                result6.X = -MathF.PI / 2f;
                                result6.Y = Mathf.Atan2(Row0[2], Row0[0]);
                                result6.Z = 0f;
                            }
                        }
                        else
                        {
                            result6.X = MathF.PI / 2f;
                            result6.Y = Mathf.Atan2(Row0[2], Row0[0]);
                            result6.Z = 0f;
                        }

                        return result6;
                    }
                case EulerOrder.Zyx:
                    {
                        float num = Row2[0];
                        Vector3 result = default(Vector3);
                        if (num < 0.999999f)
                        {
                            if (num > -0.999999f)
                            {
                                result.X = Mathf.Atan2(Row2[1], Row2[2]);
                                result.Y = Mathf.Asin(0f - num);
                                result.Z = Mathf.Atan2(Row1[0], Row0[0]);
                            }
                            else
                            {
                                result.X = 0f;
                                result.Y = MathF.PI / 2f;
                                result.Z = 0f - Mathf.Atan2(Row0[1], Row1[1]);
                            }
                        }
                        else
                        {
                            result.X = 0f;
                            result.Y = -MathF.PI / 2f;
                            result.Z = 0f - Mathf.Atan2(Row0[1], Row1[1]);
                        }

                        return result;
                    }
            }
        }

        throw new ArgumentOutOfRangeException("order");
    }

    internal readonly Quaternion GetQuaternion()
    {
        float num = Row0[0] + Row1[1] + Row2[2];
        if (num > 0f)
        {
            float num2 = Mathf.Sqrt(num + 1f) * 2f;
            float num3 = 1f / num2;
            return new Quaternion((Row2[1] - Row1[2]) * num3, (Row0[2] - Row2[0]) * num3, (Row1[0] - Row0[1]) * num3, num2 * 0.25f);
        }

        if (Row0[0] > Row1[1] && Row0[0] > Row2[2])
        {
            float num4 = Mathf.Sqrt(Row0[0] - Row1[1] - Row2[2] + 1f) * 2f;
            float num5 = 1f / num4;
            return new Quaternion(num4 * 0.25f, (Row0[1] + Row1[0]) * num5, (Row0[2] + Row2[0]) * num5, (Row2[1] - Row1[2]) * num5);
        }

        if (Row1[1] > Row2[2])
        {
            float num6 = Mathf.Sqrt(0f - Row0[0] + Row1[1] - Row2[2] + 1f) * 2f;
            float num7 = 1f / num6;
            return new Quaternion((Row0[1] + Row1[0]) * num7, num6 * 0.25f, (Row1[2] + Row2[1]) * num7, (Row0[2] - Row2[0]) * num7);
        }

        float num8 = Mathf.Sqrt(0f - Row0[0] - Row1[1] + Row2[2] + 1f) * 2f;
        float num9 = 1f / num8;
        return new Quaternion((Row0[2] + Row2[0]) * num9, (Row1[2] + Row2[1]) * num9, num8 * 0.25f, (Row1[0] - Row0[1]) * num9);
    }

    //
    // 摘要:
    //     Returns the Godot.Basis's rotation in the form of a Godot.Quaternion. See Godot.Basis.GetEuler(Godot.EulerOrder)
    //     if you need Euler angles, but keep in mind quaternions should generally be preferred
    //     to Euler angles.
    //
    // 返回结果:
    //     The basis rotation.
    public readonly Quaternion GetRotationQuaternion()
    {
        Basis basis = Orthonormalized();
        if (basis.Determinant() < 0f)
        {
            basis = basis.Scaled(-Vector3.One);
        }

        return basis.GetQuaternion();
    }

    //
    // 摘要:
    //     Returns the inverse of the matrix.
    //
    // 返回结果:
    //     The inverse matrix.
    public readonly Basis Inverse()
    {
        float num = Row1[1] * Row2[2] - Row1[2] * Row2[1];
        float num2 = Row1[2] * Row2[0] - Row1[0] * Row2[2];
        float num3 = Row1[0] * Row2[1] - Row1[1] * Row2[0];
        float num4 = Row0[0] * num + Row0[1] * num2 + Row0[2] * num3;
        if (num4 == 0f)
        {
            throw new InvalidOperationException("Matrix determinant is zero and cannot be inverted.");
        }

        float num5 = 1f / num4;
        float num6 = Row0[2] * Row2[1] - Row0[1] * Row2[2];
        float num7 = Row0[1] * Row1[2] - Row0[2] * Row1[1];
        float num8 = Row0[0] * Row2[2] - Row0[2] * Row2[0];
        float num9 = Row0[2] * Row1[0] - Row0[0] * Row1[2];
        float num10 = Row0[1] * Row2[0] - Row0[0] * Row2[1];
        float num11 = Row0[0] * Row1[1] - Row0[1] * Row1[0];
        return new Basis(num * num5, num6 * num5, num7 * num5, num2 * num5, num8 * num5, num9 * num5, num3 * num5, num10 * num5, num11 * num5);
    }

    //
    // 摘要:
    //     Returns true if this basis is finite, by calling Godot.Mathf.IsFinite(System.Single)
    //     on each component.
    //
    // 返回结果:
    //     Whether this vector is finite or not.
    public readonly bool IsFinite()
    {
        if (Row0.IsFinite() && Row1.IsFinite())
        {
            return Row2.IsFinite();
        }

        return false;
    }

    internal readonly Basis Lerp(Basis to, float weight)
    {
        Basis result = this;
        result.Row0 = Row0.Lerp(to.Row0, weight);
        result.Row1 = Row1.Lerp(to.Row1, weight);
        result.Row2 = Row2.Lerp(to.Row2, weight);
        return result;
    }

    //
    // 摘要:
    //     Creates a Godot.Basis with a rotation such that the forward axis (-Z) points
    //     towards the target position. The up axis (+Y) points as close to the up vector
    //     as possible while staying perpendicular to the forward axis. The resulting Basis
    //     is orthonormalized. The target and up vectors cannot be zero, and cannot be parallel
    //     to each other.
    //
    // 参数:
    //   target:
    //     The position to look at.
    //
    //   up:
    //     The relative up direction.
    //
    //   useModelFront:
    //     If true, then the model is oriented in reverse, towards the model front axis
    //     (+Z, Vector3.ModelFront), which is more useful for orienting 3D models.
    //
    // 返回结果:
    //     The resulting basis matrix.
    public static Basis LookingAt(Vector3 target, Vector3? up = null, bool useModelFront = false)
    {
        Vector3 valueOrDefault = up.GetValueOrDefault();
        if (!up.HasValue)
        {
            valueOrDefault = Vector3.Up;
            up = valueOrDefault;
        }

        Vector3 vector = target.Normalized();
        if (!useModelFront)
        {
            vector = -vector;
        }

        Vector3 vector2 = up.Value.Cross(vector);
        vector2.Normalize();
        Vector3 column = vector.Cross(vector2);
        return new Basis(vector2, column, vector);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Basis LookingAt(Vector3 target, Vector3 up)
    {
        return LookingAt(target, up, useModelFront: false);
    }

    //
    // 摘要:
    //     Returns the orthonormalized version of the basis matrix (useful to call occasionally
    //     to avoid rounding errors for orthogonal matrices). This performs a Gram-Schmidt
    //     orthonormalization on the basis of the matrix.
    //
    // 返回结果:
    //     An orthonormalized basis matrix.
    public readonly Basis Orthonormalized()
    {
        Vector3 vector = this[0];
        Vector3 vector2 = this[1];
        Vector3 vector3 = this[2];
        vector.Normalize();
        vector2 -= vector * vector.Dot(vector2);
        vector2.Normalize();
        vector3 = vector3 - vector * vector.Dot(vector3) - vector2 * vector2.Dot(vector3);
        vector3.Normalize();
        return new Basis(vector, vector2, vector3);
    }

    //
    // 摘要:
    //     Introduce an additional rotation around the given axis by angle (in radians).
    //     The axis must be a normalized vector.
    //
    // 参数:
    //   axis:
    //     The axis to rotate around. Must be normalized.
    //
    //   angle:
    //     The angle to rotate, in radians.
    //
    // 返回结果:
    //     The rotated basis matrix.
    public readonly Basis Rotated(Vector3 axis, float angle)
    {
        return new Basis(axis, angle) * this;
    }

    //
    // 摘要:
    //     Introduce an additional scaling specified by the given 3D scaling factor.
    //
    // 参数:
    //   scale:
    //     The scale to introduce.
    //
    // 返回结果:
    //     The scaled basis matrix.
    public readonly Basis Scaled(Vector3 scale)
    {
        Basis result = this;
        result.Row0 *= scale.X;
        result.Row1 *= scale.Y;
        result.Row2 *= scale.Z;
        return result;
    }

    //
    // 摘要:
    //     Assuming that the matrix is a proper rotation matrix, slerp performs a spherical-linear
    //     interpolation with another rotation matrix.
    //
    // 参数:
    //   target:
    //     The destination basis for interpolation.
    //
    //   weight:
    //     A value on the range of 0.0 to 1.0, representing the amount of interpolation.
    //
    //
    // 返回结果:
    //     The resulting basis matrix of the interpolation.
    public readonly Basis Slerp(Basis target, float weight)
    {
        Quaternion quaternion = new Quaternion(this);
        Quaternion to = new Quaternion(target);
        Basis result = new Basis(quaternion.Slerp(to, weight));
        result.Row0 *= Mathf.Lerp(Row0.Length(), target.Row0.Length(), weight);
        result.Row1 *= Mathf.Lerp(Row1.Length(), target.Row1.Length(), weight);
        result.Row2 *= Mathf.Lerp(Row2.Length(), target.Row2.Length(), weight);
        return result;
    }

    //
    // 摘要:
    //     Transposed dot product with the X axis of the matrix.
    //
    // 参数:
    //   with:
    //     A vector to calculate the dot product with.
    //
    // 返回结果:
    //     The resulting dot product.
    public readonly float Tdotx(Vector3 with)
    {
        return Row0[0] * with[0] + Row1[0] * with[1] + Row2[0] * with[2];
    }

    //
    // 摘要:
    //     Transposed dot product with the Y axis of the matrix.
    //
    // 参数:
    //   with:
    //     A vector to calculate the dot product with.
    //
    // 返回结果:
    //     The resulting dot product.
    public readonly float Tdoty(Vector3 with)
    {
        return Row0[1] * with[0] + Row1[1] * with[1] + Row2[1] * with[2];
    }

    //
    // 摘要:
    //     Transposed dot product with the Z axis of the matrix.
    //
    // 参数:
    //   with:
    //     A vector to calculate the dot product with.
    //
    // 返回结果:
    //     The resulting dot product.
    public readonly float Tdotz(Vector3 with)
    {
        return Row0[2] * with[0] + Row1[2] * with[1] + Row2[2] * with[2];
    }

    //
    // 摘要:
    //     Returns the transposed version of the basis matrix.
    //
    // 返回结果:
    //     The transposed basis matrix.
    public readonly Basis Transposed()
    {
        Basis result = this;
        result.Row0[1] = Row1[0];
        result.Row1[0] = Row0[1];
        result.Row0[2] = Row2[0];
        result.Row2[0] = Row0[2];
        result.Row1[2] = Row2[1];
        result.Row2[1] = Row1[2];
        return result;
    }

    //
    // 摘要:
    //     Constructs a pure rotation basis matrix from the given quaternion.
    //
    // 参数:
    //   quaternion:
    //     The quaternion to create the basis from.
    public Basis(Quaternion quaternion)
    {
        float num = 2f / quaternion.LengthSquared();
        float num2 = quaternion.X * num;
        float num3 = quaternion.Y * num;
        float num4 = quaternion.Z * num;
        float num5 = quaternion.W * num2;
        float num6 = quaternion.W * num3;
        float num7 = quaternion.W * num4;
        float num8 = quaternion.X * num2;
        float num9 = quaternion.X * num3;
        float num10 = quaternion.X * num4;
        float num11 = quaternion.Y * num3;
        float num12 = quaternion.Y * num4;
        float num13 = quaternion.Z * num4;
        Row0 = new Vector3(1f - (num11 + num13), num9 - num7, num10 + num6);
        Row1 = new Vector3(num9 + num7, 1f - (num8 + num13), num12 - num5);
        Row2 = new Vector3(num10 - num6, num12 + num5, 1f - (num8 + num11));
    }

    //
    // 摘要:
    //     Constructs a pure rotation basis matrix, rotated around the given axis by angle
    //     (in radians). The axis must be a normalized vector.
    //
    // 参数:
    //   axis:
    //     The axis to rotate around. Must be normalized.
    //
    //   angle:
    //     The angle to rotate, in radians.
    public Basis(Vector3 axis, float angle)
    {
        Vector3 vector = new Vector3(axis.X * axis.X, axis.Y * axis.Y, axis.Z * axis.Z);
        (float Sin, float Cos) tuple = Mathf.SinCos(angle);
        float item = tuple.Sin;
        float item2 = tuple.Cos;
        Row0.X = vector.X + item2 * (1f - vector.X);
        Row1.Y = vector.Y + item2 * (1f - vector.Y);
        Row2.Z = vector.Z + item2 * (1f - vector.Z);
        float num = 1f - item2;
        float num2 = axis.X * axis.Y * num;
        float num3 = axis.Z * item;
        Row0.Y = num2 - num3;
        Row1.X = num2 + num3;
        num2 = axis.X * axis.Z * num;
        num3 = axis.Y * item;
        Row0.Z = num2 + num3;
        Row2.X = num2 - num3;
        num2 = axis.Y * axis.Z * num;
        num3 = axis.X * item;
        Row1.Z = num2 - num3;
        Row2.Y = num2 + num3;
    }

    //
    // 摘要:
    //     Constructs a basis matrix from 3 axis vectors (matrix columns).
    //
    // 参数:
    //   column0:
    //     The X vector, or Column0.
    //
    //   column1:
    //     The Y vector, or Column1.
    //
    //   column2:
    //     The Z vector, or Column2.
    public Basis(Vector3 column0, Vector3 column1, Vector3 column2)
    {
        Row0 = new Vector3(column0.X, column1.X, column2.X);
        Row1 = new Vector3(column0.Y, column1.Y, column2.Y);
        Row2 = new Vector3(column0.Z, column1.Z, column2.Z);
    }

    //
    // 摘要:
    //     Constructs a transformation matrix from the given components. Arguments are named
    //     such that xy is equal to calling X.Y.
    //
    // 参数:
    //   xx:
    //     The X component of the X column vector, accessed via b.X.X or [0][0].
    //
    //   yx:
    //     The X component of the Y column vector, accessed via b.Y.X or [1][0].
    //
    //   zx:
    //     The X component of the Z column vector, accessed via b.Z.X or [2][0].
    //
    //   xy:
    //     The Y component of the X column vector, accessed via b.X.Y or [0][1].
    //
    //   yy:
    //     The Y component of the Y column vector, accessed via b.Y.Y or [1][1].
    //
    //   zy:
    //     The Y component of the Z column vector, accessed via b.Y.Y or [2][1].
    //
    //   xz:
    //     The Z component of the X column vector, accessed via b.X.Y or [0][2].
    //
    //   yz:
    //     The Z component of the Y column vector, accessed via b.Y.Y or [1][2].
    //
    //   zz:
    //     The Z component of the Z column vector, accessed via b.Y.Y or [2][2].
    public Basis(float xx, float yx, float zx, float xy, float yy, float zy, float xz, float yz, float zz)
    {
        Row0 = new Vector3(xx, yx, zx);
        Row1 = new Vector3(xy, yy, zy);
        Row2 = new Vector3(xz, yz, zz);
    }

    //
    // 摘要:
    //     Constructs a Basis matrix from Euler angles in the specified rotation order.
    //     By default, use YXZ order (most common).
    //
    // 参数:
    //   euler:
    //     The Euler angles to use.
    //
    //   order:
    //     The order to compose the Euler angles.
    public static Basis FromEuler(Vector3 euler, EulerOrder order = EulerOrder.Yxz)
    {
        (float Sin, float Cos) tuple = Mathf.SinCos(euler.X);
        float item = tuple.Sin;
        float item2 = tuple.Cos;
        Basis basis = new Basis(new Vector3(1f, 0f, 0f), new Vector3(0f, item2, item), new Vector3(0f, 0f - item, item2));
        (float Sin, float Cos) tuple2 = Mathf.SinCos(euler.Y);
        item = tuple2.Sin;
        item2 = tuple2.Cos;
        Basis basis2 = new Basis(new Vector3(item2, 0f, 0f - item), new Vector3(0f, 1f, 0f), new Vector3(item, 0f, item2));
        (float Sin, float Cos) tuple3 = Mathf.SinCos(euler.Z);
        item = tuple3.Sin;
        item2 = tuple3.Cos;
        Basis basis3 = new Basis(new Vector3(item2, item, 0f), new Vector3(0f - item, item2, 0f), new Vector3(0f, 0f, 1f));
        if ((ulong)order <= 5uL)
        {
            switch (order)
            {
                case EulerOrder.Xyz:
                    return basis * basis2 * basis3;
                case EulerOrder.Xzy:
                    return basis * basis3 * basis2;
                case EulerOrder.Yxz:
                    return basis2 * basis * basis3;
                case EulerOrder.Yzx:
                    return basis2 * basis3 * basis;
                case EulerOrder.Zxy:
                    return basis3 * basis * basis2;
                case EulerOrder.Zyx:
                    return basis3 * basis2 * basis;
            }
        }

        throw new ArgumentOutOfRangeException("order");
    }

    //
    // 摘要:
    //     Constructs a pure scale basis matrix with no rotation or shearing. The scale
    //     values are set as the main diagonal of the matrix, and all of the other parts
    //     of the matrix are zero.
    //
    // 参数:
    //   scale:
    //     The scale Vector3.
    //
    // 返回结果:
    //     A pure scale Basis matrix.
    public static Basis FromScale(Vector3 scale)
    {
        return new Basis(scale.X, 0f, 0f, 0f, scale.Y, 0f, 0f, 0f, scale.Z);
    }

    //
    // 摘要:
    //     Composes these two basis matrices by multiplying them together. This has the
    //     effect of transforming the second basis (the child) by the first basis (the parent).
    //
    //
    // 参数:
    //   left:
    //     The parent basis.
    //
    //   right:
    //     The child basis.
    //
    // 返回结果:
    //     The composed basis.
    public static Basis operator *(Basis left, Basis right)
    {
        return new Basis(right.Tdotx(left.Row0), right.Tdoty(left.Row0), right.Tdotz(left.Row0), right.Tdotx(left.Row1), right.Tdoty(left.Row1), right.Tdotz(left.Row1), right.Tdotx(left.Row2), right.Tdoty(left.Row2), right.Tdotz(left.Row2));
    }

    //
    // 摘要:
    //     Returns a Vector3 transformed (multiplied) by the basis matrix.
    //
    // 参数:
    //   basis:
    //     The basis matrix transformation to apply.
    //
    //   vector:
    //     A Vector3 to transform.
    //
    // 返回结果:
    //     The transformed Vector3.
    public static Vector3 operator *(Basis basis, Vector3 vector)
    {
        return new Vector3(basis.Row0.Dot(vector), basis.Row1.Dot(vector), basis.Row2.Dot(vector));
    }

    //
    // 摘要:
    //     Returns a Vector3 transformed (multiplied) by the inverse basis matrix, under
    //     the assumption that the transformation basis is orthonormal (i.e. rotation/reflection
    //     is fine, scaling/skew is not). vector * basis is equivalent to basis.Transposed()
    //     * vector. See Godot.Basis.Transposed. For transforming by inverse of a non-orthonormal
    //     basis (e.g. with scaling) basis.Inverse() * vector can be used instead. See Godot.Basis.Inverse.
    //
    //
    // 参数:
    //   vector:
    //     A Vector3 to inversely transform.
    //
    //   basis:
    //     The basis matrix transformation to apply.
    //
    // 返回结果:
    //     The inversely transformed vector.
    public static Vector3 operator *(Vector3 vector, Basis basis)
    {
        return new Vector3(basis.Row0[0] * vector.X + basis.Row1[0] * vector.Y + basis.Row2[0] * vector.Z, basis.Row0[1] * vector.X + basis.Row1[1] * vector.Y + basis.Row2[1] * vector.Z, basis.Row0[2] * vector.X + basis.Row1[2] * vector.Y + basis.Row2[2] * vector.Z);
    }

    //
    // 摘要:
    //     Returns true if the basis matrices are exactly equal. Note: Due to floating-point
    //     precision errors, consider using Godot.Basis.IsEqualApprox(Godot.Basis) instead,
    //     which is more reliable.
    //
    // 参数:
    //   left:
    //     The left basis.
    //
    //   right:
    //     The right basis.
    //
    // 返回结果:
    //     Whether or not the basis matrices are exactly equal.
    public static bool operator ==(Basis left, Basis right)
    {
        return left.Equals(right);
    }

    //
    // 摘要:
    //     Returns true if the basis matrices are not equal. Note: Due to floating-point
    //     precision errors, consider using Godot.Basis.IsEqualApprox(Godot.Basis) instead,
    //     which is more reliable.
    //
    // 参数:
    //   left:
    //     The left basis.
    //
    //   right:
    //     The right basis.
    //
    // 返回结果:
    //     Whether or not the basis matrices are not equal.
    public static bool operator !=(Basis left, Basis right)
    {
        return !left.Equals(right);
    }

    //
    // 摘要:
    //     Returns true if the Godot.Basis is exactly equal to the given object (obj). Note:
    //     Due to floating-point precision errors, consider using Godot.Basis.IsEqualApprox(Godot.Basis)
    //     instead, which is more reliable.
    //
    // 参数:
    //   obj:
    //     The object to compare with.
    //
    // 返回结果:
    //     Whether or not the basis matrix and the object are exactly equal.
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is Basis other)
        {
            return Equals(other);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if the basis matrices are exactly equal. Note: Due to floating-point
    //     precision errors, consider using Godot.Basis.IsEqualApprox(Godot.Basis) instead,
    //     which is more reliable.
    //
    // 参数:
    //   other:
    //     The other basis.
    //
    // 返回结果:
    //     Whether or not the basis matrices are exactly equal.
    public readonly bool Equals(Basis other)
    {
        if (Row0.Equals(other.Row0) && Row1.Equals(other.Row1))
        {
            return Row2.Equals(other.Row2);
        }

        return false;
    }

    //
    // 摘要:
    //     Returns true if this basis and other are approximately equal, by running Godot.Vector3.IsEqualApprox(Godot.Vector3)
    //     on each component.
    //
    // 参数:
    //   other:
    //     The other basis to compare.
    //
    // 返回结果:
    //     Whether or not the bases are approximately equal.
    public readonly bool IsEqualApprox(Basis other)
    {
        if (Row0.IsEqualApprox(other.Row0) && Row1.IsEqualApprox(other.Row1))
        {
            return Row2.IsEqualApprox(other.Row2);
        }

        return false;
    }

    //
    // 摘要:
    //     Serves as the hash function for Godot.Basis.
    //
    // 返回结果:
    //     A hash code for this basis.
    public override readonly int GetHashCode()
    {
        return HashCode.Combine(Row0, Row1, Row2);
    }

    //
    // 摘要:
    //     Converts this Godot.Basis to a string.
    //
    // 返回结果:
    //     A string representation of this basis.
    public override readonly string ToString()
    {
        return ToString(null);
    }

    //
    // 摘要:
    //     Converts this Godot.Basis to a string with the given format.
    //
    // 返回结果:
    //     A string representation of this basis.
    public readonly string ToString(string? format)
    {
        return $"[X: {X.ToString(format)}, Y: {Y.ToString(format)}, Z: {Z.ToString(format)}]";
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
