using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class FlameSprite : ISprite //Return to this later, not needed right now
    {
        private (Rectangle, Rectangle) rectangles;
        private Texture2D[] Texture;



        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        private int pos_x;
        private int pos_y;

        private int width;
        private int height;

        /*
         * Initalize flame sprite
         */
        public FlameSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            current_frame = START_FRAME;
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;
            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;

        }
        /*
         * Update
         */
        public void Update()
        {
            Move();
        }

        /*
         * Movement- > optomize later
         */
        public void Move()
        {
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:
            pos_x += RandomMove.CheckBounds(DIR_X, pos_x, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            pos_y += RandomMove.CheckBounds(DIR_Y, pos_y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);


        }

     
        /*
         * Factor out into Draw class
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            setRectangles();
            spriteBatch.Draw(Texture[current_frame], rectangles.Item2, rectangles.Item1, Color.White);
        }

        public void setPos(int x, int y)
        {
            pos_x = x; pos_y = y;
        }

        public (int, int) getPos()
        {
            return (pos_x, pos_y);
        }

        public void setRectangles()
        {
            rectangles.Item1 = new Rectangle(1, 1, width, height);
            rectangles.Item2 = new Rectangle(pos_x, pos_y, width, height);
        }

        public (Rectangle, Rectangle) GetRectangle()
        {
            return rectangles;
        }
    }
}

