using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEntity
	{
        void Update();
        void Draw(SpriteBatch spriteBatch);

        public void Attack();

        public void ItemDrop();

    }
}


