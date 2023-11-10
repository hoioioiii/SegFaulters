using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using static Project1.Constants;

namespace Project1
{
    public class GameOverScreens
    {


        public static void DrawGameOverScreen(SpriteBatch spriteBatch,SpriteFont font)
        {

            spriteBatch.DrawString(font, "Game Over",CENTER, Color.White);

            MediaPlayer.Pause();      
        }
      

        public static void DrawOptionsScreen(SpriteBatch spriteBatch, SpriteFont font)
        {
            

            Game1.selectionManager.DrawHeartSelector(spriteBatch);
            spriteBatch.DrawString(font, "RETRY", RETRY_POSITION, Color.White);
            spriteBatch.DrawString(font, "QUIT", QUIT_POSITION, Color.White);
        }


    }
}
