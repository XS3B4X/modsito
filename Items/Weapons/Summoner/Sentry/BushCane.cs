using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Modsito.Projectiles.Sentry;
using System.Numerics;

namespace Modsito.Items.Weapons.Summoner.Minion
{
    internal class BushCane : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Summon;
            Item.width = 20;
            Item.height = 20;
            Item.damage = 7;
            Item.knockBack = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 39);
            Item.UseSound = SoundID.Item2;
            Item.shoot = ModContent.ProjectileType<BushCaneSentry>();
            Item.sentry = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 20);
            recipe1.AddTile(TileID.LivingLoom);
            recipe1.Register();
        }
    }
}
