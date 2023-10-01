using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class DogMonsterSprite : ISprite
    {
        private Texture2D[] Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows { get; set; }

        //Columns is the number of columns in the alias
        private int Columns { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double current_frame { get; set; }

        //totalFrames keeps track of how many frames there are in total
        private int total_frame { get; set; }

        private int pos_x { get; set; }
        private int pos_y { get; set; }

        private int width;
        private int height;


        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;

        public static int Direction;
        private int secondsPassed;

        private bool WalkDown;
        private bool WalkLeft;

        private bool Vertical;

        private String[] MovementArray;

        public DogMonsterSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            Rows = DM_R;
            Columns = DM_C;
            current_frame = START_FRAME;
            total_frame = 2;
            pos_x = SPRITE_X;
            pos_y = SPRITE_Y;


            elapsedTime = 0;
            msecPerFrame = 300;
            WalkDown = true;
            WalkLeft = true;
            Vertical = false;
            Direction = 1;
            secTillDirChange = 1;

            


        }
        public void Update()
        {

            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            secondsPassed += Game1.deltaTime.ElapsedGameTime.Seconds;
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

        public void ChangeDirectionX()
        {
            this.Direction = Direction * -1;
            if (WalkLeft)
            {
                WalkLeft = false;
                START_FRAME = 4;
                total_frame = 6;
            }
            else
            {
                WalkLeft = true;
                START_FRAME = 6;
                total_frame = 8;
            }

            current_frame = START_FRAME;
        }


        public void ChangeDirectionY()
        {
            this.Direction = Direction * -1;
            if (WalkDown)
            {
                WalkDown = false;
                START_FRAME = UP_DIRECTION_SPRITE;
                total_frame = 4;
            }
            else
            {
                WalkDown = true;
                START_FRAME = DOWN_DIRECTION_SPRITE;
                total_frame = 2;
            }

            current_frame = START_FRAME;
        }

        public void ChangeDirectionPath()
        {
            if (Vertical)
            {
                Vertical = false;
                WalkLeft = true;
                ChangeDirectionX();
            }
            else
            {
                Vertical = true;
                WalkDown = true;
                ChangeDirectionY();
            }
        }


        public void Move()
        {   
            if (elapsedTime >= msecPerFrame)
            {
                secTillDirChange += 1;

                if (secTillDirChange > 3)
                {
                    ChangeDirectionPath();
                    secTillDirChange = 0;
                }  
            }
            if (Vertical)
            {
                pos_y += Direction;

                if (pos_y >= SCREEN_HEIGHT_UPPER || pos_y <= SCREEN_HEIGHT_LOWER)
                {
                    ChangeDirectionY();
                }
            }
            else
            {
                pos_x += Direction;

                if (pos_x >= SCREEN_WIDTH_UPPER || pos_x <= SCREEN_WIDTH_LOWER)
                {
                    ChangeDirectionX();
                }
            }
          

           
        }

        private void Animate()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(1, 1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

