using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR.Items.Weapons
{
	public class TheBatton : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Batton");
			Tooltip.SetDefault("'Stolen off a music man.'");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
