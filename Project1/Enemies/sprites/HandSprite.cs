using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class HandSprite : ISprite
    {
        private Texture2D[] Texture;
        private (Rectangle, Rectangle) rectangles;
        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        private int pos_x;
        private int pos_y;




        //factor out for animation class
        private int width;
        private int height;
        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;

        //factor out into direction
        private int Direction;
        private int secondsPassed;

        private bool left;

        /*
         * Initalize the sprite
         */
        public HandSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            
            current_frame = START_FRAME;
            total_frame = HAND_TOTAL;

            //change later to XML
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;


            elapsedTime = 0;
            msecPerFrame = 300;
            left = true;
            Direction = 1;
            secTillDirChange = 1;

            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;
        }

        /*
         * Update the sprite
         */
        public void Update()
        {

            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            secondsPassed += Game1.deltaTime.ElapsedGameTime.Seconds;
            Move();
            UpdateFrames();

        }

        /*
         * Animate the sprite
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
         * Change the sprite direction -> factr out
         */
        public void ChangeDirection()
        {
            this.Direction = Direction * -1;

            if (left)
            {
                left = false;
                total_frame = 4;
                START_FRAME = 2;
            }
            else
            {
                left = true;
                total_frame = 2;
                START_FRAME = 0;
            }
        }

        /*
         * Move the sprite -> factor out
         */
        public void Move()
        {
            if (secondsPassed >= secTillDirChange)
            {
                elapsedTime -= msecPerFrame;
                ChangeDirection();
                secondsPassed = 0;
            }

            pos_x += Direction;

            if (pos_x >= SCREEN_WIDTH_UPPER || pos_x <= SCREEN_WIDTH_LOWER)
            {
                ChangeDirection();
            }
        }

        /*
         * Draw Sprite -> factor out later
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

