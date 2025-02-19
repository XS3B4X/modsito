using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Buffs
{
    public class AmberWhipDebuff : ModBuff
    {
        public override string Texture => "Modsito/Buffs/WhipTagDamageDebuff";
        public static readonly int tagDamage = 5;
    }

    public class AmberWhipTagDebuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            if (npc.HasBuff<AmberWhipDebuff>())
            {
                modifiers.FlatBonusDamage += AmberWhipDebuff.tagDamage;
            }
        }
    }
}
