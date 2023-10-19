using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class SnakeSprite : ISprite
    {
        private Texture2D[] Texture;



        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        //factor all out into later classes
        private int pos_x;
        private int pos_y;

        private int width;
        private int height;


        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;

        private int Direction;
        private int secondsPassed;

        private bool left;


        /*
         * Initalize snake
         */
        public SnakeSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            
            current_frame = START_FRAME;
            total_frame = SNAKE_TOTAL;
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;


            //factor out
            elapsedTime = 0;
            msecPerFrame = 300;
            left = true;
            Direction = 1;
            secTillDirChange = 1;
        }

        /*
         * Update snake
         */
        public void Update()
        {

            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            secondsPassed += Game1.deltaTime.ElapsedGameTime.Seconds;
            Move();
            UpdateFrames();

        }

        /*
         * Animate snake
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
         * Factor out to direction
         */
        public void ChangeDirection()
        {

            this.Direction = Direction * -1;

            if (left)
            {
                left = false;
                total_frame = 4;
                START_FRAME = 3;
            }
            else
            {
                left = true;
                total_frame = 1;
                START_FRAME = 0;
            }
        }


        /*
         * move snake
         */
        public void Move()
        {
            if (secondsPassed >= secTillDirChange)
            {
                secondsPassed -= secTillDirChange;
                ChangeDirection();
                //secondsPassed = 0;
            }

            pos_x += Direction;

            if (pos_x >= SCREEN_WIDTH_UPPER || pos_x <= SCREEN_WIDTH_LOWER)
            {
                ChangeDirection();
            }

        }

        /*
         * Animate snake
         */
        private void Animate()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

           

        }


        /*
         * Draw snake
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(1, 1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}


