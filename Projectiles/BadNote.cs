using TAiTR.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Projectiles
{
	public class BadNote : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bad Note");
        }
        public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 18;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 450;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle4>(), 0f, 0f);
            }
            if (Main.expertMode == true)
            {
                projectile.damage = (int)23.75;
            }
            else
            {
                projectile.damage = 30;
            }
            projectile.tileCollide = false;
        }


        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle4>(), projectile.oldVelocity.X * 0.001f, projectile.oldVelocity.Y * 0.001f);
            }
        }
    }
}