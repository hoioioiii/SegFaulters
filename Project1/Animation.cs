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


        public Animation(int frame, ITime time_manager, IDirectionStateManager direct_manager) { 
           
            this.frame_list = null;
            this.curr_frame = frame;
            this.time_manager = time_manager;
            this.direction_manager = direct_manager;
            this.start_frame = START_FRAME;
            this.direction_change = false;
            
        }

        public void PopulateFrames()
        {
            GetDirectionArray(direction_manager.GetDirection());
        }

        private void GetDirectionArray(Direction direct)
        {
            switch (direct)
            {
                case Direction.Up:
                    frame_direct = UP;
                    break;
                case Direction.Right:
                    frame_direct = RIGHT;
                    break;
                case Direction.Down:
                    frame_direct = DOWN;
                    break;
                case Direction.Left:
                    frame_direct = LEFT;
                    break;
            }
            this.total_frame = frame_list[frame_direct].Length;

            CheckCurrentFrame();
            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }



        public void Animate()
        {
            GetDirectionArray(direction_manager.GetDirection());
            if (this.time_manager.checkAnimationFrameTime())
            {
                this.time_manager.resetElaspedMilli();
                this.curr_frame += 1;
            }
            CheckCurrentFrame();
            
        }

        public int GetCurrentFrame()
        {
            return this.curr_frame;
            
        }

        private void CheckCurrentFrame()
        {
           
            if (direction_change)
            {
                GetDirectionArray(direction_manager.GetDirection());
                direction_change = false;
            }
            if (this.curr_frame >= this.total_frame)
               
                this.curr_frame = start_frame;

            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }

        public void SetTotalFrame(int frameNum)
        {
            total_frame = frameNum;
        }

        public void SetStartFrame(int frameNum)
        {

            start_frame = frameNum;
        }

        public void NeedSpriteDirectionImage(bool update)
        {
            direction_change = update;
        }
    }
}
