using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class BatSprite : ISprite
	{

        //Gets the sprite frames
        private Texture2D[] Texture;

        //current Frame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many sprite frames there are in total
        private int total_frame;

        //Sprite position
        private int pos_x;
        private int pos_y;

        //Width and Height of sprite frames
        private int width;
        private int height;

        //Used for animation purposes, will move moved out to a animation class in future
        private int elapsedTime;
        private int msecPerFrame;

     
        public BatSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
           
            current_frame = 0;
            total_frame = BAT_TOTAL;
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;
            elapsedTime = 0;
            msecPerFrame = 300;

            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;
        }

        /*
         * Update
         */
        public void Update()
        {
            
            Move();
            UpdateFrames();

        }

        /*
         * Animation
         */
        public void UpdateFrames()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= msecPerFrame)
            {
                elapsedTime -= msecPerFrame;
                current_frame += 1;
            }

            if (current_frame >= total_frame)
                current_frame = START_FRAME;
        }

        /*
         * Movement
         */
        public void Move()
        {
            //Have this moved out to a random move class method.
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:
            pos_x += RandomMove.CheckBounds(DIR_X, pos_x, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            pos_y += RandomMove.CheckBounds(DIR_Y, pos_y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);
        }

        /*
         * Draw Sprite
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            //Have this moved out to a draw sprite class to handle all drawings.
            Rectangle SOURCE_REC = new Rectangle(1, 1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

    }
}

