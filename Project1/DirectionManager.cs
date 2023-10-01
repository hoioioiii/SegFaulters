using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class DirectionManager
    {

        // 1 : up
        //2: right
        //3:down
        //4:left
        public static int OffsetX(int x, int direction)
        {
            if (direction % 2 == 0)
            {
                //moving left
                if(direction > 2)
                {
                    int offSet = -1 * 30;
                    x += offSet;
                }
                else//moving right
                {
                    int offSet = 70;
                    x += offSet;
                }
            }
            return x;
        }

        public static int OffsetY(int y, int direction)
        {
            if (direction % 2 != 0)
            {
                //moving down
                if (direction < 2)
                {
                    int offSet = -1 * 40;
                    y += offSet;
                }
                else//moving up
                {
                    int offSet = 70;
                    y += offSet;
                }
            }
            return y;
        }






    }
}
