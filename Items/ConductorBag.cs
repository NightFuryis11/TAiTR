using TAiTR.Items.Weapons;
using TAiTR.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.Items
{
	public class ConductorBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 11;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			int choice = Main.rand.Next(7);
			if (choice == 0) {
				player.QuickSpawnItem(ItemType<TheBatton>());
			}
			else if (choice == 1) {
				player.QuickSpawnItem(ItemType<TheBatton>());
			}
			if (choice != 1) {
				player.QuickSpawnItem(ItemType<TheBatton>());
			}
			player.QuickSpawnItem(ItemType<TheBatton>());
		}

		public override int BossBagNPC => NPCType<TheConductor>();
	}
}