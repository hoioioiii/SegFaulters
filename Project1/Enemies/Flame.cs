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
	public class Flame : IEntity
	{  
        private ISprite sprite;

        /*
         * Initalize the flame
         */
        public Flame()
		{
            sprite = EnemySpriteFactory.Instance.CreateFlameSprite();
        }
        
        /*
         * Update the flame
         */
        public void Update()
        {
            sprite.Update();
          
        }

        /*
         * Draw Flame Sprite
         */
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        /*
         * Maybe not
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Maybe?
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Prob not
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

