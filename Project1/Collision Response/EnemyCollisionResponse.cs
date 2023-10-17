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
        public static void BoundaryResponse(IEnemy enemy, DIRECTION direction)
        {
            // TODO: CHANGE TO ENEMY POSITION!
            Vector2 enemyPosition = new Vector2(0 ,0);
            AllCollisionResponse.Knockback(enemyPosition, direction, knockbackDistance);
        }

        /*
         * 
         */
        public static void DamageResponse(IEnemy enemy, DIRECTION direction)
        {
            // TODO: CHANGE TO ENEMY POSITION!
            Vector2 enemyPosition = new Vector2(0, 0);
            AllCollisionResponse.Knockback(enemyPosition, direction, knockbackDistance);
            AllCollisionResponse.ApplyDamage();

        }
        #endregion
    }
}
