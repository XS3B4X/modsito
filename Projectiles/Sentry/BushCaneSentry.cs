using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Sentry
{
    internal class BushCaneSentry : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Summon;
            Projectile.sentry = true;
            Projectile.timeLeft = Projectile.SentryLifeTime;
        }

        public override 
    }
}
