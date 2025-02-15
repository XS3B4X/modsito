using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Summoner
{
    internal class AmberEmblem : ModItem
    {
        public static readonly int damageBonus = 5;
        public static readonly int tagDamageBonus = 3;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, tagDamageBonus);
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1, silver: 14);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) *= 1 + (damageBonus / 100f);
            player.GetModPlayer<WhipExtensionPlayer>().tagDamage += tagDamageBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 15);
            recipe1.AddIngredient(ItemID.Amber, 2);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
    }
    public class WhipExtensionPlayer : ModPlayer
    {
        public int tagDamage = 0;

        public override void ResetEffects()
        {
            tagDamage = 0;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            // Verifica si el proyectil es un látigo
            if (proj.DamageType == DamageClass.SummonMeleeSpeed && proj.aiStyle == ProjAIStyleID.Whip)
            {
                // Aplica el Tag Damage adicional
                modifiers.SourceDamage.Base += tagDamage;
            }
        }
    }
}