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
	public class BossDino : IEntity
    { 

        private ISprite sprite;

        /*
         * Initialize Dino
         */
        public BossDino()
		{

            sprite = EnemySpriteFactory.Instance.CreateDinoSprite();
        }

        /*
         * Update Dino 
         */
        public void Update()
        {
            sprite.Update();
            
        }

        /*
         * Draw Dino
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        
        /*
         * Dino's health
         * Future Implement
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Dino's attack 
         * Future Implement
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Dino death drop
         * Future Implement
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }


        public Rectangle getPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public void setPosition(int x, int y)
        {
            sprite.setPos(x, y);

        }





    }
}

