using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class SkeletonSprite : ISprite
    {
        private Texture2D[] Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows { get; set; }

        //Columns is the number of columns in the alias
        private int Columns { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame { get; set; }

        //totalFrames keeps track of how many frames there are in total
        private int total_frame { get; set; }

        private int pos_x { get; set; }
        private int pos_y { get; set; }

        private int width;
        private int height;

        private int elapsedTime;
        private int msecPerFrame;


        public SkeletonSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            Rows = SKELETON_R;
            Columns = SKELETON_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = SPRITE_XE;
            pos_y = SPRITE_YE;


            elapsedTime = 0;
            msecPerFrame = 300;
        }
        public void Update()
        {
            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            
            Move();
            UpdateFrames();

        }

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

        public void Move()
        {
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:
            pos_x += RandomMove.CheckBounds(DIR_X, pos_x, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            pos_y += RandomMove.CheckBounds(DIR_Y, pos_y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);


        }

        private void Animate()
        {

            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(1, 1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

