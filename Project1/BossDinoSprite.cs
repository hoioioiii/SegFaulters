using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class BossDinoSprite : ISprite
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

        private int row;
        private int col;
        
        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;

        private int Direction;
        private bool WalkDown;
        private bool WalkUp;
        private int secondsPassed;
        public BossDinoSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            Rows = DINO_R;
            Columns = DINO_C;
            current_frame = 0;
            total_frame = 2;
            pos_x = SPRITE_XE;
            pos_y = SPRITE_YE;

            elapsedTime = 0;
            msecPerFrame = 300;

            WalkDown = true;
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


        public void ChangeDirection() {

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

        public void Move()
        {
            if (secondsPassed >= secTillDirChange)
            {
                elapsedTime -= msecPerFrame;
                ChangeDirection();
                secondsPassed = 0;
            }

            pos_y += Direction;

            if(pos_y >= SCREEN_HEIGHT_UPPER || pos_y <= 0)
            {
                ChangeDirection();
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

            Rectangle SOURCE_REC = new Rectangle(1,1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);

            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

