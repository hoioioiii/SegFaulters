using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayRupee : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Rupee] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Rupee;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

