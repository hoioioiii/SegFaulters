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
	public class LocationDisplay : IHUDEntity
    {
        private Texture2D titleRect;
        private Texture2D mapRect;
        private Vector2 coordTitle;
        private Vector2 coordMap;
        private int fullMenuOffset = 0;
        private bool reset = false;
        private SpriteFont font;
        private int titleOffset;

        public LocationDisplay(GraphicsDevice graphics, ContentManager content)
		{
            font = content.Load<SpriteFont>("HUDFont");
            titleRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT / 3);
            mapRect = new Texture2D(graphics, 1, 1);
            mapRect.SetData(new[] { Color.Blue});
            titleOffset = (HUD_SECTION_WIDTH - (int)font.MeasureString("-Location-").X) / 2;
            coordTitle = new Vector2(titleOffset, 0);
            coordMap = new Vector2(0, titleRect.Height);
            

            //private SpriteFont font = Content.Load<SpriteFont>("File");
            //_spriteBatch.DrawString(font, "Credits \nMade By: Drishti Mittal \nSprites From: ", new Vector2(300, 400), Color.Black);
        }

        public void Update()
        {
            if(HeadsUpDisplay.IsFullMenuDisplay())
            {
                coordTitle.Y += fullMenuOffset;
                coordMap.Y += fullMenuOffset;
                reset = true;
            } else if(reset)
            {
                coordTitle.Y -= fullMenuOffset;
                coordMap.Y -= fullMenuOffset;
                reset = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(titleRect, coordTitle, Color.White);
            spriteBatch.DrawString(font, "-Location-", coordTitle, Color.White);
            spriteBatch.Draw(mapRect, new Rectangle((int)coordMap.X, (int)coordMap.Y, HUD_SECTION_WIDTH, HUD_HEIGHT - titleRect.Height), Color.Blue);
        }
    }
}

