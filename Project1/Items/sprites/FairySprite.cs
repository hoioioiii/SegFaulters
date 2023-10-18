using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class FairySprite : ISprite
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
        private (Rectangle, Rectangle) rectangles;

        public FairySprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;
            Rows = FAIRY_R;
            Columns = FAIRY_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = SPRITE_X;
            pos_y = SPRITE_Y;
        }
        public void Update()
        {

            //Move();
            current_frame += FRAME_SPD;
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

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            setRectangles();
            spriteBatch.Draw(Texture[(int)current_frame], rectangles.Item2, rectangles.Item1, Color.White);
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



