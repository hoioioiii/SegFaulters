using System;
namespace Project1
{
	public class MoveDown : ICommand
    {
		public void Execute()
		{
			if (!Player.isAttacking)
			{
				PlayerMovement.down();
			}
		}
	}
}

