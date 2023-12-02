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
    public class AnimationBees : IAnimation
    {
        

        private int curr_frame;

        private int total_frame;

        private ITime time_manager;
        private int direction;

        private int start_frame;
        private bool direction_change;
        private int frame_direct;

        public Texture2D sprite_frame { get; private set; }
        public List<Texture2D[]> frame_list { private get;  set; }



        //might change later according to new sprite factory
        public AnimationBees(int frame, ITime time_manager, List<Texture2D[]> spritesheet) { 
           
            this.frame_list = spritesheet;
            //this.total_frame = total;
            this.curr_frame = frame;
            this.time_manager = time_manager;
            this.direction = Player.getUserDirection();
            this.start_frame = START_FRAME;
            this.direction_change = false;
            
        }

        public void PopulateFrames()
        {
            GetDirectionArray(direction);
        }

        private void GetDirectionArray(int direct)
        {
            switch (direct)
            {
                case 0:
                    frame_direct = UP;
                    break;
                case 1:
                    frame_direct = RIGHT;
                    break;
                case 2:
                    frame_direct = DOWN;
                    break;
                case 3:
                    frame_direct = LEFT;
                    break;
            }
            if (frame_list.Count == 1)
            {
                frame_direct = UP;
            }


            this.total_frame = frame_list[frame_direct].Length;

            CheckCurrentFrame();
            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }



        public void Animate()
        {
            GetDirectionArray(direction);
            if (this.time_manager.CheckAnimationFrameTime())
            {
                this.time_manager.ResetElaspedMilli();
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
                GetDirectionArray(direction);
                direction_change = false;
            }
            if (this.curr_frame >= this.total_frame)
                this.curr_frame = start_frame;

            
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
