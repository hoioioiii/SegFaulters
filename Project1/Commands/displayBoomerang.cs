using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displayBoomerang : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Boomerang] > 0)
            {
                //ItemIterator.pointer = (int)ITEMS.Boomerang;
                //Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

