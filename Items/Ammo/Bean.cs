using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR.Items.Ammo
{
	public class Bean : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Bean");
			Tooltip.SetDefault("Looks a bit squishy.");
		}

		public override void SetDefaults() {
			item.damage = 7;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("Bean");
			item.shootSpeed = 16f;
			item.ammo = item.type;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(ItemID.UnicornHorn, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
