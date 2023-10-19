using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class DirectionManager
    {
        //may delete this class later

        public static int FourDirMove(int pos, int direction)
        {
            //takes care of horizontal

            if (direction % 2 == 0)
            {
                pos = moveX(pos, direction);
            }
            else
            {
                pos = moveY(pos, direction);
            }

            return pos;
        }

        public static int moveY(int pos, int direction)
        {

            //moving down
            if (direction > 2)
            {

                pos += 1;
            }
            else//moving up
            {

                pos += -1;
            }
            return pos;
        }

        public static int moveX(int pos, int direction)
        {

            //moving left
            if (direction > 2)
            {

                pos += -1;
            }
            else//moving right
            {
                pos += 1;

            }

            return pos;

        }


        // 1 : up
        //2: right
        //3:down
        //4:left
        public static int OffsetX(int x, int direction)
        {
            if (direction % 2 == 0)
            {
                //moving left
                if (direction > 2)
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

        public static int DirectionOffsetX(int pos, int direction)
        {

            if (direction > 2)
            {

                int offset = -1 * 30;
                pos += offset;
            }
            else
            {
                int offset = 30;
                pos += offset;
            }

            return pos;

        }

        public static int DirectionOffsetY(int pos, int direction)
        {
            if (direction == 0)
            {
                return pos;

            }

            if (direction < 2)
            {

                int offset = -1 * 30;
                pos += offset;
            }
            else
            {
                int offset = 30;
                pos += offset;
            }

            return pos;
        }





    }
}
