using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Projectiles
{
	public class FinaleBolt : ModProjectile
	{
        private double explosion;
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 11;
            DisplayName.SetDefault("Finale");
        }

        public override void SetDefaults() {
			projectile.width = 10;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (projectile.velocity.Y <= 0)
            {
                projectile.damage = 45;
            }
            else
            {
                projectile.damage = ((int)projectile.velocity.Y * 2) + 45;
            }
            if (++projectile.frameCounter >= 5)
            {

                projectile.frameCounter = 0;

                if (++projectile.frame >= 11)
                {

                    projectile.frame = 0;
                }
            }
            if (explosion == 1)
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
                projectile.width = 100;
                projectile.height = 100;
                projectile.Center = projectile.position;
                drawOffsetX = 50;
                drawOriginOffsetY = 50;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            explosion += 1;
            return false;
        }

		public override void Kill(int timeLeft) {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Sparkle>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
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

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            explosion += 1;
        }
    }
}