using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static System.Net.Mime.MediaTypeNames;

namespace Modsito.Items.Accessories.Damage
{
    internal class ReinforcedBowString : ModItem
    {
        public static readonly int additiveDamageBonus = 10;
        public static readonly int attackSpeedBonus = 20;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(additiveDamageBonus, attackSpeedBonus);
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
            player.GetModPlayer<BowDamagePlayer>().HasReinforcedBowString = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Cobweb, 15);
            recipe1.AddTile(TileID.Loom);
            recipe1.Register();
        }
    }
    public class BowDamagePlayer : ModPlayer
    {
        public bool HasReinforcedBowString = false;
        public override void ResetEffects()
        {
            HasReinforcedBowString = false;
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (HasReinforcedBowString && item.useAmmo == AmmoID.Arrow)
            {
                damage *= 1.10f; // +10% daño solo para arcos
            }
        }
        public override void PostUpdate()
        {
            if (HasReinforcedBowString && Main.LocalPlayer.HeldItem.useAmmo == AmmoID.Arrow)
            {
                Item heldItem = Main.LocalPlayer.HeldItem;

                if (!heldItem.TryGetGlobalItem(out BowGlobalItem bowStats))
                {
                    heldItem.GetGlobalItem<BowGlobalItem>().ApplyModifiers(heldItem);
                }
            }
        }
    }
    public class BowGlobalItem : GlobalItem
    {
        private bool modified = false;
        public void ApplyModifiers(Item item)
        {
            if (!modified && item.useAmmo == AmmoID.Arrow)
            {
                item.useTime = (int)(item.useTime * 0.80f); // Reduce un 20% el tiempo de uso
                item.useAnimation = (int)(item.useAnimation * 0.80f);
                modified = true;
            }
        }
    }
}
