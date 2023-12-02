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
        private Texture2D[] arrowSpriteStorage = new Texture2D[ARROW_TOTAL];
        private Texture2D[] bombSpriteStorage = new Texture2D[BOMB_TOTAL];
        private Texture2D[] boomerangSpriteStorage = new Texture2D[BOOM_TOTAL];
        private Texture2D[] bowSpriteStorage = new Texture2D[BOW_TOTAL];
        private Texture2D[] clockSpriteStorage = new Texture2D[CLOCK_TOTAL];
        private Texture2D[] fairySpriteStorage = new Texture2D[FAIRY_TOTAL];
        public static Texture2D[] heartSpriteStorage = new Texture2D[HEART_TOTAL];
        private Texture2D[] heartContainerSpriteStorage = new Texture2D[HEART_CONTAINER_TOTAL];
        private Texture2D[] keySpriteStorage = new Texture2D[KEY_TOTAL];
        private Texture2D[] mapSpriteStorage = new Texture2D[MAP_TOTAL];
        private Texture2D[] rupeeSpriteStorage = new Texture2D[RUPEE_TOTAL];
        private Texture2D[] triforceSpriteStorage = new Texture2D[TRIFORCE_TOTAL];
        private Texture2D[] swordSpriteStorage = new Texture2D[SWORD_TOTAL];
        private Texture2D[] BeehiveSpriteStorage = new Texture2D[BEEHIVE_TOTAL];


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

            arrowSpriteStorage[0] = content.Load<Texture2D>(assetName: "arrowUp");


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

            swordSpriteStorage[0] = content.Load<Texture2D>(assetName: "swordUp");

            BeehiveSpriteStorage[0] = content.Load<Texture2D>(assetName: "orb");


            // More Content.Load calls follow
            //...
        }
        
       
        public IItemSprite CreateArrowSprite((int, int) pos)
        {
            return new ArrowSprite(arrowSpriteStorage,pos);
        }
        public IItemSprite CreateBombSprite((int, int) pos)
        {           
            return new BombItemSprite(bombSpriteStorage,pos);
        }
        
        public IItemSprite CreateBoomerangSprite((int, int) pos)
        {
            return new BoomerangSprite(boomerangSpriteStorage,pos);
        }

        public IItemSprite CreateBowSprite((int, int) pos)
        {
            return new BowSprite(bowSpriteStorage, pos);
        }

        public IItemSprite CreateClockSprite((int, int) pos)
        {
            return new ClockSprite(clockSpriteStorage, pos);
        }

        public IItemSprite CreateFairySprite((int, int) pos)
        {
            return new FairySprite(fairySpriteStorage, pos);
        }

        public IItemSprite CreateHeartSprite((int, int) pos)
        {
            return new HeartSprite(heartSpriteStorage, pos);
        }

        public IItemSprite CreateHeartContainerSprite((int, int) pos)
        {
            return new HeartContainerSprite(heartContainerSpriteStorage, pos);
        }

        public IItemSprite CreateKeySprite((int, int) pos)
        {
            return new KeySprite(keySpriteStorage, pos);
        }

        public IItemSprite CreateMapSprite((int, int) pos)
        {
            return new MapSprite(mapSpriteStorage, pos);
        }

        public IItemSprite CreateRupeeSprite((int, int) pos)
        {
            return new RupeeSprite(rupeeSpriteStorage, pos);
        }

        public IItemSprite CreateTriforceSprite((int, int) pos)
        {
            return new TriforceSprite(triforceSpriteStorage, pos);
        }

        public IItemSprite CreateSwordSprite((int, int) pos)
        {
            return new SwordSprite(swordSpriteStorage, pos);
        }

        public IItemSprite CreateBeehiveSprite((int, int) pos)
        {
            return new BeehiveItemSprite(BeehiveSpriteStorage, pos);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

