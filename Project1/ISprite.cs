using System;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface ISprite
    {
        void Update();
        void Move();
        public void Draw(SpriteBatch spriteBatch);
    }
}


