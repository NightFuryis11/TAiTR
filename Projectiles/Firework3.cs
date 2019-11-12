using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace TAiTR.Projectiles
{
	public class Firework3 : ModProjectile
	{
        private double explosion;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<GreenTrail>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (projectile.velocity.Y <= 0)
            {
                projectile.damage = 20;
            }
            else
            {
                projectile.damage = (int)projectile.velocity.Y + 20;
            }
            if (explosion > 0.9f && explosion < 1.1f)
            {
                projectile.timeLeft = 3;
                explosion = 2;
                projectile.tileCollide = false;
                projectile.direction = projectile.oldDirection;
                projectile.velocity = projectile.oldVelocity;
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.position = projectile.Center;
                //projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                //projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 80;
                projectile.height = 80;
                projectile.Center = projectile.position;
                //projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                //projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                drawOffsetX = 40;
                drawOriginOffsetY = 40;
                //projectile.direction = projectile.oldDirection;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            explosion += 1;
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<GreenTrail>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            explosion = 0;
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 10;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            explosion += 1;
        }
    }
}