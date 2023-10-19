using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEntity
	{
        public Rectangle BoundingBox { get; }

        void Update();
        void Draw(SpriteBatch spriteBatch);

        public void Attack();

        public void ItemDrop();

        //public Rectangle getPositionAndRectangle();

        public void setPosition(int x, int y);
        
    }
}


