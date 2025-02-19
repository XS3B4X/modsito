using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Buffs
{
    public class DarkCrystalWhipDebuff : ModBuff
    {
        public override string Texture => "Modsito/Buffs/WhipTagDamageDebuff";
        public static readonly int tagDamage = 3;
        public static readonly int tagCritChance = 4;
    }

    public class DarkCrystalWhipTagDebuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            if (npc.HasBuff<AmberWhipDebuff>())
            {
                modifiers.FlatBonusDamage += AmberWhipDebuff.tagDamage;
            }

            if (Main.rand.Next(100) < DarkCrystalWhipDebuff.tagCritChance)
            {
                modifiers.SetCrit();
            }
        }
    }
}
