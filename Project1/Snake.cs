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
namespace Project1
{
	public class Snake : IEnemy
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
        private Game1 GameObject;
        private ContentManager ContentLoad;

        //Remove later above--------------



        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;

        //Movement:
        private int POS_X;
        private int POS_Y;

<<<<<<< HEAD
        private ISprite sprite;

        public Snake()
		{
            //remove later:
            /*
=======
        public Snake()
		{
            //remove later:
>>>>>>> origin/state-transition-character-interface-2.0
            GameObject = Constants.GameObj;
            ContentLoad = GameObject.Content;
            Texture = Load();
            POS_X = SPRITE_X;
            POS_Y = SPRITE_Y;
<<<<<<< HEAD
            */

            sprite = EnemySpriteFactory.Instance.CreateSnakeSprite();
=======
>>>>>>> origin/state-transition-character-interface-2.0
        }

       
        public void Update()
        {
<<<<<<< HEAD
            sprite.Update();
            /*
=======
>>>>>>> origin/state-transition-character-interface-2.0
            Move();
            CURRENT_FRAME += FRAME_SPD;
            if (CURRENT_FRAME >= TOTAL_FRAME)
                CURRENT_FRAME = START_FRAME;
<<<<<<< HEAD
            */
=======
>>>>>>> origin/state-transition-character-interface-2.0
        }

        private void Animate()
        {

<<<<<<< HEAD
            //WIDTH = Texture.Width / Columns;
            //HEIGHT = Texture.Height / Rows;

            //ROW = (int)CURRENT_FRAME / Columns;
            //COL = (int)CURRENT_FRAME % Columns;
=======
            WIDTH = Texture.Width / Columns;
            HEIGHT = Texture.Height / Rows;

            ROW = (int)CURRENT_FRAME / Columns;
            COL = (int)CURRENT_FRAME % Columns;
>>>>>>> origin/state-transition-character-interface-2.0

        }
        public void Draw(SpriteBatch spriteBatch)
        {
<<<<<<< HEAD
            sprite.Draw(spriteBatch);
=======

            Animate();
            Rectangle SOURCE_REC = new Rectangle(WIDTH * COL, HEIGHT * ROW, WIDTH, HEIGHT);
            Rectangle DEST_REC = new Rectangle(POS_X, POS_Y, WIDTH, HEIGHT);
            spriteBatch.Draw(Texture, DEST_REC, SOURCE_REC, Color.White);
>>>>>>> origin/state-transition-character-interface-2.0
        }

        /*
          * Responsible for setting the the frame numbers(r,c) of the sprite
          */
        private void setFrames()
        {
<<<<<<< HEAD
            //Rows = SNAKE_R;
            //Columns = SNAKE_C;
            //CURRENT_FRAME = START_FRAME;
            //TOTAL_FRAME = Rows * Columns;
=======
            Rows = SNAKE_R;
            Columns = SNAKE_C;
            CURRENT_FRAME = START_FRAME;
            TOTAL_FRAME = Rows * Columns;
>>>>>>> origin/state-transition-character-interface-2.0
        }

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load()
        {
<<<<<<< HEAD
            //setFrames();
=======
            setFrames();
>>>>>>> origin/state-transition-character-interface-2.0
            return ContentLoad.Load<Texture2D>(assetName: "SNAKE");
        }

        public void Move()
        {
<<<<<<< HEAD
            //int DIR_X = RandomMove.RandMove();
            //int DIR_Y = RandomMove.RandMove();

            ////Add bounding constraints:

            //POS_X += RandomMove.CheckBounds(DIR_X, POS_X, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            //POS_Y += RandomMove.CheckBounds(DIR_Y, POS_Y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);
=======
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:

            POS_X += RandomMove.CheckBounds(DIR_X, POS_X, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            POS_Y += RandomMove.CheckBounds(DIR_Y, POS_Y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);
>>>>>>> origin/state-transition-character-interface-2.0


        }

        public void Health()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

