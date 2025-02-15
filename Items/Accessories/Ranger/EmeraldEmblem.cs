using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Ranger
{
    internal class EmeraldEmblem : ModItem
    {
        public static readonly int damageBonus = 5;
        public static readonly int ammoReservationBonus = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, ammoReservationBonus);
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
            player.GetDamage(DamageClass.Ranged) *= 1 + (damageBonus / 100f);
            player.GetModPlayer<ammoReservation>().ammoChance += ammoReservationBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 15);
            recipe1.AddIngredient(ItemID.Emerald, 2);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
    }
    public class ammoReservation : ModPlayer
    {
        public float ammoChance = 0;
        public override void ResetEffects()
        {
            ammoChance = 0f;
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            if (Main.rand.NextFloat() < (ammoChance / 100f))
            {
                return false;
            }
            return true;
        }
    }
}