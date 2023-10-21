using System;
using Microsoft.Xna.Framework;
using Project1.Collision;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class PlayerCollisionResponse
    {
        /*
         * Pass in item
         * Call item to remove it from the room or
         * call room manager to do it (which one should?)
         * 
         * Place it in Link's inventory or
         * Change a value (like health)
         * The last part will be done by the item entity class
         */
        public static void ItemResponse(IItem item)
        {
            // TODO: CALL ITEM INSTANCE/ROOM MANAGER
        }

        /*
         * Pass in door
         * Send to level loader which door it was
         */
        public static void DoorResponse(IEnvironment door)
        {
            // TODO: CALL LEVEL LOADER
        }

        /*
         * 
         */
        public static void BoundaryResponse(Player link, DIRECTION direction)
        {
            Vector2 playerPosition = new Vector2(Player.getUserPos().X, Player.getUserPos().Y);
            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, Player.playerSpeed);
            link.setPosition((int)playerPosition.X, (int)playerPosition.Y);
        }

        /*
         * 
         */
        public static void DamageResponse(Player link, DIRECTION direction)
        {
            Vector2 playerPosition = new Vector2(Player.getUserPos().X, Player.getUserPos().Y);
            // Constant KNOCKBACK_DISTANCE
            playerPosition = AllCollisionResponse.Knockback(playerPosition, direction, KNOCKBACK_DISTANCE);
            AllCollisionResponse.ApplyDamage();
            link.setPosition((int)playerPosition.X, (int)playerPosition.Y);
        }       
    }
}
