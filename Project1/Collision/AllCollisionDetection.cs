using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Collision_Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using static Project1.Constants;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1
{
    public class AllCollisionDetection
    {
      
        /*
         * Detect every object the player/enemies could be colliding with
         * For each player/enemy, detect if colliding with list of colliders
         * Walls, doors, enemies, items, etc.
         * Knock player back if collision is a wall or enemy (calculated in DirectionalCollsionDetection.cs, handled in collision response class)
         * Additional optimizations might be helpful (like a quadtree)
         * There could've been more optimizations here but the grader said they weren't worth implementing
         */

     
       
        private static List<IEntity> entities;
       


        #region Collision rectangles TODO: USE ENTITIES INSTEAD
        
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

        #region Collision Entity Lists
        /*
         * List of rectangles for collision boxes for Link
         * Includes: Items, doors, boundaries, enemies, and non-Link damagers (attacks and enemies without health)
         */
       
       
        private static List<IItem> roomItems;
        private static List<Door> roomDoors;
        private static List<IEnvironment> roomBoundaries;

        private static List<IWeapon> weapons;
        private static List<IWeapon> playerWeapons;

        private static List<IWeapon> detectionWeapons;

        private static List<IEntity> detectionEntities;
       
   
        #endregion

        #region Collision Detection Entities (player & room enemies & doors)
        /*
         * Detect every object the player could be colliding with
         * pass in list of axis-alligned bounding rectangles
         * Additional directional collision information required for enemies, attacks and boundaries         
         */
        private static void DetectAllCollisionsLinkEntity()
        {
            bool isColliding = false;


           
            DIRECTION collisionDirection = DIRECTION.left;

            

            foreach (var item in roomItems)
            {
                isColliding = Player.BoundingBox.Intersects(item.BoundingBox);
                if (isColliding)
                {
                    PlayerCollisionResponse.ItemResponse(item);
                }

            
                
            }
            
            foreach (Door door in roomDoors)
            {
                isColliding = Player.BoundingBox.Intersects(door.BoundingBox);
                if (isColliding)
                {
                    PlayerCollisionResponse.DoorResponse(door);
                    break;
                }
            }

            foreach (var boundary in roomBoundaries)
            {
                isColliding = Player.BoundingBox.Intersects(boundary.BoundingBox);
                if (isColliding)
                {
                    collisionDirection = DetectCollisionDirection(Player.BoundingBox, boundary.BoundingBox, collisionDirection);
                    PlayerCollisionResponse.BoundaryResponse(collisionDirection);
                }
           
            }
            foreach (var enemy in entities)
            {

                isColliding = Player.BoundingBox.Intersects(enemy.BoundingBox);
                if (isColliding)
                {
                    collisionDirection = DetectCollisionDirection(Player.BoundingBox, enemy.BoundingBox, collisionDirection);
                  

                    #region Print to debug console
                    System.Text.StringBuilder sb = new StringBuilder();
                    sb.Append("COLLISION DIRECTION: " + collisionDirection);

                    if (sb.Length > 0)
                        System.Diagnostics.Debug.WriteLine(sb.ToString());
                    #endregion

                    PlayerCollisionResponse.DamageResponse(collisionDirection,false,DAMAGE_HALF_HEART);
                }

            }

            
            foreach (var detectionEntity in detectionEntities)
            {
                
                bool isCollidingX = Player.BoundingBox.Intersects(detectionEntity.DetectionFieldX);
                bool isCollidingY = Player.BoundingBox.Intersects(detectionEntity.DetectionFieldY);
                if (isCollidingX || isCollidingY)
                {
                    Rectangle detectionBox = (isCollidingX) ? detectionEntity.DetectionFieldX : detectionEntity.DetectionFieldY;
                    collisionDirection = DetectCollisionDirection(Player.BoundingBox, detectionBox, collisionDirection);

                   
                }
                EnemyCollisionResponse.SpikeDetectionResponse(detectionEntity, isCollidingX, isCollidingY);
            }

            foreach (var enemyAttack in weapons)
            {
                isColliding = Player.BoundingBox.Intersects(enemyAttack.BoundingBox);
                if (isColliding)
                {
                    collisionDirection = DetectCollisionDirection(Player.BoundingBox, enemyAttack.BoundingBox, collisionDirection);
                    
                    PlayerCollisionResponse.DamageResponse(collisionDirection,true,0);
                }
            }


        }



        private static void DetectAllCollisionsEnemiesEntity()
        {
          

            bool isColliding = false;

            /*
             * additional directional collision information required for enemies, attacks and boundaries
             */
            foreach (var enemy in entities)
            {
                foreach (var boundary in roomBoundaries)
                {
                    isColliding = enemy.BoundingBox.Intersects(boundary.BoundingBox);
                    if (isColliding)
                    {
                        DIRECTION collisionDirection = DIRECTION.left;
                        collisionDirection = DetectCollisionDirection(enemy.BoundingBox, boundary.BoundingBox, collisionDirection);

                        EnemyCollisionResponse.BoundaryResponse(enemy, collisionDirection);
                    }
                }
                foreach (IWeapon weapon in playerWeapons)
                {
                    isColliding = enemy.BoundingBox.Intersects(weapon.BoundingBox);
                    if (isColliding)
                    {
                        DIRECTION collisionDirection = DIRECTION.left;
                        collisionDirection = DetectCollisionDirection(enemy.BoundingBox, weapon.BoundingBox, collisionDirection);

                        WeaponCollisionResponse.WeaponResponse(weapon);
                        EnemyCollisionResponse.DamageResponse(enemy, collisionDirection);
                    }
                }
            }

            foreach (IWeapon weapon in detectionWeapons)
            {
                CheckAllEntites(weapon);
            }
        }

        private static void CheckAllEntites(IWeapon weapon)
        {
           
            foreach (var enemy in entities)
            {
                bool isColliding = false;
                isColliding = enemy.BoundingBox.Intersects(weapon.getDetectionFieldRectangle());
                if (isColliding)
                {
                    DIRECTION collisionDirection = DIRECTION.left;
                    collisionDirection = DetectCollisionDirection(enemy.BoundingBox, weapon.BoundingBox, collisionDirection);
                    EnemyCollisionResponse.DetectionResponse(enemy, weapon, collisionDirection);
                }
            }
        }
        
        private static void DetectAllCollisionsDoors()
        {
            foreach (Door door in roomDoors)
            {
                foreach (IWeapon weapon in playerWeapons)
                {
                    if (weapon.ToString().Equals("Project1.Bomb") && door.BoundingBox.Intersects(weapon.BoundingBox) && door.isTunnelDoor())
                    {
                        door.UnlockDoor();
                   
                        return;
                    }
                }
            }
        }

        #endregion

        public static void DetectCollision(IActiveObjects GameOBJ)
        {
            entities = new List<IEntity>(GameOBJ.getEntityList());
            
            roomBoundaries = new List<IEnvironment>(GameOBJ.getEnvironmentList());
            weapons = new List<IWeapon>(GameOBJ.getWeaponList());
            playerWeapons = new List<IWeapon>(GameOBJ.getPlayerWeaponList());
            roomItems = new List<IItem>(GameOBJ.getItemList());
            detectionWeapons = new List<IWeapon>(GameOBJ.getDetectionWeaponsList());
            detectionEntities = new List<IEntity>(GameOBJ.getDetectionEntityList());
            roomDoors = new List<Door>(GameOBJ.getDoorList());


            DetectAllCollisionsLinkEntity();
            DetectAllCollisionsEnemiesEntity();
            DetectAllCollisionsDoors();

        }


        /*
         * Change collisionDirection enum to correct direction
         * 
         * Detect collision (Rectangle intersect test)
         * Determine whether distance between the rectangles is positive or negative
         * Get overlap rect
         * If overlap rect's width > height, it's a top/bottom collision, otherwise left/right
         * Use positive or negative direction to determine which side
         */
        private static DIRECTION DetectCollisionDirection(Rectangle targetRect, Rectangle roomRect, DIRECTION collisionDirection)
        {
            Rectangle overlap = new Rectangle();            
            Rectangle.Intersect(ref targetRect, ref roomRect, out overlap);
          
            if (overlap.Width > overlap.Height)
            {
                bool positiveDirection = targetRect.Center.Y - roomRect.Center.Y > 0;

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
                bool positiveDirection = targetRect.Center.X - roomRect.Center.X > 0;

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

            return collisionDirection;
            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("COLLISION DIRECTION: " + collisionDirection);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion
        }

        #region OUTDATED, USES RECTS NOT ENTITIES! Collision Detection (player & room enemies)
   
        private bool DetectCollisionOfType(List<object> colVars)
        {
            bool isColliding = false;
            foreach (var colVar in colVars) { }

            

            return isColliding;
        }

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
           
            }

        }

        #endregion
    }
}
