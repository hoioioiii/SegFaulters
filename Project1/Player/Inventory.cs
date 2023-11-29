using System;
using static Project1.Constants;

namespace Project1
{
	public static class Inventory
	{
        public static void PickUpItem(ITEMS itemToAdd)
        {
            Player.itemInventory[(int)itemToAdd] = Player.itemInventory[(int)itemToAdd] + 1;
        }

        public static bool UseItem(ITEMS itemToDelete)
        {
            bool didItemGetUsed;
            if (Player.itemInventory[(int)itemToDelete] > 0)
            {
                Player.itemInventory[(int)itemToDelete]--;
                didItemGetUsed = true; //if player has item, it got used.
            }
            else
            {
                didItemGetUsed = false; //if player does not have item, it did not get used.
            }

            return didItemGetUsed;
        }
    }
}

