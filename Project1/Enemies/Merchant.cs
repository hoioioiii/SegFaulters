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
    public class Merchant : IEntity
	{

        private ISprite sprite;


        /*
         * Initalize the merchant
         */
        public Merchant()
		{
         
            sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
        }

        /*
         * 
         * Update the merchant
         */
        public void Update()
        {
            sprite.Update();
         
        }

       /*
        * Draw the merchant
        */
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

      
        /*
         * Merchant health -> maybe?
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         *prob not  -> Maybe?
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Maybe?
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}

