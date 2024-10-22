using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Modsito.Projectiles.Ammo.Saws;
using Terraria.Localization;

namespace Modsito.Items.Weapons.Ranger.Ammo.Saws
{
    public class SawBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 5;
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.value = 1100;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.ammo = Item.type;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe(25);
            recipe1.AddIngredient(ItemID.LeadBar, 5);
            recipe1.AddTile(TileID.Anvils);
            recipe1.HasResult(25);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe(25);
            recipe2.AddIngredient(ItemID.IronBar, 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.HasResult(25);
            recipe2.Register();
        }
    }
}
