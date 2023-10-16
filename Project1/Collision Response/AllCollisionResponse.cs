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
         * Offset from current entity position
         * 
         * TODO: need position and direction
         * what should be the knock back duration and speed?
         */
        public static Vector2 Knockback(Enum DIRECTION)
        {
            return new Vector2(0, 0);
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
