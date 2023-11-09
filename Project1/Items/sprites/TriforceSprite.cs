using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class TriforceSprite : IItemSprite
    {
        //Stores all frames for the item
        private Texture2D[] Texture { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double current_frame { get; set; }

        //totalFrames keeps track of how many frames there are in for this item
        private int total_frame { get; set; }

        //position specifed by XML
        private int pos_x { get; set; }
        private int pos_y { get; set; }

        //bounding box
        private Rectangle rect;

        //dimentions of sprite frame
        private int width;
        private int height;


        public TriforceSprite(Texture2D[] spriteSheet, (int, int) pos)
        {
            Texture = spriteSheet;
            current_frame = START_FRAME;
            total_frame = TRIFORCE_TOTAL;
            pos_x = pos.Item1;
            pos_y = pos.Item2;
        }
        public void Update()
        {
            // code for animation
            current_frame += FRAME_SPD;
            if (current_frame >= total_frame)
                current_frame = START_FRAME;
        }

        private void setDimention()
        {
            width = Texture[(int)current_frame].Width;
            height = Texture[(int)current_frame].Height;
        }

        // draw inside Link's inventory
        public void Draw(SpriteBatch spriteBatch)
        {
            pos_x = (int)Player.getUserPos().X;
            pos_y = (int)Player.getUserPos().Y;
            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width, height);
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }

        // draw inside level loader
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int scale)
        {
            //setDimention();
            //Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            //Rectangle DEST_REC = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            //rect = DEST_REC;
            //spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);


            setDimention();
            Rectangle SOURCE_REC = new Rectangle(0, 0, width, height);
            Rectangle DEST_REC = new Rectangle(pos_x, pos_y, width * scale, height * scale);
            rect = DEST_REC;
            spriteBatch.Draw(Texture[(int)current_frame], DEST_REC, SOURCE_REC, Color.White);
        }
        public Rectangle getRect()
        {
            return rect;
        }

    }
}



