using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TAiTR.Dusts.Blocks;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Tiles
{
	public class ZincOre : ModTile
	{
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 215;
            Main.tileShine2[Type] = false;
            Main.tileShine[Type] = 975;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Zinc");
            AddMapEntry(new Color(107, 117, 124), name);
            dustType = 82;
            drop = ItemType<Items.Placeable.ZincOre>();
			soundType = 21;
			soundStyle = 1;
			mineResist = 1f;
		}
	}
}