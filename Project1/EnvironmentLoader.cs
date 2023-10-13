using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project1
{
    public class EnvironmentLoader
    {
        private static Texture2D levelBackground;
        private static Dictionary<(int, int), int> blockPositionDictionary;
        private static IEnvironment block;
        private static Texture2D blockTexture;

        public static void LoadContent(ContentManager content)
        {
            //load in background content
            levelBackground = content.Load<Texture2D>("LevelBackground");

            //load in blockPositionDictionary
            block = new CurrentBlock(EnvironmentIterator.getCurrEnemy(), 114, 75);
        }

        public static void Update()
        {
            block.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(levelBackground, new Rectangle(17, -22, levelBackground.Width * 3, levelBackground.Height * 3), Color.White);

            block.Draw(spriteBatch);
        }

    }
}
