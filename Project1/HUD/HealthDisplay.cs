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
        private Texture2D titleRect;
       // private Texture2D healthRect;
        private Vector2[] coordsTitle;
        //private Vector2[] coordsHealth;
        private float fullMenuOffset = (SCREEN_HEIGHT / 3) * 2;
        private bool reset = false;
        private SpriteFont font;
        private enum PAUSE_STATE { active = 0, paused = 1 };
        private static PAUSE_STATE pauseIndex = PAUSE_STATE.active;
        private int titleOffset;

        //health TO BE MODIFIED ONCE PLAYER DONE
        public static IHealthSystem linkHealth;

        public HealthDisplay(GraphicsDevice graphics, ContentManager content)
		{


            font = content.Load<SpriteFont>("HUDFont");
            titleRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT / 3);
            //healthRect = new Texture2D(graphics, HUD_SECTION_WIDTH, HUD_HEIGHT - titleRect.Height);
            titleOffset = (HUD_SECTION_WIDTH - (int)font.MeasureString("-LIFE-").X) / 2;

            //index 0 is not paused and 1 is paused
            Vector2[] tempVectorArr = { new Vector2((2 * HUD_SECTION_WIDTH) + titleOffset, 0), new Vector2((2 * HUD_SECTION_WIDTH) + titleOffset, fullMenuOffset) };
            coordsTitle = tempVectorArr;

            //index 0 is not paused and 1 is paused
            //Vector2[] tempVectorArr2 = { new Vector2(2 * HUD_SECTION_WIDTH, titleRect.Height), new Vector2(2 * HUD_SECTION_WIDTH, titleRect.Height + fullMenuOffset) };
            //coordsHealth = tempVectorArr2;

            linkHealth = new HealthSystem(LINK_HEARTS); //start link with 3 hearts
        }

        public void Update()
        {
            
            // If paused
            /*
            if (HeadsUpDisplay.IsFullMenuDisplay())
            {
                pauseIndex = PAUSE_STATE.paused;
                //UP TO MODIFICATION
                linkHealth.Paused();
                reset = true;
            }
            else if (reset)
            {
                pauseIndex = PAUSE_STATE.active;
                //UP TO MODIFICATION
                linkHealth.Reset();
                reset = false;
            }
            */

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "-LIFE-", coordsTitle[(int)pauseIndex], Color.Red);
           // spriteBatch.Draw(healthRect, coordsHealth[(int)pauseIndex], Color.Blue);
            linkHealth.Draw(spriteBatch);
        }
    }
}

