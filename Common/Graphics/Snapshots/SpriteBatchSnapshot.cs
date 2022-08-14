﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AllBeginningsMod.Common.Graphics.Snapshots;

/// <summary>
/// Represents the states of a <see cref="SpriteBatch"/>'s captured drawing instance.
/// </summary>
public readonly struct SpriteBatchSnapshot
{
    public readonly SpriteSortMode SortMode;
    public readonly BlendState BlendState;
    public readonly SamplerState SamplerState;
    public readonly DepthStencilState DepthStencilState;
    public readonly RasterizerState RasterizerState;
    public readonly Effect Effect;
    public readonly Matrix TransformMatrix;
    
    public SpriteBatchSnapshot(
        SpriteSortMode sortMode,
        BlendState blendState,
        SamplerState samplerState,
        DepthStencilState depthStencilState,
        RasterizerState rasterizerState,
        Effect effect,
        Matrix transformMatrix
    ) {
        SortMode = sortMode;
        BlendState = blendState;
        SamplerState = samplerState;
        DepthStencilState = depthStencilState;
        RasterizerState = rasterizerState;
        Effect = effect;
        TransformMatrix = transformMatrix;
    }
    
    /// <summary>
    /// Captures the current drawing instance of a <see cref="SpriteBatch"/>.
    /// </summary>
    /// <param name="spriteBatch">The spritebatch.</param>
    /// <returns>A <see cref="SpriteBatchSnapshot"/> containing the drawing states of a <see cref="SpriteBatch"/> drawing instance</returns>
    public static SpriteBatchSnapshot Capture(SpriteBatch spriteBatch) {
        SpriteBatchCache.EnsureInitialized();

        SpriteSortMode sortMode = (SpriteSortMode) SpriteBatchCache.SortMode.GetValue(spriteBatch);
        BlendState blendState = (BlendState) SpriteBatchCache.BlendState.GetValue(spriteBatch);
        SamplerState samplerState = (SamplerState) SpriteBatchCache.SamplerState.GetValue(spriteBatch);
        DepthStencilState depthStencilState = (DepthStencilState) SpriteBatchCache.DepthStencilState.GetValue(spriteBatch);
        RasterizerState rasterizerState = (RasterizerState) SpriteBatchCache.RasterizerState.GetValue(spriteBatch);
        Effect effect = (Effect) SpriteBatchCache.Effect.GetValue(spriteBatch);
        Matrix transformMatrix = (Matrix) SpriteBatchCache.TransformMatrix.GetValue(spriteBatch);

        return new SpriteBatchSnapshot(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
    }
}