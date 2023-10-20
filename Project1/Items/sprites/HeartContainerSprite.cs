using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class HeartContainerSprite : IItemSprite
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
        private int pos_x;
        private int pos_y;

        private static Vector2 position;

        private int width;
        private int height;
        private Rectangle rect;

        public HeartContainerSprite(Texture2D[] spriteSheet, (int, int) pos)
        {
            Texture = spriteSheet;
            Rows = HEART_CONTAINER_R;
            Columns = HEART_CONTAINER_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            pos_x = pos.Item1;
            pos_y = pos.Item2;
            position = Player.getUserPos();
        }
        public void Update()
        {
            position = Player.getUserPos();
        }

        private void setDimention()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        // draw inside Link's inventory
        public void Draw(SpriteBatch spriteBatch)
        {
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

        // draw inside level loader
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int scale)
        {
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            rect = DEST_REC;
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        public Rectangle getRect()
        {
            return rect;
        }

    }
}




