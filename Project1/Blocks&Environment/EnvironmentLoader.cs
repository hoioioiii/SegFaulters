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
            ROOM_FRAME_HEIGHT = levelBackground.Height * 3;
            ROOM_FRAME_WIDTH = levelBackground.Width * 3;

            //load in door content
            doorSpriteArray = new Texture2D[10];
            doorSpriteArray[(int)DOORTEXTURES.DOORWEST] = content.Load<Texture2D>("DoorWEST");
            doorSpriteArray[(int)DOORTEXTURES.DOOREAST] = content.Load<Texture2D>("DoorEAST");
            doorSpriteArray[(int)DOORTEXTURES.DOORSOUTH] = content.Load<Texture2D>("DoorSOUTH");
            doorSpriteArray[(int)DOORTEXTURES.DOORNORTH] = content.Load<Texture2D>("DoorNORTH");
            doorSpriteArray[(int)DOORTEXTURES.LOCKDOORNORTH] = content.Load<Texture2D>("Locked DoorNORTH");
            doorSpriteArray[(int)DOORTEXTURES.LOCKDOORSOUTH] = content.Load<Texture2D>("LockedDoorSOUTH");
            doorSpriteArray[(int)DOORTEXTURES.LOCKDOORWEST] = content.Load<Texture2D>("LockedDoorWEST");
            doorSpriteArray[(int)DOORTEXTURES.LOCKDOOREAST] = content.Load<Texture2D>("LockedDoorEAST");
            doorSpriteArray[(int)DOORTEXTURES.TUNNELDOORNORTH] = content.Load<Texture2D>("TunnelDoorNORTH");
            doorSpriteArray[(int)DOORTEXTURES.TUNNELDOORSOUTH] = content.Load<Texture2D>("TunnelDoorSOUTH");


        }

        //loads blocks given data of row,col and the texture of the block
        public static void LoadBlocks((string, (int, int))[] blocksToLoad)
        {
            blocksArray = new IEnvironment[blocksToLoad.Length];

            for (int i = 0; i < blocksToLoad.Length; i++)
            {
                //Texture2D texture = EnvironmentIterator.getCurrEnemy();
                String name = blocksToLoad[i].Item1;
                Texture2D texture = EnvironmentIterator.GetTextureFromName(blocksToLoad[i].Item1);
                (int, int) positionFromData = blocksToLoad[i].Item2;

                (int, int) pos = PositionGrid.getPosBasedOnGrid(positionFromData.Item1, positionFromData.Item2);
                int posX = pos.Item1;
                int posY = pos.Item2;

                //IF collision is not necessary!
                bool canCollide = true;
                if (name == "CarpetBlock" || name == "BlackRoom")
                    canCollide = false;

                blocksArray[i] = new CurrentBlock(texture, posX, posY, canCollide, name);
                Game1.GameObjManager.addNewEnvironment(blocksArray[i]);
            }
        }

        public static void LoadDoors(((string, bool), (int, bool))[] doorsToLoad)
        {
            doorArray = new Door[doorsToLoad.Length];
            for (int i = 0; i < doorsToLoad.Length; i++)
            {
                string directionString = doorsToLoad[i].Item1.Item1;
                DIRECTION directionEnum = DirectionToEnum(directionString);
                int destinationRoom = doorsToLoad[i].Item2.Item1;
                bool isLocked = doorsToLoad[i].Item2.Item2;
                bool isTunnel = doorsToLoad[i].Item1.Item2;
                doorArray[i] = new Door(doorSpriteArray, directionEnum, destinationRoom, isLocked, isTunnel);
                Game1.GameObjManager.addDoors(doorArray[i]);
            }
        }

        public static DIRECTION DirectionToEnum(string directionString)
        {
            DIRECTION direction = DIRECTION.left;
            switch (directionString)
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
            foreach (IEnvironment block in blocksArray)
            {
                block.Update();
            }
        }

        //fix tom
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelBackground, new Rectangle(BG_START_X + FRAME_BUFFER_X, BG_START_Y + FRAME_BUFFER_Y, ROOM_FRAME_WIDTH, ROOM_FRAME_HEIGHT), Color.White);

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
