using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class HandSprite : UniversalClassEntity
    {
        /*
         * Initalize the sprite
         */
        public HandSprite(List<Texture2D[]> spriteSheet, (int, int) position, (String, int)[] items): base(spriteSheet, position, items)
        {
          
        }

      
    }
}


