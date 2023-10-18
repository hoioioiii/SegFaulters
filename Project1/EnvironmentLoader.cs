using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Project1.Constants;
using System.Runtime.CompilerServices;

namespace Project1
{
    //loads in the blocks needed for the level, the correct background, and the doors
    public static class EnvironmentLoader
    {
        private static Texture2D levelBackground;
        private static Dictionary<(int, int), (int, int)> blockPositionDictionary;
        private static IEnvironment[] blocksArray;

        public static void LoadContent(ContentManager content)
        {
            //load in background content
            levelBackground = content.Load<Texture2D>("LevelBackground");

            blockPositionDictionary = new Dictionary<(int, int), (int, int)>(); //<(row, col), (posX, posY)>
            //load in blockPositionDictionary 7 rows x 12 columns
            for (int row = 0; row < 7; row++) //per 7 rows
            {
                for(int col = 0; col < 12; col++) //12 columns
                {
                    //114, 75 is the starting point of the grid
                    //48 is the width/height of each block
                    blockPositionDictionary.Add((row, col), (114 + BLOCK_DIMENSION * (col), 75 + BLOCK_DIMENSION * (row)));
                }
            }

            (int, int)[] blocksToLoad = new (int, int)[2];
            blocksToLoad[0] = (2, 3);
            blocksToLoad[1] = (5, 10);

            LoadBlocks(blocksToLoad);

        }

        //loads blocks given data of row,col and the texture of the block
        private static void LoadBlocks((int,int)[] blocksToLoad)
        {
            blocksArray = new IEnvironment[blocksToLoad.Length];

            for (int i = 0; i < blocksToLoad.Length; i++)
            {
                Texture2D texture = EnvironmentIterator.getCurrEnemy();
                int posX = blockPositionDictionary[blocksToLoad[i]].Item1;
                int posY = blockPositionDictionary[blocksToLoad[i]].Item2;
                blocksArray[i] = new CurrentBlock(texture, posX, posY);
            }
        }

        public static void Update()
        {
            foreach (IEnvironment block in blocksArray) {
                block.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelBackground, new Rectangle(17, -22, levelBackground.Width * 3, levelBackground.Height * 3), Color.White);

            foreach (IEnvironment block in blocksArray)
            {
                block.Draw(spriteBatch);
            }
        }

    }
}
