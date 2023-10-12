using Microsoft.Xna.Framework;

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
        Rectangle targetRects;

        // List of rectangles for collision boxes
        Rectangle staticRects;

        public void Update(GameTime gameTime)
        {
            // pass in list of axis-alligned bounding rectangles
            bool isColliding = false;
            isColliding = DetectCollision(isColliding);
            /*
             * additional directional collision information required enemies, attacks and boundaries
             */
            /*
            if (enemy || boundary)
            {

            }
            */
        }

        /*
         * Detect collision (Rectangle intersect test)
         * if collision is true and object is a wall or enemy, call DetectCollisionDirection()
         */
        bool DetectCollision(bool isColliding)
        {

            isColliding = targetRects.Intersects(staticRects);

            return isColliding;
        }

        void boundaryOrDamageCheck()
        {

        }

        void sendToCollisionRespose()
        {

        }
    }
}
