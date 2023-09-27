using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class JellySprite : ISprite
    {
        private Texture2D Texture { get; set; }

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
        public JellySprite(Texture2D spriteSheet)
		{
            Texture = spriteSheet;
            Rows = JELLY_R;
            Columns = JELLY_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = SPRITE_X;
            pos_y = SPRITE_Y;
        }
        public void Update()
        {
            Move();
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

            width = Texture.Width / Columns;
            height = Texture.Height / Rows;

            row = (int)current_frame / Columns;
            col = (int)current_frame % Columns;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(width * col, height * row, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
        }
    }
}

