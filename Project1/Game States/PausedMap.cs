using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        private static int compassPauseTextX = 130;
        private static int compassPauseTextY = 100;
        private static int mapItemX = 210;
        private static int mapItemY = 180;
        private static int mapPauseTextX = 180;
        private static int mapPauseTextY = 230;
        private Vector2 compassPauseTextPos;
        private Vector2 mapItemPos;
        private Vector2 mapPauseTextPos;


        public PausedMap(GraphicsDevice graphics, ContentManager content)
        {
            //assigning scale factors
            //is 580px
            screenMaxHeight = graphics.Viewport.Height * 2 / 3;

            spriteScale = 2;
            compassPauseText = content.Load<Texture2D>(assetName: "compassPauseText");
            mapItem = content.Load<Texture2D>(assetName: "mapItem");
            mapPauseText = content.Load<Texture2D>(assetName: "mapPauseText");




        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate the position for all textures and draw
            compassPauseTextPos = new Vector2(compassPauseTextX, screenMaxHeight - compassPauseTextY);
            mapItemPos = new Vector2(mapItemX, screenMaxHeight - mapItemY);
            mapPauseTextPos = new Vector2(mapPauseTextX, screenMaxHeight - mapPauseTextY);

            spriteBatch.Draw(compassPauseText, new Rectangle((int)compassPauseTextPos.X, (int)compassPauseTextPos.Y, compassPauseText.Width * spriteScale, compassPauseText.Height * spriteScale), Color.White);
            spriteBatch.Draw(mapItem, new Rectangle((int)mapItemPos.X, (int)mapItemPos.Y, mapItem.Width * spriteScale, mapItem.Height * spriteScale), Color.White);
            spriteBatch.Draw(mapPauseText, new Rectangle((int)mapPauseTextPos.X, (int)mapPauseTextPos.Y, mapPauseText.Width * spriteScale, mapPauseText.Height * spriteScale), Color.White);


        }


        public void Update()
        {
            //no-op
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
