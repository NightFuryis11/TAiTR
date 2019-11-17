using Terraria.ModLoader;

namespace TAiTR.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PinkGlasses : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 10;
            item.rare = 1;
            item.vanity = true;
        }

        public override bool DrawHead()
        {
            return true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            drawAltHair = false;
            return;
        }
    }
}