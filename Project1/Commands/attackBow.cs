using System;
namespace Project1
{
    public class attackBow : ICommand
    {
        public void Execute()
        {
            if (!Player.isAttacking)
            {
                PlayerAttack.attackBow();
            }
        }
    }
}
