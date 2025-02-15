using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Melee
{
    internal class RubyEmblem : ModItem
    {
        public static readonly int damageBonus = 5;
        public static readonly int weaponSizeBonus = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, weaponSizeBonus);
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
            player.GetDamage(DamageClass.Melee) *= 1 + (damageBonus / 100f);
            player.GetAttackSpeed(DamageClass.Melee) *= 1 + (weaponSizeBonus / 100f);
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 15);
            recipe1.AddIngredient(ItemID.Ruby, 2);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
    }
    public class MeleeScalePlayer : ModPlayer
    {
        public float weaponSizeBonus = 0f;
        public override void ResetEffects()
        {
            weaponSizeBonus = 0f;
        }
        public override void ModifyItemScale(Item item, ref float scale)
        {
            if (item.DamageType == DamageClass.Melee)
            {
                scale *= 1 + (weaponSizeBonus / 100f);
            }
        }
    }
}