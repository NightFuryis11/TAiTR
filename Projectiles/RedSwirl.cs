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
	public class RedSwirl : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Swirl");
        }

        public override void SetDefaults() {
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 150;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.rotation -= 0.1f;
            if (Main.expertMode == true)
            {
                projectile.damage = (int)11.25;
            }
            projectile.tileCollide = false;
        }


		public override void Kill(int timeLeft) {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -4, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 4, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4, 0, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4, 0, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4, -4, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4, 4, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4, -4, ProjectileType<RedRay>(), 0, 3f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4, 4, ProjectileType<RedRay>(), 0, 3f);
        }
    }
}