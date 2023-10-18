using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    internal class Random
    {


        //will randomize how many seconds a enemy will be moving in 1 driection before changing
        public static int RandomSeconds()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(3,7);
   
            return val;
        }

        //will randomize how many milliseconds a enemy will be moving before attacking
        public static int RandomMilli()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(100, 300);

            return val;
        }

        public static Direction RandomDirection()
        {
            System.Random rand = new System.Random();

            int val = rand.Next(1, 4);
            
            switch (val)
            {
                case 1:
                    return Direction.Up;

                case 2:
                    return Direction.Right;

                case 3:
                    return Direction.Down;
                case 4: 
                    return Direction.Left;

                default:
                    return Direction.Down;
            }
        }



        public static int CheckBounds(int addPos, int currPos, int UpperBound, int LowerBound) {
        
            if ((addPos + currPos) > UpperBound) {

                return addPos * -1;
            }
            else
            {
                return addPos;
            }
        
        }
    }
}
