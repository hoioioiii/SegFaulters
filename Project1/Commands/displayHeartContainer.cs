using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayHeartContainer : ICommand
    {
        public void Execute()
        {
            if (Inventory.itemInventory[(int)ITEMS.HeartContainer] > 0)
            {
               // ItemIterator.pointer = (int)ITEMS.HeartContainer;
               // Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

