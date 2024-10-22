using Microsoft.Xna.Framework;
using Modsito.Items.Weapons.Ranger.Ammo.Saws;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Modsito.Projectiles.Ammo.Saws;
using Terraria.DataStructures;

namespace Modsito.Items.Weapons.Ranger.SawThrower
{
    public class MoltenLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.knockBack = 3.5f;
            Item.damage = 40;
            Item.width = 60;
            Item.height = 24;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 18f;
            Item.UseSound = SoundID.Item1;
            Item.value = 3750;
            Item.rare = ItemRarityID.Orange;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.useAmmo = ModContent.ItemType<SawBlade>();
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.HellstoneBar, 20);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 1f);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ModContent.ProjectileType<SawBladeProjectile>())
            {
                type = ModContent.ProjectileType<BlazingSawBladeProjectile>();
            }
        }
    }
}
