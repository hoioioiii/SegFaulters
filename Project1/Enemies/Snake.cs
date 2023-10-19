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
        public Rectangle BoundingBox { get; set; }
        //Texture stores the texture alias for our animation
        private Texture2D Texture { get; set; }

        private ISprite sprite;


        /*
         * Initalize snake
         */
        public Snake()
		{
         
            sprite = EnemySpriteFactory.Instance.CreateSnakeSprite();
        }

       
        /*
         * Update snake
         */
        public void Update()
        {
            sprite.Update();
         
        }

     /*
      * Draw Snake
      */
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

   
        /*
         * Snake health
         */
        public void Health()
        {
            throw new NotImplementedException();
        }


        /*
         * 
         * Snake attk
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }


        /*
         * Snake item drop death
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

