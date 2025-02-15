using System;
using Microsoft.Xna.Framework;
using Modsito.Projectiles.Sentry;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Sentry
{
    public class FlameThrowerSentryProjectile : ModProjectile
    {
        private NPC target;
        public int Level = 0;
        public float maxDetectRadius;
        public float fireRange;
        public int damage;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 70;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.sentry = true;
            Projectile.timeLeft = Projectile.SentryLifeTime;
            Projectile.aiStyle = 0;
        }

        private NPC forcedTarget = null;

        private void ShootFire()
        {
            if (target == null) return;

            Vector2 direction = target.Center - Projectile.Center;
            float distanceToTarget = direction.Length();
            direction.Normalize();

            float speed = 10f;
            int type = ModContent.ProjectileType<FlameThrowerFireProjectile>();
            damage = (int)(23 * (1 + (1f / 3f) * Level));
            fireRange = maxDetectRadius;

            if (distanceToTarget <= fireRange)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction * speed, type, damage, Projectile.knockBack, Projectile.owner);
            }
        }

        public void SetTarget(NPC npc)
        {
            forcedTarget = npc;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead)
            {
                Projectile.Kill();
                return;
            }

            maxDetectRadius = 16 * (12f * (1 + (1f / 3f) * Level));
            fireRange = maxDetectRadius;

            if (forcedTarget != null && forcedTarget.active)
            {
                target = forcedTarget;
            }
            else
            {
                target = FindClosestNPC(maxDetectRadius);
            }

            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();
                Projectile.rotation = (float)Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2;

                if (Projectile.ai[0] % 15 == 0)
                {
                    ShootFire();
                }
            }

            Projectile.ai[0]++;
        }

        private NPC FindClosestNPC(float radius)
        {
            NPC closestNPC = null;
            float closestDistance = radius;

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this))
                {
                    float distance = Vector2.Distance(npc.Center, Projectile.Center);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
            }
            return closestNPC;
        }

        public void UpdateStats()
        {
            if (Level < 5)
            {
                Level++;
            }
        }
    }
}