using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEntity
	{
        public Rectangle BoundingBox { get; }

        //void Update();
        //void Draw(SpriteBatch spriteBatch);

        //public void Attack();

        //public void ItemDrop();

        //public Rectangle getPositionAndRectangle();

        //public void setPosition(int x, int y);

        void Update();
        void Move();
        public void Draw(SpriteBatch spriteBatch);

        public void setPosition(int x, int y);

        public (int, int) getPos();

        //public void setRectangles();

        public void ChangeDirections();
        /**
         * Gets the source and destination rectangle from the object 
         * Form: (Source Rectangle, Destination Rectangle)
         **/
        //public (Microsoft.Xna.Framework.Rectangle, Microsoft.Xna.Framework.Rectangle) GetRectangle();
        public Rectangle GetPositionAndRectangle();

        public void TakeDamage(int amount);

        
    }
}


