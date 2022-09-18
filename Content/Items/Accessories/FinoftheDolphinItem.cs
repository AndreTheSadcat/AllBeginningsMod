﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Items.Accessories;

public sealed class FinoftheDolphinItem : ModItem
{
    public override void SetStaticDefaults() {
        SacrificeTotal = 1;
    }

    public override void SetDefaults() {
        Item.accessory = true;

        Item.width = 16;
        Item.height = 20;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 80);
    }

    public override void UpdateEquip(Player player) {
        if (player.wet) {
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }

        player.accFlipper = true;
        player.ignoreWater = true;
    }
}