using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class TriforceSprite : ISprite
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


        public TriforceSprite(Texture2D[] spriteSheet)
        {
            Texture = spriteSheet;
            Rows = TRIFORCE_R;
            Columns = TRIFORCE_C;
            current_frame = START_FRAME;
            total_frame = Rows * Columns;
            position = Player.getUserPos();
        }
        public void Update()
        {

            //Move();
            position = Player.getUserPos();
            current_frame += FRAME_SPD;
            if (current_frame >= total_frame)
                current_frame = START_FRAME;
        }

        public void Move()
        {
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:
           


        }

        private void Animate()
        {

            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

    }
}



