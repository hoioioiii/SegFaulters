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
            //Texture = Load();
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

