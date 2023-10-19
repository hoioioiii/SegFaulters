using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEnemy
	{
        public Rectangle BoundingBox { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);

        public void Attack();

        public void ItemDrop();

    }
}


