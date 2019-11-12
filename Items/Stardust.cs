using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR.Items
{
	public class Stardust : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'You sense some vague magical power...'");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 28;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar);
            		recipe.AddIngredient(ItemID.Bottle);
            		recipe.AddTile(TileID.Bottles);
            		recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
