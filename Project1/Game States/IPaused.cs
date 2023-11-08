using System;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IPaused
	{
        public void Update();
        public void Draw(SpriteBatch spriteBatch);

    }
}

