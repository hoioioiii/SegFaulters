using System;
using static Project1.Constants;

namespace Project1.Enemies
{
    public interface IDirectionStateManager
    {
        public Direction getDirection();
        public void setDirection(Direction direction);

        public void changeDirection();

        public void NeedDirectionUpdate(bool dir_flag);

        public Direction getRandomDirection();
    }
}
