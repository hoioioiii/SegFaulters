using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface ITime
    {

        //public int getTimeMilli()

        //public int getTimeSeconds()  



        public void UpdateElaspedMilli();

        public void UpdateElaspedSec();

        public void resetElaspedMilli();

        public void resetElaspedSec();
        public bool checkIfAttackTimeRandom();
        public bool checkAnimationFrameTime();

        //How long to to be moving in 1 direction before needing to either stop or change directions
        public bool checkRandMovementTime();
        public void setRandMovementTimeFrame();

        public void updateElapsedMoveTime();
        public bool checkIfAttackTime();
        public void enableMoveTime();

        public bool PaceTime(int pace);


        public bool CreateAttackAqua();
    }
}
