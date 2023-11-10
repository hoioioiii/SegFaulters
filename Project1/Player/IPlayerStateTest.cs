using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public interface IPlayerStateTest
    {
        public bool isAlive {get;}

        public bool isAttacking { get; }
        public bool isMoving { get; }
        public void setAttacking(bool state);
        public void setDead(bool state);
        public void setMove(bool state);

    }
}
