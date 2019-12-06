using Terraria;
using Terraria.ModLoader;

namespace TAiTR.Dusts
{
	public class NoteSparkle4 : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.85f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, 0.17f, 0.89f, 0.89f);
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}