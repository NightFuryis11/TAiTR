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
	public class PurpleLight : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Light");
        }

        public override void SetDefaults() {
			projectile.width = 26;
			projectile.height = 26;
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
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<PurpleTrail>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.rotation += 0.1f;
            projectile.velocity.X = projectile.velocity.X / (int)1.8;
            projectile.velocity.Y += 0.02f;
            if (Main.expertMode == true)
            {
                projectile.damage = (int)21.25;
            }
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft) {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<PurpleTrail>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}