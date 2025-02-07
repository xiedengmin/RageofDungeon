//
// GLSL textureless classic 2D noise "cnoise",
// with an RSL-style periodic variant "pnoise".
// Author:  Stefan Gustavson (stefan.gustavson@liu.se)
// Version: 2011-08-22
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
        /// <param name="P">Point on a 2D grid of gradient vectors.</param>
        /// <returns>Noise value.</returns>
        public static float cnoise(Vector2 P)
        {
            Vector4 Pi = floor(P.xyxy) + Vector4(0.0f, 0.0f, 1.0f, 1.0f);
            Vector4 Pf = frac(P.xyxy) - Vector4(0.0f, 0.0f, 1.0f, 1.0f);
            Pi = mod289(Pi); // To avoid truncation effects in permutation
            Vector4 ix = Pi.xzxz;
            Vector4 iy = Pi.yyww;
            Vector4 fx = Pf.xzxz;
            Vector4 fy = Pf.yyww;

            Vector4 i = permute(permute(ix) + iy);

            Vector4 gx = frac(i * (1.0f / 41.0f)) * 2.0f - 1.0f;
            Vector4 gy = abs(gx) - 0.5f;
            Vector4 tx = floor(gx + 0.5f);
            gx = gx - tx;

            Vector2 g00 = Vector2(gx.x, gy.x);
            Vector2 g10 = Vector2(gx.y, gy.y);
            Vector2 g01 = Vector2(gx.z, gy.z);
            Vector2 g11 = Vector2(gx.w, gy.w);

            Vector4 norm = taylorInvSqrt(Vector4(dot(g00, g00), dot(g01, g01), dot(g10, g10), dot(g11, g11)));
            g00 *= norm.x;
            g01 *= norm.y;
            g10 *= norm.z;
            g11 *= norm.w;

            float n00 = dot(g00, Vector2(fx.x, fy.x));
            float n10 = dot(g10, Vector2(fx.y, fy.y));
            float n01 = dot(g01, Vector2(fx.z, fy.z));
            float n11 = dot(g11, Vector2(fx.w, fy.w));

            Vector2 fade_xy = fade(Pf.xy);
            Vector2 n_x = lerp(Vector2(n00, n01), Vector2(n10, n11), fade_xy.x);
            float n_xy = lerp(n_x.x, n_x.y, fade_xy.y);
            return 2.3f * n_xy;
        }

        /// <summary>
        /// Classic Perlin noise, periodic variant
        /// </summary>
        /// <param name="P">Point on a 2D grid of gradient vectors.</param>
        /// <param name="rep">Period of repetition.</param>
        /// <returns>Noise value.</returns>
        public static float pnoise(Vector2 P, Vector2 rep)
        {
            Vector4 Pi = floor(P.xyxy) + Vector4(0.0f, 0.0f, 1.0f, 1.0f);
            Vector4 Pf = frac(P.xyxy) - Vector4(0.0f, 0.0f, 1.0f, 1.0f);
            Pi = fmod(Pi, rep.xyxy); // To create noise with explicit period
            Pi = mod289(Pi); // To avoid truncation effects in permutation
            Vector4 ix = Pi.xzxz;
            Vector4 iy = Pi.yyww;
            Vector4 fx = Pf.xzxz;
            Vector4 fy = Pf.yyww;

            Vector4 i = permute(permute(ix) + iy);

            Vector4 gx = frac(i * (1.0f / 41.0f)) * 2.0f - 1.0f;
            Vector4 gy = abs(gx) - 0.5f;
            Vector4 tx = floor(gx + 0.5f);
            gx = gx - tx;

            Vector2 g00 = Vector2(gx.x, gy.x);
            Vector2 g10 = Vector2(gx.y, gy.y);
            Vector2 g01 = Vector2(gx.z, gy.z);
            Vector2 g11 = Vector2(gx.w, gy.w);

            Vector4 norm = taylorInvSqrt(Vector4(dot(g00, g00), dot(g01, g01), dot(g10, g10), dot(g11, g11)));
            g00 *= norm.x;
            g01 *= norm.y;
            g10 *= norm.z;
            g11 *= norm.w;

            float n00 = dot(g00, Vector2(fx.x, fy.x));
            float n10 = dot(g10, Vector2(fx.y, fy.y));
            float n01 = dot(g01, Vector2(fx.z, fy.z));
            float n11 = dot(g11, Vector2(fx.w, fy.w));

            Vector2 fade_xy = fade(Pf.xy);
            Vector2 n_x = lerp(Vector2(n00, n01), Vector2(n10, n11), fade_xy.x);
            float n_xy = lerp(n_x.x, n_x.y, fade_xy.y);
            return 2.3f * n_xy;
        }
    }
}
