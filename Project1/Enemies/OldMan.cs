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
    public class OldMan : IEntity
	{
        private ISprite sprite;


        /*
         * Initalize OldMan
         */
        public OldMan()
		{
            
            sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
        }

        /*
         * Update Old man 
         */
        public void Update()
        {
            sprite.Update();
           
        }


        /*
         * Draw Old man
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Health -> implement?
         */
        public void Health()
        {
            throw new NotImplementedException();
        }


        /*
         * Attack -> implement?
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * ItemDrop -? implement?
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

