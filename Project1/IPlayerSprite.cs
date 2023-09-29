using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IPlayerSprite
    {
        void Update(int direction, Vector2 pos);
        void Move();
        public void Draw(SpriteBatch spriteBatch, string type);
    }
}