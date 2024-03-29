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
	public class AerGirl : ModNPC
	{
		public override string Texture => "TAiTR/NPCs/AerGirl";

		public override string[] AltTextures => new[] { "TAiTR/NPCs/AerGirl_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Aer Girl";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Aer Girl");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}
                if (LocalNPCOverride.savedAerGirl == true)
                {
                    return true;
                }
				/*foreach (Item item in player.inventory) {
					if (item.type == ItemType<ExampleItem>() || item.type == ItemType<Items.Placeable.ExampleBlock>()) {
						return true;
					}
				}*/
			}
			return false;
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(14)) {
				case 0:
					return "Abby";
				case 1:
					return "Arian";
				case 2:
					return "Ariel";
                case 3:
                    return "Callie";
                case 4:
                    return "Crystal";
                case 5:
                    return "Eliese";
                case 6:
                    return "Elizabeth";
                case 7:
                    return "Janie";
                case 8:
                    return "Morgan";
                case 9:
                    return "Opal";
                case 10:
                    return "Rachel";
                case 11:
                    return "Sally";
                case 12:
                    return "Veronica";
                default:
					return "Betty";
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

		public override string GetChat() {
            int lines;
			int Angler = NPC.FindFirstNPC(NPCID.Angler);
            int Goblin = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            int Mech = NPC.FindFirstNPC(NPCID.Mechanic);
            int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
            int Demo = NPC.FindFirstNPC(NPCID.Demolitionist);
            int Nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (Main.dayTime == true)
            {
                if (Main.hardMode == true)
                {
                    lines = 8;
                    if (Angler >= 0 && Main.rand.NextBool(lines))
                    {
                        return "You know, " + Main.npc[Angler].GivenName + " is actually kind of cute. Although, he is way too hard-headed.";
                    }
                    if (Goblin >= 0 && Main.rand.NextBool(lines))
                    {
                        return "I love these things that " + Main.npc[Goblin].GivenName + " made for me! I can see so much better!";
                    }
                    if (Mech >= 0 && Main.rand.NextBool(lines))
                    {
                        return "I love these things that " + Main.npc[Mech].GivenName + " made for me! I can see so much better!";
                    }
                    switch (Main.rand.Next(lines))
                    {
                        case 0:
                            return "Man! I never knew I had this kind of power!";
                        case 1:
                            return "I challenged " + Main.npc[Clothier].GivenName + " to a battle... Let me just say, " + Main.npc[Nurse].GivenName + "'s help was needed.";
                        case 2:
                            return "What explosion? Oh, that one. I would tend to think " + Main.npc[Demo].GivenName + " did that.";
                        case 3:
                            return "It's nice to finally be able to explore the surface.";
                        default:
                            return "So this is what my parents said I knew too much about.";
                    }
                }
                else
                {
                    lines = 5;
                    if (Angler >= 0 && Main.rand.NextBool(lines))
                    {
                        return "You know, " + Main.npc[Angler].GivenName + " is actually kind of cute. Although, he is way too hard-headed.";
                    }
                    if (Goblin >= 0 && Main.rand.NextBool(lines))
                    {
                        return "I love these things that " + Main.npc[Goblin].GivenName + " made for me! I can see so much better!";
                    }
                    if (Mech >= 0 && Main.rand.NextBool(lines))
                    {
                        return "I love these things that " + Main.npc[Mech].GivenName + " made for me! I can see so much better!";
                    }
                    switch (Main.rand.Next(lines))
                    {
                        case 0:
                            return "The reason my parents chained me up, is because they said I knew too much... I don't know what about.";
                        default:
                            return "It's nice to finally be able to explore the surface.";
                    }
                }
            }
            else
            {
                if (Main.bloodMoon == true)
                {
                    lines = 3;
                    switch (Main.rand.Next(lines))
                    {
                        case 1:
                            return "AHH! Help me! Kill everything!";
                        case 2:
                            return "This is more monsters then I have ever seen in one place in my life. AHH! They are coming in!";
                        default:
                            return "Why is everyone so snotty right now? Hurry up, so I don't die already " + Main.myPlayer + "!";
                    }
                }
                else
                {
                    lines = 3;
                    switch (Main.rand.Next(lines))
                    {
                        case 0:
                            return "Sure is dark out there. Make sure you take some torches!";
                        case 1:
                            return "Wish I had a bed.";
                        default:
                            return "Back in my original home, the Towros kept all the intruders away. Hope you can too... What am I saying? Of course you can!";
                    }
                }
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
			button = Language.GetTextValue("LegacyInterface.28");
			//button2 = "Awesomeify";
			//if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				//button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
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

		public override void NPCLoot() {
            if (Main.rand.Next(2) == 0)
                Item.NewItem(npc.getRect(), ItemType<Items.Armor.PinkGlasses>());
        }

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toQueenStatue) {
			return true;
		}

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
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, DustType<Sparkle>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileType<CloudBall>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 3f;
            gravityCorrection = 0;
			randomOffset = 0.2f;
		}
	}
}
