using System;
using Microsoft.Xna.Framework;
using Project1.Collision;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class EnemyCollisionResponse
    {
        /*
         * For boundary collision, can't move past/through
         */
        public static void BoundaryResponse(IEntity enemy, DIRECTION direction)
        {           
            Vector2 enemyPosition = new Vector2(enemy.GetPositionAndRectangle().X, enemy.GetPositionAndRectangle().Y);
            enemyPosition = AllCollisionResponse.Knockback(enemyPosition, direction, ENEMY_SPEED);
            enemy.ChangeDirections();
            enemy.setPosition((int)enemyPosition.X, (int)enemyPosition.Y);
        }

        /*
         * Enemy collision, significant knockback & damage & temporary invincibility
         */
        public static void DamageResponse(IEntity enemy, DIRECTION direction)
        {
            Vector2 enemyPosition = new Vector2(enemy.GetPositionAndRectangle().X, enemy.GetPositionAndRectangle().Y);
            enemyPosition = AllCollisionResponse.Knockback(enemyPosition, direction, KNOCKBACK_DISTANCE);
            enemy.setPosition((int)enemyPosition.X, (int)enemyPosition.Y);
            enemy.TakeDamage(Player.stats[ATTACK] + Player.weaponAttackAmount);
        }
    }
}
