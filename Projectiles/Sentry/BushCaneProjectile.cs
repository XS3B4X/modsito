using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Sentry
{
    internal class BushCaneProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = -1
        }
    }
}
