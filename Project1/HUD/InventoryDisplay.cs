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
        private Texture2D countRect;
        private Texture2D itemRect;
        private Texture2D innerItemRect;
        private Vector2 coordCountBase;
        private Vector2 coordCount;
        private Vector2 coordItem;
        private Rectangle itemDestination;
        private int fullMenuOffset = 0;
        private int HUD_COUNT_OFFSET = HUD_HEIGHT / 4;
        private int ITEM_SPRITE_OFFSET = HUD_SECTION_WIDTH / 9;
        private bool reset = false;
        private SpriteFont font;
        private int[] itemCount = {Player.itemInventory[(int)ITEMS.Rupee], Player.itemInventory[(int)ITEMS.Key] , Player.itemInventory[(int)ITEMS.Bomb]};

        public InventoryDisplay(GraphicsDevice graphics, ContentManager content)
		{
            countRect = new Texture2D(graphics, SCREEN_WIDTH / 9, SCREEN_WIDTH / 5);
            itemRect = new Texture2D(graphics, 1, 1);
            itemRect.SetData(new[] { Color.Blue });

            innerItemRect = new Texture2D(graphics, 1, 1);
            innerItemRect.SetData(new[] { Color.Black });

            coordItem = new Vector2(HUD_SECTION_WIDTH + (HUD_SECTION_WIDTH / 3), HUD_HEIGHT / 3);
            itemDestination = new Rectangle((int)coordItem.X, (int)coordItem.Y, HUD_SECTION_WIDTH / 4, HUD_HEIGHT / 3);

            coordCountBase = new Vector2(HUD_SECTION_WIDTH, HUD_COUNT_OFFSET);
            coordCount = coordCountBase;
            font = content.Load<SpriteFont>("HUDFont");

            //private SpriteFont font = Content.Load<SpriteFont>("File");
            //_spriteBatch.DrawString(font, "Credits \nMade By: Drishti Mittal \nSprites From: ", new Vector2(300, 400), Color.Black);
        }

        public void Update()
        {
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                coordCountBase.Y += fullMenuOffset;
                coordItem.Y += fullMenuOffset;
                reset = true;
            }
            else if (reset)
            {
                coordCountBase.Y -= fullMenuOffset;
                coordItem.Y -= fullMenuOffset;
                reset = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(countRect, coordCount, Color.White);
            IItem rupee = new Rupee(((int)coordCountBase.X, (int)coordCountBase.Y));
            IItem bomb = new BombItem(((int)coordCountBase.X, (int)coordCountBase.Y));
            IItem key = new Key(((int)coordCountBase.X, (int)coordCountBase.Y));
            coordCount.X = coordCountBase.X + ITEM_SPRITE_OFFSET;
            for (int i = 0; i < 3; i++)
            {
                coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * i);
                spriteBatch.DrawString(font, "X" + itemCount[i], coordCount, Color.White);
            }
            coordCount = coordCountBase;
            rupee.Draw(spriteBatch, coordCount, 2);

            //key won't draw right
            coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * 1);
            key.Draw(spriteBatch, coordCount, 2);

            coordCount.Y = coordCountBase.Y + ((HUD_HEIGHT / 3) * 2);
            bomb.Draw(spriteBatch, coordCount, 2);
            //spriteBatch.DrawString(font, "-Inventory-", coordCount, Color.White);
            //boxes to hold inventory
            spriteBatch.Draw(itemRect, itemDestination, Color.Blue);
            spriteBatch.Draw(itemRect, new Rectangle((int)coordItem.X + (HUD_SECTION_WIDTH / 3), (int)coordItem.Y, HUD_SECTION_WIDTH / 4, HUD_HEIGHT / 3), Color.Blue);
        }
    }
}

