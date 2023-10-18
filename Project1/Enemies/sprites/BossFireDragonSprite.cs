using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class BossFireDragonSprite : ISprite
    {
        private Texture2D[] Texture;


        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        //Positon of Each Sprite
        public static int pos_x;
        public static int pos_y;

        //Gonna find a diff way to do this 
        private int width;
        private int height;

        //factor out into animation class
        private int elapsedTime;
        private int msecPerFrame;
        private int secTillDirChange;

        //factor out into direction class
        private int Direction;
        private int secondsPassed;

        public static bool newAttack;
        private (Rectangle, Rectangle) rectangles;
        public BossFireDragonSprite(Texture2D[] spriteSheet)
		{
            Texture = spriteSheet;
            current_frame = START_FRAME;
            pos_x = SPRITE_X_START;
            pos_y = SPRITE_Y_START;


            newAttack = true;

            //Factor out in animate class
            elapsedTime = 0;
            msecPerFrame = 300;

            //factor out into direction class
            Direction = 1;
            secTillDirChange = 1;

            //fix this later
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
         * Animate Sprite
         */
        public void UpdateFrames()
        {
            if (elapsedTime >= msecPerFrame)
            {
                elapsedTime -= msecPerFrame;
                current_frame += 1;
            }

            if (current_frame >= FD_TOTAL)
                current_frame = START_FRAME;
        }

        /*
         * Factor into direction manager
         * 
         */
        public void ChangeDirection()
        {

            this.Direction = Direction * -1;
        }

        /*
         * Moves dragon
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
         * Draw's Dragon
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            setRectangles();
            spriteBatch.Draw(Texture[current_frame], rectangles.Item2, rectangles.Item1, Color.White);
        }

        //TODO:FIX
        /*
         * Gets Dragons Position
         */
        public static Vector2 getUserPos()
        {
            return new Vector2(pos_x, pos_y);
        }

        /*
         * Gets dragons Direction
         */
        public static int getUserDirection()
        {
            //Replace with the direction manager
            return 4;
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

