using Microsoft.Xna.Framework;
using Modsito.Items.Weapons.Ranger.Ammo.Saws;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Modsito.Projectiles.Ammo.Saws;

namespace Modsito.Items.Weapons.Ranger.SawThrower
{
    public class SawThrower : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.knockBack = 3f;
            Item.damage = 25;
            Item.width = 55;
            Item.height = 21;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 14f;
            Item.UseSound = SoundID.Item1;
            Item.value = 1250;
            Item.rare = ItemRarityID.Blue;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.useAmmo = ModContent.ItemType<SawBlade>();
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.LeadBar, 12);
            recipe1.AddIngredient(ItemID.Diamond, 3);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.IronBar, 12);
            recipe2.AddIngredient(ItemID.Diamond, 3);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 1f);
        }
    }
}
