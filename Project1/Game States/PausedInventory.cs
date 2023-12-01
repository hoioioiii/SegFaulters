using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1;
using Project1.HUD;
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
        Texture2D redItemSelector;

        private static int spriteScale;

        private float screenMaxHeight; // Height of the top two-thirds of the screen

        //fix magic numbers constants
        private static int inventoryTextOffsetX = 130; 
        private static int inventoryTextOffsetY = 500 + ROOM_FRAME_HEIGHT; 
        private static int useBtextOffsetX = 100; 
        private static int useBtextOffsetY = 300 + ROOM_FRAME_HEIGHT;
        private static int smallItemBoxTextOffsetX = 190;
        private static int smallItemBoxTextOffsetY = 430 + ROOM_FRAME_HEIGHT;
        private static int itemInventoryBoxTextOffsetX = 400;
        private static int itemInventoryBoxTextOffsetY = 450 + ROOM_FRAME_HEIGHT;

        private static int itemInventoryBoxOffSet = 18;
        private static int itemInventoryBoxOffSet2 = 4;
        private static int itemInventoryBoxOffSet3 = 16;
        private static int itemInventoryBoxScaleOffSet = 10;

        private static int inventoryboxWidth; 
        private static int inventoryboxHeight;

        private static Vector2 selectedItemPosition;
        private static int currentItemIndex = 0;

        int inventoryRows = 2;
        int inventoryCols = 4;
        int selectorSmoother = 0;

        Vector2 inventoryPosition;
        Vector2 useBPosition;
        Vector2 smallitemboxPosition;
        Vector2 itemInventoryPosition;

        private static List<(Vector2, inventoryItems)> itemLocations = new List<(Vector2, inventoryItems)>();



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
            redItemSelector = content.Load<Texture2D>(assetName: "redItemSelector");

            //small item box
            smallItemBox = content.Load<Texture2D>(assetName: "smallItemBox");



            //press B text
            useBtext = content.Load<Texture2D>(assetName: "USEBbuttonfont");

            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Static parts of the inventory         !TODO: change hardcoded positions!
            
            // Calculate the position for all textures and draw
            inventoryPosition = new Vector2(inventoryTextOffsetX, screenMaxHeight - inventoryTextOffsetY);
            useBPosition = new Vector2(useBtextOffsetX, screenMaxHeight - useBtextOffsetY);
            smallitemboxPosition = new Vector2(smallItemBoxTextOffsetX, screenMaxHeight - smallItemBoxTextOffsetY);
            itemInventoryPosition = new Vector2(itemInventoryBoxTextOffsetX, screenMaxHeight - itemInventoryBoxTextOffsetY);

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
                    itemLocations.Add((new Vector2(x, y), item));
                    break;
                    
                }
                totalItems--;
            }

            selectedItemPosition = itemLocations[currentItemIndex].Item1;
            spriteBatch.Draw(redItemSelector, new Rectangle((int)selectedItemPosition.X - itemInventoryBoxOffSet2, (int)selectedItemPosition.Y - itemInventoryBoxOffSet2, redItemSelector.Width + itemInventoryBoxScaleOffSet, redItemSelector.Height + itemInventoryBoxScaleOffSet), Color.White);

            drawSelectedItemToSmallBox(spriteBatch);




        }

        //depending on what the selector is hovering over, it will display on the small box
        private void drawSelectedItemToSmallBox(SpriteBatch spriteBatch)
        {
            IItem smallboxinventoryitem = null;
            USABLE_ITEM type = (USABLE_ITEM)itemLocations[currentItemIndex].Item2;
            Vector2 pos = new Vector2((int)smallitemboxPosition.X + itemInventoryBoxOffSet3, (int)smallitemboxPosition.Y + itemInventoryBoxOffSet3);
            switch (itemLocations[currentItemIndex].Item2)
            {
                case inventoryItems.bow:
                    smallboxinventoryitem = new Bow(((int)pos.X, (int)pos.Y));
                    type = USABLE_ITEM.bow;
                    break;
                case inventoryItems.boomerang:
                    smallboxinventoryitem = new BoomerangItem(((int)pos.X, (int)pos.Y));
                    type = USABLE_ITEM.boomerang;
                    break;
                case inventoryItems.bomb:
                    smallboxinventoryitem = new BombItem(((int)pos.X, (int)pos.Y));
                    type = USABLE_ITEM.bomb;
                    break;
                case inventoryItems.key:
                    smallboxinventoryitem = new Key(((int)pos.X, (int)pos.Y));
                    type = USABLE_ITEM.key;
                    break;
            }
            InventoryDisplay.setSelectedItem(type);
            //Issue here, this is not displaying the correct item in the small box inventory when an item gets used up
            //instead, it displays an item next to it
            //You can use Player.itemInventory[(int)InventoryDisplay.getSelectedItemTypeIndex()] > 0 to test if the selected item's count is greater than 1 in case that helps you solve the problem
            smallboxinventoryitem.Draw(spriteBatch, pos, 3);
        }

        //function that gets the number of items and which ones so Draw can have the correct sprite to create
        public (int, List<inventoryItems>) getTotalNumOfItems() 
        {
            int num = 0;
            List<inventoryItems> list = new List<inventoryItems>();
            if (Inventory.itemInventory[(int)ITEMS.Bow] > 0)
            {
                num++;
                list.Add(inventoryItems.bow);
            }
            if (Inventory.itemInventory[(int)ITEMS.Bomb] > 0)
            {
                num++;
                list.Add(inventoryItems.bomb);
            }
            if (Inventory.itemInventory[(int)ITEMS.Key] > 0)
            {
                num++;
                list.Add(inventoryItems.key);
            }
            if (Inventory.itemInventory[(int)ITEMS.Boomerang] > 0)
            {
                num++;
                list.Add(inventoryItems.boomerang);
            }

            return (num, list);
        }

        public void Update()
        {
            
        }

        //moves the selector, makes sure it loops back to the other side 
        //selector smoother is so it doesnt update crazy fast between the controller checks
        public void moveSelectorLeft()
        {
            if(selectorSmoother == 9)
            {
                if (currentItemIndex == 0)
                {
                    currentItemIndex = itemLocations.Count - 1;
                }
                currentItemIndex--;
                selectorSmoother = 0;
            }
            selectorSmoother++;
        }

        //moves the selector, makes sure it loops back to the other side 
        public void moveSelectorRight()
        {
            if(selectorSmoother == 9)
            {
                if (currentItemIndex == itemLocations.Count - 1)
                {
                    currentItemIndex = 0;
                }
                currentItemIndex++;
                selectorSmoother = 0;
            }
            selectorSmoother++;
        }
    }
    public enum inventoryItems { bomb = 1, boomerang = 0, key = 2, bow = 3 } //sword maps to bow for now for HUD
}
