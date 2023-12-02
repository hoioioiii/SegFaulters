using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEntity
	{
        public Rectangle BoundingBox { get; }


        public Rectangle DetectionFieldX { get; }
        public Rectangle DetectionFieldY { get;}

        

        public (bool,bool) detected { get; set; }
        public void SetDetected(bool x, bool y);
        void Update();
        void Move();
        public void Draw(SpriteBatch spriteBatch);

        public void setPosition(int x, int y);

        public (int, int) getPos();

        public void ChangeDirections();
      
        public Rectangle GetPositionAndRectangle();

        public void TakeDamage(int amount);

        
    }
}


