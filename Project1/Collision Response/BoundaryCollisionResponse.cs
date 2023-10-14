using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class BoundaryCollisionResponse
    {
        /* 
         * There should be knockback applied to the target, moving them backwards from the direction they collided in
         * This class handles what happens when the target collisides with a boundary
         */

        // Knock back target (player or enemy)
        void Knockback()
        {

        }

        /*
        void Knockback(DIRECTION direction)
        {
            switch(direction)
            {
                case DIRECTION.right:
                    break;
                case DIRECTION.left:
                    break;
                case DIRECTION.up:
                    break;
                case DIRECTION.down:
                    break;
                default:
                    throw new ArgumentException("");
            }
        }
        */


        }
}
