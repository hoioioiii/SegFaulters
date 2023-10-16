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
         * 
         */
        public static void ItemResponse()
        {

        }

        /*
         * 
         */
        public static void DoorResponse()
        {

        }

        /*
         * 
         */
        public static void BoundaryResponse(Enum DIRECTION)
        {
            // need position and direction
            Knockback();
        }

        /*
         * 
         */
        public static void DamageResponse(Enum DIRECTION)
        {
            // need position and direction
            Knockback();
            ApplyDamage();

        }
        #endregion


        #region Collision Response action methods
        /* Knock back target (player or enemy)
         * TODO: need position and direction
         * what should be the knock back duration and speed?
         */
        static void Knockback()
        {
            
        }

        /*
         * Lower health variable of Link or enemy
         * Apply temporary invincibility so the entity can't take every frame
         */
        static void ApplyDamage()
        {

        }

        #endregion
    }
}
