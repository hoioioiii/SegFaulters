using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Project1.Enemies;
using static Project1.Constants;
namespace Project1
{
    public class PlayerAnimation : IAnimationPlayer
    {

        private int curr_frame;
        private int total_frame;

        private ITime time_manager;
        private IDirectionStateManager direction_manager;
        private IPlayerStateTest playerState;
        private int start_frame;
        private bool direction_change;
        private int frame_direct;

        public Texture2D sprite_frame { get; private set; }
        public List<Texture2D[]> frame_list { private get; set; }
        public static Texture2D[] stillFrame_list { private get; set; }
        public static Texture2D[] attackingFrame_list { private get; set; }


        //might change later according to new sprite factory
        public PlayerAnimation(int frame, ITime time_manager, IDirectionStateManager direct_manager, IPlayerStateTest state)
        {

            this.frame_list = null;
            //this.total_frame = total;
            this.curr_frame = frame;
            this.time_manager = time_manager;
            this.direction_manager = direct_manager;
            this.start_frame = START_FRAME;
            this.direction_change = false;
            this.playerState = state;
        }

        public void SetAttackFrame()
        {
            
           GetDirectionArray(direction_manager.GetDirection(),playerState.isAttacking, playerState.isMoving);
            
        }

      

        public void PopulateFrames()
        {
            GetDirectionArray(direction_manager.GetDirection(),false,false);
        }

        private void GetDirectionArray(Direction direct, bool isAttack, bool isStill)
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

            ChangeCurrentSpriteFrames(isStill,isAttack);
            
            
        }

        private void ChangeCurrentSpriteFrames(bool isStill, bool isAttack)
        {
            //if it is not moving then we want to use the still sprite array
            if (isStill)
            {
                this.total_frame = stillFrame_list.Length;
                this.sprite_frame = stillFrame_list[frame_direct];

            }
            else if (isAttack)
            {
                this.total_frame = attackingFrame_list.Length;
                this.sprite_frame = attackingFrame_list[frame_direct];

            }
            else
            {
                this.total_frame = frame_list[frame_direct].Length;
                CheckCurrentFrame();
                this.sprite_frame = frame_list[frame_direct][curr_frame];
            }
        }


        public void Animate()
        {
            GetDirectionArray(direction_manager.GetDirection(),playerState.isAttacking,playerState.isMoving);
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
                GetDirectionArray(direction_manager.GetDirection(),playerState.isAttacking, playerState.isMoving);
                direction_change = false;
            }
            if (this.curr_frame >= this.total_frame)
                //start frame will change depending on new sprite factory
                this.curr_frame = start_frame;

            this.sprite_frame = frame_list[frame_direct][curr_frame];
        }


        //not needed
        public void SetTotalFrame(int frameNum)
        {
            total_frame = frameNum;
        }

        //not needed
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
