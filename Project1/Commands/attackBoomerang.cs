using System;
namespace Project1
{
    public class attackBoomerang : ICommand
    {
        public void Execute()
        {
            if (!Player.isAttacking) {
                PlayerAttack.attackBoom();
            }
        }
    }
}


