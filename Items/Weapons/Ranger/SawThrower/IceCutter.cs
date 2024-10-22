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
    public class IceCutter : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ice Cutter");
            // Tooltip.SetDefault("Throws two frozen saws at once, Inflicts FrostBurn");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.knockBack = 2.5f;
            Item.damage = 65;
            Item.width = 21;
            Item.height = 21;
            Item.useAnimation = 20;
            Item.useTime = 10;
            Item.reuseDelay = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 22f;
            Item.UseSound = SoundID.Item1;
            Item.value = 5500;
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SawBladeProjectile>();
            Item.useAmmo = ModContent.ItemType<SawBlade>();
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.TitaniumBar, 15);
            recipe1.AddIngredient(ItemID.FrostCore, 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.AdamantiteBar, 15);
            recipe2.AddIngredient(ItemID.FrostCore, 1);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 1f);
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.Frostburn, 60 * 2);
        }
    }
}
