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
    public class ItemSpriteFactory
    {
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
        private Texture2D[] arrowSpriteStorage = new Texture2D[ARROW_C * ARROW_R];
        private Texture2D[] bombSpriteStorage = new Texture2D[BOMB_C * BOMB_R];
        private Texture2D[] boomerangSpriteStorage = new Texture2D[BOOM_C * BOOM_R];
        private Texture2D[] bowSpriteStorage = new Texture2D[BOW_C * BOW_R];
        private Texture2D[] clockSpriteStorage = new Texture2D[CLOCK_C * CLOCK_R];
        private Texture2D[] fairySpriteStorage = new Texture2D[FAIRY_C * FAIRY_R];
        private Texture2D[] heartSpriteStorage = new Texture2D[HEART_C * HEART_R];
        private Texture2D[] heartContainerSpriteStorage = new Texture2D[HEART_CONTAINER_C * HEART_CONTAINER_R];
        private Texture2D[] keySpriteStorage = new Texture2D[KEY_C * KEY_R];
        private Texture2D[] mapSpriteStorage = new Texture2D[MAP_C * MAP_R];
        private Texture2D[] rupeeSpriteStorage = new Texture2D[RUPEE_C * RUPEE_R];
        private Texture2D[] triforceSpriteStorage = new Texture2D[TRIFORCE_C * TRIFORCE_R];
        private Texture2D[] swordSpriteStorage = new Texture2D[SWORD_C * SWORD_R];


        // More private Texture2Ds follow
        // ...

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //goombaSpriteSheet = content.Load<Texture2D>("goomba");
            arrowSpriteStorage[0] = content.Load<Texture2D>(assetName: "arrowDown");
            arrowSpriteStorage[1] = content.Load<Texture2D>(assetName: "arrowLeft");
            arrowSpriteStorage[2] = content.Load<Texture2D>(assetName: "arrowUp");
            arrowSpriteStorage[3] = content.Load<Texture2D>(assetName: "arrowRight");

            bombSpriteStorage[0] = content.Load<Texture2D>(assetName: "bomb");
            boomerangSpriteStorage[0] = content.Load<Texture2D>(assetName: "boomerang_sheet");
            bowSpriteStorage[0] = content.Load<Texture2D>(assetName: "bow");
            clockSpriteStorage[0] = content.Load<Texture2D>(assetName: "clock");

            fairySpriteStorage[0] = content.Load<Texture2D>(assetName: "fairy1");
            fairySpriteStorage[1] = content.Load<Texture2D>(assetName: "fairy2");

            heartSpriteStorage[0] = content.Load<Texture2D>(assetName: "heartBlue");
            heartSpriteStorage[1] = content.Load<Texture2D>(assetName: "heartRed");

            heartContainerSpriteStorage[0] = content.Load<Texture2D>(assetName: "heartContainer");
            keySpriteStorage[0] = content.Load<Texture2D>(assetName: "key");
            mapSpriteStorage[0] = content.Load<Texture2D>(assetName: "map");

            rupeeSpriteStorage[0] = content.Load<Texture2D>(assetName: "rupeeBlue");
            rupeeSpriteStorage[1] = content.Load<Texture2D>(assetName: "rupeeGold");

            triforceSpriteStorage[0] = content.Load<Texture2D>(assetName: "triforcePieceBlue");
            triforceSpriteStorage[1] = content.Load<Texture2D>(assetName: "triforcePieceGold");

            swordSpriteStorage[0] = content.Load<Texture2D>(assetName: "swordDown");
            swordSpriteStorage[1] = content.Load<Texture2D>(assetName: "swordLeft");
            swordSpriteStorage[2] = content.Load<Texture2D>(assetName: "swordUp");
            swordSpriteStorage[3] = content.Load<Texture2D>(assetName: "swordRight");


            // More Content.Load calls follow
            //...
        }
        
       
        public ISprite CreateArrowSprite()
        {
            return new ArrowSprite(arrowSpriteStorage);
        }

        public ISprite CreateBombSprite()
        {
           
            return new BombSprite(bombSpriteStorage);
        }

        public ISprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(boomerangSpriteStorage);
        }

        public ISprite CreateBowSprite()
        {
            return new BowSprite(bowSpriteStorage);
        }

        public ISprite CreateClockSprite()
        {
            return new ClockSprite(clockSpriteStorage);
        }

        public ISprite CreateFairySprite()
        {
            return new FairySprite(fairySpriteStorage);
        }

        public ISprite CreateHeartSprite()
        {
            return new HeartSprite(heartSpriteStorage);
        }

        public ISprite CreateHeartContainerSprite()
        {
            return new HeartContainerSprite(heartContainerSpriteStorage);
        }

        public ISprite CreateKeySprite()
        {
            return new KeySprite(keySpriteStorage);
        }

        public ISprite CreateMapSprite()
        {
            return new MapSprite(mapSpriteStorage);
        }

        public ISprite CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSpriteStorage);
        }

        public ISprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSpriteStorage);
        }

        public ISprite CreateSwordSprite()
        {
            return new SwordSprite(swordSpriteStorage);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

