using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project1.Enemies;
using Project1.SmartAI;
using static Project1.Constants;

namespace Project1
{
    public class Movement : IMove
    {
        private IDirectionStateManager direction_state;
        private IEntity entityObj;
        private ITime time_manager;
        private int pos_x;
        private int pos_y;
        private double angle;
        private double speed;
        private int directionIndicator;

        private RangeDetectionToPlayer rangeDetector;

        //for testing purposes only:
        private int elaspedTime;

        public Movement(IDirectionStateManager direction_state, IEntity entityObj, ITime time_manager, int x, int y, int spd) { 
        
            this.direction_state = direction_state;
            this.entityObj = entityObj;
            this.time_manager = time_manager;
            this.rangeDetector = new RangeDetectionToPlayer(this, RANGE_RADIUS);
            MovementBasedGrid(x,y);
            
            this.angle = 0;
            this.speed = spd;
            elaspedTime = 0;

            directionIndicator = 1;



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
            Direction direct = direction_state.GetDirection();
            bool isMoving = false;

            if (direct != Direction.Up && direct != Direction.Down)
            {
                direction_state.SetDirection(start_direction);
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
                    
                    return CheckBound(MoveDownOrRight(pos), roomBoundsMaxY, roomBoundsMinY);  

                case Direction.Up:
                    
                    return CheckBound(MoveUpOrLeft(pos), roomBoundsMaxY, roomBoundsMinY);
            }
            return (false, pos);
        }

        private void updateMovement(bool canMove, (int, int) pos_pair,bool dir_flag)
        {
            
            if (canMove)
            {
                direction_state.NeedDirectionUpdate(dir_flag);

                if (!dir_flag)
                entityObj.setPosition(pos_pair.Item1, pos_pair.Item2);
            }
            

        }


        private (bool,int) moveHorizontal(int pos, Direction direct)
        {
            switch (direct)
            {
                case Direction.Right:
                    
                    return CheckBound(MoveDownOrRight(pos), roomBoundsMaxX, roomBoundsMinX);

                case Direction.Left:
                    
                    return CheckBound(MoveUpOrLeft(pos), roomBoundsMaxX, roomBoundsMinX);
            }
            return (false, pos);

        }


        public void HorizontalMovement(Direction start_direction)
        {
           
            (int, int) pos_pair = entityObj.getPos();
            (bool, int) update_pair = (false, pos_pair.Item1);
            Direction direct = direction_state.GetDirection();
            bool isMoving = false;

            if (direct != Direction.Left && direct != Direction.Right)
            {
                direction_state.SetDirection(start_direction);
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
           
                int x = entityObj.getPos().Item1;
                int y = entityObj.getPos().Item2;
                int originX = entityObj.getPos().Item1 - Random.RandomOriginOffset();
                int originY = entityObj.getPos().Item2 - Random.RandomOriginOffset();

                double cos = Math.Cos(angle) * Random.RandomRadius();
                double sin = Math.Sin(angle) * Random.RandomRadius();

               (bool, int) positionX = CheckBound((int)(originX + cos), roomBoundsMaxX, roomBoundsMinX);
               (bool, int) positionY = CheckBound((int)(originY + sin), roomBoundsMaxY, roomBoundsMinY);
            
            entityObj.setPosition(positionX.Item2,positionY.Item2);
            
        }

        public void WanderMove()
        {
            time_manager.SetRandMovementTimeFrame();
            time_manager.UpdateElapsedMoveTime();

            if (time_manager.CheckRandMovementTime())
            {
                direction_state.GetRandomDirection();

            }
            
            WandererMovement(direction_state.GetDirection());
            
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

       
        public void LeftAndRight()
        {

            //factor out later
            elaspedTime += Game1.deltaTime.ElapsedGameTime.Milliseconds;
            if (elaspedTime >= 1000)
            {
                directionIndicator *= -1;
                elaspedTime = 0;
            }

            if (directionIndicator < 0)
            {
                PaceLeftToRight(Direction.Right);
            }
            else
            {
                PaceLeftToRight(Direction.Left);
            }


        }


        private void PaceLeftToRight(Direction direct)
        {

            (int, int) pos_pair = entityObj.getPos();
            (bool, int) update_pair = (false, pos_pair.Item1);

            bool isMoving = true;

            update_pair = moveHorizontal(update_pair.Item2, direct);
            
            pos_pair.Item1 = update_pair.Item2;
            updateMovement(isMoving, pos_pair, update_pair.Item1);
        }


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
                return (true,fixPosition(UpperBound,LowerBound, currPos));
            }

            else if (currPos < LowerBound)
            {
                return (true, fixPosition(LowerBound,LowerBound, currPos));
            }

            return (false, currPos);
        }

        private int fixPosition(int boundUpper, int boundLower, int pos)
        {
            return Math.Clamp(pos, boundLower, boundUpper);
        }

        public Vector2 getVector()
        {
            return new Vector2(pos_x, pos_y);
        }

        public void SmartAIDetectionFieldMovement()
        {
            if (rangeDetector.DetectionField() == RangeTypeToMovement.SEEK)
            {
                SeekPlayer.Move(getVector(), this, SMARTAI_USER.ENTITY);
            }
            else
            {
                WanderMove();
            }

        }
    }
}
