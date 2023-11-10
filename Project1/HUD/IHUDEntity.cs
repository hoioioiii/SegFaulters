using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.HUD
{
	public interface IHUDEntity
	{
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}

