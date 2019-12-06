using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using TAiTR.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TAiTR.NPCs
{
    [AutoloadBossHead]
    public class TheConductor : ModNPC
    {
        int spriteDirection;
        int[] myAI = new int[7]; //0 is the move timer, 1 is attack timer, 2 is multiattack cooldown, 3 is multiattack shot counter, 4 is a one-time used to summon the mini-bosses, 5 is multiattack cooldown #2.
        private Player player;
        private float speed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Conductor");
            //Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 28000;
            npc.damage = 50;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.height = 42;
            npc.width = 44;
            npc.value = 100000;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            myAI[4] = 1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/BattonBatter");
            musicPriority = MusicPriority.BossHigh;
            bossBag = mod.ItemType("ConductorBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(35000 + (7000 * (numPlayers)));
            npc.damage = 70;
            npc.defense = 40;
            npc.knockBackResist = 0f;
        }

        public override void AI()
        {
            Target();
            DespawnHandler();
            myAI[0] -= 1;
            npc.ai[0] -= 1;
            myAI[1] -= 1;
            myAI[2] -= 1;
            myAI[5] -= 1;
            if (player.active == true && player.dead == !true)
            {
                if (myAI[0] <= 0)
                {
                    Move(new Vector2(PlayerX(), PlayerY()));
                    myAI[0] = 250;
                    npc.ai[0] = 25;
                    myAI[1] = 40;
                }
                if (npc.ai[0] <= 0)
                {
                    Still(new Vector2(0, 0));

                }
                if (distanceToPlayer() >= 800)
                {
                    Move(new Vector2(PlayerX(), PlayerY()));
                    myAI[0] = 250;
                    npc.ai[0] = 45;
                    myAI[1] = 30;
                }
            }

            if (myAI[2] <= 0 && myAI[3] > 0)
            {
                Shoot1();
                myAI[3] -= 1;
                myAI[2] = 8;
            }

            if (myAI[5] <= 0 && myAI[6] > 0)
            {
                Shoot2();
                myAI[6] -= 1;
                myAI[5] = 45;
            }


            if (myAI[1] == 0)
            {
                int attackSelector = Main.rand.Next(0, 5);
                if (attackSelector == 0 || attackSelector == 3)
                {
                    myAI[2] = 2;
                    myAI[3] = 20;
                }
                if (attackSelector == 1 || attackSelector == 4)
                {
                    myAI[6] = 3;
                    myAI[5] = 2;
                }
                if (attackSelector == 2)
                {
                    Shoot3();
                }
            }

            if (Main.npc.Any(npc => npc.active && (npc.type == mod.NPCType("Barit") || npc.type == mod.NPCType("Ariete"))))
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }

            if (Main.expertMode == true && myAI[4] == 1 && npc.life <= 10000)
            {
                NPC.NewNPC((int)npc.Center.X - 10, (int)npc.Center.Y, mod.NPCType("Barit"));
                NPC.NewNPC((int)npc.Center.X + 10, (int)npc.Center.Y, mod.NPCType("Ariete"));
                myAI[4] = 0;
            }

            float distX = (float)player.Center.X - (float)npc.Center.X;
            npc.direction = (npc.spriteDirection = Math.Sign(distX));
        }


        public float distanceToPlayer()
        {
            float distX = (float)player.Center.X - (float)npc.Center.X;
            float distY = (float)player.Center.Y - (float)npc.Center.Y;
            float dist = (float)Math.Sqrt(distX * distX + distY * distY);
            return dist;
        }

        public int PlayerX()
        {
            float offsetx;
            int trueoffsetx;
            offsetx = Main.rand.Next(0, 33);
            trueoffsetx = (int)offsetx - 16;
            return trueoffsetx;
        }

        public int PlayerY()
        {
            float offsety;
            int trueoffsety;
            offsety = Main.rand.Next(0, 321);
            trueoffsety = (int)offsety - 160;
            return trueoffsety;
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void Still(Vector2 nowhere)
        {
            Vector2 moveTo = npc.Center * nowhere;
            npc.velocity = moveTo;
        }

        private void Move(Vector2 offset)
        {
            speed = 20f;
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 0f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        private void DespawnHandler()
        {
            if(!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, 10f);
                    if(npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private float Magnitude(Vector2 move)
        {
            return (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
        }

        private void Shoot1()
        {
            int type =  Main.rand.Next(new int[] { ProjectileType<Projectiles.ManiacNote>(), ProjectileType<Projectiles.ManiacNote2>(), ProjectileType<Projectiles.ManiacNote3>() });
            Vector2 velocity = player.Center - npc.Center;
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 5f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity * 3, type, 12, 4f);
        }

        private void Shoot2()
        {
            int type = ProjectileType<GreenStar>();
            Vector2 velocity = player.Center - npc.Center;
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 5f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(45);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X * 2, perturbedSpeed.Y * 2, type, 0, 0);
            }
        }

        private void Shoot3()
        {
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 100, mod.NPCType("BadClef"));
            NPC.NewNPC((int)npc.Center.X + 10, (int)npc.Center.Y, mod.NPCType("BadClef"));
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BadClef"));
            NPC.NewNPC((int)npc.Center.X - 10, (int)npc.Center.Y, mod.NPCType("BadClef"));
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 100, mod.NPCType("BadClef"));
        }

        /*public override void FindFrame(int frameHeight)
        {
            spriteDirection = (int)player.Center.X - (int)npc.Center.X;
            npc.spriteDirection = npc.direction;
        }*/

        public override void NPCLoot()
        {
            if (Main.expertMode == true)
            {
                npc.DropBossBags();
            }
            else
            {

            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}
