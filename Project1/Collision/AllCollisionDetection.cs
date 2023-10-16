using Microsoft.Xna.Framework;
using System;
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
         * Additional optimizations might be helpful (like a quadtree)
         */

        // player and enemy rects, the latter is a list
        // TODO: refactor into entity
        //List<IEnemy> enemyRects = new List<IEnemy>();
        List<Rectangle> enemyRects = new List<Rectangle>();

        // player rect
        // TODO: refactor to include interface
        //Player link;

        #region Collision rectangles
        // TODO: ROOM MANAGER MUST GENERATE THESE LISTS ON NEW ROOM LOAD TO PASS INTO COLLISION
        /*
         * List of rectangles for collision boxes for Link
         * Includes: Items, doors, boundaries, enemies, and non-Link damagers (attacks and enemies without health)
         */
        List<Rectangle> roomCollisionRectsForLink = new List<Rectangle>();

        /*
         * List of rectangles for collision boxes for enemies
         * Includes: Boundaries and Link's weapons 
         */
        List<Rectangle> roomCollisionRectsForEnemies = new List<Rectangle>();
        #endregion

        #region Collision Detection (player & room enemies)
        public void DetectAllCollisionsLink(CollisionType collisionType, Rectangle link)
        {
            // pass in list of axis-alligned bounding rectangles

            bool isColliding = false;

            /*
             * additional directional collision information required for enemies, attacks and boundaries
             */

            foreach (var roomRect in roomCollisionRectsForLink)
            {
                // check if player/enemy intersects a room rectangle
                isColliding = link.Intersects(roomRect);
                    
                // if yes
                if (isColliding)
                {
                    // if the CollisionType is damage or boundary, directional collision check required
                    Enum collisionDirection = DIRECTION.left;

                    switch (collisionType)
                    {
                        case CollisionType.ITEM:
                            // TODO: change to entity
                            AllCollisionResponse.ItemResponse();
                            break;
                        case CollisionType.DOOR:
                            // TODO: get correct door transition
                            AllCollisionResponse.DoorResponse();
                            break;
                        case CollisionType.BOUNDARY:                          
                            DetectCollisionDirection(link, roomRect, collisionDirection);
                            // TODO: Pass in player entity
                            AllCollisionResponse.BoundaryResponse(collisionDirection);
                            break;
                        case CollisionType.DAMAGE:
                            DetectCollisionDirection(link, roomRect, collisionDirection);
                            // TODO: Pass in player entity
                            AllCollisionResponse.DamageResponse(collisionDirection);
                            break;                           
                    }
                }

                /*
                * only one collision per frame 
                * if object detects a collision, no more collisions allowed for that frame
                * might be worth removing
                */
                //if (isColliding) { break; }
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
                foreach (var roomRect in roomCollisionRectsForEnemies)
                {
                    // check if player/enemy intersects a room rectangle
                    isColliding = enemy.Intersects(roomRect);

                    // if yes
                    if (isColliding)
                    {
                        Enum collisionDirection = DIRECTION.left;
                        switch (collisionType)
                        {
                            case CollisionType.BOUNDARY:
                                DetectCollisionDirection(enemy, roomRect, collisionDirection);
                                // TODO: Pass in enemy entity
                                AllCollisionResponse.BoundaryResponse(collisionDirection);
                                break;
                            case CollisionType.DAMAGE:
                                DetectCollisionDirection(enemy, roomRect, collisionDirection);
                                // TODO: Pass in enemy entity
                                AllCollisionResponse.DamageResponse(collisionDirection);
                                break;
                        }
                    }

                    /*
                     * only one collision per frame 
                     * if object detects a collision, no more collisions allowed for that frame
                     * might be worth removing
                     */
                    //if (isColliding) { break; }
                }

            }
        }
        #endregion

        /*
         * Change collisionDirection enum to correct direction
         * Detect collision (Rectangle intersect test)
         * Determine whether distance between the rectangles is positive or negative
         * Get overlap rect
         * If overlap rect's width > height, it's a top/bottom collision, otherwise left/right
         * Use positive or negative direction to determine which side
         */
        void DetectCollisionDirection(Rectangle targetRect, Rectangle roomRect, Enum collisionDirection)
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
                    collisionDirection = DIRECTION.down;
                } 
                else
                {
                    // top collision
                    collisionDirection = DIRECTION.up;
                }
            }
            else
            {
                // left right collision
                if (positiveDirection)
                {
                    // left collision
                    collisionDirection = DIRECTION.left;
                }
                else
                {
                    // right collision
                    collisionDirection = DIRECTION.right;
                }
            }
        }
    }
}
