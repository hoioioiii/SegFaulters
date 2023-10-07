using System;
namespace Project1
{
	public class MoveRight : ICommand
	{
		public void Execute()
		{
			if (!Player.isAttacking)
			{
				Player.right();
			}
		}
	}
}

