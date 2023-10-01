using System;
namespace Project1
{
    public class attackSword : ICommand
    {
        public void Execute()
        {
            if (!Player.isAttacking)
            {
                Player.attackSword();
            }
        }
    }
}
