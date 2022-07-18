﻿using AllBeginningsMod.Content.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Common.Globals.NPCs
{
    public sealed class ShopGlobalNPC : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot) {
            if (type == NPCID.BestiaryGirl) {
                if (Main.BestiaryDB.GetCompletedPercentByMod(Mod) == -1) {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RabbitsFootItem>());
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<MagmaShellItem>());
                    nextSlot++;
                }
            }
        }
    }
}