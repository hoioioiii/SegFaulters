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
        public static Dictionary<(int, int), (int, int)> blockPositionDictionary;
        private static IEnvironment[] blocksArray;
        private static IEnvironment[] doorArray;
        private static Texture2D[] doorSpriteArray;

        public static void LoadContent(ContentManager content)
        {
            blocksArray = new IEnvironment[0];
            doorArray = new IEnvironment[0];
            //load in background content
            levelBackground = content.Load<Texture2D>("LevelBackground");

            //load in door content
            doorSpriteArray = new Texture2D[4];
            doorSpriteArray[0] = content.Load<Texture2D>("DoorWEST");
            doorSpriteArray[1] = content.Load<Texture2D>("DoorEAST");
            doorSpriteArray[2] = content.Load<Texture2D>("DoorSOUTH");
            doorSpriteArray[3] = content.Load<Texture2D>("DoorNORTH");

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
        }

        //loads blocks given data of row,col and the texture of the block
        public static void LoadBlocks((int,int)[] blocksToLoad)
        {
            blocksArray = new IEnvironment[blocksToLoad.Length];

            for (int i = 0; i < blocksToLoad.Length; i++)
            {
                Texture2D texture = EnvironmentIterator.getCurrEnemy();
                int posX = blockPositionDictionary[blocksToLoad[i]].Item1;
                int posY = blockPositionDictionary[blocksToLoad[i]].Item2;
                blocksArray[i] = new CurrentBlock(texture, posX, posY);
                Game1.GameObjManager.addNewEnvironment(blocksArray[i]);
            }
        }

        public static void LoadDoors((string, (int, bool))[] doorsToLoad)
        {
            doorArray = new IEnvironment[doorsToLoad.Length];
            for( int i = 0;i < doorsToLoad.Length;i++)
            {
                string direction = doorsToLoad[i].Item1;
                int destinationRoom = doorsToLoad[i].Item2.Item1;
                bool isLocked = doorsToLoad[i].Item2.Item2;
                doorArray[i] = new Door(doorSpriteArray, direction, destinationRoom, isLocked);
                Game1.GameObjManager.addDoors(doorArray[i]);
            }
        }
   
        public static void Update()
        {
            foreach (IEnvironment block in blocksArray) {
                block.Update();
            }
        }

        //fix tom
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelBackground, new Rectangle(17, -22, levelBackground.Width * 3, levelBackground.Height * 3), Color.White);

            foreach (IEnvironment block in blocksArray)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnvironment door in doorArray)
            {
                door.Draw(spriteBatch);
            }
        }

    }
}
