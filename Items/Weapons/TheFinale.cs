using TAiTR.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TAiTR.Items.Weapons
{
	public class TheFinale : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Finale");
			Tooltip.SetDefault("The weapon's damage increases with the speed of its fall\n'Killer colors!'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
            item.damage = 45;
			item.magic = true;
			item.mana = 7;
			item.width = 28;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 20000;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<FinaleBolt>();
			item.shootSpeed = 10f;
            item.crit = -12;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<TheFourth>(), 1);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<TheFourth>(), 1);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}