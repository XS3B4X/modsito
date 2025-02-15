using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Armor.Mixed
{
    [AutoloadEquip(EquipType.Head)]
    internal class GemAmberHood : ModItem
    {
        public static readonly int damageBonus = 15;
        public static readonly int minionKnockbackBonus = 1;
        public static readonly int minionSentrySetBonus = 1;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(damageBonus);
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults()
        {
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(minionSentrySetBonus);

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 32, copper: 40);
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) *= 1 + (damageBonus / 100f);
            player.GetKnockback(DamageClass.Summon) += minionKnockbackBonus;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GemChestplate>() && legs.type == ModContent.ItemType<GemLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.maxMinions += minionSentrySetBonus;
            player.maxTurrets += minionSentrySetBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Topaz, 4);
            recipe1.AddIngredient(ItemID.Diamond, 1);
            recipe1.AddIngredient(ItemID.StoneBlock, 8);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}
