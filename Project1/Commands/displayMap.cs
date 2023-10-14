using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayMap : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Map] > 0)
            {
                ItemIterator.pointer = (int)ITEMS.Map;
                Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

