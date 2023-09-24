using System;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Project1
{
	public class EnemySpriteFactory
	{
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
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

        // More private Texture2Ds follow
        // ...

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //goombaSpriteSheet = content.Load<Texture2D>("goomba");
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
        public IEnemy CreateBatSprite()
        {
            Bat.setFrames();
            return new Bat(batSpritesheet);
        }

        public IEnemy CreateBossAquaDragonSprite()
        {
            BossAquaDragonSprite.setFrames();
            return new BossAquaDragonSprite(aquaDragonSpritesheet);
        }

        public IEnemy CreateDinoSprite()
        {
            BossDino.setFrames();
            return new BossDino(dinoSpritesheet);
        }

        public IEnemy CreateFireDragonSprite()
        {
            BossFireDragon.setFrames();
            return new BossFireDragon(fireDragonSpritesheet);
        }

        public IEnemy CreateDogMonsterSprite()
        {
            DogMonster.setFrames();
            return new DogMonster(dogMonsterSpritesheet);
        }

        public IEnemy CreateFlameSprite()
        {
            Flame.setFrames();
            return new Flame(flameSpritesheet);
        }

        public IEnemy CreateHandSprite()
        {
            Hand.setFrames();
            return new Hand(handSpritesheet);
        }

        public IEnemy CreateJellySprite()
        {
            Jelly.setFrames();
            return new Jelly(jellySpritesheet);
        }

        public IEnemy CreateMerchantSprite()
        {
            Merchant.setFrames();
            return new Merchant(merchantSpritesheet);
        }

        public IEnemy CreateOldManSprite()
        {
            OldMan.setFrames();
            return new OldMan(oldManSpritesheet);
        }

        public IEnemy CreateSkeletonSprite()
        {
            Skeleton.setFrames();
            return new Skeleton(skeletonSpritesheet);
        }

        public IEnemy CreateSnakeSprite()
        {
            Snake.setFrames();
            return new Snake(snakeSpritesheet);
        }

        public IEnemy CreateSpikeCrossSprite()
        {
            SpikeCross.setFrames();
            return new SpikeCross(spikeCrossSpritesheet);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

