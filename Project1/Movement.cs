using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;
using static Project1.Constants;

namespace Project1
{
    public class Movement : IMove
    {
        private IDirectionStateManager direction_state;
        private ISprite entityObj;
        private ITime time_manager;
        private int pos_x;
        private int pos_y;
        private double angle;
        private double speed;


        public Movement(IDirectionStateManager direction_state, ISprite entityObj, ITime time_manager, int x, int y, int spd) { 
        
            this.direction_state = direction_state;
            this.entityObj = entityObj;
            this.time_manager = time_manager;

            MovementBasedGrid(x,y);
            
            this.angle = 0;
            this.speed = spd;
        }

        private void MovementBasedGrid(int x, int y)
        {

            (int, int) pos = PositionGrid.getPosBasedOnGrid(x, y);
            this.pos_x = pos.Item1;
            this.pos_y = pos.Item2;
        }
        private int MoveUpOrLeft(int pos)
        {
            return pos -=1;
        }

        private int MoveDownOrRight(int pos)
        {
            return pos += 1;
        }

        private void VerticalMovement(Direction start_direction)
        {
            (int,int) pos_pair  = entityObj.getPos();
            (bool, int) update_pair = (false, pos_pair.Item2);
            Direction direct = direction_state.getDirection();
            bool isMoving = false;

            if (direct != Direction.Up && direct != Direction.Down)
            {
                direction_state.setDirection(start_direction);
            }
            else
            {
               isMoving = true;
               update_pair = moveVertical(update_pair.Item2, direct);
            }           

            pos_pair.Item2 = update_pair.Item2;
            updateMovement(isMoving, pos_pair, update_pair.Item1);

        }

        private (bool,int) moveVertical(int pos, Direction direct)
        {
            switch (direct)
            {
                case Direction.Down:
                    return CheckBound(MoveDownOrRight(pos), SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);  

                case Direction.Up:
                    return CheckBound(MoveUpOrLeft(pos), SCREEN_HEIGHT_UPPER, SCREEN_HEIGHT_LOWER);
            }
            return (false, pos);
        }

        private void updateMovement(bool canMove, (int, int) pos_pair,bool dir_flag)
        {
            if (canMove)
            {
                direction_state.NeedDirectionUpdate(dir_flag);

                if (!dir_flag)
                entityObj.setPos(pos_pair.Item1, pos_pair.Item2);
            }

        }


        private (bool,int) moveHorizontal(int pos, Direction direct)
        {
            switch (direct)
            {
                case Direction.Right:
                    return CheckBound(MoveDownOrRight(pos), SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);

                case Direction.Left:
                    return CheckBound(MoveUpOrLeft(pos), SCREEN_WIDTH_UPPER, SCREEN_WIDTH_LOWER);
            }
            return (false, pos);

        }


        public void HorizontalMovement(Direction start_direction)
        {
           
            (int, int) pos_pair = entityObj.getPos();
            (bool, int) update_pair = (false, pos_pair.Item1);
            Direction direct = direction_state.getDirection();
            bool isMoving = false;

            if (direct != Direction.Left && direct != Direction.Right)
            {
                direction_state.setDirection(start_direction);
            }
            else
            {
                isMoving = true;
                update_pair = moveHorizontal(update_pair.Item2, direct);
            }
            pos_pair.Item1 = update_pair.Item2;
            updateMovement(isMoving, pos_pair, update_pair.Item1);
        }

        //can remove param later
        public void circularMovement(Direction start_direction)
        {
            angle += 0.1;
            int originX = entityObj.getPos().Item1 - Random.RandomOriginOffset();
            int originY = entityObj.getPos().Item2 - Random.RandomOriginOffset();

            double cos = Math.Cos(angle) * Random.RandomRadius();
            double sin = Math.Sin(angle) * Random.RandomRadius();

            entityObj.setPos((int)(originX + cos), (int)(originY + sin));
        }

        public void WanderMove()
        {
            time_manager.setRandMovementTimeFrame();
            time_manager.updateElapsedMoveTime();

            //means to change directions
            if (time_manager.checkRandMovementTime())
            {
                direction_state.getRandomDirection();

            }
            WandererMovement(direction_state.getDirection());
        }

        private void WandererMovement(Direction start_direction)
        { 
            switch (start_direction)
            {
                case Direction.Left:
                    HorizontalMovement(Direction.Left);
                    break;
                case Direction.Up:
                    VerticalMovement(Direction.Up);
                    break;
                case Direction.Down:
                    VerticalMovement(Direction.Down);
                    break;
                case Direction.Right:
                    HorizontalMovement(Direction.Right);
                    break;
            }
        }

       


        //public void DiagonalMovement(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        //{

           
        //}

        //public void Stop(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        //{
        //    //change state of isMoving to false in enemy state
        //}




        public void setPosition(int x, int y)
        {
            this.pos_y = y;
            this.pos_x = x;

        }

        public (int, int) getPosition()
        {
            return (pos_x, pos_y);
        }

        //Checks the bounds for the screen or input. Will be replaced w collision stuff
        private (bool,int) CheckBound(int currPos, int UpperBound, int LowerBound)
        {
           
            if (currPos >= UpperBound)
            {
                return (true,fixPosition(UpperBound, currPos));
            }

            else if (currPos < LowerBound)
            {
                return (true, fixPosition(LowerBound, currPos));
            }

            return (false, currPos);
        }

        private int fixPosition(int bound, int pos)
        {
            return (pos + (bound - pos));
        }

    

    }
}
