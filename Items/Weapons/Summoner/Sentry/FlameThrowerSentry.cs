using Microsoft.Xna.Framework;
using Modsito.Projectiles.Sentry;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Items.Weapons.Summoner.Sentry
{
    public class FlameThrowerSentry : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Summon;
            Item.noMelee = true;
            Item.knockBack = 1f;
            Item.damage = 23;
            Item.width = 20;
            Item.height = 20;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.DD2_DefenseTowerSpawn;
            Item.value = Item.buyPrice(gold: 2, silver:39);
            Item.rare = ItemRarityID.Pink;
            Item.autoReuse = true;
            Item.ArmorPenetration = 15;

            Item.shoot = ModContent.ProjectileType<FlameThrowerSentryProjectile>();
            Item.shootSpeed = 0f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            FlameThrowerSentryProjectile sentry = null;

            // Buscar si ya existe la torreta lanzallamas
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI
                    && Main.projectile[i].type == ModContent.ProjectileType<FlameThrowerSentryProjectile>())
                {
                    sentry = Main.projectile[i].ModProjectile as FlameThrowerSentryProjectile;
                    break;
                }
            }

            // Si ya hay una torreta lanzallamas, mejorarla o resetear si está en nivel 5
            if (sentry != null)
            {
                player.maxTurrets--;
                if (sentry.Level < 5)
                {
                    // **Eliminar una torreta existente (cualquiera) antes de mejorar**
                    foreach (Projectile proj in Main.projectile)
                    {
                        if (proj.active && proj.owner == player.whoAmI && proj.sentry && proj.type != ModContent.ProjectileType<FlameThrowerSentryProjectile>())
                        {
                            proj.Kill();
                            break; // Solo eliminar UNA torreta
                        }
                    }

                    // Mejorar la torreta y reducir un slot
                    sentry.UpdateStats();
                    player.maxTurrets--;
                }
                else
                {
                    // **Si está en nivel 5, eliminar todas las torretas y reiniciar**
                    foreach (Projectile proj in Main.projectile)
                    {
                        if (proj.active && proj.owner == player.whoAmI && proj.sentry)
                        {
                            proj.Kill();
                        }
                    }

                    // Invocar una nueva torreta
                    Vector2 spawnPosition = Main.MouseWorld;
                    int index = Projectile.NewProjectile(source, spawnPosition.X, spawnPosition.Y,
                        0, 0, type, damage, knockback, player.whoAmI);

                    if (index >= 0)
                    {
                        FlameThrowerSentryProjectile newSentry = Main.projectile[index].ModProjectile as FlameThrowerSentryProjectile;
                        if (newSentry != null)
                        {
                            newSentry.Level = 0;
                            newSentry.UpdateStats();
                        }
                    }
                }

                return false;
            }

            // Si no hay torreta lanzallamas, invocar una nueva
            Vector2 spawnPos = Main.MouseWorld;
            int newIndex = Projectile.NewProjectile(source, spawnPos.X, spawnPos.Y, 0, 0, type, damage, knockback, player.whoAmI);

            if (newIndex >= 0)
            {
                FlameThrowerSentryProjectile newSentry = Main.projectile[newIndex].ModProjectile as FlameThrowerSentryProjectile;
                if (newSentry != null)
                {
                    newSentry.Level = 0;
                    newSentry.UpdateStats();
                }
            }
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true; // Permite el uso alternativo (click derecho)
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // Click derecho
            {
                SelectTarget(player);
                return false; // Evita que se dispare normalmente
            }
            return true;
        }

        private void SelectTarget(Player player)
        {
            NPC closestNPC = null;
            float maxDetectRadius = 400f; // Radio de selección
            float closestDistance = maxDetectRadius;

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy())
                {
                    float distance = Vector2.Distance(npc.Center, Main.MouseWorld);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
            }

            if (closestNPC != null)
            {
                // Marcar al enemigo como objetivo de la torreta
                foreach (Projectile proj in Main.projectile)
                {
                    if (proj.active && proj.owner == player.whoAmI && proj.ModProjectile is FlameThrowerSentryProjectile sentry)
                    {
                        sentry.SetTarget(closestNPC);
                    }
                }
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(1f, 1f);
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.HallowedBar, 12);
            recipe1.AddIngredient(ItemID.SoulofFright, 18);
            recipe1.AddIngredient(ItemID.LivingFireBlock, 25);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
    }
}