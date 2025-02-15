using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Armor.Mixed
{
    [AutoloadEquip(EquipType.Head)]
    internal class GemRubyMask : ModItem
    {
        public static readonly int damageBonus = 11;
        public static readonly int critChanceBonus = 5;
        public static readonly int meleeSpeedSetBonus = 12;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus, critChanceBonus);
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults()
        {
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(meleeSpeedSetBonus);

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 30, copper: 90);
            Item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) *= 1 + (damageBonus / 100f);
            player.GetCritChance(DamageClass.Melee) += critChanceBonus;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GemChestplate>() && legs.type == ModContent.ItemType<GemLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.GetAttackSpeed(DamageClass.Melee) += (meleeSpeedSetBonus / 100f);
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Ruby, 4);
            recipe1.AddIngredient(ItemID.Diamond, 1);
            recipe1.AddIngredient(ItemID.StoneBlock, 8);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
