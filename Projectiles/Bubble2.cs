using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Projectiles
{
	public class Bubble2 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubble");
        }
        public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
		}

		public override void AI() {
			if (Main.rand.NextBool(50)) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<MiniBubble>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.velocity = projectile.velocity * 0.95f;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.damage = 40;
        }

		public override bool OnTileCollide(Vector2 oldVelocity) {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                projectile.velocity.X = oldVelocity.X * -0.5f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.5f;
            }
            return false;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 3; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<MiniBubble>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item54, (int)position.X, (int)position.Y);
            for (int i = 0; i < 2; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3));
                Projectile.NewProjectile(projectile.Center, vel, ProjectileType<Bubble3>(), projectile.damage, projectile.knockBack, projectile.owner, 0, 1);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            projectile.Kill();
        }
    }
}