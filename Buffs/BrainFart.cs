using Terraria;
using Terraria.ModLoader;
using System.Linq;

namespace TAiTR.Buffs
{
    public class BrainFart : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Brain Fart");
            Description.SetDefault("You have forgotten how your weapons work.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamageMult = 0.9f;
        }
    }
}
