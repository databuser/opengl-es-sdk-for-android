#version 300 es
/* Copyright (c) 2014-2017, ARM Limited and Contributors
 *
 * SPDX-License-Identifier: MIT
 *
 * Permission is hereby granted, free of charge,
 * to any person obtaining a copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
 * and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

#extension GL_EXT_shader_pixel_local_storage : require
precision highp float;

__pixel_localEXT FragDataLocal {
    layout(rgb10_a2) vec4 lighting;
    layout(rg16f) vec2 minMaxDepth;
    layout(rgb10_a2) vec4 albedo;
    layout(rg16f) vec2 normalXY;
} storage;

uniform vec3 albedo;
in vec4 vPosition;
in vec3 vNormal;

void main()
{
    vec3 n = normalize(vNormal);
    storage.lighting = vec4(0.0);
    storage.minMaxDepth = vec2(-vPosition.z, -vPosition.z);
    storage.albedo.rgb = albedo;
    storage.albedo.a = sign(n.z);
    storage.normalXY = n.xy;
}
