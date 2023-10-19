using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal interface IEntityState
    {
        public void setIsMoving(bool update);
        public bool isMoving();
        public void setDamaged(bool update);
        public bool isDamaged();

        public void setIsAttacking(bool update);

        public bool IsAttacking();

        public bool IsAlive();

        public void setIsAlive(bool update);
        public void setNewAttack(bool update);
        public bool startNewAttack();

    }
}
