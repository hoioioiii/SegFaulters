using System;
using System.Collections.Generic;
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
    }
}
