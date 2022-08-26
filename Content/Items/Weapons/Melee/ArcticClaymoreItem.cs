﻿using AllBeginningsMod.Common.Bases.Items;
using AllBeginningsMod.Content.Items.Materials;
using AllBeginningsMod.Content.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllBeginningsMod.Content.Items.Weapons.Melee;

public sealed class ArcticClaymoreItem : GreatswordItemBase<ArcticClaymoreProjectile>
{
    public override void SetStaticDefaults() {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults() {
        base.SetDefaults();

        Item.damage = 24;
        Item.DamageType = DamageClass.Melee;

        Item.autoReuse = true;
        Item.knockBack = 6f;

        Item.width = 50;
        Item.height = 50;

        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Shoot;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(gold: 1, silver: 50);
    }
    public override void AddRecipes() {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<SnowflakeItem>(), 15);
        recipe.AddRecipeGroup(RecipeGroupID.Wood, 12);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}