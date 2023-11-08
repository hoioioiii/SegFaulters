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
    public class PausedInventory : IPaused
    {
        Texture2D inventoryText;
        Texture2D useBtext;
        Texture2D itemInventory;
        Texture2D smallItemBox;

        private static int textScale;

        private float screenMaxHeight; // Height of the top two-thirds of the screen

        //fix magic numbers constants
        private static int inventoryTextOffsetX = 130; 
        private static int inventoryTextOffsetY = 500; 
        private static int useBtextOffsetX = 100; 
        private static int useBtextOffsetY = 300;
        private static int smallItemBoxTextOffsetX = 130;
        private static int smallItemBoxTextOffsetY = 450;
        private static int itemInventoryBoxTextOffsetX = 400;
        private static int itemInventoryBoxTextOffsetY = 450;




        public PausedInventory(GraphicsDevice graphics, ContentManager content)
        {
            //assigning scale factors
            //is 580px
            screenMaxHeight = graphics.Viewport.Height * 2 / 3;
            textScale = 3;
            //inventory text
            inventoryText = content.Load<Texture2D>(assetName: "INVENTORYfont");

            //small item box
            smallItemBox = content.Load<Texture2D>(assetName: "smallItemBox");
            //big item inventory
            itemInventory = content.Load<Texture2D>(assetName: "BigItemInventory");


            //press B text
            useBtext = content.Load<Texture2D>(assetName: "USEBbuttonfont");

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Static parts of the inventory         !TODO: change hardcoded positions!
            
            // Calculate the position for all textures and draw
            Vector2 inventoryPosition = new Vector2(inventoryTextOffsetX, screenMaxHeight - inventoryTextOffsetY);
            Vector2 useBPosition = new Vector2(useBtextOffsetX, screenMaxHeight - useBtextOffsetY);
            Vector2 smallitemboxPosition = new Vector2(smallItemBoxTextOffsetX, screenMaxHeight - smallItemBoxTextOffsetY);
            Vector2 itemInventoryPosition = new Vector2(itemInventoryBoxTextOffsetX, screenMaxHeight - itemInventoryBoxTextOffsetY);

            spriteBatch.Draw(inventoryText, new Rectangle((int)inventoryPosition.X, (int)inventoryPosition.Y, inventoryText.Width * textScale, inventoryText.Height * textScale), Color.White);
            spriteBatch.Draw(useBtext, new Rectangle((int)useBPosition.X, (int)useBPosition.Y, useBtext.Width * textScale, useBtext.Height * textScale), Color.White);
            spriteBatch.Draw(smallItemBox, new Rectangle((int)smallitemboxPosition.X, (int)smallitemboxPosition.Y, smallItemBox.Width * textScale, smallItemBox.Height * textScale), Color.White);
            spriteBatch.Draw(itemInventory, new Rectangle((int)itemInventoryPosition.X, (int)itemInventoryPosition.Y, itemInventory.Width * textScale, itemInventory.Height * textScale), Color.White);


        }

        public void Update()
        {
            
        }
    }
}
