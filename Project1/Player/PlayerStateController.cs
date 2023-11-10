using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PlayerStateController : IPlayerStateTest
    {
        public bool isAlive { get; private set; }

        public bool isAttacking { get; private set; }

        public bool isMoving { get; private set; }


        public PlayerStateController()
        {
            isAlive = true;
            isAttacking = false;
            isMoving = false;
        }

        public void setAttacking(bool state)
        {
            //if state is true and enemy is frozen, set attacking as true
            isAttacking = (state && !isMoving) ? state : false;
        }

        public void setDead(bool state)
        {
            isAlive = (state && !isMoving && !isAttacking) ? false : true;
        }

        public void setMove(bool state)
        {
            //if attacking is false, then we can move
            isMoving = (state && !isAttacking) ? state : false;
        }
    }
}
