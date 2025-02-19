using Modsito.Projectiles.Whip;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Items.Weapons.Summoner.Whip
{
    internal class DarkCrystalWhip : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.width = 36;
            Item.height = 36;
            Item.damage = 31;
            Item.knockBack = 2;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.shootSpeed = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Orange;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item152;
            Item.value = Item.sellPrice(gold: 1, silver: 34);
            Item.shoot = ModContent.ProjectileType<DarkCrystalWhipProjectile>();
        }

        public override bool MeleePrefix()
        {
            return true;
        }
    }

    //Prepara el arma en el Loot de los cofres de la mazmorra
    public class DarkCrystalWhipChestLootSystem : ModSystem
    {
        public override void PostWorldGen()
        {
            int[] dungeonWeapons =
            {
                ItemID.Muramasa,
                ItemID.Handgun,
                ItemID.AquaScepter,
                ItemID.MagicMissile,
                ItemID.BlueMoon
            };

            int maxReplacements = 3;
            int replacementsDone = 0;

            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                    continue;

                Tile chestTile = Main.tile[chest.x, chest.y];

                // 2 * 36 = Cofre con llave de la mazmorra
                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 2 * 36)
                {
                    // Si ya se han hecho suficientes reemplazos, salir del bucle
                    if (replacementsDone >= maxReplacements)
                        break;

                    for (int slot = 0; slot < Chest.maxItems; slot++)
                    {
                        if (chest.item[slot].type != ItemID.None && dungeonWeapons.Contains(chest.item[slot].type))
                        {
                            // Reemplazar el arma con el DarkCrystalWhip
                            chest.item[slot].SetDefaults(ModContent.ItemType<DarkCrystalWhip>());
                            replacementsDone++;
                            break; // Solo reemplazar una arma por cofre
                        }
                    }
                }
            }
        }
    }
}
