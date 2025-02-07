//
// Description : Array and textureless GLSL 2D/3D/4D simplex
//               noise functions.
//      Author : Ian McEwan, Ashima Arts.
//  Maintainer : stegu
//     Lastmath.mod : 20110822 (ijm)
//     License : Copyright (C) 2011 Ashima Arts. All rights reserved.
//               Distributed under the MIT License. See LICENSE file.
//               https://github.com/ashima/webgl-noise
//               https://github.com/stegu/webgl-noise
//

using static Godot.Mathematics.math;

namespace Godot.Mathematics
{
    public static partial class noise
    {
        /// <summary>
        /// Simplex noise.
        /// </summary>
        /// <param name="v">Input coordinate.</param>
        /// <returns>Noise value.</returns>
        public static float snoise(Vector3 v)
        {
            Vector2 C = Vector2(1.0f / 6.0f, 1.0f / 3.0f);
            Vector4 D = Vector4(0.0f, 0.5f, 1.0f, 2.0f);

            // First corner
            Vector3 i = floor(v + dot(v, C.yyy));
            Vector3 x0 = v - i + dot(i, C.xxx);

            // Other corners
            Vector3 g = step(x0.yzx, x0.xyz);
            Vector3 l = 1.0f - g;
            Vector3 i1 = min(g.xyz, l.zxy);
            Vector3 i2 = max(g.xyz, l.zxy);

            //   x0 = x0 - 0.0 + 0.0 * C.xxx;
            //   x1 = x0 - i1  + 1.0 * C.xxx;
            //   x2 = x0 - i2  + 2.0 * C.xxx;
            //   x3 = x0 - 1.0 + 3.0 * C.xxx;
            Vector3 x1 = x0 - i1 + C.xxx;
            Vector3 x2 = x0 - i2 + C.yyy; // 2.0*C.x = 1/3 = C.y
            Vector3 x3 = x0 - D.yyy; // -1.0+3.0*C.x = -0.5 = -D.y

            // Permutations
            i = mod289(i);
            Vector4 p = permute(permute(permute(
                                         i.z + Vector4(0.0f, i1.z, i2.z, 1.0f))
                                     + i.y + Vector4(0.0f, i1.y, i2.y, 1.0f))
                             + i.x + Vector4(0.0f, i1.x, i2.x, 1.0f));

            // Gradients: 7x7 points over a square, mapped onto an octahedron.
            // The ring size 17*17 = 289 is close to a multiple of 49 (49*6 = 294)
            float n_ = 0.142857142857f; // 1.0/7.0
            Vector3 ns = n_ * D.wyz - D.xzx;

            Vector4 j = p - 49.0f * floor(p * ns.z * ns.z); //  math.mod(p,7*7)

            Vector4 x_ = floor(j * ns.z);
            Vector4 y_ = floor(j - 7.0f * x_); // math.mod(j,N)

            Vector4 x = x_ * ns.x + ns.yyyy;
            Vector4 y = y_ * ns.x + ns.yyyy;
            Vector4 h = 1.0f - abs(x) - abs(y);

            Vector4 b0 = Vector4(x.xy, y.xy);
            Vector4 b1 = Vector4(x.zw, y.zw);

            //Vector4 s0 = Vector4(math.lessThan(b0,0.0))*2.0 - 1.0;
            //Vector4 s1 = Vector4(math.lessThan(b1,0.0))*2.0 - 1.0;
            Vector4 s0 = floor(b0) * 2.0f + 1.0f;
            Vector4 s1 = floor(b1) * 2.0f + 1.0f;
            Vector4 sh = -step(h, Vector4(0.0f));

            Vector4 a0 = b0.xzyw + s0.xzyw * sh.xxyy;
            Vector4 a1 = b1.xzyw + s1.xzyw * sh.zzww;

            Vector3 p0 = Vector3(a0.xy, h.x);
            Vector3 p1 = Vector3(a0.zw, h.y);
            Vector3 p2 = Vector3(a1.xy, h.z);
            Vector3 p3 = Vector3(a1.zw, h.w);

            //Normalise gradients
            Vector4 norm = taylorInvSqrt(Vector4(dot(p0, p0), dot(p1, p1), dot(p2, p2), dot(p3, p3)));
            p0 *= norm.x;
            p1 *= norm.y;
            p2 *= norm.z;
            p3 *= norm.w;

            // Mix final noise value
            Vector4 m = max(0.6f - Vector4(dot(x0, x0), dot(x1, x1), dot(x2, x2), dot(x3, x3)), 0.0f);
            m = m * m;
            return 42.0f * dot(m * m, Vector4(dot(p0, x0), dot(p1, x1), dot(p2, x2), dot(p3, x3)));
        }
    }
}
