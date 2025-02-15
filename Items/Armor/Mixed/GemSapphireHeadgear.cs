using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Armor.Mixed
{
    [AutoloadEquip(EquipType.Head)]
    internal class GemSapphireHeadgear : ModItem
    {
        public static readonly int damageBonus = 13;
        public static readonly int manaCostReductionBonus = 10;
        public static readonly int critChanceSetBonus = 5;
        public static readonly int maxManaSetBonus = 60;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, manaCostReductionBonus);
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults()
        {
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(critChanceSetBonus, maxManaSetBonus);

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 30, copper: 90);
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) *= 1 + (damageBonus / 100f);
            player.manaCost *= 1 - (manaCostReductionBonus / 100f);
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GemChestplate>() && legs.type == ModContent.ItemType<GemLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.GetCritChance(DamageClass.Magic) += critChanceSetBonus;
            player.statManaMax2 += maxManaSetBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Sapphire, 4);
            recipe1.AddIngredient(ItemID.Diamond, 1);
            recipe1.AddIngredient(ItemID.StoneBlock, 8);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
