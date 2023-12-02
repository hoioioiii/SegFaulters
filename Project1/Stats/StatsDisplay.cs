using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Color = Microsoft.Xna.Framework.Color;
using static Project1.Constants;
using static Project1.Game1;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
	public class StatsDisplay : IStatsScreen
    {
        private Texture2D backgroundRect;
        private SpriteFont font;
        private Vector2 coordBase;
        private Rectangle destinationBackground;
        private float titleHeight;
        public static bool displayStats = false;
        public StatsDisplay(GraphicsDevice graphics, ContentManager content)
		{
            backgroundRect = new Texture2D(graphics, 1, 1);
            backgroundRect.SetData(new[] { Color.Black });

            font = content.Load<SpriteFont>("HUDFont");

            coordBase = new Vector2(0, HUD_HEIGHT);

            destinationBackground = new Rectangle((int)coordBase.X, (int)coordBase.Y, STATS_WIDTH, STATS_HEIGHT);

            titleHeight = font.MeasureString("Player Stats").Y;

        }

        public void Draw(SpriteBatch spriteBatch)
		{
            if (displayStats)
            {
                spriteBatch.Draw(backgroundRect, destinationBackground, Color.Black);
                spriteBatch.DrawString(font, "Player Stats", coordBase, Color.White);
                Vector2 coordStat = new Vector2(coordBase.X + (STATS_WIDTH / STATS_WIDTH_OFFSET1), coordBase.Y + titleHeight);
                foreach (KeyValuePair<String, int> Stat in Player.stats)
                {
                    spriteBatch.DrawString(font, Stat.Key, coordStat, Color.White);

                    Vector2 coordStatVal = coordStat;
                    coordStatVal.X = STATS_WIDTH_MULTIPLIER * (STATS_WIDTH / STATS_WIDTH_OFFSET2);
                    spriteBatch.DrawString(font, "" + Stat.Value, coordStatVal, Color.White);

                    coordStat.Y += (STATS_HEIGHT - titleHeight) / STATS_TOTAL;
                }
            }
        }

        public void Update()
		{

		}

    }
}

