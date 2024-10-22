using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Modsito.Items.Accessories.Damage
{
    internal class ReinforcedBowString : ModItem
    {
        public static readonly int AdditiveDamageBonus = 10;
        public static readonly int AttackSpeedBonus = 20;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus, AttackSpeedBonus);
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += AdditiveDamageBonus / 100f;
            player.GetAttackSpeed(DamageClass.Ranged) += AttackSpeedBonus / 100f;
        }
    }
}
