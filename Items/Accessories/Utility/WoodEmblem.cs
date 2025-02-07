using System.Xml;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Utility
{
    internal class WoodEmblem : ModItem
    {
        public static readonly int SentryMinionCount = 1;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SentryMinionCount);
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(silver: 10);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxTurrets += SentryMinionCount;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.RichMahogany, 10);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
    }
}