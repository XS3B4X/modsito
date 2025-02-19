using Modsito.Projectiles.Whip;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Items.Weapons.Summoner.Whip
{
    internal class AmberWhip : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.width = 36;
            Item.height = 34;
            Item.damage = 16;
            Item.knockBack = 2;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.shootSpeed = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;   
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item152;
            Item.value = Item.sellPrice(silver: 73);
            Item.shoot = ModContent.ProjectileType<AmberWhipProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Amber, 5);
            recipe1.AddIngredient(ItemID.FossilOre, 12);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}
