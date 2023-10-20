using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
using static Project1.Constants.Direction;


namespace Project1.Enemies
{
    public class DirectionStateEnemy : IDirectionStateManager
    {
        
        
        private Direction current_direction;
        private Dictionary<Direction, Direction> oppositeDirection;

        public DirectionStateEnemy(Direction direction_state)
        {

            current_direction = direction_state;
            createOppositeDirectionMapping();

        }


        private void createOppositeDirectionMapping()
        {
            oppositeDirection = new Dictionary<Direction, Direction>
            {
                { Direction.Left, Direction.Right },
                { Direction.Up, Direction.Down },
                { Direction.Right, Direction.Left },
                { Direction.Down, Direction.Up }
            };
        }

        public void changeDirection()
        {
            setDirection(oppositeDirection.GetValueOrDefault(current_direction));
        }

        public Direction getDirection()
        {
            return current_direction;
        }

        public void setDirection(Direction state)
        {
            this.current_direction = state;
        }

        public void NeedDirectionUpdate(bool update_flag)
        {
            if (update_flag)
            {
                changeDirection();
            }

        }

        public Direction getRandomDirection()
        {
            setDirection(Random.RandomDirection());
            return getDirection();
        }
    }
}
