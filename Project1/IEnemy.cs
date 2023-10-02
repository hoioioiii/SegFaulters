using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IEnemy
	{
        void Update();
        void Draw(SpriteBatch spriteBatch);


        //public Texture2D Load();

        public void Move();

        public void Health();

        public void Attack();

        public void ItemDrop();

    }
}


