using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Magic
{
    internal class SapphireEmblem : ModItem
    {
        public static readonly int damageBonus = 5;
        public static readonly int maxManaBonus = 20;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, maxManaBonus);
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
            player.GetDamage(DamageClass.Magic) *= 1 + (damageBonus / 100f);
            player.statManaMax2 += maxManaBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 15);
            recipe1.AddIngredient(ItemID.Sapphire, 2);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
    }
}