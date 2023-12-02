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
        private int movement_timeframe_sec;
        private int elapsed_move__sec;
        private int elapsedTime_milli;
        private int attackDuration;
        private int attackPerMovement;
        private bool stopMoveTime;

        //bool to determine if object is weapon, might factor out to a subclass later
        private bool obj_weapon;

        public TimeTracker(bool is_weapon) {

            elapsedTime_milli = 0;
            elapsedTime_sec = 0;
            obj_weapon = is_weapon;

            //this is in milliseconds -> change out magic numbers later// may not be needed actually
            attackDuration = 100;


            //how long to move b4 commencing a attack -> change out magic numbers later
            attackPerMovement = 100;//This is for dino and all the enemies

            stopMoveTime = false;
        }


        private int getTimeMilli()
        {

            
            return Game1.deltaTime.ElapsedGameTime.Milliseconds;
        }


        private int getTimeSeconds()
        {
            return Game1.deltaTime.ElapsedGameTime.Seconds;
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
           UpdateElaspedMilli();
           return elapsedTime_milli >= ms_per_frame_animation;
            
        }
        //check if direction change is needed for wandering movement
        public bool checkRandMovementTime()
        {
             if (elapsed_move__sec >= Random.RandomMilli())
            {
                elapsed_move__sec = 0;
                return true;
            }
            return false;
        }

        public bool checkIfAttackTime()
        {
            elapsed_move__sec += 1;
            if (elapsed_move__sec >= attackPerMovement)
            {
                elapsed_move__sec = 0;
                stopMoveTime = true;
                return true;
            }
            return false;
        }

        public bool checkIfAttackTimeRandom()
        {
            elapsed_move__sec += 1;
            if (elapsed_move__sec >= Random.RandomMilli())
            {
                elapsed_move__sec = 0;
                stopMoveTime = true;
                return true;
            }
            return false;
        }



        //Can be factored out later
        public bool CreateAttackAqua()
        {
            elapsed_move__sec += 1;
            if (elapsed_move__sec >= 100)
            {
                elapsed_move__sec = 0;
                
                return true;
            }
            return false;
        }

        //Set time for movement duration in 1 direction for wandering movement
        public void setRandMovementTimeFrame()
        {
           movement_timeframe_sec =  Random.RandomMilli();
        }

        //Keeps track of the time spent moving
        public void updateElapsedMoveTime()
        {
            if(!stopMoveTime)
            {
                elapsed_move__sec += 1;
            }
        }

        public void enableMoveTime()
        {
            stopMoveTime = false;
        }


        public bool PaceTime(int pace)
        {
            if (elapsed_move__sec >= pace)
            {
                elapsed_move__sec = 0;
                return true;
            }
            return false;
        }

    }
}
