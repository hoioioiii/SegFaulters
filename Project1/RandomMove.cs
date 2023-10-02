using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class RandomMove
    {

        public static int RandMove()
        {
            
            Random rand = new Random();
            int val = rand.Next(-1,2);
   
            return val;
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
