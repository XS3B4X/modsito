using Microsoft.Xna.Framework;
using Modsito.Items.Weapons.Ranger.Ammo.Saws;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Modsito.Projectiles.Ammo.Saws;

namespace Modsito.Items.Weapons.Ranger.SawThrower
{
    public class ClorophiteSawLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.knockBack = 2.5f;
            Item.damage = 70;
            Item.width = 21;
            Item.height = 21;
            Item.useAnimation = 20;
            Item.useTime = 8;
            Item.reuseDelay = 30;
            Item.consumeAmmoOnFirstShotOnly = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 26f;
            Item.UseSound = SoundID.Item1;
            Item.value = 7250;
            Item.rare = ItemRarityID.Pink;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.useAmmo = ModContent.ItemType<SawBlade>();
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 1f);
        }
    }
}
