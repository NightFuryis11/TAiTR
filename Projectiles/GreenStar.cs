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
	public class GreenStar : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Star");
        }

        public override void SetDefaults() {
			projectile.width = 38;
			projectile.height = 38;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 170;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle3>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.rotation += 0.1f;
            if (Main.expertMode == !true)
            {
                projectile.damage = (int)12.5;
            }
            else
            {
                projectile.damage = 10;
            }
            projectile.tileCollide = false;
        }


		public override void Kill(int timeLeft) {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle3>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item27, (int)position.X, (int)position.Y);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -15, ProjectileType<GreenShard>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 15, ProjectileType<GreenShard>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 15, 0, ProjectileType<GreenShard>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -15, 0, ProjectileType<GreenShard>(), 0, 3f);
        }
    }
}