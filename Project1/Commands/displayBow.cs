using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayBow : ICommand
	{
        public void Execute()
        {
            if (Inventory.itemInventory[(int)ITEMS.Bow] > 0)
            {
                //ItemIterator.pointer = (int)ITEMS.Bow;
//Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

