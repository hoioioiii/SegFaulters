using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class AllCollisionResponse
    {
        /*
         * Handles all types of collisions
         * Send the collision type to be handled by the appropriate collision response class
         */

        

        Player Link;
        /*
        // Not needed because AllCollisionDetection.cs already knows the collision type, it can just call the methods directly
        public void CollisionT(CollisionType myColType)
        {
            
            //CollisionType myColType = CollisionType.BOUNDARY;
            switch(myColType)
            {
               case CollisionType.BOUNDARY:

                    break;
                case CollisionType.ITEM:
                    
                    break;
                case CollisionType.DOOR:
                    
                    break;
                case CollisionType.DAMAGE:
                   
                    break;
                default:
                    break;
            }
        }
        */

        #region Collision Responses
        /*
         * Pass in item
         * Call item to remove it from the room either
         * 
         * Place it in Link's inventory or
         * Change a value (like health)
         * The last part will be done by the item entity class
         */
        public static void ItemResponse()
        {

        }

        /*
         * Pass 
         */
        public static void DoorResponse()
        {

        }

        /*
         * 
         */
        public static void BoundaryResponse(Enum direction)
        {
            // need position and direction
            Knockback(direction);
        }

        /*
         * 
         */
        public static void DamageResponse(Enum direction)
        {
            // need position and direction
            Knockback(direction);
            ApplyDamage();

        }
        #endregion


        #region Collision Response action methods
        /* Knock back target (player or enemy)
         * Offset from current entity position
         * 
         * TODO: need position and direction
         * what should be the knock back duration and speed?
         */
        static void Knockback(Enum DIRECTION)
        {
            
        }

        /*
         * Lower health variable of Link or enemy
         * Apply temporary invincibility so the entity can't take every frame
         * Are there different damage amounts from different damage sources?
         */
        static void ApplyDamage()
        {
             
        }

        #endregion
    }
}
