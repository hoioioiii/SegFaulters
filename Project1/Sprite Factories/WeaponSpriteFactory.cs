using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;

namespace Project1
{
    public class WeaponSpriteFactory
    {

        private Texture2D[] SwordSheet = new Texture2D[4];
        private Texture2D[] BowSheet = new Texture2D[BOW_TOTAL];
        private Texture2D[] ArrowSheet = new Texture2D[4];
        private Texture2D[] BombSheet = new Texture2D[BOMB_ARRAY];
        private Texture2D[] BoomerangSheet = new Texture2D[BOOMERANG_C * BOOMERANG_R];
        private Texture2D[] OrbSheet = new Texture2D[1];
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

            //SwordSheet[0] = content.Load<Texture2D>("swordUp");
            //SwordSheet[1] = content.Load<Texture2D>("swordDown");
            //SwordSheet[2] = content.Load<Texture2D>("swordRight");
            //SwordSheet[3] = content.Load<Texture2D>("swordLeft");

            //// movement only
            //BowSheet[0] = content.Load<Texture2D>("bowUp");
            //BowSheet[1] = content.Load<Texture2D>("bowDown");
            //BowSheet[2] = content.Load<Texture2D>("bowLeft");
            //BowSheet[3] = content.Load<Texture2D>("bowRight");

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


        public ISpriteWeapon CreateSwordSprite()
        {
            return new SwordSpritePlayer(SwordSheet);
        }

    }

}