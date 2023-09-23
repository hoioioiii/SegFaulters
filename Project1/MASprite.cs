using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    // moving, animated sprite
    internal class MASprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private int totalSteps;
        private int currentStep;
        bool isMovingForward;

        public MASprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            totalSteps = 30;
            currentStep = 0;
            isMovingForward = true;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            
            // steps for movement
            if (isMovingForward)
            {
                if (currentStep < totalSteps)
                {
                    currentStep++;
                }
                else
                {
                    isMovingForward = false;
                }
            }
            else
            {
                if (currentStep > -totalSteps)
                {
                    currentStep--;
                }
                else
                {
                    isMovingForward = true;
                }
            }
            

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X + currentStep, (int)location.Y, width, height);
                    
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
