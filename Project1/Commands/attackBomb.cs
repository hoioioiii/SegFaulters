using System;
using static Project1.Constants;
namespace Project1
{
    public class attackBomb : ICommand
    {
        public void Execute()
        {
            if (!Player.isAttacking)
            {
                PlayerAttack.attackBomb();
            }
        }
    }
}
