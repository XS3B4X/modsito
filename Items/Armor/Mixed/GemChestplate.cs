using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Armor.Mixed
{
    [AutoloadEquip(EquipType.Body)]
    internal class GemChestplate : ModItem
    {
        public static readonly int damageBonus = 3;
        public static readonly int critChanceBonus = 3;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, critChanceBonus);
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 35, copper: 24);
            Item.defense = 4;
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) *= 1 + (damageBonus / 100f);
            player.GetCritChance(DamageClass.Generic) += critChanceBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Diamond, 3);
            recipe1.AddIngredient(ItemID.StoneBlock, 15);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
