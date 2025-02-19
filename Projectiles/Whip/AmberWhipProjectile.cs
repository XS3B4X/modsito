using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Modsito.Buffs;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modsito.Projectiles.Whip
{
    public class AmberWhipProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true;
            Projectile.DefaultToWhip();
            Projectile.WhipSettings.Segments = 18;
            Projectile.WhipSettings.RangeMultiplier = 0.9f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<AmberWhipDebuff>(), 240);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            Projectile.damage = (int)(Projectile.damage * 0.65f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            List<Vector2> whipPoints = new List<Vector2>();
            Projectile.FillWhipControlPoints(Projectile, whipPoints);

            Texture2D whipTexture = TextureAssets.Projectile[Projectile.type].Value;

            // **Definir las secciones de la textura**
            Rectangle handleFrame = new Rectangle(0, 0, 10, 28);  // Mango (10x28)
            Rectangle segmentFrame = new Rectangle(0, 28, 10, 12); // Segmentos centrales (10x12)
            Rectangle tipFrame = new Rectangle(0, 40, 10, 16);     // Punta (10x18)

            for (int i = 0; i < whipPoints.Count - 1; i++)
            {
                Vector2 current = whipPoints[i];
                Vector2 next = whipPoints[i + 1];
                Vector2 diff = next - current;
                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(current.ToTileCoordinates(), Color.White);
                Vector2 scale = new Vector2(1f, 1f);

                // **Dibujar el mango (primer segmento)**
                if (i == 0)
                {
                    Vector2 origin = new Vector2(5, 0); // Punto de origen en la base del mango
                    Main.EntitySpriteDraw(whipTexture, current - Main.screenPosition, handleFrame, color, rotation, origin, scale, SpriteEffects.None, 0);
                }
                // **Dibujar los segmentos centrales (segmentos intermedios)**
                else if (i < whipPoints.Count - 2)
                {
                    Vector2 origin = new Vector2(5, 0); // Conectar desde la parte superior del segmento anterior
                    Main.EntitySpriteDraw(whipTexture, current - Main.screenPosition, segmentFrame, color, rotation, origin, scale, SpriteEffects.None, 0);
                }
                // **Dibujar la punta (último segmento)**
                else
                {
                    Vector2 origin = new Vector2(5, 0); // Conectar la punta con el último segmento
                    Vector2 tipScale = new Vector2(1.3f, 1.3f);
                    Main.EntitySpriteDraw(whipTexture, current - Main.screenPosition, tipFrame, color, rotation, origin, tipScale, SpriteEffects.None, 0);
                }
            }

            return false; // Evita el dibujo predeterminado
        }
    }
}