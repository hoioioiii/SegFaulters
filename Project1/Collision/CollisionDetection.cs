using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project1.Collision
{
    internal class CollisionDetection
    {
        public Rectangle rect;
        
        public void Update(GameTime gameTime) 
        { 
            
        }

        #region Collision Detection
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
