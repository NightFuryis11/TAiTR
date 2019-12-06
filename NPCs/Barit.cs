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
    public class Barit : ModNPC
    {
        int[] myAI = new int[5]; //0 is the move timer, 1 is attack timer, 2 is multiattack cooldown, 3 is multiattack shot counter, 4 is a one-time used to summon the mini-bosses.
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barit");
            //Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 12000;
            npc.damage = 55;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.height = 40; //inaccurate
            npc.width = 26; //inaccurate
            npc.value = 0;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            myAI[4] = 1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/BattonBatter");
            musicPriority = MusicPriority.BossMedium;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 12000;
            npc.damage = 55;
            npc.defense = 20;
            npc.knockBackResist = 0f;
        }

        public override void AI()
        {
            Target();
            DespawnHandler();
            myAI[0] -= 1;
            npc.ai[0] -= 1;
            myAI[1] -= 1;
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
                    myAI[1] = 85;
                }
            }


            if (myAI[1] == 0)
            {
                Shoot1();
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
            int type = ProjectileType<RedSwirl>();
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
            Projectile.NewProjectile(npc.position, velocity * 0, type, 0, 4f);
        }

        /*public override void FindFrame(int frameHeight)
        {
            
        }*/

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}
