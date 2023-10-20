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
	public class SpikeCross : IEntity
	{
        public Rectangle BoundingBox => getPositionAndRectangle();
        private ISprite sprite;

        /*
         * Initalize Spike
         */
        public SpikeCross((int, int) position, (String, int)[] items)
		{
            
            sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite(position, items);
        }
       
        /*
         * Update Spike
         */
        public void Update()
        {
            sprite.Update();
          
        }
      
        /*
         * Draw Spike
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

     
        /*
         * Spike Heath -> later
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * 
         * Spike aTTK -> LATER
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Spike item driop -> later
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

