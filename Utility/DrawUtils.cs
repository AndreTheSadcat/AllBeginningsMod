﻿using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace AllBeginningsMod.Utility
{
    public static class DrawUtils
    {
        public static Rectangle ScreenRectangle => new(0, 0, Main.screenWidth, Main.screenHeight);
        public static Vector2 ScreenSize => new(Main.screenWidth, Main.screenHeight);
        public static Matrix GameViewTransformationMatrix => Main.GameViewMatrix.TransformationMatrix;

        public static int GetPrimitiveCount(int vertexCount, PrimitiveType type) {
            return type switch {
                PrimitiveType.TriangleList => vertexCount / 3,
                PrimitiveType.TriangleStrip => vertexCount - 2,
                PrimitiveType.LineList => vertexCount / 2,
                PrimitiveType.LineStrip => vertexCount - 1,
                PrimitiveType.PointListEXT => vertexCount / 3,
                _ => ThrowUnknownPrimitiveType(type)
            };
            [MethodImpl(MethodImplOptions.NoInlining)] 
            static int ThrowUnknownPrimitiveType(PrimitiveType type) => throw new ArgumentException($"Unsupported primitive type: {type}", nameof(type));
        }
    }
}