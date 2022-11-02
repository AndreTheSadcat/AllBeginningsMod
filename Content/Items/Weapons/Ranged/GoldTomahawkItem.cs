﻿using AllBeginningsMod.Content.Projectiles.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Items.Weapons.Ranged;

public sealed class GoldTomahawkItem : ModItem
{
    public override void SetDefaults() {
        Item.consumable = true;
        Item.noMelee = true;

        Item.maxStack = 999;

        Item.DamageType = DamageClass.Ranged;
        Item.damage = 18;
        Item.knockBack = 2f;

        Item.width = 24;
        Item.height = 28;

        Item.useTime = 12;
        Item.useAnimation = 12;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.holdStyle = ItemHoldStyleID.HoldUp;

        Item.shoot = ModContent.ProjectileType<GoldTomahawkProjectile>();
        Item.shootSpeed = 14f;

        Item.value = Item.sellPrice(copper: 10);
        Item.rare = ItemRarityID.White;

        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes() {
        Recipe recipe = CreateRecipe(50);
        recipe.AddIngredient(ItemID.GoldBar);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}