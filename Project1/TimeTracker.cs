using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class TimeTracker: ITime
    {
        //factor out into constants class
        private static int ms_per_frame_animation = 300;
        private static int weapon_screen_life_sec;


        private int elapsedTime_sec;

        private int elapsedTime_milli;

        //bool to determine if object is weapon, might factor out to a subclass later
        private bool obj_weapon;

        public TimeTracker(bool is_weapon) {

            elapsedTime_milli = 0;
            elapsedTime_sec = 0;
            obj_weapon = is_weapon;
           


        }


        private int getTimeMilli()
        {

            
            return Game1.deltaTime.ElapsedGameTime.Milliseconds; ;
        }


        private int getTimeSeconds()
        {
            return Game1.deltaTime.ElapsedGameTime.Seconds; ;
        }

        public void UpdateElaspedMilli()
        {


            elapsedTime_milli += getTimeMilli();
        }


        public void UpdateElaspedSec()
        {
            elapsedTime_sec += getTimeSeconds();
        }


        public void resetElaspedMilli()
        {
            elapsedTime_milli -= ms_per_frame_animation ;
        }


        public void resetElaspedSec()
        {
            elapsedTime_sec -= ms_per_frame_animation;
        }


        public bool checkAnimationFrameTime()
        {
           return elapsedTime_milli >= ms_per_frame_animation;
            
        }



    }
}
