using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Project1;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Project1.Constants;
using Project1.Enemies.sprites;
using System.Collections.Generic;
using Project1.Enemies;

namespace Project1
{
    public class EnemySpriteFactory
    {
        private List<Texture2D[]> batStorage = new List<Texture2D[]>() { new Texture2D[BAT_FRAMES_U], new Texture2D[BAT_FRAMES_R], new Texture2D[BAT_FRAMES_D], new Texture2D[BAT_FRAMES_L], new Texture2D[BAT_FRAMES_DEATH] };
        //constants specify how mant frames there are for each sprite
        //make sure to edit the constants is constants.cs to reflect how many frames there are for each sprites
        private List<Texture2D[]> aquaDragonStorage = new List<Texture2D[]>() { new Texture2D[AQUA_FRAMES_U], new Texture2D[AQUA_FRAMES_R], new Texture2D[AQUA_FRAMES_D], new Texture2D[AQUA_FRAMES_L], new Texture2D[AQUA_FRAMES_DEATH] };

        private List<Texture2D[]> dinoStorage = new List<Texture2D[]>() { new Texture2D[DINO_FRAMES_U], new Texture2D[DINO_FRAMES_R], new Texture2D[DINO_FRAMES_D], new Texture2D[DINO_FRAMES_L], new Texture2D[DINO_FRAMES_DEATH] };

        private List<Texture2D[]> fireDinoStorage = new List<Texture2D[]>() { new Texture2D[FD_FRAMES_U], new Texture2D[FD_FRAMES_R], new Texture2D[FD_FRAMES_D], new Texture2D[FD_FRAMES_L], new Texture2D[FD_FRAMES_DEATH] };

        private List<Texture2D[]> dogMonsterStorage = new List<Texture2D[]>() { new Texture2D[DM_FRAMES_U], new Texture2D[DM_FRAMES_R], new Texture2D[DM_FRAMES_D], new Texture2D[DM_FRAMES_L], new Texture2D[DM_FRAMES_DEATH] };

        private List<Texture2D[]> flameStorage = new List<Texture2D[]>() { new Texture2D[FLAME_FRAMES_U], new Texture2D[FLAME_FRAMES_R], new Texture2D[FLAME_FRAMES_D], new Texture2D[FLAME_FRAMES_L], new Texture2D[FLAME_FRAMES_DEATH] };

        private List<Texture2D[]> handStorage = new List<Texture2D[]>() { new Texture2D[HAND_FRAMES_U], new Texture2D[HAND_FRAMES_R], new Texture2D[HAND_FRAMES_D], new Texture2D[HAND_FRAMES_L], new Texture2D[HAND_FRAMES_DEATH] };

        private List<Texture2D[]> jellyStorage = new List<Texture2D[]>() { new Texture2D[JELLY_FRAMES_U], new Texture2D[JELLY_FRAMES_R], new Texture2D[JELLY_FRAMES_D], new Texture2D[JELLY_FRAMES_L], new Texture2D[JELLY_FRAMES_DEATH] };

        private List<Texture2D[]> merchantStorage = new List<Texture2D[]>() { new Texture2D[MERCHANT_FRAMES_U], new Texture2D[MERCHANT_FRAMES_R], new Texture2D[MERCHANT_FRAMES_D], new Texture2D[MERCHANT_FRAMES_L], new Texture2D[MERCHANT_FRAMES_DEATH] };

        private List<Texture2D[]> oldManStorage = new List<Texture2D[]>() { new Texture2D[OLDMAN_FRAMES_U], new Texture2D[OLDMAN_FRAMES_R], new Texture2D[OLDMAN_FRAMES_D], new Texture2D[OLDMAN_FRAMES_L], new Texture2D[OLDMAN_FRAMES_DEATH] };

        private List<Texture2D[]> skelatonStorage = new List<Texture2D[]>() { new Texture2D[SKEL_FRAMES_U], new Texture2D[SKEL_FRAMES_R], new Texture2D[SKEL_FRAMES_D], new Texture2D[SKEL_FRAMES_L], new Texture2D[SKEL_FRAMES_DEATH] };

        private List<Texture2D[]> snakeStorage = new List<Texture2D[]>() { new Texture2D[SNAKE_FRAMES_U], new Texture2D[SNAKE_FRAMES_R], new Texture2D[SNAKE_FRAMES_D], new Texture2D[SNAKE_FRAMES_L], new Texture2D[SNAKE_FRAMES_DEATH] };

        private List<Texture2D[]> spikeStorage = new List<Texture2D[]>() { new Texture2D[SPIKE_FRAMES_U], new Texture2D[SPIKE_FRAMES_R], new Texture2D[SPIKE_FRAMES_D], new Texture2D[SPIKE_FRAMES_L], new Texture2D[SPIKE_FRAMES_DEATH] };

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
            //REFERENCE: list index 0 = Up Frames, 1 = Right Frames, 2  = Down Frames, 3 = Left Frames
            //add all frames to the arrays
            //anything in all caps still needs to be updates with the new sprit

            #region Bat Sprite Storage

           
                batStorage[UP][0] = content.Load<Texture2D>(assetName: "bat1");
                batStorage[UP][1] = content.Load<Texture2D>(assetName: "bat1");
                batStorage[UP][2] = content.Load<Texture2D>(assetName: "bat2");
                batStorage[UP][3] = content.Load<Texture2D>(assetName: "bat2");
            batStorage[RIGHT][0] = content.Load<Texture2D>(assetName: "bat2");
            batStorage[RIGHT][1] = content.Load<Texture2D>(assetName: "bat2");
            batStorage[RIGHT][2] = content.Load<Texture2D>(assetName: "bat2");
            batStorage[RIGHT][3] = content.Load<Texture2D>(assetName: "bat2");
            batStorage[DOWN][0] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[DOWN][1] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[DOWN][2] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[DOWN][3] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[LEFT][0] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[LEFT][1] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[LEFT][2] = content.Load<Texture2D>(assetName: "bat1");
            batStorage[LEFT][3] = content.Load<Texture2D>(assetName: "bat1");



            #endregion

            #region Aqua Dragon Storage

            //we can toss smthing else here

            aquaDragonStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "aquaRight1");
            aquaDragonStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "aquaRight2");
            aquaDragonStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "aquaLeft1");
            aquaDragonStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "aquaLeft2");

            aquaDragonStorage[(int)ENEMY_DIRECTION.up][0] = aquaDragonStorage[(int)ENEMY_DIRECTION.right][0];
            aquaDragonStorage[(int)ENEMY_DIRECTION.up][1] = aquaDragonStorage[(int)ENEMY_DIRECTION.left][0];
            aquaDragonStorage[(int)ENEMY_DIRECTION.up][2] = aquaDragonStorage[(int)ENEMY_DIRECTION.right][1];
            aquaDragonStorage[(int)ENEMY_DIRECTION.up][3] = aquaDragonStorage[(int)ENEMY_DIRECTION.left][1];

            aquaDragonStorage[(int)ENEMY_DIRECTION.down][0] = aquaDragonStorage[(int)ENEMY_DIRECTION.right][0];
            aquaDragonStorage[(int)ENEMY_DIRECTION.down][1] = aquaDragonStorage[(int)ENEMY_DIRECTION.left][0];
            aquaDragonStorage[(int)ENEMY_DIRECTION.down][2] = aquaDragonStorage[(int)ENEMY_DIRECTION.right][1];
            aquaDragonStorage[(int)ENEMY_DIRECTION.down][3] = aquaDragonStorage[(int)ENEMY_DIRECTION.left][1];

            #endregion

            #region Dino Storage

            //2 sprites for up and down, animation for left and right

            dinoStorage[(int)ENEMY_DIRECTION.up][0] = content.Load<Texture2D>(assetName: "dinoTop1");
            dinoStorage[(int)ENEMY_DIRECTION.up][1] = content.Load<Texture2D>(assetName: "dinoTop2");
            dinoStorage[(int)ENEMY_DIRECTION.up][2] = content.Load<Texture2D>(assetName: "dinoTop3");
            dinoStorage[(int)ENEMY_DIRECTION.down][0] = content.Load<Texture2D>(assetName: "dinoBottom1");
            dinoStorage[(int)ENEMY_DIRECTION.down][1] = content.Load<Texture2D>(assetName: "dinoBottom2");
            dinoStorage[(int)ENEMY_DIRECTION.down][2] = content.Load<Texture2D>(assetName: "dinoBottom1");
            dinoStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "dinoLeft1");
            dinoStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "dinoLeft2");
            dinoStorage[(int)ENEMY_DIRECTION.left][2] = content.Load<Texture2D>(assetName: "dinoLeft1");
            dinoStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "dinoRight1");
            dinoStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "dinoRight2");
            dinoStorage[(int)ENEMY_DIRECTION.right][2] = content.Load<Texture2D>(assetName: "dinoRight1");


            #endregion

            #region Fire Storage

            //all for left, left animation for all 4

            fireDinoStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "fd1");
            fireDinoStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "fd2");
            fireDinoStorage[(int)ENEMY_DIRECTION.left][2] = content.Load<Texture2D>(assetName: "fd3");
            fireDinoStorage[(int)ENEMY_DIRECTION.left][3] = content.Load<Texture2D>(assetName: "fd4");
            fireDinoStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "fd1");
            fireDinoStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "fd2");
            fireDinoStorage[(int)ENEMY_DIRECTION.right][2] = content.Load<Texture2D>(assetName: "fd3");
            fireDinoStorage[(int)ENEMY_DIRECTION.right][3] = content.Load<Texture2D>(assetName: "fd4");

            fireDinoStorage[(int)ENEMY_DIRECTION.up][0] = fireDinoStorage[(int)ENEMY_DIRECTION.left][0];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][1] = fireDinoStorage[(int)ENEMY_DIRECTION.left][0];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][2] = fireDinoStorage[(int)ENEMY_DIRECTION.left][1];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][3] = fireDinoStorage[(int)ENEMY_DIRECTION.left][1];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][4] = fireDinoStorage[(int)ENEMY_DIRECTION.left][2];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][5] = fireDinoStorage[(int)ENEMY_DIRECTION.left][2];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][6] = fireDinoStorage[(int)ENEMY_DIRECTION.left][3];
            fireDinoStorage[(int)ENEMY_DIRECTION.up][7] = fireDinoStorage[(int)ENEMY_DIRECTION.left][3];

            fireDinoStorage[(int)ENEMY_DIRECTION.down][0] = fireDinoStorage[(int)ENEMY_DIRECTION.right][0];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][1] = fireDinoStorage[(int)ENEMY_DIRECTION.right][0];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][2] = fireDinoStorage[(int)ENEMY_DIRECTION.right][1];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][3] = fireDinoStorage[(int)ENEMY_DIRECTION.right][1];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][4] = fireDinoStorage[(int)ENEMY_DIRECTION.right][2];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][5] = fireDinoStorage[(int)ENEMY_DIRECTION.right][2];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][6] = fireDinoStorage[(int)ENEMY_DIRECTION.right][3];
            fireDinoStorage[(int)ENEMY_DIRECTION.down][7] = fireDinoStorage[(int)ENEMY_DIRECTION.right][3];


            #endregion

            #region Dog Monster

            dogMonsterStorage[(int)ENEMY_DIRECTION.up][0] = content.Load<Texture2D>(assetName: "dm3");
            dogMonsterStorage[(int)ENEMY_DIRECTION.up][1] = content.Load<Texture2D>(assetName: "dm4");
            dogMonsterStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "dm7");
            dogMonsterStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "dm8");
            dogMonsterStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "dm5");
            dogMonsterStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "dm6");
            dogMonsterStorage[(int)ENEMY_DIRECTION.down][0] = content.Load<Texture2D>(assetName: "dm1");
            dogMonsterStorage[(int)ENEMY_DIRECTION.down][1] = content.Load<Texture2D>(assetName: "dm2");


            #endregion

            #region Flame Storage

            for (int i = 0; i < 4; i++)
            {
                flameStorage[i][0] = content.Load<Texture2D>(assetName: "fire1");
                flameStorage[i][1] = content.Load<Texture2D>(assetName: "fire2");
            }


            #endregion

            #region Hand Storage

            handStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "handLeftDown1");
            handStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "handLeftDown2");
            handStorage[(int)ENEMY_DIRECTION.left][2] = content.Load<Texture2D>(assetName: "handLeftUp1");
            handStorage[(int)ENEMY_DIRECTION.left][3] = content.Load<Texture2D>(assetName: "handLeftUp2 ");

            handStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "handRightDown1");
            handStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "handRightDown2");
            handStorage[(int)ENEMY_DIRECTION.right][2] = content.Load<Texture2D>(assetName: "handRightUp1");
            handStorage[(int)ENEMY_DIRECTION.right][3] = content.Load<Texture2D>(assetName: "handRightUp2");

            handStorage[(int)ENEMY_DIRECTION.up][0] = handStorage[(int)ENEMY_DIRECTION.right][0];
            handStorage[(int)ENEMY_DIRECTION.up][1] = handStorage[(int)ENEMY_DIRECTION.left][0];
            handStorage[(int)ENEMY_DIRECTION.up][2] = handStorage[(int)ENEMY_DIRECTION.right][1];
            handStorage[(int)ENEMY_DIRECTION.up][3] = handStorage[(int)ENEMY_DIRECTION.left][1];
            handStorage[(int)ENEMY_DIRECTION.up][4] = handStorage[(int)ENEMY_DIRECTION.right][2];
            handStorage[(int)ENEMY_DIRECTION.up][5] = handStorage[(int)ENEMY_DIRECTION.left][2];
            handStorage[(int)ENEMY_DIRECTION.up][6] = handStorage[(int)ENEMY_DIRECTION.right][3];
            handStorage[(int)ENEMY_DIRECTION.up][7] = handStorage[(int)ENEMY_DIRECTION.left][3];

            handStorage[(int)ENEMY_DIRECTION.down][0] = handStorage[(int)ENEMY_DIRECTION.right][0];
            handStorage[(int)ENEMY_DIRECTION.down][1] = handStorage[(int)ENEMY_DIRECTION.left][0];
            handStorage[(int)ENEMY_DIRECTION.down][2] = handStorage[(int)ENEMY_DIRECTION.right][1];
            handStorage[(int)ENEMY_DIRECTION.down][3] = handStorage[(int)ENEMY_DIRECTION.left][1];
            handStorage[(int)ENEMY_DIRECTION.down][4] = handStorage[(int)ENEMY_DIRECTION.right][2];
            handStorage[(int)ENEMY_DIRECTION.down][5] = handStorage[(int)ENEMY_DIRECTION.left][2];
            handStorage[(int)ENEMY_DIRECTION.down][6] = handStorage[(int)ENEMY_DIRECTION.right][3];
            handStorage[(int)ENEMY_DIRECTION.down][7] = handStorage[(int)ENEMY_DIRECTION.left][3];

            #endregion

            #region Jelly Storage

            for (int i = 0; i < 4; i++)
            {
                jellyStorage[i][0] = content.Load<Texture2D>(assetName: "gel12");
                jellyStorage[i][1] = content.Load<Texture2D>(assetName: "gel21");
                jellyStorage[i][2] = content.Load<Texture2D>(assetName: "gel12");
                jellyStorage[i][2] = content.Load<Texture2D>(assetName: "gel21");
            }

            #endregion

            #region Merchant Storage

            for (int i = 0; i < 4; i++)
            {
                merchantStorage[i][0] = content.Load<Texture2D>(assetName: "merchant");
            }

            #endregion

            #region Old Man Storage

            for (int i = 0; i < 4; i++)
            {
                oldManStorage[i][0] = content.Load<Texture2D>(assetName: "ZeldaSpriteOldMan");
            }

            #endregion

            #region Skelaton Storage

            for (int i = 0; i < 4; i++)
            {
                skelatonStorage[i][0] = content.Load<Texture2D>(assetName: "skeleton1");
                skelatonStorage[i][1] = content.Load<Texture2D>(assetName: "skeleton2");
            }

            #endregion

            #region Snake Storage

            snakeStorage[(int)ENEMY_DIRECTION.right][0] = content.Load<Texture2D>(assetName: "snakeRight1");
            snakeStorage[(int)ENEMY_DIRECTION.right][1] = content.Load<Texture2D>(assetName: "snakeRight2");
            snakeStorage[(int)ENEMY_DIRECTION.left][0] = content.Load<Texture2D>(assetName: "snakeLeft1");
            snakeStorage[(int)ENEMY_DIRECTION.left][1] = content.Load<Texture2D>(assetName: "snakeLeft2");

            snakeStorage[(int)ENEMY_DIRECTION.up][0] = snakeStorage[(int)ENEMY_DIRECTION.right][0];
            snakeStorage[(int)ENEMY_DIRECTION.up][1] = snakeStorage[(int)ENEMY_DIRECTION.left][0];
            snakeStorage[(int)ENEMY_DIRECTION.up][2] = snakeStorage[(int)ENEMY_DIRECTION.right][1];
            snakeStorage[(int)ENEMY_DIRECTION.up][3] = snakeStorage[(int)ENEMY_DIRECTION.left][1];

            snakeStorage[(int)ENEMY_DIRECTION.down][0] = snakeStorage[(int)ENEMY_DIRECTION.right][0];
            snakeStorage[(int)ENEMY_DIRECTION.down][1] = snakeStorage[(int)ENEMY_DIRECTION.left][0];
            snakeStorage[(int)ENEMY_DIRECTION.down][2] = snakeStorage[(int)ENEMY_DIRECTION.right][1];
            snakeStorage[(int)ENEMY_DIRECTION.down][3] = snakeStorage[(int)ENEMY_DIRECTION.left][1];

            #endregion

            #region Spike Storage

            for (int i = 0; i < 4; i++)
            {
                spikeStorage[i][0] = content.Load<Texture2D>(assetName: "BladeTrap");
            }


            #endregion
            //REFACTOR make things based on direction they are facing

            // More Content.Load calls follow
            //...
        }


        public ISprite CreateBatSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new BatSprite(batStorage, animation,movement,direction,state,time);
        }

        public ISprite CreateBossAquaDragonSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
           
            return new BossAquaDragonSprite(aquaDragonStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateDinoSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new BossDinoSprite(dinoStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateFireDragonSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new BossFireDragonSprite(fireDinoStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateDogMonsterSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new DogMonsterSprite(dogMonsterStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateFlameSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new FlameSprite(flameStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateHandSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new HandSprite(handStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateJellySprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new JellySprite(jellyStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateMerchantSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new MerchantSprite(merchantStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateOldManSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new OldManSprite(oldManStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateSkeletonSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new SkeletonSprite(skelatonStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateSnakeSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new SnakeSprite(snakeStorage, animation, movement, direction, state, time);
        }

        public ISprite CreateSpikeCrossSprite(IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time)
        {
            return new SpikeCrossSprite(spikeStorage, animation, movement, direction, state, time);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

