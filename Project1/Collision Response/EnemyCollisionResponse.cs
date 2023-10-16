using System;
using Microsoft.Xna.Framework;
using Project1.Collision;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class EnemyCollisionResponse
    {
        #region Collision Response Enemy

        /*
         * 
         */
        public static void BoundaryResponse(Enum direction)
        {
            // need position and direction
            AllCollisionResponse.Knockback(direction);
        }

        /*
         * 
         */
        public static void DamageResponse(Enum direction)
        {
            // need position and direction
            AllCollisionResponse.Knockback(direction);
            AllCollisionResponse.ApplyDamage();

        }
        #endregion
    }
}
