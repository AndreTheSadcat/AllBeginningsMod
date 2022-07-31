﻿using AllBeginningsMod.Common.Bases.Projectiles;
using AllBeginningsMod.Content.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Projectiles.Ranged;

public sealed class CopperTomahawkProjectile : ModProjectileBase
{
    public override string Texture => base.Texture.Replace("/Projectiles/", "/Items/Weapons/").Replace("Projectile", "Item");

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Copper Tomahawk");
    }

    public override void SetDefaults() {
        Projectile.friendly = true;

        Projectile.width = 24;
        Projectile.height = 24;

        Projectile.timeLeft = 180;
        Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
    }

    public override bool OnTileCollide(Vector2 oldVelocity) {
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

        Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

        if (Main.rand.NextBool(5))
            Item.NewItem(Projectile.GetSource_Death(), Projectile.position, ModContent.ItemType<CopperTomahawkItem>());

        return true;
    }
}