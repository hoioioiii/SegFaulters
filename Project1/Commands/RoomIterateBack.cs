using System;
namespace Project1.Commands
{
	public class RoomIterateBack : ICommand
	{
        public void Execute()
        {
            if(GameStateManager.GameState == GameState.DefaultState)
            {
                RoomManager.DecrementActiveRoom();
            }
            
        }
    }
}

