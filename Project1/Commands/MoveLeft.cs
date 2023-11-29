using System;
namespace Project1
{
	public class MoveLeft : ICommand
    {
		public void Execute()
		{
            if (GameStateManager.GameState == GameState.DefaultState)
            {
                if (!Player.isAttacking)
                {
                    PlayerMovement.left();
                }
            }
            else if (GameStateManager.GameState == GameState.PausedState)
            {
                GameStateManager.PausedScreen.moveSelectorLeft();

            }

        }
    
	}
}

