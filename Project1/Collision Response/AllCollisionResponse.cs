using Microsoft.Xna.Framework;
using System;
using System.Text;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class AllCollisionResponse
    {
      
        
        public static Vector2 Knockback(Vector2 position, DIRECTION directon, int knockbackDist)
        {
            switch (directon)
            {
                case DIRECTION.left:
                    position = position + new Vector2(knockbackDist, 0);
                    position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
                    break;
                case DIRECTION.right:
                    position = position + new Vector2(-knockbackDist, 0);
                    position.X = Math.Clamp(position.X, roomBoundsMinX, roomBoundsMaxX);
                    break;
                case DIRECTION.down:
                    position = position + new Vector2(0, knockbackDist);
                    position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
                    break;
                case DIRECTION.up:
                    position = position + new Vector2(0, -knockbackDist);
                    position.Y = Math.Clamp(position.Y, roomBoundsMinY, roomBoundsMaxY);
                    break;
            }

          

            return position;
        }

      
    }
}
