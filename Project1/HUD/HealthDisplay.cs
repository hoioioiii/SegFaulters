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
	public class HealthDisplay : IHUDEntity
    {
        private Texture2D titleRect;
        private Texture2D healthRect;
        private Vector2 coordTitle;
        private Vector2 coordHealth;
        private int fullMenuOffset = 0;
        private bool reset = false;

        public HealthDisplay(GraphicsDevice graphics)
		{
            titleRect = new Texture2D(graphics, SCREEN_WIDTH_UPPER / 3, SCREEN_WIDTH_UPPER / 10);
            healthRect = new Texture2D(graphics, SCREEN_WIDTH_UPPER / 3, SCREEN_WIDTH_UPPER / 7);
            coordTitle = new Vector2(2 * (SCREEN_WIDTH_UPPER / 3), 0);
            coordHealth = new Vector2(2 * (SCREEN_WIDTH_UPPER / 3), titleRect.Height);

            //private SpriteFont font = Content.Load<SpriteFont>("File");
            //_spriteBatch.DrawString(font, "Credits \nMade By: Drishti Mittal \nSprites From: ", new Vector2(300, 400), Color.Black);
        }

        public void Update()
        {
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                coordTitle.Y += fullMenuOffset;
                coordHealth.Y += fullMenuOffset;
                reset = true;
            }
            else if (reset)
            {
                coordTitle.Y -= fullMenuOffset;
                coordHealth.Y -= fullMenuOffset;
                reset = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titleRect, coordTitle, Color.White);
            spriteBatch.Draw(healthRect, coordHealth, Color.Blue);
        }
    }
}

