// Cellular noise ("Worley noise") in 2D in GLSL.
// Copyright (c) Stefan Gustavson 2011-04-19. All rights reserved.
// This code is released under the conditions of the MIT license.
// See LICENSE file for details.
// https://github.com/stegu/webgl-noise

using static Godot.Mathematics.math;

namespace Godot.Mathematics
{
    public static partial class noise
    {
        /// <summary>
        /// 2D Cellular noise ("Worley noise") with standard 3x3 search window for good feature point values.
        /// </summary>
        /// <param name="P">A point in 2D space.</param>
        /// <returns>Feature points. F1 is in the x component, F2 in the y component.</returns>
        public static Vector2 cellular(Vector2 P)
        {
            const float K = 0.142857142857f; // 1/7
            const float Ko = 0.428571428571f; // 3/7
            const float jitter = 1.0f; // Less gives more regular pattern

            Vector2 Pi = mod289(floor(P));
            Vector2 Pf = frac(P);
            Vector3 oi = Vector3(-1.0f, 0.0f, 1.0f);
            Vector3 of = Vector3(-0.5f, 0.5f, 1.5f);
            Vector3 px = permute(Pi.x + oi);
            Vector3 p = permute(px.x + Pi.y + oi); // p11, p12, p13
            Vector3 ox = frac(p * K) - Ko;
            Vector3 oy = mod7(floor(p * K)) * K - Ko;
            Vector3 dx = Pf.x + 0.5f + jitter * ox;
            Vector3 dy = Pf.y - of + jitter * oy;
            Vector3 d1 = dx * dx + dy * dy; // d11, d12 and d13, squared
            p = permute(px.y + Pi.y + oi); // p21, p22, p23
            ox = frac(p * K) - Ko;
            oy = mod7(floor(p * K)) * K - Ko;
            dx = Pf.x - 0.5f + jitter * ox;
            dy = Pf.y - of + jitter * oy;
            Vector3 d2 = dx * dx + dy * dy; // d21, d22 and d23, squared
            p = permute(px.z + Pi.y + oi); // p31, p32, p33
            ox = frac(p * K) - Ko;
            oy = mod7(floor(p * K)) * K - Ko;
            dx = Pf.x - 1.5f + jitter * ox;
            dy = Pf.y - of + jitter * oy;
            Vector3 d3 = dx * dx + dy * dy; // d31, d32 and d33, squared
            // Sort out the two smallest distances (F1, F2)
            Vector3 d1a = min(d1, d2);
            d2 = max(d1, d2); // Swap to keep candidates for F2
            d2 = min(d2, d3); // neither F1 nor F2 are now in d3
            d1 = min(d1a, d2); // F1 is now in d1
            d2 = max(d1a, d2); // Swap to keep candidates for F2
            d1.xy = (d1.x < d1.y) ? d1.xy : d1.yx; // Swap if smaller
            d1.xz = (d1.x < d1.z) ? d1.xz : d1.zx; // F1 is in d1.x
            d1.yz = min(d1.yz, d2.yz); // F2 is now not in d2.yz
            d1.y = min(d1.y, d1.z); // nor in  d1.z
            d1.y = min(d1.y, d2.x); // F2 is in d1.y, we're done.
            return sqrt(d1.xy);
        }
    }
}
