using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;
using static Project1.Constants;
using static Project1.Game1;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Microsoft.Xna.Framework.Content;

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
        private SpriteFont font;
        private int titleOffset;

        public HealthDisplay(GraphicsDevice graphics, ContentManager content)
		{
            font = content.Load<SpriteFont>("HUDFont");
            titleRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT / 3);
            healthRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT - titleRect.Height);
            titleOffset = (HUD_SECTION_WIDTH - (int)font.MeasureString("-LIFE-").X) / 2;
            coordTitle = new Vector2((2 * HUD_SECTION_WIDTH) + titleOffset, 0);
            coordHealth = new Vector2(2 * HUD_SECTION_WIDTH, titleRect.Height);
            

            //in Game1 constructor, graphic devicmanager.buffer
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
            //spriteBatch.Draw(titleRect, coordTitle, Color.White);
            //titleWidth = (int)font.MeasureString("-LIFE-").X;
            spriteBatch.DrawString(font, "-LIFE-", coordTitle, Color.Red);
            spriteBatch.Draw(healthRect, coordHealth, Color.Blue);
        }
    }
}

