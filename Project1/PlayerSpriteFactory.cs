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
    public class PlayerSpriteFactory
    {
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
        private Texture2D[] link1SpriteStorage = new Texture2D[PLAYER_FRAMES];
        private Texture2D[] link2SpriteStorage = new Texture2D[PLAYER_FRAMES];
        private Texture2D[] linkAttackSpriteStorage = new Texture2D[PLAYER_FRAMES];
        /*
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
        */


        // More private Texture2Ds follow
        // ...

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            
            // still and movement
            link1SpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkRight1");
            link1SpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkLeft1");
            link1SpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkUp1");
            link1SpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkDown1");

            // movement only
            link2SpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkRight2");
            link2SpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkLeft2");
            link2SpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkUp2");
            link2SpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkDown2");

            // Attack using weapon or item
            linkAttackSpriteStorage[(int)DIRECTION.right] = content.Load<Texture2D>(assetName: "LinkAttackRight");
            linkAttackSpriteStorage[(int)DIRECTION.left] = content.Load<Texture2D>(assetName: "LinkAttackLeft");
            linkAttackSpriteStorage[(int)DIRECTION.up] = content.Load<Texture2D>(assetName: "LinkAttackUp");
            linkAttackSpriteStorage[(int)DIRECTION.down] = content.Load<Texture2D>(assetName: "LinkAttackDown");


            // More Content.Load calls follow
            //...
        }


        public IPlayerSprite CreateLinkSprite()
        {
            return new LinkSprite(link1SpriteStorage, link2SpriteStorage, linkAttackSpriteStorage);
        }

        /*
        public ISprite CreateLink2Sprite()
        {

            return new Link2Sprite(link2SpriteStorage);
        }

        public ISprite CreateLinkAttackSprite()
        {

            return new LinkAttackSprite(linkAttackSpriteStorage);
        }
        */

        /*

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
        */

        // More public ISprite returning methods follow
        // ...
    }
}
