using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class WeaponDirectionMovement
    {
        //may delete this class later

        public static int FourDirMove(int pos, int direction, int modifer)
        {
            //takes care of horizontal

            if (direction % 2 == 0)
            {
                pos = moveX(pos, direction, modifer);
            }
            else
            {
                pos = moveY(pos, direction, modifer);
            }

            return pos;
        }

        public static int moveY(int pos, int direction, int modifer)
        {

            //moving down: 3
            if (direction == 3)
            {

                pos += 1;
            }
            else if(direction == 1)//moving up
            {

                pos += -1;
            }
            return pos;
        }
        public static int ForwardBack(int pos, int direction, int mod)
        {
            if (direction == 1 || direction == 4)
            {

                pos -= 1 * mod;

            }
            else if (direction == 2 || direction == 3)
            {
                pos += 1 * mod;
            }
            return pos;

        }


        public static int moveX(int pos, int direction,int modifer)
        {

            //moving left
            if (direction == 4)
            {

                pos += -1 ;
            }
            else if (direction == 2)//moving right
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
                    int offSet = -1 * 10;
                    x += offSet;
                }
                else//moving right
                {
                    int offSet = 5;
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
                    int offSet = -1 * 10;
                    y += offSet;
                }
                else//moving up
                {
                    int offSet = 40;
                    y += offSet;
                }
            }
            return y;
        }

        public static int DirectionOffsetX(int pos, int direction)
        {

            if (direction > 2)
            {

                int offset = -1 * 10;
                pos += offset;
            }
            else
            {
                int offset = 10;
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

                int offset = -1 * 10;
                pos += offset;
            }
            else
            {
                int offset = 10;
                pos += offset;
            }

            return pos;
        }





    }
}
