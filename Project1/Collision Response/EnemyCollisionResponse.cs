using System;
using Microsoft.Xna.Framework;
using Project1.Collision;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class EnemyCollisionResponse
    {
        /*
         * 
         */
        public static void BoundaryResponse(IEntity enemy, DIRECTION direction)
        {           
            Vector2 enemyPosition = new Vector2(enemy.getPositionAndRectangle().X, enemy.getPositionAndRectangle().Y);
            enemyPosition = AllCollisionResponse.Knockback(enemyPosition, direction, ENEMY_SPEED);
            enemy.setPosition((int)enemyPosition.X, (int)enemyPosition.Y);
        }

        /*
         * 
         */
        public static void DamageResponse(IEntity enemy, DIRECTION direction)
        {
            Vector2 enemyPosition = new Vector2(enemy.getPositionAndRectangle().X, enemy.getPositionAndRectangle().Y);
            enemyPosition = AllCollisionResponse.Knockback(enemyPosition, direction, KNOCKBACK_DISTANCE);
            enemy.setPosition((int)enemyPosition.X, (int)enemyPosition.Y);
            AllCollisionResponse.ApplyDamage();
        }       
    }
}
