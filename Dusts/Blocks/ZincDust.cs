using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace TAiTR.Dusts.Blocks
{
	public class ZincDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}

        public virtual Color? GetAlpha(Dust dust, Color red)
        {
            return null;
        }

    }
}