using System;
namespace Project1.Commands
{
	public class RoomIterateBack : ICommand
	{
        public void Execute()
        {
            Game1.GameObjManager.clearAll();
            RoomManager.DecrementActiveRoom();
        }
    }
}

