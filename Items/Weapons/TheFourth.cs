using TAiTR.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TAiTR.Items.Weapons
{
	public class TheFourth : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Fourth");
			Tooltip.SetDefault("The weapon's damage increases with the speed of its fall.\n'Pretty colors!'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
            item.damage = 20;
			item.magic = true;
			item.mana = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<Firework>();
			item.shootSpeed = 8f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Stardust>(), 20);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddTile(TileID.Bookcases);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ProjectileType<Projectiles.Firework3>(), ProjectileType<Projectiles.Firework2>(), ProjectileType<Projectiles.Firework4>(), ProjectileType<Projectiles.Firework5>() });
			return true;
		}
	}
}