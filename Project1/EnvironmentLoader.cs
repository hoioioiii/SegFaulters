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
        private static IEnvironment[] blocksArray;
        private static Door[] doorArray;
        private static Texture2D[] doorSpriteArray;        

        public static void LoadContent(ContentManager content)
        {
            blocksArray = new IEnvironment[0];
            doorArray = new Door[0];
            //load in background content
            levelBackground = content.Load<Texture2D>("LevelBackground");

            //load in door content
            doorSpriteArray = new Texture2D[8];
            doorSpriteArray[0] = content.Load<Texture2D>("DoorWEST");
            doorSpriteArray[1] = content.Load<Texture2D>("DoorEAST");
            doorSpriteArray[2] = content.Load<Texture2D>("DoorSOUTH");
            doorSpriteArray[3] = content.Load<Texture2D>("DoorNORTH");
            doorSpriteArray[4] = content.Load<Texture2D>("Locked DoorNORTH");
            doorSpriteArray[5] = content.Load<Texture2D>("LockedDoorSOUTH");
            doorSpriteArray[6] = content.Load<Texture2D>("LockedDoorWEST");
            doorSpriteArray[7] = content.Load<Texture2D>("LockedDoorEAST");

        }

        //loads blocks given data of row,col and the texture of the block
        public static void LoadBlocks((int,int)[] blocksToLoad)
        {
            blocksArray = new IEnvironment[blocksToLoad.Length];

            for (int i = 0; i < blocksToLoad.Length; i++)
            {
                Texture2D texture = EnvironmentIterator.getCurrEnemy();
                (int, int) pos = PositionGrid.getPosBasedOnGrid(blocksToLoad[i].Item1, blocksToLoad[i].Item2);
                int posX = pos.Item1;
                int posY = pos.Item2;

                blocksArray[i] = new CurrentBlock(texture, posX, posY);
                Game1.GameObjManager.addNewEnvironment(blocksArray[i]);
            }
        }

        public static void LoadDoors((string, (int, bool))[] doorsToLoad)
        {
            doorArray = new Door[doorsToLoad.Length];
            for( int i = 0;i < doorsToLoad.Length;i++)
            {
                string directionString = doorsToLoad[i].Item1;
                 DIRECTION directionEnum = DirectionToEnum(directionString);
                int destinationRoom = doorsToLoad[i].Item2.Item1;
                bool isLocked = doorsToLoad[i].Item2.Item2;
                doorArray[i] = new Door(doorSpriteArray, directionEnum, destinationRoom, isLocked);
                Game1.GameObjManager.addDoors(doorArray[i]);
            }
        }

        private static DIRECTION DirectionToEnum(String directionString)
        {
            DIRECTION direction = DIRECTION.left;
            switch(directionString)
            {
                case "north":
                    direction = DIRECTION.up;
                    break;
                case "south":
                    direction = DIRECTION.down;
                    break;
                case "west":
                    direction = DIRECTION.left;
                    break;
                case "east":
                    direction = DIRECTION.right;
                    break;
                default:
                    break;
            }
            return direction;


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
            spriteBatch.Draw(levelBackground, new Rectangle(17, -22 + FRAME_BUFFER, levelBackground.Width * 3, levelBackground.Height * 3), Color.White);

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
