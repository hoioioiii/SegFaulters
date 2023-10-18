using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    internal class Animation : IAnimation
    {

        private int curr_frame;

        private int total_frame;

        private ITime time_manager;
        private IDirectionStateManager direction_manager;

        private int start_frame;

        private bool direction_change;

        //might change later according to new sprite factory
        public Animation(int frame, int total,ITime time_manager, IDirectionStateManager direct_manager) { 
           
            this.total_frame = total;
            this.curr_frame = frame;
            this.time_manager = time_manager;
            this.direction_manager = direct_manager;
            this.start_frame = START_FRAME;
            this.direction_change = false;
        }



        public void Animate()
        {
           
            if (this.time_manager.checkAnimationFrameTime())
            {
                this.time_manager.resetElaspedMilli();
                this.curr_frame += 1;
            }
            checkCurrentFrame();
        }

        public int getCurrentFrame()
        {
            return this.curr_frame;
            
        }

        private void checkCurrentFrame()
        {
            if(direction_change)
            {
                applyDirectionSpriteUpdate(direction_manager.getDirection());
                direction_change = false;
            }


            if (this.curr_frame >= this.total_frame)
                //start frame will change depending on new sprite factory
                this.curr_frame = start_frame;
        }

        //TODO: Fix sprite factory to work with this.
        private void applyDirectionSpriteUpdate(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:

                    
                    break;
                case Direction.Right:
                    break;
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
            }
        }

        public void setTotalFrame(int frameNum)
        {

            total_frame = frameNum;
        }
        public void setStartFrame(int frameNum)
        {

            start_frame = frameNum;
        }

        public void needSpriteDirectionImage(bool update)
        {
            direction_change = update;
        }
    }
}
