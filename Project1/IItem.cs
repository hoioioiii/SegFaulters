using System;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IItem
	{
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}

