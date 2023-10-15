using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class ClockSprite : IItemSprite
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

        private static Vector2 position;

        private int width;
        private int height;


        public ClockSprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;
            Rows = CLOCK_R;
            Columns = CLOCK_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = SPRITE_X;
            pos_y = SPRITE_Y;

            position = Player.getUserPos();
        }
        public void Update()
        {

            //Move();
            position = Player.getUserPos();
        }

        private void setDimention()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, int scale)
        {
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

    }
}



