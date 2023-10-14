using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayClock : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Clock] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Clock;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

