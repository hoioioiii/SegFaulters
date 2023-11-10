using System;
namespace Project1
{
	public class MoveRight : ICommand
	{
		public void Execute()
		{
			if(GameStateManager.GameState == GameState.DefaultState)
			{
                if (!Player.isAttacking)
                {
                    Player.right();
                }
            } else if(GameStateManager.GameState == GameState.PausedState)
			{
                GameStateManager.PausedScreen.moveSelectorRight();

            }

		}
	}
}

