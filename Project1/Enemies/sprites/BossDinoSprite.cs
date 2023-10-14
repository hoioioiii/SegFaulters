using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class BossDinoSprite : ISprite
    {
        private Texture2D[] Texture;



        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;
        private int pos_x;
        private int pos_y;

        private int width;
        private int height;
        

        //Gonna factor out into a Animation class
        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;


        //Gonna factor out into Direction Manager
        private int Direction;
        private bool WalkDown;
        private bool WalkUp;
        private int secondsPassed;
        public BossDinoSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            
            
            current_frame = START_FRAME;
            
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;

            //Factor out into Direction Manager
            elapsedTime = 0;
            msecPerFrame = 300;

            //This is handled by the direction Manager, change later
            WalkDown = true;
            Direction = 1;
            secTillDirChange = 1;

            //keeps track if frames width/height
            width = Texture[current_frame].Width;
            height = Texture[current_frame].Height;

        }

        /*
         * Update movement and animation
         */
        public void Update()
        {

            elapsedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            secondsPassed += Game1.deltaTime.ElapsedGameTime.Seconds;
            Move();
            UpdateFrames();

        }

        /*
         * Update Animation
         */
        public void UpdateFrames()
        {
            if (elapsedTime >= msecPerFrame)
            {
                elapsedTime -= msecPerFrame;
                current_frame += 1;
            }

            if (current_frame >= DINO_TOTAL)
                current_frame = START_FRAME;

            
        }

        /*
         * Going to be factored out in Direction Manager Class
         */
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

        /*
         * Movement -> to be factored out into Movement Class
         */
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

        //To be factored out into draw class.
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle SOURCE_REC = new Rectangle(1,1, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

