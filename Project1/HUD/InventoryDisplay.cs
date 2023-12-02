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
        private Vector2 coordCountBase;
        private Vector2 coordItem;
        private Vector2 coordInnerItem;
        private Rectangle itemDestination;
        private Rectangle itemInnerDestination;
        private float keyLableOffsetX;
        private float keyLableOffsetY;
        private static USABLE_ITEM userSelectedItem = USABLE_ITEM.bow;
        private static IItem[] selectedItemArray;
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

            coordItem = new Vector2(HUD_SECTION_WIDTH + HUD_SECTION_THIRD, HUD_HEIGHT_THIRD);


            //for outer box of inventory
            itemDestination = new Rectangle((int)coordItem.X, (int)coordItem.Y, HUD_SECTION_FOURTH, HUD_HEIGHT_THIRD);

            float innerOffsetX = HUD_SECTION_WIDTH / INNER_OFFSET_SLICE_X;
            float innerOffsetY = HUD_HEIGHT / INNER_OFFSET_SLICE_Y;
            coordInnerItem = new Vector2(coordItem.X + innerOffsetX, coordItem.Y + innerOffsetY);

            float innerWidth = HUD_SECTION_FOURTH - (HUD_SECTION_WIDTH / INNER_WIDTH_SLICE);
            float innerHeight = HUD_HEIGHT_THIRD - (HUD_HEIGHT / INNER_HEIGHT_SLICE);

            //for inner rectangle of inventory
            itemInnerDestination = new Rectangle((int)coordInnerItem.X, (int)coordInnerItem.Y, (int)innerWidth, (int)innerHeight);

            //for base of all things in the inventory section
            coordCountBase = new Vector2(HUD_SECTION_WIDTH, HUD_COUNT_OFFSET);

            //trying to call measureString only once since its an expensive operation
            keyLableOffsetX = font.MeasureString("B").X / 2;
            keyLableOffsetY = font.MeasureString("B").Y;

            //create the selected item array
            IItem[] tempSelectedItemArray = { new BoomerangItem(((int)coordCountBase.X, (int)coordCountBase.Y)), new BombItem(((int)coordCountBase.X, (int)coordCountBase.Y)), new BeehiveItem(((int)coordCountBase.X, (int)coordCountBase.Y)), new Bow(((int)coordCountBase.X, (int)coordCountBase.Y)) };
            selectedItemArray = tempSelectedItemArray;
        }

        public void Update()
        {

            //Update item counts
            itemCount[0] = Inventory.itemInventory[(int)ITEMS.Rupee];
            itemCount[1] = Inventory.itemInventory[(int)ITEMS.Key];
            itemCount[2] = Inventory.itemInventory[(int)ITEMS.Bomb];

        }

        public static void setSelectedItem(USABLE_ITEM type)
        {
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, beehive = 2, bow = 3};" enum from constants.cs for this
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
            IItem rupee = new Rupee(((int)coordCountBase.X, (int)coordCountBase.Y));
            IItem bomb = new BombItem(((int)coordCountBase.X, (int)coordCountBase.Y));

            float secondRectOffset = HUD_SECTION_THIRD;

            //Display counts of bomb, keys, and rupees
            Vector2 coordCount = coordCountBase;
            coordCount.X = coordCountBase.X + ITEM_SPRITE_OFFSET;

            for (int i = 0; i < 3; i++)
            {
                coordCount.Y = coordCountBase.Y + (HUD_HEIGHT_THIRD * i);
                spriteBatch.DrawString(font, "X" + itemCount[i], coordCount, Color.White);
            }
            coordCount = coordCountBase;
            rupee.Draw(spriteBatch, coordCount, SPRITE_SIZE);

            //key implementation depends on the initial coordinates passed to it
            //for some reason so I cant intantiate it at the top
            coordCount.Y = coordCountBase.Y + (HUD_HEIGHT_THIRD * 1);
            IItem key = new Key(((int)coordCount.X, (int)coordCount.Y));
            key.Draw(spriteBatch, coordCount, SPRITE_SIZE);

            coordCount.Y = coordCountBase.Y + (HUD_HEIGHT_THIRD * 2);
            bomb.Draw(spriteBatch, coordCount, SPRITE_SIZE);

            //boxes to hold inventory
            spriteBatch.Draw(itemRect, itemDestination, Color.Blue);
            Rectangle itemDestination2 = itemDestination;
            itemDestination2.X += (int)secondRectOffset;
            spriteBatch.Draw(itemRect, itemDestination2, Color.Blue);


            //boxes for inner inventory
            spriteBatch.Draw(innerItemRect, itemInnerDestination, Color.Black);
            Rectangle itemInnerDestination2 = itemInnerDestination;
            itemInnerDestination2.X += (int)secondRectOffset;
            spriteBatch.Draw(innerItemRect, itemInnerDestination2, Color.Black);


            //Add control labels to inventory boxes
            Vector2 coordKeyLabel = new Vector2(itemDestination.X + (itemDestination.Width / 2) - keyLableOffsetX, itemDestination.Y - KEY_OFFSET);
            spriteBatch.DrawString(font, "B", coordKeyLabel, Color.White);
            Vector2 coordKeyLabel2 = coordKeyLabel;
            coordKeyLabel2.X += secondRectOffset;
            spriteBatch.DrawString(font, "Z", coordKeyLabel2, Color.White);

            //Add default sword into item A box
            IItem sword = new SwordItem(((int)coordCountBase.X, (int)coordCountBase.Y));
            Vector2 swordSprite = coordKeyLabel2;
            swordSprite.Y += keyLableOffsetY;
            sword.Draw(spriteBatch, swordSprite, SPRITE_SIZE);

            //Add selected item to item B box
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, beehive = 2, bow = 3};" enum from constants.cs for this
            Vector2 selectedSprite = coordKeyLabel;
            selectedSprite.Y += keyLableOffsetY;
            selectedSprite.X -= (itemDestination.Width / 2);
            selectedSprite.X += 3 * keyLableOffsetX;

            //key was implemented weirdly so we have to pass location now rather than ealier
            //selectedItemArray[(int)USABLE_ITEM.beehive] = new Key(((int)selectedSprite.X, (int)selectedSprite.Y));

            //display the selected item
            selectedItem = selectedItemArray[(int)userSelectedItem];

            if (Inventory.itemInventory[(int)selectedItem.GetTypeIndex()] != 0) {
                selectedItem.Draw(spriteBatch, selectedSprite, SPRITE_SIZE);
            }
        }
    }
}

