using System;
namespace Project1.Commands
{
	public class RoomIterateForward : ICommand
	{
        public void Execute()
        {
            if (GameStateManager.GameState == GameState.DefaultState)
            {
                RoomManager.IncrementActiveRoom();
            }
        }
    }
}

