using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayKey : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Key] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Key;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

