using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class ArrowSprite : ISprite
    {
        private Texture2D[] Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows;

        //Columns is the number of columns in the alias
        private int Columns;

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private int current_frame;

        //totalFrames keeps track of how many frames there are in total
        private int total_frame;

        private int pos_x;
        private int pos_y;

        private int width;
        private int height;
        private (Rectangle, Rectangle) rectangles;

        public ArrowSprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;
            Rows = ARROW_R;
            Columns = ARROW_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = SPRITE_X;
            pos_y = SPRITE_Y;
        }

        /*
        * Update
        */
        public void Update()
        {
            
            //Move();
            //current_frame += FRAME_SPD;
            //if (current_frame >= total_frame)
            //    current_frame = START_FRAME;
        }

        /*
         * Sprite Movement
         */
        public void Move()
        {
           
        }

        /*
         * Sprite Animation
         */
        private void Animate()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        /*
        * Draw the sprite
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



