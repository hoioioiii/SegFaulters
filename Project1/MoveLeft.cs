using System;
namespace Project1
{
	public class MoveLeft : ICommand
    {
		public void Execute()
		{
			if (!Player.isAttacking)
			{
				if (!Player.isDead) { 
					Player.left();
				}
			}
		}
	}
}

