using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.HUD;
using System;
using System.Collections.Generic;
using static Project1.Constants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PausedMap : IPaused
    {
        private int screenMaxHeight;
        private int spriteScale;
        private Texture2D compassPauseText;
        private Texture2D mapItem;
        private Texture2D mapPauseText;
        private Texture2D blackSquareRoom;
        private Texture2D greenSquareOnMap;
        private Texture2D pausedMap;

        private static List<bool> roomsEntered = new List<bool>(18);
        private static int compassPauseTextX = 130;
        private static int compassPauseTextY = 100;
        private static int mapItemX = 210;
        private static int mapItemY = 180;
        private static int mapPauseTextX = 180;
        private static int mapPauseTextY = 230;
        private static int pausedMapX = 410;
        private static int pausedMapY = 230;

        private static int spriteScaleOffset1 = 100;
        private static int greenBoxOffset = 3;
        private static int locationDisplayOffSetX = 470;
        private static int locationDisplayOffSetY = 280;

        private Vector2 compassPauseTextPos;
        private Vector2 mapItemPos;
        private Vector2 mapPauseTextPos;
        private Vector2 blackSquareRoomPos;
        private Vector2 greenSquareOnMapPos;
        private Vector2 pausedMapPos;

        private static int activeRoomNumber;
        private static int totalRooms = 18;

        Vector2 locationdisplayRoom;


        public PausedMap(GraphicsDevice graphics, ContentManager content)
        {
            //assigning scale factors
            //is 580px
            screenMaxHeight = graphics.Viewport.Height * 2 / 3;

            spriteScale = 2;
            compassPauseText = content.Load<Texture2D>(assetName: "compassPauseText");
            mapItem = content.Load<Texture2D>(assetName: "mapItem");
            mapPauseText = content.Load<Texture2D>(assetName: "mapPauseText");
            blackSquareRoom = content.Load<Texture2D>(assetName: "blackSquareRoom");

            // TODO: FIX THESE TWO ASSETS!!!
            greenSquareOnMap = content.Load<Texture2D>(assetName: "greenSquareOnMap");
            pausedMap = content.Load<Texture2D>(assetName: "pausedMap");

            for (int i = 0; i < 19; i++)
            {
                roomsEntered.Add(false);

            }




        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate the position for all textures and draw
            compassPauseTextPos = new Vector2(compassPauseTextX, screenMaxHeight - compassPauseTextY);
            mapItemPos = new Vector2(mapItemX, screenMaxHeight - mapItemY);
            mapPauseTextPos = new Vector2(mapPauseTextX, screenMaxHeight - mapPauseTextY);
            pausedMapPos = new Vector2(pausedMapX, screenMaxHeight - pausedMapY);

            spriteBatch.Draw(compassPauseText, new Rectangle((int)compassPauseTextPos.X, (int)compassPauseTextPos.Y, compassPauseText.Width * spriteScale, compassPauseText.Height * spriteScale), Color.White);
            spriteBatch.Draw(mapItem, new Rectangle((int)mapItemPos.X, (int)mapItemPos.Y, mapItem.Width * spriteScale, mapItem.Height * spriteScale), Color.White);
            spriteBatch.Draw(mapPauseText, new Rectangle((int)mapPauseTextPos.X, (int)mapPauseTextPos.Y, mapPauseText.Width * spriteScale, mapPauseText.Height * spriteScale), Color.White);
            spriteBatch.Draw(pausedMap, new Rectangle((int)pausedMapPos.X, (int)pausedMapPos.Y, pausedMap.Width+ spriteScaleOffset1, pausedMap.Height + spriteScaleOffset1), Color.White);



            for (int i =0; i< roomsEntered.Count - 1; i++)
            {
                if (roomsEntered[i] == true)
                {
                    locationdisplayRoom = LocationDisplay.positionCoords[i];
                    locationdisplayRoom.X += locationDisplayOffSetX;
                    locationdisplayRoom.Y += locationDisplayOffSetY;
                    spriteBatch.Draw(blackSquareRoom, new Rectangle((int)locationdisplayRoom.X, (int)locationdisplayRoom.Y, blackSquareRoom.Width, blackSquareRoom.Height), Color.White);
                }
            }
            spriteBatch.Draw(greenSquareOnMap, new Rectangle((int)LocationDisplay.positionCoords[activeRoomNumber].X + greenBoxOffset + 470, (int)LocationDisplay.positionCoords[activeRoomNumber].Y + 280 + greenBoxOffset, greenSquareOnMap.Width, greenSquareOnMap.Height), Color.White);


        }


        public void Update()
        {
            activeRoomNumber = RoomManager.GetCurrentRoomIndex() % totalRooms;
            roomsEntered[activeRoomNumber] = true;

        }








        public void moveSelectorLeft()
        {
            //no-op
        }

        public void moveSelectorRight()
        {
            //no-op
        }
    }





}
