using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static Project1.Constants;
using static Project1.ICommand;

namespace Project1
{
    public class PausedInventory : IPaused
    {
        Texture2D inventoryText;
        Texture2D useBtext;
        Texture2D itemInventory;
        Texture2D smallItemBox;

        private static int spriteScale;

        private float screenMaxHeight; // Height of the top two-thirds of the screen

        //fix magic numbers constants
        private static int inventoryTextOffsetX = 130; 
        private static int inventoryTextOffsetY = 500; 
        private static int useBtextOffsetX = 100; 
        private static int useBtextOffsetY = 300;
        private static int smallItemBoxTextOffsetX = 190;
        private static int smallItemBoxTextOffsetY = 430;
        private static int itemInventoryBoxTextOffsetX = 400;
        private static int itemInventoryBoxTextOffsetY = 450;

        private static int itemInventoryBoxOffSet = 18;

        private static int inventoryboxWidth; 
        private static int inventoryboxHeight;

        int inventoryRows = 2;
        int inventoryCols = 4;
        Texture2D test;



        public PausedInventory(GraphicsDevice graphics, ContentManager content)
        {
            //assigning scale factors
            //is 580px
            screenMaxHeight = graphics.Viewport.Height * 2 / 3;
            
            spriteScale = 3;
            //inventory text
            inventoryText = content.Load<Texture2D>(assetName: "INVENTORYfont");
            //big item inventory
            itemInventory = content.Load<Texture2D>(assetName: "BigItemInventory");
            inventoryboxWidth = (itemInventory.Width - 2) / 4; //either plus or  minus
            inventoryboxHeight = (itemInventory.Height - 2 ) / 2;

            //small item box
            smallItemBox = content.Load<Texture2D>(assetName: "smallItemBox");



            //press B text
            useBtext = content.Load<Texture2D>(assetName: "USEBbuttonfont");

            test = content.Load<Texture2D>(assetName: "bow");

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Static parts of the inventory         !TODO: change hardcoded positions!
            
            // Calculate the position for all textures and draw
            Vector2 inventoryPosition = new Vector2(inventoryTextOffsetX, screenMaxHeight - inventoryTextOffsetY);
            Vector2 useBPosition = new Vector2(useBtextOffsetX, screenMaxHeight - useBtextOffsetY);
            Vector2 smallitemboxPosition = new Vector2(smallItemBoxTextOffsetX, screenMaxHeight - smallItemBoxTextOffsetY);
            Vector2 itemInventoryPosition = new Vector2(itemInventoryBoxTextOffsetX, screenMaxHeight - itemInventoryBoxTextOffsetY);

            spriteBatch.Draw(inventoryText, new Rectangle((int)inventoryPosition.X, (int)inventoryPosition.Y, inventoryText.Width * spriteScale, inventoryText.Height * spriteScale), Color.White);
            spriteBatch.Draw(useBtext, new Rectangle((int)useBPosition.X, (int)useBPosition.Y, useBtext.Width * spriteScale, useBtext.Height * spriteScale), Color.White);
            spriteBatch.Draw(smallItemBox, new Rectangle((int)smallitemboxPosition.X, (int)smallitemboxPosition.Y, smallItemBox.Width * spriteScale, smallItemBox.Height * spriteScale), Color.White);
            spriteBatch.Draw(itemInventory, new Rectangle((int)itemInventoryPosition.X, (int)itemInventoryPosition.Y, itemInventory.Width * spriteScale, itemInventory.Height * spriteScale), Color.White);

            List<inventoryItems> listOfItems = new List<inventoryItems>();
            var temp = getTotalNumOfItems();
            int totalItems = temp.Item1;
            listOfItems = temp.Item2;

            int maxItems = inventoryRows * inventoryCols;
            for (int i = 0; i < maxItems; i++)
            {
                // Calculate row and column based on the current index
                int row = i / inventoryCols;
                int col = i % inventoryCols;

                // Check if items run out
                if (totalItems <= 0)
                {
                    break; // Break out of the loop
                }
                int x = (int)itemInventoryPosition.X + (col * inventoryboxWidth * spriteScale) + itemInventoryBoxOffSet;
                int y = (int)itemInventoryPosition.Y + (row * inventoryboxHeight * spriteScale) + itemInventoryBoxOffSet;

                
                foreach (var item in listOfItems)
                {
                    //change or put each draw in each else if
                    IItem inventoryitem = null;

                    if (item == inventoryItems.boomerang)
                    {
                        inventoryitem = new BoomerangItem((x, y));
                        listOfItems.Remove(item);
                        

                    } else if(item == inventoryItems.bomb)
                    {
                        inventoryitem = new BombItem((x, y));
                        listOfItems.Remove(item);
                        
                    } else if( item == inventoryItems.bow)
                    {
                        inventoryitem = new Bow((x, y));
                        listOfItems.Remove(item);
                       

                    } else if (item == inventoryItems.key)
                    {
                        inventoryitem = new Key((x, y));
                        listOfItems.Remove(item);
                        
                    }
                   // spriteBatch.Draw(test, new Rectangle(x, y, inventoryboxWidth * 2 - 10, inventoryboxHeight * 2 - 10), Color.White);
                    inventoryitem.Draw(spriteBatch, new Vector2(x, y), 2);
                    break;
                }
                totalItems--;
            }



        }

        //function that gets the number of items and which ones so Draw can have the correct sprite to create
        public (int, List<inventoryItems>) getTotalNumOfItems() 
        {
            int num = 0;
            List<inventoryItems> list = new List<inventoryItems>();
            if (Player.itemInventory[(int)ITEMS.Bow] > 0)
            {
                num++;
                list.Add(inventoryItems.bow);
            }
            if (Player.itemInventory[(int)ITEMS.Bomb] > 0)
            {
                num++;
                list.Add(inventoryItems.bomb);
            }
            if (Player.itemInventory[(int)ITEMS.Key] > 0)
            {
                num++;
                list.Add(inventoryItems.key);
            }
            if (Player.itemInventory[(int)ITEMS.Boomerang] > 0)
            {
                num++;
                list.Add(inventoryItems.boomerang);
            }

            return (num, list);
        }

        public void Update()
        {
            
        }
    }
    public enum inventoryItems { bomb, boomerang, key, bow }
}
