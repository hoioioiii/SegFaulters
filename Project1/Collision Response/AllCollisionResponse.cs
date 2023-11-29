using Microsoft.Xna.Framework;
using System;
using System.Text;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class AllCollisionResponse
    {
        /*
         * Handles collision response methods used by both Link and enemies
         * Send the collision type to be handled by the appropriate collision response class
         */

        /* Knock back target (player or enemy)
         * Offset from current entity position, opposite the direction of collision
         * 
         * need position and direction
         * what should be the knock back duration?
         * Knockback speed should be equal to speed of player or enemy
         * How to make this an instance method?
         */
        public static Vector2 Knockback(Vector2 position, DIRECTION directon, int knockbackDist)
        {
            switch (directon)
            {
                case DIRECTION.left:
                    position = position + new Vector2(knockbackDist, 0);
                    position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
                    break;
                case DIRECTION.right:
                    position = position + new Vector2(-knockbackDist, 0);
                    position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
                    break;
                case DIRECTION.down:
                    position = position + new Vector2(0, knockbackDist);
                    position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
                    break;
                case DIRECTION.up:
                    position = position + new Vector2(0, -knockbackDist);
                    position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
                    break;
            }

            return position;
        }

    }
}
