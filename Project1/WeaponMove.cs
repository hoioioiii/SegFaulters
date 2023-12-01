using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1
{
    public class WeaponMove : IMove
    {
        private int pos_x;
        private int pos_y;

        public WeaponMove(int x, int y) { 
   
            this.pos_x = x;
            this.pos_y = y;
        }


        public (int, int) getPosition()
        {
           return (pos_x, pos_y);
        }

        public Vector2 getVector()
        {
            return new Vector2(pos_x, pos_y);
        }
        public void setPosition(int x, int y)
        {
                this.pos_y = y;
                this.pos_x = x;
        }



        //not needed
        public void HorizontalMovement(Constants.Direction start_direction)
        {
            throw new NotImplementedException();
        }


        //not needed
        public void LeftAndRight()
        {
            throw new NotImplementedException();
        }

        //Not needed
        public void SmartAIDetectionFieldMovement()
        {
            throw new NotImplementedException();
        }

        //Not needed
        public void WanderMove()
        {
            throw new NotImplementedException();
        }

        //not needed
        public void circularMovement(Constants.Direction start_direction)
        {
            throw new NotImplementedException();
        }
    }
}
