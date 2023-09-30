using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Movement
    {

        public static int MoveUp(int y)
        {
            return y -=1;
        }

        public static int MoveDown(int y)
        {
            return y += 1;
        }

        public static int MoveLeft(int x)
        {
            return x -= 1;
        }

        public static int MoveRight(int x)
        {
            return x += 1;
        }

        public static int CheckBounds(int addPos, int currPos, int UpperBound, int LowerBound)
        {

            if ((addPos + currPos) >= UpperBound)
            {

                return 0;
            }
            else
            {
                return addPos;
            }

        }

    }
}
