using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1
{
	public class Rupee : IItem
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Texture2D[] sprites;
        private int screenWidth;
        private int screenHeight;
        public Rupee(Game1 game1)
		{
            sprites[0] = Game1.spriteStorage[10];
            sprites[1] = Game1.spriteStorage[11];
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            screenWidth = 800;
            screenHeight = 480;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture = sprites[currentFrame];
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);

            Rectangle destinationRectangle = new Rectangle(screenWidth / 2 - (width / 2), screenHeight / 2 - (height / 2), width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

