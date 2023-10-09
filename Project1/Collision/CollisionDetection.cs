using Microsoft.Xna.Framework;

namespace Project1.Collision
{
    internal class CollisionDetection
    {
        /*
         * Detect every object the player could be colliding with
         * For each player, detect if colliding with list of colliders
         * Walls, doors, enemies, items, etc.
         * Knock player back if collision is a wall or enemy (handled in collision response class)
         * Additional optimizations needed
         */
        Rectangle playerRect;

        // List of rectangles for collision boxes
        Rectangle rect;

        public void Update(GameTime gameTime)
        {

        }

        #region Collision Detection
        /*
         * Detect collision
         * if collision is true and object is a wall or enemy, call DetectCollisionDirection()
         */
        bool DetectCollision()
        {
            bool isColliding = false;

            isColliding = playerRect.Intersects(rect);

            return isColliding;
        }

        /*
         * If a rectangle intersection is detected 
         * and if collision is true and object is a wall or enemy,
         * 
         */
        int DetectCollisionDirection()
        {
            // The directions are:
            int direction = 0;

            return direction;
        }
        #endregion

        #region Rectangle intersect test

        #endregion

        #region More Accurate Rectangle intersect test
        // Rectangle intersect test
        bool IsTouchingLeft()
        {
            bool isTouchingLeft = false;

            //isTouchingLeft = this.rect.Left

            return isTouchingLeft;
        }
        bool IsTouchingRight()
        {
            bool isTouchingRight = false;

            //isTouching = this.rect.Right

            return isTouchingRight;
        }
        bool IsTouchingTop()
        {
            bool isTouchingTop = false;

            //isTouchingTop = this.rect.Top

            return isTouchingTop;
        }
        bool IsTouchingBottom()
        {
            bool isTouchingBottom = false;

            //isTouchingBottom = this.rect.Bottom

            return isTouchingBottom;
        }
        #endregion
    }
}
