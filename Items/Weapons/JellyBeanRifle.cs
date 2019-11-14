using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR.Items.Weapons
{
	public class JellyBeanRifle : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Bean Rifle");
			Tooltip.SetDefault("Shoots rather squishy things.");
		}

		public override void SetDefaults() {
			item.damage = 67;
			item.ranged = true;
			item.width = 72;
			item.height = 22;
			item.useTime = 34;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 25000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = mod.ItemType("Bean");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
