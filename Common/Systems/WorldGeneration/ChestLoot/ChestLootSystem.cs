﻿using System.Collections.Generic;
using AllBeginningsMod.Utility.Extensions;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.WorldBuilding;

namespace AllBeginningsMod.Common.Systems.WorldGeneration.ChestLoot;

public sealed class ChestLootSystem : ModSystem
{
    // Not on PostWorldGen just so it doesnt look confusing without no progress message. If we ever add our own chests, a change might be required.
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
        int chestIndex = tasks.FindIndex(index => index.Name == "Water Chests");
        tasks.TryInsert(chestIndex + 1, new PassLegacy(AllBeginningsMod.ModPrefix + "ChestLoot", GenerateChestLoot));
    }

    private static void GenerateChestLoot(GenerationProgress progress, GameConfiguration configuration) {
        progress.Message = "Adding loot to chests...";

        foreach (Chest chest in Main.chest) {
            if (chest == null)
                continue;
            
            Tile tile = Framing.GetTileSafely(chest.x, chest.y);

            foreach (ChestLoot chestLoot in ModContent.GetContent<ChestLoot>()) {
                if (!tile.HasTile || tile.TileType != TileID.Containers || tile.TileFrameX != chestLoot.ChestFrame)
                    continue;
                
                chestLoot.SetLoot(chest);
            }
        }
    }
}