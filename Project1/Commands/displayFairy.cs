using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayFairy : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Fairy] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Fairy;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

