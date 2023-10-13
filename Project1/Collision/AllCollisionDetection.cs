using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Project1.Constants;

namespace Project1.Collision
{
    internal class AllCollisionDetection
    {
        /*
         * Detect every object the player could be colliding with
         * For each player, detect if colliding with list of colliders
         * Walls, doors, enemies, items, etc.
         * Knock player back if collision is a wall or enemy (calculated in DirectionalCollsionDetection.cs, handled in collision response class)
         * Additional optimizations needed (like a quadtree)
         */
        
        // player and enemy rects
        //list
        List<Rectangle> targetRects = new List<Rectangle>();

        // for each rect
        //Rectangle targetRect;


        // List of rectangles for collision boxes (not player/enemy)
        List<Rectangle> roomRects = new List<Rectangle>();

        // for each rect
        //Rectangle roomRect;

        public void DetectAllCollisions()
        {
            // pass in list of axis-alligned bounding rectangles

            bool isColliding = false;

            /*
             * additional directional collision information required enemies, attacks and boundaries
             */
            foreach (var target in targetRects)
            {
                foreach (var roomRect in roomRects)
                {
                    // check if player/enemy intersects a room rectangle
                    isColliding = target.Intersects(roomRect);
                    

                    // if yes
                    if (isColliding)
                    {
                        // if the CollisionType is damage or boundary, directional collision check required
                        if (target.CollisionType.DAMAGE || target.CollisionType.BOUNDARY)
                        {
                            DetectCollisionDirection(target, roomRect);

                            //sendToCollisionRespose
                        }
                        else if (target.CollisionType.ITEM)
                        {
                            //sendToCollisionRespose
                        }
                        else
                        {
                            // is door
                            //sendToCollisionRespose
                        }
                    }

                   /*
                    * only one collision per frame 
                    * if object detects a collision, no more collisions allowed for that frame
                    */
                    if (isColliding) { break; }
                }
                
                if (isColliding) { break; }
            }
        }

        /*
         * Detect collision (Rectangle intersect test)
         * if collision is true and object is a wall or enemy, call DetectCollisionDirection()
         */
        void DetectCollisionDirection(Rectangle targetRect, Rectangle roomRect)
        {
            Rectangle overlap = new Rectangle();
            bool positiveDirection = true;

            positiveDirection = Vector2.Distance(new Vector2(targetRect.Center.X, targetRect.Center.Y), new Vector2(roomRect.Center.X, roomRect.Center.Y)) > 0;

            Intersect(targetRect, roomRect, overlap);
         
            if (overlap.Width > overlap.Height)
            {
                // top/bottom collision
                if (positiveDirection)
                {
                    // bottom collision

                } 
                else
                {
                    // top collision

                }
            }
            else
            {
                // left right collision
                if (positiveDirection)
                {
                    // left collision

                }
                else
                {
                    // right collision

                }
            }

        }
    }
}
