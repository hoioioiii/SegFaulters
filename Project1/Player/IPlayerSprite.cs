using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IPlayerSprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, string _type, int direction, Vector2 location);
        public Rectangle getRectangle();



        //this is only for test purposes:

        public void Draw();
    }
}
