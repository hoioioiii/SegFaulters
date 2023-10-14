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
        /*
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
        public void ItemResponse()
        {

        }

        public void DoorResponse()
        {

        }

        public void BoundaryResponse()
        {
            // need position and direction
            Knockback();
        }

        public void DamageResponse(Rectangle target)
        {
            // need position and direction
            Knockback();
            ApplyDamage();
        }
        #endregion


        #region Collision Response action methods
        // Knock back target (player or enemy)
        // need position and direction
        // knock back duration, 1 second?
        void Knockback()
        {
            
        }

        void ApplyDamage()
        {

        }

        #endregion
    }
}
