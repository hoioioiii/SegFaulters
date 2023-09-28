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
        //testing for adding back to branch
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
            
            aquaDragonSpritesheet = content.Load<Texture2D>(assetName: "AD");
            dinoSpritesheet = content.Load<Texture2D>(assetName: "DINO");
            fireDragonSpritesheet = content.Load<Texture2D>(assetName: "FD");
            dogMonsterSpritesheet = content.Load<Texture2D>(assetName: "DM");
            flameSpritesheet = content.Load<Texture2D>(assetName: "FIRE");
            handSpritesheet = content.Load<Texture2D>(assetName: "HAND");
            jellySpritesheet = content.Load<Texture2D>(assetName: "JELLY");
            merchantSpritesheet = content.Load<Texture2D>(assetName: "MERCHANT");
            oldManSpritesheet = content.Load<Texture2D>(assetName: "OLDM");
            skeletonSpritesheet = content.Load<Texture2D>(assetName: "SKELETON");
            snakeSpritesheet = content.Load<Texture2D>(assetName: "SNAKE");
            spikeCrossSpritesheet = content.Load<Texture2D>(assetName: "SPIKES");
            

            // More Content.Load calls follow
            //...
        }
        
       
        public ISprite CreateBatSprite()
        {
            return new BatSprite(batSpritesheet);
        }

        public ISprite CreateBossAquaDragonSprite()
        {
           
            return new BossAquaDragonSprite(aquaDragonSpritesheet);
        }

        public ISprite CreateDinoSprite()
        {
            return new BossDinoSprite(dinoSpritesheet);
        }

        public ISprite CreateFireDragonSprite()
        {
            return new BossFireDragonSprite(fireDragonSpritesheet);
        }

        public ISprite CreateDogMonsterSprite()
        {
            return new DogMonsterSprite(dogMonsterSpritesheet);
        }

        public ISprite CreateFlameSprite()
        {
            return new FlameSprite(flameSpritesheet);
        }

        public ISprite CreateHandSprite()
        {
            return new HandSprite(handSpritesheet);
        }

        public ISprite CreateJellySprite()
        {
            return new JellySprite(jellySpritesheet);
        }

        public ISprite CreateMerchantSprite()
        {
            return new MerchantSprite(merchantSpritesheet);
        }

        public ISprite CreateOldManSprite()
        {
            return new OldManSprite(oldManSpritesheet);
        }

        public ISprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(skeletonSpritesheet);
        }

        public ISprite CreateSnakeSprite()
        {
            return new SnakeSprite(snakeSpritesheet);
        }

        public ISprite CreateSpikeCrossSprite()
        {
            return new SpikeCrossSprite(spikeCrossSpritesheet);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

