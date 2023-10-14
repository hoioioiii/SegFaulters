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
    public class Hand : IEnemy
    { 
        private ISprite sprite;

        /*
         * Initalize Hand
         */
        public Hand()
		{
           

            sprite = EnemySpriteFactory.Instance.CreateHandSprite();
        }

        /*
         * Update hand
         */
        public void Update()
        {
            sprite.Update();
          
        }

        /*
         * Draw the hand
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Implement health ->later
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Implement Attack later
         * 
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Implement Item drop later
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

