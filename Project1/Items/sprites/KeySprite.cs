using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class KeySprite : IItemSprite
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

        private static Vector2 position;

        private int width;
        private int height;


        public KeySprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;
            Rows = KEY_R;
            Columns = KEY_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
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
            Rectangle DEST_REC = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

        // draw inside level loader
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int scale)
        {
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

    }
}





