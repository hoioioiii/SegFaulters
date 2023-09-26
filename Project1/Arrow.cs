using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;

namespace Project1
{
	public class Arrow : IItem
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        //private int XCoordinate;
        private int screenWidth;
        private int screenHeight;
        public Arrow(Game1 game1)
		{
            Texture = Game1.spriteStorage[12];
            Rows = 1;
            Columns = 4;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            //XEnd = (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - (Texture.Width / Columns);
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
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
            //rectangle within the texture (the source) that we want to draw
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            //where texture will be drawn
            //Rectangle destinationRectangle = new Rectangle(XCoordinate, (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2, width, height);
            //Rectangle destinationRectangle = new Rectangle(XCoordinate, screenHeight / 2 - (height / 2), width, height);
            Rectangle destinationRectangle = new Rectangle(screenWidth / 2 - (width / 2), screenHeight / 2 - (height / 2), width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

