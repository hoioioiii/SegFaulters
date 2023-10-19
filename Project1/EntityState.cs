using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class EntityState : IEntityState
    {
        private bool alive;

        private bool attacking;

        private bool damaged;

        private bool moving;

        private bool newAttack;

        public EntityState() { 
        
            alive = true;
            attacking = false;
            damaged = false;
            moving = true;
            newAttack = false;
        }
        public bool IsAlive()
        {
            return alive;
        }

        public bool IsAttacking()
        {
            return attacking;
        }

     

        public bool isMoving()
        {
            return moving;
        }

        public void setDamaged(bool update)
        {
            damaged = update;
        }

        public void setIsAlive(bool update)
        {
          alive = update;
        }

        public void setIsAttacking(bool update)
        {
            attacking = update;
        }

        public void setIsMoving(bool update)
        {
            moving = update;
        }

        public bool isDamaged()
        {
            return damaged;
        }

        public bool startNewAttack()
        {
            return newAttack;
        }

        public void setNewAttack(bool update)
        {
            newAttack = update;
        }
    }
}
