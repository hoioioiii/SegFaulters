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
    internal class Movement
    {



        public static int MoveUpOrLeft(int pos)
        {
            return pos -=1;
        }

        public static int MoveDownOrRight(int pos)
        {
            return pos += 1;
        }

        public static void VerticalMovement(IDirectionStateManager direction_state, ISprite entityObj, Direction start_direction)
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
            updateMovement(isMoving, pos_pair, update_pair.Item1, direction_state, entityObj);

        }

        private static (bool,int) moveVertical(int pos, Direction direct)
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

        private static void updateMovement(bool canMove, (int, int) pos_pair,bool dir_flag, IDirectionStateManager direction_state, ISprite entityObj)
        {
            if (canMove)
            {
                direction_state.NeedDirectionUpdate(dir_flag);

                if (!dir_flag)
                entityObj.setPos(pos_pair.Item1, pos_pair.Item2);
            }

        }


        private static (bool,int) moveHorizontal(int pos, Direction direct)
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


        public static void HorizontalMovement(IDirectionStateManager direction_state, ISprite entityObj, Direction start_direction)
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
            updateMovement(isMoving, pos_pair, update_pair.Item1, direction_state, entityObj);
        }


        public static void circularMovement(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        {

         
        }


        public static void WandererMovement(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        { 
            

            switch (start_direction)
            {
                case Direction.Left:
                    HorizontalMovement(direction_state, entityOb, Direction.Left);
                    break;
                case Direction.Up:
                    VerticalMovement(direction_state, entityOb, Direction.Up);
                    break;
                case Direction.Down:
                    VerticalMovement(direction_state, entityOb, Direction.Down);
                    break;
                case Direction.Right:
                    HorizontalMovement(direction_state, entityOb, Direction.Right);
                    break;
            }
        }

        public static void WanderMove(IDirectionStateManager directionStateManager, ISprite entityObj, ITime time_manager)
        {
            time_manager.setRandMovementTimeFrame();
            time_manager.updateElapsedMoveTime();

            //means to change directions
            if (time_manager.checkRandMovementTime())
            {
                directionStateManager.getRandomDirection();

            }
            Movement.WandererMovement(directionStateManager, entityObj, directionStateManager.getDirection());
        }


        public static void DiagonalMovement(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        {

           
        }

        



        public static void Stop(IDirectionStateManager direction_state, ISprite entityOb, Direction start_direction)
        {
            //change state of isMoving to false in enemy state
        }



        //Checks the bounds for the screen or input. Will be replaced w collision stuff
        private static (bool,int) CheckBound(int currPos, int UpperBound, int LowerBound)
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

        private static int fixPosition(int bound, int pos)
        {
            return (pos + (bound - pos));
        }

    }
}
