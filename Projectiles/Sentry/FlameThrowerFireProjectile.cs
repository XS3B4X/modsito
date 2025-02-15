using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Sentry
{
    public class FlameThrowerFireProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 90;
            Projectile.height = 90;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 60;
            Projectile.alpha = 255;
            Projectile.light = 0.5f;
            Projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            // Efecto de dispersión del fuego
            Projectile.velocity *= 0.98f;
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
            }
        }
    }
}
