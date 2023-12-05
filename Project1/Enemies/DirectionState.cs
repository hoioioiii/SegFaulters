using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
using static Project1.Constants.Direction;


namespace Project1.Enemies
{
    public class DirectionState : IDirectionStateManager
    {
        
        
        private Direction current_direction;
        private Dictionary<Direction, Direction> oppositeDirection;

        public DirectionState(Direction direction_state)
        {

            current_direction = direction_state;
            CreateOppositeDirectionMapping();

        }


        private void CreateOppositeDirectionMapping()
        {
            oppositeDirection = new Dictionary<Direction, Direction>
            {
                { Direction.Left, Direction.Right },
                { Direction.Up, Direction.Down },
                { Direction.Right, Direction.Left },
                { Direction.Down, Direction.Up }
            };
        }

        public void ChangeDirection()
        {
            SetDirection(oppositeDirection.GetValueOrDefault(current_direction));
        }

        public Direction GetDirection()
        {
            return current_direction;
        }

        public void SetDirection(Direction state)
        {
            this.current_direction = state;
        }

        public void NeedDirectionUpdate(bool update_flag)
        {
            if (update_flag)
            {
                ChangeDirection();
            }
        }
        public Direction GetRandomDirection()
        {
            SetDirection(Random.RandomDirection());
            return GetDirection();
        }
    }
}
