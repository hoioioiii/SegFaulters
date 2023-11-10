using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    internal class WeaponDirectionMovement
    {
        //may delete this class later
        //NEED TO FIX WEAPON-DIRECT-MOVEMENT to reflect new linkdirection variable
        //went from 1-4 to 0-3 for linkDirection variable

        public static int FourDirMove(int pos, int direction, int modifer)
        {
            //takes care of horizontal

            //Up and Down
            if (direction % 2 == 0)
            {
                pos = moveY(pos, direction, modifer);
            }
            else 
            {
                pos = moveX(pos, direction, modifer);
                
            }

            return pos;
        }

        public static int moveY(int pos, int direction, int modifer)
        {

            //moving down: 3
            if (direction == 2)
            {

                pos += 1 * modifer;
            }
            else if(direction == 0)//moving up
            {

                pos -= 1 * modifer;
            }
            return pos;
        }
        public static int ForwardBack(int pos, int direction, int mod)
        {
            if (direction == 0 || direction == 3)
            {

                pos -= 1 * mod;

            }
            else if (direction == 1 || direction == 2)
            {
                pos += 1 * mod;
            }
            return pos;

        }

        public static int moveX(int pos, int direction,int modifer)
        {

            //moving left
            if (direction == 3)
            {

                pos += -1 * modifer ;
            }
            else if (direction == 1)//moving right
            {
                pos += 1 * modifer;

            }

            return pos;

        }

        public static int FollowXPlayer(int x, int user)
        {

            int diff = (user - x);

            if(diff < 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public static int FollowYPlayer(int y, int user)
        {

            int diff = (user - y);

            if (diff <= 0)
            {
                y -= 1;
            }
            else
            {
                y += 1;
            }


            return y;
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

        public static (int,int) SwordOffSetX(int x, int y,int direction)
        {
            
            //up and down
            switch (direction)
            {
                //0 is right

                //1 is left

                //2 is up

                //3 is down
                case 0:
                    x += WEAPON_OFFSET_X;
                    y -= WEAPON_OFFSET_Y;
                    break;
                case 1:
                    x += WEAPON_OFFSET_Y;
                    y += WEAPON_OFFSET_X;
                    break;
                case 2:
                    x += WEAPON_OFFSET_X;
                    y += WEAPON_OFFSET_Y;
                    break;
                case 3:
                    x -= WEAPON_OFFSET_Y;
                    y += WEAPON_OFFSET_X;
                    break;
            }
            return (x,y);
        }

        public static int SwordOffSetY(int pos, int direction)
        {
            //vibe

            return pos;
        }

        public static bool CheckBoundary(int pos, int upperBound, int lowerBound)
        {
            if ((pos >= upperBound) || (pos <= lowerBound))
            {
                return true;
            }
            return false;
        }




    }
}
