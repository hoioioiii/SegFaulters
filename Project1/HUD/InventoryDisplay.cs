using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;
using static Project1.Constants;
using static Project1.Game1;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace Project1.HUD
{
	public class InventoryDisplay : IHUDEntity
    {
        private Texture2D countRect;
        private Texture2D itemRect;
        private Vector2 coordCount;
        private Vector2 coordItem;
        private int fullMenuOffset = 0;
        private bool reset = false;

        public InventoryDisplay(GraphicsDevice graphics)
		{
            countRect = new Texture2D(graphics, SCREEN_WIDTH_UPPER / 9, SCREEN_WIDTH_UPPER / 5);
            itemRect = new Texture2D(graphics, 2 * (SCREEN_WIDTH_UPPER / 9), SCREEN_WIDTH_UPPER / 5);
            coordCount = new Vector2(SCREEN_WIDTH_UPPER / 3, 0);
            coordItem = new Vector2(SCREEN_WIDTH_UPPER / 3, 0);

            //private SpriteFont font = Content.Load<SpriteFont>("File");
            //_spriteBatch.DrawString(font, "Credits \nMade By: Drishti Mittal \nSprites From: ", new Vector2(300, 400), Color.Black);
        }

        public void Update()
        {
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                coordCount.Y += fullMenuOffset;
                coordItem.Y += fullMenuOffset;
                reset = true;
            }
            else if (reset)
            {
                coordCount.Y -= fullMenuOffset;
                coordItem.Y -= fullMenuOffset;
                reset = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(countRect, coordCount, Color.White);
            spriteBatch.Draw(itemRect, coordItem, Color.Blue);
        }
    }
}

