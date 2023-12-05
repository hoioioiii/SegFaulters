using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
namespace Project1
{
    public class TimeTracker: ITime
    {
   

        private int elapsedTime_sec;
        private int movement_timeframe_sec;
        private int elapsed_move__sec;
        private int elapsedTime_milli;
     
        private bool stopMoveTime;

     

        public TimeTracker(bool is_weapon) {

            elapsedTime_milli = 0;
            elapsedTime_sec = 0;
            stopMoveTime = false;
        }


        private int GetTimeMilli()
        {
            return Game1.deltaTime.ElapsedGameTime.Milliseconds;
        }


        private int GetTimeSeconds()
        {
            return Game1.deltaTime.ElapsedGameTime.Seconds;
        }

        public void UpdateElaspedMilli()
        {

            elapsedTime_milli += GetTimeMilli();
        }


        public void UpdateElaspedSec()
        {
            elapsedTime_sec += GetTimeSeconds();
        }


        public void ResetElaspedMilli()
        {
            elapsedTime_milli -= MS_PER_FRAME;
        }


        public void ResetElaspedSec()
        {
            elapsedTime_sec -= MS_PER_FRAME;
        }


        public bool CheckAnimationFrameTime()
        {
           UpdateElaspedMilli();
           return elapsedTime_milli >= MS_PER_FRAME;
            
        }
       


        public bool CheckRandMovementTime()
        {
             if (elapsed_move__sec >= Random.RandomMilli())
            {
                elapsed_move__sec = 0;
                return true;
            }
            return false;
        }


        public bool CheckRandMovementTimeBat()
        {
            if (elapsed_move__sec >= 10000)
            {
                elapsed_move__sec = 0;
                return true;
            }
            return false;
        }

        public bool CheckIfAttackTime()
        {
            elapsed_move__sec += 1;
            if (elapsed_move__sec >= ATTACK_PER_MOVEMENT)
            {
                elapsed_move__sec = 0;
                stopMoveTime = true;
                return true;
            }
            return false;
        }

        public bool CheckIfAttackTimeRandom()
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

       
        public void SetRandMovementTimeFrame()
        {
           movement_timeframe_sec =  Random.RandomMilli();
        }

       
        public void UpdateElapsedMoveTime()
        {
            if(!stopMoveTime)
            {
                elapsed_move__sec += 1;
            }
        }

        public void EnableMoveTime()
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
