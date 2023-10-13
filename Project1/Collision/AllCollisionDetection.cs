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
        List<Rectangle> enemyRects = new List<Rectangle>();

        // player rect
        Rectangle linkRect;


        // List of rectangles for collision boxes (not player/enemy)
        List<Rectangle> roomRects = new List<Rectangle>();


        #region Collision Detection (player & room enemies)
        public void DetectAllCollisionsLink(CollisionType collisionType, Rectangle link)
        {
            // pass in list of axis-alligned bounding rectangles

            bool isColliding = false;

            /*
             * additional directional collision information required for enemies, attacks and boundaries
             */
            
            foreach (var roomRect in roomRects)
            {
                // check if player/enemy intersects a room rectangle
                isColliding = link.Intersects(roomRect);
                    
                // if yes
                if (isColliding)
                {
                    // if the CollisionType is damage or boundary, directional collision check required
                    switch (collisionType)
                    {
                        case CollisionType.ITEM:
                            //sendToCollisionRespose
                            break;
                        case CollisionType.DOOR:
                            //sendToCollisionRespose
                            break;
                        case CollisionType.BOUNDARY:
                            DetectCollisionDirection(link, roomRect);
                            //sendToCollisionRespose
                            break;
                        case CollisionType.DAMAGE:
                            DetectCollisionDirection(link, roomRect);
                            //sendToCollisionRespose
                            break;
                            
                    }
                }

                /*
                * only one collision per frame 
                * if object detects a collision, no more collisions allowed for that frame
                */
                if (isColliding) { break; }
            }
                            
        }

        public void DetectAllCollisionsEnemies(CollisionType collisionType)
        {
            // pass in list of axis-alligned bounding rectangles

            bool isColliding = false;

            /*
             * additional directional collision information required for enemies, attacks and boundaries
             */
            foreach (var enemy in enemyRects)
            {
                foreach (var roomRect in roomRects)
                {
                    // check if player/enemy intersects a room rectangle
                    isColliding = enemy.Intersects(roomRect);

                    // if yes
                    if (isColliding)
                    {
                        // if the CollisionType is damage or boundary, directional collision check required
                        switch (collisionType)
                        {
                            case CollisionType.BOUNDARY:
                                DetectCollisionDirection(enemy, roomRect);
                                //sendToCollisionRespose
                                break;
                            case CollisionType.DAMAGE:
                                DetectCollisionDirection(enemy, roomRect);
                                //sendToCollisionRespose
                                break;

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
        #endregion

        /*
         * Detect collision (Rectangle intersect test)
         * if collision is true and object is a wall or enemy, call DetectCollisionDirection()
         */
        void DetectCollisionDirection(Rectangle targetRect, Rectangle roomRect)
        {
            Rectangle overlap = new Rectangle();
            bool positiveDirection = true;

            positiveDirection = Vector2.Distance(new Vector2(targetRect.Center.X, targetRect.Center.Y), new Vector2(roomRect.Center.X, roomRect.Center.Y)) > 0;

            Rectangle.Intersect(ref targetRect, ref roomRect, out overlap);
         
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
