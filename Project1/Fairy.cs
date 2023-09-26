using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1
{
    public class Fairy : IItem
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Texture2D[] sprites;
        //private int XCoordinate;
        private int screenWidth;
        private int screenHeight;
        public Fairy(Game1 game1)
		{
            sprites[0] = Game1.spriteStorage[14];
            sprites[1] = Game1.spriteStorage[15];
            Rows = 1;
            Columns = 2;
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
            Texture = sprites[currentFrame];
            int width = Texture.Width;
            int height = Texture.Height;
            //int row = currentFrame / Columns;
            //int column = currentFrame % Columns;
            //rectangle within the texture (the source) that we want to draw
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
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

