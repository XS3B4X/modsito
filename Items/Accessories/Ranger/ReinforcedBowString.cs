using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Ranger
{
    internal class ReinforcedBowString : ModItem
    {
        public static readonly int AttackSpeedBonus = 20;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AttackSpeedBonus);
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(silver: 37, copper: 85);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.HeldItem.useAmmo == AmmoID.Arrow)
            {
                player.GetAttackSpeed(DamageClass.Ranged) += AttackSpeedBonus / 100f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Cobweb, 25);
            recipe1.AddTile(TileID.Loom);
            recipe1.Register();
        }
    }
}
