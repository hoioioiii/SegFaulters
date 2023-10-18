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
    public class Jelly : IEntity
	{
       
        private ISprite sprite;

        public Jelly()
        {
            
            sprite = EnemySpriteFactory.Instance.CreateJellySprite();
        }

        /*
         * Update the sprite
         */
        public void Update()
        {
            sprite.Update();
           
        }

        /*
         * Draw the sprite
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }


        /*
         * Move the sprite
         */
        public void Move()
        {
            sprite.Move();

        }

        /*
         * Sprite health -> later
         */
        public void Health()
        {
            throw new NotImplementedException();
        }


        /*
         * Sprite attack -> later
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Sprite ItemDrop -> later
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

