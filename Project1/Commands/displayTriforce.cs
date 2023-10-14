using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayTriforce : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Triforce] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Triforce;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

