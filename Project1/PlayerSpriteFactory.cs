using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Project1
{
    public class PlayerSpriteFactory
    {
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
        /*
        private Texture2D batSpritesheet;
        private Texture2D aquaDragonSpritesheet;
        private Texture2D dinoSpritesheet;
        private Texture2D fireDragonSpritesheet;
        private Texture2D dogMonsterSpritesheet;
        private Texture2D flameSpritesheet;
        private Texture2D handSpritesheet;
        private Texture2D jellySpritesheet;
        private Texture2D merchantSpritesheet;
        private Texture2D oldManSpritesheet;
        private Texture2D skeletonSpritesheet;
        private Texture2D snakeSpritesheet;
        private Texture2D spikeCrossSpritesheet;
        */
        private Texture2D linkRightSpritesheet;
        private Texture2D linkLeftSpritesheet;
        private Texture2D linkRightAnimatedTexSpritesheet;
        private Texture2D linkLeftAnimatedTexSpritesheet;
        
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

        private PlayerSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //goombaSpriteSheet = content.Load<Texture2D>("goomba");
            /*
            batSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            aquaDragonSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            dinoSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            fireDragonSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            dogMonsterSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            flameSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            handSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            jellySpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            merchantSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            oldManSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            skeletonSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            snakeSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            spikeCrossSpritesheet = content.Load<Texture2D>(assetName: "KEESE_BAT");
            */

            linkRightSpritesheet = content.Load<Texture2D>(assetName: "ZeldaSpriteLinkRight");
            linkLeftSpritesheet = content.Load<Texture2D>(assetName: "ZeldaSpriteLinkLeft");
            linkRightAnimatedTexSpritesheet = content.Load<Texture2D>(assetName: "linkWalkRightSpritesheet");
            linkLeftAnimatedTexSpritesheet = content.Load<Texture2D>(assetName: "linkWalkLeftSpritesheet");

            // More Content.Load calls follow
            //...
        }
        /*
        public IEnemy CreateGoombaSprite()
        {
            return new GoombaSprite(goombaSpritesheet, Game1.Instance.level.isAboveGround);
        }

        public IEnemy CreateKoopaSprite()
        {
            return new KoopaSprite(koopaSpritesheet, 32, 32);
        }

        public IEnemy CreateGiantKoopaSprite()
        {
            return new KoopaSprite(koopaSpritesheet, 64, 64);
        }
        */
        public IPlayer CreateLinkRightSprite()
        {
            return new LinkRight(linkRightSpritesheet);
        }

        public IPlayer CreateLinkLeftSprite()
        { 
            return new LinkLeft(linkLeftSpritesheet);
        }

        public IPlayer CreateLinkRightAnimatedSprite()
        {
            return new LinkRightAnimated(linkRightAnimatedTexSpritesheet);
        }

        public IPlayer CreateLinkLeftAnimatedSprite()
        {
            return new LinkLeftAnimated(linkLeftAnimatedTexSpritesheet);
        }

        /*

        public IPlayer CreateSnakeSprite()
        {
            Snake.setFrames();
            return new Snake(snakeSpritesheet);
        }

        public IPlayer CreateSpikeCrossSprite()
        {
            SpikeCross.setFrames();
            return new SpikeCross(spikeCrossSpritesheet);
        }
        */

        // More public ISprite returning methods follow
        // ...
    }
}

// Client code in main game class' LoadContent method:
//EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
//ISprite mySprite = EnemySpriteFactory.Instance.CreateGoombaSprite();

