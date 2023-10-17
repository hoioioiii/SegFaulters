using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IItem
	{
        public Rectangle BoundingBox { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}


