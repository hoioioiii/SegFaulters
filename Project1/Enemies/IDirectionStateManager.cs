using System;
using static Project1.Constants;

namespace Project1.Enemies
{
    public interface IDirectionStateManager
    {
        public Direction GetDirection();
        public void SetDirection(Direction direction);

        public void ChangeDirection();

        public void NeedDirectionUpdate(bool dir_flag);

        public Direction GetRandomDirection();
    }
}
