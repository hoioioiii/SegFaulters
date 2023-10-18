using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal interface ITime
    {

        //public int getTimeMilli()

        //public int getTimeSeconds()  



        public void UpdateElaspedMilli();

        public void UpdateElaspedSec();

        public void resetElaspedMilli();

        public void resetElaspedSec();
        public bool checkAnimationFrameTime();

    }
}
