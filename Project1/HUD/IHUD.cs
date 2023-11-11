using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.HUD
{
	public interface IHUD
	{
        public void Update(bool fullMenu);
        public void Draw(SpriteBatch spriteBatch);
        public void DrawFollowCamera(SpriteBatch spriteBatch);
    }
}

