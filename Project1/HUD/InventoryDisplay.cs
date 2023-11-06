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
        private float fullMenuOffset = (SCREEN_HEIGHT / 3) * 2;
        private int HUD_COUNT_OFFSET = HUD_HEIGHT / 4;
        private int ITEM_SPRITE_OFFSET = HUD_SECTION_WIDTH / 9;
        private float keyLableOffsetX;
        private float keyLableOffsetY;
        private bool reset = false;
        private static USABLE_ITEM userSelectedItem = USABLE_ITEM.boomerang;
        private static IItem[] selectedItemArray;
        private SpriteFont font;
        private int[] itemCount = {Player.itemInventory[(int)ITEMS.Rupee], Player.itemInventory[(int)ITEMS.Key] , Player.itemInventory[(int)ITEMS.Bomb]};

        public InventoryDisplay(GraphicsDevice graphics, ContentManager content)
		{

            itemRect = new Texture2D(graphics, 1, 1);
            itemRect.SetData(new[] { Color.Blue });

            innerItemRect = new Texture2D(graphics, 1, 1);
            innerItemRect.SetData(new[] { Color.Black });

            coordItem = new Vector2(HUD_SECTION_WIDTH + (HUD_SECTION_WIDTH / 3), HUD_HEIGHT / 3);
            itemDestination = new Rectangle((int)coordItem.X, (int)coordItem.Y, HUD_SECTION_WIDTH / 4, HUD_HEIGHT / 3);

            //tried to achieve this but infortunatly had to add lots of magic numbers to get it to work
            //float innerOffsetX = itemDestination.Width / 12;
            //float innerOffsetY = itemDestination.Height / 12;
            float innerOffsetX = HUD_SECTION_WIDTH / 48;
            float innerOffsetY = HUD_HEIGHT / 36;
            coordInnerItem = new Vector2(coordItem.X + innerOffsetX, coordItem.Y + innerOffsetY);

            //tried to achieve this but infortunatly had to add lots of magic numbers to get it to work
            //float innerWidth = itemDestination.Width * (5 / 6);
            //float innerHeight = itemDestination.Height * (5 / 6);
            float innerWidth = (HUD_SECTION_WIDTH / 4) - (HUD_SECTION_WIDTH / 24);
            float innerHeight = (HUD_HEIGHT / 3) - (HUD_HEIGHT / 18);

            itemInnerDestination = new Rectangle((int)coordInnerItem.X, (int)coordInnerItem.Y, (int)innerWidth, (int)innerHeight);

            //necessary for logic to push HUD to bottom of screen durinf pause screen
            coordCountBase = new Vector2(HUD_SECTION_WIDTH, HUD_COUNT_OFFSET);
            font = content.Load<SpriteFont>("HUDFont");
            //trying to call measureString only once since its an expensive operation
            keyLableOffsetX = font.MeasureString("B").X / 2;
            keyLableOffsetY = font.MeasureString("B").Y;

            //create the selected item array
            IItem[] tempSelectedItemArray = {new BoomerangItem(((int)coordCountBase.X, (int)coordCountBase.Y)), new BombItem(((int)coordCountBase.X, (int)coordCountBase.Y)), new Key(((int)coordCountBase.X, (int)coordCountBase.Y)), new SwordItem(((int)coordCountBase.X, (int)coordCountBase.Y))};
            selectedItemArray = tempSelectedItemArray;
        }

        public void Update()
        {
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                coordCountBase.Y += fullMenuOffset;
                coordItem.Y += fullMenuOffset;
                itemDestination.Y += (int)fullMenuOffset;
                itemInnerDestination.Y += (int)fullMenuOffset;
                reset = true;
            }
            else if (reset)
            {
                coordCountBase.Y -= fullMenuOffset;
                coordItem.Y -= fullMenuOffset;
                itemDestination.Y -= (int)fullMenuOffset;
                itemInnerDestination.Y -= (int)fullMenuOffset;
                reset = false;
            }

            //Update item counts
            itemCount[0] = Player.itemInventory[(int)ITEMS.Rupee];
            itemCount[1] = Player.itemInventory[(int)ITEMS.Key];
            itemCount[2] = Player.itemInventory[(int)ITEMS.Bomb];

        }

        public static void setSelectedItem(USABLE_ITEM type)
        {
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, key = 2, sword = 3};" enum from constants.cs for this
            userSelectedItem = type;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(countRect, coordCount, Color.White);
            IItem rupee = new Rupee(((int)coordCountBase.X, (int)coordCountBase.Y));
            IItem bomb = new BombItem(((int)coordCountBase.X, (int)coordCountBase.Y));

            float secondRectOffset = (HUD_SECTION_WIDTH / 3);

            Vector2 coordCount = coordCountBase;
            coordCount.X = coordCountBase.X + ITEM_SPRITE_OFFSET;

            for (int i = 0; i < 3; i++)
            {
                coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * i);
                spriteBatch.DrawString(font, "X" + itemCount[i], coordCount, Color.White);
            }
            coordCount = coordCountBase;
            rupee.Draw(spriteBatch, coordCount, 2);

            //key implementation depends on the initial coordinates passed to it
            //for some reason so I cant intantiate it at the top
            coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * 1);
            IItem key = new Key(((int)coordCount.X, (int)coordCount.Y));
            key.Draw(spriteBatch, coordCount, 2);

            coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * 2);
            bomb.Draw(spriteBatch, coordCount, 2);
            //spriteBatch.DrawString(font, "-Inventory-", coordCount, Color.White);

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
            Vector2 coordKeyLabel = new Vector2(itemDestination.X + (itemDestination.Width / 2) - keyLableOffsetX, itemDestination.Y - 5);
            spriteBatch.DrawString(font, "B", coordKeyLabel, Color.White);
            Vector2 coordKeyLabel2 = coordKeyLabel;
            coordKeyLabel2.X += secondRectOffset;
            spriteBatch.DrawString(font, "A", coordKeyLabel2, Color.White);

            //Add default sword into item A box
            IItem sword = new SwordItem(((int)coordCountBase.X, (int)coordCountBase.Y));
            Vector2 swordSprite = coordKeyLabel2;
            swordSprite.Y += keyLableOffsetY;
            sword.Draw(spriteBatch, swordSprite, 2);

            //Add selected item to item B box
            //Using the "public enum USABLE_ITEM { boomerang = 0, bomb = 1, key = 2, sword = 3};" enum from constants.cs for this
            Vector2 selectedSprite = coordKeyLabel;
            selectedSprite.Y += keyLableOffsetY;
            selectedSprite.X -= (itemDestination.Width / 2);
            selectedSprite.X += 3 * keyLableOffsetX;

            //key was implemented weirdly so we have to pass location now rather than ealier
            selectedItemArray[(int)USABLE_ITEM.key] = new Key(((int)selectedSprite.X, (int)selectedSprite.Y));

            //display the selected item
            IItem selectedItem = selectedItemArray[(int)userSelectedItem];
            selectedItem.Draw(spriteBatch, selectedSprite, 2);
        }
    }
}

