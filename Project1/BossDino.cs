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

        private ISprite sprite;

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

            sprite = EnemySpriteFactory.Instance.CreateDinoSprite();
        }
        public void Update()
        {
            sprite.Update();
            
        }

        private void Animate()
        {
           

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Responsible for setting the the frame numbers(r,c) of the sprite
         */
        private void setFrames()
        {
           
        }

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load()
        {
            /*
            setFrames();
            */
            return ContentLoad.Load<Texture2D>(assetName: "DINO");
            
        }

        public void Move()
        {
            
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

