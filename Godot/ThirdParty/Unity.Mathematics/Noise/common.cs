using Unity.IL2CPP.CompilerServices;
using static Godot.Mathematics.math;

namespace Godot.Mathematics
{
    /// <summary>
    /// A static class containing noise functions.
    /// </summary>
    [Il2CppEagerStaticClassConstruction]
    public static partial class noise
    {
        // Modulo 289 without a division (only multiplications)
        static float  mod289(float x)  { return x - floor(x * (1.0f / 289.0f)) * 289.0f; }
        static Vector2 mod289(Vector2 x) { return x - floor(x * (1.0f / 289.0f)) * 289.0f; }
        static Vector3 mod289(Vector3 x) { return x - floor(x * (1.0f / 289.0f)) * 289.0f; }
        static Vector4 mod289(Vector4 x) { return x - floor(x * (1.0f / 289.0f)) * 289.0f; }

        // Modulo 7 without a division
        static Vector3 mod7(Vector3 x) { return x - floor(x * (1.0f / 7.0f)) * 7.0f; }
        static Vector4 mod7(Vector4 x) { return x - floor(x * (1.0f / 7.0f)) * 7.0f; }

        // Permutation polynomial: (34x^2 + x) math.mod 289
        static float  permute(float x)  { return mod289((34.0f * x + 1.0f) * x); }
        static Vector3 permute(Vector3 x) { return mod289((34.0f * x + 1.0f) * x); }
        static Vector4 permute(Vector4 x) { return mod289((34.0f * x + 1.0f) * x); }

        static float  taylorInvSqrt(float r)  { return 1.79284291400159f - 0.85373472095314f * r; }
        static Vector4 taylorInvSqrt(Vector4 r) { return 1.79284291400159f - 0.85373472095314f * r; }

        static Vector2 fade(Vector2 t) { return t*t*t*(t*(t*6.0f-15.0f)+10.0f); }
        static Vector3 fade(Vector3 t) { return t*t*t*(t*(t*6.0f-15.0f)+10.0f); }
        static Vector4 fade(Vector4 t) { return t*t*t*(t*(t*6.0f-15.0f)+10.0f); }

        static Vector4 grad4(float j, Vector4 ip)
        {
            Vector4 ones = Vector4(1.0f, 1.0f, 1.0f, -1.0f);
            Vector3 pxyz = floor(frac(Vector3(j) * ip.xyz) * 7.0f) * ip.z - 1.0f;
            float  pw   = 1.5f - dot(abs(pxyz), ones.xyz);
            Vector4 p = Vector4(pxyz, pw);
            Vector4 s = Vector4(p < 0.0f);
            p.xyz = p.xyz + (s.xyz*2.0f - 1.0f) * s.www;
            return p;
        }

        // Hashed 2-D gradients with an extra rotation.
        // (The constant 0.0243902439 is 1/41)
        static Vector2 rgrad2(Vector2 p, float rot)
        {
            // For more isotropic gradients, math.sin/math.cos can be used instead.
            float u = permute(permute(p.x) + p.y) * 0.0243902439f + rot; // Rotate by shift
            u = frac(u) * 6.28318530718f; // 2*pi
            return Vector2(cos(u), sin(u));
        }
    }
}
