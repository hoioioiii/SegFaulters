using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;
using Project1.Enemies.sprites;

namespace Project1
{
    public class EnemySpriteFactory
    {
        
        private Texture2D[] batSpritesheet = new Texture2D[BAT_C * BAT_TOTAL];
        //constants specify how mant frames there are for each sprite
        //make sure to edit the constants is constants.cs to reflect how many frames there are for each sprites
        private Texture2D[] aquaDragonSpritesheet = new Texture2D[AQUA_TOTAL];
        private Texture2D[] dinoSpritesheet = new Texture2D[DINO_TOTAL];
        private Texture2D[] fireDragonSpritesheet = new Texture2D[FD_TOTAL];
        private Texture2D[] dogMonsterSpritesheet = new Texture2D[DM_TOTAL];
        private Texture2D[] flameSpritesheet = new Texture2D[FLAME_TOTAL];
        private Texture2D[] handSpritesheet = new Texture2D[HAND_TOTAL];
        private Texture2D[] jellySpritesheet = new Texture2D[JELLY_TOTAL];
        private Texture2D[] merchantSpritesheet = new Texture2D[MERCHANT_TOTAL];
        private Texture2D[] oldManSpritesheet = new Texture2D[OLDMAN_TOTAL];
        private Texture2D[] skeletonSpritesheet = new Texture2D[SKELETON_ARRAY];
        private Texture2D[] snakeSpritesheet = new Texture2D[SNAKE_TOTAL];
        private Texture2D[] spikeCrossSpritesheet = new Texture2D[SPIKE_TOTAL];

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
            //add all frames to the arrays
            //anything in all caps still needs to be updates with the new sprite
            batSpritesheet[0] = content.Load<Texture2D>(assetName: "bat1");
            batSpritesheet[1] = content.Load<Texture2D>(assetName: "bat2");

            //we can toss smthing else here
            aquaDragonSpritesheet[0] = content.Load<Texture2D>(assetName: "ZeldaSpriteAquamentusLeft");
            aquaDragonSpritesheet[1] = content.Load<Texture2D>(assetName: "ZeldaSpriteAquamentusRight");


            dinoSpritesheet[0] = content.Load<Texture2D>(assetName: "dino1");
            dinoSpritesheet[1] = content.Load<Texture2D>(assetName: "dino2");
            dinoSpritesheet[2] = content.Load<Texture2D>(assetName: "dino3");
            dinoSpritesheet[3] = content.Load<Texture2D>(assetName: "dino4");



            fireDragonSpritesheet[0] = content.Load<Texture2D>(assetName: "fd1");
            fireDragonSpritesheet[1] = content.Load<Texture2D>(assetName: "fd2");
            fireDragonSpritesheet[2] = content.Load<Texture2D>(assetName: "fd3");
            fireDragonSpritesheet[3] = content.Load<Texture2D>(assetName: "fd4");


            dogMonsterSpritesheet[0] = content.Load<Texture2D>(assetName: "dm1");
            dogMonsterSpritesheet[1] = content.Load<Texture2D>(assetName: "dm2");
            dogMonsterSpritesheet[2] = content.Load<Texture2D>(assetName: "dm3");
            dogMonsterSpritesheet[3] = content.Load<Texture2D>(assetName: "dm4");
            dogMonsterSpritesheet[4] = content.Load<Texture2D>(assetName: "dm5");
            dogMonsterSpritesheet[5] = content.Load<Texture2D>(assetName: "dm6");
            dogMonsterSpritesheet[6] = content.Load<Texture2D>(assetName: "dm7");
            dogMonsterSpritesheet[7] = content.Load<Texture2D>(assetName: "dm8");
           

            flameSpritesheet[0] = content.Load<Texture2D>(assetName: "ZeldaSpriteFire");




            handSpritesheet[0] = content.Load<Texture2D>(assetName: "handLeft1");
            handSpritesheet[1] = content.Load<Texture2D>(assetName: "handLeft2");
            handSpritesheet[2] = content.Load<Texture2D>(assetName: "handRight1");
            handSpritesheet[3] = content.Load<Texture2D>(assetName: "handRight2");

            jellySpritesheet[0] = content.Load<Texture2D>(assetName: "jelly1");
            jellySpritesheet[1] = content.Load<Texture2D>(assetName: "jelly2");
            jellySpritesheet[2] = content.Load<Texture2D>(assetName: "jelly3");

            merchantSpritesheet[0] = content.Load<Texture2D>(assetName: "MERCHANT");

            oldManSpritesheet[0] = content.Load<Texture2D>(assetName: "ZeldaSpriteOldMan");

            skeletonSpritesheet[0] = content.Load<Texture2D>(assetName: "skeleton1");
            skeletonSpritesheet[1] = content.Load<Texture2D>(assetName: "skeleton2");

            snakeSpritesheet[0] = content.Load<Texture2D>(assetName: "snakeLeft1");
            snakeSpritesheet[1] = content.Load<Texture2D>(assetName: "snakeLeft2");
            snakeSpritesheet[2] = content.Load<Texture2D>(assetName: "snakeRight1");
            snakeSpritesheet[3] = content.Load<Texture2D>(assetName: "snakeRight2");

            spikeCrossSpritesheet[0] = content.Load<Texture2D>(assetName: "spikes1");
            spikeCrossSpritesheet[1] = content.Load<Texture2D>(assetName: "spikes2");
            spikeCrossSpritesheet[2] = content.Load<Texture2D>(assetName: "spikes3");
            spikeCrossSpritesheet[3] = content.Load<Texture2D>(assetName: "spikes4");
            spikeCrossSpritesheet[4] = content.Load<Texture2D>(assetName: "spikes5");
            spikeCrossSpritesheet[5] = content.Load<Texture2D>(assetName: "spikes6");
            spikeCrossSpritesheet[6] = content.Load<Texture2D>(assetName: "spikes7");
            //REFACTOR make things based on direction they are facing

            // More Content.Load calls follow
            //...
        }
        
       
        public ISprite CreateBatSprite((int, int) position, (String, int) items)
        {
            return new BatSprite(batSpritesheet, position, items);
        }

        public ISprite CreateBossAquaDragonSprite((int, int) position, (String, int) items)
        {
           
            return new BossAquaDragonSprite(aquaDragonSpritesheet, position, items);
        }

        public ISprite CreateDinoSprite((int, int) position, (String, int) items)
        {
            return new BossDinoSprite(dinoSpritesheet, position, items);
        }

        public ISprite CreateFireDragonSprite((int, int) position, (String, int) items)
        {
            return new BossFireDragonSprite(fireDragonSpritesheet, position, items);
        }

        public ISprite CreateDogMonsterSprite((int, int) position, (String, int) items)
        {
            return new DogMonsterSprite(dogMonsterSpritesheet, position, items);
        }

        public ISprite CreateFlameSprite((int, int) position, (String, int) items)
        {
            return new FlameSprite(flameSpritesheet, position, items);
        }

        public ISprite CreateHandSprite((int, int) position, (String, int) items)
        {
            return new HandSprite(handSpritesheet, position, items);
        }

        public ISprite CreateJellySprite((int, int) position, (String, int) items)
        {
            return new JellySprite(jellySpritesheet, position, items);
        }

        public ISprite CreateMerchantSprite((int, int) position, (String, int) items)
        {
            return new MerchantSprite(merchantSpritesheet, position, items);
        }

        public ISprite CreateOldManSprite((int, int) position, (String, int) items)
        {
            return new OldManSprite(oldManSpritesheet, position, items);
        }

        public ISprite CreateSkeletonSprite((int, int) position, (String, int) items)
        {
            return new SkeletonSprite(skeletonSpritesheet, position, items);
        }

        public ISprite CreateSnakeSprite((int, int) position, (String, int) items)
        {
            return new SnakeSprite(snakeSpritesheet, position, items);
        }

        public ISprite CreateSpikeCrossSprite((int, int) position, (String, int) items)
        {
            return new SpikeCrossSprite(spikeCrossSpritesheet, position, items);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

