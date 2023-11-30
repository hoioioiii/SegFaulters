using System;
using static Project1.Constants;
namespace Project1.Commands
{
	public class displayArrow : ICommand
    {
        public void Execute()
        {
			if (Inventory.itemInventory[(int)ITEMS.Arrow] > 0)
			{
				//ItemIterator.pointer = (int)ITEMS.Arrow;
                //Game1.Item = ItemIterator.getCurrItem();
            }
		}
	}
}

