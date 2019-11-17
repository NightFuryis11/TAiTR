using TAiTR.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Items.Weapons
{
    public class MagicalFlute : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Flute");
        }

        public override void SetDefaults()
        {
            item.damage = 42;
            item.magic = true;
            item.mana = 5;
            item.width = 46;
            item.height = 8;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.value = 12000;
            item.rare = 5;
            item.autoReuse = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/Weapons/Flute").WithPitchVariance(0.2f);
            item.shoot = ProjectileType<FluteNote>();
            item.shootSpeed = 10f;
            item.knockBack = 1;
            item.crit = -12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Flute>(), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.PixieDust, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = Main.rand.Next(new int[] { type, ProjectileType<Projectiles.FluteNote2>(), ProjectileType<Projectiles.FluteNote3>() });
            return true;
        }
    }
}
