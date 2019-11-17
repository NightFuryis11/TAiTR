using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Projectiles
{
	public class FluteNote3 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Note");
        }
        public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 450;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle>(), 0f, 0f);
            }
            projectile.damage = 42;
            projectile.tileCollide = false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                projectile.velocity.X = oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle>(), projectile.oldVelocity.X * 0.001f, projectile.oldVelocity.Y * 0.001f);
            }
            Vector2 position = projectile.Center;
            Main.PlaySound(0, (int)position.X, (int)position.Y);
        }
    }
}