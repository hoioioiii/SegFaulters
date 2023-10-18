using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
namespace Project1
{
    internal interface IMove
    {

        public void WanderMove();
        public void circularMovement(Direction start_direction);
        public void setPosition(int x, int y);
        public (int, int) getPosition();


    }
}
