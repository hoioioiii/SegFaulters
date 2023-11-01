using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using System.Collections.Generic;

namespace Project1.Enemies.sprites
{
    public class BatSprite : UniversalSpriteClass
    {

        

        public BatSprite(List<Texture2D[]> spriteSheet, IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time):base(spriteSheet,animation,movement, state,direction, time)
        {
           animation.frame_list = spriteSheet;
        }

        

       
    }
}

