﻿using AllBeginningsMod.Common.Bases.Projectiles;
using AllBeginningsMod.Utility.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace AllBeginningsMod.Content.Projectiles.Ranged;

public sealed class BorealTurnipProjectile : ModProjectileBase
{    
    public override string Texture => base.Texture.Replace("/Projectiles/", "/Items/Weapons/").Replace("Projectile", "Item");

    public override void SetStaticDefaults() {
        ProjectileID.Sets.TrailingMode[Type] = 2;
        ProjectileID.Sets.TrailCacheLength[Type] = 10;
    }

    public override void SetDefaults() {
        Projectile.friendly = true;

        Projectile.width = 32;
        Projectile.height = 32;

        Projectile.penetrate = -1;
        Projectile.timeLeft = 180;
        Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
    }

    public override bool OnTileCollide(Vector2 oldVelocity) {
        Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        return true;
    }

    public override void Kill(int timeLeft) {
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        NPC npc = Projectile.FindTargetWithinRange(512f);

        if (npc != null)
            Projectile.velocity = Projectile.DirectionTo(npc.Center) * Projectile.velocity.Length();

        target.AddBuff(BuffID.Frostburn, 60);
    }

    public override bool PreDraw(ref Color lightColor) {
        Projectile.DrawAfterimage(lightColor, Projectile.Hitbox.GetCenterOrigin(), 0.8f, 0.1f, 2);

        return true;
    }
}