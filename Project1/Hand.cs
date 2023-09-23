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
namespace Project1
{
    public class Hand : IEnemy
	{
		public Hand()
		{
           
		}
        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            //Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            //Rectangle destinationRectangle = new Rectangle(screenWidth / 2 - (width / 2), YCoordinate, width, height);

            spriteBatch.Begin();
            //spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Texture2D Load()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
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

