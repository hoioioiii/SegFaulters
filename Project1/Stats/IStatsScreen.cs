using System;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IStatsScreen
	{
        public void Draw(SpriteBatch spritebatch);
        public void Update();
    }
}

