using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class FlameSprite : UniversalClassEntity //Return to this later, not needed right now
    {
        
        /*
         * Initalize flame sprite
         */
        public FlameSprite(List<Texture2D[]> spriteSheet, (int, int) position, (String, int)[] items): base(spriteSheet, position, items)
        {
         
        }

       
    }
}