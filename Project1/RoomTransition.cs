using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Project1.Constants;


namespace Project1
{
    internal static class RoomTransition
    {
        private static Texture2D[] roomTextures;
        private static Texture2D roomTexture;
        private static bool shouldDraw;
        private static int nextRoomNum;

        private static int positionX;
        private static int positionY;

        public static void StartScrolling(Room nextRoom, int nextRoomNum, DIRECTION doorDirection)
        {
            roomTexture = roomTextures[nextRoomNum];
            getPositionFromDirection(doorDirection);

            shouldDraw = true;


            //roomTexture = roomTextures[nextRoomNum];

            // get the next room texture
            //Texture2D nextRoomTexture = roomTextures[nextRoomNum];
            //draw it either above, to the side, or below it

            //wait for screen scroller to stop

            //finally load in the actual room.
            nextRoom.Load();


        }

        private static void getPositionFromDirection(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.up:
                    positionX = 17;
                    positionY = -230;
                    break;
                case DIRECTION.down:
                    positionX = 17;
                    positionY = -235 + ROOM_FRAME_HEIGHT * 2;
                    break;
                case DIRECTION.right:
                    positionX = 17 + ROOM_FRAME_WIDTH;
                    positionY = -230 + ROOM_FRAME_HEIGHT;
                    break;
                case DIRECTION.left:
                    positionX = 17 - ROOM_FRAME_WIDTH;
                    positionY = -230 + ROOM_FRAME_HEIGHT;
                    break;
                default:
                    return;
            }
        }

        public static void LoadTextures(ContentManager content)
        {
            roomTextures = new Texture2D[17];

            roomTextures[0] = content.Load<Texture2D>("Room0");
            roomTextures[1] = content.Load<Texture2D>("Room1");
            roomTextures[2] = content.Load<Texture2D>("Room2");
            roomTextures[3] = content.Load<Texture2D>("Room3");
            roomTextures[4] = content.Load<Texture2D>("Room4");
            roomTextures[5] = content.Load<Texture2D>("Room5");
            roomTextures[6] = content.Load<Texture2D>("Room6");
            roomTextures[7] = content.Load<Texture2D>("Room7");
            roomTextures[8] = content.Load<Texture2D>("Room8");
            roomTextures[9] = content.Load<Texture2D>("Room9");
            roomTextures[10] = content.Load<Texture2D>("Room10");
            roomTextures[11] = content.Load<Texture2D>("Room11");
            roomTextures[12] = content.Load<Texture2D>("Room12");
            roomTextures[13] = content.Load<Texture2D>("Room13");
            roomTextures[14] = content.Load<Texture2D>("Room14");
            roomTextures[15] = content.Load<Texture2D>("Room15");
            roomTextures[16] = content.Load<Texture2D>("Room16");


            roomTexture = roomTextures[2];
            positionX = 0;
            positionY = 0;

            shouldDraw = false;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (shouldDraw)
            {
                spriteBatch.Draw(roomTexture, new Rectangle(positionX, positionY, ROOM_FRAME_WIDTH, ROOM_FRAME_HEIGHT), Color.White);

            }

        }
    }
}


