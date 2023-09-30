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
	public class BossDino : IEnemy
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

<<<<<<< HEAD
        private ISprite sprite;
=======

>>>>>>> state-transition-character-interface-2.0

        //Later create a animation tracker class:
        private int WIDTH;
        private int HEIGHT;
        private int ROW;
        private int COL;

        //Movement:
        private int POS_X;
        private int POS_Y;

        public BossDino()
		{
            //remove later:
            GameObject = Constants.GameObj;
            ContentLoad = GameObject.Content;
            Texture = Load();
            POS_X = SPRITE_X;
            POS_Y = SPRITE_Y;
<<<<<<< HEAD

            sprite = EnemySpriteFactory.Instance.CreateDinoSprite();
        }
        public void Update()
        {
            sprite.Update();
            /*
=======
        }
        public void Update()
        {
>>>>>>> state-transition-character-interface-2.0
            Move();
            CURRENT_FRAME += FRAME_SPD;
            if (CURRENT_FRAME >= TOTAL_FRAME)
                CURRENT_FRAME = START_FRAME;
<<<<<<< HEAD
            */
=======
>>>>>>> state-transition-character-interface-2.0
        }

        private void Animate()
        {
<<<<<<< HEAD
            /*
=======

>>>>>>> state-transition-character-interface-2.0
            WIDTH = Texture.Width / Columns;
            HEIGHT = Texture.Height / Rows;

            ROW = (int)CURRENT_FRAME / Columns;
            COL = (int)CURRENT_FRAME % Columns;
<<<<<<< HEAD
            */
=======
>>>>>>> state-transition-character-interface-2.0

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
>>>>>>> state-transition-character-interface-2.0
        }

        /*
         * Responsible for setting the the frame numbers(r,c) of the sprite
         */
        private void setFrames()
        {
<<<<<<< HEAD
            /*
=======
>>>>>>> state-transition-character-interface-2.0
            Rows = DINO_R;
            Columns = DINO_C;
            CURRENT_FRAME = START_FRAME;
            TOTAL_FRAME = Rows * Columns;
<<<<<<< HEAD
            */
=======
>>>>>>> state-transition-character-interface-2.0
        }

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load()
        {
<<<<<<< HEAD
            /*
            setFrames();
            */
            return ContentLoad.Load<Texture2D>(assetName: "DINO");
            
=======
            setFrames();
            return ContentLoad.Load<Texture2D>(assetName: "DINO");
>>>>>>> state-transition-character-interface-2.0
        }

        public void Move()
        {
<<<<<<< HEAD
            /*
=======
>>>>>>> state-transition-character-interface-2.0
            int DIR_X = RandomMove.RandMove();
            int DIR_Y = RandomMove.RandMove();

            //Add bounding constraints:

            POS_X += RandomMove.CheckBounds(DIR_X, POS_X, SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            POS_Y += RandomMove.CheckBounds(DIR_Y, POS_Y, SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);
<<<<<<< HEAD
            */
=======
>>>>>>> state-transition-character-interface-2.0


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

