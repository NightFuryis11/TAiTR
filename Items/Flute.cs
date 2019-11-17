using TAiTR.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Items
{
    public class Flute : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flute");
        }

        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 8;
            item.useTime = 14;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.value = 8000;
            item.rare = 3;
            item.autoReuse = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/Weapons/Flute").WithPitchVariance(0.2f);
        }
    }
}
