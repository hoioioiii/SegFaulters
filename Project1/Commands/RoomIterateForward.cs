using System;
namespace Project1.Commands
{
	public class RoomIterateForward : ICommand
	{
        public void Execute()
        {
            Game1.GameObjManager.clearAll();
            RoomManager.IncrementActiveRoom();
        }
    }
}

