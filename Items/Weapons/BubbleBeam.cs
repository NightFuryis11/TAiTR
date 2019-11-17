using TAiTR.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TAiTR.Items.Weapons
{
	public class BubbleBeam : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bubble Beam");
			Tooltip.SetDefault("'Clean your enemies' act up!'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
            item.damage = 45;
			item.magic = true;
			item.mana = 6;
			item.width = 28;
			item.height = 30;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 80000;
			item.rare = 8;
			item.UseSound = SoundID.Item85;
			item.autoReuse = true;
			item.shoot = ProjectileType<Bubble1>();
			item.shootSpeed = 16f;
            item.crit = -8;
		}

		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WaterBolt, 1);
            recipe.AddIngredient(ItemID.SpectreBar, 10);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}