using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class SkeletonSprite : ISprite
    {
        private Texture2D[] Texture;



        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        //sprite position
        private int pos_x;
        private int pos_y;

        private (Rectangle, Rectangle) rectangles;
        //factor out
        private int width;
        private int height;

        //factor out
        private int elapsedTime;
        private int msecPerFrame;


        /*
         * Initalize Skelly
         */
        public SkeletonSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            
            current_frame = START_FRAME;
            total_frame = SKELETON_TOTAL;
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;


            elapsedTime = 0;
            msecPerFrame = 300;

            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;
        }

        /*
         * Update skelly
         */
        public void Update()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            
            Move();
            UpdateFrames();

        }

        /*
         * Animate Skelly
         */
        public void UpdateFrames()
        {
            if (elapsedTime >= msecPerFrame)
            {
                elapsedTime -= msecPerFrame;
                current_frame += 1;
            }

            if (current_frame >= total_frame)
                current_frame = START_FRAME;
        }


        /*
         * Move skelly
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
         * Draw Skelly
         */
        public void Draw(SpriteBatch spriteBatch)
        {
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

