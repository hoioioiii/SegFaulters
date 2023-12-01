using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;
using static Project1.Constants;
using static Project1.Game1;
//using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Project1.HUD
{
	public class LocationDisplay : IHUDEntity
    {
        private Texture2D titleRect;
        private Texture2D positionRect;
        private Vector2 coordTitle;
        private Vector2 coordMap;
        private SpriteFont font;
        private int titleOffset;
        private int activeRoomNumber;
        private Rectangle mapDestination;
        private Texture2D mapSprite;
        private Rectangle positionDestination;
        //holds the coordinates of the active green box for each room
        public static Vector2[] positionCoords;


        public LocationDisplay(GraphicsDevice graphics, ContentManager content)
        {
            Vector2[] tempPositionCoords = { new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y), new Vector2(STARTING_ROOM_X - ROOM_WIDTH, STARTING_ROOM_Y), new Vector2(STARTING_ROOM_X + ROOM_WIDTH, STARTING_ROOM_Y), new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y - MAP_ROW_HEIGHT), new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y - (2 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + ROOM_WIDTH, STARTING_ROOM_Y - (2 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X - ROOM_WIDTH, STARTING_ROOM_Y - (2 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X - ROOM_WIDTH, STARTING_ROOM_Y - (3 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y - (3 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y - (4 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X, STARTING_ROOM_Y - (5 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X - ROOM_WIDTH, STARTING_ROOM_Y - (5 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + ROOM_WIDTH, STARTING_ROOM_Y - (3 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + (2 * ROOM_WIDTH) + 5, STARTING_ROOM_Y - (3 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + (2 * ROOM_WIDTH) + 5, STARTING_ROOM_Y - (4 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + (3 * ROOM_WIDTH) + 5, STARTING_ROOM_Y - (4 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X + (3 * ROOM_WIDTH) + 5, STARTING_ROOM_Y - (4 * MAP_ROW_HEIGHT)), new Vector2(STARTING_ROOM_X - (2 * ROOM_WIDTH), STARTING_ROOM_Y - (3 * MAP_ROW_HEIGHT))};
            positionCoords = tempPositionCoords;

            font = content.Load<SpriteFont>("HUDFont");
            
            activeRoomNumber = 0;

            titleRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT / 3);

            //for room indicator on map
            positionRect = new Texture2D(graphics, 1, 1);
            positionRect.SetData(new[] { Color.Green });

            titleOffset = (HUD_SECTION_WIDTH - (int)font.MeasureString("-Level 1-").X) / 2;

            coordTitle = new Vector2(titleOffset, 0);

            coordMap = new Vector2(0, titleRect.Height);
            mapSprite = content.Load<Texture2D>(assetName: "RoomSprite");

            mapDestination = new Rectangle((int)coordMap.X, (int)coordMap.Y, HUD_SECTION_WIDTH, HUD_HEIGHT - titleRect.Height);

            positionDestination = new Rectangle((int)positionCoords[activeRoomNumber].X, (int)positionCoords[activeRoomNumber].Y, mapDestination.Width / POSITION_INDICATOR_SLICE_X, mapDestination.Height / POSITION_INDICATOR_SLICE_Y);
        }

        public void Update()
        {

            //update indicator based on which room we're in
            activeRoomNumber = RoomManager.GetCurrentRoomIndex() % TOTAL_ROOMS;
            positionDestination.X = (int)positionCoords[activeRoomNumber].X;
            positionDestination.Y = (int)positionCoords[activeRoomNumber].Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw title
            spriteBatch.DrawString(font, "-Level 1-", coordTitle, Color.White);

            //draw entire map
            spriteBatch.Draw(mapSprite, mapDestination, Color.Blue);

            //draw location indicator
            spriteBatch.Draw(positionRect, positionDestination, Color.Green);
        }
    }
}

