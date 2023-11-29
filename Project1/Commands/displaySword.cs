using System;
using static Project1.Constants;

namespace Project1.Commands
{
	public class displaySword : ICommand
    {
        public void Execute()
        {
            if (Player.itemInventory[(int)ITEMS.Sword] > 0)
            {
                //ItemIterator.pointer = (int)ITEMS.Sword;
               // Game1.Item = ItemIterator.getCurrItem();
            }
        }
    }
}

