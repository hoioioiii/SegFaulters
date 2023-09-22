using System;
using Microsoft.Xna.Framework.Graphics;

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
    }
}

