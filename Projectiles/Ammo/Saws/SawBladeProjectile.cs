using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Ammo.Saws
{
    public class SawBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Saw Blade");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10; // 1 hit per npc max
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 2;
            AIType = -1;
        }
        public override void AI()
        {
            //Rotacion del proyectil
            Projectile.rotation *= (1f);
        }
        public override void Kill(int timeLeft)
        {
            int dust1 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Iron, 0f, 0f, 0, default, 1);
            Main.dust[dust1].noGravity = false;
        }
    }
}
