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

namespace Project1.HUD
{
    public class InventoryDisplay : IHUDEntity
    {
        private Texture2D itemRect;
        private Texture2D innerItemRect;
        private Vector2[] coordsCountBase;
        private Vector2 coordItem;
        private Vector2 coordInnerItem;
        private Rectangle[] itemDestinations;
        private Rectangle[] itemInnerDestinations;
        private float fullMenuOffset = (SCREEN_HEIGHT / 3) * 2;
        private int HUD_COUNT_OFFSET = HUD_HEIGHT / 4;
        private int ITEM_SPRITE_OFFSET = HUD_SECTION_WIDTH / 9;
        private static int INNER_OFFSET_SLICE_X = 48;
        private static int INNER_OFFSET_SLICE_Y = 36;
        private static int INNER_WIDTH_SLICE = 24;
        private static int INNER_HEIGHT_SLICE = 18;
        private float keyLableOffsetX;
        private float keyLableOffsetY;
        private bool reset = false;
        private static USABLE_ITEM userSelectedItem = USABLE_ITEM.boomerang;
        //private static int[] usableItemCount = { Player.itemInventory[(int)ITEMS.Boomerang], Player.itemInventory[(int)ITEMS.Bomb], Player.itemInventory[(int)ITEMS.Key], Player.itemInventory[(int)ITEMS.Bow]};
        private static IItem[] selectedItemArray;
        private enum PAUSE_STATE { active = 0, paused = 1 };
        private static PAUSE_STATE pauseIndex = PAUSE_STATE.active;
        private SpriteFont font;
        public static IItem selectedItem;
        private int[] itemCount = { Inventory.itemInventory[(int)ITEMS.Rupee], Inventory.itemInventory[(int)ITEMS.Key], Inventory.itemInventory[(int)ITEMS.Bomb] };

        public InventoryDisplay(GraphicsDevice graphics, ContentManager content)
        {

            itemRect = new Texture2D(graphics, 1, 1);
            itemRect.SetData(new[] { Color.Blue });

            innerItemRect = new Texture2D(graphics, 1, 1);
            innerItemRect.SetData(new[] { Color.Black });

            font = content.Load<SpriteFont>("HUDFont");

            coordItem = new Vector2(HUD_SECTION_WIDTH + (HUD_SECTION_WIDTH / 3), HUD_HEIGHT / 3);


            //for outer box of inventory
            //index 0 is not paused and 1 is paused
            Rectangle[] tempRectArr = { new Rectangle((int)coordItem.X, (int)coordItem.Y, HUD_SECTION_WIDTH / 4, HUD_HEIGHT / 3), new Rectangle((int)coordItem.X, (int)(coordItem.Y + fullMenuOffset), HUD_SECTION_WIDTH / 4, HUD_HEIGHT / 3) };
            itemDestinations = tempRectArr;

            /*
            tried to achieve this but infortunatly had to add lots of magic numbers to get it to work
            float innerOffsetX = itemDestination.Width / 12;
            float innerOffsetY = itemDestination.Height / 12;
            */
            float innerOffsetX = HUD_SECTION_WIDTH / INNER_OFFSET_SLICE_X;
            float innerOffsetY = HUD_HEIGHT / INNER_OFFSET_SLICE_Y;
            coordInnerItem = new Vector2(coordItem.X + innerOffsetX, coordItem.Y + innerOffsetY);

            /*
            tried to achieve this but infortunatly had to add lots of magic numbers to get it to work
            float innerWidth = itemDestination.Width * (5 / 6);
            float innerHeight = itemDestination.Height * (5 / 6);
            */
            float innerWidth = (HUD_SECTION_WIDTH / 4) - (HUD_SECTION_WIDTH / INNER_WIDTH_SLICE);
            float innerHeight = (HUD_HEIGHT / 3) - (HUD_HEIGHT / INNER_HEIGHT_SLICE);

            //for inner rectangle of inventory
            //index 0 is not paused and 1 is paused
            Rectangle[] tempRectArr2 = { new Rectangle((int)coordInnerItem.X, (int)coordInnerItem.Y, (int)innerWidth, (int)innerHeight), new Rectangle((int)coordInnerItem.X, (int)(coordInnerItem.Y + fullMenuOffset), (int)innerWidth, (int)innerHeight) };
            itemInnerDestinations = tempRectArr2;

            //for base of all things in the inventory section
            //index 0 is not paused and 1 is paused
            Vector2[] tempVectorArr = { new Vector2(HUD_SECTION_WIDTH, HUD_COUNT_OFFSET), new Vector2(HUD_SECTION_WIDTH, HUD_COUNT_OFFSET + fullMenuOffset) };
            coordsCountBase = tempVectorArr;

            //trying to call measureString only once since its an expensive operation
            keyLableOffsetX = font.MeasureString("B").X / 2;
            keyLableOffsetY = font.MeasureString("B").Y;

            //create the selected item array
            IItem[] tempSelectedItemArray = { new BoomerangItem(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y)), new BombItem(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y)), new Key(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y)), new Bow(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y)) };
            selectedItemArray = tempSelectedItemArray;
        }

        public void Update()
        {
            /*
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                pauseIndex = PAUSE_STATE.paused;
                reset = true;
            }
            else if (reset)
            {
                pauseIndex = PAUSE_STATE.active;
                reset = false;
            }
            */

            //Update item counts
            itemCount[0] = Inventory.itemInventory[(int)ITEMS.Rupee];
            itemCount[1] = Inventory.itemInventory[(int)ITEMS.Key];
            itemCount[2] = Inventory.itemInventory[(int)ITEMS.Bomb];

            /*
            //Update usable item counts
            usableItemCount[(int)USABLE_ITEM.boomerang] = Player.itemInventory[(int)ITEMS.Boomerang];
            usableItemCount[(int)USABLE_ITEM.bomb] = Player.itemInventory[(int)ITEMS.Bomb];
            usableItemCount[(int)USABLE_ITEM.key] = Player.itemInventory[(int)ITEMS.Key];
            usableItemCount[(int)USABLE_ITEM.bow] = Player.itemInventory[(int)ITEMS.Bow];
            */

        }

        public static void setSelectedItem(USABLE_ITEM type)
        {
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, key = 2, bow = 3};" enum from constants.cs for this
            userSelectedItem = type;
            selectedItem = selectedItemArray[(int)userSelectedItem];
        }

        public static USABLE_ITEM getSelectedItem()
        {
            return userSelectedItem;
        }

        public static ITEMS getSelectedItemTypeIndex()
        {
            return selectedItem.GetTypeIndex();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(countRect, coordCount, Color.White);
            IItem rupee = new Rupee(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y));
            IItem bomb = new BombItem(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y));

            float secondRectOffset = (HUD_SECTION_WIDTH / 3);

            //NEED to make coordCountBase array as well
            Vector2 coordCount = coordsCountBase[(int)pauseIndex];
            coordCount.X = coordsCountBase[(int)pauseIndex].X + ITEM_SPRITE_OFFSET;

            for (int i = 0; i < 3; i++)
            {
                coordCount.Y = coordsCountBase[(int)pauseIndex].Y + ((HUD_HEIGHT / 3) * i);
                spriteBatch.DrawString(font, "X" + itemCount[i], coordCount, Color.White);
            }
            coordCount = coordsCountBase[(int)pauseIndex];
            rupee.Draw(spriteBatch, coordCount, 2);

            //key implementation depends on the initial coordinates passed to it
            //for some reason so I cant intantiate it at the top
            coordCount.Y = coordsCountBase[(int)pauseIndex].Y + ((HUD_HEIGHT / 3) * 1);
            IItem key = new Key(((int)coordCount.X, (int)coordCount.Y));
            key.Draw(spriteBatch, coordCount, 2);

            coordCount.Y = coordsCountBase[(int)pauseIndex].Y + ((HUD_HEIGHT / 3) * 2);
            bomb.Draw(spriteBatch, coordCount, 2);
            //spriteBatch.DrawString(font, "-Inventory-", coordCount, Color.White);

            //boxes to hold inventory
            spriteBatch.Draw(itemRect, itemDestinations[(int)pauseIndex], Color.Blue);
            Rectangle itemDestination2 = itemDestinations[(int)pauseIndex];
            itemDestination2.X += (int)secondRectOffset;
            spriteBatch.Draw(itemRect, itemDestination2, Color.Blue);


            //boxes for inner inventory
            spriteBatch.Draw(innerItemRect, itemInnerDestinations[(int)pauseIndex], Color.Black);
            Rectangle itemInnerDestination2 = itemInnerDestinations[(int)pauseIndex];
            itemInnerDestination2.X += (int)secondRectOffset;
            spriteBatch.Draw(innerItemRect, itemInnerDestination2, Color.Black);


            //Add control labels to inventory boxes
            Vector2 coordKeyLabel = new Vector2(itemDestinations[(int)pauseIndex].X + (itemDestinations[(int)pauseIndex].Width / 2) - keyLableOffsetX, itemDestinations[(int)pauseIndex].Y - 5);
            spriteBatch.DrawString(font, "B", coordKeyLabel, Color.White);
            Vector2 coordKeyLabel2 = coordKeyLabel;
            coordKeyLabel2.X += secondRectOffset;
            spriteBatch.DrawString(font, "Z", coordKeyLabel2, Color.White);

            //Add default sword into item A box
            IItem sword = new SwordItem(((int)coordsCountBase[(int)pauseIndex].X, (int)coordsCountBase[(int)pauseIndex].Y));
            Vector2 swordSprite = coordKeyLabel2;
            swordSprite.Y += keyLableOffsetY;
            sword.Draw(spriteBatch, swordSprite, 2);

            //Add selected item to item B box
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, key = 2, bow = 3};" enum from constants.cs for this
            Vector2 selectedSprite = coordKeyLabel;
            selectedSprite.Y += keyLableOffsetY;
            selectedSprite.X -= (itemDestinations[(int)pauseIndex].Width / 2);
            selectedSprite.X += 3 * keyLableOffsetX;

            //key was implemented weirdly so we have to pass location now rather than ealier
            selectedItemArray[(int)USABLE_ITEM.key] = new Key(((int)selectedSprite.X, (int)selectedSprite.Y));

            //display the selected item
            selectedItem = selectedItemArray[(int)userSelectedItem];

            if (Inventory.itemInventory[(int)selectedItem.GetTypeIndex()] != 0) {
                selectedItem.Draw(spriteBatch, selectedSprite, 2);
            }
        }
    }
}

