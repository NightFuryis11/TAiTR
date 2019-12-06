using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace TAiTR.Projectiles
{
	public class CloudBall : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Ball");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 6;
            projectile.timeLeft = 600;
            aiType = 14;
        }

        public override void AI()
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.25f;
            //projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                projectile.velocity.X = oldVelocity.X * -0.6f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.6f;
            }
            projectile.velocity.X = projectile.velocity.X * 0.95f;
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CloudPuff>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Vector2 position = projectile.Center;
            //Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
        }
    }
}