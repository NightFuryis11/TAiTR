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
    public class BadClef : ModNPC
    {
        int[] myAI = new int[5]; //0 is the move timer, 1 is attack timer, 2 is multiattack cooldown
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bad Clef");
            //Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 300;
            npc.damage = 35;
            npc.defense = 55;
            npc.knockBackResist = 0.1f;
            npc.height = 32; //inaccurate
            npc.width = 34; //inaccurate
            npc.value = 0;
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.Item27;
            npc.DeathSound = SoundID.Item27;
            npc.aiStyle = 2;
            myAI[1] = 1;
            //music
        }


        public override void AI()
        {
            Target();
            DespawnHandler();
            myAI[0] -= 1;
            npc.ai[0] -= 1;
            myAI[1] -= 1;
            myAI[2] -= 1;
            Move(new Vector2(PlayerX(), PlayerY()));


            if (myAI[2] <= 0 && myAI[3] > 0)
            {
                Shoot1();
                myAI[3] -= 1;
                myAI[2] = 8;
            }


            if (myAI[1] == 0)
            {
                myAI[2] = 2;
                myAI[3] = 5;
                myAI[1] = 300;
            }

            if (Main.expertMode == true)
            {
                npc.lifeMax = 600;
                npc.damage = 65;
                npc.defense = 55;
                npc.knockBackResist = 0f;
            }
        }


        public int PlayerX()
        {
            float offsetx;
            int trueoffsetx;
            offsetx = Main.rand.Next(0, 17);
            trueoffsetx = (int)offsetx - 8;
            return trueoffsetx;
        }

        public int PlayerY()
        {
            float offsety;
            int trueoffsety;
            offsety = Main.rand.Next(0, 161);
            trueoffsety = (int)offsety - 80;
            return trueoffsety;
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }


        private void Move(Vector2 offset)
        {
            speed = 10f;
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 100f;
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

        private int NoteDamage()
        {
            if (Main.expertMode == true)
            {
                return 130;
            }
            return 75;
        }

        private void Shoot1()
        {
            int type =  Main.rand.Next(new int[] { ProjectileType<Projectiles.BadNote>(), ProjectileType<Projectiles.BadNote2>(), ProjectileType<Projectiles.BadNote3>() });
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
            Projectile.NewProjectile(npc.position, velocity * (float)1.5, type, 0, 4f);
        }

        /*public override void FindFrame(int frameHeight)
        {
            
        }*/
    }
}
