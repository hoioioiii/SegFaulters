using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class DogMonsterSprite : ISprite
    {
        private Texture2D[] Texture;

        //rows is the number of rows i the texture alias

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //Keeps track of bat position
        private int pos_x;
        private int pos_y;

        //Keeps track of the width and height
        private int width;
        private int height;

        //Factor out into animation class
        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;
        private int total_frame;
        //factor out to direction class
        private int Direction;
        private int secondsPassed;
        private bool WalkDown;
        private bool WalkLeft;
        private bool Vertical;
       
        //factor out into movement class
        private String[] MovementArray;

        public DogMonsterSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            
            current_frame = START_FRAME;
            total_frame = DM_TOTAL;
           
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;

            //factor all out
            elapsedTime = 0;
            msecPerFrame = 300;
            WalkDown = true;
            WalkLeft = true;
            Vertical = false;
            Direction = 1;
            secTillDirChange = 1;


            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        
        /*
         * Update the movement and animation
         */
        public void Update()
        {

            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            secondsPassed += Game1.deltaTime.ElapsedGameTime.Seconds;
            Move();
            UpdateFrames();

        }


        //Update animation
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

        //Factor out into Manager manager
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

        //Factor out into Direction Manager
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

        //FACOR out into direction manager
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

        //Factor out into movement class
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

        //factor out into draw class
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1, 1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

