﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
	public interface IItem
	{
        void Update();
        void Draw(SpriteBatch spriteBatch);
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int spriteScale);
    }
}


