using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class LevelLoader
    {
        private static Texture2D levelBackground;
        static double ratio;
        public static void LoadContent(ContentManager content)
        {
            ratio = 2.272;
            levelBackground = content.Load<Texture2D>("LevelBackground");
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelBackground, new Rectangle(0, 0, 800, 480), Color.White);
        }

    }
}
