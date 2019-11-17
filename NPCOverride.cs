using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TAiTR
{
    class NPCOverride : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Wizard:

                    if (Main.hardMode == true);
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType("Flute"));
                        nextSlot++;
                    }
                    break;
            }
        }
    }
}
