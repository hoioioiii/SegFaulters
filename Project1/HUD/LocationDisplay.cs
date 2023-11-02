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
	public class LocationDisplay : IHUDEntity
    {
        private Texture2D titleRect;
        private Texture2D mapRect;
        private Vector2 coordTitle;
        private Vector2 coordMap;
        private int fullMenuOffset = 0;
        private bool reset = false;

        public LocationDisplay()
		{
            titleRect = new Texture2D(Game.GraphicsDevice, SCREEN_WIDTH_UPPER / 3, SCREEN_WIDTH_UPPER / 10);
            mapRect = new Texture2D(Game.GraphicsDevice, SCREEN_WIDTH_UPPER / 3, SCREEN_WIDTH_UPPER / 7);
            coordTitle = new Vector2(0, 0);
            coordMap = new Vector2(0, titleRect.Height);
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
            spriteBatch.Draw(titleRect, coordTitle, Color.White);
            spriteBatch.Draw(mapRect, coordMap, Color.Blue);
        }
    }
}

