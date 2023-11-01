using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;
using System.Collections.Generic;

namespace Project1.Enemies.sprites
{
    public class BatSprite : UniversalClassEntity
    {

        

        public BatSprite(List<Texture2D[]> spriteSheet, (int, int)position, (String, int)[] items):base(spriteSheet,position,items)
        {
           
        }

        public override void MovementType()
        {

            //Movement.WanderMove(direction_state_manager, this, time_manager);
            this.movement_manager.circularMovement(Direction.Right);
        }

       
    }
}

