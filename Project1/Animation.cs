using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    internal class Animation : IAnimation
    {

        private int curr_frame;

        private int total_frame;

        private ITime time_manager;

        //might change later according to new sprite factory
        public Animation(int frame, int total,ITime time_manager) { 
           
            this.total_frame = total;
            this.curr_frame = frame;
            this.time_manager = time_manager;   
        }



        public void Animate()
        {
           
            if (this.time_manager.checkAnimationFrameTime())
            {
                this.time_manager.resetElaspedMilli();
                this.curr_frame += 1;
            }
        }

        public int getCurrentFrame()
        {
            return this.curr_frame;
            
        }

        private void checkCurrentFrame()
        {
            if (this.curr_frame >= this.total_frame)
                //start frame will change depending on new sprite factory
                this.curr_frame = START_FRAME;
        }

    }
}
