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
            int val = rand.Next(RANDOM_SECONDS_MIN, RANDOM_SECONDS_MAX);
   
            return val;
        }
        public static int RandomBeeSPD()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_BEE_SPD_MIN, RANDOM_BEE_SPD_MAX);

            return val;
        }
        public static int RandomEntitySPDPositiveOnly()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_SPD_POS_MIN, RANDOM_SPD_POS_MAX);

            return val;
        }

        public static int RandomLower()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_LOWER_MIN, RANDOM_LOWER_MAX);

            return val;
        }

        public static int RandomUpper()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_UPPER_MIN, RANDOM_UPPER_MAX);

            return val;
        }

        private static int RandomRandom()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RandomLower(), RandomUpper());

            return val;
        }



        //will randomize how many milliseconds a enemy will be moving before attacking
        public static int RandomMilli()
        {
            System.Random rand = new System.Random();

            int lower = RandomRandom();
            int upper = RandomRandom();
            while(lower > upper)
            {
                lower = RandomRandom();
                upper = RandomRandom();

            }
            
            int val = rand.Next(lower,upper );

            return val;
        }

        public static int RandomOriginOffset()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_ORIGIN_OFFSET_MIN, RANDOM_ORIGIN_OFFSET_MAX);

            return val;
        }

        public static int RandomRadius()
        {
            System.Random rand = new System.Random();
            int val = rand.Next(RANDOM_RADIUS_MIN, RANDOM_RADIUS_MAX);

            return val;
        }

        public static Direction RandomDirection()
        {
            System.Random rand = new System.Random();

            int val = rand.Next(RANDOM_DIRECTION_MIN, RANDOM_DIRECTION_MAX);
            
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
