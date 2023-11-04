using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Project1
{
    public interface ISprite
    {
        //void Update();
        //void Move();
        public void Draw(SpriteBatch spriteBatch, IWeapon weapon);
        public void Draw(SpriteBatch spriteBatch);
        //public void setPos(int x, int y);

        //public (int, int) getPos();

        //public void setRectangles();



        ///**
        // * Gets the source and destination rectangle from the object 
        // * Form: (Source Rectangle, Destination Rectangle)
        // **/
        public (Microsoft.Xna.Framework.Rectangle, Microsoft.Xna.Framework.Rectangle) GetRectangle();


    }
}


