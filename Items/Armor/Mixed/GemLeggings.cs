using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Armor.Mixed
{
    [AutoloadEquip(EquipType.Legs)]
    internal class GemLeggings : ModItem
    {
        public static readonly int damageBonus = 5;
        public static readonly int speedBonus = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, speedBonus);
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 30, copper: 90);
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) *= 1 + (damageBonus / 100f);
            player.maxRunSpeed += speedBonus / 100f;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Diamond, 2);
            recipe1.AddIngredient(ItemID.StoneBlock, 10);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
