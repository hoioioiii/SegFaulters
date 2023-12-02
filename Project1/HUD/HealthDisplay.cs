using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;
using static Project1.Constants;
using static Project1.Game1;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Microsoft.Xna.Framework.Content;
using Project1.Health;
using static Project1.Health.HealthSystemManager;

namespace Project1.HUD
{
	public class HealthDisplay : IHUDEntity
    {
        private Vector2 coordTitle;
        private SpriteFont font;
        private int titleOffset;
        public static IHealthSystem linkHealth;

        public HealthDisplay(GraphicsDevice graphics, ContentManager content)
		{


            font = content.Load<SpriteFont>("HUDFont");
    
            titleOffset = (HUD_SECTION_WIDTH - (int)font.MeasureString("-LIFE-").X) / 2;

            coordTitle = new Vector2((2 * HUD_SECTION_WIDTH) + titleOffset, 0);

            linkHealth = new HealthSystem(LINK_HEARTS); //start link with 3 hearts
        }

        public void Update()
        {
            //no op
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "-LIFE-", coordTitle, Color.Red);
            linkHealth.Draw(spriteBatch);
        }
    }
}

