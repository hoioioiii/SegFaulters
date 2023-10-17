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
        public static void BoundaryResponse(Player link, Enum direction)
        {
            // need position and direction
            AllCollisionResponse.Knockback(direction);
        }

        /*
         * 
         */
        public static void DamageResponse(Player link, Enum direction)
        {
            // need position and direction
            AllCollisionResponse.Knockback(direction);
            AllCollisionResponse.ApplyDamage();

        }
        #endregion
    }
}
