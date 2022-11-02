﻿using AllBeginningsMod.Common.Bases;

namespace AllBeginningsMod.Content.Projectiles.Melee;

public sealed class IronGreatswordProjectile : GreatswordProjectileBase
{
    public override void SetDefaults() {
        Projectile.width = 40;
        Projectile.height = 40;

        base.SetDefaults();
    }
}