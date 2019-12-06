using Terraria;
using Terraria.ModLoader;
using System.Linq;

namespace TAiTR.Buffs
{
    public class OffKey : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Off-key");
            Description.SetDefault("You can't stand that pitch.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 15;
            player.moveSpeed = 14;
        }
    }
}
