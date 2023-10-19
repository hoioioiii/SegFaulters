using System;
<<<<<<< Updated upstream
using static Project1.Constants;
namespace Project1.Commands
{
	public class displayArrow : ICommand
    {
        public void Execute()
        {
			if (Player.itemInventory[(int)ITEMS.Arrow] > 0)
			{
				ItemIterator.pointer = (int)ITEMS.Arrow;
                Game1.Item = ItemIterator.getCurrItem();
            }
=======
namespace Project1.Commands
{
	public class displayArrow
	{
		public displayArrow()
		{
>>>>>>> Stashed changes
		}
	}
}

