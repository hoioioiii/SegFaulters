using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayBomb : ICommand
    {
        public void Execute()
        {
            if (Inventory.itemInventory[(int)ITEMS.Bomb] > 0)
            {
                //ItemIterator.pointer = (int)ITEMS.Bomb;
                //Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

