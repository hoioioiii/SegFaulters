using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class Animation : IAnimation
    {
        

        private int curr_frame;

        private int total_frame;

        private ITime time_manager;
        private IDirectionStateManager direction_manager;

        private int start_frame;
        private bool direction_change;
        private int frame_direct;

        public Texture2D sprite_frame { get; private set; }
        public List<Texture2D[]> frame_list { private get;  set; }



        //might change later according to new sprite factory
        public Animation(int frame, ITime time_manager, IDirectionStateManager direct_manager) { 
           
            this.frame_list = null;
            //this.total_frame = total;
            this.curr_frame = frame;
            this.time_manager = time_manager;
            this.direction_manager = direct_manager;
            this.start_frame = START_FRAME;
            this.direction_change = false;
            
        }

        public void PopulateFrames()
        {
            getDirectionArray(direction_manager.getDirection());
        }

        private void getDirectionArray(Direction direct)
        {
            System.Diagnostics.Debug.WriteLine("In get DirectionArray");
            switch (direct)
            {

                case Direction.Up:
                    frame_direct = UP;
                    System.Diagnostics.Debug.WriteLine("In get UP direction frame " + UP);
                    break;
                case Direction.Right:
                    frame_direct = RIGHT;
                    System.Diagnostics.Debug.WriteLine("In get right direction frame " + RIGHT);
                    break;
                case Direction.Down:
                    frame_direct = DOWN;
                    System.Diagnostics.Debug.WriteLine("In get down direction frame " + DOWN);
                    break;
                case Direction.Left:
                    frame_direct = LEFT;
                    System.Diagnostics.Debug.WriteLine("In get left direction frame "  + LEFT);
                    break;
            }
            this.total_frame = frame_list[frame_direct].Length;

            checkCurrentFrame();
            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }



        public void Animate()
        {

            getDirectionArray(direction_manager.getDirection());
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
           
            if (direction_change)
            {
                getDirectionArray(direction_manager.getDirection());
                direction_change = false;
            }

            if (this.curr_frame >= this.total_frame)
                //start frame will change depending on new sprite factory
                this.curr_frame = start_frame;

            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }

    
        //not needed
        public void setTotalFrame(int frameNum)
        {

            total_frame = frameNum;
        }

        //not needed
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
