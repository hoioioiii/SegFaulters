using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayHeart : ICommand
	{
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Heart] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Heart;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

