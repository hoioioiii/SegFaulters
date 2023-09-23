using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using System.Diagnostics;

namespace Project1
{
	public class Bat : IEnemy
	{

        //Texture stores the texture alias for our animation
        private Texture2D Texture { get; set; }

        //rows is the number of rows i the texture alias
        private int Rows { get; set; }

        //Columns is the number of columns in the alias
        private int Columns { get; set; }

        //curremtFrame is used to keep track of which frame of the animation we are currently on
        private double CURRENT_FRAME;

        //totalFrames keeps track of how many frames there are in total
        private int TOTAL_FRAME;

        //Remove later-------
        private Game1 GameObj;
        private ContentManager ContentLoad;

        //Remove later above--------------



        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;


        public Bat()
		{
            //remove later:
            GameObj = Constants.GameObj;
            ContentLoad = GameObj.Content;
            Texture = Load();
        }
        //change the current frame to the next frame
        public void Update()
        {
            Health();
            CURRENT_FRAME += Constants.FRAME_SPD;
            if (CURRENT_FRAME >= TOTAL_FRAME)
                CURRENT_FRAME = START_FRAME;
        }

        private void Animate()
        {

            //determine which part of hte texture square needs to be drawm for hte current frame.
            //Start off by calculating the width and height of the frame.This finds the width and height of 1 image square
            WIDTH = Texture.Width / Columns;
            HEIGHT = Texture.Height / Rows;
            //Then calculate which row and column the current frame is located at.
            ROW = (int)CURRENT_FRAME / Columns;
            COL = (int)CURRENT_FRAME % Columns;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            Rectangle SOURCE_REC = new Rectangle(WIDTH * COL, HEIGHT * ROW, WIDTH, HEIGHT);
            Rectangle DEST_REC = new Rectangle(Constants.SPRITE_X, Constants.SPRITE_X, WIDTH, HEIGHT);
            spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);

        }

        /*
         * Responsible for setting the the frame numbers(r,c) of the sprite
         */
        private void setFrames()
        {
            Rows = Constants.BAT_R;
            Columns = Constants.BAT_C;
            CURRENT_FRAME = Constants.START_FRAME;
            TOTAL_FRAME = Rows * Columns;
        }

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load()
        {
            setFrames();
            return ContentLoad.Load<Texture2D>(assetName: "KEESE_BAT");
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Health()
        {
            //Check health
        }

        public void Attack()
        {
           //Attacks
        }

        public void ItemDrop()
        {
            //Items they drop
        }
    }
}

