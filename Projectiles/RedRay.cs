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
	public class RedRay : ModProjectile
	{
        int[] projAI = new int[111];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Ray");
        }

        public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 40;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 350;
		}

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<NoteSparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            projectile.rotation = projectile.velocity.ToRotation();

            if (Main.expertMode == true)
            {
                projectile.damage = 15;
            }
            projectile.tileCollide = false;

            int num90 = 0;
            num90 = Player.FindClosest(projectile.Center, 1, 1);
            projAI[1] += 1;
            if (projAI[1] < 110f && projAI[1] > 30f)
            {
                float scaleFactor2 = projectile.velocity.Length();
                Vector2 vector8 = Main.player[num90].Center - projectile.Center;
                vector8.Normalize();
                vector8 *= scaleFactor2;
                projectile.velocity = (projectile.velocity * 25f + vector8) / 5f;
                projectile.velocity.Normalize();
                projectile.velocity = projectile.velocity * (scaleFactor2 + ((projAI[1] - 30) / 1000));
            }
        }

        /*public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Skull;
            return true;
        }*/
    }
}