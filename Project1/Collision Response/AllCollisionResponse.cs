using Microsoft.Xna.Framework;
using System;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class AllCollisionResponse
    {
        /*
         * Handles collision response methods used by both Link and enemies
         * Send the collision type to be handled by the appropriate collision response class
         */


        #region Collision Response action methods
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
                    break;
                case DIRECTION.right:
                    position = position + new Vector2(-knockbackDist, 0);
                    break;
                case DIRECTION.down:
                    position = position + new Vector2(0, knockbackDist);
                    break;
                case DIRECTION.up:
                    position = position + new Vector2(0, -knockbackDist);
                    break;
            }
                      
            return position;
        }

        /*
         * Lower health variable of Link or enemy
         * Apply temporary invincibility so the entity can't take every frame
         * Are there different damage amounts from different damage sources?
         */
        public static void ApplyDamage()
        {
             
        }

        #endregion
    }
}
