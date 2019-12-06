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
	public class GreenShard : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Shard");
        }

        public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 18;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle3>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.expertMode == !true)
            {
                projectile.damage = 30;
            }
            else
            {
                projectile.damage = 25;
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
        }
    }
}