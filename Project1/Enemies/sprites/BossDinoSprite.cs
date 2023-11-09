using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class BossDinoSprite : UniversalSpriteClass
    {
        
        public BossDinoSprite(List<Texture2D[]> spriteSheet, IAnimation animation, IMove movement, IDirectionStateManager direction, IEntityState state, ITime time) : base(spriteSheet,animation, movement, state, direction, time)

        {
            animation.frame_list = spriteSheet;
        }

       
    }
}

