using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Collision_Response;
using Project1.Weapons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using static Project1.Constants;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1
{
    public class AllCollisionDetection
    {
        // TODO: IMPLEMENT BOUNDING BOXES FOR INTERFACES AND CLASSES INHERTING THEM

        /*
         * Detect every object the player/enemies could be colliding with
         * For each player/enemy, detect if colliding with list of colliders
         * Walls, doors, enemies, items, etc.
         * Knock player back if collision is a wall or enemy (calculated in DirectionalCollsionDetection.cs, handled in collision response class)
         * Additional optimizations might be helpful (like a quadtree)
         */

        // player and enemy rects, the latter is a list
        //List<IEntity> entities = new List<IEntity>();
        private static List<IEntity> entities;
        //List<Rectangle> entities = new List<Rectangle>();

        //private static Player link;


        #region Collision rectangles TODO: USE ENTITIES INSTEAD
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

        #region Collision Entity Lists
        /*
         * List of rectangles for collision boxes for Link
         * Includes: Items, doors, boundaries, enemies, and non-Link damagers (attacks and enemies without health)
         */
        //List<IItem> roomItems = new List<IItem>();
        //List<IDoor> roomDoors = new List<IDoor>();
        //List<IEnvironment> roomBoundaries = new List<IEnvironment>();


        ////TODO: change to interface
        //List<Rectangle> enemyAttackInstances = new List<Rectangle>();
       
        private static List<IItem> roomItems;
        private static List<IEnvironment> roomDoors;
        private static List<IEnvironment> roomBoundaries;

        private static List<IWeapon> weapons;
        ////TODO: change to interface
        /*
         * List of rectangles for collision boxes for enemies
         * Includes: Boundaries and Link's weapons 
         * 
         * TODO: Differentiate between whether weapons belong to Link or an enemy
         */
        List<IWeaponMelee> weaponMelees = new List<IWeaponMelee>();
        //List<IWeaponProjectile> weaponProjectiles = new List<IWeaponProjectile>();
        #endregion

        int rect1Pos;

        public static void CollisionTestInitialize(Player link)
        {
            

            
        }

        public static void CollisionTestUpdate()
        {
            
            
            Rectangle rect1 = new Rectangle(50, 50, 50, 50);
            Rectangle rect2 = new Rectangle(99, 99, 99, 99);
            System.Console.WriteLine("New Rectangle: {0}", rect1);
            System.Console.WriteLine("New Rectangle: {0}", rect2);



            bool isColliding = false;

            isColliding = rect1.Intersects(rect2);
            if (isColliding)
            {
                System.Console.WriteLine("Colliding New Rectangle");
            }
        }

        public static void DrawCollisionTest(SpriteBatch spriteBatch) {
            // Draw the big black rectangle
            //spriteBatch.Draw(pixel, rect1, Color.Black);

            // Draw the small rectangle that changes color on collision
            //spriteBatch.Draw(pixel, rect2, smallRectangleColor);
        }

        #region Collision Detection Entities (player & room enemies)
        /*
         * Detect every object the player could be colliding with
         * pass in list of axis-alligned bounding rectangles
         * Additional directional collision information required for enemies, attacks and boundaries         
         */
        private static void DetectAllCollisionsLinkEntity()
        {
            bool isColliding = false;


            // check if player intersects a room rectangle
                
            // if the CollisionType is damage or boundary, directional collision check required
            
            DIRECTION collisionDirection = DIRECTION.left;

            

            foreach (var item in roomItems)
            {
                isColliding = Player.BoundingBox.Intersects(item.BoundingBox);
                if (isColliding)
                {
                    PlayerCollisionResponse.ItemResponse(item);
                }
                /*
                #region Print to debug console
                System.Text.StringBuilder sb = new StringBuilder();
                sb.Append("isColliding: " + isColliding);

                if (sb.Length > 0)
                    System.Diagnostics.Debug.WriteLine(sb.ToString());
                #endregion
                */
            }
            
            foreach (var door in roomDoors)
            {
                isColliding = Player.BoundingBox.Intersects(door.BoundingBox);
                if (isColliding)
                {
                    PlayerCollisionResponse.DoorResponse(door);
                }               
            }
            
            foreach (var boundary in roomBoundaries)
            {
                isColliding = Player.BoundingBox.Intersects(boundary.BoundingBox);
                if (isColliding)
                {
                    DetectCollisionDirection(Player.BoundingBox, boundary.BoundingBox, collisionDirection);
                    PlayerCollisionResponse.BoundaryResponse(collisionDirection);
                }
                /*
                #region Print to debug console
                System.Text.StringBuilder sb = new StringBuilder();
                sb.Append("isColliding: " + isColliding);

                if (sb.Length > 0)
                    System.Diagnostics.Debug.WriteLine(sb.ToString());
                #endregion
                */
            }
            foreach (var enemy in entities)
            {
                
                isColliding = Player.BoundingBox.Intersects(enemy.BoundingBox);
                if (isColliding)
                {
                    DetectCollisionDirection(Player.BoundingBox, enemy.BoundingBox, collisionDirection);
                    PlayerCollisionResponse.DamageResponse(collisionDirection);
                }
                #region Print to debug console
                System.Text.StringBuilder sb = new StringBuilder();
                sb.Append("isColliding: " + isColliding);

                if (sb.Length > 0)
                    System.Diagnostics.Debug.WriteLine(sb.ToString());
                #endregion
            }
            //foreach (var enemyAttack in enemyAttackInstances)
            //{
            //    isColliding = link.BoundingBox.Intersects(enemyAttack);
            //    if (isColliding)
            //    {
            //        DetectCollisionDirection(link.BoundingBox, enemyAttack, collisionDirection);
            //        PlayerCollisionResponse.DamageResponse(link, collisionDirection);
            //    }
            //}


            /*
            * only one collision per frame 
            * if object detects a collision, no more collisions allowed for that frame
            * might be worth removing
            */
            //if (isColliding) { break; }
        }

        

        private static void DetectAllCollisionsEnemiesEntity()
        {
            // pass in list of axis-alligned bounding rectangles

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
                        DetectCollisionDirection(enemy.BoundingBox, boundary.BoundingBox, collisionDirection);

                        EnemyCollisionResponse.BoundaryResponse(enemy, collisionDirection);
                    }
                }
                foreach (IWeapon weapon in weapons)
                {
                    isColliding = enemy.BoundingBox.Intersects(weapon.BoundingBox);
                    if (isColliding)
                    {
                        DIRECTION collisionDirection = DIRECTION.left;
                        DetectCollisionDirection(enemy.BoundingBox, weapon.BoundingBox, collisionDirection);

                        EnemyCollisionResponse.DamageResponse(enemy, collisionDirection);
                    }
                }
                //foreach (var weaponProjectile in weaponProjectiles)
                //{
                //    isColliding = enemy.BoundingBox.Intersects(weaponProjectile.BoundingBox);
                //    if (isColliding)
                //    {
                //        DIRECTION collisionDirection = DIRECTION.left;
                //        DetectCollisionDirection(enemy.BoundingBox, weaponProjectile.BoundingBox, collisionDirection);

                //        EnemyCollisionResponse.DamageResponse(enemy, collisionDirection);
                //    }
                //}
            }
        }
        #endregion

        public static void DetectCollision(IActiveObjects GameOBJ)
        {
            entities = GameOBJ.getEntityList();
            //link = GameOBJ.getLink();
            //Game1.Player();
            roomBoundaries = GameOBJ.getEnvironmentList();
            weapons = GameOBJ.getWeaponList();
            roomItems = GameOBJ.getItemList();

            roomDoors = GameOBJ.getDoorList();
            DetectAllCollisionsLinkEntity();
            DetectAllCollisionsEnemiesEntity();
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
        private static void DetectCollisionDirection(Rectangle targetRect, Rectangle roomRect, Enum collisionDirection)
        {
            #region Print to debug console
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("DIRECTIONAL COLLISION");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion

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
            #region Print to debug console
            //System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("COLLISION DIRECTION: " + collisionDirection);

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            #endregion
        }

        #region OUTDATED, USES RECTS NOT ENTITIES! Collision Detection (player & room enemies)
        /*
         * How to make this method that can take in and use lists with different interfaces? Is it even possible?
         * See if it's possible to refactor this code into the class for next sprint.
         */
        private bool DetectCollisionOfType(List<object> colVars)
        {
            bool isColliding = false;
            foreach (var colVar in colVars) { }

            //isColliding = link.BoundingBox.Intersects(new Rectangle);

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
                /*
                // if yes
                if (isColliding)
                {
                    // if the CollisionType is damage or boundary, directional collision check required
                    Enum collisionDirection = DIRECTION.left;

                    switch (collisionType)
                    {
                        case CollisionType.ITEM:
                            // TODO: change to entity
                            PlayerCollisionResponse.ItemResponse();
                            break;
                        case CollisionType.DOOR:
                            // TODO: get correct door transition
                            PlayerCollisionResponse.DoorResponse();
                            break;
                        case CollisionType.BOUNDARY:
                            DetectCollisionDirection(link, roomRect, collisionDirection);
                            // TODO: Pass in player entity
                            PlayerCollisionResponse.BoundaryResponse(collisionDirection);
                            break;
                        case CollisionType.DAMAGE:
                            DetectCollisionDirection(link, roomRect, collisionDirection);
                            // TODO: Pass in player entity
                            PlayerCollisionResponse.DamageResponse(collisionDirection);
                            break;
                    }
                }
                */
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

            //bool isColliding = false;

            /*
             * additional directional collision information required for enemies, attacks and boundaries
             */
            //foreach (var enemy in entities)
            {
                //foreach (var roomRect in roomCollisionRectsForEnemies)
                {
                    /*
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
                                EnemyCollisionResponse.BoundaryResponse(collisionDirection);
                                break;
                            case CollisionType.DAMAGE:
                                DetectCollisionDirection(enemy, roomRect, collisionDirection);
                                // TODO: Pass in enemy entity
                                EnemyCollisionResponse.DamageResponse(collisionDirection);
                                break;
                        }
                    }
                    */
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
    }
}
