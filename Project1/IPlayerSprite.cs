using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IPlayerSprite
    {
        public bool isDead { get; set; }

        void Update(int direction, Vector2 pos);
        public void Draw(SpriteBatch spriteBatch, string type);
    }
}
