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

        private static List<bool> roomsEntered = new List<bool>(TOTAL_ROOMS);
       
        private Vector2 compassPauseTextPos;
        private Vector2 mapItemPos;
        private Vector2 mapPauseTextPos;
        
        private Vector2 pausedMapPos;

        private static int activeRoomNumber;
        

        Vector2 locationdisplayRoom;


        public PausedMap(GraphicsDevice graphics, ContentManager content)
        {
            
            screenMaxHeight = graphics.Viewport.Height * DOUBLE / SPRITE_SCALE;

            spriteScale = 2;
            compassPauseText = content.Load<Texture2D>(assetName: "compassPauseText");
            mapItem = content.Load<Texture2D>(assetName: "mapItem");
            mapPauseText = content.Load<Texture2D>(assetName: "mapPauseText");
            blackSquareRoom = content.Load<Texture2D>(assetName: "blackSquareRoom");

           
            greenSquareOnMap = content.Load<Texture2D>(assetName: "greenSquareOnMap");
            pausedMap = content.Load<Texture2D>(assetName: "pausedMap");

            for (int i = 0; i < ROOMS_ENTERED; i++)
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
            spriteBatch.Draw(greenSquareOnMap, new Rectangle((int)LocationDisplay.positionCoords[activeRoomNumber].X + greenBoxOffset + locationDisplayOffSetX, (int)LocationDisplay.positionCoords[activeRoomNumber].Y + locationDisplayOffSetY + greenBoxOffset, greenSquareOnMap.Width, greenSquareOnMap.Height), Color.White);


        }


        public void Update()
        {
            activeRoomNumber = RoomManager.GetCurrentRoomIndex() % totalRooms;
            roomsEntered[activeRoomNumber] = true;

        }

        public void MoveSelectorLeft()
        {
            //no-op
        }

        public void MoveSelectorRight()
        {
            //no-op
        }
    }





}
