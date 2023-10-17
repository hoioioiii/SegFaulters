using System;
using Microsoft.Xna.Framework;
using Project1.Collision;
using static Project1.Constants;

namespace Project1.Collision_Response
{
    internal class PlayerCollisionResponse
    {
        

        #region Collision Responses
        /*
         * Pass in item
         * Call item to remove it from the room either
         * 
         * Place it in Link's inventory or
         * Change a value (like health)
         * The last part will be done by the item entity class
         */
        public static void ItemResponse(IItem item)
        {

        }

        /*
         * Pass 
         */
        public static void DoorResponse(IDoor door)
        {

        }

        /*
         * 
         */
        public static void BoundaryResponse(Player link, DIRECTION direction)
        {
            Vector2 playerPosition = new Vector2(Player.getUserPos().X, Player.getUserPos().Y); 
            AllCollisionResponse.Knockback(playerPosition, direction, Player.playerSpeed);
        }

        /*
         * 
         */
        public static void DamageResponse(Player link, DIRECTION direction)
        {
            Vector2 playerPosition = new Vector2(Player.getUserPos().X, Player.getUserPos().Y);
            // Constant knockbackDistance
            AllCollisionResponse.Knockback(playerPosition, direction, knockbackDistance);
            AllCollisionResponse.ApplyDamage();

        }
        #endregion
    }
}
