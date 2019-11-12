using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR.Items.Weapons
{
	public class BreadstickSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Breadstick Sword");
			Tooltip.SetDefault("Looks pretty stale.");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hay, 30);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
