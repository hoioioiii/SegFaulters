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
    public class EnemySpriteFactory
    {
        //private Texture2D goombaSpritesheet;
        //private Texture2D koopaSpritesheet;
        //testing for adding back to branch
        private Texture2D[] batSpritesheet = new Texture2D[BAT_C * BAT_R];
        private Texture2D[] aquaDragonSpritesheet = new Texture2D[AD_C * AD_R];
        private Texture2D[] dinoSpritesheet = new Texture2D[DINO_C * DINO_R];
        private Texture2D[] fireDragonSpritesheet = new Texture2D[FD_C * FD_R];
        private Texture2D[] dogMonsterSpritesheet = new Texture2D[DM_C * DM_R];
        private Texture2D[] flameSpritesheet = new Texture2D[FLAME_C * FLAME_R];
        private Texture2D[] handSpritesheet = new Texture2D[HAND_C * HAND_R];
        private Texture2D[] jellySpritesheet = new Texture2D[JELLY_C * JELLY_R];
        private Texture2D[] merchantSpritesheet = new Texture2D[MERCHANT_C * MERCHANT_R];
        private Texture2D[] oldManSpritesheet = new Texture2D[OLDMAN_C * OLDMAN_R];
        private Texture2D[] skeletonSpritesheet = new Texture2D[SKELETON_C * SKELETON_R];
        private Texture2D[] snakeSpritesheet = new Texture2D[SNAKE_C * SNAKE_R];
        private Texture2D[] spikeCrossSpritesheet = new Texture2D[SPIKE_C * SPIKE_R];

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
            batSpritesheet[0] = content.Load<Texture2D>(assetName: "KEESE_BAT");

            aquaDragonSpritesheet[0] = content.Load<Texture2D>(assetName: "AD");
            dinoSpritesheet[0] = content.Load<Texture2D>(assetName: "DINO");
            fireDragonSpritesheet[0] = content.Load<Texture2D>(assetName: "FD");
            dogMonsterSpritesheet[0] = content.Load<Texture2D>(assetName: "DM");
            flameSpritesheet[0] = content.Load<Texture2D>(assetName: "FIRE");
            handSpritesheet[0] = content.Load<Texture2D>(assetName: "HAND");
            jellySpritesheet[0] = content.Load<Texture2D>(assetName: "JELLY");
            merchantSpritesheet[0] = content.Load<Texture2D>(assetName: "MERCHANT");
            oldManSpritesheet[0] = content.Load<Texture2D>(assetName: "OLDM");
            skeletonSpritesheet[0] = content.Load<Texture2D>(assetName: "SKELETON");
            snakeSpritesheet[0] = content.Load<Texture2D>(assetName: "SNAKE");
            spikeCrossSpritesheet[0] = content.Load<Texture2D>(assetName: "SPIKES");


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

