using System;
namespace Project1
{
	public class attackBeehive : ICommand
    {
        public void Execute()
        {
            if (!Player.isAttacking)
            {
                PlayerAttack.attackBeehive();
            }
        }
    }
}

