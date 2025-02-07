//
// GLSL textureless classic 3D noise "cnoise",
// with an RSL-style periodic variant "pnoise".
// Author:  Stefan Gustavson (stefan.gustavson@liu.se)
// Version: 2011-10-11
//
// Many thanks to Ian McEwan of Ashima Arts for the
// ideas for permutation and gradient selection.
//
// Copyright (c) 2011 Stefan Gustavson. All rights reserved.
// Distributed under the MIT license. See LICENSE file.
// https://github.com/stegu/webgl-noise
//

using static Godot.Mathematics.math;

namespace Godot.Mathematics
{
    public static partial class noise
    {
        /// <summary>
        /// Classic Perlin noise
        /// </summary>
        /// <param name="P">Point on a 3D grid of gradient vectors.</param>
        /// <returns>Noise value.</returns>
        public static float cnoise(Vector3 P)
        {
            Vector3 Pi0 = floor(P); // Integer part for indexing
            Vector3 Pi1 = Pi0 + Vector3(1.0f); // Integer part + 1
            Pi0 = mod289(Pi0);
            Pi1 = mod289(Pi1);
            Vector3 Pf0 = frac(P); // Fractional part for interpolation
            Vector3 Pf1 = Pf0 - Vector3(1.0f); // Fractional part - 1.0
            Vector4 ix = Vector4(Pi0.x, Pi1.x, Pi0.x, Pi1.x);
            Vector4 iy = Vector4(Pi0.yy, Pi1.yy);
            Vector4 iz0 = Pi0.zzzz;
            Vector4 iz1 = Pi1.zzzz;

            Vector4 ixy = permute(permute(ix) + iy);
            Vector4 ixy0 = permute(ixy + iz0);
            Vector4 ixy1 = permute(ixy + iz1);

            Vector4 gx0 = ixy0 * (1.0f / 7.0f);
            Vector4 gy0 = frac(floor(gx0) * (1.0f / 7.0f)) - 0.5f;
            gx0 = frac(gx0);
            Vector4 gz0 = Vector4(0.5f) - abs(gx0) - abs(gy0);
            Vector4 sz0 = step(gz0, Vector4(0.0f));
            gx0 -= sz0 * (step(0.0f, gx0) - 0.5f);
            gy0 -= sz0 * (step(0.0f, gy0) - 0.5f);

            Vector4 gx1 = ixy1 * (1.0f / 7.0f);
            Vector4 gy1 = frac(floor(gx1) * (1.0f / 7.0f)) - 0.5f;
            gx1 = frac(gx1);
            Vector4 gz1 = Vector4(0.5f) - abs(gx1) - abs(gy1);
            Vector4 sz1 = step(gz1, Vector4(0.0f));
            gx1 -= sz1 * (step(0.0f, gx1) - 0.5f);
            gy1 -= sz1 * (step(0.0f, gy1) - 0.5f);

            Vector3 g000 = Vector3(gx0.x, gy0.x, gz0.x);
            Vector3 g100 = Vector3(gx0.y, gy0.y, gz0.y);
            Vector3 g010 = Vector3(gx0.z, gy0.z, gz0.z);
            Vector3 g110 = Vector3(gx0.w, gy0.w, gz0.w);
            Vector3 g001 = Vector3(gx1.x, gy1.x, gz1.x);
            Vector3 g101 = Vector3(gx1.y, gy1.y, gz1.y);
            Vector3 g011 = Vector3(gx1.z, gy1.z, gz1.z);
            Vector3 g111 = Vector3(gx1.w, gy1.w, gz1.w);

            Vector4 norm0 = taylorInvSqrt(Vector4(dot(g000, g000), dot(g010, g010), dot(g100, g100), dot(g110, g110)));
            g000 *= norm0.x;
            g010 *= norm0.y;
            g100 *= norm0.z;
            g110 *= norm0.w;
            Vector4 norm1 = taylorInvSqrt(Vector4(dot(g001, g001), dot(g011, g011), dot(g101, g101), dot(g111, g111)));
            g001 *= norm1.x;
            g011 *= norm1.y;
            g101 *= norm1.z;
            g111 *= norm1.w;

            float n000 = dot(g000, Pf0);
            float n100 = dot(g100, Vector3(Pf1.x, Pf0.yz));
            float n010 = dot(g010, Vector3(Pf0.x, Pf1.y, Pf0.z));
            float n110 = dot(g110, Vector3(Pf1.xy, Pf0.z));
            float n001 = dot(g001, Vector3(Pf0.xy, Pf1.z));
            float n101 = dot(g101, Vector3(Pf1.x, Pf0.y, Pf1.z));
            float n011 = dot(g011, Vector3(Pf0.x, Pf1.yz));
            float n111 = dot(g111, Pf1);

            Vector3 fade_xyz = fade(Pf0);
            Vector4 n_z = lerp(Vector4(n000, n100, n010, n110), Vector4(n001, n101, n011, n111), fade_xyz.z);
            Vector2 n_yz = lerp(n_z.xy, n_z.zw, fade_xyz.y);
            float n_xyz = lerp(n_yz.x, n_yz.y, fade_xyz.x);
            return 2.2f * n_xyz;
        }

        /// <summary>
        /// Classic Perlin noise, periodic variant
        /// </summary>
        /// <param name="P">Point on a 3D grid of gradient vectors.</param>
        /// <param name="rep">Period of repetition.</param>
        /// <returns>Noise value.</returns>
        public static float pnoise(Vector3 P, Vector3 rep)
        {
            Vector3 Pi0 = fmod(floor(P), rep); // Integer part, math.modulo period
            Vector3 Pi1 = fmod(Pi0 + Vector3(1.0f), rep); // Integer part + 1, math.mod period
            Pi0 = mod289(Pi0);
            Pi1 = mod289(Pi1);
            Vector3 Pf0 = frac(P); // Fractional part for interpolation
            Vector3 Pf1 = Pf0 - Vector3(1.0f); // Fractional part - 1.0
            Vector4 ix = Vector4(Pi0.x, Pi1.x, Pi0.x, Pi1.x);
            Vector4 iy = Vector4(Pi0.yy, Pi1.yy);
            Vector4 iz0 = Pi0.zzzz;
            Vector4 iz1 = Pi1.zzzz;

            Vector4 ixy = permute(permute(ix) + iy);
            Vector4 ixy0 = permute(ixy + iz0);
            Vector4 ixy1 = permute(ixy + iz1);

            Vector4 gx0 = ixy0 * (1.0f / 7.0f);
            Vector4 gy0 = frac(floor(gx0) * (1.0f / 7.0f)) - 0.5f;
            gx0 = frac(gx0);
            Vector4 gz0 = Vector4(0.5f) - abs(gx0) - abs(gy0);
            Vector4 sz0 = step(gz0, Vector4(0.0f));
            gx0 -= sz0 * (step(0.0f, gx0) - 0.5f);
            gy0 -= sz0 * (step(0.0f, gy0) - 0.5f);

            Vector4 gx1 = ixy1 * (1.0f / 7.0f);
            Vector4 gy1 = frac(floor(gx1) * (1.0f / 7.0f)) - 0.5f;
            gx1 = frac(gx1);
            Vector4 gz1 = Vector4(0.5f) - abs(gx1) - abs(gy1);
            Vector4 sz1 = step(gz1, Vector4(0.0f));
            gx1 -= sz1 * (step(0.0f, gx1) - 0.5f);
            gy1 -= sz1 * (step(0.0f, gy1) - 0.5f);

            Vector3 g000 = Vector3(gx0.x, gy0.x, gz0.x);
            Vector3 g100 = Vector3(gx0.y, gy0.y, gz0.y);
            Vector3 g010 = Vector3(gx0.z, gy0.z, gz0.z);
            Vector3 g110 = Vector3(gx0.w, gy0.w, gz0.w);
            Vector3 g001 = Vector3(gx1.x, gy1.x, gz1.x);
            Vector3 g101 = Vector3(gx1.y, gy1.y, gz1.y);
            Vector3 g011 = Vector3(gx1.z, gy1.z, gz1.z);
            Vector3 g111 = Vector3(gx1.w, gy1.w, gz1.w);

            Vector4 norm0 = taylorInvSqrt(Vector4(dot(g000, g000), dot(g010, g010), dot(g100, g100), dot(g110, g110)));
            g000 *= norm0.x;
            g010 *= norm0.y;
            g100 *= norm0.z;
            g110 *= norm0.w;
            Vector4 norm1 = taylorInvSqrt(Vector4(dot(g001, g001), dot(g011, g011), dot(g101, g101), dot(g111, g111)));
            g001 *= norm1.x;
            g011 *= norm1.y;
            g101 *= norm1.z;
            g111 *= norm1.w;

            float n000 = dot(g000, Pf0);
            float n100 = dot(g100, Vector3(Pf1.x, Pf0.yz));
            float n010 = dot(g010, Vector3(Pf0.x, Pf1.y, Pf0.z));
            float n110 = dot(g110, Vector3(Pf1.xy, Pf0.z));
            float n001 = dot(g001, Vector3(Pf0.xy, Pf1.z));
            float n101 = dot(g101, Vector3(Pf1.x, Pf0.y, Pf1.z));
            float n011 = dot(g011, Vector3(Pf0.x, Pf1.yz));
            float n111 = dot(g111, Pf1);

            Vector3 fade_xyz = fade(Pf0);
            Vector4 n_z = lerp(Vector4(n000, n100, n010, n110), Vector4(n001, n101, n011, n111), fade_xyz.z);
            Vector2 n_yz = lerp(n_z.xy, n_z.zw, fade_xyz.y);
            float n_xyz = lerp(n_yz.x, n_yz.y, fade_xyz.x);
            return 2.2f * n_xyz;
        }
    }
}
