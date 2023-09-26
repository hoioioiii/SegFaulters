using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1
{
	public class HeartContainer : IItem
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int screenWidth;
        private int screenHeight;

        public HeartContainer(Game1 game1)
		{
            Texture = Game1.spriteStorage[3];
            Rows = 1;
            Columns = 1;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            screenWidth = 800;
            screenHeight = 480;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
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

