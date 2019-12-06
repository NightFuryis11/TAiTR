using System;
using TAiTR;
using TAiTR.Dusts;
using TAiTR.Items;
using TAiTR.Items.Weapons;
using TAiTR.Projectiles;
using TAiTR.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class BoundAerGirl : ModNPC
	{
		public override string Texture => "TAiTR/NPCs/BoundAerGirl";

		public override string[] AltTextures => new[] { "TAiTR/NPCs/BoundAerGirl_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Bound Aer Girl";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            {
                DisplayName.SetDefault("Bound Aer Girl");
                Main.npcFrameCount[npc.type] = 25;
                NPCID.Sets.ExtraFramesCount[npc.type] = 9;
                NPCID.Sets.HatOffsetY[npc.type] = 4;
            }
		}

		public override void SetDefaults() {
			npc.townNPC = false;
			npc.friendly = true;
            animationType = NPCID.BoundWizard;
            npc.knockBackResist = 100f;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

        public override bool CanChat()
        {
            return true;
        }

        /*public void Transform(int newType)
        {
            newType = mod.NPCType("AerGirl");
        }*/

        public override string GetChat() {
            int lines;
			int Angler = NPC.FindFirstNPC(NPCID.Angler);
            int Goblin = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            int Mech = NPC.FindFirstNPC(NPCID.Mechanic);
            int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
            int Demo = NPC.FindFirstNPC(NPCID.Demolitionist);
            int Nurse = NPC.FindFirstNPC(NPCID.Nurse);
            LocalNPCOverride.savedAerGirl = true;
            lines = 3;
            switch (Main.rand.Next(lines))
            {
                case 0:
                    return "Thanks! Those Cuffs were really starting to hurt!";
                case 1:
                    return "Yay! I can move again!";
                default:
                    return "I can't really see you, but you aren't yelling at me, and you aren't whiping me so... You must not be from around here.";
            }
        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

        public override void SetChatButtons(ref string button, ref string button2) {
            //button2 = "Awesomeify";
            //if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
            //button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
        }
        /*public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.WaspNest>())}";
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.WaspNest>());
					return;
				}
				shop = true;
			}
			else {
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				GetInstance<ExampleMod>().ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
		}*/

            /*public override void SetupShop(Chest shop, ref int nextSlot) {
                shop.item[nextSlot].SetDefaults(ItemType<ExampleItem>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<EquipMaterial>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<BossItem>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleWorkbench>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleChair>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleDoor>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleBed>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleChest>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<ExamplePickaxe>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<ExampleHamaxe>());
                nextSlot++;
                if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
                    shop.item[nextSlot].SetDefaults(ItemType<ExampleHealingPotion>());
                    nextSlot++;
                }
                if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !GetInstance<ExampleConfigServer>().DisableExampleWings) {
                    shop.item[nextSlot].SetDefaults(ItemType<ExampleWings>());
                    nextSlot++;
                }
                if (Main.moonPhase < 2) {
                    shop.item[nextSlot].SetDefaults(ItemType<ExampleSword>());
                    nextSlot++;
                }
                else if (Main.moonPhase < 4) {
                    shop.item[nextSlot].SetDefaults(ItemType<ExampleGun>());
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.ExampleBullet>());
                    nextSlot++;
                }
                else if (Main.moonPhase < 6) {
                    shop.item[nextSlot].SetDefaults(ItemType<TheFourth>());
                    nextSlot++;
                }
                else {
                }
                // Here is an example of how your npc can sell items from other mods.
                var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
                if (modSummonersAssociation != null) {
                    shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
                    nextSlot++;
                }

                if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null)
                {
                    foreach (var item in GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList)
                    {
                        if (item.IsUnloaded)
                            continue;
                        shop.item[nextSlot].SetDefaults(item.Type);
                        shop.item[nextSlot].shopCustomPrice = 0;
                        shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
                        nextSlot++;
                        // TODO: Have tModLoader handle index issues.
                    }	
                }
            }*/


		// Make this Town NPC teleport to the King and/or Queen statue when triggered.

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		/*public override void OnGoToStatue(bool toKingStatue) {
			if (Main.netMode == NetmodeID.Server) {
				ModPacket packet = mod.GetPacket();
				packet.Write((byte)ExampleModMessageType.ExampleTeleportToStatue);
				packet.Write((byte)npc.whoAmI);
				packet.Send();
			}
			else {
				StatueTeleport();
			}
		}*/

		// Create a square of pixels around the NPC on teleport.
	}
}
