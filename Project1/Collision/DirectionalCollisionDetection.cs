using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Collision
{
    internal class DirectionalCollisionDetection
    {

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

        #region Directional Rectangle intersect test
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
