using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;
using System.Collections.Generic;
using Application;

namespace Project1
{
    public class WeaponSpriteFactory
    {

        private Texture2D[] SwordSheet = new Texture2D[4];
        private Texture2D test;
        private Texture2D[] BowSheet = new Texture2D[BOW_TOTAL];
        private Texture2D[] ArrowSheet = new Texture2D[4];
        private Texture2D[] BombSheet = new Texture2D[BOMB_ARRAY];
        private Texture2D[] BoomerangSheet = new Texture2D[BOOMERANG_C * BOOMERANG_R];
        private Texture2D[] OrbSheet = new Texture2D[1];
        private Texture2D[] BeehiveSheet = new Texture2D[BEEHIVE_ARRAY];
        private List<Texture2D[]> BeeSheet = new List<Texture2D[]>() { new Texture2D[BEE_ARRAY], new Texture2D[BEE_ARRAY], new Texture2D[BEE_ARRAY], new Texture2D[BEE_ARRAY], new Texture2D[BEE_ARRAY]};
        private List<Texture2D[]> HoneycombSheet = new List<Texture2D[]>() { new Texture2D[HONEYCOMB_ARRAY] };
        // More private Texture2Ds follow
        // ...

        private static WeaponSpriteFactory instance = new WeaponSpriteFactory();

        public static WeaponSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private WeaponSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //add all frames to the arrays
            //anything in all caps still needs to be updates with the new sprite
            //REFERENCE: list index 0 = Up Frames, 1 = Right Frames, 2  = Down Frames, 3 = Left Frames
            //Up:0, Right:1, Down:2, Left: 3

            //SwordSheet[0] = content.Load<Texture2D>("swordUp");
            //SwordSheet[1] = content.Load<Texture2D>("swordDown");
            //SwordSheet[2] = content.Load<Texture2D>("swordRight");
            //SwordSheet[3] = content.Load<Texture2D>("swordLeft");

            //// movement only
            //BowSheet[0] = content.Load<Texture2D>("bowUp");
            //BowSheet[1] = content.Load<Texture2D>("bowDown");
            //BowSheet[2] = content.Load<Texture2D>("bowLeft");
            //BowSheet[3] = content.Load<Texture2D>("bowRight");

            
            BeehiveSheet[UP] = content.Load<Texture2D>("HiveNew");

            HoneycombSheet[UP][UP] = content.Load<Texture2D>("HoneycombNew");
            HoneycombSheet[UP][RIGHT] = content.Load<Texture2D>("HoneycombNew");
            HoneycombSheet[UP][DOWN] = content.Load<Texture2D>("HoneycombNew");
            HoneycombSheet[UP][LEFT] = content.Load<Texture2D>("HoneycombNew");
            HoneycombSheet[UP][4] = content.Load<Texture2D>("HoneycombNew");

            #region Bee Storage

            BeeSheet[UP][0] = content.Load<Texture2D>("beeUp1");
            BeeSheet[UP][1] = content.Load<Texture2D>("beeUp2");
            BeeSheet[UP][2] = content.Load<Texture2D>("beeUp3");
            BeeSheet[UP][3] = content.Load<Texture2D>("beeUp4");


            BeeSheet[RIGHT][0] = content.Load<Texture2D>("beeRight1");
            BeeSheet[RIGHT][1] = content.Load<Texture2D>("beeRight2");
            BeeSheet[RIGHT][2] = content.Load<Texture2D>("beeRight3");
            BeeSheet[RIGHT][3] = content.Load<Texture2D>("beeRight4");

            BeeSheet[DOWN][0] = content.Load<Texture2D>("beeDown1");
            BeeSheet[DOWN][1] = content.Load<Texture2D>("beeDown2");
            BeeSheet[DOWN][2] = content.Load<Texture2D>("beeDown3");
            BeeSheet[DOWN][3] = content.Load<Texture2D>("beeDown4");


            BeeSheet[LEFT][0] = content.Load<Texture2D>("beeLeft1");
            BeeSheet[LEFT][1] = content.Load<Texture2D>("beeLeft2");
            BeeSheet[LEFT][2] = content.Load<Texture2D>("beeLeft3");
            BeeSheet[LEFT][3] = content.Load<Texture2D>("beeLeft4");

            //for the explosion stuff
            BeeSheet[4][0] = content.Load<Texture2D>("beeLeft1");
            BeeSheet[4][1] = content.Load<Texture2D>("beeLeft2");
            BeeSheet[4][2] = content.Load<Texture2D>("beeLeft3");
            BeeSheet[4][3] = content.Load<Texture2D>("beeLeft4");

            #endregion

            SwordSheet[UP] = content.Load<Texture2D>("swordUp");
            SwordSheet[RIGHT] = content.Load<Texture2D>("swordRight");
            SwordSheet[DOWN] = content.Load<Texture2D>("swordDown");
            SwordSheet[LEFT] = content.Load<Texture2D>("swordLeft");


            ArrowSheet[UP] = content.Load<Texture2D>("arrowUp");
            ArrowSheet[RIGHT] = content.Load<Texture2D>("arrowRight");
            ArrowSheet[DOWN] = content.Load<Texture2D>("arrowDown");
            ArrowSheet[LEFT] = content.Load<Texture2D>("arrowLeft");

            //// Attack using weapon or item
            BombSheet[UP] = content.Load<Texture2D>("ZeldaSpriteBomb");
            BombSheet[RIGHT] = content.Load<Texture2D>("ZeldaSpriteEnemyCloud");

            BoomerangSheet[UP] = content.Load<Texture2D>("boomerang1");
            BoomerangSheet[RIGHT] = content.Load<Texture2D>("boomerang2");
            BoomerangSheet[DOWN] = content.Load<Texture2D>("boomerang3");
            BoomerangSheet[LEFT] = content.Load<Texture2D>("boomerang4");

            ////need the orbs still
            OrbSheet[0] = content.Load<Texture2D>("orb");

        }


        public ISpriteWeapon CreateBombSprite()
        {
            return new BombSprite(BombSheet);
        }

        public ISpriteWeapon CreateArrowSprite()
        {
            return new ArrowSpritePlayer(ArrowSheet);
        }
        public ISpriteWeapon CreateBoomerangeSprite()
        {
            return new BoomerangeSprite(BoomerangSheet);
        }

        public ISpriteWeapon CreateBoomerangePlayerSprite()
        {
            return new BoomerangeSpritePlayer(BoomerangSheet);
        }

        public ISpriteWeapon CreateOrbSprite((int,int) pos, ORB_DIRECTION type)
        {
            return new OrbSprite(OrbSheet, pos, type);
        }
        public ISpriteWeapon CreateBeesSprite((int, int) pos, ORB_DIRECTION type)
        {
            return new BeesSprite(BeeSheet, pos, type);
        }
        public ISpriteWeapon CreateBeeHiveSprite()
        {
            return new BeeHiveSprite(HoneycombSheet);
        }
        public ISpriteWeapon CreateSwordSprite()
        {
            return new SwordSpritePlayer(SwordSheet);
        }

    }

}