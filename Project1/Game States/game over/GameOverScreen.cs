using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static Project1.Constants;

namespace Project1
{
    public class GameOverScreen
    {
        private SpriteFont font;

        public GameOverScreen(GraphicsDevice graphics, ContentManager content)
        {
            font = content.Load<SpriteFont>("ZeldaFont");
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (Game1.timer <= 0)
            {
                Game1.selectionManager.DrawHeartSelector(spritebatch);
                spritebatch.DrawString(font, "RETRY", RETRY_POSITION, Color.White);
                spritebatch.DrawString(font, "QUIT", QUIT_POSITION, Color.White);
            }
            else
            {
                spritebatch.DrawString(font, "Game Over", CENTER, Color.White);
            }


        }
        public static void GameOverSoundEffecct()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Play(gameOverStateSound);
        }

        public void Update()
        {
            Game1.timer--;
        }
    }
}
